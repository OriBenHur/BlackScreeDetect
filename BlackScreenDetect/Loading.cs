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
        private readonly Prograss _prograss;
        public bool IsAbort { get; set; }
        public bool IsAbortAll;
        private bool _isLoaded;

        public Loading(MainForm form)
        {
            InitializeComponent();
            _tsLarge.Checked = Data.Instance.Large;
            _tsMedium.Checked = Data.Instance.Medium;
            _tsSmall.Checked = Data.Instance.Small;
            _tsOpacity.Value = Data.Instance.Opacity;
            _tsh256 = new ToolStripControlHost(_tsLarge);
            _tsh128 = new ToolStripControlHost(_tsMedium);
            _tsh64 = new ToolStripControlHost(_tsSmall);
            _tshOpacity = new ToolStripControlHost(_tsOpacity);
            _tshComboBox = new ToolStripControlHost(_tsComboBox);
            _cmsSizes.Items.Add(_tsh256);
            _cmsSizes.Items.Add(_tsh128);
            _cmsSizes.Items.Add(_tsh64);
            _cmsSizes.Items.Add(_tshOpacity);
            _cmsSizes.Items.Add("Pick a Backround Style:");
            _cmsSizes.Items.Add(_tshComboBox);
            _cmsSizes.Items.Add(_tsAbort);
            _cmsSizes.Items.Add(_tsAbortAll);
            //var csm = new ToolStripControlHost(_cmsSizes);
            //_cmsIcon.Items.Add(csm);
            //_cmsIcon.Items.Add(_tsOpenMain);
            BackColor = Color.White;
            TransparencyKey = Color.White;
            _mf = form;
            _prograss = new Prograss(_mf , this)
            {
                Opacity = _tsOpacity.Value * 0.01,
                label1 =
                {
                    ForeColor = Data.Instance.ForeColorColor,
                    BackColor = Data.Instance.BackColor
                }
            };
            _tsComboBox.SelectedItem = string.IsNullOrEmpty(Data.Instance.PickItem) ? "Transparent Background" : Data.Instance.PickItem;

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
            _prograss.Opacity = _tsOpacity.Value * 0.01;
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
            _prograss.Visible = !_mf.Visible;
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
            _prograss.Location = new Point(Left, Top - _prograss.Size.Height - 5);
            Save();
        }


        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip(pictureBox1, "Double Click To Hide / Show Main Window");
        }

        private void Abort_Clicked(object sender, EventArgs e)
        {
            IsAbort = true;
            KillProcess("ffmpeg");
        }

        private void AbortAll_Clicked(object sender, EventArgs e)
        {
            IsAbortAll = true;
            KillProcess("ffmpeg");
            _niLoading.Visible = false;
        }

        private static void KillProcess(string p)
        {
            foreach (var process in Process.GetProcessesByName(p))
            {
                var parent = ParentProcessUtilities.GetParentProcess(process.Id) == null ? process.ProcessName : ParentProcessUtilities.GetParentProcess(process.Id).ProcessName;
                if (parent.Equals(GetExecutingAssembly().GetName().Name) || parent.Equals(p))
                    process.Kill();
            }
        }
        private void ShowMain_Clicked(object sender, EventArgs e)
        {
            _mf.Visible = true;
            _niLoading.Visible = !_mf.Visible;
            _mf.BringToFront();
        }
        //private void White_Clicked(object sender, EventArgs e)
        //{
        //    _prograss.label1.BackColor = Color.White;
        //    _prograss.label1.ForeColor = Color.FromArgb(5,5,5);
        //    Data.Instance.BackColor = Color.White;
        //    Data.Instance.ForeColorColor = Color.FromArgb(5, 5, 5); ;
        //    Data.Save();
        //}

        //private void Gray_Clicked(object sender, EventArgs e)
        //{
        //    _prograss.label1.BackColor = Color.Gray;
        //    _prograss.label1.ForeColor = Color.White;
        //    Data.Instance.BackColor = Color.Gray;
        //    Data.Instance.ForeColorColor = Color.White;
        //    Data.Save();
        //}

        //private void None_Clicked(object sender, EventArgs e)
        //{
        //    _prograss.label1.BackColor = Color.Black;
        //    _prograss.label1.ForeColor = Color.FromArgb(5, 5, 5);
        //    Data.Instance.BackColor = Color.Black;
        //    Data.Instance.ForeColorColor = Color.FromArgb(5, 5, 5);
        //    Data.Save();
        //}

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
            
            if (!_isLoaded) return;
            Data.Instance.LoadX = Location.X;
            Data.Instance.LoadY = Location.Y;
            Data.Save();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            _isLoaded = true;
            _prograss.Show(this);
            _prograss.Visible = false;
            var h = Data.Instance.LoadH;
            var w = Data.Instance.LoadW;
            var x = Data.Instance.LoadX;
            var y = Data.Instance.LoadY;
            Size = new Size(w, h);
            Location = x == 0 && y == 0
                ? new Point(_mf.Location.X + (_mf.Width / 2) - (Width / 2), _mf.Location.Y)
                : new Point(x, y);
            Opacity = Data.Instance.Opacity * 0.01;
            BringToFront();
            CheckLoction();
        }

        private void Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isLoaded = false;
            _prograss.Close();
            Data.Instance.Large = _tsLarge.Checked;
            Data.Instance.Medium = _tsMedium.Checked;
            Data.Instance.Small = _tsSmall.Checked;
            Data.Instance.Opacity = _tsOpacity.Value;
            CheckLoction();
            Data.Instance.LoadX = Location.X;
            Data.Instance.LoadY = Location.Y;
            Data.Save();
        }


        private void _niLoading_DoubleClick(object sender, EventArgs e)
        {
            _mf.Visible = true;
            _niLoading.Visible = !_mf.Visible;
            _prograss.Visible = !_mf.Visible;
            _mf.BringToFront();
        }

        private void _tsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (_tsComboBox.SelectedIndex)
            {
                case 0:
                    _prograss.label1.BackColor = Color.Black;
                    _prograss.label1.ForeColor = Color.FromArgb(5, 5, 5);
                    Data.Instance.BackColor = Color.Black;
                    Data.Instance.ForeColorColor = Color.FromArgb(5, 5, 5);
                    Data.Instance.PickItem = "Transparent Background";
                    Data.Save();
                    _cmsSizes.Close();
                    break;

                case 1:
                    _prograss.label1.BackColor = Color.Gray;
                    _prograss.label1.ForeColor = Color.White;
                    Data.Instance.BackColor = Color.Gray;
                    Data.Instance.ForeColorColor = Color.White;
                    Data.Instance.PickItem = "Gray Backround";
                    Data.Save();
                    _cmsSizes.Close();
                    break;

                case 2:
                    _prograss.label1.BackColor = Color.White;
                    _prograss.label1.ForeColor = Color.FromArgb(5, 5, 5);
                    Data.Instance.BackColor = Color.White;
                    Data.Instance.ForeColorColor = Color.FromArgb(5, 5, 5);
                    Data.Instance.PickItem = "White Backround";
                    Data.Save();
                    _cmsSizes.Close();
                    break;
            }
        }
    }
}
