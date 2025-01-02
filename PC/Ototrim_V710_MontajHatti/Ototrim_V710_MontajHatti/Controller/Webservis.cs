using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ototrim_V710_MontajHatti.Proxy;
using System.Windows.Forms;
using Sanver_FrameWorkV6;
using Ototrim_V710_MontajHatti.Model;

namespace Ototrim_V710_MontajHatti
{
    public static class Webservis
    {
        static UretimTools ototrimWebservis;

        //public static string url = @"http://192.168.1.77/WsTest/uretimtools.asmx";


        //WebservisUrl.txt 
        public static string url = @"http://192.168.11.6/WsOHCLamba/UretimTools.asmx";

        public static int KullaniciListesiDoldur(int hatNo, DataGridView dg)
        {
            int kullaniciSayi = 0;
            dg.DataSource = null;

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                UretimHatCalisanlarResponse res = ototrimWebservis.get_UretimHatCalisanlar(hatNo);

                if (res.IsSucces)
                {
                    dg.DataSource = res.AktifCalisanlar.ToList();
                    kullaniciSayi = res.AktifCalisanlar.Length;

                    dg.Columns[0].Width = 60;
                    dg.Columns[1].Width = 140;
                    dg.Columns[2].Width = 100;
                }
            }
            catch
            {

            }

            return kullaniciSayi;
        }

        public static bool TumKullanicilariCikart(int hatNo, DataGridView dg)
        {
            bool BasariliMi = false;
     
            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                UretimHatCalisanlarResponse res = ototrimWebservis.get_UretimHatCalisanlar(hatNo);

                if (res.IsSucces)
                {
                    for (int i = 0; i < res.AktifCalisanlar.Length; i++)
                    {
                        KullaniciCikart(hatNo, res.AktifCalisanlar[i].SicilNo, dg);
                    }

                    if (KullaniciListesiDoldur(hatNo,dg) == 0)
                        BasariliMi = true;
                }
            }
            catch
            {

            }

