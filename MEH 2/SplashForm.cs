using System;
using System.Windows.Forms;


namespace MEHv2
{
    public partial class SplashForm : Form
    {


        public SplashForm()
        {
            InitializeComponent();


            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string VersionText = version.Major.ToString() + "." + version.Minor.ToString() + "." + version.Build.ToString("D2");

            TitleLabel.Text = "Meaning Extraction Helper (v" + VersionText + ")";


        }

        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
