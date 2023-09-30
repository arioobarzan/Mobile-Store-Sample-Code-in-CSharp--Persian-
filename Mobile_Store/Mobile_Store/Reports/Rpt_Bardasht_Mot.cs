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
    public partial class Rpt_Bardasht_Mot : Form
    {
        PersianCalendar pc = new PersianCalendar();
        List<BardashtMot > lst_bardasht = new List<BardashtMot >();
        ContextContainer context = new ContextContainer();
        int day, month, year, number; long jamhe_mablagh,tarikh_bardasht,tarikh_start,tarikh_end;
        public Rpt_Bardasht_Mot()
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
                number = 0; jamhe_mablagh = 0;
                foreach (BardashtMot  bm in lst_bardasht)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number.ToString();
                    t.Tag = bm;

                    t.SubItems.Add(bm.Mablagh .ToString ());
                    t.SubItems.Add(bm.Date );
                    t.SubItems.Add(bm.Tozih );
                    jamhe_mablagh  += bm.Mablagh;
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        private void Tarikh(BardashtMot  item)
        {
            string day, month, year;
            string[] result = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result = Reg.Split(item.Date );
            year = result[0].ToString();
            month = result[1].ToString();
            day = result[2].ToString();
            tarikh_bardasht = Convert.ToInt64(year + month + day);
        }
        private void Rpt_Bardasht_Mot_Load(object sender, EventArgs e)
        {
            Date();
            btn_search.Focus();
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //////////////////////از تاریخ////////////////////////////////
            tarikh_start = Convert.ToInt64(txt_year_1.Text + cmb_month_1.Text + cmb_day_1.Text);
            //////////////////////////////////////////////////////////////

            //////////////////////////تا تاریخ///////////////////////////
            tarikh_end = Convert.ToInt64(txt_year_2.Text + cmb_month_2.Text + cmb_day_2.Text);
            //////////////////////////////////////////////////////////////

            lst_bardasht.Clear();

            foreach (var item in context.BardashtMots )
            {
                Tarikh(item);
                if (tarikh_start <= tarikh_bardasht && tarikh_bardasht <= tarikh_end) lst_bardasht.Add(item);
            }
            load_form();
            lab_jamhe_mablagh.Text = jamhe_mablagh.ToString();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
