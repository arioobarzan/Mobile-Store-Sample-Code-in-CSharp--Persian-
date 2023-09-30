using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
    partial class ForoshAghsat 
    {
        public ForoshAghsat(int factor,long  eshterak, string name_kala, string model_kala, int count, long ghimat_vahed, string date_forosh):this()
        {
            this.Factor = factor;
            this.Eshterak = eshterak;
            this.Name_kala = name_kala;
            this.Model_kala = model_kala;
            this.Count = count;
            this.Ghimat_vahed = ghimat_vahed;
            this.Date_Forosh = date_forosh;
        }
        public ForoshAghsat() { }
    }
}
