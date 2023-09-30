using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
  partial   class Anbar
    {
      public Anbar(string name_kala,string  model_kala,int count_kala,long ghimat_vahed,long ghimat_forosh):this()
      {
          this.Name_kala = name_kala;
          this.Model_kala = model_kala;
          this.Count_kala = count_kala;
          this.Ghimat_vahed = ghimat_vahed;
          this.Ghimat_forosh = ghimat_forosh;

      }
      public Anbar() { }
    }
}
