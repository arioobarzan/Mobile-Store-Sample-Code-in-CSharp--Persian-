using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile_Store
{
    partial class Kharid
    {
        public Kharid(int factor, string name_foroshandeh, string name_kala, string model_kala, int count_kala, long ghimat_vahed, long ghimat_forosh, string date_Kharid, string serial):this()
        {
            this.Factor = factor;
            this.Name_Foroshandeh = name_foroshandeh;
            this.Name_kala = name_kala;
            this.Model_kala = model_kala;
            this.Count = count_kala;
            this.Ghimat_vahed = ghimat_vahed;
            this.Ghimat_forosh = ghimat_forosh;
            this.Date_kharid = date_Kharid;
            this.Serial = serial;
        }

        public Kharid() { }
        //public override string ToString()
        //{
        //    return Model_kala +"";
        //}
    }
}
