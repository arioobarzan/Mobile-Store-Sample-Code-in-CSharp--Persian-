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
    public partial class Frm_daryaft_ghest : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year;
        PersianCalendar pc = new PersianCalendar();
        public Frm_daryaft_ghest()
        {
            InitializeComponent();
        }

        private void Date()
        {
            DateTime dt = DateTime.Today;
            year = pc.GetYear(dt);
            month = pc.GetMonth(dt);
            day = pc.GetDayOfMonth(dt);

            if (day % 10 == day) cmb_day_ghest.Text  = "0" + day;
            else cmb_day_ghest.Text = day.ToString();
            if (month % 10 == month) cmb_month_ghest.Text = "0" + month;
            else cmb_month_ghest.Text = month.ToString();
            txt_year_ghest.Text = year.ToString();
        }
        public void load_data(long eshterak)
        {
            var q_aghsat = context.Aghsats.Where(a => a.Eshterak == eshterak  && a.Pass =="0");
            dataGridView1.DataSource = q_aghsat;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[6].Visible = false;



            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[2].HeaderText = "فاکتور ";
            dataGridView1.Columns[3].Width = 130;
            dataGridView1.Columns[3].HeaderText = "شماره قسط";
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[4].HeaderText = "مبلغ قسط ";
            dataGridView1.Columns[5].Width = 133;
            dataGridView1.Columns[5].HeaderText = "تاریخ پرداخت ";

        }

        private void btn_daryaft_ghest_Click(object sender, EventArgs e)
        {
            //try
            //{
                long eshterak = Convert.ToInt64(txt_eshterak.Text);
                int count=dataGridView1.SelectedRows.Count;
                if (count  > 0)
                {

                        ///////////////دریافت قسط/////////////////
                         
                        Aghsat  a = (Aghsat)dataGridView1.SelectedRows[0].DataBoundItem;
                        Daryaft d = new Daryaft(a.Factor, a.Mablegh_ghest, txt_year_ghest.Text + "/" + cmb_month_ghest.Text + "/" + cmb_day_ghest.Text, 0, null, null, null, null, null, null, 0, null, null, "0");
                        context.Daryafts.AddObject(d);
                        context.SaveChanges();
                        ///////////////////////////////////////////

                        ///////////////////////ویرایش اقساط//////
                        a.Pass = "1";
                        context.Aghsats.ApplyCurrentValues(a);
                        context.SaveChanges();
                        ////////////////////////////////////////////
                        load_data(eshterak);
                        count--;
                    
                }
                else MessageBox.Show("یک رکورد را انتخایب کنید");
          //  }
        //    catch (Exception x) { MessageBox.Show("خطا" + x); }
        }

        private void Frm_daryaft_ghest_Load(object sender, EventArgs e)
        {
            Date();
        }

        private void txt_eshterak_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long eshterak = Convert.ToInt64(txt_eshterak.Text);
                var q_name_moshterak = context.Moshtarekins.Where(m => m.Eshterak == eshterak);
                
                if (q_name_moshterak.Count() > 0)
                {
                    foreach (var item in q_name_moshterak) lab_name_moshterak .Text = item.Name + " " + item.Family;
                }
                else lab_name_moshterak .Text = "";
                load_data(eshterak);

            }
            catch { }
        }

    }
}
