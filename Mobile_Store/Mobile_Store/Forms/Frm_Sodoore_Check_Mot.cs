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
    public partial class Frm_Sodoore_Check_Mot : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year;
        PersianCalendar pc = new PersianCalendar();
        public Frm_Sodoore_Check_Mot()
        {
            InitializeComponent();
        }

        private void Date()
        {
            DateTime dt = DateTime.Today;
            year = pc.GetYear(dt);
            month = pc.GetMonth(dt);
            day = pc.GetDayOfMonth(dt);

            if (day % 10 == day) cmb_day_sodor.Text = "0" + day;
            else cmb_day_sodor.Text = day.ToString();
            if (month % 10 == month) cmb_month_sodor.Text = "0" + month;
            else cmb_month_sodor.Text = month.ToString();
            txt_year_sodor.Text = year.ToString();
            txt_year_check.Text = year.ToString();
        }

        private void Frm_Sodoore_Check_Mot_Load(object sender, EventArgs e)
        {
            txt_shomare_hesab.Focus();
            Date();
        }

        private void btn_Sabt_Check_Click(object sender, EventArgs e)
        {
            try
            {
                var q_check = context.SodoorChecks.Where(s => s.Shomareh_Hesab == txt_shomare_hesab.Text && s.Shomareh_check == txt_shomare_check.Text && s.Dar_vajhe == txt_dar_vajhe.Text);
                var q_shomare_hesab = context.Banks.Where(b => b.Shomareh_Hesab == txt_shomare_hesab.Text);
                if (q_shomare_hesab.Count() == 0) { MessageBox.Show("این شماره حساب ثبت نشده است"); }
                else
                {
                    if (q_check.Count() > 0) { MessageBox.Show("چک ثبت شده است"); }
                    else
                    {
                        if (txt_year_sodor.Text == "" || cmb_month_sodor.Text == "" || cmb_day_sodor.Text == "" || txt_year_check.Text == "" || cmb_month_check.Text == "" || cmb_day_check.Text == "" || txt_shomare_hesab.Text == "" || txt_shomare_hesab.Text == "0" || txt_shomare_check.Text == "0" || txt_shomare_check.Text == "" || txt_mablegh_check.Text == "0" || txt_dar_vajhe.Text == "") { MessageBox.Show("اطلاعات را به درستی وارد کنید "); }
                        else
                        {
                            SodoorCheck s_check = new SodoorCheck(txt_year_sodor.Text + "/" + cmb_month_sodor.Text + "/" + cmb_day_sodor.Text,txt_year_check .Text +"/"+cmb_month_check .Text +"/"+cmb_day_check .Text , txt_shomare_hesab.Text, txt_shomare_check.Text, Convert.ToInt64(txt_mablegh_check.Text), txt_dar_vajhe.Text, txt_tozih.Text);
                            context.SodoorChecks.AddObject(s_check);
                            context.SaveChanges();

                            MessageBox.Show("چک ثبت شد");
                            txt_dar_vajhe.Text = ""; txt_shomare_check.Text = "";
                            txt_shomare_hesab.Text = ""; txt_mablegh_check.Text = ""; txt_tozih.Text = "";

                        }
                    }
                }
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_shomare_hesab_TextChanged(object sender, EventArgs e)
        {
            var q = context.Banks.Where(b => b.Shomareh_Hesab == txt_shomare_hesab.Text);
            if (q.Count() > 0)
            {
                foreach (var item in q) { lab_bank.Text = item.Name + " / " + item.Shohbeh; }
            }
            else lab_bank.Text = "";
        }




 
    }
}
