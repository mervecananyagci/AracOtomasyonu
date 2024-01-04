using System;
using System.Windows.Forms;

namespace AracOtomasyon
{
    internal static class Program
    {
        public static string DuzenlenecekId;
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Kullanicisifre());
        }

    }
}
