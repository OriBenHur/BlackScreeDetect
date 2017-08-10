using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Management.Automation;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using BlackScreenDetect.Properties;
using static System.Reflection.Assembly;


namespace BlackScreenDetect
{
    public partial class MainForm : Form
    {
        private string[] SelectedItems => (from object item in _listBoxWatchedItems.SelectedItems
                                           select item.ToString()).ToArray();

        
        private static Loading _loadForm;// = new Loading();

        public MainForm()
        {
            InitializeComponent();
            _loadForm = new Loading(this);

        }

        private void InitializeUi()
        {
            _listBoxWatchedItems.Items.Clear();
            _listBoxWatchedItems.Items.AddRange(Data.Instance.WatchedFolders.ToArray<object>());

        }

        private void Log(string text, Color color = default(Color))
        {
            _rtbLog.Invoke(() =>
            {
                if (Equals(color, default(Color))) color = Color.White;
                if (_rtbLog.Lines.Length > 1000)
                    _rtbLog.Clear();
                _rtbLog.SelectionColor = Color.White;
                _rtbLog.AppendText($"{DateTime.Now}: ");
                _rtbLog.SelectionColor = color;
                _rtbLog.AppendText($"{text}\n");
                _rtbLog.ScrollToCaret();
            });
        }

        private static IEnumerable<string> Filtered_List(IList<string> list)
        {
            return (from name in list
                    let extension = Path.GetExtension(name)
                    where extension != null
                    let ext = extension.ToLower()
                    where ext.Equals(".mp4") || ext.Equals(".avi") || ext.Equals(".mkv")
                    select name).ToList();
        }

        private static IList<string> GetFiles(string path, string pattern)
        {
            var files = new List<string>();

            try
            {
                files.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));
                foreach (var directory in Directory.GetDirectories(path)) files.AddRange(GetFiles(directory, pattern));
            }
            catch
            {
                Console.WriteLine(@"Opps!");
            }

            return files;
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fs = new FolderSelectDialog();
            var result = fs.ShowDialog();
            if (!result) return;
            if (!Directory.Exists(fs.FileName)) return;
            var allfiles = Filtered_List(GetFiles(fs.FileName, "*.*"));
            foreach (var file in allfiles)
            {
                if (file == null || Data.Instance.WatchedFolders.Contains(file)) return;
                Data.Instance.WatchedFolders.Add(file);
                Data.Save();
            }

