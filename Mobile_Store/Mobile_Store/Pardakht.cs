using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
  partial   class Pardakht
    {
      public Pardakht(int factor,long mablegh_naghdy,string date_pardakht_naghdi,string date_sodoor,string date_check,string shomareh_hesab,string shomareh_check,long mablegh_check,string dar_vajhe,string type_pardakht):this()
      {
          this.Factor = factor;
          this.mablegh_naghdi  = mablegh_naghdy;
          this.Date_Pardaght_naghdi = date_pardakht_naghdi;
          this.Date_sodoor = date_sodoor;
          this.Date_check = date_check;
          this.Shomareh_Hesab = shomareh_hesab;
          this.Shomareh_check = shomareh_check;
          this.Mablegh_check = mablegh_check;
          this.Dar_vajhe = dar_vajhe;
          this.Type_pardakht = type_pardakht;
          
      }

      public Pardakht() { }
    }
}
