using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ototrim_V710_MontajHatti
{
    public static class Fotograf
    {
        public static string FtpYolu_Ist70_Kamera = @"D:\FTP\Ist70Kamera";

        public static void FtpKlasorleriTemizle()
        {
            KalanResimleriSilme(FtpYolu_Ist70_Kamera);
        }

        public static void KalanResimleriSilme(string KlasorYolu)
        {
            System.IO.DirectoryInfo DI = new DirectoryInfo(KlasorYolu);
            System.IO.FileInfo[] FI = DI.GetFiles("*", SearchOption.TopDirectoryOnly);

            if (FI.Length > 0)
            {
                for (int i = 0; i < FI.Length; i++)
                {
                    File.Delete(KlasorYolu + "\\" + FI[i].Name);
                }
            }
        }

        public static Color SonucRenk(string DosyaYolu)
        {
            if (Path.GetFileName(DosyaYolu).Contains("OK"))
                return Color.Lime;
            else
                return Color.Red;
        }

        public static string ResimIcinKlasorOlusturma(string YeniKlasorYolu)
        {
            DateTime AnlikZaman = DateTime.Now;

            string KlasorYolu = "";

            try
            {
                KlasorYolu = string.Format(@"{0}\{1}\{2}\{3}\"
               , YeniKlasorYolu
               , AnlikZaman.Year.ToString()
               , AnlikZaman.Month.ToString("00")
               , AnlikZaman.Day.ToString("00")
              );
            }
            catch { }

            DirectoryInfo DI = new DirectoryInfo(KlasorYolu);
            if (!DI.Exists)
            {
                Directory.CreateDirectory(KlasorYolu);
            }

            return KlasorYolu;
        }

        public static string ResimAdiOlusturma()
        {
            DateTime AnlikZaman = DateTime.Now;

            string ResimAdi = "";

            try
            {
                ResimAdi = string.Format(@"{0}{1}{2}.jpg"
               , AnlikZaman.Hour.ToString("00")
               , AnlikZaman.Minute.ToString("00")
               , AnlikZaman.Second.ToString("00")
              );
            }
            catch { }

            return ResimAdi;
        }

        public static string DeleteInvalidFileNameChars(string fileName)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, '_');
            }

            return fileName;
        }

        public static Image ResizeImage(string DosyaYolu, Size size)
        {
            return (Image)(new Bitmap(Image.FromFile(DosyaYolu), size));
        }

        public static bool AgYolunaErisimVarMi(string KlasorYolu)
        {
            DirectoryInfo DI = new DirectoryInfo(KlasorYolu);
            if (DI.Exists)
                return true;
            else
                return false;
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs,int saklanacakGunSayisi)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                //if (file.CreationTime < DateTime.Now.AddDays(-saklanacakGunSayisi))
                //{
                //    // Copy the file.
                //    file.CopyTo(temppath, true);
                //    file.Delete();
                //}

                //if (file.CreationTime < DateTime.Now.AddDays(-saklanacakGunSayisi))
                //{
                //    // Copy the file.
                //    file.CopyTo(temppath, true);
                //    file.Delete();
                //}

                // Copy the file.
                file.CopyTo(temppath, true);

                if (file.CreationTime < DateTime.Now.AddDays(-saklanacakGunSayisi))
                {
                    //delete file
                    file.Delete();
                }
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs, saklanacakGunSayisi);

                    if (subdir.GetFiles().Length == 0)
                        subdir.Delete();
                }
            }
        }
    }
}
