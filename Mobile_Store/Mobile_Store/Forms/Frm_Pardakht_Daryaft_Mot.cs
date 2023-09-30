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
    public partial class Frm_Pardakht_Daryaft_Mot : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year;
        PersianCalendar pc = new PersianCalendar();
        public Frm_Pardakht_Daryaft_Mot()
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
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_Pardakht_Daryaft_Mot_Load(object sender, EventArgs e)
        {
            txt_shakhs.Focus();
            Date();
        }

        private void btn_Sabt_Sanad_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_year.Text == "" || cmb_month.Text == "" || cmb_day.Text == "" || txt_shakhs.Text == "" || txt_mablegh_bedehi.Text == "0" || txt_mablegh_bestankar.Text == "0") { MessageBox.Show("اطلاعات را به درستی وارد کنید "); }
                else
                {
                    long bedehi, bestankar;
                    if (txt_mablegh_bedehi .Text == "") bedehi = 0;
                    else bedehi = Convert.ToInt64(txt_mablegh_bedehi .Text);
                    if (txt_mablegh_bestankar .Text == "") bestankar = 0;
                    else bestankar = Convert.ToInt64(txt_mablegh_bestankar .Text);

                    ParDarMot pd = new ParDarMot(txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text, txt_shakhs.Text,bedehi ,bestankar , txt_tozih.Text);
                    context.ParDarMots.AddObject(pd);
                    context.SaveChanges();

                    MessageBox.Show(" ثبت شد");
                    txt_mablegh_bedehi.Text = ""; txt_tozih.Text = "";
                    txt_mablegh_bestankar.Text = ""; txt_shakhs.Text = "";

                }
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید"); }
        }

    }
}
