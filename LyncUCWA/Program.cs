using LyncUCWA.JsonResponses;
using System;
using System.Windows.Forms;

namespace LyncUCWA
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
        public static ApplicationResponse ApplicationInstance;
        public static MyContacts Contacts;
        public static Phones Phones;
    }
}
