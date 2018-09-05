using System;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace MEHv2
{
    public partial class SplashForm : Form
    {


        public SplashForm()
        {
            InitializeComponent();

            //still thinking about doing an update notification
            //try
            //{
            //    WebClient client = new WebClient();
            //    Stream stream = client.OpenRead("http://yoururl/test.txt");
            //    StreamReader reader = new StreamReader(stream);
            //    String content = reader.ReadToEnd();
            //}
            //catch
            //{

            //}



            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string VersionText = version.Major.ToString() + "." + version.Minor.ToString() + "." + version.Build.ToString();

            TitleLabel.Text = "Meaning Extraction Helper (v" + VersionText + ")";

        }

        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
