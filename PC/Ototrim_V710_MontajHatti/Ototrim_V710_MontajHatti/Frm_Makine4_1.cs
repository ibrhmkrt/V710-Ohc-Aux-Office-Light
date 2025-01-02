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
    public partial class Frm_Makine4_1 : Form
    {
        #region "DEĞİŞKENLER"

        Sanver_AnaSayfa.PLC_Tags FotografAdiTagi;
        Sanver_AnaSayfa.PLC_Tags HmiInfoTagi;

        Sanver_AnaSayfa.PLC_Tags Makine4_DurusOn_Tagi;
        Sanver_AnaSayfa.PLC_Tags Makine5_DurusOn_Tagi;

        Sanver_AnaSayfa.PLC_Tags Makine4_UretimHatDurumu_Tagi;
        Sanver_AnaSayfa.PLC_Tags Makine5_UretimHatDurumu_Tagi;

        Sanver_AnaSayfa.PLC_Tags IsEmri_Iste_Tagi;
        
        Sanver_AnaSayfa.PLC_Tags BakimKontrolOn_Tagi;

        Sanver_AnaSayfa.PLC_Tags Makine4_Bos_Tagi;
        Sanver_AnaSayfa.PLC_Tags Makine5_Bos_Tagi;

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

        public Frm_Makine4_1()
        {
            InitializeComponent();
        }

        private void Frm_Makine4_1_Load(object sender, EventArgs e)
        {
            //string s = "";

            //Helper.DosyayaYaz("test", "skdjskjds", @"D:\SANVER\URETIMEMIR\", "ryeuryuerrere");

            try { this.Location = Screen.AllScreens[0].WorkingArea.Location; }
            catch { }

            sanver_AnaSayfa_Makine4_1.AktifSayfa = 0;

            tmr_AcilisPingKontrol.Enabled = true;
        }

        private void Frm_Makine4_1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void tmr_AcilisPingKontrol_Tick(object sender, EventArgs e)
        {
            if (Helper.PingVarMi(sanver_AnaSayfa_Makine4_1.CPU_IP) && Helper.PingVarMi(sanver_AnaSayfa_Makine5.CPU_IP))
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
            sanver_AnaSayfa_Makine4_1.AktifSayfa = 0;
            sanver_AnaSayfa_Makine4_1.DilSecenek = 0;
            sanver_AnaSayfa_Makine4_1.ConnectOpen();
            sanver_AnaSayfa_Makine4_1.KontrolBasla();

            sanver_AnaSayfa_Makine5.AktifSayfa = 0;
            sanver_AnaSayfa_Makine5.DilSecenek = 0;
            sanver_AnaSayfa_Makine5.ConnectOpen();
            sanver_AnaSayfa_Makine5.KontrolBasla();

            //sanver_Kayit1.KontrolBasla();

            tmr_Basla.Enabled = true;
        }

        private void tmr_Basla_Tick(object sender, EventArgs e)
        {
            tmr_Basla.Enabled = false;

            sanver_AnaSayfa_Makine5.AktifSayfa = 1;

            sanver_AnaSayfa_Makine4_1.AktifSayfa = 1;
            
            Makine4_Bos_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 57);
            Makine5_Bos_Tagi = sanver_AnaSayfa_Makine5.TagListe.Find(item => item.ID == 1);

            ReceteID_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 3);
            IsEmriNo_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 4);
            FotografAdiTagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 5);
            IstasyonNo_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 11);

            HmiInfoTagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 82);

            IsEmri_Iste_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 45);
            IsEmri_Iste_Tagi.OkunanDegerUpdate += IsEmri_Iste_Tagi_OkunanDegerUpdate;

            Makine4_UretimHatDurumu_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 58);
            Makine4_DurusOn_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 61);

            Makine5_UretimHatDurumu_Tagi = sanver_AnaSayfa_Makine5.TagListe.Find(item => item.ID == 4);
            Makine5_DurusOn_Tagi = sanver_AnaSayfa_Makine5.TagListe.Find(item => item.ID == 2);

            BakimKontrolOn_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 62);

            UretimBasladi_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 63);
            UretimBasladi_Onay_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 64);
            UretimBitti_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 65);
            UretimBitti_Onay_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 66);

            GenelSonuc_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 100);
            HataKodu_Tagi = sanver_AnaSayfa_Makine4_1.TagListe.Find(item => item.ID == 101);

            FotografAdiTagi.OkunanDegerUpdate += FotografAdiTagi_OkunanDegerUpdate;

            UretimBasladi_Tagi.OkunanDegerUpdate += UretimBasladi_Tagi_OkunanDegerUpdate;
            UretimBitti_Tagi.OkunanDegerUpdate += UretimBitti_Tagi_OkunanDegerUpdate;

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
            Helper.TagDegerYaz(sanver_AnaSayfa_Makine4_1, 46, "0");

            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);

            Webservis.BakimKontrolDurumu(hatNo, dg_BakimKontrolleri);

            Webservis.KullaniciListesiDoldur(hatNo, dg_KullaniciListe);

            Webservis.UretimHatPlanGetir(hatNo, dg_HatPlan, lbl_WebservisMesaj);

            PLC_Haberlesme.BakimZamanlariGonder("BKMZMN", sanver_AnaSayfa_Makine4_1, 67, lbl_WebservisMesaj);

            PLC_Haberlesme.Makine4_KaliteKontrolBilgileriGonder(sanver_AnaSayfa_Makine4_1, sanver_AnaSayfa_Makine5, hatNo, lbl_WebservisMesaj);
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

            Helper.TagDegerYaz(sanver_AnaSayfa_Makine4_1, 150, dt.Hour.ToString());
            Helper.TagDegerYaz(sanver_AnaSayfa_Makine4_1, 151, dt.Minute.ToString());
            Helper.TagDegerYaz(sanver_AnaSayfa_Makine4_1, 152, dt.Second.ToString());

            if(BakimKontrolOn_Tagi.OkunanDeger.ToBool() == true)
            {
                if(dg_BakimKontrolleri.Visible == false)
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

            //try { dg_BakimKontrolleri.Visible = BakimKontrolOn_Tagi.OkunanDeger.ToBool(); }
            //catch { }

            DurusKontrol();

            KaliteKontrolZamanKontrolu();
        }

        public void KaliteKontrolZamanKontrolu()
        {
            try
            {
                DateTime SonKaliteKontrolZamani = Helper.TagDegerOku(sanver_AnaSayfa_Makine4_1, 49).ToDatetime();
                int KaliteKontrolPeriyodu_min = Helper.TagDegerOku(sanver_AnaSayfa_Makine4_1, 47).ToInt() * 60;
                int KaliteKontrolGerekli = Helper.TagDegerOku(sanver_AnaSayfa_Makine4_1, 46).ToInt();
                string DefaultUser = Helper.TagDegerOku(sanver_AnaSayfa_Makine4_1, 48);
            
                if(KaliteKontrolGerekli == 0)
                {
                    if (Makine4_UretimHatDurumu_Tagi.OkunanDeger.ToInt() != 6)
                    {
                        if (DateTime.Now.AddMinutes(-KaliteKontrolPeriyodu_min) > SonKaliteKontrolZamani)
                        {
                            Proxy.SetUretimHatStatuResponse hatDurumuSet;

                            hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.KALITE_DURUS, DefaultUser, "", lbl_WebservisMesaj);

                            if (hatDurumuSet.IsSucces)
                            {
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine5, Makine5_UretimHatDurumu_Tagi);

                                Helper.TagDegerYaz(sanver_AnaSayfa_Makine4_1, 46, "1");
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
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);

            Proxy.SetUretimHatStatuResponse hatDurumuSet;

            lbl_WebservisMesaj.Text = "";

            if (hatDurumuGet.IsSucces)
            {
                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.DURUS.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.BAKIM.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_DURUS.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt())
                {
                    hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.KALITE_START, txt_KaliteKullanici.Text, "", lbl_WebservisMesaj);

                    if (hatDurumuSet.IsSucces)
                    {
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine5, Makine5_UretimHatDurumu_Tagi);
           
                        txt_Kullanici.Text = "";

                        PLC_Haberlesme.Makine4_KaliteKontrolBilgileriGonder(sanver_AnaSayfa_Makine4_1, sanver_AnaSayfa_Makine5, hatNo, lbl_WebservisMesaj);

                        Helper.TagDegerYaz(sanver_AnaSayfa_Makine4_1, 153, "0");
                        Helper.TagDegerYaz(sanver_AnaSayfa_Makine5, 153, "0");

                        lbl_WebservisMesaj.Text = "KALITE START yapıldı";

                        txt_KaliteKullanici.Text = "";

                        tmr_KaliteKontrolYapildi.Enabled = true;

                        //Helper.TagDegerYaz(sanver_AnaSayfa_Makine4_1, 46, "0");

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
            Helper.TagDegerYaz(sanver_AnaSayfa_Makine4_1, 46, "0");
        }

        private void btn_KaliteDurus_Click(object sender, EventArgs e)
        {

        }

        #endregion "KALİTE ONAY - KALİTE DURUŞ"

        #region "HAT DURUM GÜNCELLE"

        private void btn_Off_Click(object sender, EventArgs e)
        {
            if (Makine4_Bos_Tagi.OkunanDeger.ToInt() == 1 && Makine5_Bos_Tagi.OkunanDeger.ToInt() == 1)
            {
                Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
                Proxy.SetUretimHatStatuResponse hatDurumuSet;

                //lbl_WebservisMesaj.Text = "";

                if (hatDurumuGet.IsSucces)
                {
                    if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.DURUS.ToInt())
                    {
                        hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.OFF, txt_Kullanici.Text, "", lbl_WebservisMesaj);

                        if (hatDurumuSet.IsSucces)
                        {
                            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
                            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine5, Makine5_UretimHatDurumu_Tagi);
                            txt_Kullanici.Text = "";

                            Webservis.TumKullanicilariCikart(hatNo, dg_KullaniciListe);

                            Makine4_DurusOn_Tagi.YazilanDeger = "0";
                            Makine5_DurusOn_Tagi.YazilanDeger = "0";
                        }
                        else
                        {
                            lbl_WebservisMesaj.Text = hatDurumuSet.Mesaj;
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
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
            Proxy.SetUretimHatStatuResponse hatDurumuSet;
            Proxy.AddCalisanResponse addCalisan;

            //lbl_WebservisMesaj.Text = "";

            if (hatDurumuGet.IsSucces)
            {
                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.OFF.ToInt())
                {
                    int KullaniciSayi = Webservis.KullaniciListesiDoldur(hatNo, dg_KullaniciListe);

                    if (KullaniciSayi == 0)
                    {
                        addCalisan = Webservis.KullaniciEkle(hatNo, txt_Kullanici.Text, dg_KullaniciListe);

                        if (addCalisan.IsSucces)
                        {
                            Webservis.KullaniciListesiDoldur(hatNo, dg_KullaniciListe);

                            hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.ON, txt_Kullanici.Text, "", lbl_WebservisMesaj);

                            if (hatDurumuSet.IsSucces)
                            {
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine5, Makine5_UretimHatDurumu_Tagi);
                                txt_Kullanici.Text = "";
                            }
                            else
                            {
                                lbl_WebservisMesaj.Text = hatDurumuSet.Mesaj;
                            }
                        }
                        else
                        {
                            if (addCalisan.Mesaj != null)
                                lbl_WebservisMesaj.Text = addCalisan.Mesaj;
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
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
            Proxy.SetUretimHatStatuResponse hatDurumuSet;

            lbl_WebservisMesaj.Text = "";

            if (hatDurumuGet.IsSucces)
            {
                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt())
                {
                    hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.BAKIM, txt_Kullanici.Text, "", lbl_WebservisMesaj);

                    if (hatDurumuSet.IsSucces)
                    {
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine5, Makine5_UretimHatDurumu_Tagi);
                        txt_Kullanici.Text = "";
                    }
                    else
                    {
                        lbl_WebservisMesaj.Text = hatDurumuSet.Mesaj;
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
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);

            lbl_WebservisMesaj.Text = "";

            if (hatDurumuGet.IsSucces)
            {
                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt())
                {
                    if (Webservis.PersonelHattaEkliMi(hatNo, txt_Kullanici.Text))
                    {
                        Makine4_DurusOn_Tagi.YazilanDeger = "1";
                        Makine5_DurusOn_Tagi.YazilanDeger = "1";
                    }
                        
                    else
                        lbl_WebservisMesaj.Text = "Personel Üretim Hattına Çalışan Olaran Henüz Eklenmemiş!";
                }
            }
        }

        public void DurusKontrol()
        {
            if (Makine4_DurusOn_Tagi.OkunanDeger.ToBool() == true)
            {
                if (Makine4_Bos_Tagi.OkunanDeger.ToInt() == 1 && Makine5_Bos_Tagi.OkunanDeger.ToInt() == 1)
                {
                    Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
                    Proxy.SetUretimHatStatuResponse hatDurumuSet;

                    lbl_WebservisMesaj.Text = "";

                    if (hatDurumuGet.IsSucces)
                    {
                        if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.START.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.KALITE_START.ToInt())
                        {
                            hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.DURUS, txt_Kullanici.Text, "", lbl_WebservisMesaj);

                            if (hatDurumuSet.IsSucces)
                            {
                                Makine4_DurusOn_Tagi.YazilanDeger = "0";
                                Makine5_DurusOn_Tagi.YazilanDeger = "0";

                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
                                Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine5, Makine5_UretimHatDurumu_Tagi);

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
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
            Proxy.SetUretimHatStatuResponse hatDurumuSet;

            lbl_WebservisMesaj.Text = "";

            if (hatDurumuGet.IsSucces)
            {
                if (hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.ON.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.DURUS.ToInt() || hatDurumuGet.UretimHatStatu == Proxy.UretimHatStatuler.BAKIM.ToInt())
                {
                    hatDurumuSet = Webservis.Set_HatDurumu(hatNo, Proxy.UretimHatStatuler.START, txt_Kullanici.Text, "", lbl_WebservisMesaj);

                    if (hatDurumuSet.IsSucces)
                    {
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
                        Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine5, Makine5_UretimHatDurumu_Tagi);
                        txt_Kullanici.Text = "";

                        //IsEmriIste();
                    }
                    else
                    {
                        lbl_WebservisMesaj.Text = hatDurumuSet.Mesaj;
                    }
                }
                else
                {
                    lbl_WebservisMesaj.Text = "Hat 'ON','DURUŞ' ya da 'BAKIM' modundan 'START' moduna alınabilir.";
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
            Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
            Proxy.AddCalisanResponse addCalisan;

            if (hatDurumuGet.UretimHatStatu.ToInt() >= 2)
            {
                if (txt_Kullanici.Text.Length > 2)
                {
                    lbl_WebservisMesaj.Text = "";

                    addCalisan = Webservis.KullaniciEkle(hatNo, txt_Kullanici.Text, dg_KullaniciListe);

                    if (!addCalisan.IsSucces)
                    {
                        if (addCalisan.Mesaj != null)
                            lbl_WebservisMesaj.Text = addCalisan.Mesaj;
                    }

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

                Proxy.CurrentUretimHatStatuResponse hatDurumuGet = Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa_Makine4_1, Makine4_UretimHatDurumu_Tagi);
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
                            {
                                if (removeCalisan.Mesaj != null)
                                    lbl_WebservisMesaj.Text = removeCalisan.Mesaj;
                            }
                        }
                        else
                        {
                            lbl_WebservisMesaj.Text = "Hatta Çalışan Personel Sayısı = 1, START modunda hattan tüm personeller çıkartılamaz!";
                        }
                    }
                }
                else
                {
                    if (hatDurumuGet.Mesaj != null)
                        lbl_WebservisMesaj.Text = hatDurumuGet.Mesaj;
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

            //Önce lokal veritabanından sorgula
            //Eğer lokal veritabanında iş yoksa webservisten al

            //Makinede Zaten Parça Varsa Parça İsteme, Yoksa Parça İsteğinde Bulun
            if (IstasyonNo_Tagi.OkunanDeger == "0" || ReceteID_Tagi.OkunanDeger == "0")
            {
                Model.Uretim_Hat2 urun = Veritabani.UretimEmir_TablodanOku_Hat2(Model.Steps.Step1, Veritabani.Step1_Istasyon.Sol);

                if (urun.ID != 0)
                {
                    //Urun bulundu plc'ye ürün bilgilerini ve reçeteyi gönder
                    PLC_Haberlesme.Makine4_Step1_VeriGonder(sanver_AnaSayfa_Makine4_1, urun);
                }
                else
                {
                    Proxy.UretimEmirResponse res = Webservis.Get_YeniUretimEmir(hatNo, lbl_WebservisMesaj);

                    if (res.IsSucces)
                    {
                        Veritabani.UretimEmir_TabloyaKaydet_Hat2(res, 1);

                        urun = Veritabani.UretimEmir_TablodanOku_Hat2(Model.Steps.Step1, Veritabani.Step1_Istasyon.Sol);

                        //Urun bulundu plc'ye ürün bilgilerini ve reçeteyi gönder
                        PLC_Haberlesme.Makine4_Step1_VeriGonder(sanver_AnaSayfa_Makine4_1, urun);
                    }
                    else
                    {
                        lbl_WebservisMesaj.Text = res.Mesaj;
                    }
                }
            }
        }

        #endregion "İŞ EMRİ İSTE"

        #region "BAKIM KONTROL"
        private void btn_BakimKontrolKaydet_Click(object sender, EventArgs e)
        {
            Proxy.SetBakimKontrolleriResponse res = Webservis.SetBakimKontrolDurumu(hatNo, dg_BakimKontrolleri, lbl_WebservisMesaj);

            if(res.IsSucces)
            {
                BakimKontrolOn_Tagi.YazilanDeger = "0";
            }
        }
        #endregion


    }
}
