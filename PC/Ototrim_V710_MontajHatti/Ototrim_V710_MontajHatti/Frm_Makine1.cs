using System;
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
    public partial class Frm_Makine1 : Form
    {
        #region "DEĞİŞKENLER"

        Sanver_AnaSayfa.PLC_Tags FotografAdiTagi;
        Sanver_AnaSayfa.PLC_Tags HmiInfoTagi;

        Sanver_AnaSayfa.PLC_Tags Makine1_DurusOn_Tagi;
        Sanver_AnaSayfa.PLC_Tags Makine2_DurusOn_Tagi;
        Sanver_AnaSayfa.PLC_Tags Makine3_DurusOn_Tagi;

        Sanver_AnaSayfa.PLC_Tags Makine1_UretimHatDurumu_Tagi;
        Sanver_AnaSayfa.PLC_Tags Makine2_UretimHatDurumu_Tagi;
        Sanver_AnaSayfa.PLC_Tags Makine3_UretimHatDurumu_Tagi;

        Sanver_AnaSayfa.PLC_Tags IsEmri_Iste_Tagi;

        Sanver_AnaSayfa.PLC_Tags BakimKontrolOn_Tagi;

        Sanver_AnaSayfa.PLC_Tags Makine1_Bos_Tagi;
        Sanver_AnaSayfa.PLC_Tags Makine2_Bos_Tagi;
        Sanver_AnaSayfa.PLC_Tags Makine3_Bos_Tagi;

        Sanver_AnaSayfa.PLC_Tags UretimBasladi_Tagi;
        Sanver_AnaSayfa.PLC_Tags UretimBasladi_Onay_Tagi;

        Sanver_AnaSayfa.PLC_Tags UretimBitti_Tagi;
        Sanver_AnaSayfa.PLC_Tags UretimBitti_Onay_Tagi;

        Sanver_AnaSayfa.PLC_Tags IsEmriNo_Tagi;

        Sanver_AnaSayfa.PLC_Tags GenelSonuc_Tagi;
        Sanver_AnaSayfa.PLC_Tags HataKodu_Tagi;

        Sanver_AnaSayfa.PLC_Tags ReceteID_Tagi;
        Sanver_AnaSayfa.PLC_Tags IstasyonNo_Tagi;

        int hatNo = 3;

        #endregion "DEĞİŞKENLER"

        #region "PROGRAM BAŞLAMA"

        public Frm_Makine1()
        {
            InitializeComponent();
        }

        private void Frm_Makine1_Load(object sender, EventArgs e)
        {
            //Proxy.EnSonKaliteOnayResponse enSonKaliteOnayZamani = Webservis.EnSonKaliteOnay(hatNo);
            //dg_KaliteOnay.DataSource = enSonKaliteOnayZamani.EnSonOnay;

            try { this.Location = Screen.AllScreens[0].WorkingArea.Location; }
            catch { }

            sanver_AnaSayfa_Makine1.AktifSayfa = 0;

 
            tmr_AcilisPingKontrol.Enabled = true;
        }

        private void Frm_Makine1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void tmr_AcilisPingKontrol_Tick(object sender, EventArgs e)
        {
            if (Helper.PingVarMi(sanver_AnaSayfa_Makine1.CPU_IP) && Helper.PingVarMi(sanver_AnaSayfa_Makine2.CPU_IP) && Helper.PingVarMi(sanver_AnaSayfa_Makine3.CPU_IP))
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

            CheckForIllegalCrossThreadCalls = false;

            sanver_AnaSayfa_Makine1.AktifSayfa = 0;
            sanver_AnaSayfa_Makine1.DilSecenek = 0;
            sanver_AnaSayfa_Makine1.ConnectOpen();
            sanver_AnaSayfa_Makine1.KontrolBasla();

            sanver_AnaSayfa_Makine2.AktifSayfa = 0;
            sanver_AnaSayfa_Makine2.DilSecenek = 0;
            sanver_AnaSayfa_Makine2.ConnectOpen();
            sanver_AnaSayfa_Makine2.KontrolBasla();

            sanver_AnaSayfa_Makine3.AktifSayfa = 0;
            sanver_AnaSayfa_Makine3.DilSecenek = 0;
            sanver_AnaSayfa_Makine3.ConnectOpen();
            sanver_AnaSayfa_Makine3.KontrolBasla();

            //sanver_Kayit1.KontrolBasla();

            tmr_Basla.Enabled = true;
        }

        private void tmr_Basla_Tick(object sender, EventArgs e)
        {
            tmr_Basla.Enabled = false;

            sanver_AnaSayfa_Makine2.AktifSayfa = 1;
            sanver_AnaSayfa_Makine3.AktifSayfa = 1;

            sanver_AnaSayfa_Makine1.AktifSayfa = 1;

            Makine1_Bos_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 57);
            Makine2_Bos_Tagi = sanver_AnaSayfa_Makine2.TagListe.Find(item => item.ID == 1);
            Makine3_Bos_Tagi = sanver_AnaSayfa_Makine3.TagListe.Find(item => item.ID == 1);

            IsEmri_Iste_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 45);
            IsEmri_Iste_Tagi.OkunanDegerUpdate += IsEmri_Iste_Tagi_OkunanDegerUpdate;
            
            Makine1_DurusOn_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 61);
            Makine2_DurusOn_Tagi = sanver_AnaSayfa_Makine2.TagListe.Find(item => item.ID == 2);
            Makine3_DurusOn_Tagi = sanver_AnaSayfa_Makine3.TagListe.Find(item => item.ID == 2);

            Makine1_UretimHatDurumu_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 58);
            Makine2_UretimHatDurumu_Tagi = sanver_AnaSayfa_Makine2.TagListe.Find(item => item.ID == 4);
            Makine3_UretimHatDurumu_Tagi = sanver_AnaSayfa_Makine3.TagListe.Find(item => item.ID == 4);

            ReceteID_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 3);
            IsEmriNo_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 4);
            FotografAdiTagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 5);
            IstasyonNo_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 11);

            HmiInfoTagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 80);

            
            BakimKontrolOn_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 62);

            UretimBasladi_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 63);
            UretimBasladi_Onay_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 64);
            UretimBitti_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 65);
            UretimBitti_Onay_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 66);

            GenelSonuc_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 100);
            HataKodu_Tagi = sanver_AnaSayfa_Makine1.TagListe.Find(item => item.ID == 101);

            FotografAdiTagi.OkunanDegerUpdate += FotografAdiTagi_OkunanDegerUpdate;

            UretimBasladi_Tagi.OkunanDegerUpdate += UretimBasladi_Tagi_OkunanDegerUpdate;
            UretimBitti_Tagi.OkunanDegerUpdate += UretimBitti_Tagi_OkunanDegerUpdate;

            this.Refresh();

            BaslangicKontrolleri();

            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine2, Makine2_UretimHatDurumu_Tagi);
            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine3, Makine3_UretimHatDurumu_Tagi);

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
            Helper.TagDegerYaz(sanver_AnaSayfa_Makine1, 46, "0");

            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);

            Webservis.BakimKontrolDurumu(hatNo, dg_BakimKontrolleri);

            Webservis.KullaniciListesiDoldur(hatNo, dg_KullaniciListe);

            Webservis.UretimHatPlanGetir(hatNo, dg_HatPlan, lbl_WebservisMesaj);

            PLC_Haberlesme.BakimZamanlariGonder("BKMZMN", sanver_AnaSayfa_Makine1, 67, lbl_WebservisMesaj);

            PLC_Haberlesme.Makine1_KaliteKontrolBilgileriGonder(sanver_AnaSayfa_Makine1, sanver_AnaSayfa_Makine2, sanver_AnaSayfa_Makine3, hatNo, lbl_WebservisMesaj);
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

                    Proxy.GetUretimEmirSonucBekleyenlerResponse get_UretimEmirSonuclar = Webservis.Get_UretimEmirSonucBekleyenler(lbl_WebservisMesaj, 31);

                    if (get_UretimEmirSonuclar.IsSucces)
                    {
                        int Vida1_Sonuc = Helper.TagDegerOku(sanver_AnaSayfa_Makine1, 102).ToInt();
                        int Vida2_Sonuc = Helper.TagDegerOku(sanver_AnaSayfa_Makine1, 103).ToInt();

                        double Vida1_Tork = Helper.TagDegerOku(sanver_AnaSayfa_Makine1, 104).ToDouble() / 100.0;
                        double Vida2_Tork = Helper.TagDegerOku(sanver_AnaSayfa_Makine1, 105).ToDouble() / 100.0;

                        int Vida1_Aci = Helper.TagDegerOku(sanver_AnaSayfa_Makine1, 106).ToInt();
                        int Vida2_Aci = Helper.TagDegerOku(sanver_AnaSayfa_Makine1, 107).ToInt();

                        for (int i = 0; i < get_UretimEmirSonuclar.UretimSonuclari.Length; i++)
                        {
                            if (get_UretimEmirSonuclar.UretimSonuclari[i].Tag == "17")
                                get_UretimEmirSonuclar.UretimSonuclari[i].Sonuc = string.Format("{0};{1};{2}", Vida1_Sonuc, Vida1_Tork, Vida1_Aci);

                            if (get_UretimEmirSonuclar.UretimSonuclari[i].Tag == "18")
                                get_UretimEmirSonuclar.UretimSonuclari[i].Sonuc = string.Format("{0};{1};{2}", Vida2_Sonuc, Vida2_Tork, Vida2_Aci);
                        }

                        Proxy.SetUretimEmirSonuclarResponse set_UretimEmirSonuclar = Webservis.Set_UretimEmirSonucBekleyenler(lbl_WebservisMesaj, IsEmriNo_Tagi.OkunanDeger, get_UretimEmirSonuclar);
                    }

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
            lbl_Baslik.Text = string.Format("                            OTOTRİM - AUX STOP MONTAJ / OFFICE MONTAJ MAKİNESİ - {0}", DateTime.Now.ToString());

            this.Text = lbl_Baslik.Text.TrimStart();

            DateTime dt = DateTime.Now;

            Helper.TagDegerYaz(sanver_AnaSayfa_Makine1, 150, dt.Hour.ToString());
            Helper.TagDegerYaz(sanver_AnaSayfa_Makine1, 151, dt.Minute.ToString());
            Helper.TagDegerYaz(sanver_AnaSayfa_Makine1, 152, dt.Second.ToString());

            if (BakimKontrolOn_Tagi.OkunanDeger.ToBool() == true)
            {
                if (dg_BakimKontrolleri.Visible == false)
                {
                    Webservis.BakimKontrolDurumu(hatNo, dg_BakimKontrolleri);
                    dg_BakimKontrolleri.Visible = true;
                    btn_BakimKontrolKaydet.Visible = true;
                }
            }
            else
            {
                dg_BakimKontrolleri.Visible = false;
                btn_BakimKontrolKaydet.Visible = false;
            }

            DurusKontrol();

            KaliteKontrolZamanKontrolu();
        }

        public void KaliteKontrolZamanKontrolu()
        {
            try
            {
                DateTime SonKaliteKontrolZamani = Helper.TagDegerOku(sanver_AnaSayfa_Makine1, 49).ToDatetime();
                int KaliteKontrolPeriyodu_min = Helper.TagDegerOku(sanver_AnaSayfa_Makine1, 47).ToInt() * 60;
                int KaliteKontrolGerekli = Helper.TagDegerOku(sanver_AnaSayfa_Makine1, 46).ToInt();
                string DefaultUser = Helper.TagDegerOku(sanver_AnaSayfa_Makine1, 48);

                if (KaliteKontrolGerekli == 0)
                {
                    if (Makine1_UretimHatDurumu_Tagi.OkunanDeger.ToInt() != 6)
                    {
                        if (DateTime.Now.AddMinutes(-KaliteKontrolPeriyodu_min) > SonKaliteKontrolZamani)
                        {
                            Proxy.SetUretimHatStatuResponse hatDurumuSet;

                            hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.KALITE_DURUS, DefaultUser, "", lbl_WebservisMesaj);

                            if (hatDurumuSet.IsSucces)
                            {
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine2, Makine2_UretimHatDurumu_Tagi);
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine3, Makine3_UretimHatDurumu_Tagi);

                                Helper.TagDegerYaz(sanver_AnaSayfa_Makine1, 46, "1");
                            }
                            else
                            {
                                lbl_WebservisMesaj.Text = hatDurumuSet.Mesaj;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        #endregion "SAAT"

        #region "KALİTE ONAY - KALİTE DURUŞ"

        private void btn_KaliteOnay_Click(object sender, EventArgs e)
        {
            //Start verecek kullanıcı listesinde olmak zorunda değil

            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
            Proxy.SetUretimHatStatuResponse hatDurumuSet;

            //lbl_WebservisMesaj.Text = "";

            if (hatDurumuGet.IsSucces)
            {
                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.DURUS.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.BAKIM.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_DURUS.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt())
                {
                    hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.KALITE_START, txt_KaliteKullanici.Text, "", lbl_WebservisMesaj);

                   // hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.KALITE_DURUS, txt_KaliteKullanici.Text, "", lbl_WebservisMesaj);

                    if (hatDurumuSet.IsSucces)
                    {
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine2, Makine2_UretimHatDurumu_Tagi);
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine3, Makine3_UretimHatDurumu_Tagi);

                        txt_Kullanici.Text = "";

                        PLC_Haberlesme.Makine1_KaliteKontrolBilgileriGonder(sanver_AnaSayfa_Makine1, sanver_AnaSayfa_Makine2, sanver_AnaSayfa_Makine3, hatNo, lbl_WebservisMesaj);

                        //Nok Kasa Sayaçları Sıfırla - Tag Eklenecek
                        Helper.TagDegerYaz(sanver_AnaSayfa_Makine1, 153, "0"); //Aux montaj Nok Kasa
                        Helper.TagDegerYaz(sanver_AnaSayfa_Makine1, 154, "0"); //Office montaj Nok Kasa
                        Helper.TagDegerYaz(sanver_AnaSayfa_Makine2, 153, "0"); //Aux test Nok Kasa
                        Helper.TagDegerYaz(sanver_AnaSayfa_Makine3, 153, "0"); //Office test Nok Kasa

                        lbl_WebservisMesaj.Text = "KALITE START yapıldı";

                        txt_KaliteKullanici.Text = "";

                        tmr_KaliteKontrolYapildi.Enabled = true;
                    }
                    else
                    {
                        lbl_WebservisMesaj.Text = hatDurumuSet.Mesaj;
                    }
                }
            }
        }

        private void tmr_KaliteKontrolYapildi_Tick(object sender, EventArgs e)
        {
            tmr_KaliteKontrolYapildi.Enabled = false;
            Helper.TagDegerYaz(sanver_AnaSayfa_Makine1, 46, "0");
        }

        private void btn_KaliteDurus_Click(object sender, EventArgs e)
        {

        }
        
        #endregion "KALİTE ONAY - KALİTE DURUŞ"

        #region "HAT DURUM GÜNCELLE"

        private void btn_Off_Click(object sender, EventArgs e)
        {
            if (Makine1_Bos_Tagi.OkunanDeger.ToInt() == 1 && Makine2_Bos_Tagi.OkunanDeger.ToInt() == 1 && Makine3_Bos_Tagi.OkunanDeger.ToInt() == 1)
            {
                Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
                Proxy.SetUretimHatStatuResponse hatDurumuSet;

                //lbl_WebservisMesaj.Text = "";

                if (hatDurumuGet.IsSucces)
                {
                    if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.DURUS.ToInt())
                    {
                        hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.OFF, txt_Kullanici.Text, "", lbl_WebservisMesaj);

                        if (hatDurumuSet.IsSucces)
                        {
                            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
                            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine2, Makine2_UretimHatDurumu_Tagi);
                            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine3, Makine3_UretimHatDurumu_Tagi);

                            txt_Kullanici.Text = "";

                            Webservis.TumKullanicilariCikart(hatNo, dg_KullaniciListe);

                            Makine1_DurusOn_Tagi.YazilanDeger = "0";
                            Makine2_DurusOn_Tagi.YazilanDeger = "0";
                            Makine3_DurusOn_Tagi.YazilanDeger = "0";
                        }
                        else
                        {
                            Webservis.AlarmMesajGoster(hatDurumuSet.Mesaj, lbl_WebservisMesaj);
                        }
                    }
                }
            }
            else
            {
                lbl_WebservisMesaj.Text = "Hattaki Tüm İstasyonlar Boş Olmalı";
            }
        }

        private void btn_On_Click(object sender, EventArgs e)
        {
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
            Proxy.SetUretimHatStatuResponse hatDurumuSet;
            Proxy.AddCalisanResponse addCalisan;

            //lbl_WebservisMesaj.Text = "";

            if (hatDurumuGet.IsSucces)
            {
                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.OFF.ToInt())
                {
                    int KullaniciSayi = Webservis.KullaniciListesiDoldur(hatNo, dg_KullaniciListe);

                    if(KullaniciSayi == 0)
                    {
                        addCalisan = Webservis.KullaniciEkle(hatNo, txt_Kullanici.Text, dg_KullaniciListe);

                        if (addCalisan.IsSucces)
                        {
                            Webservis.KullaniciListesiDoldur(hatNo, dg_KullaniciListe);

                            hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.ON, txt_Kullanici.Text, "", lbl_WebservisMesaj);

                            if (hatDurumuSet.IsSucces)
                            {
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine2, Makine2_UretimHatDurumu_Tagi);
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine3, Makine3_UretimHatDurumu_Tagi);

                                txt_Kullanici.Text = "";
                            }
                            else
                            {
                                Webservis.AlarmMesajGoster(hatDurumuSet.Mesaj, lbl_WebservisMesaj);
                            }
                        }
                        else
                        {
                            Webservis.AlarmMesajGoster(addCalisan.Mesaj, lbl_WebservisMesaj);
                        }
                    }
                }
                else
                {
                    lbl_WebservisMesaj.Text = "Hat sadece OFF modundan ON moduna geçebilir!";
                }
            }
        }

        private void btn_Bakim_Click(object sender, EventArgs e)
        {
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
            Proxy.SetUretimHatStatuResponse hatDurumuSet;

            lbl_WebservisMesaj.Text = "";

            if (hatDurumuGet.IsSucces)
            {
                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt())
                {
                    hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.BAKIM, txt_Kullanici.Text, "", lbl_WebservisMesaj);

                    if (hatDurumuSet.IsSucces)
                    {
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine2, Makine2_UretimHatDurumu_Tagi);
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine3, Makine3_UretimHatDurumu_Tagi);

                        txt_Kullanici.Text = "";
                    }
                    else
                    {
                        Webservis.AlarmMesajGoster(hatDurumuSet.Mesaj, lbl_WebservisMesaj);
                    }
                }
                else
                {
                    lbl_WebservisMesaj.Text = "Hat ON, START veya KALITE_START modundan BAKIM moduna geçebilir!";
                }
            }
        }

        private void btn_Durus_Click(object sender, EventArgs e)
        {
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);

            lbl_WebservisMesaj.Text = "";

            if (hatDurumuGet.IsSucces)
            {
                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt())
                {
                    if (Webservis.PersonelHattaEkliMi(hatNo, txt_Kullanici.Text))
                    {
                        Makine1_DurusOn_Tagi.YazilanDeger = "1";
                        Makine2_DurusOn_Tagi.YazilanDeger = "1";
                        Makine3_DurusOn_Tagi.YazilanDeger = "1";
                    }  
                    else
                        lbl_WebservisMesaj.Text = "Personel Üretim Hattına Çalışan Olaran Henüz Eklenmemiş!";
                }
            }
        }

        public void DurusKontrol()
        {
            if (Makine1_DurusOn_Tagi.OkunanDeger.ToBool() == true)
            {
                Makine2_DurusOn_Tagi.YazilanDeger = "1";
                Makine3_DurusOn_Tagi.YazilanDeger = "1";

                if (Makine1_Bos_Tagi.OkunanDeger.ToInt() == 1 && Makine2_Bos_Tagi.OkunanDeger.ToInt() == 1 && Makine3_Bos_Tagi.OkunanDeger.ToInt() == 1)
                {
                    Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
                    Proxy.SetUretimHatStatuResponse hatDurumuSet;

                    lbl_WebservisMesaj.Text = "";

                    if (hatDurumuGet.IsSucces)
                    {
                        if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt())
                        {
                            hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.DURUS, txt_Kullanici.Text, "", lbl_WebservisMesaj);

                            if (hatDurumuSet.IsSucces)
                            {
                                Makine1_DurusOn_Tagi.YazilanDeger = "0";
                                Makine2_DurusOn_Tagi.YazilanDeger = "0";
                                Makine3_DurusOn_Tagi.YazilanDeger = "0";

                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine2, Makine2_UretimHatDurumu_Tagi);
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine3, Makine3_UretimHatDurumu_Tagi);

                                txt_Kullanici.Text = "";
                            }
                            else
                            {
                                lbl_WebservisMesaj.Text = hatDurumuSet.Mesaj;
                            }
                        }
                    }
                }
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
            Proxy.SetUretimHatStatuResponse hatDurumuSet;

            lbl_WebservisMesaj.Text = "";

            if (hatDurumuGet.IsSucces)
            {
                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.DURUS.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.BAKIM.ToInt())
                {
                    hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.START, txt_Kullanici.Text, "", lbl_WebservisMesaj);

                    if (hatDurumuSet.IsSucces)
                    {
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine2, Makine2_UretimHatDurumu_Tagi);
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine3, Makine3_UretimHatDurumu_Tagi);

                        txt_Kullanici.Text = "";

                        //IsEmriIste();
                    }
                    else
                    {
                        lbl_WebservisMesaj.Text = hatDurumuSet.Mesaj;
                    }
                }

                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt())
                {
                    //IsEmriIste();
                }
            }
        }

        #endregion "HAT DURUM GÜNCELLE"

        #region "KULLANICI EKLE - KULLANICI ÇIKART"

        private void btn_KullaniciEkle_Click(object sender, EventArgs e)
        {
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);

            if (hatDurumuGet.UretimHatStatu.ToInt() >= 2)
            {
                if (txt_Kullanici.Text.Length > 2)
                {
                    lbl_WebservisMesaj.Text = "";

                    Proxy.AddCalisanResponse addCalisan = Webservis.KullaniciEkle(hatNo, txt_Kullanici.Text, dg_KullaniciListe);

                    if (!addCalisan.IsSucces)
                        Webservis.AlarmMesajGoster(addCalisan.Mesaj, lbl_WebservisMesaj);

                    txt_Kullanici.Text = "";
                }
            }
            else
            {
                lbl_WebservisMesaj.Text = "OFF Modunda Üretim Hattına Çalışan Eklenemez!";
            }
        }

        private void btn_KullaniciCikart_Click(object sender, EventArgs e)
        {
            if (txt_Kullanici.Text.Length > 2)
            {
                lbl_WebservisMesaj.Text = "";

                Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine1, Makine1_UretimHatDurumu_Tagi);
                Proxy.RemoveCalisanResponse removeCalisan;

                int kullaniciSayisi = Webservis.KullaniciListesiDoldur(hatNo, dg_KullaniciListe);

                if (hatDurumuGet.IsSucces)
                {
                    if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt())
                    {
                        if (kullaniciSayisi >= 2)
                        {
                            removeCalisan = Webservis.KullaniciCikart(hatNo, txt_Kullanici.Text, dg_KullaniciListe);

                            if (!removeCalisan.IsSucces)
                                Webservis.AlarmMesajGoster(removeCalisan.Mesaj, lbl_WebservisMesaj);
                        }
                        else
                        {
                            lbl_WebservisMesaj.Text = "Hatta Çalışan Personel Sayısı = 1, START modunda hattan tüm personeller çıkartılamaz!";
                        }
                    }
                }
                else
                {
                    Webservis.AlarmMesajGoster(hatDurumuGet.Mesaj, lbl_WebservisMesaj);
                }

                txt_Kullanici.Text = "";
            }
        }

        #endregion "KULLANICI EKLE - KULLANICI ÇIKART"

        #region "İŞ EMRİ İSTE"

        void IsEmri_Iste_Tagi_OkunanDegerUpdate(object sender, PropertyChangedEventArgs e)
        {
            IsEmri_Iste_Kontrol();
        }

        public void IsEmri_Iste_Kontrol()
        {
            lbl_WebservisMesaj.Text = "";

            if (IsEmri_Iste_Tagi.OkunanDeger.ToBool() == true)
            {
              
                //Önce lokal veritabanından sorgula
                //Eğer lokal veritabanında iş yoksa webservisten al

                //Makinede Zaten Parça Varsa Parça İsteme, Yoksa Parça İsteğinde Bulun
                if (IstasyonNo_Tagi.OkunanDeger == "0" || ReceteID_Tagi.OkunanDeger == "0")
                {
                    Model.Uretim_Hat3 urun = Veritabani.UretimEmir_TablodanOku_Hat3(Model.Steps.Step1, -1);

                    if (urun.ID != 0)
                    {
                        //Urun bulundu plc'ye ürün bilgilerini ve reçeteyi gönder
                        PLC_Haberlesme.Makine1_Step1_VeriGonder(sanver_AnaSayfa_Makine1, urun);
                    }
                    else
                    {
                        Proxy.UretimEmirResponse res = Webservis.Get_YeniUretimEmir(hatNo, lbl_WebservisMesaj);

                        if (res.IsSucces)
                        {
                            Veritabani.UretimEmir_TabloyaKaydet_Hat3(res);

                            urun = Veritabani.UretimEmir_TablodanOku_Hat3(Model.Steps.Step1, -1);

                            //Urun bulundu plc'ye ürün bilgilerini ve reçeteyi gönder
                            PLC_Haberlesme.Makine1_Step1_VeriGonder(sanver_AnaSayfa_Makine1, urun);
                        }
                        else
                        {
                            lbl_WebservisMesaj.Text = res.Mesaj;
                        }
                    }
                }
            }
        }

        #endregion "İŞ EMRİ İSTE"

        #region "BAKIM KONTROL"
        
        private void btn_BakimKontrolKaydet_Click(object sender, EventArgs e)
        {
            Proxy.SetBakimKontrolleriResponse res = Webservis.SetBakimKontrolDurumu(hatNo, dg_BakimKontrolleri, lbl_WebservisMesaj);

            if (res.IsSucces)
            {
                BakimKontrolOn_Tagi.YazilanDeger = "0";
            }
        }

        #endregion
    }
}
