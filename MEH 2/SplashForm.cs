using System;
using System.Windows.Forms;

namespace MEHv2
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
