using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    static class Program
    {
        public static int count = 3;
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
            while (count > 0)
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Dashboard());
                    Application.Exit();
                }                
            }
        }
    }
}
