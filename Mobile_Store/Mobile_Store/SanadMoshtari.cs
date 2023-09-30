using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
    partial class SanadMoshtari
    {
        public SanadMoshtari(int shomareh_sanad, string name_moshtari, long bedehkar, long bestankar, string date, string tozih):this()
        {
            this.Shomareh_sanad = shomareh_sanad;
            this.Name_Moshtari = name_moshtari;
            this.Bedehkar = bedehkar;
            this.Bestankar = bestankar;
            this.Date = date;
            this.Tozih = tozih;
        }

        public SanadMoshtari() { }
    }
}
