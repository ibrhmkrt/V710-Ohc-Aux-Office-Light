using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanver_FrameWorkV6;

namespace Ototrim_V710_MontajHatti
{
    public static class Veritabani
    {

        public enum Step1_Istasyon
        {
            Yok = 0,

            Sol = 1,

            Sag = 2,
        }

        public static string con_str = "";

        public static void ConStringOlustur()
        {
            try
            {
                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\" + "HatBaglanti.udl"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (sr.EndOfStream)
                            con_str = line;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("UDL Dosya Hatası");
                Console.WriteLine(e.Message);
            }
        }

        public static void UretimEmir_TabloyaKaydet_Hat3(Proxy.UretimEmirResponse uretimEmir)
        {
            if (uretimEmir.IsSucces)
            {
                if (con_str == "")
                    ConStringOlustur();

                string sorgu = "";

                string LocalDataYolu = @"D:\SANVER\URETIMEMIR";

                string DosyaAdi = "s" + uretimEmir.UretimEmirNo + ".txt";

                string DosyaYolu = LocalDataYolu + string.Format(@"\{0}\{1}\{2}.csv", DateTime.Now.Year, DateTime.Now.Month.ToString("00"), DosyaAdi);

                string DosyaKlasoru = LocalDataYolu + string.Format(@"\{0}\{1}", DateTime.Now.Year, DateTime.Now.Month.ToString("00"));

                Helper.DosyayaYaz(DosyaYolu, SerializeObject(uretimEmir), DosyaKlasoru, "");

                sorgu = string.Format("INSERT INTO [dbo].[Uretim]([UretimEmirNo],[Referans_Kodu],[Referans_Adi],[Referans_MusteriKodu],[Referans_Barkod],[ToplamUretilecekMiktar],[Step1_MakineNo],[Step1_IstasyonNo],[Step1_SikiciProgramNo],[Step1_RedKasaKapasite],[Step1_UretimSuresi],[Step1_BaslamaTarih],[Step1_BitisTarih],[Step1_Basladi],[Step1_Tamamlandi],[Step2_MakineNo],[Step2_IstasyonNo],[Step2_RedKasaKapasite],[Step2_Lux1_Max],[Step2_Lux1_Min],[Step2_Lux2_Max],[Step2_Lux2_Min],[Step2_Lux3_Max],[Step2_Lux3_Min],[Step2_Lux4_Max],[Step2_Lux4_Min],[Step2_Lux5_Max],[Step2_Lux5_Min],[Step2_Lux6_Max],[Step2_Lux6_Min],[Step2_UretimSuresi],[Step2_BaslamaTarih],[Step2_BitisTarih],[Step2_Basladi],[Step2_Tamamlandi],HataKodu)VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},{9},{10},'{11}','{12}',{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},'{31}','{32}',{33},{34},{35})"
                    , uretimEmir.UretimEmirNo.ToString()
                    , uretimEmir.UretimEmir_Referans.Kodu
                    , uretimEmir.UretimEmir_Referans.Adi
                    , uretimEmir.UretimEmir_Referans.MusteriKodu
                    , uretimEmir.UretimEmir_Referans.BarKod
                    , uretimEmir.ToplamUretilecekMiktar
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 127).ToDouble().ToInt() //[Step1_MakineNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 128).ToDouble().ToInt() //[Step1_IstasyonNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 123).ToDouble().ToInt() //[Step1_SikiciProgramNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 124).ToDouble().ToInt() //[Step1_RedKasaKapasite]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 152).ToDouble().ToInt() //[Step1_UretimSuresi]
                    , DateTime.Now.ToSqlDate() //[Step1_BaslamaTarih]
                    , DateTime.Now.ToSqlDate() //[Step1_BitisTarih]
                    , 0 //[Step1_Basladi]
                    , 0 //[Step1_Tamamlandi]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 129).ToDouble().ToInt() //[Step2_MakineNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 130).ToDouble().ToInt() //[Step2_IstasyonNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 126).ToDouble().ToInt() //[Step2_RedKasaKapasite]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 143).ToDouble() //[Step2_Lux1_Max]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 144).ToDouble() //[Step2_Lux1_Min]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 139).ToDouble() //[Step2_Lux2_Max]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 140).ToDouble() //[Step2_Lux2_Min]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 147).ToDouble() //[Step2_Lux3_Max]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 148).ToDouble() //[Step2_Lux3_Min]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 137).ToDouble() //[Step2_Lux4_Max]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 145).ToDouble() //[Step2_Lux4_Min]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 141).ToDouble() //[Step2_Lux5_Max]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 138).ToDouble() //[Step2_Lux5_Min]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 142).ToDouble() //[Step2_Lux6_Max]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 146).ToDouble() //[Step2_Lux6_Min]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 153).ToDouble().ToInt() //[Step2_UretimSuresi]
                    , DateTime.Now.ToSqlDate() //[Step2_BaslamaTarih]
                    , DateTime.Now.ToSqlDate() //[Step2_BitisTarih]
                    , 0 //[Step2_Basladi]
                    , 0 //[Step2_Tamamlandi]
                    , 0
                    );

                OleDbConnection conn = new OleDbConnection(con_str);
                conn.Open();
                OleDbCommand command = new OleDbCommand(sorgu, conn);

                command.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static Model.Uretim_Hat3 UretimEmir_TablodanOku_Hat3(Model.Steps stepNo,int istasyonNo)
        {
            Model.Uretim_Hat3 siradakiUrun = new Model.Uretim_Hat3();

            if (con_str == "")
                ConStringOlustur();

            string sorgu = "";

            if (stepNo == Model.Steps.Step1)
            {
                sorgu = string.Format("Select TOP 1 * from Uretim Where Step{0}_Tamamlandi = 0 AND HataKodu = 0 order by ID asc", stepNo.ToInt());
            }
            else
            {
                sorgu = string.Format("Select TOP 1 * from Uretim Where Step{0}_Tamamlandi = 0 AND Step{1}_Tamamlandi = 1 AND HataKodu = 0 AND Step1_IstasyonNo = {2} order by ID asc", stepNo.ToInt(), stepNo.ToInt() - 1, istasyonNo);
            }

           // string sorgu = string.Format("Select TOP 1 * from Uretim Where Step{0}_Tamamlandi = 0 order by ID asc", stepNo.ToInt());

            OleDbConnection conn = new OleDbConnection(con_str);
            conn.Open();
            OleDbCommand command = new OleDbCommand(sorgu, conn);
            OleDbDataReader or = command.ExecuteReader();

            if (or.Read())
            {
                siradakiUrun.ID = or["ID"].ToInt();
                siradakiUrun.UretimEmirNo = or["UretimEmirNo"].ToString();
                siradakiUrun.Referans_Kodu = or["Referans_Kodu"].ToString();
                siradakiUrun.Referans_Adi = or["Referans_Adi"].ToString();
                siradakiUrun.Referans_MusteriKodu = or["Referans_MusteriKodu"].ToString();
                siradakiUrun.Referans_Barkod = or["Referans_Barkod"].ToString();

                siradakiUrun.ToplamUretilecekMiktar = or["ToplamUretilecekMiktar"].ToInt();
                siradakiUrun.Step1_MakineNo = or["Step1_MakineNo"].ToInt();
                siradakiUrun.Step1_IstasyonNo = or["Step1_IstasyonNo"].ToInt();
                siradakiUrun.Step1_SikiciProgramNo = or["Step1_SikiciProgramNo"].ToInt();
                siradakiUrun.Step1_RedKasaKapasite = or["Step1_RedKasaKapasite"].ToInt();

                siradakiUrun.Step1_UretimSuresi = or["Step1_UretimSuresi"].ToInt();
                siradakiUrun.Step1_BaslamaTarih = or["Step1_BaslamaTarih"].ToDatetime();
                siradakiUrun.Step1_BitisTarih = or["Step1_BitisTarih"].ToDatetime();
                siradakiUrun.Step1_Basladi = or["Step1_Basladi"].ToBool();
                siradakiUrun.Step1_Tamamlandi = or["Step1_Tamamlandi"].ToBool();

                siradakiUrun.Step2_MakineNo = or["Step2_MakineNo"].ToInt();
                siradakiUrun.Step2_IstasyonNo = or["Step2_IstasyonNo"].ToInt();
                siradakiUrun.Step2_RedKasaKapasite = or["Step2_RedKasaKapasite"].ToInt();
                siradakiUrun.Step2_Lux1_Max = or["Step2_Lux1_Max"].ToDouble();
                siradakiUrun.Step2_Lux1_Min = or["Step2_Lux1_Min"].ToDouble();
                siradakiUrun.Step2_Lux2_Max = or["Step2_Lux2_Max"].ToDouble();
                siradakiUrun.Step2_Lux2_Min = or["Step2_Lux2_Min"].ToDouble();
                siradakiUrun.Step2_Lux3_Max = or["Step2_Lux3_Max"].ToDouble();
                siradakiUrun.Step2_Lux3_Min = or["Step2_Lux3_Min"].ToDouble();
                siradakiUrun.Step2_Lux4_Max = or["Step2_Lux4_Max"].ToDouble();
                siradakiUrun.Step2_Lux4_Min = or["Step2_Lux4_Min"].ToDouble();
                siradakiUrun.Step2_Lux5_Max = or["Step2_Lux5_Max"].ToDouble();
                siradakiUrun.Step2_Lux5_Min = or["Step2_Lux5_Min"].ToDouble();
                siradakiUrun.Step2_Lux6_Max = or["Step2_Lux6_Max"].ToDouble();
                siradakiUrun.Step2_Lux6_Min = or["Step2_Lux6_Min"].ToDouble();

                siradakiUrun.Step2_UretimSuresi = or["Step2_UretimSuresi"].ToInt();
                siradakiUrun.Step2_BaslamaTarih = or["Step2_BaslamaTarih"].ToDatetime();
                siradakiUrun.Step2_BitisTarih = or["Step2_BitisTarih"].ToDatetime();
                siradakiUrun.Step2_Basladi = or["Step2_Basladi"].ToBool();
                siradakiUrun.Step2_Tamamlandi = or["Step2_Tamamlandi"].ToBool();
            }

            or.Close();
            conn.Close();

            or = null;
            command = null;
            conn = null;

            return siradakiUrun;
        }

        public static void UretimEmir_TabloyaKaydet_Hat2(Proxy.UretimEmirResponse uretimEmir, int baslananIstasyon)
        {
            if (uretimEmir.IsSucces)
            {
                if (con_str == "")
                    ConStringOlustur();

                string sorgu = "";

                string LocalDataYolu = @"D:\SANVER\URETIMEMIR";

                string DosyaAdi = "s" + uretimEmir.UretimEmirNo + ".txt";

                string DosyaYolu = LocalDataYolu + string.Format(@"\{0}\{1}\{2}.csv", DateTime.Now.Year, DateTime.Now.Month.ToString("00"), DosyaAdi);

                string DosyaKlasoru = LocalDataYolu + string.Format(@"\{0}\{1}", DateTime.Now.Year, DateTime.Now.Month.ToString("00"));

                Helper.DosyayaYaz(DosyaYolu, SerializeObject(uretimEmir), DosyaKlasoru, "");

               
                //string s = "s" + uretimEmir.UretimEmirNo + ".txt";

                //Helper.DosyayaYaz(s, SerializeObject(uretimEmir), @"D:\SANVER\URETIMEMIR\", "Sanver Data");

                sorgu = string.Format("INSERT INTO [dbo].[Uretim]([UretimEmirNo],[Referans_Kodu],[Referans_Adi],[Referans_MusteriKodu],[Referans_Barkod],[ToplamUretilecekMiktar],[Step1_MakineNo],[Step1_IstasyonNo],[Step1_RedKasaKapasite],[Step1_YaglamaSure],[Step1_TipSecim],[Step1_UretimSuresi],[Step1_BaslamaTarih],[Step1_BitisTarih],[Step1_Basladi],[Step1_Tamamlandi],[Step2_MakineNo],[Step2_IstasyonNo],[Step2_SikiciProgramNo],[Step2_RedKasaKapasite],[Step2_UretimSuresi],[Step2_BaslamaTarih],[Step2_BitisTarih],[Step2_Basladi],[Step2_Tamamlandi],[Step3_MakineNo],[Step3_IstasyonNo],[Step3_RedKasaKapasite],[Step3_KameraProgNo_Lamba1],[Step3_KameraProgNo_Lamba2],[Step3_UretimSuresi],[Step3_BaslamaTarih],[Step3_BitisTarih],[Step3_Basladi],[Step3_Tamamlandi],[Step3_LambaAkimDegeriMin],[Step3_LambaAkimDegeriMax],[Step1_BaslananIstasyon],HataKodu,SOS_Secim,SOS_BarkodAktif,SOS_Barkod)VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},{9},{10},{11},'{12}','{13}',{14},{15},{16},{17},{18},{19},{20},'{21}','{22}',{23},{24},{25},{26},{27},{28},{29},{30},'{31}','{32}',{33},{34},{35},{36},{37},{38},{39},{40},'{41}')"
                    , uretimEmir.UretimEmirNo.ToString()
                    , uretimEmir.UretimEmir_Referans.Kodu
                    , uretimEmir.UretimEmir_Referans.Adi
                    , uretimEmir.UretimEmir_Referans.MusteriKodu
                    , uretimEmir.UretimEmir_Referans.BarKod
                    , uretimEmir.ToplamUretilecekMiktar
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 90).ToDouble().ToInt() //[Step1_MakineNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 91).ToDouble().ToInt() //[Step1_IstasyonNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 87).ToDouble().ToInt() //[Step1_RedKasaKapasite]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 108).ToDouble().ToInt() //[Step1_YaglamaSure]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 107).ToDouble().ToInt() //[Step1_TipSecim]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 156).ToDouble().ToInt() //[Step1_UretimSuresi]
                    , DateTime.Now.ToSqlDate() //[Step1_BaslamaTarih]
                    , DateTime.Now.ToSqlDate() //[Step1_BitisTarih]
                    , 0 //[Step1_Basladi]
                    , 0 //[Step1_Tamamlandi]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 92).ToDouble().ToInt() //[Step2_MakineNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 93).ToDouble().ToInt() //[Step2_IstasyonNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 88).ToDouble().ToInt() //[Step2_SikiciProgramNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 89).ToDouble().ToInt() //[Step2_RedKasaKapasite]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 155).ToDouble().ToInt() //[Step2_UretimSuresi]
                    , DateTime.Now.ToSqlDate() //[Step2_BaslamaTarih]
                    , DateTime.Now.ToSqlDate() //[Step2_BitisTarih]
                    , 0 //[Step2_Basladi]
                    , 0 //[Step2_Tamamlandi]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 105).ToDouble().ToInt() //[Step3_MakineNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 106).ToDouble().ToInt() //[Step3_IstasyonNo]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 104).ToDouble().ToInt() //[Step3_RedKasaKapasite]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 121).ToDouble().ToInt() //[Step3_KameraProgNo_Lamba1]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 122).ToDouble().ToInt() //[Step3_KameraProgNo_Lamba2]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 154).ToDouble().ToInt() //[Step3_UretimSuresi]
                    , DateTime.Now.ToSqlDate() //[Step3_BaslamaTarih]
                    , DateTime.Now.ToSqlDate() //[Step3_BitisTarih]
                    , 0 //[Step3_Basladi]
                    , 0 //[Step3_Tamamlandi]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 399).ToDouble().ToInt() //[Step3_LambaAkimDegeriMin]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 398).ToDouble().ToInt() //[Step3_LambaAkimDegeriMax]
                    , baslananIstasyon
                    , "0"
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 107).ToDouble().ToInt() //[SOS_Secim]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 569).ToDouble().ToInt() //[SOS_BarkodAktif]
                    , UretimEmir_FonksiyonDegerGetir(uretimEmir, 570).ToString() //[SOS_Barkod]
                    );

                OleDbConnection conn = new OleDbConnection(con_str);
                conn.Open();
                OleDbCommand command = new OleDbCommand(sorgu, conn);

                command.ExecuteNonQuery();

                conn.Close();
            }
        }

