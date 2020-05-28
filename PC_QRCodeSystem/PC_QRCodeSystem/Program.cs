using PC_QRCodeSystem.View;
using System;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem
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
            //if (SettingItem.checkSaved = true)
            //{
            //    Application.Run(new Login());
            //}
            Application.Run(new PCForm());
        }
    }
}
