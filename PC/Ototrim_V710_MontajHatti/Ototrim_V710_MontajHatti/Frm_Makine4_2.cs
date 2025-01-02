﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sanver_FrameWorkV6;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

namespace Ototrim_V710_MontajHatti
{
    public partial class Frm_Makine4_2 : Form
    {
        #region "DEĞİŞKENLER"

        Sanver_AnaSayfa.PLC_Tags FotografAdiTagi;
        Sanver_AnaSayfa.PLC_Tags HmiInfoTagi;

        Sanver_AnaSayfa.PLC_Tags UretimHatDurumu_Tagi;
        Sanver_AnaSayfa.PLC_Tags DurusOn_Tagi;
        Sanver_AnaSayfa.PLC_Tags BakimKontrolOn_Tagi;
        Sanver_AnaSayfa.PLC_Tags MakineBos_Tagi;

        Sanver_AnaSayfa.PLC_Tags IsEmri_Iste_Tagi;

        Sanver_AnaSayfa.PLC_Tags UretimBasladi_Tagi;
        Sanver_AnaSayfa.PLC_Tags UretimBasladi_Onay_Tagi;

        Sanver_AnaSayfa.PLC_Tags UretimBitti_Tagi;
        Sanver_AnaSayfa.PLC_Tags UretimBitti_Onay_Tagi;

        Sanver_AnaSayfa.PLC_Tags IsEmriNo_Tagi;

        Sanver_AnaSayfa.PLC_Tags GenelSonuc_Tagi;
        Sanver_AnaSayfa.PLC_Tags HataKodu_Tagi;

        Sanver_AnaSayfa.PLC_Tags ReceteID_Tagi;
        Sanver_AnaSayfa.PLC_Tags IstasyonNo_Tagi;

        int hatNo = 2;

        #endregion "DEĞİŞKENLER"

        #region "PROGRAM BAŞLAMA"

        public Frm_Makine4_2()
        {
            InitializeComponent();
        }

        private void Frm_Makine4_2_Load(object sender, EventArgs e)
        {
            try { this.Location = Screen.AllScreens[0].WorkingArea.Location; }
            catch { }

            sanver_AnaSayfa1.AktifSayfa = 0;

            BaslangicKontrolleri();

            tmr_AcilisPingKontrol.Enabled = true;
        }

        private void Frm_Makine4_2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void tmr_AcilisPingKontrol_Tick(object sender, EventArgs e)
        {
            if (Helper.PingVarMi(sanver_AnaSayfa1.CPU_IP))
            {
                tmr_AcilisPingKontrol.Enabled = false;
                lbl_Comm.BackColor = Color.Lime;
                ProgramiBaslat();
            }
            else
            {
                tmr_AcilisPingKontrol.Interval = 1000;
                lbl_Comm.BackColor = Color.Red;
            }
        }

        public void ProgramiBaslat()
        {
            sanver_AnaSayfa1.AktifSayfa = 0;
            sanver_AnaSayfa1.DilSecenek = 0;
            sanver_AnaSayfa1.ConnectOpen();
            sanver_AnaSayfa1.KontrolBasla();

            //sanver_Kayit1.KontrolBasla();

            tmr_Basla.Enabled = true;
        }

