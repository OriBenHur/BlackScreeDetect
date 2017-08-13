using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static System.Reflection.Assembly;

namespace BlackScreenDetect
{
    public partial class Loading : Form
    {
        private readonly MainForm _mf;
        public bool IsAbort { get; set; }
        public bool IsAbortAll;
        public Loading(MainForm form)
        {
            InitializeComponent();
            _ts256.Checked = Data.Instance.X256;
            _ts128.Checked = Data.Instance.X128;
            _ts64.Checked = Data.Instance.X64;
            _tsOpacity.Value = Data.Instance.Opacity;
            _tsh256 = new ToolStripControlHost(_ts256);
            _tsh128 = new ToolStripControlHost(_ts128);
            _tsh64 = new ToolStripControlHost(_ts64);
            _tshOpacity = new ToolStripControlHost(_tsOpacity);
            _cmsSizes.Items.AddRange(new ToolStripItem[] {_tsh256, _tsh128, _tsh64, _tshOpacity, _tsAbort, _tsAbortAll});
            BackColor = Color.LimeGreen;
            TransparencyKey = Color.LimeGreen;
            _mf = form;
        }
        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        private const int CpNocloseButton = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                var myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CpNocloseButton;
                return myCp;
            }
        }

        private bool _isDragging;
        private int _currentX;
        private int _currentY;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _cmsSizes.Show(this, new Point(e.X, e.Y));
            }
            if (e.Clicks == 2) return;
            _isDragging = true;
            _currentX = e.X;
            _currentY = e.Y;
        }

        private void x256_CheckedChanged(object sender, EventArgs e)
        {
            Size = new Size(256, 256);
            _cmsSizes.Close();

        }
        private void x128_CheckedChanged(object sender, EventArgs e)
        {
            Size = new Size(128, 128);
            _cmsSizes.Close();

        }
        private void x64_CheckedChanged(object sender, EventArgs e)
        {
            Size = new Size(64, 64);
            _cmsSizes.Close();
        }
        private void Abort_Clicked(object sender, EventArgs e)
        {
            IsAbort = true;
            var visual = false;
            if (_mf.Visible == false)
            {
                _mf.Opacity = 0;
                _mf.Visible = true;
            }
            else visual = true;

            foreach (var process in Process.GetProcessesByName("ffmpeg"))
            {
                var parent = ParentProcessUtilities.GetParentProcess(process.Id).MainWindowTitle;
                if (!visual)
                {
                    _mf.Visible = false;
                    _mf.Opacity = 100;
                    
                }
                if (parent.Equals(GetExecutingAssembly().GetName().Name))
                    process.Kill();
                
            }   
        }

        private void AbortAll_Clicked(object sender, EventArgs e)
        {
            IsAbortAll = true;
            var visual = false;
            if (_mf.Visible == false)
            {
                _mf.Opacity = 0;
                _mf.Visible = true;
            }
            else visual = true;
            foreach (var process in Process.GetProcessesByName("ffmpeg"))
            {
                var parent = ParentProcessUtilities.GetParentProcess(process.Id).MainWindowTitle;
                if (!visual)
                {
                    _mf.Visible = false;
                    _mf.Opacity = 100;

                }
                if (parent.Equals(GetExecutingAssembly().GetName().Name))
                    process.Kill();
            }

        }
        private void opacity_Scroll(object sender, EventArgs e)
        {
            Opacity = _tsOpacity.Value * 0.01;
            Data.Instance.Opacity = _tsOpacity.Value;
            Data.Save();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging || e.Clicks == 2) return;
            Location = new Point(Left + (e.X - _currentX), Top + (e.Y - _currentY));
            Data.Instance.LoadX = Location.X;
            Data.Instance.LoadY = Location.Y;
            Data.Save();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2) return;
            _isDragging = false;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _mf.Visible = !_mf.Visible;
        }

        private void Save()
        {
            Data.Instance.X256 = _ts256.Checked;
            Data.Instance.X128 = _ts128.Checked;
            Data.Instance.X64 = _ts64.Checked;
            Data.Save();
        }

        private void Loading_Move(object sender, EventArgs e)
        {
            Save();
        }

        private void Loading_SizeChanged(object sender, EventArgs e)
        {
            Data.Instance.LoadW = Data.Instance.LoadH = Size.Width;
            Data.Save();
        }
    }
}
