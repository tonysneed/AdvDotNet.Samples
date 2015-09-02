using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Blocker.Client
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
            Application.ThreadException += (o, ea) =>
                {
                    MessageBox.Show(ea.Exception.Message, "Error");
                };
            Application.Run(new MainForm());
        }
    }
}