        private static string SerializeObject(object toSerialize)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(toSerialize.GetType());

            using (System.IO.StringWriter textWriter = new System.IO.StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }


        public static Model.Uretim_Hat2 UretimEmir_TablodanOku_Hat2(Model.Steps stepNo,Step1_Istasyon stepStation)
        {
            Model.Uretim_Hat2 siradakiUrun = new Model.Uretim_Hat2();

            if (con_str == "")
                ConStringOlustur();

            string sorgu = "";


            if(stepNo == Model.Steps.Step1)
            {
                // Makine girişte istasyonunda her 2 istasyonda aktif olduğunda veritabanında parça kayıtlı olduğu için aynı ÜretimEmirNo yu almaya çalışıyor. Böylelikle sadece giren istasyondan parçanın çıkması sağlanıyor
                if (stepStation == Step1_Istasyon.Yok)
                    sorgu = string.Format("Select TOP 1 * from Uretim Where Step{0}_Tamamlandi = 0 AND HataKodu = 0 order by ID asc", stepNo.ToInt());
                else
                    sorgu = string.Format("Select TOP 1 * from Uretim Where Step{0}_Tamamlandi = 0 AND [Step1_BaslananIstasyon] = {1} AND HataKodu = 0 order by ID asc", stepNo.ToInt(), stepStation.ToInt());
            }
            else
            {
                sorgu = string.Format("Select TOP 1 * from Uretim Where Step{0}_Tamamlandi = 0 AND Step{1}_Tamamlandi = 1 AND HataKodu = 0 order by ID asc", stepNo.ToInt(), stepNo.ToInt() -1);
            }
           
            OleDbConnection conn = new OleDbConnection(con_str);
            conn.Open();
            OleDbCommand command = new OleDbCommand(sorgu, conn);
            OleDbDataReader or = command.ExecuteReader();

            if (or.Read())
            {
                siradakiUrun.ID = or["ID"].ToInt();

                siradakiUrun.UretimEmirNo = or["UretimEmirNo"].ToString();
                siradakiUrun.Referans_Kodu = or["Referans_Kodu"].ToString();
                siradakiUrun.Referans_Adi = or["Referans_Adi"].ToString();
                siradakiUrun.Referans_MusteriKodu = or["Referans_MusteriKodu"].ToString();
                siradakiUrun.Referans_Barkod = or["Referans_Barkod"].ToString();
                siradakiUrun.ToplamUretilecekMiktar = or["ToplamUretilecekMiktar"].ToInt();

                siradakiUrun.Step1_MakineNo = or["Step1_MakineNo"].ToInt();
                siradakiUrun.Step1_IstasyonNo = or["Step1_IstasyonNo"].ToInt();
                siradakiUrun.Step1_RedKasaKapasite = or["Step1_RedKasaKapasite"].ToInt();

                siradakiUrun.Step1_UretimSuresi = or["Step1_UretimSuresi"].ToInt();
                siradakiUrun.Step1_BaslamaTarih = or["Step1_BaslamaTarih"].ToDatetime();
                siradakiUrun.Step1_BitisTarih = or["Step1_BitisTarih"].ToDatetime();
                siradakiUrun.Step1_Basladi = or["Step1_Basladi"].ToBool();
                siradakiUrun.Step1_Tamamlandi = or["Step1_Tamamlandi"].ToBool();
                siradakiUrun.Step1_YaglamaSure = or["Step1_YaglamaSure"].ToInt();

                siradakiUrun.Step2_MakineNo = or["Step2_MakineNo"].ToInt();
                siradakiUrun.Step2_IstasyonNo = or["Step2_IstasyonNo"].ToInt();
                siradakiUrun.Step2_RedKasaKapasite = or["Step2_RedKasaKapasite"].ToInt();
                siradakiUrun.Step2_SikiciProgramNo = or["Step2_SikiciProgramNo"].ToInt();

                siradakiUrun.Step2_UretimSuresi = or["Step2_UretimSuresi"].ToInt();
                siradakiUrun.Step2_BaslamaTarih = or["Step2_BaslamaTarih"].ToDatetime();
                siradakiUrun.Step2_BitisTarih = or["Step2_BitisTarih"].ToDatetime();
                siradakiUrun.Step2_Basladi = or["Step2_Basladi"].ToBool();
                siradakiUrun.Step2_Tamamlandi = or["Step2_Tamamlandi"].ToBool();

                siradakiUrun.Step3_MakineNo = or["Step2_MakineNo"].ToInt();
                siradakiUrun.Step3_IstasyonNo = or["Step2_IstasyonNo"].ToInt();
                siradakiUrun.Step3_RedKasaKapasite = or["Step2_RedKasaKapasite"].ToInt();

                siradakiUrun.Step3_KameraProgNo_Lamba1 = or["Step3_KameraProgNo_Lamba1"].ToDouble().ToInt();
                siradakiUrun.Step3_KameraProgNo_Lamba2 = or["Step3_KameraProgNo_Lamba2"].ToDouble().ToInt();

                siradakiUrun.Step3_LambaAkimDegeriMin = or["Step3_LambaAkimDegeriMin"].ToDouble().ToInt();
                siradakiUrun.Step3_LambaAkimDegeriMax = or["Step3_LambaAkimDegeriMax"].ToDouble().ToInt();

                siradakiUrun.Step3_UretimSuresi = or["Step3_UretimSuresi"].ToInt();
                siradakiUrun.Step3_BaslamaTarih = or["Step3_BaslamaTarih"].ToDatetime();
                siradakiUrun.Step3_BitisTarih = or["Step3_BitisTarih"].ToDatetime();
                siradakiUrun.Step3_Basladi = or["Step3_Basladi"].ToBool();
                siradakiUrun.Step3_Tamamlandi = or["Step3_Tamamlandi"].ToBool();

                siradakiUrun.SOS_Secim = or["SOS_Secim"].ToInt();

                siradakiUrun.SOS_BarkodAktif = or["SOS_BarkodAktif"].ToInt();
                siradakiUrun.SOS_Barkod = or["SOS_Barkod"].ToString();
            }

            or.Close();
            conn.Close();

            or = null;
            command = null;
            conn = null;

            return siradakiUrun;
        }