            return BasariliMi;
        }

        public static bool PersonelHattaEkliMi(int hatNo, string sicilNo)
        {
            bool BasariliMi = false;

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                UretimHatCalisanlarResponse res = ototrimWebservis.get_UretimHatCalisanlar(hatNo);

                if (res.IsSucces)
                {
                    Proxy.Calisanlar calisan = Array.Find(res.AktifCalisanlar, c=> c.SicilNo == sicilNo);

                    if (calisan != null)
                        BasariliMi = true;
                }
            }
            catch
            {

            }

            return BasariliMi;
        }

        public static AddCalisanResponse KullaniciEkle(int hatNo, string kullanici, DataGridView dg)
        {
            AddCalisanResponse res = new AddCalisanResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.addCalisan(hatNo, kullanici);

                if (res.IsSucces)
                    Webservis.KullaniciListesiDoldur(hatNo, dg);
            }
            catch
            {
                res.IsSucces = false;
                res.Mesaj = "Webservis ile bağlantı kurulamadı! - addCalisan " + url;
            }

            return res;
        }

        public static RemoveCalisanResponse KullaniciCikart(int hatNo, string kullanici, DataGridView dg)
        {
            RemoveCalisanResponse res = new RemoveCalisanResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.removeCalisan(hatNo, kullanici);

                if(res.IsSucces)
                    Webservis.KullaniciListesiDoldur(hatNo, dg);
            }
            catch
            {
                res.IsSucces = false;
                res.Mesaj = "Webservis ile bağlantı kurulamadı! - removeCalisan " + url;
            }

            return res;
        }

        public static UretimEmirBilgilerResponse ReferansBilgileriGetir(string uretimEmirNo, Label hataMesaj)
        {
            UretimEmirBilgilerResponse res = new UretimEmirBilgilerResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.get_UretimEmirBilgileri(uretimEmirNo);

            }
            catch
            {
                res.IsSucces = false;
                res.Mesaj = "Webservis ile bağlantı kurulamadı! - get_UretimEmirBilgileri " + url;
            }

            return res;
        }

        public static UretimHatPlanResponse UretimHatPlanGetir(int hatNo, DataGridView dg, Label hataMesaj)
        {
            UretimHatPlanResponse res = new UretimHatPlanResponse();
            dg.DataSource = null;

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.get_UretimHatPlan(hatNo);

            
                if (res.IsSucces)
                {
                    dg.DataSource = res.UretimHatPlanlari.ToList();
                    dg.Columns["MalzemeAdi"].Visible = false;
                    dg.Columns["MusteriKodu"].Visible = false;
                    dg.Columns["Aciklama"].Visible = false;

                    dg.Columns[0].Width = 60;
                    dg.Columns[1].Width = 100;
                    dg.Columns[2].Width = 242;
                    dg.Columns[3].Width = 150;
                    dg.Columns[4].Width = 60;
                }
            }
            catch
            {
                // MessageBox.Show("Webservis ile bağlantı kurulamadı! " + url, "Webservis Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return res;
        }

        public static GetBakimKontrolleriResponse BakimKontrolDurumu(int hatNo, Label hataMesaj)
        {
            GetBakimKontrolleriResponse res = new GetBakimKontrolleriResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.get_BakimKontrolleri();
            }
            catch
            {
                // MessageBox.Show("Webservis ile bağlantı kurulamadı! " + url, "Webservis Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return res;
        }

        public static GetBakimKontrolleriResponse BakimKontrolDurumu(int hatNo, DataGridView dg)
        {
            GetBakimKontrolleriResponse res = new GetBakimKontrolleriResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.get_BakimKontrolleri();

                if (res.IsSucces)
                {
                    dg.DataSource = res.BakimKontrolleri.ToList();

                    dg.Columns[0].Width = 80;
                    dg.Columns[1].Width = 80;
                    dg.Columns[2].Width = 300;
                    dg.Columns[3].Width = 100;
                }
            }
            catch
            {
                // MessageBox.Show("Webservis ile bağlantı kurulamadı! " + url, "Webservis Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return res;
        }

        public static List<Sanver_BakimKontrol> BakimKontrolList(GetBakimKontrolleriResponse res, DataGridView dg)
        {
            List<Sanver_BakimKontrol> kontrolListe = new List<Sanver_BakimKontrol>();

            try
            {
                foreach (var kontrol in res.BakimKontrolleri)
                {
                    Sanver_BakimKontrol b = new Sanver_BakimKontrol();

                    b.BakimKontrolKey = kontrol.BakimKontrolKey;
                    b.SiraNo = kontrol.SiraNo;
                    b.KontrolAciklama = kontrol.KontrolAciklama;
                    b.Evet = false;
                    b.Hayir = false;

                    kontrolListe.Add(b);
                }

                 dg.DataSource = null;
                 dg.DataSource = kontrolListe.ToList();

                 dg.Columns["BakimKontrolKey"].Visible = false;
                 dg.Columns["SiraNo"].Width = 100;
                 dg.Columns["KontrolAciklama"].Width = 320;
                 dg.Columns["Evet"].Width = 100;
                 dg.Columns["Hayir"].Width = 100;
            }
            catch
            {
                // MessageBox.Show("Webservis ile bağlantı kurulamadı! " + url, "Webservis Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return kontrolListe;
        }

        public static SetBakimKontrolleriResponse SetBakimKontrolDurumu(int hatNo, DataGridView dg, Label hataMesaj)
        {
            GetBakimKontrolleriResponse res_Get = new GetBakimKontrolleriResponse();
            SetBakimKontrolleriResponse res_Set = new SetBakimKontrolleriResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res_Get = BakimKontrolDurumu(hatNo, new DataGridView());

                if(res_Get.IsSucces)
                {
                    for (int i = 0; i < res_Get.BakimKontrolleri.Length; i++)
                    {
                        //if (dg.Rows[i].Cells[3].Value.ToBool() == true && dg.Rows[i].Cells[4].Value.ToBool() == false)
                        //    res_Get.BakimKontrolleri[i].Yanit = true;
                        //else
                        //    res_Get.BakimKontrolleri[i].Yanit = false;

                        if (dg.Rows[i].Cells[3].Value.ToBool() == true)
                            res_Get.BakimKontrolleri[i].Yanit = true;
                        else
                            res_Get.BakimKontrolleri[i].Yanit = false;

                        //res_Get.BakimKontrolleri[i].Yanit = true;
                    }

                    res_Set = ototrimWebservis.set_BakimKontrolleri(hatNo, res_Get);

                    if (res_Set.IsSucces)
                    {
                        hataMesaj.Text = "Bakım Kontrolleri Tamamlandı.";
                    }
                    else
                    {
                        hataMesaj.Text = res_Set.Mesaj;
                    }
                }
                else
                {
                    hataMesaj.Text = res_Get.Mesaj;
                }
            }
            catch
            {
                // MessageBox.Show("Webservis ile bağlantı kurulamadı! " + url, "Webservis Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return res_Set;
        }

        public static CurrentUretimHatStatuResponse Get_HatDurumu(int hatNo,Label hataMesaj)
        {
            CurrentUretimHatStatuResponse res = new CurrentUretimHatStatuResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.getCurrentUretimHatStatu(hatNo);

                //res.IsSucces = true;

                if (!res.IsSucces)
                    hataMesaj.Text = res.Mesaj;
            }
            catch
            {
                // MessageBox.Show("Webservis ile bağlantı kurulamadı! " + url, "Webservis Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                res.IsSucces = false;
                res.Mesaj = "Webservis bağlantı hatası ! - getCurrentUretimHatStatu";

                hataMesaj.Text = res.Mesaj;
            }

            return res;
        }

        public static CurrentUretimHatStatuResponse Get_HatDurumu(int hatNo, Label hataMesaj,Sanver_AnaSayfa anasayfa, Sanver_AnaSayfa.PLC_Tags hatDurum_Tagi)
        {
            hataMesaj.Text = "";

            CurrentUretimHatStatuResponse res = new CurrentUretimHatStatuResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.getCurrentUretimHatStatu(hatNo);

                if (res.IsSucces)
                {
                    hatDurum_Tagi.YazilanDeger = res.UretimHatStatu.ToInt().ToString();
                }
                else
                {
                    hataMesaj.Text = res.Mesaj;
                } 
            }
            catch
            {
                // MessageBox.Show("Webservis ile bağlantı kurulamadı! " + url, "Webservis Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                res.IsSucces = false;
                res.Mesaj = "Webservis bağlantı hatası ! - getCurrentUretimHatStatu";

                hataMesaj.Text = res.Mesaj;
            }

            return res;
        }

        public static SetUretimHatStatuResponse Set_HatDurumu(int hatNo, UretimHatStatuler hatStatus, string sicilNo, string aciklama,Label hataMesaj)
        {
            SetUretimHatStatuResponse res = new SetUretimHatStatuResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                if (hatStatus == UretimHatStatuler.KALITE_DURUS || hatStatus == UretimHatStatuler.KALITE_START)
                {
                    res = ototrimWebservis.set_UretimHatStatu(hatNo, hatStatus, sicilNo, aciklama);
                }
                else
                {
                    if (PersonelHattaEkliMi(hatNo, sicilNo))
                    {
                        res = ototrimWebservis.set_UretimHatStatu(hatNo, hatStatus, sicilNo, aciklama);
                    }
                    else
                    {
                        res.IsSucces = false;
                        res.Mesaj = "Personel Üretim Hattına Çalışan Olaran Henüz Eklenmemiş! - set_UretimHatStatu : " + hatStatus.ToString() + " - Sicil No : " + sicilNo;
                    }
                }
            }
            catch
            {
                res.IsSucces = false;
                res.Mesaj = "Webservis bağlantı hatası ! - set_UretimHatStatu : " + hatStatus.ToString();
            }

            return res;
        }

        public static EnSonKaliteOnayResponse EnSonKaliteOnay(int hatNo)
        {
            EnSonKaliteOnayResponse res = new EnSonKaliteOnayResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.getEnsonKaliteOnayZaman(hatNo);
            }
            catch
            {
                // MessageBox.Show("Webservis ile bağlantı kurulamadı! " + url, "Webservis Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                res.IsSucces = false;
                res.Mesaj = "Webservis bağlantı hatası ! - getEnsonKaliteOnayZaman";
            }

            return res;
        }

        public static EnSonKaliteOnayResponse EnSonKaliteOnay(int hatNo, DataGridView dg)
        {
            EnSonKaliteOnayResponse res = new EnSonKaliteOnayResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.getEnsonKaliteOnayZaman(hatNo);
            }
            catch
            {
                // MessageBox.Show("Webservis ile bağlantı kurulamadı! " + url, "Webservis Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                res.IsSucces = false;
                res.Mesaj = "Webservis bağlantı hatası ! - getEnsonKaliteOnayZaman";
            }

            return res;
        }

        public static UretimEmirResponse Get_YeniUretimEmir(int hatNo, Label hataMesaj)
        {
            UretimEmirResponse res = new UretimEmirResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res.IsSucces = true;
                res = ototrimWebservis.new_UretimEmir(hatNo);
            }
            catch
            {
                res.IsSucces = false;
                res.Mesaj = "Webservis bağlantı hatası ! - new_UretimEmir";
            }

            return res;
        }

        public static Set_UretimEmirResponse Set_UretimEmir(string uretimEmirNo, int step, UretimEmirIslemTipleri islemTipi, bool hatCikis, bool hataliCikis, int hataKodu, Label hataMesaj)
        {
            Set_UretimEmirResponse res = new Set_UretimEmirResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.set_UretimEmir(uretimEmirNo, step, islemTipi, hatCikis, hataliCikis, hataKodu);
            }
            catch
            {
                res.IsSucces = false;
                res.Mesaj = "Webservis bağlantı hatası ! - new_UretimEmir";
            }

            return res;
        }

        public static int KaliteKontrolZamanGetir(Label lbl,string parametreAdi)
        {
            Proxy.GetParametreResponse res = Webservis.ParametreOku(parametreAdi);

            int kaliteKontrolZamani = 0;

            if (res.IsSucces)
            {
                try
                {
                    kaliteKontrolZamani = res.IntValue;
                }
                catch
                {
                    res.IsSucces = false;
                    res.Mesaj = "Webservis bağlantı hatası !";
                }
            }
            else
            {
                if (res.Mesaj != null)
                    lbl.Text = res.Mesaj;
            }

            return kaliteKontrolZamani;
        }

        public static string KaliteKontrolDefaultUserGetir(Label lbl, string parametreAdi, Label hataMesaj)
        {
            Proxy.GetParametreResponse res = Webservis.ParametreOku(parametreAdi);

            string defaultUser = "";

            if (res.IsSucces)
            {
                try
                {
                    defaultUser = res.StringValue;
                }
                catch
                {
                    res.IsSucces = false;
                    res.Mesaj = "Webservis bağlantı hatası !";
                }
            }
            else
            {
                if (res.Mesaj != null)
                    lbl.Text = res.Mesaj;
            }

            return defaultUser;
        }

        public static GetParametreResponse ParametreOku(string parametreAdi)
        {
            GetParametreResponse res = new GetParametreResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res = ototrimWebservis.getParametre(parametreAdi);
            }
            catch
            {
                // MessageBox.Show("Webservis ile bağlantı kurulamadı! " + url, "Webservis Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                res.IsSucces = false;
                res.Mesaj = "Webservis bağlantı hatası !";
            }

            return res;
        }

        public static void AlarmMesajGoster (string mesaj,Label lbl)
        {
            if (mesaj != null)
                lbl.Text = mesaj;
        }

        public static GetUretimEmirSonucBekleyenlerResponse Get_UretimEmirSonucBekleyenler(Label hataMesaj, int tipNo)
        {
            hataMesaj.Text = "";

            GetUretimEmirSonucBekleyenlerResponse res = new GetUretimEmirSonucBekleyenlerResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res.IsSucces = true;
                res = ototrimWebservis.get_UretimEmirSonucBekleyenler(tipNo);
            }
            catch
            {
                res.IsSucces = false;
                res.Mesaj = "Webservis bağlantı hatası ! - get_UretimEmirSonucBekleyenler";
                hataMesaj.Text = res.Mesaj;
            }

            return res;
        }

        public static SetUretimEmirSonuclarResponse Set_UretimEmirSonucBekleyenler(Label hataMesaj, string uretimEmirNo, GetUretimEmirSonucBekleyenlerResponse sonuclar)
        {
            hataMesaj.Text = "";

            SetUretimEmirSonuclarResponse res = new SetUretimEmirSonuclarResponse();

            try
            {
                ototrimWebservis = new UretimTools();
                ototrimWebservis.Url = url;

                res.IsSucces = true;
                res = ototrimWebservis.set_UretimEmirSonuclar(uretimEmirNo, sonuclar);
            }
            catch
            {
                res.IsSucces = false;
                res.Mesaj = "Webservis bağlantı hatası ! - set_UretimEmirSonuclar";
                hataMesaj.Text = res.Mesaj;
            }

            return res;
        }
    }
}
