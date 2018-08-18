﻿using System;
using System.Windows.Forms;

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

            Application.Run(new MEHv2.SplashForm());

            Application.Run(new MainForm());
        }
    }
}
