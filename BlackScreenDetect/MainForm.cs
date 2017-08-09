using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;


namespace BlackScreenDetect
{
    public partial class MainForm : Form
    {
        private string[] SelectedItems => (from object item in _listBoxWatchedItems.SelectedItems
                                           select item.ToString()).ToArray();

        private static Size MainSize { get; set; }
        private static readonly Loading LoadForm = new Loading();

        public static FormWindowState Windowstate { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Windowstate = WindowState;
        }
        private void InitializeUi()
        {
            _listBoxWatchedItems.Items.Clear();
            _listBoxWatchedItems.Items.AddRange(Data.Instance.WatchedFolders.ToArray());

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
            return (from name in list let extension = Path.GetExtension(name) where extension != null let ext = extension.ToLower() where ext.Equals(".mp4") || ext.Equals(".avi") || ext.Equals(".mkv") select name).ToList();
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
            if (Data.Instance.FFmpegBinLib == "")
            {
                MessageBox.Show(this, @"You must select The ffmpeg bin dir", @"error");
                return;
            }

            foreach (var selectedItem in SelectedItems)
            {
                while (_bwProcess.IsBusy)
                    Application.DoEvents();
                Log($@"Start Processing {Path.GetFileNameWithoutExtension(selectedItem)}");
                _bwLoading.RunWorkerAsync();
                _bwProcess.RunWorkerAsync(selectedItem);
            }
        }

        private void _bwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            var startTime = DateTime.Now.TimeOfDay;
            var ffmpeg = Data.Instance.FFmpegBinLib;
            var pixThreshold = Data.Instance.PixThreshold ?? "0.10";
            var picThreshold = Data.Instance.PicThreshold ?? "0.98";
            var duration = Data.Instance.Duration ?? "2";

            var name = Path.GetFileNameWithoutExtension(e.Argument as string);
            var scriptText =
                $@"[string]$out = ({ffmpeg}\ffmpeg.exe -i '{e.Argument as string}' -vf blackdetect=d={duration}:pic_th={picThreshold}:pix_th={pixThreshold} -f rawvideo -y nul 2>&1){Environment.NewLine}$out | Out-File $env:TMP\{name}_black.txt{Environment.NewLine}$black = (Get-Content $env:TMP\{name}_black.txt | Select-String -Pattern ""blackdetect""){Environment.NewLine}$black | Out-File $env:TMP\{name}_out.txt";
            PowerShell psExec = PowerShell.Create();
            psExec.AddScript(scriptText);
            psExec.Invoke();
            psExec.Commands.Clear();
            var output = "";
            var fpsscriptText = $@"{ffmpeg}\ffprobe -v error -select_streams v:0 -show_entries stream=avg_frame_rate -of default=noprint_wrappers=1:nokey=1 '{e.Argument as string}'";
            psExec.AddScript(fpsscriptText);

            var resulte = psExec.Invoke<string>().ToList();
            var fps = 0.0;
            foreach (var item in resulte)
            {
                var fraction = Regex.Match(item, "(?<numerator>.*)/(?<denominator>.*)");
                var numerator = double.Parse(fraction.Groups["numerator"].Value);
                var denominator = double.Parse(fraction.Groups["denominator"].Value);
                var tmpfps = numerator / denominator;
                fps = Convert.ToDouble(tmpfps.ToString("N3"));
            }

            psExec.Commands.Clear();
            string line;

            // Read the file and display it line by line.
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
            LoadForm.Close();
        }

        private void _bwLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {

                LoadForm.Location = new Point(Location.X + Width / 2 - LoadForm.Width / 2, Location.Y);
                LoadForm.ShowDialog(this);
            }));
        }

        private static string ConvertToTime(string time)
        {
            //
            var m = Regex.Match(time, @"\[blackdetect @ [a-zA-Z0-9]{16}\].*black_start:(?<start>.*) black_end:(?<end>.*) black_duration:(?<duration>.*)");
            var start = ConvertToTime(double.Parse(m.Groups["start"].Value));
            var end = ConvertToTime(double.Parse(m.Groups["end"].Value));
            //var duration = ConvertToTime(TimeSpan.Parse($"{Convert.ToDateTime(end) - Convert.ToDateTime(start)}").TotalSeconds);
            return $@"Start Time:{start}        End Time:{end}";//        Duration:{duration}";
        }

        private static string ConvertToTime(double time)
        {
            var tmp = time.ToString(CultureInfo.InvariantCulture).Split('.');
            var miliSeconds = tmp.Length == 1 ? "000" : tmp[1].Length > 2 ? tmp[1].Substring(0,3) : tmp[1].Length > 1 ? tmp[1] + "0" : tmp[1] + "00";
            var t = TimeSpan.FromSeconds(time);
            var tc = $"{t.Hours:D2}:{t.Minutes:D2}:{t.Seconds:D2}.{miliSeconds}";
            return tc;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            MainSize = Size;
        }
    }
}
