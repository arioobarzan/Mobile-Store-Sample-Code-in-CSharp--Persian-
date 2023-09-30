using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mobile_Store.Forms
{
    public partial class Frm_delete_bar_forosh : Form
    {
        ContextContainer context = new ContextContainer();
        List<BarForosh> lst_bar_forosh = new List<BarForosh>();
        List<Anbar> lst_anbar = new List<Anbar>();
        public Frm_delete_bar_forosh()
        {
            InitializeComponent();
        }

        private void btn_del_factor_Click(object sender, EventArgs e)
        {
            try
            {
                int fact = Convert.ToInt32(txt_factor.Text);
                if (txt_factor.Text == "0" || txt_factor.Text == "") { MessageBox.Show("اطلاعات را به طور صحیح وارد کنید"); }
                else
                {
                    var q = context.BarForoshes.Where(k => k.Factor == fact);
                    if (q.Count() > 0)
                    {
                        int result = Convert.ToInt32(MessageBox.Show("آیا  مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                        if (result == 6)
                        {

                            foreach (BarForosh item in q) lst_bar_forosh.Add(item);
                            foreach (var bar in lst_bar_forosh)
                            {
                                context.BarForoshes.DeleteObject(bar);
                                context.SaveChanges();
                                var q_anbar = context.Anbars.Where(a => a.Name_kala == bar.Name_kala && a.Model_kala == bar.Model_kala);
                                //////////////////////////////ویرایش انبار/////////////////////////////////
                                lst_anbar.Clear();
                                foreach (Anbar item in q_anbar) lst_anbar.Add(item);
                                foreach (var item in lst_anbar)
                                {
                                    item.Count_kala = item.Count_kala - bar.Count;
                                    context.Anbars.ApplyCurrentValues(item);
                                    context.SaveChanges();
                                }
                                ///////////////////////////////////////////////////////////////////////////
                            }
                            MessageBox.Show("فاکتور برگشت حذف شد ");
                            txt_factor.Text = "0";
                            lab_name_foroshandeh.Text = "";
                            lst_bar_forosh.Clear();
                            lst_anbar.Clear();
                        }
                    }
                    else MessageBox.Show("همچنین فاکتوری وجود ندارد ");
                }
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }
        }

        private void txt_factor_TextChanged(object sender, EventArgs e)
        {
            //try
          //  {
                lab_name_foroshandeh.Text = "";
                int fact = Convert.ToInt32(txt_factor.Text);
                var q = context.Foroshes.Where(k => k.Factor == fact).OfType<ForoshNaghdi>();
                var q2 = context.Foroshes.Where(k => k.Factor == fact).OfType<ForoshAghsat>();
                if (q.Count() > 0)
                {
                    foreach (var item in q)
                    {
                        lab_name_foroshandeh.Text = item.Name_Moshtari;
                    }

                }
                if (q2.Count() > 0)
                {
                    foreach (var item in q2)
                    {
                        lab_name_foroshandeh.Text = item.Eshterak.ToString();
                    }

                }
           // }
           // catch (Exception x) { MessageBox.Show("خطا" + x); }


        }

    }
}
