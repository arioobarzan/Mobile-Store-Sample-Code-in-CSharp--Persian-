using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Mobile_Store.Reports
{
    public partial class Rpt_Max_Min_Forosh : Form
    {
        PersianCalendar pc = new PersianCalendar();
        List<Anbar> lst_Anbar = new List<Anbar>();
        List<Anbar> lst_Max = new List<Anbar>();
        List<Anbar> lst_Min = new List<Anbar>();
        ContextContainer context = new ContextContainer();
        int day, month, year, number, number_max, number_min, count, jamhe_tehdad_min, jamhe_tehdad_max;
        long jamhe_mablagh_min, jamhe_mablagh_max, tarikh_forosh, tarikh_start, tarikh_end;
        public Rpt_Max_Min_Forosh()
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
        private void Tarikh(Forosh item)
        {
            string day, month, year;
            string[] result = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result = Reg.Split(item.Date_Forosh);
            year = result[0].ToString();
            month = result[1].ToString();
            day = result[2].ToString();
            tarikh_forosh = Convert.ToInt64(year + month + day);
        }
        public void load_Max_Kala()
        {
            try
            {
                listView1.Items.Clear();
                number = 0; jamhe_mablagh_max = 0; jamhe_tehdad_max = 0;
                foreach (Anbar k in lst_Max)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number.ToString();
                    t.Tag = k;

                    t.SubItems.Add(k.Name_kala);
                    t.SubItems.Add(k.Model_kala);

                    t.SubItems.Add(k.Count_kala.ToString());
                    jamhe_tehdad_max += k.Count_kala;
                    t.SubItems.Add(k.Ghimat_forosh.ToString());
                    jamhe_mablagh_max = (k.Ghimat_forosh * k.Count_kala) + jamhe_mablagh_max;
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        public void load_Min_Kala()
        {
            try
            {
                listView2.Items.Clear();
                number = 0; jamhe_mablagh_min = 0; jamhe_tehdad_min = 0;
                foreach (Anbar k in lst_Min)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number.ToString();
                    t.Tag = k;

                    t.SubItems.Add(k.Name_kala);
                    t.SubItems.Add(k.Model_kala);

                    t.SubItems.Add(k.Count_kala.ToString());
                    jamhe_tehdad_min += k.Count_kala;
                    t.SubItems.Add(k.Ghimat_forosh.ToString());
                    jamhe_mablagh_min = (k.Ghimat_forosh * k.Count_kala) + jamhe_mablagh_min;
                    listView2.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        private void Rpt_Max_Min_Forosh_Load(object sender, EventArgs e)
        {
            try
            {
                Date();
                btn_search.Focus();
            }
            catch { }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                //////////////////////از تاریخ////////////////////////////////
                tarikh_start = Convert.ToInt64(txt_year_1.Text + cmb_month_1.Text + cmb_day_1.Text);
                //////////////////////////////////////////////////////////////

                //////////////////////////تا تاریخ///////////////////////////
                tarikh_end = Convert.ToInt64(txt_year_2.Text + cmb_month_2.Text + cmb_day_2.Text);
                //////////////////////////////////////////////////////////////
                if (txt_max.Text != "") number_max = Convert.ToInt32(txt_max.Text);
                else number_max = 3;
                if (txt_min.Text != "") number_min = Convert.ToInt32(txt_min.Text);
                else number_min = 3;
                ////////////////////////////////////////////////
                lst_Anbar.Clear(); lst_Max.Clear(); lst_Min.Clear();

                Max_Min_Kala();
                load_Max_Kala();
                load_Min_Kala();

                lab_jamhe_mablagh_max.Text = jamhe_mablagh_max.ToString();
                lab_jamhe_tedad_max.Text = jamhe_tehdad_max.ToString();
                lab_jamhe_mablegh_min.Text = jamhe_mablagh_min.ToString();
                lab_jamhe_tedad_min.Text = jamhe_tehdad_min.ToString();
            }
            catch { }

        }

        private void Max_Min_Kala()
        {
            foreach (var item in context.Anbars)
            {
                count = 0;

                var q_forosh = context.Foroshes.Where(k => k.Name_kala == item.Name_kala && k.Model_kala == item.Model_kala);
                foreach (var f in q_forosh)
                {
                    Tarikh(f);
                    if (tarikh_start <= tarikh_forosh && tarikh_forosh <= tarikh_end) count = f.Count + count;
                }

                Anbar a = new Anbar(item.Name_kala, item.Model_kala, count, item.Ghimat_vahed, item.Ghimat_forosh);
                lst_Anbar.Add(a);
            }
            //////////////بیشترین اجناس فروخته شده////////////////
            var q_max = lst_Anbar.Where (k=>k.Count_kala !=0).OrderByDescending(k => k.Count_kala);
            foreach (var item in q_max)
            {
                if (number_max == 0) break;
                lst_Max.Add(item);
                number_max--;
            }
            ///////////////////کمترین اجناس فروخته شده////////////
            var q_min = lst_Anbar.OrderBy(k => k.Count_kala);
            foreach (var item in q_min)
            {
                if (number_min == 0) break;
                lst_Min.Add(item);
                number_min--;
            }
            /////////////////////////////////////////////////////
        }

    }
}
