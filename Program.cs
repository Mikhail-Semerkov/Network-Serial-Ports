using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Serial_Ports
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm view = new MainForm();
            view.StartPosition = FormStartPosition.CenterScreen;
            IController controller = new IController(view);

            Application.Run(view);
        }
    }
}
