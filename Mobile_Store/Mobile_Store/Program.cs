using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mobile_Store
{
    static class Program
    {
        //MobileStoreContainer context = new MobileStoreContainer();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms_User.Frm_Login ());
        }
    }
}