        private void tmr_Basla_Tick(object sender, EventArgs e)
        {
            tmr_Basla.Enabled = false;

            sanver_AnaSayfa1.AktifSayfa = 1;

            ReceteID_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 3);
            IsEmriNo_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 4);
            FotografAdiTagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 5);
            IstasyonNo_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 11);

            HmiInfoTagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 80);

            IsEmri_Iste_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 45);
            IsEmri_Iste_Tagi.OkunanDegerUpdate += IsEmri_Iste_Tagi_OkunanDegerUpdate;

            MakineBos_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 57);
            UretimHatDurumu_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 58);
            DurusOn_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 61);
            BakimKontrolOn_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 62);

            UretimBasladi_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 63);
            UretimBasladi_Onay_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 64);
            UretimBitti_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 65);
            UretimBitti_Onay_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 66);

            GenelSonuc_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 100);
            HataKodu_Tagi = sanver_AnaSayfa1.TagListe.Find(item => item.ID == 101);

            FotografAdiTagi.OkunanDegerUpdate += FotografAdiTagi_OkunanDegerUpdate;

            UretimBasladi_Tagi.OkunanDegerUpdate += UretimBasladi_Tagi_OkunanDegerUpdate;
            UretimBitti_Tagi.OkunanDegerUpdate += UretimBitti_Tagi_OkunanDegerUpdate;

            UretimBasladi_Kontrol();
            UretimBitti_Kontrol();

            BaslangicKontrolleri();

            UretimBasladi_Kontrol();
            UretimBitti_Kontrol();

            try { Controller.FotografGoruntule.FotografiPaneldeGoster(FotografAdiTagi.OkunanDeger.TrimStart().TrimEnd(), lbl_FotografAdi, pnl_UrunFotograf); }
            catch { }


            tmr_Saat.Enabled = true;

            CheckForIllegalCrossThreadCalls = false;

            //KALİTE DURUŞU
            //KKZMN - OTOKLTUSR

        }

        public void BaslangicKontrolleri()
        {
            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa1, UretimHatDurumu_Tagi);

            Webservis.KullaniciListesiDoldur(hatNo, dg_KullaniciListe);

            Webservis.UretimHatPlanGetir(hatNo, dg_HatPlan, lbl_WebservisMesaj);

            Proxy.EnSonKaliteOnayResponse enSonKaliteOnayZamani = Webservis.EnSonKaliteOnay(hatNo);
        }

        private void pb_SanverLogo_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.sanvermuhendislik.com/");
        }

        #endregion "PROGRAM BAŞLAMA"

        #region "ÜRETİM BAŞLADI"

        void UretimBasladi_Tagi_OkunanDegerUpdate(object sender, PropertyChangedEventArgs e)
        {
            UretimBasladi_Kontrol();
        }

        public void UretimBasladi_Kontrol()
        {
            if (UretimBasladi_Tagi.OkunanDeger.ToBool() == true)
            {
                Proxy.Set_UretimEmirResponse uretimEmir_Set = Webservis.Set_UretimEmir(IsEmriNo_Tagi.OkunanDeger, Model.Steps.Step1.ToInt(), Proxy.UretimEmirIslemTipleri.BASLA, false, false, 0, lbl_WebservisMesaj);

                if (uretimEmir_Set.IsSucces)
                {
                    Veritabani.UretimEmir_TabloGuncelle_UretimBasladi(ReceteID_Tagi.OkunanDeger.ToInt(), Model.Steps.Step1);

                    //lbl_WebservisMesaj.Text = "Step 1 Başladı";
                    UretimBasladi_Onay_Tagi.YazilanDeger = "1";
                }
                else
                {
                    lbl_WebservisMesaj.Text = uretimEmir_Set.Mesaj;
                }
            }
        }

        #endregion "ÜRETİM BAŞLADI"

        #region "ÜRETİM BİTTİ"

        void UretimBitti_Tagi_OkunanDegerUpdate(object sender, PropertyChangedEventArgs e)
        {
            UretimBitti_Kontrol();
        }

        public void UretimBitti_Kontrol()
        {
            if (UretimBitti_Tagi.OkunanDeger.ToBool() == true)
            {
                bool hataliMi = false;

                if (GenelSonuc_Tagi.OkunanDeger == "2")
                    hataliMi = true;

                Proxy.Set_UretimEmirResponse uretimEmir_Set = Webservis.Set_UretimEmir(IsEmriNo_Tagi.OkunanDeger, Model.Steps.Step1.ToInt(), Proxy.UretimEmirIslemTipleri.BITIR, false, hataliMi, HataKodu_Tagi.OkunanDeger.ToInt(), lbl_WebservisMesaj);

                if (uretimEmir_Set.IsSucces)
                {
                    Veritabani.UretimEmir_TabloGuncelle_UretimBitti(ReceteID_Tagi.OkunanDeger.ToInt(), Model.Steps.Step1, HataKodu_Tagi.OkunanDeger.ToInt());

                    UretimBitti_Onay_Tagi.YazilanDeger = "1";
                }
                else
                {
                    lbl_WebservisMesaj.Text = uretimEmir_Set.Mesaj;
                }
            }
        }

        #endregion "ÜRETİM BİTTİ"

        #region "FOTOĞRAF GÜNCELLEME"

        void FotografAdiTagi_OkunanDegerUpdate(object sender, PropertyChangedEventArgs e)
        {
            Controller.FotografGoruntule.FotografiPaneldeGoster(FotografAdiTagi.OkunanDeger.TrimStart().TrimEnd(), lbl_FotografAdi, pnl_UrunFotograf);
        }

        #endregion "FOTOĞRAF GÜNCELLEME"

        #region "SAAT"

        private void tmr_Saat_Tick(object sender, EventArgs e)
        {
            lbl_Baslik.Text = string.Format("                            OTOTRİM - OHC MONTAJ MAKİNESİ - {0}", DateTime.Now.ToString());

            this.Text = lbl_Baslik.Text.TrimStart();

            DateTime dt = DateTime.Now;

            //try { dg_BakimKontrolleri.Visible = BakimKontrolOn_Tagi.OkunanDeger.ToBool(); }
            //catch { }
        }

        #endregion "SAAT"

        #region "KALİTE ONAY - KALİTE DURUŞ"

        private void btn_KaliteOnay_Click(object sender, EventArgs e)
        {
            //Start verecek kullanıcı listesinde olmak zorunda değil
        }

        private void btn_KaliteDurus_Click(object sender, EventArgs e)
        {

        }

        #endregion "KALİTE ONAY - KALİTE DURUŞ"

        #region "HAT DURUM GÜNCELLE"

        private void btn_Off_Click(object sender, EventArgs e)
        {
            lbl_WebservisMesaj.Text = "Hat durumu sadece hattaki ilk makineden değiştirilebilir!";
        }

        private void btn_On_Click(object sender, EventArgs e)
        {
            lbl_WebservisMesaj.Text = "Hat durumu sadece hattaki ilk makineden değiştirilebilir!";
        }

        private void btn_Bakim_Click(object sender, EventArgs e)
        {
            lbl_WebservisMesaj.Text = "Hat durumu sadece hattaki ilk makineden değiştirilebilir!";
        }

        private void btn_Durus_Click(object sender, EventArgs e)
        {
            lbl_WebservisMesaj.Text = "Hat durumu sadece hattaki ilk makineden değiştirilebilir!";
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa1, UretimHatDurumu_Tagi);

            if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt())
            {
                //IsEmriIste();
            }
        }

        #endregion "HAT DURUM GÜNCELLE"


        #region "İŞ EMRİ İSTE"

        void IsEmri_Iste_Tagi_OkunanDegerUpdate(object sender, PropertyChangedEventArgs e)
        {
            IsEmri_Iste_Kontrol();
        }

        public void IsEmri_Iste_Kontrol()
        {
            lbl_WebservisMesaj.Text = "";
           
            //Önce lokal veritabanından sorgula
            //Eğer lokal veritabanında iş yoksa webservisten al

            //Makinede Zaten Parça Varsa Parça İsteme, Yoksa Parça İsteğinde Bulun
            if (IstasyonNo_Tagi.OkunanDeger == "0" || ReceteID_Tagi.OkunanDeger == "0")
            {
                Model.Uretim_Hat2 urun = Veritabani.UretimEmir_TablodanOku_Hat2(Model.Steps.Step1, Veritabani.Step1_Istasyon.Sag);

                if (urun.ID != 0)
                {
                    //Urun bulundu plc'ye ürün bilgilerini ve reçeteyi gönder
                    PLC_Haberlesme.Makine4_Step1_VeriGonder(sanver_AnaSayfa1, urun);
                }
                else
                {
                    Proxy.UretimEmirResponse res = Webservis.Get_YeniUretimEmir(hatNo, lbl_WebservisMesaj);

                    if (res.IsSucces)
                    {
                        Veritabani.UretimEmir_TabloyaKaydet_Hat2(res,2);

                        urun = Veritabani.UretimEmir_TablodanOku_Hat2(Model.Steps.Step1,Veritabani.Step1_Istasyon.Sag);

                        //Urun bulundu plc'ye ürün bilgilerini ve reçeteyi gönder
                        PLC_Haberlesme.Makine4_Step1_VeriGonder(sanver_AnaSayfa1, urun);
                    }
                    else
                    {
                        lbl_WebservisMesaj.Text = res.Mesaj;
                    }
                }
            }
        }

        #endregion "İŞ EMRİ İSTE"

        private void sanver_Label6_Click(object sender, EventArgs e)
        {

        }

        private void sanver_TextBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
