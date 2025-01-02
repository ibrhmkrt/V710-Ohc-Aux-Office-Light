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
    public partial class _02_FotografGoster : Form
    {

        string DosyaYolu = "";

        public _02_FotografGoster()
        {
            InitializeComponent();
        }

        public _02_FotografGoster(string _dosyaYolu)
        {
            DosyaYolu = _dosyaYolu;

            InitializeComponent();
        }

        private void _02_FotografGoster_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.BackgroundImage = Image.FromFile(DosyaYolu);
            }
            catch
            {
                pictureBox1.BackgroundImage = null;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
