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
    public partial class Frm_Makine5 : Form
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

        public Frm_Makine5()
        {
            InitializeComponent();
        }

        private void Frm_Makine5_Load(object sender, EventArgs e)
        {
            try { this.Location = Screen.AllScreens[0].WorkingArea.Location; }
            catch { }

            sanver_AnaSayfa1.AktifSayfa = 0;

  
            tmr_AcilisPingKontrol.Enabled = true;
        }

        private void Frm_Makine5_FormClosing(object sender, FormClosingEventArgs e)
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

            BaslangicKontrolleri();

            Webservis.Get_HatDurumu(hatNo, lbl_WebservisMesaj, sanver_AnaSayfa1, UretimHatDurumu_Tagi);

            UretimBasladi_Kontrol();
            UretimBitti_Kontrol();

            PLC_Haberlesme.BakimZamanlariGonder("BKMZMN", sanver_AnaSayfa1, 67, lbl_WebservisMesaj);

            try { Controller.FotografGoruntule.FotografiPaneldeGoster(FotografAdiTagi.OkunanDeger.TrimStart().TrimEnd(), lbl_FotografAdi, pnl_UrunFotograf); }
            catch { }


            tmr_Saat.Enabled = true;

            CheckForIllegalCrossThreadCalls = false;

            //KALİTE DURUŞU
            //KKZMN - OTOKLTUSR

        }

        public void BaslangicKontrolleri()
        {
            //Webservis.BakimKontrolDurumu(hatNo, dg_BakimKontrolleri);

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
                Proxy.Set_UretimEmirResponse uretimEmir_Set = Webservis.Set_UretimEmir(IsEmriNo_Tagi.OkunanDeger, Model.Steps.Step3.ToInt(), Proxy.UretimEmirIslemTipleri.BASLA, false, false, 0, lbl_WebservisMesaj);

                if (uretimEmir_Set.IsSucces)
                {
                    Veritabani.UretimEmir_TabloGuncelle_UretimBasladi(ReceteID_Tagi.OkunanDeger.ToInt(), Model.Steps.Step3);

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

                Proxy.Set_UretimEmirResponse uretimEmir_Set = Webservis.Set_UretimEmir(IsEmriNo_Tagi.OkunanDeger, Model.Steps.Step3.ToInt(), Proxy.UretimEmirIslemTipleri.BITIR, true, hataliMi, HataKodu_Tagi.OkunanDeger.ToInt(), lbl_WebservisMesaj);

                if (uretimEmir_Set.IsSucces)
                {
                    Veritabani.UretimEmir_TabloGuncelle_UretimBitti(ReceteID_Tagi.OkunanDeger.ToInt(), Model.Steps.Step3, HataKodu_Tagi.OkunanDeger.ToInt());

                    Proxy.GetUretimEmirSonucBekleyenlerResponse get_UretimEmirSonuclar = Webservis.Get_UretimEmirSonucBekleyenler(lbl_WebservisMesaj, 23);

                    if (get_UretimEmirSonuclar.IsSucces)
                    {
                        int Kontrol1_Sonuc = Helper.TagDegerOku(sanver_AnaSayfa1, 102).ToInt();
                        int Kontrol2_Sonuc = Helper.TagDegerOku(sanver_AnaSayfa1, 103).ToInt();
                        int Kontrol3_Sonuc = Helper.TagDegerOku(sanver_AnaSayfa1, 104).ToInt();
                        int Kontrol4_Sonuc = Helper.TagDegerOku(sanver_AnaSayfa1, 105).ToInt();

                        int Akim1_Sonuc = Helper.TagDegerOku(sanver_AnaSayfa1, 106).ToInt();
                        int Akim2_Sonuc = Helper.TagDegerOku(sanver_AnaSayfa1, 108).ToInt();
                        int Akim1_Deger = Helper.TagDegerOku(sanver_AnaSayfa1, 107).ToInt();
                        int Akim2_Deger = Helper.TagDegerOku(sanver_AnaSayfa1, 109).ToInt();

                        for (int i = 0; i < get_UretimEmirSonuclar.UretimSonuclari.Length; i++)
                        {
                            if (get_UretimEmirSonuclar.UretimSonuclari[i].Tag == "9")
                                get_UretimEmirSonuclar.UretimSonuclari[i].Sonuc = Kontrol1_Sonuc.ToString();

                            if (get_UretimEmirSonuclar.UretimSonuclari[i].Tag == "10")
                                get_UretimEmirSonuclar.UretimSonuclari[i].Sonuc = Kontrol2_Sonuc.ToString();

                            if (get_UretimEmirSonuclar.UretimSonuclari[i].Tag == "11")
                                get_UretimEmirSonuclar.UretimSonuclari[i].Sonuc = Kontrol3_Sonuc.ToString();

                            if (get_UretimEmirSonuclar.UretimSonuclari[i].Tag == "12")
                                get_UretimEmirSonuclar.UretimSonuclari[i].Sonuc = Kontrol4_Sonuc.ToString();

                            if (get_UretimEmirSonuclar.UretimSonuclari[i].Tag == "13")
                                get_UretimEmirSonuclar.UretimSonuclari[i].Sonuc = string.Format("{0};{1}", Akim1_Sonuc, Akim1_Deger);

                            if (get_UretimEmirSonuclar.UretimSonuclari[i].Tag == "15")
                                get_UretimEmirSonuclar.UretimSonuclari[i].Sonuc = string.Format("{0};{1}", Akim2_Sonuc, Akim2_Deger);
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
            lbl_Baslik.Text = string.Format("                            OTOTRİM - OHC FINAL MAKİNESİ - {0}", DateTime.Now.ToString());

            this.Text = lbl_Baslik.Text.TrimStart();

            DateTime dt = DateTime.Now;

            txt_SOS_OkunanBarkod.Focus();

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
                Model.Uretim_Hat2 urun = Veritabani.UretimEmir_TablodanOku_Hat2(Model.Steps.Step3,0);

                if (urun.ID != 0)
                {
                    //Urun bulundu plc'ye ürün bilgilerini ve reçeteyi gönder
                    PLC_Haberlesme.Makine5_Step3_VeriGonder(sanver_AnaSayfa1, urun);
                }
                else
                {
                    lbl_WebservisMesaj.Text = "Sırada bekleyen parça yok!";
                }
            }
        }

        #endregion "İŞ EMRİ İSTE"

        

        private void txt_SOS_OkunanBarkod_TextChanged(object sender, EventArgs e)
        {
            if(txt_SOS_OkunanBarkod.Text.Length > 5)
            {
                if (tmr_SOS_OkunanBarkod.Enabled == false)
                    tmr_SOS_OkunanBarkod.Enabled = true;
            }
        }

        private void tmr_SOS_OkunanBarkod_Tick(object sender, EventArgs e)
        {
            tmr_SOS_OkunanBarkod.Enabled = false;
            Helper.TagDegerYaz(sanver_AnaSayfa1, 85, txt_SOS_OkunanBarkod.Text);

            txt_SOS_OkunanBarkod.Text = "";
        }
    }
}
