using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        private static Loading _loadForm;
        private int _abort;
        private int _done;
        //private int _index;
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

        private string Log(string text, Color color = default(Color))
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
            return $"{DateTime.Now}: {text}";
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

        private string _text;
        private void processToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedItems == null)
                return;
            var ffmpeg = Data.Instance.FFmpegBinLib;
            if (string.IsNullOrEmpty(ffmpeg))
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
                    var bit = Environment.Is64BitOperatingSystem
                        ? "win64/static/ffmpeg-latest-win64-static.7z"
                        : "/win32/static/ffmpeg-latest-win32-static.7z";
                    Log(@"The ffmpeg bin dir you set does not contain all the necessary binaries.", Color.Red);
                    Log(@"Please recheck and confirm it's the right folder.", Color.Red);
                    Log($@"Last version can be found here: {baseUrl}{bit}", Color.Red);
                    return;
                }
            }
            var output = Data.Instance.OutputFolder;
            if (string.IsNullOrEmpty(output))
            {
                Log(@"You Have to Configure the Output Folder First", Color.Red);
                return;
            }
            foreach (var selectedItem in SelectedItems)
            {
                while (_bwProcess.IsBusy || _bwLoading.IsBusy)
                    Application.DoEvents();
                if (_loadForm.IsAbortAll) break;
                _text = Log($@"Start Processing {Path.GetFileNameWithoutExtension(selectedItem)}");
                _bwLoading.RunWorkerAsync();
                _bwProcess.RunWorkerAsync(selectedItem);
            }

            while (_bwProcess.IsBusy || _bwLoading.IsBusy)
                Application.DoEvents();


            if (SelectedItems.Length <= 0)
            {
                Text = @"BlackScreenDetect";

                Log("No Item Was Selected", Color.Red);
                return;
            }

            if (_abort == SelectedItems.Length)
            {
                Text = @"BlackScreenDetect";
                _loadForm._niLoading.Visible = false;
                if (!Visible) Visible = true;
                BringToFront();
                Log("All the processes have been aborted", Color.Red);
                _loadForm.IsAbortAll = false;
                _loadForm.IsAbort = false;
                _abort = _done = 0;
                return;
            }
            if (_loadForm.IsAbortAll)
            {
                Text = @"BlackScreenDetect";
                _loadForm._niLoading.Visible = false;
                if (!Visible) Visible = true;
                BringToFront();
                Log("All pending processes have been aborted", Color.Red);
                Log($"{SelectedItems.Length - _abort} reports have been saved to: {Data.Instance.OutputFolder}", Color.Gold);
                _loadForm.IsAbortAll = false;
                _loadForm.IsAbort = false;
                _abort = _done = 0;
                return;
            }

            _loadForm.IsAbortAll = false;
            _loadForm.IsAbort = false;
            Text = @"BlackScreenDetect";
            _loadForm._niLoading.Visible = false;
            if (!Visible) Visible = true;
            BringToFront();
            string msg;
            Color color;

            if (_done == SelectedItems.Length)
            {
                msg = "Done Processing All Selected Items";
                color = Color.Gold;
            }

            else
            {

                msg = $"Done Processing {_done} Items out of {SelectedItems.Length} Items";
                color = Color.SaddleBrown;
            }

            Log(msg, color);
            Log($"All the reports are saved to: {Data.Instance.OutputFolder}", Color.Gold);
            _abort = _done = 0;
            if (!Data.Instance.PlaySounds) return;
            var startSoundPlayer = new SoundPlayer(Resources.Done);
            startSoundPlayer.Play();
        }

        private double _time;
        public string Percentage;
        public string VideoName;

        private void _bwProcess_DoWork(object sender, DoWorkEventArgs e)
        {

            using (var psExec = PowerShell.Create())
            {
                var startTime = DateTime.Now.TimeOfDay;
                var ffmpeg = Data.Instance.FFmpegBinLib;
                var duration = Data.Instance.Duration ?? "1";
                var picThreshold = Data.Instance.PicThreshold ?? "0.98";
                var pixThreshold = Data.Instance.PixThreshold ?? "0";
                var filePath = e.Argument as string;
                VideoName = Path.GetFileNameWithoutExtension(filePath);
                var validateScript = $@"{ffmpeg}\ffprobe.exe -stats -i '{filePath}' 2>&1";
                psExec.AddScript(validateScript);
                var valid = psExec.Invoke<string>().ToList();
                if (valid.Any(item => item.Contains("Invalid data found")))
                {
                    Log($@"{VideoName} is Invalid Media File", Color.Red);
                    return;
                }
                psExec.Commands.Clear();
                var timeScript = $@"D:\ffmpeg\bin\ffprobe.exe -v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 '{filePath}'";
                psExec.AddScript(timeScript);
                var tm = psExec.Invoke<string>().ToList();
                foreach (var item in tm)
                {
                    _time = Convert.ToDouble($"{Convert.ToDouble(item):0.000}");
                }
                psExec.Commands.Clear();
                var scriptText =
                    $@"{ffmpeg}\ffmpeg.exe -i '{filePath}' -vf blackdetect=d={duration}:pic_th={picThreshold}:pix_th={pixThreshold} -f rawvideo -y nul 2>&1 | Select-String -Pattern ""black_start"",""speed""";
                psExec.AddScript(scriptText);
                var result = "";
                var output = new ObservableCollection<string>();
                var currenTime = DateTime.Now;
                //Log($@"Processing {VideoName}    ", Color.BlueViolet);
                //_rtbLog.Invoke(() =>
                //{
                //    _rtbLog.AppendText("\n");
                //});
                output.CollectionChanged += (s, r) =>
                {
                    foreach (var item in r.NewItems)
                    {
                        var m = Regex.Match(item.ToString(), "black_start");
                        var tmMatch = Regex.Match(item.ToString(),
                            @"time=\s*(?<time>[0-9]{2}:[0-9]{2}:[0-9]{2}\.[0-9]{2})");
                        if (m.Success) result = result + ConvertToTime(item.ToString()) + Environment.NewLine;
                        else if (tmMatch.Success)
                        {
                            var seconds = TimeSpan.Parse(tmMatch.Groups["time"].Value).TotalSeconds;
                            Percentage = $"{seconds / _time * 100:0.00}";
                            _rtbLog.Invoke(() =>
                            {
                                ChangeLine(_rtbLog, _rtbLog.Lines.Length - 2, $@"{_text} [Processing... {Percentage}%]");
                                Text = $@"BlackScreenDetect {Percentage}%";
                            });
                        }
                    }
                };
                psExec.Invoke(null, output);
                //var scriptOutput = psExec.Invoke<string>().ToList();
                //psExec.Commands.Clear();

                if (_loadForm.IsAbort)
                {
                    this.Invoke(() => { Text = @"BlackScreenDetect"; });
                    _abort++;
                    Log("Process Was Aborted...", Color.Red);
                    _loadForm.IsAbort = false;
                    return;
                }

                if (_loadForm.IsAbortAll)
                {
                    this.Invoke(() => { Text = @"BlackScreenDetect"; });

                    _abort = _abort + SelectedItems.Length -
                             Array.FindIndex(SelectedItems, author => author.Contains((string)e.Argument));

                    _bwLoading.CancelAsync();
                    _bwProcess.CancelAsync();
                    e.Cancel = true;
                    return;
                }

                //var output = (from line in scriptOutput let m = Regex.Match(line, "black_start") where m.Success select line).Aggregate("", (current, line) => current + ConvertToTime(line) + Environment.NewLine);
                var outFile = Data.Instance.OutputFolder;
                File.WriteAllText($@"{outFile}\{VideoName}_out.txt", result, Encoding.UTF8);

                var endTime = DateTime.Now.TimeOfDay;
                var timeItTookSpan = (endTime - startTime).TotalSeconds;
                var time = TimeSpan.FromSeconds(timeItTookSpan);
                var timeFormat = timeItTookSpan >= 360
                    ? $@"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}.{time.Milliseconds:000} Hours"
                    : timeItTookSpan >= 60
                        ? $@"{time.Minutes:00}:{time.Seconds:00}.{time.Milliseconds:000} Minutes"
                        : $@"{time.Seconds:00}.{time.Milliseconds:000} Seconds";
                _rtbLog.Invoke(() =>
                {
                    ChangeLine(_rtbLog, _rtbLog.Lines.Length - 2, $@"{_text} [{Percentage}%]");
                });
                Log($@"Done Proessing {VideoName} in {timeFormat}", Color.Green);
                _done++;
            }
        }

        private static void ChangeLine(TextBoxBase rtb, int line, string text)
        {

            var s1 = rtb.GetFirstCharIndexFromLine(line);
            var s2 = line < rtb.Lines.Length - 1 ? rtb.GetFirstCharIndexFromLine(line + 1) - 1 : rtb.Text.Length;
            rtb.Select(s1, s2 - s1);
            rtb.SelectedText = text;

        }
        private void _bwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {
                _loadForm.Close();
            }));
        }

        private void _bwLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {
                _loadForm.ShowDialog(this);
            }));
        }

        private static string ConvertToTime(string time)
        {
            var m = Regex.Match(time,
                @".*black_start:(?<start>.*) black_end:(?<end>.*) black_duration:(?<duration>.*)");
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var txtFiles = GetFiles(Path.GetTempPath(), "*.txt");
            foreach (var txtFile in txtFiles)
            {
                if (!txtFile.Contains("_out") && !txtFile.Contains("_black")) continue;

                try
                {
                    File.Delete(txtFile);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
    }
}
