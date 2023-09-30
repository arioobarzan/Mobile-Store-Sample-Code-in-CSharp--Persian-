using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
   partial  class ParDarMot
    {
       public ParDarMot(string date,string name_shakhs,long bedehkar,long bestankar,string tozih):this()
       {
           this.Date = date;
           this.Name_shakhs = name_shakhs;
           this.Bedehkar = bedehkar;
           this.Bestankar = bestankar;
           this.Tozih = tozih;
       }

       public ParDarMot() { }
    }
}
