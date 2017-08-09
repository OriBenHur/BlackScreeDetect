using System;
using System.Windows.Forms;

namespace BlackScreenDetect
{
    public partial class TechnicalDetails : Form
    {
        public TechnicalDetails(string appName, string version, string buildDate)
        {
            InitializeComponent();
            Text = $@"{appName} Technical Details";
            build_label.Text = buildDate;
            App_label.Text = appName;
            AppVersion_label.Text = version;
        }

        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
    }
}
