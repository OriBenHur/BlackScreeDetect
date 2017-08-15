using System.Drawing;
using System.Windows.Forms;

namespace BlackScreenDetect
{
    public partial class Prograss : Form
    {
        private readonly MainForm _mf;
        private readonly Loading _loading;
        public Prograss(MainForm form ,Loading loadForm)
        {
            InitializeComponent();
            _mf = form;
            _loading = loadForm;
            _Run.Start();
            BackColor = Color.Black;
            TransparencyKey = Color.Black;
        }

        public sealed override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        private void _Run_Tick(object sender, System.EventArgs e)
        {
            label1.Text = string.IsNullOrEmpty(_mf.Percentage) ? "" : $@"Processing: {_mf.Percentage}%";
        }

        private void Prograss_Move(object sender, System.EventArgs e)
        {
            if(Visible)
                CheckLoction();
        }

        private void CheckLoction()
        {
            if (Left + Width > Screen.AllScreens[0].Bounds.Width)
            {
                Left = Screen.AllScreens[0].Bounds.Width - Width;
                _loading.Left = Left - 5;
            }

            if (Left < Screen.AllScreens[0].Bounds.Left)
            {
                Left = Screen.AllScreens[0].Bounds.Left;
                _loading.Left = Left - 5;
            }

            if (Top + Height > Screen.AllScreens[0].Bounds.Height)
            {
                Top = Screen.AllScreens[0].Bounds.Height - Height;
                _loading.Top = Top + Height + 5 ;
            }

            if (Top < Screen.AllScreens[0].Bounds.Top)
            {
                Top = Screen.AllScreens[0].Bounds.Top;
                _loading.Top = Top + Height + 5;
            }
        }

        private void Prograss_VisibleChanged(object sender, System.EventArgs e)
        {
            if (Visible) CheckLoction();
        }
    }
}
