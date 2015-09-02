using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Buggy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // This suppresses errors
            //Application.ThreadException += (o, ea) => { };

            // Let app go boom
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            Application.Run(new MainForm());
        }
    }
}
