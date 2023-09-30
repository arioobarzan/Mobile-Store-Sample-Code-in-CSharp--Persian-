using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
  partial   class Nkala
    {
      public Nkala(string name):this()
      {
          this.Name = name;
      }

      public Nkala() { }
      public override string ToString()
      {
          return Name +"";
      }
    }
}
