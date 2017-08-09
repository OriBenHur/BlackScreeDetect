using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackScreenDetect
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            BackColor = Color.LimeGreen;
            TransparencyKey = Color.LimeGreen;
        }

        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MainForm.Windowstate = FormWindowState.Minimized;
            WindowState =FormWindowState.Minimized;
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
