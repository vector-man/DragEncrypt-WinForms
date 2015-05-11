﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinehEncryption
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // get the targetted file location
            string fileLocation;
            if (args == null || args.Length <= 0)
            {
                var openFile = new OpenFileDialog {Multiselect = false, CheckFileExists = true};
                openFile.ShowDialog();
                fileLocation = openFile.FileName;
            }
            else
            {
                fileLocation = args[0];
            }
            // quit on 'Cancel' or other weird filenames ^^"
            if (String.IsNullOrWhiteSpace(fileLocation)) return;

            Application.Run(new MainProcess(fileLocation));
        }
    }
}
