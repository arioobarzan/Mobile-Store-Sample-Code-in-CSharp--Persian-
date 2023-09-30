using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
  partial   class Bardasht
    {
      public Bardasht(string shomare_hesab,string daryaftkonandeh,long mablagh,string date,string tozih,Bank bank):this()
      {
          this.Shomareh_Hesab = shomare_hesab;
          this.DaryaftKonandeh = daryaftkonandeh;
          this.Mablagh = mablagh;
          this.Date = date;
          this.Tozih = tozih;
          this.Bank = bank;
      }
      public Bardasht() { }
    }
}
