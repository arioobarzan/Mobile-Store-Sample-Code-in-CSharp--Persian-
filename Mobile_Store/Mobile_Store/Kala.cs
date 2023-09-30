using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
   partial  class Kala
    {
       public Kala(string name,string model):this()
       {
           this.Name = name;
           this.Model = model;
       }

       public Kala() { }
       public override string ToString()
       {
           return Model  + "";
       }
    }
}