        public static void UretimEmir_TabloGuncelle_UretimBasladi(int ID, Model.Steps step)
        {
            if (ID != 0)
            {
                if (con_str == "")
                    ConStringOlustur();

                string sorgu = "";

                sorgu = string.Format("UPDATE [dbo].[Uretim] SET [Step{0}_BaslamaTarih] = '{1}' ,[Step{0}_Basladi] = {2}  WHERE ID = {3}"
                    , step.ToInt()
                    , DateTime.Now.ToSqlDate()
                    , 1
                    , ID
                    );

                OleDbConnection conn = new OleDbConnection(con_str);
                conn.Open();
                OleDbCommand command = new OleDbCommand(sorgu, conn);

                command.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static void UretimEmir_TabloGuncelle_UretimBitti(int ID, Model.Steps step,int HataKodu)
        {
            if (ID != 0)
            {
                if (con_str == "")
                    ConStringOlustur();

                string sorgu = "";

                sorgu = string.Format("UPDATE [dbo].[Uretim] SET [Step{0}_BitisTarih] = '{1}' ,[Step{0}_Tamamlandi] = {2},[HataKodu] = {4}  WHERE ID = {3}"
                    , step.ToInt()
                    , DateTime.Now.ToSqlDate()
                    , 1
                    , ID
                    , HataKodu
                    );

                OleDbConnection conn = new OleDbConnection(con_str);
                conn.Open();
                OleDbCommand command = new OleDbCommand(sorgu, conn);

                command.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static string UretimEmir_FonksiyonDegerGetir(Proxy.UretimEmirResponse uretimEmir, int fonksiyonKodu)
        {
            try
            {
                return Array.Find(uretimEmir.Fonksiyonlar, x => x.PlcTag == fonksiyonKodu.ToString()).Deger.ToString();
            }
            catch
            {
                return "0";
            }
        }
    }
}
