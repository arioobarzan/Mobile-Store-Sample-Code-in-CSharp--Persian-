using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
   partial  class Bank
    {
       public Bank(string name,string shohbeh,string shomareh_hesab,long mojodi,string saheb_hesab):this()
       {
           this.Name = name;
           this.Shohbeh = shohbeh;
           this.Shomareh_Hesab = shomareh_hesab;
           this.Mojodi = mojodi;
           this.Saheb_Hesab = saheb_hesab;
       }

       public Bank() { }
    }
}
