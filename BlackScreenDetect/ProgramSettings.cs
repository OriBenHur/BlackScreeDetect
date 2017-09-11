using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BlackScreenDetect
{
    public partial class ProgramSettings : Form
    {
        private readonly ColorDialog _logBackColor;
        private readonly ColorDialog _regularColor;
        private readonly ColorDialog _successColor;
        private readonly ColorDialog _warrningColor;
        private readonly ColorDialog _errorColor;
        private readonly ColorDialog _infoColor;
        private bool _isBold;
        private bool _isitalic;
        private bool _isUnderline;

        public ProgramSettings()
        {
            InitializeComponent();
            _logBackColor = new ColorDialog { Color = Data.Instance.LogBackColor };
            _regularColor = new ColorDialog { Color = Data.Instance.RegularColor };
            _successColor = new ColorDialog { Color = Data.Instance.SuccessColor };
            _warrningColor = new ColorDialog { Color = Data.Instance.WarrningColor };
            _errorColor = new ColorDialog { Color = Data.Instance.ErrorColor };
            _infoColor = new ColorDialog { Color = Data.Instance.InfoColor };
            _isBold = Data.Instance.IsBold;
            _lbBold.BackColor = Data.Instance.IsBoldColor;
            _isitalic = Data.Instance.IsItalic;
            _lbItalic.BackColor = Data.Instance.IsItalicColor;
            _isUnderline = Data.Instance.IsUnderline;
            _lbUnderline.BackColor = Data.Instance.IsUnderlineColor;
            _tbFFmpegLocation.Text = Data.Instance.FFmpegBinLib;
            _tbOutputfolder.Text = Data.Instance.OutputFolder;
            _tbdurtion.Text = Data.Instance.Duration;
            _tbtpixthreshold.Text = Data.Instance.PixThreshold;
            _tbpicthreshold.Text = Data.Instance.PicThreshold;
            _cbPlaySounds.Checked = Data.Instance.PlaySounds;
            _cbNoMB.Checked = Data.Instance.NoMb;
            _cbDebug.Checked = Data.Instance.Debug;
            _pnBackColor.BackColor = Data.Instance.LogBackColor;
            _pnRegularColor.BackColor = Data.Instance.RegularColor;
            _pnSuccessColor.BackColor = Data.Instance.SuccessColor;
            _pnWarrningColor.BackColor = Data.Instance.WarrningColor;
            _pnErrorColor.BackColor = Data.Instance.ErrorColor;
            _pnInfoColor.BackColor = Data.Instance.InfoColor;
            _lbRegularTextExp.BackColor = Data.Instance.LogBackColor;
            _lbSuccessTextExp.BackColor = Data.Instance.LogBackColor;
            _lbWarningTextExp.BackColor = Data.Instance.LogBackColor;
            _lbErrorTextExp.BackColor = Data.Instance.LogBackColor;
            _lbInfoTextExp.BackColor = Data.Instance.LogBackColor;
            _lbRegularTextExp.ForeColor = Data.Instance.RegularColor;
            _lbSuccessTextExp.ForeColor = Data.Instance.SuccessColor;
            _lbWarningTextExp.ForeColor = Data.Instance.WarrningColor;
            _lbErrorTextExp.ForeColor = Data.Instance.ErrorColor;
            _lbInfoTextExp.ForeColor = Data.Instance.InfoColor;
            _lbRegularTextExp.Font = Data.Instance.LogFont;
            _lbSuccessTextExp.Font = Data.Instance.LogFont;
            _lbWarningTextExp.Font = Data.Instance.LogFont;
            _lbErrorTextExp.Font = Data.Instance.LogFont;
            _lbInfoTextExp.Font = Data.Instance.LogFont;
            var installedFonts = new InstalledFontCollection();
            foreach (var font in installedFonts.Families)
            {
                _cbFonts.Items.Add(font.Name);
            }
            for (var i = 8; i < 16; i++)
            {
                _cbSize.Items.Add(i.ToString());
            }
            for (var i = 14; i < 26; i += 2)
            {
                _cbSize.Items.Add(i.ToString());
            }
            _cbFonts.SelectedItem = Data.Instance.FontName;
            _cbSize.SelectedItem = Data.Instance.FontSize;

        }

        private void _browesButton_Click(object sender, EventArgs e)
        {
            if (_bwAutoSearch.IsBusy)
            {
                _bwAutoSearch.CancelAsync();
            }

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
            Data.Instance.NoMb = _cbNoMB.Checked;
            Data.Instance.Debug = _cbDebug.Checked;
            Data.Instance.LogBackColor = _logBackColor.Color;
            Data.Instance.RegularColor = _pnRegularColor.BackColor;
            Data.Instance.SuccessColor = _pnSuccessColor.BackColor;
            Data.Instance.WarrningColor = _pnWarrningColor.BackColor;
            Data.Instance.ErrorColor = _pnErrorColor.BackColor;
            Data.Instance.InfoColor = _pnInfoColor.BackColor;
            Data.Instance.FontName = _cbFonts.SelectedItem.ToString();
            Data.Instance.FontSize = _cbSize.SelectedItem.ToString();
            Data.Instance.IsBold = _isBold;
            Data.Instance.IsBoldColor = _lbBold.BackColor;
            Data.Instance.IsItalic = _isitalic;
            Data.Instance.IsItalicColor = _lbItalic.BackColor;
            Data.Instance.IsUnderlineColor = _lbUnderline.BackColor;
            Data.Instance.IsUnderline = _isUnderline;
            var style = " ,style=";
            if (_isBold)
            {
                style += "Bold, ";
            }
            if (_isitalic)
            {
                style += "Italic, ";
            }
            if (_isUnderline)
            {
                style += "Underline, ";
            }

            style = _isBold || _isitalic || _isUnderline ? style.Trim().TrimEnd(',') : "";
            Data.Instance.FontStyle = style;
            var cvt = new FontConverter();

            Data.Instance.LogFont = (Font)cvt.ConvertFromString($@"{Data.Instance.FontName},{Data.Instance.FontSize}pt{Data.Instance.FontStyle}");
            Data.Save();
            Close();
        }

        private void _lbNoMS_Click(object sender, EventArgs e)
        {
            _cbNoMB.Checked = !_cbNoMB.Checked;
        }

        private void _lbPlaySounds_Click(object sender, EventArgs e)
        {
            _cbPlaySounds.Checked = !_cbPlaySounds.Checked;
        }

        private void _lbDebug_Click(object sender, EventArgs e)
        {
            _cbDebug.Checked = !_cbDebug.Checked;
        }

        private void _btAutoSearch_Click(object sender, EventArgs e)
        {
            _tbFFmpegLocation.Text = @"Wait...";
            var envvar = Environment.GetEnvironmentVariable("Path");
            if (envvar == null) return;
            var envDirs = envvar.Split(';');
            _bwAutoSearch.RunWorkerAsync(envDirs);
        }

        private static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private void _bwAutoSearch_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var found = false;
            foreach (var dir in (string[])e.Argument)
            {
                if (dir.Equals(@"C:\Windows", StringComparison.CurrentCultureIgnoreCase)) continue;
                var files = MainForm.GetFiles(dir, "*.exe");
                var tmpDir = dir.EndsWith(@"\") ? dir : $@"{dir}\";
                var enumerable = files as string[] ?? files.ToArray();
                if (!enumerable.Contains($@"{tmpDir}ffmpeg.exe") || !enumerable.Contains($@"{tmpDir}ffprobe.exe")) continue;
                e.Result = UppercaseFirst(tmpDir.EndsWith(@"\") ? tmpDir.TrimEnd('\\') : tmpDir);
                found = true;
                break;
            }
            if (!found)
                e.Result = @"Can't Find Please Browse Manually";
        }

        private void _bwAutoSearch_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _tbFFmpegLocation.Text = e.Result.ToString();
        }


        private void _btResetAll_Click(object sender, EventArgs e)
        {
            _tbFFmpegLocation.Text = "";
            _tbOutputfolder.Text = "";
            _tbdurtion.Text = @"0.2";
            _tbtpixthreshold.Text = @"0";
            _tbpicthreshold.Text = @"0.98";
            _cbPlaySounds.Checked = true;
            _cbNoMB.Checked = false;
            _cbDebug.Checked = false;
            _cbFonts.SelectedItem = "Microsoft Sans Serif";
            _cbSize.SelectedItem = "11";
            _isBold = false;
            _lbBold.BackColor = SystemColors.Control;
            _isitalic = false;
            _lbItalic.BackColor = SystemColors.Control;
            _isUnderline = false;
            _lbUnderline.BackColor = SystemColors.Control;
            _btBackroundReset.PerformClick();
            _btResetRegularColor.PerformClick();
            _btResetSuccessColor.PerformClick();
            _btResetWarningColor.PerformClick();
            _btResetErrorColor.PerformClick();
            _btResetInfoColor.PerformClick();
        }

        private void _btBackroundReset_Click(object sender, EventArgs e)
        {
            _pnBackColor.BackColor = Color.FromArgb(0, 36, 86);
            _logBackColor.Color = Color.FromArgb(0, 36, 86);
            _lbRegularTextExp.BackColor = Color.FromArgb(0, 36, 86);
            _lbSuccessTextExp.BackColor = Color.FromArgb(0, 36, 86);
            _lbWarningTextExp.BackColor = Color.FromArgb(0, 36, 86);
            _lbErrorTextExp.BackColor = Color.FromArgb(0, 36, 86);
            _lbInfoTextExp.BackColor = Color.FromArgb(0, 36, 86);
        }

        private void _pnBackColor_Click(object sender, EventArgs e)
        {
            _logBackColor.Color = Data.Instance.LogBackColor;
            if (_logBackColor.ShowDialog(this) == DialogResult.OK)
            {
                _pnBackColor.BackColor = _logBackColor.Color;
                _lbRegularTextExp.BackColor = _pnBackColor.BackColor;
                _lbSuccessTextExp.BackColor = _pnBackColor.BackColor;
                _lbWarningTextExp.BackColor = _pnBackColor.BackColor;
                _lbErrorTextExp.BackColor = _pnBackColor.BackColor;
                _lbInfoTextExp.BackColor = _pnBackColor.BackColor;
            }
        }

        private void _pnRegularColor_Click(object sender, EventArgs e)
        {
            _regularColor.Color = Data.Instance.RegularColor;
            if (_regularColor.ShowDialog(this) == DialogResult.OK)
            {
                _pnRegularColor.BackColor = _regularColor.Color;
                _lbRegularTextExp.ForeColor = _pnRegularColor.BackColor;
            }
        }

        private void _pnSuccessColor_Click(object sender, EventArgs e)
        {
            _successColor.Color = Data.Instance.SuccessColor;
            if (_successColor.ShowDialog(this) == DialogResult.OK)
            {
                _pnSuccessColor.BackColor = _successColor.Color;
                _lbSuccessTextExp.ForeColor = _pnSuccessColor.BackColor;
            }
        }

        private void _pnWarrningColor_Click(object sender, EventArgs e)
        {
            _warrningColor.Color = Data.Instance.WarrningColor;
            if (_warrningColor.ShowDialog(this) == DialogResult.OK)
            {
                _pnWarrningColor.BackColor = _warrningColor.Color;
                _lbWarningTextExp.ForeColor = _pnWarrningColor.BackColor;
            }
        }

        private void _pnErrorColor_Click(object sender, EventArgs e)
        {
            _errorColor.Color = Data.Instance.ErrorColor;
            if (_errorColor.ShowDialog(this) == DialogResult.OK)
            {
                _pnErrorColor.BackColor = _errorColor.Color;
                _lbErrorTextExp.ForeColor = _pnErrorColor.BackColor;
            }
        }

        private void _pnInfoColor_Click(object sender, EventArgs e)
        {
            _infoColor.Color = Data.Instance.InfoColor;
            if (_infoColor.ShowDialog(this) == DialogResult.OK)
            {
                _pnInfoColor.BackColor = _infoColor.Color;
                _lbInfoTextExp.ForeColor = _pnInfoColor.BackColor;
            }
        }


        private void _lbBold_Click(object sender, EventArgs e)
        {
            _lbBold.BackColor = _lbBold.BackColor == Color.LightGray ? SystemColors.Control : Color.LightGray;
            _isBold = _lbBold.BackColor == Color.LightGray;
            var style = " ,style=";
            if (_isBold)
            {
                style += "Bold, ";
            }
            if (_isitalic)
            {
                style += "Italic, ";
            }
            if (_isUnderline)
            {
                style += "Underline, ";
            }

            style = _isBold || _isitalic || _isUnderline ? style.Trim().TrimEnd(',') : "";
            var cvt = new FontConverter();
            var font = (Font)cvt.ConvertFromString($@"{_cbFonts.SelectedItem},{11}pt{style}");
            if (font == null) return;
            _lbRegularTextExp.Font = font;
            _lbSuccessTextExp.Font = font;
            _lbWarningTextExp.Font = font;
            _lbErrorTextExp.Font = font;
            _lbInfoTextExp.Font = font;
        }

        private void _lbItalic_Click(object sender, EventArgs e)
        {
            _lbItalic.BackColor = _lbItalic.BackColor == Color.LightGray ? SystemColors.Control : Color.LightGray;
            _isitalic = _lbItalic.BackColor == Color.LightGray;
            var style = " ,style=";
            if (_isBold)
            {
                style += "Bold, ";
            }
            if (_isitalic)
            {
                style += "Italic, ";
            }
            if (_isUnderline)
            {
                style += "Underline, ";
            }

            style = _isBold || _isitalic || _isUnderline ? style.Trim().TrimEnd(',') : "";
            var cvt = new FontConverter();
            var font = (Font)cvt.ConvertFromString($@"{_cbFonts.SelectedItem},{11}pt{style}");
            if (font == null) return;
            _lbRegularTextExp.Font = font;
            _lbSuccessTextExp.Font = font;
            _lbWarningTextExp.Font = font;
            _lbErrorTextExp.Font = font;
            _lbInfoTextExp.Font = font;
        }

        private void _lbUnderline_Click(object sender, EventArgs e)
        {
            _lbUnderline.BackColor = _lbUnderline.BackColor == Color.LightGray ? SystemColors.Control : Color.LightGray;
            _isUnderline = _lbUnderline.BackColor == Color.LightGray;
            var style = " ,style=";
            if (_isBold)
            {
                style += "Bold, ";
            }
            if (_isitalic)
            {
                style += "Italic, ";
            }
            if (_isUnderline)
            {
                style += "Underline, ";
            }

            style = _isBold || _isitalic || _isUnderline ? style.Trim().TrimEnd(',') : "";
            var cvt = new FontConverter();
            var font = (Font)cvt.ConvertFromString($@"{_cbFonts.SelectedItem},{11}pt{style}");
            if (font == null) return;
            _lbRegularTextExp.Font = font;
            _lbSuccessTextExp.Font = font;
            _lbWarningTextExp.Font = font;
            _lbErrorTextExp.Font = font;
            _lbInfoTextExp.Font = font;
        }

        private void _btResetRegularColor_Click(object sender, EventArgs e)
        {
            _pnRegularColor.BackColor = Color.White;
            _regularColor.Color = Color.White;
            _lbRegularTextExp.ForeColor = Color.White;
        }

        private void _btResetSuccessColor_Click(object sender, EventArgs e)
        {
            _pnSuccessColor.BackColor = Color.Green;
            _successColor.Color = Color.Green;
            _lbSuccessTextExp.ForeColor = Color.Green;
        }

        private void _btResetWarningColor_Click(object sender, EventArgs e)
        {
            _pnWarrningColor.BackColor = Color.Gold;
            _warrningColor.Color = Color.Gold;
            _lbWarningTextExp.ForeColor =Color.Gold;
        }

        private void _btResetErrorColor_Click(object sender, EventArgs e)
        {
            _pnErrorColor.BackColor = Color.Red;
            _errorColor.Color = Color.Red;
            _lbErrorTextExp.ForeColor = Color.Red;
        }

        private void _btResetInfoColor_Click(object sender, EventArgs e)
        {
            _pnInfoColor.BackColor = Color.BlueViolet;
            _infoColor.Color = Color.BlueViolet;
            _lbInfoTextExp.ForeColor = Color.BlueViolet;
        }

        private void _lbMoreInfo_Click(object sender, EventArgs e)
        {
            Process.Start("https://ffmpeg.org/ffmpeg-filters.html#blackdetect");
        }

        private void _cbFonts_SelectedValueChanged(object sender, EventArgs e)
        {
            var style = " ,style=";
            if (_isBold)
            {
                style += "Bold, ";
            }
            if (_isitalic)
            {
                style += "Italic, ";
            }
            if (_isUnderline)
            {
                style += "Underline, ";
            }
            
            style = _isBold || _isitalic || _isUnderline ? style.Trim().TrimEnd(',') : "";
            var cvt = new FontConverter();
            var font = (Font)cvt.ConvertFromString($@"{_cbFonts.SelectedItem},{11}pt{style}");
            if (font == null) return;
            _lbRegularTextExp.Font = font;
            _lbSuccessTextExp.Font = font;
            _lbWarningTextExp.Font = font;
            _lbErrorTextExp.Font = font;
            _lbInfoTextExp.Font = font;
            //_lbSuccessTextExp.Font = Data.Instance.LogFont;
            //_lbWarningTextExp.Font = Data.Instance.LogFont;
            //_lbErrorTextExp.Font = Data.Instance.LogFont;
            //_lbInfoTextExp.Font = Data.Instance.LogFont;
        }

        private void _lbWarningTextExp_SizeChanged(object sender, EventArgs e)
        {
            _btResetWarningColor.Location = new Point(_lbWarningTextExp.Location.X + _lbWarningTextExp.Width + 4, _btResetWarningColor.Location.Y);
        }

        private void _btResetWarningColor_LocationChanged(object sender, EventArgs e)
        {
            _btBackroundReset.Location = new Point(_btResetWarningColor.Location.X, _btBackroundReset.Location.Y);
            _btResetRegularColor.Location = new Point(_btResetWarningColor.Location.X, _btResetRegularColor.Location.Y);
            _btResetErrorColor.Location = new Point(_btResetWarningColor.Location.X, _btResetErrorColor.Location.Y);
            _btResetSuccessColor.Location = new Point(_btResetWarningColor.Location.X, _btResetSuccessColor.Location.Y);
            _btResetInfoColor.Location = new Point(_btResetWarningColor.Location.X, _btResetInfoColor.Location.Y);

        }

        private void _btRestColors_Click(object sender, EventArgs e)
        {
            _btBackroundReset.PerformClick();
            _btResetRegularColor.PerformClick();
            _btResetSuccessColor.PerformClick();
            _btResetWarningColor.PerformClick();
            _btResetErrorColor.PerformClick();
            _btResetInfoColor.PerformClick();
        }

        private void _lbMoreInfo_MouseDown(object sender, MouseEventArgs e)
        {
            _lbMoreInfo.BackColor = Color.LightGray;
        }

        private void _lbMoreInfo_MouseUp(object sender, MouseEventArgs e)
        {
            _lbMoreInfo.BackColor = SystemColors.Control;
        }
    }
}
