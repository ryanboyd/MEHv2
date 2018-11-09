using System;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace MEH2
{
    static class MEH2
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string VersionText = version.Major.ToString() + "." + version.Minor.ToString() + "." + version.Build.ToString();


            //check for updates
            try
            {
                MyWebClient client = new MyWebClient();
                client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                Stream stream = client.OpenRead("https://meh.ryanb.cc/version.txt");
                StreamReader reader = new StreamReader(stream);
                string content = reader.ReadToEnd();

                if (content != VersionText)
                {
                    var result = MessageBox.Show("A new version of MEH is available at https://meh.ryanb.cc" + Environment.NewLine + Environment.NewLine + "Would you like to download the update?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start("https://meh.ryanb.cc/download/");
                            Application.Exit();
                        }
                        catch
                        {

                        }
                    }
                    //run program if they don't want to update
                    else
                    {
                        Application.Run(new MEHv2.SplashForm());
                        Application.Run(new MainForm());
                    }
                }
                //run program if the version is the latest
                else
                {
                    Application.Run(new MEHv2.SplashForm());
                    Application.Run(new MainForm());
                }

            }
            //run program if there's an error in the check
            catch
            {
                Application.Run(new MEHv2.SplashForm());
                Application.Run(new MainForm());
            }




        }

        //just setting that timeout to 5 seconds max
        private class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 5000;
                return w;
            }
    }


    }
}
