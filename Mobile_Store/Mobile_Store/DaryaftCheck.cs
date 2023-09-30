using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
   partial  class DaryaftCheck
    {
       public DaryaftCheck(string date_sodoor,string  date_check,string name_moshtari,string shomareh_hesab,string shomareh_check,long mablegh_check,string tozih):this()
       {
           this.Date_sodoor = date_sodoor;
           this.Date_check = date_check;
           this.Name_Moshtari = name_moshtari;
           this.Shomareh_Hesab = shomareh_hesab;
           this.Shomareh_check = shomareh_check;
           this.Mablegh_check = mablegh_check;
           this.Tozih = tozih;
       }

       public DaryaftCheck() { }
    }
}
