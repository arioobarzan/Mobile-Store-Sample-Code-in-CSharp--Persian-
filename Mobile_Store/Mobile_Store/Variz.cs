using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
   partial  class Variz
    {
       public Variz(string shomareh_hesab,string pardakhtkonandeh,long mablagh,int shomareh_fish,string date,string tozih,Bank bank):this()
       {
           this.Shomareh_Hesab = shomareh_hesab;
           this.PardakhtKonandeh = pardakhtkonandeh;
           this.Mablagh = mablagh;
           this.Shomareh_Fish = shomareh_fish;
           this.Date = date;
           this.Tozih = tozih;
           this.Bank = bank;
       }

       public Variz() { }
    }
}
