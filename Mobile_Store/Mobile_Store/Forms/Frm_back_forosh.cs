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
    public partial class Frm_back_forosh : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year, tedad, number, count_kala, id; long ghimat_vahed, mablegh_kol, mojodi;
        PersianCalendar pc = new PersianCalendar();
        List<BarForosh> lst_bar_forosh = new List<BarForosh>();
        List<Anbar> lst_Anbar = new List<Anbar>();
        public Frm_back_forosh()
        {
            InitializeComponent();
        }
        public void date()
        {
            DateTime dt = DateTime.Today;
            year = pc.GetYear(dt);
            month = pc.GetMonth(dt);
            day = pc.GetDayOfMonth(dt);

            if (day % 10 == day) cmb_day.Text = "0" + day;
            else cmb_day.Text = day.ToString();
            if (month % 10 == month) cmb_month.Text = "0" + month;
          else   cmb_month.Text = month.ToString();
            txt_year.Text = year.ToString();
        }
        public void loadform()
        {
            try
            {
                listView1.Items.Clear();
                number = 0;
                foreach (BarForosh  k in lst_bar_forosh )
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
        private void Frm_back_forosh_Load(object sender, EventArgs e)
        {
            date();
        }

        private void txt_factor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmb_nkala.Items.Clear();
                lst_Anbar.Clear();
                lst_bar_forosh.Clear();
                txt_count.Text = "0";
                lab_mojodi.Text = "";
                txt_ghimat_vahed.Text = "0";
                cmb_nkala.Items.Clear();
                cmb_model.Items.Clear();
                listView1.Items.Clear();
                
                int fact = Convert.ToInt32(txt_factor.Text);
                var q = context.Foroshes .Where(k => k.Factor == fact).OfType<ForoshNaghdi >();
                if (q.Count() > 0)
                {
                    foreach (var item in q) cmb_name_moshtari .Text  = item.Name_Moshtari;
                  
                    var q2 = q.Where(k => k.Factor == fact && k.Name_Moshtari ==cmb_name_moshtari .Text ).GroupBy(g => g.Name_kala);
                   foreach (var item in q2) cmb_nkala.Items.Add(item.Key);
                }
                else cmb_name_moshtari.Text = "";
            }
            catch { }
        }

        private void cmb_nkala_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                lab_mojodi.Text = "";
                txt_ghimat_vahed.Text = "0";
                txt_count.Text = "0";
                int fact = Convert.ToInt32(txt_factor.Text);
                cmb_model.Items.Clear();
                var q = context.Foroshes.Where(k => k.Name_kala == cmb_nkala.Text && k.Factor == fact);
                foreach (var item in q) cmb_model.Items.Add(item.Model_kala);
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }

        private void cmb_model_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                mojodi = 0;
                lab_mojodi.Text = "";
                txt_count.Text = "0";
                txt_ghimat_vahed.Text = "0";
                int fact = Convert.ToInt32(txt_factor.Text);
                var q = context.Foroshes.Where(k => k.Factor == fact && k.Name_kala == cmb_nkala.Text && k.Model_kala == cmb_model.Text);
                foreach (var item in q)
                {
                    mojodi = item.Count;
                    txt_ghimat_vahed.Text = (item.Ghimat_vahed).ToString();
                }
                var q2 = context.BarForoshes .Where(k => k.Factor == fact && k.Name_kala == cmb_nkala.Text && k.Model_kala == cmb_model.Text);
                foreach (var item in q2) mojodi = mojodi - item.Count;

                lab_mojodi.Text = mojodi.ToString();
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmb_nkala.Text != "" && cmb_model.Text != "")
                {
                    var q = lst_bar_forosh .Where(s => s.Name_kala == cmb_nkala.Text && s.Model_kala == cmb_model.Text);
                    if (q.Count() > 0) MessageBox.Show("همچین کالایی اضافه شده است");
                    else
                    {

                        if (Convert.ToInt32(txt_count.Text) > mojodi ) MessageBox.Show("تعداد کالای انتخابی از موجودی  بیشتر است ");
                        else
                        {
                            BarForosh bf = new BarForosh(Convert.ToInt32(txt_factor.Text), cmb_nkala.Text, cmb_model.Text, Convert.ToInt32(txt_count.Text), Convert.ToInt64(txt_ghimat_vahed.Text), txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text);
                            lst_bar_forosh.Add(bf);

                            loadform();
                            ///////////////
                            tedad++;
                            lab_jamhe_tedad.Text = tedad.ToString();
                            mablegh_kol = mablegh_kol + (Convert.ToInt64(txt_ghimat_vahed.Text) * Convert.ToInt32(txt_count.Text));
                            lab_mablegh_kol.Text = mablegh_kol.ToString();
                            ///////////////
                        }
                    }
                }
                else MessageBox.Show("نام و مدل کالا را وارد کنید");
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void btn_sabt_bar_forosh_Click(object sender, EventArgs e)
        {
            try
            {
                int fact = Convert.ToInt32(txt_factor.Text);
                if (txt_count.Text == "" || txt_factor.Text == "0") { MessageBox.Show(" اطلاعات را به طور صحیح وارد کنید  "); }
                else
                {
                    if (lst_bar_forosh .Count == 0) { MessageBox.Show("لطفا فاکتور را پر کنید"); }
                    else
                    {
                        /////////////////ثبت فاکتور برگشت////////////////
                        foreach (var bar in lst_bar_forosh )
                        {
                            context.BarForoshes .AddObject(bar);
                            context.SaveChanges();
                        }
                        MessageBox.Show("فاکتور برگشت" + txt_factor.Text + "  ثبت شد");

                        ////////////////////////اضافه کردن به لیست انبار////////////////
                        foreach (var item in lst_bar_forosh)
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

                            if (q.Count() > 0)
                            {
                                foreach (var c in q)
                                {
                                    id = c.Id;
                                    count_kala = c.Count_kala;
                                }
                                a.Id = id;
                                a.Count_kala = count_kala + a.Count_kala;
                                context.Anbars.ApplyCurrentValues(a);
                                context.SaveChanges();
                            }
                        }
                        ////////////////////////////////////////////////////////////////////
                        txt_count.Text = "0";
                        txt_ghimat_vahed.Text = "0";
                        cmb_model.Text = "";
                        cmb_nkala.Text = "";
                        cmb_name_moshtari.Enabled = true;
                        lst_Anbar.Clear();
                        lst_bar_forosh.Clear();
                        listView1.Items.Clear();
                        lab_jamhe_tedad.Text = "";
                        lab_mablegh_kol.Text = "";
                        txt_factor.Text = "0";
                    }
                }

            }
            catch (Exception x) { MessageBox.Show(" خطا در ثبت : " + x); }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    BarForosh  k = (BarForosh )listView1.SelectedItems[0].Tag;
                    k.Name_kala = cmb_nkala.Text;
                    k.Model_kala = cmb_model.Text;
                    /////////////////////
                    mablegh_kol = mablegh_kol - (k.Ghimat_vahed * k.Count);
                    if (Convert.ToInt32(txt_count.Text) > mojodi) { MessageBox.Show("  تعداد کالای ویرایش شده بیشتر از موجودی فاکتور است"); }
                    else k.Count = Convert.ToInt32(txt_count.Text);


                    mablegh_kol = mablegh_kol + (k.Ghimat_vahed * k.Count);
                    lab_mablegh_kol.Text = mablegh_kol.ToString();
                    /////////////////////

                    loadform();
                }
                else MessageBox.Show("یک رکورد را انتخاب کنید ");

            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BarForosh  bar = new BarForosh ();
                if (listView1.SelectedItems.Count > 0)
                {
                    bar = (BarForosh )listView1.SelectedItems[0].Tag;
                    cmb_nkala.Text = bar.Name_kala;
                    cmb_model.Text = bar.Model_kala;
                    txt_count.Text = bar.Count.ToString();
                    txt_ghimat_vahed.Text = bar.Ghimat_vahed.ToString();

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
                        BarForosh  k = (BarForosh )listView1.SelectedItems[count - 1].Tag;
                        lst_bar_forosh.Remove(k);
                        count--;
                        //////////////////////
                        tedad--;
                        lab_jamhe_tedad.Text = tedad.ToString();
                        mablegh_kol = mablegh_kol - (k.Ghimat_vahed * k.Count);
                        lab_mablegh_kol.Text = mablegh_kol.ToString();
                        /////////////////////
                    }
                    loadform();
                }
            }
            catch (Exception x) { MessageBox.Show("خطا در حذف " + x); }
        }


    }
}
