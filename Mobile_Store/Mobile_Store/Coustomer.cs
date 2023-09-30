using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
   partial  class Coustomer
    {
       public Coustomer(string name,string family,string tel,string mobile,string foroshghah,string adress,long bedehkar,long bestankar):this()
       {
           this.Name = name;
           this.Family = family;
           this.Tel = tel;
           this.Mobile = mobile;
           this.Foroshghah = foroshghah;
           this.Adress = adress;
           this.Bedehkar = bedehkar;
           this.Bestankar = bestankar;
       }
       public Coustomer() { }
       public override string ToString()
       {
           return Name +" " + Family ;
       }
    }
}
