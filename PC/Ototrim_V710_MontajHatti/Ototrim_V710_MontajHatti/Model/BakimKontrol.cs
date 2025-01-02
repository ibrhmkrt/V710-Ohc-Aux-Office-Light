using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ototrim_V710_MontajHatti.Model
{
    public class Sanver_BakimKontrol
    {
        public int BakimKontrolKey { get; set; }
        public int SiraNo { get; set; }
        public string KontrolAciklama { get; set; }
        public bool Evet { get; set; }
        public bool Hayir { get; set; }

        public Sanver_BakimKontrol()
        {
            BakimKontrolKey = 0;
            SiraNo = 0;
            KontrolAciklama = "";
            Evet = false;
            Hayir = false;
        }
    }
}
