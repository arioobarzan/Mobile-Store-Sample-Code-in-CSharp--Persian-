using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
   partial  class Daryaft
    {
       public Daryaft(int factor,long mablegh_naghdi,string date_daryaft_naghdi,long mablegh_daftari,string date_daftari,string name_shakhs,string date_sodor,string date_check,string shomareh_hesab,string shomareh_check,long mablegh_check,string saheb_hesab,string pass_check,string type_daryaft):this()
       {
           this.Factor = factor;
           this.Mablegh_naghdi = mablegh_naghdi ;
           this.Date_Daryaft_naghdi = date_daryaft_naghdi;
           this.Mablegh_Dafteri = mablegh_daftari;
           this.Date_Dafteri = date_daftari;
           this.Name_shakhs = name_shakhs;
           this.Date_sodoor = date_sodor;
           this.Date_check = date_check;
           this.Shomareh_Hesab = shomareh_hesab;
           this.Shomareh_check = shomareh_check;
           this.Mablegh_check = mablegh_check;
           this.Saheb_Hesab = saheb_hesab;
           this.Pas_check = pass_check;
           this.Type_daryaft = type_daryaft;
       }
       public Daryaft() { }
    }
}
