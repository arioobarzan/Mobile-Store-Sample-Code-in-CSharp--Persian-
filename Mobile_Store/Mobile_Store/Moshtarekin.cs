using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
  partial   class Moshtarekin
    {
      public Moshtarekin(long eshterak, string name, string family, string tel, string mobile, string shomareh_hesab, string shomareh_check, string adress_kar, string adress)
      {
          this.Eshterak = eshterak;
          this.Name = name;
          this.Family = family;
          this.Tel = tel;
          this.Mobile = mobile;
          this.Shomareh_Hesab = shomareh_hesab;
          this.Shomareh_check = shomareh_check;
          this.Adress_kar = adress_kar;
          this.Adress = adress;
      }

      public Moshtarekin() { }
      public override string ToString()
      {
          return Name +" "+Family;
      }
    }
}
