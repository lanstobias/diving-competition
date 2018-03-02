using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
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
            Application.Run(new ProjectMainWindow());
        }

        // check if a string is formatted correctly
        public static bool StringCheckFormat(string s)
        {
            Regex regex = new Regex(@"^[a-öA-Ö0-9_ -]+$");

            if (regex.IsMatch(s))
                return true;

            return false;
        }
    }
}
