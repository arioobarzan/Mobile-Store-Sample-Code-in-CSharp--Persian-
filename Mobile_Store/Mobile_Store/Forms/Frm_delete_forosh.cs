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
    public partial class Frm_delete_forosh : Form
    {
        ContextContainer context = new ContextContainer();
        List<Forosh> lst_forosh = new List<Forosh>();
        List<BarForosh> lst_bar_forosh = new List<BarForosh>();
        List<Anbar> lst_anbar = new List<Anbar>();
        long ghimat_vahed = 0, ghimat_forosh = 0;
        public Frm_delete_forosh()
        {
            InitializeComponent();
        }

        private void btn_del_factor_Click(object sender, EventArgs e)
        {
            try
            {
            int fact = Convert.ToInt32(txt_factor.Text);
            var q_check_kharid = context.BarForoshes.Where(k => k.Factor == fact);

            if (q_check_kharid.Count() > 0) { MessageBox.Show(" امکان حذف فاکتور وجود ندارد ( فاکتور برگشت داشته )"); }
            else
            {
                if (txt_factor.Text == "0" || txt_factor.Text == "") { MessageBox.Show("اطلاعات را به طور صحیح وارد کنید"); }
                else
                {
                    var q_forosh = context.Foroshes.Where(k => k.Factor == fact);


                        if (q_forosh.Count() > 0)
                        {
                            int result = Convert.ToInt32(MessageBox.Show("آیا  مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                            if (result == 6)
                            {

                                foreach (Forosh item in q_forosh) lst_forosh.Add(item);
                                foreach (var k in lst_forosh)
                                {
                                    context.Foroshes.DeleteObject(k);
                                    context.SaveChanges();
                                    var q_anbar = context.Anbars.Where(a => a.Name_kala == k.Name_kala && a.Model_kala == k.Model_kala);
                                    ////////////////قیمت واحد  و  فروش  قبلی ///////////////////////////
                                    var q = context.Kharids.Where(kh => kh.Name_kala == k.Name_kala && kh.Model_kala == k.Model_kala);
                                    foreach (var item in q)
                                    {
                                        ghimat_vahed = item.Ghimat_vahed;
                                        ghimat_forosh = item.Ghimat_forosh;
                                    }
                                    ///////////////////////تعداد برگشتی فاکتور فروش////////////////////////
                                    lst_bar_forosh.Clear();
                                    var q_bar_forosh = context.BarForoshes.Where(es => es.Factor == fact && es.Name_kala == k.Name_kala && es.Model_kala == k.Model_kala);
                                    foreach (BarForosh item in q_bar_forosh) lst_bar_forosh.Add(item);
                                    foreach (var item in lst_bar_forosh)
                                    {
                                        k.Count = k.Count - item.Count;
                                        context.BarForoshes.DeleteObject(item);
                                        context.SaveChanges();
                                    }
                                    //////////////////////////////ویرایش انبار/////////////////////////////////
                                    lst_anbar.Clear();
                                    foreach (Anbar item in q_anbar) lst_anbar.Add(item);
                                    foreach (var item in lst_anbar)
                                    {
                                        item.Count_kala = item.Count_kala + k.Count;
                                        item.Ghimat_forosh = ghimat_forosh;
                                        item.Ghimat_vahed = ghimat_vahed;
                                        context.Anbars.ApplyCurrentValues(item);
                                        context.SaveChanges();
                                    }
                                    ///////////////////////////////////////////////////////////////////////////
                                }
                            }
                            MessageBox.Show("فاکتور حذف شد ");
                            txt_factor.Text = "0";
                            lab_name_foroshandeh.Text = "";


                            lst_forosh.Clear();
                            lst_bar_forosh.Clear();
                            lst_anbar.Clear();
                        }
                        else MessageBox.Show("همچنین فاکتوری وجود ندارد ");
                    }
                
            }

            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }
        }



        private void txt_factor_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }
        }
    }
}
