using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sanver_FrameWorkV6;

namespace Ototrim_V710_MontajHatti
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
            // Application.Run(new _01_AnaSayfa());

            //Makine ID ile bilgisayar IP leri aynıdır.
            //İlgili ID ye göre ilgili formu çalıştırıyoruz.
            int makineID = Helper.DosyadanOku("MakineID.txt").Trim().ToInt();

            Webservis.url = Helper.DosyadanOku("WebservisUrl.txt").Trim();

           // MessageBox.Show(Webservis.url);

            if (makineID == 19)
                Application.Run(new Frm_Makine1());
            else if (makineID == 29)
                Application.Run(new Frm_Makine2());
            else if (makineID == 39)
                Application.Run(new Frm_Makine3());
            else if (makineID == 47)
                Application.Run(new Frm_Makine4_1());
            else if (makineID == 48)
                Application.Run(new Frm_Makine4_2());
            else if (makineID == 49)
                Application.Run(new Frm_Makine4_3());
            else if (makineID == 59)
                Application.Run(new Frm_Makine5());


           // Application.Run(new test());
        }
    }
}
