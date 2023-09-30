using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
   partial  class Aghsat
    {
       public Aghsat(long  esterdad,int factor,int shomare_ghest,long  mablegh_ghest,string  date_pardakht,string  pass):this()
       {
           this.Eshterak = esterdad;
           this.Factor = factor;
           this.Shomare_ghest = shomare_ghest;
           this.Mablegh_ghest = mablegh_ghest;
           this.Date_pardakht = date_pardakht;
           this.Pass = pass;
       }
       public Aghsat() { }
    }
}
