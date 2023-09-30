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
    public partial class Frm_delete_kharid : Form
    {
        ContextContainer context = new ContextContainer();
        List<Kharid> lst_kharid = new List<Kharid>();
        List<EsterdadKala> lst_esterdad = new List<EsterdadKala>();
        List<Anbar> lst_anbar = new List<Anbar>();
        long ghimat_vahed = 0, ghimat_forosh = 0;
        public Frm_delete_kharid()
        {
            InitializeComponent();
        }

        private void txt_factor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lab_name_foroshandeh.Text = "";
                int fact = Convert.ToInt32(txt_factor.Text);
                var q = context.Kharids.Where(k => k.Factor == fact);
                if (q.Count() > 0)
                {
                    foreach (var item in q)
                    {
                        lab_name_foroshandeh.Text = item.Name_Foroshandeh;
                    }

                }
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_del_factor_Click(object sender, EventArgs e)
        {
            //try
            //{
            int fact = Convert.ToInt32(txt_factor.Text); int check_count_kala = 0;
            var q_check_kharid = context.EsterdadKalas.Where(k => k.Factor == fact);

            if (q_check_kharid.Count() > 0) { MessageBox.Show(" امکان حذف فاکتور وجود ندارد ( فاکتور استرداد داشته )"); }
            else
            {
                if (txt_factor.Text == "0" || txt_factor.Text == "") { MessageBox.Show("اطلاعات را به طور صحیح وارد کنید"); }
                else
                {
                    var q_kharid = context.Kharids.Where(k => k.Factor == fact);

                    check_count_kala = Check_count_kala_factor(check_count_kala, q_kharid);
                    if (check_count_kala == 1) { MessageBox.Show("موجودی انبار کافی نمی باشد"); }
                    else
                    {
                        if (q_kharid.Count() > 0)
                        {
                            int result = Convert.ToInt32(MessageBox.Show("آیا  مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                            if (result == 6)
                            {

                                foreach (Kharid item in q_kharid) lst_kharid.Add(item);
                                foreach (var k in lst_kharid)
                                {
                                    context.Kharids.DeleteObject(k);
                                    context.SaveChanges();
                                    var q_anbar = context.Anbars.Where(a => a.Name_kala == k.Name_kala && a.Model_kala == k.Model_kala);
                                    ////////////////قیمت واحد  و  فروش  قبلی ///////////////////////////
                                    var q = context.Kharids.Where(kh => kh.Name_kala == k.Name_kala && kh.Model_kala == k.Model_kala);
                                    foreach (var item in q)
                                    {
                                        ghimat_vahed = item.Ghimat_vahed;
                                        ghimat_forosh = item.Ghimat_forosh;
                                    }
                                    ///////////////////////تعداد استردادی فاکتور خرید////////////////////////
                                    lst_esterdad.Clear();
                                    var q_esterdad = context.EsterdadKalas.Where(es => es.Factor == fact && es.Name_kala == k.Name_kala && es.Model_kala == k.Model_kala);
                                    foreach (EsterdadKala item in q_esterdad) lst_esterdad.Add(item);
                                    foreach (var item in lst_esterdad)
                                    {
                                        k.Count = k.Count - item.Count;
                                        context.EsterdadKalas.DeleteObject(item);
                                        context.SaveChanges();
                                    }
                                    //////////////////////////////ویرایش انبار/////////////////////////////////
                                    lst_anbar.Clear();
                                    foreach (Anbar item in q_anbar) lst_anbar.Add(item);
                                    foreach (var item in lst_anbar)
                                    {
                                        item.Count_kala = item.Count_kala - k.Count;
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


                            lst_kharid.Clear();
                            lst_esterdad.Clear();
                            lst_anbar.Clear();
                        }
                        else MessageBox.Show("همچنین فاکتوری وجود ندارد ");
                    }
                }
            }

            //}
            //catch (Exception x) { MessageBox.Show("خطا" + x); }
        }

        private int Check_count_kala_factor(int check_count_kala, IQueryable<Kharid> q_kharid)
        {
            var q_an = context.Anbars.Select(s => s);
            foreach (var k in q_kharid)
            {
                foreach (var a in q_an)
                {
                    if (k.Name_kala == a.Name_kala && k.Model_kala == a.Model_kala)
                    {
                        if (k.Count > a.Count_kala) check_count_kala = 1;
                    }
                }
            }
            return check_count_kala;
        }
    }
}
