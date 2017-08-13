using System;
using System.IO;
using System.Windows.Forms;

namespace BlackScreenDetect
{
    public partial class ProgramSettings : Form
    {
        public ProgramSettings()
        {
            InitializeComponent();
            _tbFFmpegLocation.Text = Data.Instance.FFmpegBinLib;
            _tbOutputfolder.Text = Data.Instance.OutputFolder;
            _tbdurtion.Text = Data.Instance.Duration;
            _tbtpixthreshold.Text = Data.Instance.PixThreshold;
            _tbpicthreshold.Text = Data.Instance.PicThreshold;
            _cbPlaySounds.Checked = Data.Instance.PlaySounds;
        }

        private void _browesButton_Click(object sender, EventArgs e)
        {
            var fs = new FolderSelectDialog
            {
                InitialDirectory = string.IsNullOrEmpty(_tbFFmpegLocation.Text) ? @"C:\" : _tbFFmpegLocation.Text,
                Title = "Select ffmpeg bin dir"
            };


            var result = fs.ShowDialog(Handle);
            if (!result) return;
            if (!Directory.Exists(fs.FileName)) return;
            _tbFFmpegLocation.Text = fs.FileName;

        }

        private void _btOutputfolder_Click(object sender, EventArgs e)
        {
            var fs = new FolderSelectDialog
            {
                InitialDirectory = string.IsNullOrEmpty(_tbOutputfolder.Text) ? @"C:\" : _tbOutputfolder.Text,
                Title = "Select output dir"
            };
            var result = fs.ShowDialog(Handle);
            if (!result) return;
            if (!Directory.Exists(fs.FileName)) return;
            _tbOutputfolder.Text = fs.FileName;
        }

        private void _SaveButton_Click(object sender, EventArgs e)
        {
            Data.Instance.FFmpegBinLib = _tbFFmpegLocation.Text;
            Data.Instance.OutputFolder = _tbOutputfolder.Text;
            Data.Instance.Duration = _tbdurtion.Text;
            Data.Instance.PixThreshold = _tbtpixthreshold.Text;
            Data.Instance.PicThreshold = _tbpicthreshold.Text;
            Data.Instance.PlaySounds = _cbPlaySounds.Checked;
            Data.Save();
            Close();
        }
    }
}