            InitializeUi();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fs = new OpenFileDialog
            {
                Title = @"Pick Some Files To ProccessName",
                Filter =
                    @"Supported File Types (*.mp4, *.mkv, *.avi)|*.mp4; *.mkv; *.avi",
                FilterIndex = 1,
                RestoreDirectory = false,
                Multiselect = true

            };
            var result = fs.ShowDialog();
            if (result != DialogResult.OK) return;
            var fileName = fs.FileNames;
            foreach (var file in fileName)
            {
                if (file == null || Data.Instance.WatchedFolders.Contains(file)) return;
                Data.Instance.WatchedFolders.Add(file);
                Data.Save();
            }
            InitializeUi();

        }

        private void _tsBtnRemoveFolder_Click(object sender, EventArgs e)
        {
            if (SelectedItems == null)
                return;
            foreach (var selectedFolder in SelectedItems)
            {
                Data.Instance.WatchedFolders.Remove(selectedFolder);
            }
            Data.Save();
            InitializeUi();
        }

        private bool _initialized;

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_initialized) return;
            _initialized = true;
            Log("Program loaded, initializing UI...");
            InitializeUi();
            Log("Ready.");
        }

        private void _tsBtnProgramSettings_Click(object sender, EventArgs e)
        {
            if (new ProgramSettings().ShowDialog(this) != DialogResult.OK)
                return;
            Log("Saved settings.");
        }

        private void processToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedItems == null)
                return;
            var ffmpeg = Data.Instance.FFmpegBinLib;
            if (ffmpeg == "")
            {
                Log(@"You Have to Configure the ffmpeg bin Folder First", Color.Red);
                return;
            }
            if (Directory.Exists(ffmpeg))
            {
                var files = GetFiles(ffmpeg, "*.exe");
                if (!files.Contains($@"{ffmpeg}\ffmpeg.exe") || !files.Contains($@"{ffmpeg}\ffprobe.exe"))
                {
                    const string baseUrl = "https://ffmpeg.zeranoe.com/builds/";
                    var bit = Environment.Is64BitOperatingSystem ? "win64/static/ffmpeg-latest-win64-static.7z" : "/win32/static/ffmpeg-latest-win32-static.7z";
                    Log(@"The ffmpeg bin dir you set does not contain all the necessary binaries.", Color.Red);
                    Log(@"Please recheck and confirm it's the right folder.", Color.Red);
                    Log($@"Last version can be found here: {baseUrl}{bit}", Color.Red);
                    return;
                }
            }

            foreach (var selectedItem in SelectedItems)
            {
                while (_bwProcess.IsBusy)
                    Application.DoEvents();
                Log($@"Start Processing {Path.GetFileNameWithoutExtension(selectedItem)}");
                _bwLoading.RunWorkerAsync();
                _bwProcess.RunWorkerAsync(selectedItem);
            }
            while (_bwProcess.IsBusy)
                Application.DoEvents();
            if (SelectedItems.Length <= 0)
            {
                Log("No Item Was Selected", Color.Red);
                return;
            }
            Log("Done Processing All Selected Items", Color.Gold);
            if (!Visible) Visible = true;
            if (!Data.Instance.PlaySounds) return;
            var startSoundPlayer = new SoundPlayer(Resources.Done);
            startSoundPlayer.Play();
        }

        private void _bwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            var psExec = PowerShell.Create();
            var startTime = DateTime.Now.TimeOfDay;
            var ffmpeg = Data.Instance.FFmpegBinLib;
            var duration = Data.Instance.Duration ?? "1";
            var picThreshold = Data.Instance.PicThreshold ?? "0.98";
            var pixThreshold = Data.Instance.PixThreshold ?? "0";
            var filePath = e.Argument as string;
            var name = Path.GetFileNameWithoutExtension(filePath);
            var validateScript = $@"{ffmpeg}\ffprobe.exe -stats -i '{filePath}' 2>&1";
            psExec.AddScript(validateScript);
            var valid = psExec.Invoke<string>().ToList();
            if (valid.Any(item => item.Contains("Invalid data found")))
            {
                Log($@"{name} is Invalid Media File", Color.Red);
                return;
            }
            psExec.Commands.Clear();
            var scriptText =
                $@"[string]$out = ({ffmpeg}\ffmpeg.exe -i '{filePath}' -vf blackdetect=d={duration}:pic_th={
                        picThreshold
                    }:pix_th={pixThreshold} -f rawvideo -y nul 2>&1){
                        Environment.NewLine
                    }$out | Out-File $env:TMP\{name}_black.txt{Environment.NewLine}$black = (Get-Content $env:TMP\{
                        name
                    }_black.txt | Select-String -Pattern ""blackdetect""){
                        Environment.NewLine
                    }$black | Out-File $env:TMP\{
                        name
                    }_out.txt";

            psExec.AddScript(scriptText);
            psExec.Invoke();
            psExec.Commands.Clear();

            var output = "";
            string line;

            var file = new StreamReader($@"{Path.GetTempPath()}\{name}_out.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line == "") continue;
                output += ConvertToTime(line) + Environment.NewLine;
            }
            var outFile = Data.Instance.OutputFolder ?? Path.GetTempPath();
            File.WriteAllText($@"{outFile}\{name}_out.txt", output, Encoding.UTF8);
            file.Close();
            var endTime = DateTime.Now.TimeOfDay;
            var timeItTookSpan = endTime - startTime;
            var min = Convert.ToInt32(timeItTookSpan.Minutes);
            var stringMin = min.ToString("00");
            var sec = Convert.ToInt32(timeItTookSpan.Seconds);
            var stringSec = sec.ToString("00");
            var mili = Convert.ToInt32(timeItTookSpan.Milliseconds.ToString("000"));
            var timeFormat = min <= 0 ? $@"{stringSec}.{mili} Seconds" : $@"{stringMin}:{stringSec}.{mili} Minutes";
            Log($@"Done Proessing {name} in {timeFormat}", Color.Green);
        }

        private void _bwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _loadForm.Close();
        }

        private void _bwLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {
                var h = Data.Instance.LoadH;
                var w = Data.Instance.LoadW;
                var x = Data.Instance.LoadX;
                var y = Data.Instance.LoadY;
                _loadForm.Size = new Size(w, h);
                _loadForm.Location = new Point(x,y); //new Point(Location.X + Width / 2 - _loadForm.Width / 2, Location.Y);
                _loadForm.Opacity = Data.Instance.Opacity * 0.01;
                //WindowState = FormWindowState.Minimized;
                _loadForm.ShowDialog();
            }));
        }

        private static string ConvertToTime(string time)
        {
            var m = Regex.Match(time,
                @"\[blackdetect @ [a-zA-Z0-9]{16}\].*black_start:(?<start>.*) black_end:(?<end>.*) black_duration:(?<duration>.*)");
            var start = ConvertToTime(double.Parse(m.Groups["start"].Value));
            var end = ConvertToTime(double.Parse(m.Groups["end"].Value));
            //var duration = ConvertToTime(TimeSpan.Parse($"{Convert.ToDateTime(end) - Convert.ToDateTime(start)}").TotalSeconds);
            return $@"Start Time:{start}        End Time:{end}"; //        Duration:{duration}";
        }

        private static string ConvertToTime(double time)
        {
            var tmp = time.ToString(CultureInfo.InvariantCulture).Split('.');
            var miliSeconds = tmp.Length == 1
                ? "000"
                : tmp[1].Length > 2
                    ? tmp[1].Substring(0, 3)
                    : tmp[1].Length > 1
                        ? tmp[1] + "0"
                        : tmp[1] + "00";
            var t = TimeSpan.FromSeconds(time);
            var tc = $"{t.Hours:D2}:{t.Minutes:D2}:{t.Seconds:D2}.{miliSeconds}";
            return tc;
        }


        private void _bwUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            var downloadUrl = @"";
            Version newVersion = null;
            XElement change = null;
            const string xmlUrl = @"https://oribenhur.github.io/update.xml";
            var appVersion = GetExecutingAssembly().GetName().Version;
            var appName = GetExecutingAssembly().GetName().Name.Replace(" ", "_");
            //var UpdadeMessageBox = new UpdateMessageBox();
            try
            {
                var doc = XDocument.Load(xmlUrl);
                foreach (var dm in doc.Descendants(appName))
                {
                    var versionElement = dm.Element(@"version");
                    if (versionElement == null) continue;
                    var urlelEment = dm.Element(@"url");
                    if (urlelEment == null) continue;
                    newVersion = new Version(versionElement.Value);
                    downloadUrl = urlelEment.Value;
                    change = dm.Element(@"change_log");

                }
            }
            catch (Exception exception)
            {
                Invoke(new MethodInvoker(delegate { MessageBox.Show(this, exception.Message); }));
            }

            if (appVersion.CompareTo(newVersion) < 0)
            {

                //Debug.Assert(change != null, "change != null");
                var result = DialogResult.None;
                Invoke(new MethodInvoker(delegate
                {
                    if (change != null)
                        result = MessageBox.Show(this,
                            $@"{appName.Replace('_', ' ')} v.{newVersion} is out!{Environment.NewLine}{change.Value}",
                            @"New Version is avlibale", MessageBoxButtons.YesNo);
                }));

                if (result == DialogResult.Yes)
                    Process.Start(downloadUrl);

            }
            else
            {
                if ((bool)e.Argument)
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        MessageBox.Show(this, @"You Are Running The Last Version.", @"No New Updates");
                    }));
                }
            }
        }

        private void _miCheckForUpdates_Click(object sender, EventArgs e)
        {
            _bwUpdate.RunWorkerAsync(true);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _bwUpdate.RunWorkerAsync(false);
        }

        private void _miTechnicalDetails_Click(object sender, EventArgs e)
        {
            var appVersion = GetExecutingAssembly().GetName().Version;
            var appName = GetExecutingAssembly().GetName().Name;
            // ReSharper disable once AssignNullToNotNullAttribute
            var buildDate = File.GetLastWriteTime(GetExecutingAssembly().Location).ToLocalTime();
            var td = new TechnicalDetails(appName, appVersion.ToString(), $@"{buildDate.ToShortDateString()} - {buildDate.ToShortTimeString()}");
            td.ShowDialog(this);
        }

        private void _listBoxWatchedItems_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void _listBoxWatchedItems_DragDrop(object sender, DragEventArgs e)
        {
            var s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
            {
                _listBoxWatchedItems.Items.Add(s[i]);
                var str = s[i];
                if (str != null && !Data.Instance.WatchedFolders.Contains(str))
                    Data.Instance.WatchedFolders.Add(str);
            }
            Data.Save();
            InitializeUi();
        }
        private void _listBoxWatchedItems_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    var rowIndex = GetRowIndex(e.Location);
                    if (rowIndex == -1)
                        break;
                    _listBoxWatchedItems.ClearSelected();
                    _listBoxWatchedItems.SelectedIndex = rowIndex;
                    _cmsListBox.Show(this, new Point(e.X + 5, e.Y + 35));
                    break;
                case MouseButtons.Left:
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void Open(object sender, EventArgs e)
        {
            var folder = Path.GetDirectoryName(_listBoxWatchedItems.SelectedItem as string);
            if (folder != null) Process.Start(folder);
        }

        private void _listBoxWatchedItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                for (var val = 0; val < _listBoxWatchedItems.Items.Count; val++)
                {
                    _listBoxWatchedItems.SetSelected(val, true);
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                _tsBtnRemoveFolder_Click(sender, e);
            }
        }

        private void _rtbLog_MouseDown(object sender, MouseEventArgs e)
        {
            var contextMenu = new ContextMenu();
            var clear = new MenuItem("Clear Log");
            var copyText = new MenuItem("Copy Text");
            copyText.Click += CopyText;
            contextMenu.MenuItems.Add(copyText);
            clear.Click += Clear;
            contextMenu.MenuItems.Add(clear);
            _rtbLog.ContextMenu = contextMenu;
        }

        private void CopyText(object sender, EventArgs e)
        {
            _rtbLog.Copy();
        }
        private void Clear(object sender, EventArgs e)
        {
            _rtbLog.Clear();
            //InitializeUi();
            Log("Ready.");
        }


        private int GetRowIndex(Point p)
        {
            for (var i = 0; i < _listBoxWatchedItems.Items.Count; i++)
            {
                var r1 = _listBoxWatchedItems.GetItemRectangle(i);
                var r = new Rectangle(0, r1.Top, _listBoxWatchedItems.Width, r1.Height);
                if (!r.Contains(p)) continue;
                _listBoxWatchedItems.Focus();
                return i;
            }
            return -1;
        }

        private void _rtbLog_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
