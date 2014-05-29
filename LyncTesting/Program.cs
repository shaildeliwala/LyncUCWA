using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LyncTest
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
            mForm = new UI.MainForm();
            Application.Run(mForm);
        }

        public static UI.MainForm mForm;
        public static JsonResponses.ApplicationResponse ApplicationResource;
    }
}
