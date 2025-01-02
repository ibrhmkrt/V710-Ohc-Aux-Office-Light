using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanver_FrameWorkV6;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ototrim_V710_MontajHatti
{
    public static class Helper
    {
        public static void TagDegerYaz(Sanver_AnaSayfa Anasayfa, int YazilacakTagNo, string YazilacakDeger)
        {
            Sanver_AnaSayfa.PLC_Tags YazilacakTag = Anasayfa.TagListe.Find(item => item.ID == YazilacakTagNo);

            YazilacakTag.YazilanDeger = YazilacakDeger;
        }

        public static void TagDegerYaz_Recete(Sanver_AnaSayfa Anasayfa, int YazilacakTagNo, string YazilacakDeger)
        {
            Sanver_AnaSayfa.PLC_Tags YazilacakTag = Anasayfa.TagListe_Recete.Find(item => item.ID == YazilacakTagNo);

            YazilacakTag.YazilanDeger = YazilacakDeger;
        }

        public static string TagDegerOku(Sanver_AnaSayfa Anasayfa, int OkunacakTagNo)
        {
            Sanver_AnaSayfa.PLC_Tags OkunacakTag = Anasayfa.TagListe.Find(item => item.ID == OkunacakTagNo);

            return OkunacakTag.OkunanDeger;
        }

        public static string TagDegerOku(Sanver_AnaSayfa Anasayfa, int OkunacakTagNo, int OndalikHaneSayisi)
        {
            Sanver_AnaSayfa.PLC_Tags OkunacakTag = Anasayfa.TagListe.Find(item => item.ID == OkunacakTagNo);

            if (OndalikHaneSayisi > 0)
            {
                double tmp;

                tmp = (Convert.ToDouble(OkunacakTag.OkunanDeger) / Math.Pow(10.0, Convert.ToDouble(OndalikHaneSayisi)));

                string frm = "{0:0.";
                for (int i = 0; i < OndalikHaneSayisi; i++)
                {
                    frm += "0";
                }
                frm += "}";

                return string.Format(frm, tmp);

            }
            else
            {
                return OkunacakTag.OkunanDeger;
            }
        }
      
        public static string TagDegerOku_Recete(Sanver_AnaSayfa Anasayfa, int OkunacakTagNo)
        {
            Sanver_AnaSayfa.PLC_Tags OkunacakTag = Anasayfa.TagListe_Recete.Find(item => item.ID == OkunacakTagNo);

            return OkunacakTag.OkunanDeger;
        }

        public static string TagDegerOku_Recete(Sanver_AnaSayfa Anasayfa, int OkunacakTagNo, int OndalikHaneSayisi)
        {
            Sanver_AnaSayfa.PLC_Tags OkunacakTag = Anasayfa.TagListe.Find(item => item.ID == OkunacakTagNo);

            if (OndalikHaneSayisi > 0)
            {
                double tmp;

                tmp = (Convert.ToDouble(OkunacakTag.OkunanDeger) / Math.Pow(10.0, Convert.ToDouble(OndalikHaneSayisi)));

                string frm = "{0:0.";
                for (int i = 0; i < OndalikHaneSayisi; i++)
                {
                    frm += "0";
                }
                frm += "}";

                return string.Format(frm, tmp);

            }
            else
            {
                return OkunacakTag.OkunanDeger;
            }
        }

        

        public static bool ProgramCalisiyorMu(string programAdi)
        {
            bool tekSeferCalis = false;

            Process[] prg = Process.GetProcesses();
            string prglist;
            int say = 0;
            foreach (Process Prog in prg)
            {
                prglist = Prog.ToString();
                prglist = prglist.Replace("System.Diagnostics.Process (", "");
                prglist = prglist.Replace(")", "");
                if (prglist.Contains(programAdi))
                {
                    say = say + 1;
                }

                if (say >= 1)
                {
                    tekSeferCalis = true;
                }
            }

            return tekSeferCalis;
        }

        public static bool PingVarMi(string nameOrAddress)
        {
            try
            {
                Ping pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress, 200);
                return reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                return false;
            }
        }

        public static Color RandomColor()
        {
            Random r = new Random();

           //  return Color.FromArgb(r.Next(100,256), r.Next(100,256), r.Next(100,256));

             return Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        }

        public static void DosyayaYaz(string DosyaAdi, string Veri, string KlasorYolu, string DosyaBaslik)
        {
            DirectoryInfo DI = new DirectoryInfo(KlasorYolu);
            if (!DI.Exists) { Directory.CreateDirectory(KlasorYolu); }

            FileInfo FI = new FileInfo(DosyaAdi);
            if (!FI.Exists)
            {
                using (StreamWriter sw = new StreamWriter(DosyaAdi, true))
                {
                    sw.WriteLine(DosyaBaslik);
                }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(DosyaAdi, true))
                {
                    sw.WriteLine(Veri);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string DosyadanOku(string DosyaAdi)
        {
            string OkunanData = "";

            using (StreamReader sr = new StreamReader(DosyaAdi))
            {
                string line;

                if ((line = sr.ReadLine()) != null)
                {
                    OkunanData = line;
                }
            }

            return OkunanData;
        }
    }
}
