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
    public partial class Frm_Ghest_bandi : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year; long mablegh_ghest;
        PersianCalendar pc = new PersianCalendar();
        List<Daryaft> lst_daryaft = new List<Daryaft>();
        public Frm_Ghest_bandi()
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
        public void changh()
        {
            int fact=Convert .ToInt32 (txt_factor .Text );
            long eshterak = Convert.ToInt64(txt_eshterak.Text);
            var q = context.Aghsats.Where(k=>k.Eshterak ==eshterak   &&  k.Factor ==fact  );
            dataGridView1.DataSource = q;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[6].Visible = false;


            dataGridView1.Columns[3].Width = 140;
            dataGridView1.Columns[3].HeaderText = "شماره قسط";
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[4].HeaderText = "مبلغ قسط";
            dataGridView1.Columns[5].Width = 195;
            dataGridView1.Columns[5].HeaderText = "تاریخ پرداخت";

        }
        private void Frm_Ghest_bandi_Load(object sender, EventArgs e)
        {
            Date();
        }

        private void txt_eshterak_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_count_ghest.Text = "";
                txt_sood.Text = "0";
                txt_factor.Text = "0";
                dataGridView1.Rows.Clear();
                long eshterak = Convert.ToInt64(txt_eshterak.Text);
                var q = context.Moshtarekins.Where(m => m.Eshterak == eshterak);
                if (q.Count() > 0)
                {
                    foreach (var item in q) txt_name_moshterak.Text = item.Name + " " + item.Family;

                }
                else txt_name_moshterak.Text = "";
            }
            catch (Exception x) { MessageBox.Show("خطا"+ x);  }
        }

        private void txt_factor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_mablegh_factor.Text = "";
                int fact = Convert.ToInt32(txt_factor.Text);long eshterak=Convert.ToInt64 (txt_eshterak .Text ); long mablegh_fact = 0;
                
                ///////////////////////////مبلغ فاکتور مشترک//////////////////
                var q_mablegh_factor = context.Foroshes.Where(k => k.Factor == fact).OfType<ForoshAghsat >();
                var q_mablegh_factor_moshterek = q_mablegh_factor.Where(k => k.Eshterak == eshterak);
                /////////////////////////////کم کردن مبلغ فاکتور برگشتی از فاکتور مشترک/////////
                var q_mablegh_barghasht = context.BarForoshes.Where(k => k.Factor == fact);
               //////////////////////////////////////////////////////////////

                if (q_mablegh_factor_moshterek.Count() > 0)
                {
                    foreach (var item in q_mablegh_factor_moshterek) mablegh_fact = mablegh_fact + (item.Ghimat_vahed * item.Count);

                    foreach (var item in q_mablegh_barghasht) mablegh_fact = mablegh_fact - (item.Ghimat_vahed * item.Count);

                    txt_mablegh_factor.Text  = mablegh_fact.ToString();
                    changh();
                }
            }
            catch (Exception x) { MessageBox.Show("خطا"+ x); }
        }

        private void btn_sabt_ghsat_Click(object sender, EventArgs e)
        {
            try
            {
                int fact = Convert.ToInt32(txt_factor.Text);
                long eshterak = Convert.ToInt64(txt_eshterak.Text);
                int year = Convert.ToInt32(txt_year.Text);
                int month = Convert.ToInt32(cmb_month.Text);
                int day = Convert.ToInt32(cmb_day.Text);
                int count = Convert.ToInt32(txt_count_ghest.Text);
                string str_month, str_day;
                int number_ghest = 0;
                var q_check_ghest = context.Aghsats.Where(a => a.Eshterak == eshterak  && a.Factor == fact );
                if (q_check_ghest.Count() > 0) { MessageBox.Show("قسط ها برای این فاکتور ثبت شده"); }
                else
                {
                    ///////////////////////////محاسبه مبلغ قسط///////////////////
                    mohasebeh_ghest();
                    //////////////////////////////ثبت اقساط//////////////////////
                    while (count != 0)
                    {
                        number_ghest++;
                        month++;
                        if (month > 12)
                        {
                            month = month - 12;
                            year++;
                        }
                        if (month % 10 == month) str_month = "0" + month;
                        else str_month = month.ToString();
                        if (day % 10 == day) str_day = "0" + day ;
                        else str_day = day.ToString();

                        Aghsat a = new Aghsat(Convert.ToInt64(txt_eshterak.Text), Convert.ToInt32(txt_factor.Text), number_ghest, mablegh_ghest, year + "/" + str_month + "/" + str_day , "0");
                        context.Aghsats.AddObject(a);
                        context.SaveChanges();
                        changh();
                        count--;
                        //////////////////////////////////////////////////////////////
                    }

                    /////////////////ثبت پیش پرداخت/////////////////
                    Daryaft d = new Daryaft(Convert.ToInt32(txt_factor.Text), Convert.ToInt64(txt_pishpardakht.Text),txt_year.Text +"/"+cmb_month .Text +"/"+cmb_day .Text , 0, null, null, null, null, null, null, 0, null, null, "0");
                    context.Daryafts.AddObject(d);
                    context.SaveChanges();
                    /////////////////////////////////////////////////
                }
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }
        }

        private void mohasebeh_ghest()
        {
            mablegh_ghest = 0;
            mablegh_ghest = Convert.ToInt64(txt_mablegh_factor.Text) - Convert.ToInt64(txt_pishpardakht.Text);
            Sood_mablagh();
            mablegh_ghest = mablegh_ghest / Convert.ToInt64(txt_count_ghest.Text);
        }

        public long Sood_mablagh()
        {
            long sood = (mablegh_ghest * Convert.ToInt32(txt_sood.Text)) / 100;
            mablegh_ghest = mablegh_ghest + sood;
            return mablegh_ghest;
        }

        private void btn_delete_aghsat_Click(object sender, EventArgs e)
        {
            //try
            //{
            lst_daryaft.Clear();
                int result = Convert.ToInt32(MessageBox.Show("آیا  مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                if (result == 6)
                {
                    int count = dataGridView1.Rows.Count -1;
                    while (count != 0)
                    {
                        context.Aghsats .DeleteObject((Aghsat)dataGridView1.Rows[0].DataBoundItem);
                        context.SaveChanges();
                        count--;
                    }

                    ////////////////حذف پیش پرداخت اقساط////////////
                    int fact=Convert.ToInt32 (txt_factor .Text );
                    var q = context.Daryafts.Where(d => d.Factor == fact);
                    foreach (var item in q) lst_daryaft.Add(item);
                    foreach (var pish in lst_daryaft )
                    {
                        context.Daryafts.DeleteObject(pish);
                        context.SaveChanges();
                    }
                    //////////////////////////////////////////////////

                }
          //  }
         //   catch(Exception  x) { MessageBox.Show("خطا در حذف "+x); }
        }

        private void btn_mohasebeh_aghsat_Click(object sender, EventArgs e)
        {
            try
            {
                mohasebeh_ghest();
                Frm_mohasebeh_aghsat f = new Frm_mohasebeh_aghsat(Convert.ToInt32(txt_count_ghest.Text), mablegh_ghest);
                f.ShowDialog();
            }
            catch { }
        }
    }
}
