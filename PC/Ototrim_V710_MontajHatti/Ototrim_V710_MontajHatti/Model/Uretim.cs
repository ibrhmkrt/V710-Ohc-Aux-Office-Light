using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ototrim_V710_MontajHatti.Model
{
    public enum Steps
    {
        Step1 = 1,

        Step2 = 2,

        Step3 = 3,
    }

    public class Uretim_Hat3
    {
        public long ID { get; set; }
        public string UretimEmirNo { get; set; }
        public string Referans_Kodu { get; set; }
        public string Referans_Adi { get; set; }
        public string Referans_MusteriKodu { get; set; }
        public string Referans_Barkod { get; set; }
        public int ToplamUretilecekMiktar { get; set; }
        public int Step1_MakineNo { get; set; }
        public int Step1_IstasyonNo { get; set; }
        public int Step1_SikiciProgramNo { get; set; }
        public int Step1_RedKasaKapasite { get; set; }
        public int Step1_UretimSuresi { get; set; }
        public DateTime Step1_BaslamaTarih { get; set; }
        public DateTime Step1_BitisTarih { get; set; }
        public bool Step1_Basladi { get; set; }
        public bool Step1_Tamamlandi { get; set; }
        public int Step2_MakineNo { get; set; }
        public int Step2_IstasyonNo { get; set; }
        public int Step2_RedKasaKapasite { get; set; }
        public double Step2_Lux1_Max { get; set; }
        public double Step2_Lux1_Min { get; set; }
        public double Step2_Lux2_Max { get; set; }
        public double Step2_Lux2_Min { get; set; }
        public double Step2_Lux3_Max { get; set; }
        public double Step2_Lux3_Min { get; set; }
        public double Step2_Lux4_Max { get; set; }
        public double Step2_Lux4_Min { get; set; }
        public double Step2_Lux5_Max { get; set; }
        public double Step2_Lux5_Min { get; set; }
        public double Step2_Lux6_Max { get; set; }
        public double Step2_Lux6_Min { get; set; }
        public int Step2_UretimSuresi { get; set; }
        public DateTime Step2_BaslamaTarih { get; set; }
        public DateTime Step2_BitisTarih { get; set; }
        public bool Step2_Basladi { get; set; }
        public bool Step2_Tamamlandi { get; set; }

        public Uretim_Hat3(long ID_, string UretimEmirNo_, string Referans_Kodu_, string Referans_Adi_, string Referans_MusteriKodu_, string Referans_Barkod_, int ToplamUretilecekMiktar_, int Step1_MakineNo_, int Step1_IstasyonNo_, int Step1_SikiciProgramNo_, int Step1_RedKasaKapasite_, int Step1_UretimSuresi_, DateTime Step1_BaslamaTarih_, DateTime Step1_BitisTarih_, bool Step1_Basladi_, bool Step1_Tamamlandi_, int Step2_MakineNo_, int Step2_IstasyonNo_, int Step2_RedKasaKapasite_, double Step2_Lux1_Max_, double Step2_Lux1_Min_, double Step2_Lux2_Max_, double Step2_Lux2_Min_, double Step2_Lux3_Max_, double Step2_Lux3_Min_, double Step2_Lux4_Max_, double Step2_Lux4_Min_, double Step2_Lux5_Max_, double Step2_Lux5_Min_, double Step2_Lux6_Max_, double Step2_Lux6_Min_, int Step2_UretimSuresi_, DateTime Step2_BaslamaTarih_, DateTime Step2_BitisTarih_, bool Step2_Basladi_, bool Step2_Tamamlandi_)
        {
            this.ID = ID_;
            this.UretimEmirNo = UretimEmirNo_;
            this.Referans_Kodu = Referans_Kodu_;
            this.Referans_Adi = Referans_Adi_;
            this.Referans_MusteriKodu = Referans_MusteriKodu_;
            this.Referans_Barkod = Referans_Barkod_;
            this.ToplamUretilecekMiktar = ToplamUretilecekMiktar_;
            this.Step1_MakineNo = Step1_MakineNo_;
            this.Step1_IstasyonNo = Step1_IstasyonNo_;
            this.Step1_SikiciProgramNo = Step1_SikiciProgramNo_;
            this.Step1_RedKasaKapasite = Step1_RedKasaKapasite_;
            this.Step1_UretimSuresi = Step1_UretimSuresi_;
            this.Step1_BaslamaTarih = Step1_BaslamaTarih_;
            this.Step1_BitisTarih = Step1_BitisTarih_;
            this.Step1_Basladi = Step1_Basladi_;
            this.Step1_Tamamlandi = Step1_Tamamlandi_;
            this.Step2_MakineNo = Step2_MakineNo_;
            this.Step2_IstasyonNo = Step2_IstasyonNo_;
            this.Step2_RedKasaKapasite = Step2_RedKasaKapasite_;
            this.Step2_Lux1_Max = Step2_Lux1_Max_;
            this.Step2_Lux1_Min = Step2_Lux1_Min_;
            this.Step2_Lux2_Max = Step2_Lux2_Max_;
            this.Step2_Lux2_Min = Step2_Lux2_Min_;
            this.Step2_Lux3_Max = Step2_Lux3_Max_;
            this.Step2_Lux3_Min = Step2_Lux3_Min_;
            this.Step2_Lux4_Max = Step2_Lux4_Max_;
            this.Step2_Lux4_Min = Step2_Lux4_Min_;
            this.Step2_Lux5_Max = Step2_Lux5_Max_;
            this.Step2_Lux5_Min = Step2_Lux5_Min_;
            this.Step2_Lux6_Max = Step2_Lux6_Max_;
            this.Step2_Lux6_Min = Step2_Lux6_Min_;
            this.Step2_UretimSuresi = Step2_UretimSuresi_;
            this.Step2_BaslamaTarih = Step2_BaslamaTarih_;
            this.Step2_BitisTarih = Step2_BitisTarih_;
            this.Step2_Basladi = Step2_Basladi_;
            this.Step2_Tamamlandi = Step2_Tamamlandi_;
        }

        public Uretim_Hat3()
        {
            this.ID = 0;
            this.UretimEmirNo = "";
            this.Referans_Kodu = "";
            this.Referans_Adi = "";
            this.Referans_MusteriKodu = "";
            this.Referans_Barkod = "";
            this.ToplamUretilecekMiktar = 0;
            this.Step1_MakineNo = 0;
            this.Step1_IstasyonNo = 0;
            this.Step1_SikiciProgramNo = 0;
            this.Step1_RedKasaKapasite = 0;
            this.Step1_UretimSuresi = 0;
            this.Step1_BaslamaTarih = new DateTime();
            this.Step1_BitisTarih = new DateTime();
            this.Step1_Basladi = false;
            this.Step1_Tamamlandi = false;
            this.Step2_MakineNo = 0;
            this.Step2_IstasyonNo = 0;
            this.Step2_RedKasaKapasite = 0;
            this.Step2_Lux1_Max = 0;
            this.Step2_Lux1_Min = 0;
            this.Step2_Lux2_Max = 0;
            this.Step2_Lux2_Min = 0;
            this.Step2_Lux3_Max = 0;
            this.Step2_Lux3_Min = 0;
            this.Step2_Lux4_Max = 0;
            this.Step2_Lux4_Min = 0;
            this.Step2_Lux5_Max = 0;
            this.Step2_Lux5_Min = 0;
            this.Step2_Lux6_Max = 0;
            this.Step2_Lux6_Min = 0;
            this.Step1_UretimSuresi = 0;
            this.Step2_BaslamaTarih = new DateTime();
            this.Step2_BitisTarih = new DateTime();
            this.Step2_Basladi = false;
            this.Step2_Tamamlandi = false;
        }
    }

    public class Uretim_Hat2
    {
        public long ID { get; set; }
        public string UretimEmirNo { get; set; }
        public string Referans_Kodu { get; set; }
        public string Referans_Adi { get; set; }
        public string Referans_MusteriKodu { get; set; }
        public string Referans_Barkod { get; set; }
        public int ToplamUretilecekMiktar { get; set; }
        public int Step1_MakineNo { get; set; }
        public int Step1_IstasyonNo { get; set; }
        public int Step1_RedKasaKapasite { get; set; }
        public int Step1_YaglamaSure { get; set; }
        public int Step1_TipSecim { get; set; }
        public int Step1_UretimSuresi { get; set; }
        public DateTime Step1_BaslamaTarih { get; set; }
        public DateTime Step1_BitisTarih { get; set; }
        public bool Step1_Basladi { get; set; }
        public bool Step1_Tamamlandi { get; set; }
        public int Step2_MakineNo { get; set; }
        public int Step2_IstasyonNo { get; set; }
        public int Step2_SikiciProgramNo { get; set; }
        public int Step2_RedKasaKapasite { get; set; }
        public int Step2_UretimSuresi { get; set; }
        public DateTime Step2_BaslamaTarih { get; set; }
        public DateTime Step2_BitisTarih { get; set; }
        public bool Step2_Basladi { get; set; }
        public bool Step2_Tamamlandi { get; set; }
        public int Step3_MakineNo { get; set; }
        public int Step3_IstasyonNo { get; set; }
        public int Step3_RedKasaKapasite { get; set; }
        public int Step3_KameraProgNo_Lamba1 { get; set; }
        public int Step3_KameraProgNo_Lamba2 { get; set; }
        public int Step3_UretimSuresi { get; set; }
        public int Step3_LambaAkimDegeriMin { get; set; }
        public int Step3_LambaAkimDegeriMax { get; set; }
        public DateTime Step3_BaslamaTarih { get; set; }
        public DateTime Step3_BitisTarih { get; set; }
        public bool Step3_Basladi { get; set; }
        public bool Step3_Tamamlandi { get; set; }

        public int SOS_Secim { get; set; }

        public int SOS_BarkodAktif { get; set; }
        public string SOS_Barkod { get; set; }

        public Uretim_Hat2(long ID_, string UretimEmirNo_, string Referans_Kodu_, string Referans_Adi_, string Referans_MusteriKodu_, string Referans_Barkod_, int ToplamUretilecekMiktar_, int Step1_MakineNo_, int Step1_IstasyonNo_, int Step1_RedKasaKapasite_, int Step1_YaglamaSure_, int Step1_TipSecim_, int Step1_UretimSuresi_, DateTime Step1_BaslamaTarih_, DateTime Step1_BitisTarih_, bool Step1_Basladi_, bool Step1_Tamamlandi_, int Step2_MakineNo_, int Step2_IstasyonNo_, int Step2_SikiciProgramNo_, int Step2_RedKasaKapasite_, int Step2_UretimSuresi_, DateTime Step2_BaslamaTarih_, DateTime Step2_BitisTarih_, bool Step2_Basladi_, bool Step2_Tamamlandi_, int Step3_MakineNo_, int Step3_IstasyonNo_, int Step3_RedKasaKapasite_, int Step3_KameraProgNo_Lamba1_, int Step3_KameraProgNo_Lamba2_, int Step3_UretimSuresi_,int Step3_LambaAkimDegeriMin_,int Step3_LambaAkimDegeriMax_, DateTime Step3_BaslamaTarih_, DateTime Step3_BitisTarih_, bool Step3_Basladi_, bool Step3_Tamamlandi_,int SOS_Secim_, int SOS_BarkodAktif_,string SOS_Barkod_)
        {
            this.ID = ID_;
            this.UretimEmirNo = UretimEmirNo_;
            this.Referans_Kodu = Referans_Kodu_;
            this.Referans_Adi = Referans_Adi_;
            this.Referans_MusteriKodu = Referans_MusteriKodu_;
            this.Referans_Barkod = Referans_Barkod_;
            this.ToplamUretilecekMiktar = ToplamUretilecekMiktar_;
            this.Step1_MakineNo = Step1_MakineNo_;
            this.Step1_IstasyonNo = Step1_IstasyonNo_;
            this.Step1_RedKasaKapasite = Step1_RedKasaKapasite_;
            this.Step1_YaglamaSure = Step1_YaglamaSure_;
            this.Step1_TipSecim = Step1_TipSecim_;
            this.Step1_UretimSuresi = Step1_UretimSuresi_;
            this.Step1_BaslamaTarih = Step1_BaslamaTarih_;
            this.Step1_BitisTarih = Step1_BitisTarih_;
            this.Step1_Basladi = Step1_Basladi_;
            this.Step1_Tamamlandi = Step1_Tamamlandi_;
            this.Step2_MakineNo = Step2_MakineNo_;
            this.Step2_IstasyonNo = Step2_IstasyonNo_;
            this.Step2_SikiciProgramNo = Step2_SikiciProgramNo_;
            this.Step2_RedKasaKapasite = Step2_RedKasaKapasite_;
            this.Step2_UretimSuresi = Step2_UretimSuresi_;
            this.Step2_BaslamaTarih = Step2_BaslamaTarih_;
            this.Step2_BitisTarih = Step2_BitisTarih_;
            this.Step2_Basladi = Step2_Basladi_;
            this.Step2_Tamamlandi = Step2_Tamamlandi_;
            this.Step3_MakineNo = Step3_MakineNo_;
            this.Step3_IstasyonNo = Step3_IstasyonNo_;
            this.Step3_RedKasaKapasite = Step3_RedKasaKapasite_;
            this.Step3_KameraProgNo_Lamba1 = Step3_KameraProgNo_Lamba1_;
            this.Step3_KameraProgNo_Lamba2 = Step3_KameraProgNo_Lamba2_;
            this.Step3_UretimSuresi = Step3_UretimSuresi_;
            this.Step3_LambaAkimDegeriMin = Step3_LambaAkimDegeriMin_;
            this.Step3_LambaAkimDegeriMax = Step3_LambaAkimDegeriMax_;
            this.Step3_BaslamaTarih = Step3_BaslamaTarih_;
            this.Step3_BitisTarih = Step3_BitisTarih_;
            this.Step3_Basladi = Step3_Basladi_;
            this.Step3_Tamamlandi = Step3_Tamamlandi_;
            this.SOS_Secim = SOS_Secim_;
            this.SOS_BarkodAktif = SOS_BarkodAktif_;
            this.SOS_Barkod = SOS_Barkod_;
        }

        public Uretim_Hat2()
        {
            this.ID = 0;
            this.UretimEmirNo = "";
            this.Referans_Kodu = "";
            this.Referans_Adi = "";
            this.Referans_MusteriKodu = "";
            this.Referans_Barkod = "";
            this.ToplamUretilecekMiktar = 0;
            this.Step1_MakineNo = 0;
            this.Step1_IstasyonNo = 0;
            this.Step1_RedKasaKapasite = 0;
            this.Step1_YaglamaSure = 0;
            this.Step1_TipSecim = 0;
            this.Step1_UretimSuresi = 0;
            this.Step1_BaslamaTarih = new DateTime();
            this.Step1_BitisTarih = new DateTime();
            this.Step1_Basladi = false;
            this.Step1_Tamamlandi = false;
            this.Step2_MakineNo = 0;
            this.Step2_IstasyonNo = 0;
            this.Step2_SikiciProgramNo = 0;
            this.Step2_RedKasaKapasite = 0;
            this.Step2_UretimSuresi = 0;
            this.Step2_BaslamaTarih = new DateTime(); ;
            this.Step2_BitisTarih = new DateTime(); ;
            this.Step2_Basladi = false;
            this.Step2_Tamamlandi = false;
            this.Step3_MakineNo = 0;
            this.Step3_IstasyonNo = 0;
            this.Step3_RedKasaKapasite = 0;
            this.Step3_KameraProgNo_Lamba1 = 0;
            this.Step3_KameraProgNo_Lamba2 = 0;
            this.Step3_UretimSuresi = 0;
            this.Step3_LambaAkimDegeriMin = 0;
            this.Step3_LambaAkimDegeriMax = 0;
            this.Step3_BaslamaTarih = new DateTime(); ;
            this.Step3_BitisTarih = new DateTime(); ;
            this.Step3_Basladi = false;
            this.Step3_Tamamlandi = false;

            this.SOS_Secim = 0;
            this.SOS_BarkodAktif = 0;
            this.SOS_Barkod = "";
        }
    }
}
