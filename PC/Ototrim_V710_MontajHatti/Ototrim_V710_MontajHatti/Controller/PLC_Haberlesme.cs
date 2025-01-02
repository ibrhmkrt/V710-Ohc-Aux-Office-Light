using Sanver_FrameWorkV6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ototrim_V710_MontajHatti
{
    public static class PLC_Haberlesme
    {
        //Aux Stop Lamp / Office Lamp Reçete Bilgilerini Gönder
        public static void Makine1_Step1_VeriGonder(Sanver_AnaSayfa anasayfa, Model.Uretim_Hat3 urun)
        {
            Helper.TagDegerYaz(anasayfa, 1, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 2, DateTime.Now.ToString());
            Helper.TagDegerYaz(anasayfa, 3, urun.ID.ToString());
            Helper.TagDegerYaz(anasayfa, 4, urun.UretimEmirNo);
            Helper.TagDegerYaz(anasayfa, 5, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 6, urun.Referans_Adi);
            Helper.TagDegerYaz(anasayfa, 7, urun.Referans_MusteriKodu);
            Helper.TagDegerYaz(anasayfa, 8, urun.Referans_Barkod);
            Helper.TagDegerYaz(anasayfa, 9, urun.ToplamUretilecekMiktar.ToString());

            Helper.TagDegerYaz(anasayfa, 10, urun.Step1_MakineNo.ToString());
            Helper.TagDegerYaz(anasayfa, 11, urun.Step1_IstasyonNo.ToString());
            Helper.TagDegerYaz(anasayfa, 12, urun.Step1_SikiciProgramNo.ToString());
            Helper.TagDegerYaz(anasayfa, 13, urun.Step1_RedKasaKapasite.ToString());
            Helper.TagDegerYaz(anasayfa, 14, urun.Step1_UretimSuresi.ToString());

            Helper.TagDegerYaz(anasayfa, 64, urun.Step1_Basladi.ToInt().ToString()); //UretimBasladi_Onay
        }

        //Aux Stop Lamp Final Reçete Bilgilerini Gönder
        public static void Makine2_Step2_VeriGonder(Sanver_AnaSayfa anasayfa, Model.Uretim_Hat3 urun)
        {
            Helper.TagDegerYaz(anasayfa, 1, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 2, DateTime.Now.ToString());
            Helper.TagDegerYaz(anasayfa, 3, urun.ID.ToString());
            Helper.TagDegerYaz(anasayfa, 4, urun.UretimEmirNo);
            Helper.TagDegerYaz(anasayfa, 5, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 6, urun.Referans_Adi);
            Helper.TagDegerYaz(anasayfa, 7, urun.Referans_MusteriKodu);
            Helper.TagDegerYaz(anasayfa, 8, urun.Referans_Barkod);
            Helper.TagDegerYaz(anasayfa, 9, urun.ToplamUretilecekMiktar.ToString());

            Helper.TagDegerYaz(anasayfa, 10, urun.Step2_MakineNo.ToString());
            Helper.TagDegerYaz(anasayfa, 11, urun.Step2_IstasyonNo.ToString());
            Helper.TagDegerYaz(anasayfa, 12, urun.Step2_RedKasaKapasite.ToString());
            Helper.TagDegerYaz(anasayfa, 13, urun.Step2_UretimSuresi.ToString());

            Helper.TagDegerYaz(anasayfa, 15, (urun.Step2_Lux1_Max * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 14, (urun.Step2_Lux1_Min * 10).ToInt().ToString());

            Helper.TagDegerYaz(anasayfa, 64, urun.Step2_Basladi.ToInt().ToString()); //UretimBasladi_Onay
        }

        //Office Lamp Final Reçete Bilgilerini Gönder
        public static void Makine3_Step2_VeriGonder(Sanver_AnaSayfa anasayfa, Model.Uretim_Hat3 urun)
        {
            Helper.TagDegerYaz(anasayfa, 1, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 2, DateTime.Now.ToString());
            Helper.TagDegerYaz(anasayfa, 3, urun.ID.ToString());
            Helper.TagDegerYaz(anasayfa, 4, urun.UretimEmirNo);
            Helper.TagDegerYaz(anasayfa, 5, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 6, urun.Referans_Adi);
            Helper.TagDegerYaz(anasayfa, 7, urun.Referans_MusteriKodu);
            Helper.TagDegerYaz(anasayfa, 8, urun.Referans_Barkod);
            Helper.TagDegerYaz(anasayfa, 9, urun.ToplamUretilecekMiktar.ToString());

            Helper.TagDegerYaz(anasayfa, 10, urun.Step2_MakineNo.ToString());
            Helper.TagDegerYaz(anasayfa, 11, urun.Step2_IstasyonNo.ToString());
            Helper.TagDegerYaz(anasayfa, 12, urun.Step2_RedKasaKapasite.ToString());
            Helper.TagDegerYaz(anasayfa, 13, urun.Step2_UretimSuresi.ToString());

            Helper.TagDegerYaz(anasayfa, 15, (urun.Step2_Lux1_Max * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 14, (urun.Step2_Lux1_Min * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 17, (urun.Step2_Lux2_Max * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 16, (urun.Step2_Lux2_Min * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 19, (urun.Step2_Lux3_Max * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 18, (urun.Step2_Lux3_Min * 10).ToInt().ToString());

            Helper.TagDegerYaz(anasayfa, 21, (urun.Step2_Lux4_Max * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 20, (urun.Step2_Lux4_Min * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 23, (urun.Step2_Lux5_Max * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 22, (urun.Step2_Lux5_Min * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 25, (urun.Step2_Lux6_Max * 10).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 24, (urun.Step2_Lux6_Min * 10).ToInt().ToString());

            Helper.TagDegerYaz(anasayfa, 64, urun.Step2_Basladi.ToInt().ToString()); //UretimBasladi_Onay
        }

        //OHC Montaj Makinesi Montaj Tarafı Reçete Bilgilerini Gönder
        public static void Makine4_Step1_VeriGonder(Sanver_AnaSayfa anasayfa, Model.Uretim_Hat2 urun)
        {
            Helper.TagDegerYaz(anasayfa, 1, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 2, DateTime.Now.ToString());
            Helper.TagDegerYaz(anasayfa, 3, urun.ID.ToString());
            Helper.TagDegerYaz(anasayfa, 4, urun.UretimEmirNo);
            Helper.TagDegerYaz(anasayfa, 5, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 6, urun.Referans_Adi);
            Helper.TagDegerYaz(anasayfa, 7, urun.Referans_MusteriKodu);
            Helper.TagDegerYaz(anasayfa, 8, urun.Referans_Barkod);
            Helper.TagDegerYaz(anasayfa, 9, urun.ToplamUretilecekMiktar.ToString());
            
        
            Helper.TagDegerYaz(anasayfa, 10, urun.Step1_MakineNo.ToString());
            Helper.TagDegerYaz(anasayfa, 11, urun.Step1_IstasyonNo.ToString());
            Helper.TagDegerYaz(anasayfa, 13, urun.Step1_RedKasaKapasite.ToString());

            Helper.TagDegerYaz(anasayfa, 14, urun.Step1_UretimSuresi.ToString());
            Helper.TagDegerYaz(anasayfa, 15, urun.Step1_YaglamaSure.ToString());

            Helper.TagDegerYaz(anasayfa, 64, urun.Step1_Basladi.ToInt().ToString()); //UretimBasladi_Onay
        }

        //OHC Montaj Makinesi Sıkıcı Tarafı Reçete Bilgilerini Gönder
        public static void Makine4_Step2_VeriGonder(Sanver_AnaSayfa anasayfa, Model.Uretim_Hat2 urun)
        {
            Helper.TagDegerYaz(anasayfa, 1, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 2, DateTime.Now.ToString());
            Helper.TagDegerYaz(anasayfa, 3, urun.ID.ToString());
            Helper.TagDegerYaz(anasayfa, 4, urun.UretimEmirNo);
            Helper.TagDegerYaz(anasayfa, 5, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 6, urun.Referans_Adi);
            Helper.TagDegerYaz(anasayfa, 7, urun.Referans_MusteriKodu);
            Helper.TagDegerYaz(anasayfa, 8, urun.Referans_Barkod);
            Helper.TagDegerYaz(anasayfa, 9, urun.ToplamUretilecekMiktar.ToString());


            Helper.TagDegerYaz(anasayfa, 10, urun.Step2_MakineNo.ToString());
            Helper.TagDegerYaz(anasayfa, 11, urun.Step2_IstasyonNo.ToString());
            Helper.TagDegerYaz(anasayfa, 12, urun.Step2_SikiciProgramNo.ToString());
            Helper.TagDegerYaz(anasayfa, 13, urun.Step2_RedKasaKapasite.ToString());

            Helper.TagDegerYaz(anasayfa, 14, urun.Step2_UretimSuresi.ToString());
            Helper.TagDegerYaz(anasayfa, 64, urun.Step2_Basladi.ToInt().ToString()); //UretimBasladi_Onay
        }

        //OHC Final Makinesi Reçete Bilgilerini Gönder
        public static void Makine5_Step3_VeriGonder(Sanver_AnaSayfa anasayfa, Model.Uretim_Hat2 urun)
        {
            Helper.TagDegerYaz(anasayfa, 1, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 2, DateTime.Now.ToString());
            Helper.TagDegerYaz(anasayfa, 3, urun.ID.ToString());
            Helper.TagDegerYaz(anasayfa, 4, urun.UretimEmirNo);
            Helper.TagDegerYaz(anasayfa, 5, urun.Referans_Kodu);
            Helper.TagDegerYaz(anasayfa, 6, urun.Referans_Adi);
            Helper.TagDegerYaz(anasayfa, 7, urun.Referans_MusteriKodu);
            Helper.TagDegerYaz(anasayfa, 8, urun.Referans_Barkod);
            Helper.TagDegerYaz(anasayfa, 9, urun.ToplamUretilecekMiktar.ToString());

            Helper.TagDegerYaz(anasayfa, 10, urun.Step3_MakineNo.ToString());
            Helper.TagDegerYaz(anasayfa, 11, urun.Step3_IstasyonNo.ToString());
            Helper.TagDegerYaz(anasayfa, 12, urun.Step3_RedKasaKapasite.ToString());
            Helper.TagDegerYaz(anasayfa, 13, urun.Step3_UretimSuresi.ToString());

            Helper.TagDegerYaz(anasayfa, 14, (urun.Step3_KameraProgNo_Lamba1).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 15, (urun.Step3_KameraProgNo_Lamba2).ToInt().ToString());

            Helper.TagDegerYaz(anasayfa, 16, (urun.Step3_LambaAkimDegeriMin).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 17, (urun.Step3_LambaAkimDegeriMax).ToInt().ToString());

            Helper.TagDegerYaz(anasayfa, 18, (urun.SOS_Secim).ToInt().ToString());

            Helper.TagDegerYaz(anasayfa, 19, (urun.SOS_BarkodAktif).ToInt().ToString());
            Helper.TagDegerYaz(anasayfa, 20, (urun.SOS_Barkod).ToString());

            Helper.TagDegerYaz(anasayfa, 64, urun.Step3_Basladi.ToInt().ToString()); //UretimBasladi_Onay
        }

        public static void BakimZamanlariGonder(string parametreAdi, Sanver_AnaSayfa anasayfa, int baslangicTagNo, Label lbl)
        {
            Proxy.GetParametreResponse res = Webservis.ParametreOku(parametreAdi);

            if (res.IsSucces)
            {
                try
                {
                    string[] saatler = res.StringValue.Split(';');

                    Helper.TagDegerYaz(anasayfa, baslangicTagNo, saatler[0].Trim());
                    Helper.TagDegerYaz(anasayfa, baslangicTagNo + 1, saatler[1].Trim());

                    Helper.TagDegerYaz(anasayfa, baslangicTagNo + 2, saatler[1].Trim());
                    Helper.TagDegerYaz(anasayfa, baslangicTagNo + 3, saatler[2].Trim());

                    Helper.TagDegerYaz(anasayfa, baslangicTagNo + 4, saatler[2].Trim());
                    Helper.TagDegerYaz(anasayfa, baslangicTagNo + 5, saatler[0].Trim());
                }
                catch (Exception ex)
                {
                    lbl.Text = ex.Message + " Vardiya Formatı Hatalı! \"0;8;16\" formatında olmalı";
                }
            }
            else
            {
                if (res.Mesaj != null)
                    lbl.Text = res.Mesaj;
            }
        }

        public static void Makine1_KaliteKontrolBilgileriGonder(Sanver_AnaSayfa anasayfa_Makine1, Sanver_AnaSayfa anasayfa_Makine2, Sanver_AnaSayfa anasayfa_Makine3, int hatNo, Label lbl)
        {
            Proxy.GetParametreResponse _kontrolPeriyodu = Webservis.ParametreOku("KKZMN");
            Proxy.GetParametreResponse _defaultUser = Webservis.ParametreOku("OTOKLTUSR");
            Proxy.EnSonKaliteOnayResponse _sonKontrolZamani = Webservis.EnSonKaliteOnay(hatNo);

            if (_defaultUser.IsSucces && _kontrolPeriyodu.IsSucces && _sonKontrolZamani.IsSucces)
            {
                try
                {
                    int kontrolPeriyodu = _kontrolPeriyodu.IntValue;
                    string defaultuser = _defaultUser.StringValue;
                    DateTime sonKontrolZamani = _sonKontrolZamani.EnSonOnay;

                    Helper.TagDegerYaz(anasayfa_Makine1, 47, kontrolPeriyodu.ToString());
                    Helper.TagDegerYaz(anasayfa_Makine1, 48, defaultuser);
                    Helper.TagDegerYaz(anasayfa_Makine1, 49, sonKontrolZamani.ToString());

                    Helper.TagDegerYaz(anasayfa_Makine2, 6, kontrolPeriyodu.ToString());
                    Helper.TagDegerYaz(anasayfa_Makine2, 7, defaultuser);
                    Helper.TagDegerYaz(anasayfa_Makine2, 8, sonKontrolZamani.ToString());

                    Helper.TagDegerYaz(anasayfa_Makine3, 6, kontrolPeriyodu.ToString());
                    Helper.TagDegerYaz(anasayfa_Makine3, 7, defaultuser);
                    Helper.TagDegerYaz(anasayfa_Makine3, 8, sonKontrolZamani.ToString());


                }
                catch (Exception ex)
                {
                    lbl.Text = ex.Message;
                }
            }
            else
            {
                if (!_defaultUser.IsSucces)
                {
                    if (_defaultUser.Mesaj != null)
                        lbl.Text = _defaultUser.Mesaj;
                }

                if (!_kontrolPeriyodu.IsSucces)
                {
                    if (_kontrolPeriyodu.Mesaj != null)
                        lbl.Text = _kontrolPeriyodu.Mesaj;
                }

                if (!_sonKontrolZamani.IsSucces)
                {
                    if (_sonKontrolZamani.Mesaj != null)
                        lbl.Text = _sonKontrolZamani.Mesaj;
                }
            }
        }

        public static void Makine4_KaliteKontrolBilgileriGonder(Sanver_AnaSayfa anasayfa_Makine4, Sanver_AnaSayfa anasayfa_Makine5, int hatNo, Label lbl)
        {
            Proxy.GetParametreResponse _kontrolPeriyodu = Webservis.ParametreOku("KKZMN");
            Proxy.GetParametreResponse _defaultUser = Webservis.ParametreOku("OTOKLTUSR");
            Proxy.EnSonKaliteOnayResponse _sonKontrolZamani = Webservis.EnSonKaliteOnay(hatNo);

            if (_defaultUser.IsSucces && _kontrolPeriyodu.IsSucces && _sonKontrolZamani.IsSucces)
            {
                try
                {
                    int kontrolPeriyodu = _kontrolPeriyodu.IntValue;
                    string defaultuser = _defaultUser.StringValue;
                    DateTime sonKontrolZamani = _sonKontrolZamani.EnSonOnay;

                    Helper.TagDegerYaz(anasayfa_Makine4, 47, kontrolPeriyodu.ToString());
                    Helper.TagDegerYaz(anasayfa_Makine4, 48, defaultuser);
                    Helper.TagDegerYaz(anasayfa_Makine4, 49, sonKontrolZamani.ToString());

                    Helper.TagDegerYaz(anasayfa_Makine5, 6, kontrolPeriyodu.ToString());
                    Helper.TagDegerYaz(anasayfa_Makine5, 7, defaultuser);
                    Helper.TagDegerYaz(anasayfa_Makine5, 8, sonKontrolZamani.ToString());

                }
                catch (Exception ex)
                {
                    lbl.Text = ex.Message;
                }
            }
            else
            {
                if(!_defaultUser.IsSucces)
                {
                    if (_defaultUser.Mesaj != null)
                    lbl.Text = _defaultUser.Mesaj;
                }

                if (!_kontrolPeriyodu.IsSucces)
                {
                    if (_kontrolPeriyodu.Mesaj != null)
                        lbl.Text = _kontrolPeriyodu.Mesaj;
                }

                if (!_sonKontrolZamani.IsSucces)
                {
                    if (_sonKontrolZamani.Mesaj != null)
                        lbl.Text = _sonKontrolZamani.Mesaj;
                }
            }
        }
    }
}
