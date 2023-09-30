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
    public partial class Rpt_Foroshandegan : Form
    {
        PersianCalendar pc = new PersianCalendar();
        List<SanadForoshandeghan> lst_foroshandegan = new List<SanadForoshandeghan>();
        ContextContainer context = new ContextContainer();
        int day, month, year, number; long jamhe_bestankar,jamhe_bedehkar, tarikh_sanad, tarikh_start, tarikh_end;
        public Rpt_Foroshandegan()
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
                number = 0; jamhe_bestankar = 0; jamhe_bedehkar = 0;
                foreach (SanadForoshandeghan  f in lst_foroshandegan)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number.ToString();
                    t.Tag = f;

                    t.SubItems.Add(f.Shomareh_sanad.ToString ());
                    t.SubItems.Add(f.Name_Foroshandeh );
                    t.SubItems.Add(f.Bedehkar .ToString ());
                    jamhe_bedehkar += f.Bedehkar;
                    t.SubItems.Add(f.Bestankar .ToString ());
                    jamhe_bestankar += f.Bestankar;
                    t.SubItems.Add(f.Date);
                    t.SubItems.Add(f.Tozih );

                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        private void Tarikh(SanadForoshandeghan  item)
        {
            string day, month, year;
            string[] result = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result = Reg.Split(item.Date );
            year = result[0].ToString();
            month = result[1].ToString();
            day = result[2].ToString();
            tarikh_sanad = Convert.ToInt64(year + month + day);
        }
        private void Search()
        {
            var q = context.SanadForoshandeghans.Where(f => f.Name_Foroshandeh.EndsWith (cmb_foroshandeh.Text));
            foreach (var item in q)
            {
                Tarikh(item);
                if (tarikh_start <= tarikh_sanad && tarikh_sanad <= tarikh_end) lst_foroshandegan.Add(item);
            }
        }

        private void Rpt_Foroshandegan_Load(object sender, EventArgs e)
        {
            try
            {
                Date();
                btn_search.Focus();
                foreach (var item in context.Foroshandeghans) cmb_foroshandeh.Items.Add(item);
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
                lst_foroshandegan.Clear();
                if (cmb_foroshandeh.SelectedIndex == 0)
                {
                    var q = context.SanadForoshandeghans.Select (s=>s);
                    foreach (var item in q)
                    {
                        Tarikh(item);
                        if (tarikh_start <= tarikh_sanad && tarikh_sanad <= tarikh_end) lst_foroshandegan.Add(item);
                    }
                }
                else  Search();

                load_form();
                lab_jamhe_bestankar.Text = jamhe_bestankar.ToString();
                lab_jamhe_bedehkar.Text = jamhe_bedehkar.ToString();
            }
            catch { MessageBox.Show("خطا"); }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
