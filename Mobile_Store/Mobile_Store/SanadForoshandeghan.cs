using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
   partial  class SanadForoshandeghan
    {
       public SanadForoshandeghan(int shomareh_sanad,string name_foroshandeh,long bedehkar,long bestankar,string date,string tozih):this()
       {
           this.Shomareh_sanad = shomareh_sanad;
           this.Name_Foroshandeh = name_foroshandeh;
           this.Bedehkar = bedehkar;
           this.Bestankar = bestankar;
           this.Date = date;
           this.Tozih = tozih;
       }

       public SanadForoshandeghan() { }
    }
}
