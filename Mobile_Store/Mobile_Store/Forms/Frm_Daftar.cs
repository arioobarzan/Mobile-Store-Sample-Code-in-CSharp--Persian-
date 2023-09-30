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
    public partial class Frm_Daftar : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year; long baghimandeh;
        List<Daryaft> lst_daryaft = new List<Daryaft>();
        PersianCalendar pc = new PersianCalendar();
        public Frm_Daftar()
        {
            InitializeComponent();
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
        private void Baghimandeh()
        {
            long jamhe_daryafti = 0;
            int factor = Convert.ToInt32(txt_factor.Text);
            /////////////باقیمانده بدهی///////////////////
            var q_par = context.Daryafts.Where(p => p.Factor == factor);
            foreach (var item in q_par)
            {
                jamhe_daryafti = Convert.ToInt64(item.Mablegh_check) + Convert.ToInt64(item.Mablegh_naghdi) + Convert.ToInt64(item.Mablegh_Dafteri) + jamhe_daryafti;
            }
            baghimandeh = Convert.ToInt64(lab_manlegh_factor.Text) - jamhe_daryafti;
            ///////////////////////////////////////////////
        }
        public void load_data()
        {
            var q = context.Daryafts.Where(d => d.Type_daryaft == "2" && d.Pas_check =="0");
            dataGridView1.DataSource = q;
            Changh();

            Jamhe_Mablegh_Daftar(q);

        }
        private void Jamhe_Mablegh_Daftar(IQueryable<Daryaft> q)
        {
            long jamhe_mablegh_daftar = 0;
            foreach (var item in q) jamhe_mablegh_daftar += Convert.ToInt64(item.Mablegh_Dafteri);
            lab_jamhe_mablegh_dafteri.Text = jamhe_mablegh_daftar.ToString();
        }
        private void Changh()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;


            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].HeaderText = "فاکتور ";
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[4].HeaderText = "مبلغ بدهی";
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[5].HeaderText = "تاریخ خرید  ";
            dataGridView1.Columns[6].Width = 166;
            dataGridView1.Columns[6].HeaderText = " نام شخص ";
        }
        private void Search()
        {
            var q2 = context.Daryafts.Where(d => d.Type_daryaft == "2" && d.Pas_check=="0" && d.Name_shakhs.EndsWith(txt_search.Text));
            dataGridView1.DataSource = q2;
            Changh();
            Jamhe_Mablegh_Daftar(q2);
        }

        private void txt_factor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lab_manlegh_factor.Text = ""; lab_name_moshtari.Text = ""; 
                int fact = Convert.ToInt32(txt_factor.Text); long mablegh_fact = 0;
                var q_mablegh_factor = context.Foroshes.Where(k => k.Factor == fact).OfType<ForoshNaghdi>();
                var q_mablegh_barghasht = context.BarForoshes.Where(k => k.Factor == fact);
                var q_takhfif = context.Takhfifs.Where(k => k.Factor == fact);
                if (q_mablegh_factor.Count() > 0)
                {
                    ////////////////حساب مبلغ فاکتور//////////////
                    foreach (var item in q_mablegh_factor)
                    {
                        mablegh_fact = mablegh_fact + (item.Ghimat_vahed * item.Count);
                        lab_name_moshtari.Text = item.Name_Moshtari;
                    }
                    if (lab_name_moshtari.Text != "متفرقه") txt_name_shakhs.Text = lab_name_moshtari.Text;
                    else txt_name_shakhs.Text = "";
                    /////////////////کم کردن مبلغ برگشتی از فاکتور//////
                    foreach (var item in q_mablegh_barghasht)
                    {
                        mablegh_fact = mablegh_fact - (item.Ghimat_vahed * item.Count);
                    }
                    ////////کم کردن تخفیف از فاکتور//////////////////////////
                    foreach (var item in q_takhfif) mablegh_fact = mablegh_fact - item.Mablegh_Takhfif;

                    lab_manlegh_factor.Text = mablegh_fact.ToString();
                }

                Baghimandeh();
                txt_mablegh.Text = baghimandeh.ToString();
            }
            catch { }
        }

        private void Frm_Daftar_Load(object sender, EventArgs e)
        {
            txt_mablegh.Focus();
            Date();
            load_data();
            
        }

        private void btn_daryaft_naghdi_Click(object sender, EventArgs e)
        {
            try
            {
                Baghimandeh();
                if (Convert.ToInt64(txt_mablegh.Text) > baghimandeh) { MessageBox.Show("مبلغ بیش از بدهی است "); }
                else
                {
                    if (txt_year.Text == "" || cmb_month.Text == "" || cmb_day.Text == "" || txt_mablegh.Text == "" || txt_name_shakhs.Text == "") { MessageBox.Show("اطلاعات را به طور صحیح وارد کنید"); }
                    else
                    {
                        Daryaft d = new Daryaft(Convert.ToInt32(txt_factor.Text), 0, null, Convert.ToInt64(txt_mablegh.Text), txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text, txt_name_shakhs.Text, null, null, null, null, 0, null,"0", "2");
                        context.Daryafts.AddObject(d);
                        context.SaveChanges();

                        MessageBox.Show("در دفتر ثبت شد");
                        Baghimandeh();
                        Search();
                        txt_mablegh.Text = baghimandeh.ToString();
                    }

                }
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید"); }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Search();
        }

      

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_mablegh_pardakhti .Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch { }
        }

        private void btn_pardakht_bedehi_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Daryaft d = (Daryaft)dataGridView1.SelectedRows[0].DataBoundItem;
                    if (Convert.ToInt64(txt_mablegh_pardakhti.Text) > d.Mablegh_Dafteri) { MessageBox.Show("مبلغ بیشتر از بدهی است"); }
                    else
                    {
                        if (Convert.ToInt64(txt_mablegh_pardakhti.Text) == d.Mablegh_Dafteri)
                        {
                            d.Pas_check = "1";
                            MessageBox.Show("پرداخت بدهی با موفقیت انجام شد");
                        }
                        else
                        {
                            if (Convert.ToInt64(txt_mablegh_pardakhti.Text) < d.Mablegh_Dafteri)
                            {
                                d.Mablegh_Dafteri -= Convert.ToInt64(txt_mablegh_pardakhti.Text);
                                MessageBox.Show("مبلغ از بدهی کسر شد");

                            }
                        }
                    }
                    context.Daryafts.ApplyCurrentValues(d);
                    context.SaveChanges();
                    Search();
                }
                else MessageBox.Show("یک رکورد را انتخاب کنید ");
            }
            catch { }
        }




    }
}
