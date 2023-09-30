using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Mobile_Store.Forms
{
    public partial class Frm_forosh_aghsat : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year, tedad, number, count_kala, id; long ghimat_vahed, mablegh_kol, mojodi;
        PersianCalendar pc = new PersianCalendar();
        List<Forosh> lst_forosh = new List<Forosh>();
        List<Anbar> lst_Anbar = new List<Anbar>();
        public Frm_forosh_aghsat()
        {
            InitializeComponent();
        }
        public void load_form()
        {
            try
            {
                listView1.Items.Clear();
                number = 0;
                foreach (ForoshAghsat  k in lst_forosh)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number + "";
                    t.Tag = k;

                    t.SubItems.Add(k.Name_kala);
                    t.SubItems.Add(k.Model_kala);
                    t.SubItems.Add(k.Count.ToString());
                    t.SubItems.Add(k.Ghimat_vahed.ToString());
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }
        private void Date()
        {
            DateTime dt = DateTime.Today;
            year = pc.GetYear(dt);
            month = pc.GetMonth(dt);
            day = pc.GetDayOfMonth(dt);

            if (day % 10 == day) cmb_day.Text = "0" + day;
            else cmb_day.Text = day.ToString();
            if (month % 10 == month) cmb_month.Text = "0" + month;
            else cmb_month.Text = month.ToString();
            txt_year.Text = year.ToString();
        }

        private void Frm_forosh_aghsat_Load(object sender, EventArgs e)
        {
            try
            {
                Date();
                var q = context.Anbars.GroupBy(g => g.Name_kala);
                foreach (var item in q) cmb_nkala.Items.Add(item.Key);
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }

        private void cmb_nkala_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                txt_eshterak.Enabled = false;
                cmb_model.Items.Clear();
                var q = context.Anbars.Where(a => a.Name_kala == cmb_nkala.Text);
                foreach (var item in q) cmb_model.Items.Add(item.Model_kala);
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }

        private void cmb_model_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                mojodi = 0;
                txt_mojodi.Text = "";
                txt_ghimat_vahed.Text = "0";
                txt_eshterak.Enabled = false;
                var q = context.Anbars.Where(k => k.Name_kala == cmb_nkala.Text && k.Model_kala == cmb_model.Text);
                foreach (var item in q)
                {
                    mojodi = item.Count_kala;
                    txt_ghimat_vahed.Text = (item.Ghimat_forosh).ToString();
                }

                txt_mojodi.Text = mojodi.ToString();
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }

        private void txt_eshterak_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                lst_Anbar.Clear();
                lst_forosh.Clear();
                txt_count.Text = "";
                txt_mojodi.Text = "";
                txt_ghimat_vahed.Text = "0";
                cmb_model.Items.Clear();
                listView1.Items.Clear();

                long eshterak = Convert.ToInt64(txt_eshterak .Text);
                var q = context.Moshtarekins .Where(m=>m.Eshterak  == eshterak);
                if (q.Count() > 0)
                {
                    foreach (var item in q) txt_name_moshterak.Text = item.Name + " " +item.Family ;

                }
                else txt_name_moshterak .Text = "";
            }
            catch { }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_nkala.Text != "" && cmb_model.Text != "" && txt_factor.Text != "0" && txt_factor.Text != "")
                {
                    txt_eshterak .Enabled = false;
                    var q = lst_forosh.Where(s => s.Name_kala == cmb_nkala.Text && s.Model_kala == cmb_model.Text);
                    long eshterak=Convert.ToInt64 (txt_eshterak .Text );
                    var q2 = context.Moshtarekins.Where(m => m.Eshterak == eshterak);

                    if (q.Count() > 0) MessageBox.Show("همچین کالایی اضافه شده است");
                    else
                    {
                        if (Convert.ToInt32(txt_count.Text) > mojodi) MessageBox.Show("تعداد کالای انتخابی از موجودی بیشتر است ");
                        else
                        {
                            if (q2.Count() > 0)
                            {
                                ForoshAghsat f = new ForoshAghsat(Convert.ToInt32(txt_factor.Text), Convert.ToInt64(txt_eshterak.Text), cmb_nkala.Text, cmb_model.Text, Convert.ToInt32(txt_count.Text), Convert.ToInt64(txt_ghimat_vahed.Text), txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text);
                                lst_forosh.Add(f);

                                load_form();
                                ////////////////////
                                tedad++;
                                lab_jamhe_tedad.Text = tedad.ToString();
                                mablegh_kol = mablegh_kol + (Convert.ToInt64(txt_ghimat_vahed.Text) * Convert.ToInt32(txt_count.Text));
                                lab_mablegh_kol.Text = mablegh_kol.ToString();
                                //////////////////
                            }
                            else { MessageBox.Show("اشتراک موجود نمی باشد"); }
                        }
                    }
                }
                else MessageBox.Show("اطلاعات را به طور صحیح وارد کنید");
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void btn_sabt_factor_Click(object sender, EventArgs e)
        {
            try
            {
                int fact = Convert.ToInt32(txt_factor.Text);
                var check_factor = context.Foroshes.Where(k => k.Factor == fact);
                if (txt_factor.Text == "0" || txt_factor.Text == "") { MessageBox.Show("اطلاعات را به طور صحیح وارد کنید"); }
                else
                {
                    if (check_factor.Count() > 0) { MessageBox.Show("فاکتور شماره " + fact + " وجود دارد"); }
                    else
                    {
                        if (lst_forosh.Count == 0) { MessageBox.Show("لطفا فاکتور را پر کنید"); }
                        else
                        {
                            /////////////////ثبت فاکتور فروش////////////////
                            foreach (var kh in lst_forosh) kh.Factor = fact;

                            foreach (var kh in lst_forosh)
                            {
                                context.Foroshes.AddObject(kh);
                                context.SaveChanges();
                            }
                            ////////////////////////اضافه کردن به لیست انبار////////////////
                            foreach (var item in lst_forosh)
                            {
                                ////////////بدست آوردن قیمت واحد///////////////
                                var q_g = context.Anbars.Where(k => k.Name_kala == item.Name_kala && k.Model_kala == item.Model_kala);
                                foreach (var gh in q_g) ghimat_vahed = gh.Ghimat_vahed;

                                Anbar a = new Anbar(item.Name_kala, item.Model_kala, item.Count, ghimat_vahed, item.Ghimat_vahed);
                                lst_Anbar.Add(a);

                            }

                            ///////////////////////ویرایش در انبار////////////////////////////////
                            foreach (var a in lst_Anbar)
                            {
                                var q = context.Anbars.Where(s => s.Name_kala == a.Name_kala && s.Model_kala == a.Model_kala);

                                    foreach (var c in q)
                                    {
                                        id = c.Id;
                                        count_kala = c.Count_kala;
                                    }

                                    a.Id = id;
                                    a.Count_kala = count_kala - a.Count_kala;
                                    context.Anbars.ApplyCurrentValues(a);
                                    context.SaveChanges();

                            }
                            ////////////////////////////////////////////////////////////////////
                            MessageBox.Show(" فاکتور" + txt_factor.Text + "  ثبت شد");
                            txt_count.Text = "0";

                            txt_ghimat_vahed.Text = "0";
                            cmb_model.Text = "";
                            cmb_nkala.Text = "";
                            txt_eshterak .Enabled = true;
                            lst_Anbar.Clear();
                            lst_forosh.Clear();
                            listView1.Items.Clear();
                            lab_jamhe_tedad.Text = "";
                            lab_mablegh_kol.Text = "";
                            txt_factor.Text = "0";
                            tedad = 0;
                            mablegh_kol = 0;
                        }
                    }
                }
            }
            catch (Exception x) { MessageBox.Show(" خطا در ثبت : " + x); }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ForoshAghsat k = new ForoshAghsat();
                if (listView1.SelectedItems.Count > 0)
                {
                    k = (ForoshAghsat)listView1.SelectedItems[0].Tag;
                    cmb_nkala.Text = k.Name_kala;
                    cmb_model.Text = k.Model_kala;
                    txt_count.Text = k.Count.ToString();
                    txt_ghimat_vahed.Text = k.Ghimat_vahed.ToString();
                }
            }
            catch { }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                int result = Convert.ToInt32(MessageBox.Show("آیا  مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                if (result == 6)
                {
                    int count = listView1.SelectedItems.Count;
                    while (count != 0)
                    {
                        ForoshAghsat f = (ForoshAghsat)listView1.SelectedItems[count - 1].Tag;
                        lst_forosh.Remove(f);
                        count--;
                        ///////////////
                        tedad--;
                        lab_jamhe_tedad.Text = tedad.ToString();
                        mablegh_kol = mablegh_kol - (f.Ghimat_vahed * f.Count);
                        lab_mablegh_kol.Text = mablegh_kol.ToString();
                        ///////////////
                    }
                    load_form();
                }
            }
            catch (Exception x) { MessageBox.Show("خطا در حذف " + x); }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ForoshAghsat f = (ForoshAghsat)listView1.SelectedItems[0].Tag;
                    f.Name_kala = cmb_nkala.Text;
                    f.Model_kala = cmb_model.Text;
                    /////////////////////
                    mablegh_kol = mablegh_kol - (f.Ghimat_vahed * f.Count);


                    f.Count = Convert.ToInt32(txt_count.Text);
                    f.Ghimat_vahed = Convert.ToInt64(txt_ghimat_vahed.Text);

                    mablegh_kol = mablegh_kol + (f.Ghimat_vahed * f.Count);
                    lab_mablegh_kol.Text = mablegh_kol.ToString();
                    /////////////////////

                    load_form();
                }
                else MessageBox.Show("یک رکورد را انتخاب کنید ");

            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

    }
}
