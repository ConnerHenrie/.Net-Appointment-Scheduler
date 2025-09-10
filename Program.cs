using Conner_Henrie_C969.Database;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conner_Henrie_C969
{
    internal static class Program
    {
        public static string currentUser = "Undefined";
        public static int currentUserID = 0;
        public static string currentLocale = "en";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBConnection.setConnection();
            Application.Run(new LoginForm());

        }
    }
}
