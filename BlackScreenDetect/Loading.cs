using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlackScreenDetect
{
    public partial class Loading : Form
    {
        private readonly MainForm _mf;
        private readonly TrackBar _opacity;
        private readonly RadioButton _x256;
        private readonly RadioButton _x128;
        private readonly RadioButton _x64;

        public Loading(MainForm form)
        {
            InitializeComponent();
            _x256 = new RadioButton();
            _x128 = new RadioButton();
            _x64 = new RadioButton();
            _opacity = new TrackBar();
            _x256.Text = @"256x256";
            _x256.Checked = Data.Instance.X256;
            _x256.BackColor = Color.White;
            _x256.CheckedChanged += x256_CheckedChanged;
            _x128.Text = @"128x128";
            _x128.Checked = Data.Instance.X128;
            _x128.BackColor = Color.White;
            _x128.CheckedChanged += x128_CheckedChanged;
            _x64.Text = @"64x64";
            _x64.Checked = Data.Instance.X64;
            _x64.BackColor = Color.White;
            _x64.CheckedChanged += x64_CheckedChanged;
            _opacity.Maximum = 100;
            _opacity.Minimum = 15;
            _opacity.Value = Data.Instance.Opacity;
            _opacity.Scroll += opacity_Scroll;
            _opacity.ForeColor = Color.White;
            var ch = new ToolStripControlHost(_x256);
            var ch1 = new ToolStripControlHost(_x128);
            var ch2 = new ToolStripControlHost(_x64);
            var ch3 = new ToolStripControlHost(_opacity);
            _cmsSizes.Items.Clear();
            _cmsSizes.Items.Add(ch);
            _cmsSizes.Items.Add(ch1);
            _cmsSizes.Items.Add(ch2);
            _cmsSizes.Items.Add(ch3);

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

        private void opacity_Scroll(object sender, EventArgs e)
        {
            Opacity = _opacity.Value * 0.01;
            Save();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging || e.Clicks == 2) return;
            Location = new Point(Left + (e.X - _currentX), Top + (e.Y - _currentY));
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
            Data.Instance.X256 = _x256.Checked;
            Data.Instance.X128 = _x128.Checked;
            Data.Instance.X64 = _x64.Checked;
            Data.Instance.Opacity = _opacity.Value;
            Data.Instance.LoadW = Data.Instance.LoadH = Size.Width;
            Data.Instance.LoadX = Location.X;
            Data.Instance.LoadY = Location.Y;
            Data.Save();
        }

        private void Loading_Move(object sender, EventArgs e)
        {
            Save();
        }

        private void Loading_SizeChanged(object sender, EventArgs e)
        {
            Save();
        }



        //private void Loading_Shown(object sender, EventArgs e)
        //{
        //    _bwUpdate.RunWorkerAsync();
        //}
    }
}
