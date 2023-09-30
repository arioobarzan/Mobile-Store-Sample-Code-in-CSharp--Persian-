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
    public partial class Frm_Sanad_Moshteri : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year; 
        PersianCalendar pc = new PersianCalendar();
        public Frm_Sanad_Moshteri()
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

        private void Frm_Sanad_Moshteri_Load(object sender, EventArgs e)
        {
            txt_sanad.Focus();
            Date();
            Automatic_shomare_sanad();
            foreach (var item in context.Coustomers) cmb_name_moshtari.Items.Add(item);


        }

        private void Automatic_shomare_sanad()
        {
            int max = 0;
            var q = context.SanadMoshtaris.Select(s => s.Shomareh_sanad);
            foreach (var item in q) max = item;
            max++;
            txt_sanad.Text = max.ToString();
        }

        private void btn_Sabt_Sanad_Click(object sender, EventArgs e)
        {
            int sanad = Convert.ToInt32(txt_sanad.Text);
            var q_check = context.SanadMoshtaris .Where(s => s.Shomareh_sanad == sanad);
            if (q_check.Count() > 0) { MessageBox.Show("این شماره سند ثبت شده است "); }
            else
            {
                long bedehi, bestankar;
                if (txt_bedehkar.Text == "") bedehi = 0;
                else bedehi = Convert.ToInt64(txt_bedehkar.Text);
                if (txt_bestankar.Text == "") bestankar = 0;
                else bestankar = Convert.ToInt64(txt_bestankar.Text);

                SanadMoshtari sm = new SanadMoshtari(Convert.ToInt32(txt_sanad.Text), cmb_name_moshtari.Text, bedehi, bestankar, txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text, txt_tozih.Text);
                context.SanadMoshtaris.AddObject(sm);
                context.SaveChanges();

                MessageBox.Show("شماره سند " + txt_sanad.Text + " ثبت شد");
                Automatic_shomare_sanad(); txt_tozih.Text = ""; txt_bedehkar.Text = "";
                txt_bestankar.Text = ""; cmb_name_moshtari.Text = "";
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
