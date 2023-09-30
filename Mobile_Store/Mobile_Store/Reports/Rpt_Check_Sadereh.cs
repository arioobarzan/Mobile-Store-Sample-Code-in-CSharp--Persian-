using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Mobile_Store.Reports
{
    public partial class Rpt_Check_Sadereh : Form
    {
        PersianCalendar pc = new PersianCalendar();
        List<Pardakht> lst_pardakht = new List<Pardakht>();
        List<SodoorCheck> lst_check_mot = new List<SodoorCheck>();
        ContextContainer context = new ContextContainer();
        int day, month, year; long mablegh_check,tarikh_start,tarikh_end,tarikh_sodor;
        public Rpt_Check_Sadereh()
        {
            InitializeComponent();
        }

        private void Date()
        {
            DateTime dt = DateTime.Today;
            year = pc.GetYear(dt);
            month = pc.GetMonth(dt);
            day = pc.GetDayOfMonth(dt);

            if (day % 10 == day)
            { 
                cmb_day_1.Text = "0" + day;
                cmb_day_2.Text = "0" + day;
            }
            else
            { 
                cmb_day_1.Text = day.ToString();
                cmb_day_2.Text = day.ToString();
            }
            if (month % 10 == month)
            { 
                cmb_month_1.Text = "0" + month;
                cmb_month_2.Text = "0" + month;
            }
            else
            { 
                cmb_month_1.Text = month.ToString();
                cmb_month_2.Text = month.ToString();
            }
            txt_year_1.Text = year.ToString();
            txt_year_2.Text = year.ToString();
        }
        public void load_form()
        {
            try
            {
                listView1.Items.Clear();
                mablegh_check = 0;
                foreach (Pardakht  a in lst_pardakht)
                {
                    ListViewItem t = new ListViewItem();
                    t.Text = a.Date_check ;
                    t.Tag = a;

                    t.SubItems.Add(a.Shomareh_Hesab );
                    t.SubItems.Add(a.Shomareh_check );
                    t.SubItems.Add(a.Mablegh_check.ToString () );
                    mablegh_check +=Convert.ToInt64 ( a.Mablegh_check);
                    t.SubItems.Add(a.Dar_vajhe );
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        public void load_form_mot()
        {
            try
            {
                listView2.Items.Clear();
                
                foreach (SodoorCheck  sc in lst_check_mot)
                {
                    ListViewItem t = new ListViewItem();
                    t.Text = sc.Date_check;
                    t.Tag = sc;

                    t.SubItems.Add(sc.Shomareh_Hesab);
                    t.SubItems.Add(sc.Shomareh_check);
                    t.SubItems.Add(sc.Mablegh_check.ToString());
                    mablegh_check += Convert.ToInt64(sc.Mablegh_check);
                    t.SubItems.Add(sc.Dar_vajhe);
                    listView2.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        private void Rpt_Check_Sadereh_Load(object sender, EventArgs e)
        {
            Date();

        }

        private void Tarikh_Start(string date)
        {
            string day, month, year;
            string[] result_sodor = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result_sodor = Reg.Split(date);
            year = result_sodor[0].ToString();
            month = result_sodor[1].ToString();
            day = result_sodor[2].ToString();
            tarikh_start  = Convert.ToInt64(year + month + day);
        }
        private void Tarikh_End(string date)
        {
            string day, month, year;
            string[] result_sodor = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result_sodor = Reg.Split(date);
            year = result_sodor[0].ToString();
            month = result_sodor[1].ToString();
            day = result_sodor[2].ToString();
            tarikh_end  = Convert.ToInt64(year + month + day);
        }
        private void Tarikh_Sodor(Pardakht  item)
        {
            string day, month, year;
            string[] result_sodor = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result_sodor = Reg.Split(item.Date_sodoor );
            year = result_sodor[0].ToString();
            month = result_sodor[1].ToString();
            day = result_sodor[2].ToString();
            tarikh_sodor  = Convert.ToInt64(year + month + day);
        }
        private void Tarikh_Sodor_mot(SodoorCheck  item)
        {
            string day, month, year;
            string[] result_sodor = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result_sodor = Reg.Split(item.Date_Sodor );
            year = result_sodor[0].ToString();
            month = result_sodor[1].ToString();
            day = result_sodor[2].ToString();
            tarikh_sodor = Convert.ToInt64(year + month + day);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            
            //////////////////////از تاریخ////////////////////////////////
            string date_start = txt_year_1.Text + "/" + cmb_month_1.Text + "/" + cmb_day_1.Text;
            Tarikh_Start(date_start);
            //////////////////////////////////////////////////////////////

            //////////////////////////تا تاریخ///////////////////////////
            string date_end = txt_year_2.Text + "/" + cmb_month_2.Text + "/" + cmb_day_2.Text;
            Tarikh_End(date_end);
            //////////////////////////////////////////////////////////////

            lst_pardakht.Clear();
            lst_check_mot.Clear();
            var q = context.Pardakhts.Where(p => p.Type_pardakht == "1");
            foreach (var item in q )
            {
                Tarikh_Sodor(item);
                if (tarikh_start <= tarikh_sodor  && tarikh_sodor <= tarikh_end ) lst_pardakht.Add(item);
            }
            foreach (var item in context.SodoorChecks )
            {
                Tarikh_Sodor_mot(item);
                if (tarikh_start <= tarikh_sodor && tarikh_sodor <= tarikh_end) lst_check_mot.Add(item);
            }
            load_form();
            load_form_mot();
            lab_mablegh_check.Text = mablegh_check.ToString();
        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
