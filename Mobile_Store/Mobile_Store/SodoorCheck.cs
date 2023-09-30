using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
  partial   class SodoorCheck
    {
      public SodoorCheck(string date_sodor, string date_check,string shomareh_Hesab,string Shomareh_check,long mablegh_check,string dar_vajhe,string tozih):this()
      {
          this.Date_Sodor = date_sodor;
          this.Date_check = date_check;
          this.Shomareh_Hesab = shomareh_Hesab;
          this.Shomareh_check = Shomareh_check;
          this.Mablegh_check = mablegh_check;
          this.Dar_vajhe = dar_vajhe;
          this.Tozih = tozih;
      }

      public SodoorCheck() { }
    }
}
