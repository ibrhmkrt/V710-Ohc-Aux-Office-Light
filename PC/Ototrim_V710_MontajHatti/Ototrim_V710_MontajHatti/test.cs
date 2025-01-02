using Ototrim_V710_MontajHatti.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ototrim_V710_MontajHatti
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {

            Webservis.BakimKontrolDurumu(3, dg_BakimKontrolleri);

           //var x = Webservis.EnSonKaliteOnay(3).EnSonOnay.ToString();


           // PLC_Haberlesme.BakimZamanlariGonder("BKMZMN", new Sanver_FrameWorkV6.Sanver_AnaSayfa(), 67, label1);


           // int kkzmn = Webservis.KaliteKontrolZamanGetir(label1, "KKZMN");

           // string kkusr = Webservis.KaliteKontrolDefaultUserGetir(label1, "OTOKLTUSR");

           // //Proxy.GetParametreResponse res1 = Webservis.ParametreOku("KKZMN");

           // //Proxy.GetParametreResponse res2 = Webservis.ParametreOku("OTOKLTUSR");

           // Webservis.BakimKontrolDurumu(3);

           // GetBakimKontrolleriResponse res = Webservis.BakimKontrolDurumu(3);

           // Webservis.BakimKontrolList(res, dg_BakimKontrolleri);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Webservis.SetBakimKontrolDurumu(3, dg_BakimKontrolleri,label1);
        }
    }
}
