using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    static class Program
    {
        public static bool login = false;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 loginForm = new Form1();
            if (loginForm.ShowDialog() == DialogResult.OK && login==true)
            {
                Application.Run(new Dashboard());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
