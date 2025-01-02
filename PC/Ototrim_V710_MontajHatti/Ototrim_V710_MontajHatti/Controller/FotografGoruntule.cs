using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ototrim_V710_MontajHatti.Controller
{
    public static class FotografGoruntule
    {
        public static void FotografiPaneldeGoster(string referansAdi, Label lbl_FotografAdi, Panel pnl_UrunFotograf)
        {
            if (referansAdi != "")
            {
                try
                {
                    lbl_FotografAdi.Text = referansAdi;
                    lbl_FotografAdi.AutoSize = false;

                    string fotografYolu = string.Format(@"REFERANSFOTOGRAF\{0}.jpeg", referansAdi);

                    bool fileExist = File.Exists(fotografYolu);

                    if (fileExist)
                    {
                        pnl_UrunFotograf.BackgroundImage = Image.FromFile(fotografYolu);
                    }
                    else
                    {
                        fotografYolu = string.Format(@"REFERANSFOTOGRAF\{0}.png", referansAdi);

                        fileExist = File.Exists(fotografYolu);

                        if (fileExist)
                        {
                            pnl_UrunFotograf.BackgroundImage = Image.FromFile(fotografYolu);
                        }
                        else
                        {
                            pnl_UrunFotograf.BackgroundImage = null;

                            lbl_FotografAdi.Text = referansAdi + " - " + string.Format(@"REFERANSFOTOGRAF\{0}.jpg/.png yolunda fotoğraf bulunamadı!", referansAdi);
                            lbl_FotografAdi.AutoSize = true;
                        }
                    }
                }
                catch
                {
                    pnl_UrunFotograf.BackgroundImage = null;

                    lbl_FotografAdi.Text = referansAdi + " - " + string.Format(@"REFERANSFOTOGRAF\{0}.jpg/.png yolunda fotoğraf bulunamadı!", referansAdi);
                    lbl_FotografAdi.AutoSize = true;
                }
            }
            else
            {
                pnl_UrunFotograf.BackgroundImage = null;
            }
        }
    }
}
