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
    public partial class Frm_delete_Esterdad : Form
    {
        ContextContainer contex = new ContextContainer();
        List<EsterdadKala> lst_Esterdad = new List<EsterdadKala>();
        List<Anbar> lst_anbar = new List<Anbar>();
       
        public Frm_delete_Esterdad()
        {
            InitializeComponent();
        }



        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_factor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lab_name_foroshandeh.Text = "";
                int fact = Convert.ToInt32(txt_factor.Text);
                var q = contex.EsterdadKalas .Where(k => k.Factor == fact);
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

        private void btn_del_factor_Click(object sender, EventArgs e)
        {
            try
            {
                int fact = Convert.ToInt32(txt_factor.Text);
                if (txt_factor.Text == "0" || txt_factor.Text == "") { MessageBox.Show("اطلاعات را به طور صحیح وارد کنید"); }
                else
                {
                    var q = contex.EsterdadKalas .Where(k => k.Factor == fact);
                    if (q.Count() > 0)
                    {
                        int result = Convert.ToInt32(MessageBox.Show("آیا  مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                        if (result == 6)
                        {

                            foreach (EsterdadKala  item in q) lst_Esterdad.Add(item);
                            foreach (var E in lst_Esterdad)
                            {
                                contex.EsterdadKalas.DeleteObject(E);
                                contex.SaveChanges();
                                var q_anbar = contex.Anbars.Where(a => a.Name_kala == E.Name_kala && a.Model_kala == E.Model_kala);
                                //////////////////////////////ویرایش انبار/////////////////////////////////
                                lst_anbar.Clear();
                                foreach (Anbar item in q_anbar) lst_anbar.Add(item);
                                foreach (var item in lst_anbar)
                                {
                                    item.Count_kala = item.Count_kala + E.Count;
                                    contex.Anbars.ApplyCurrentValues(item);
                                    contex.SaveChanges();
                                }
                                ///////////////////////////////////////////////////////////////////////////
                            }
                            MessageBox.Show("فاکتور استرداد حذف شد ");
                            txt_factor.Text = "0";
                            lab_name_foroshandeh.Text = "";
                            lst_Esterdad.Clear();
                            lst_anbar.Clear();
                        }
                    }
                    else MessageBox.Show("همچنین فاکتوری وجود ندارد ");
                }
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }
        }

     
    }
}
