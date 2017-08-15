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
        private bool _isLoaded;

        public Loading(MainForm form)
        {
            InitializeComponent();
            //WR = Screen.GetWorkingArea(this);
            _tsLarge.Checked = Data.Instance.Large;
            _tsMedium.Checked = Data.Instance.Medium;
            _tsSmall.Checked = Data.Instance.Small;
            _tsOpacity.Value = Data.Instance.Opacity;
            _tsh256 = new ToolStripControlHost(_tsLarge) { Size = new Size(104, 80) };
            _tsh128 = new ToolStripControlHost(_tsMedium) { Size = new Size(104, 80) };
            _tsh64 = new ToolStripControlHost(_tsSmall) { Size = new Size(104, 80) };
            _tshOpacity = new ToolStripControlHost(_tsOpacity);
            _cmsSizes.Items.Add(_tsh256); //_tsh128, _tsh64, _tshOpacity, _tsAbort, _tsAbortAll }
            _cmsSizes.Items.Add(_tsh128);
            _cmsSizes.Items.Add(_tsh64);
            _cmsSizes.Items.Add(_tshOpacity);
            _cmsSizes.Items.Add(_tsAbort);
            _cmsSizes.Items.Add(_tsAbortAll);
            //_cmsSizes.Items.AddRange(new ToolStripItem[] { _tshOpacity, _tsAbort, _tsAbortAll });
            BackColor = Color.White;
            TransparencyKey = Color.White;
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
            if (e.Clicks == 2) return;
            if (e.Button == MouseButtons.Right)
            {
                _cmsSizes.Show(this, new Point(e.X, e.Y));
            }
            _isDragging = true;
            _currentX = e.X;
            _currentY = e.Y;

        }

        private void _tsLarge_CheckedChanged(object sender, EventArgs e)
        {
            Size = new Size(210, 210);
            _cmsSizes.Close();
            Data.Instance.LoadH = 210;
            Data.Instance.LoadW = 210;
            if (_isLoaded) CheckLoction();
            Save();

        }
        private void _tsMedium_CheckedChanged(object sender, EventArgs e)
        {
            Size = new Size(128, 128);
            _cmsSizes.Close(); 
            Data.Instance.LoadH = 128;
            Data.Instance.LoadW = 128;
            if (_isLoaded) CheckLoction();
            Save();

        }
        private void _tsSmall_CheckedChanged(object sender, EventArgs e)
        {
            Size = new Size(80, 80);
            _cmsSizes.Close();
            Data.Instance.LoadH = 80;
            Data.Instance.LoadW = 80;
            if (_isLoaded) CheckLoction();
            Save();
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
            CheckLoction();
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
            if (e.Button == MouseButtons.Right) return;
            _mf.Visible = !_mf.Visible;
            _niLoading.Visible = !_mf.Visible;
            _mf.BringToFront();

        }

        private void Save()
        {
            Data.Instance.Large = _tsLarge.Checked;
            Data.Instance.Medium = _tsMedium.Checked;
            Data.Instance.Small = _tsSmall.Checked;
            Data.Save();
        }

        private void Loading_Move(object sender, EventArgs e)
        {
            Save();
        }


        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip(pictureBox1, $"Processing {_mf.VideoName} {_mf.Percentage}%");
        }

        private void Abort_Clicked(object sender, EventArgs e)
        {
            IsAbort = true;
            foreach (var process in Process.GetProcessesByName("ffmpeg"))
            {
                var parent = ParentProcessUtilities.GetParentProcess(process.Id).ProcessName;
                if (parent.Equals(GetExecutingAssembly().GetName().Name))
                    process.Kill();
            }
        }

        private void AbortAll_Clicked(object sender, EventArgs e)
        {
            IsAbortAll = true;
            foreach (var process in Process.GetProcessesByName("ffmpeg"))
            {
                var parent = ParentProcessUtilities.GetParentProcess(process.Id) ==  null ? process.ProcessName : ParentProcessUtilities.GetParentProcess(process.Id).ProcessName;
                if (parent.Equals(GetExecutingAssembly().GetName().Name) || parent.Equals("ffmpeg"))
                    process.Kill();
            }
            _niLoading.Visible = false;
        }

        private void Loading_LocationChanged(object sender, EventArgs e)
        {
            CheckLoction();
            
        }

        private void CheckLoction()
        {
            if (Left + Width > Screen.AllScreens[0].Bounds.Width)
                Left = Screen.AllScreens[0].Bounds.Width - Width;

            if (Left < Screen.AllScreens[0].Bounds.Left)
                Left = Screen.AllScreens[0].Bounds.Left;

            if (Top + Height > Screen.AllScreens[0].Bounds.Height)
                Top = Screen.AllScreens[0].Bounds.Height - Height;

            if (Top < Screen.AllScreens[0].Bounds.Top)
                Top = Screen.AllScreens[0].Bounds.Top;
        }

        private void _niLoading_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            _mf.Visible = !_mf.Visible;
            _niLoading.Visible = !_mf.Visible;
            _mf.BringToFront();
        }

        private void _niLoading_BalloonTipShown(object sender, EventArgs e)
        {
            _niLoading.BalloonTipText = $@"{_mf.Percentage}%";
            _niLoading.Text = $@"{_mf.Percentage}%";
            _niLoading.BalloonTipTitle = $@"{_mf.Percentage}%";
        }

        private void _niLoading_MouseMove(object sender, MouseEventArgs e)
        {
            _niLoading.ShowBalloonTip(300000, $"Processing {_mf.VideoName} {_mf.Percentage}%", $"Processing {_mf.VideoName} {_mf.Percentage}%", ToolTipIcon.None);
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            _isLoaded = true;
            var h = Data.Instance.LoadH;
            var w = Data.Instance.LoadW;
            var x = Data.Instance.LoadX;
            var y = Data.Instance.LoadY;
            Size = new Size(w, h);
            Location = x == 0 && y == 0
                ? new Point(_mf.Location.X + _mf.Width / 2 - Width / 2, _mf.Location.Y)
                : new Point(x, y);
            Opacity = Data.Instance.Opacity * 0.01;
            BringToFront();
            CheckLoction();
        }

        private void Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isLoaded = false;
            Data.Instance.Large = _tsLarge.Checked;
            Data.Instance.Medium = _tsMedium.Checked;
            Data.Instance.Small = _tsSmall.Checked;
            Data.Instance.Opacity = _tsOpacity.Value;
            CheckLoction();
            Data.Instance.LoadX = Location.X;
            Data.Instance.LoadY = Location.Y;
            Data.Save();
        }

        private void Loading_Deactivate(object sender, EventArgs e)
        {
            Show();
            Activate();
            Focus();
            BringToFront();
        }
    }
}
