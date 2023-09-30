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
    public partial class Frm_Bardasht_Mot : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year;
        PersianCalendar pc = new PersianCalendar();
        public Frm_Bardasht_Mot()
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

        private void Frm_Bardasht_Mot_Load(object sender, EventArgs e)
        {
            txt_mablegh.Focus();
            Date();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Sabt_Sanad_Click(object sender, EventArgs e)
        {
            try
            {
                BardashtMot bm = new BardashtMot(txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text, Convert.ToInt64(txt_mablegh.Text), txt_tozih.Text);
                context.BardashtMots.AddObject(bm);
                context.SaveChanges();

                MessageBox.Show("سند ثبت شد");

            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید"); }
        }


    }
}
