using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void _browesButton_Click(object sender, EventArgs e)
        {
            var fs = new FolderSelectDialog();
            var result = fs.ShowDialog();
            if (!result) return;
            if (!Directory.Exists(fs.FileName)) return;
            _tbFFmpegLocation.Text = fs.FileName;

        }

        private void _SaveButton_Click(object sender, EventArgs e)
        {
            Data.Instance.FFmpegBinLib = _tbFFmpegLocation.Text;
            Data.Instance.OutputFolder = _tbOutputfolder.Text;
            Data.Instance.Duration = _tbdurtion.Text;
            Data.Instance.PixThreshold = _tbtpixthreshold.Text;
            Data.Instance.PicThreshold = _tbpicthreshold.Text;
            Data.Save();
            Close();
        }

        private void _btOutputfolder_Click(object sender, EventArgs e)
        {
            var fs = new FolderSelectDialog();
            var result = fs.ShowDialog();
            if (!result) return;
            if (!Directory.Exists(fs.FileName)) return;
            _tbOutputfolder.Text = fs.FileName;
        }
    }
}
