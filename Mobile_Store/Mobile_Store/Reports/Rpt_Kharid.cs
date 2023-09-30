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
    public partial class Rpt_Kharid : Form
    {
        PersianCalendar pc = new PersianCalendar();
        List<Kharid > lst_kharid = new List<Kharid >();
        List<Kharid> list = new List<Kharid>();
        ContextContainer context = new ContextContainer();
        int day, month, year, number, jamhe_tehdad; long jamhe_mablagh, tarikh_kharid, tarikh_start, tarikh_end; string date_start, date_end;
        public Rpt_Kharid()
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
                number = 0; jamhe_mablagh = 0; jamhe_tehdad = 0;
                foreach (Kharid  k in lst_kharid)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number.ToString();
                    t.Tag = k;

                    t.SubItems.Add(k.Name_Foroshandeh );
                    t.SubItems.Add(k.Name_kala );
                    t.SubItems.Add(k.Model_kala );
                    t.SubItems.Add(k.Serial);
                    t.SubItems.Add(k.Count .ToString ());
                    jamhe_tehdad += k.Count;
                    t.SubItems.Add(k.Ghimat_vahed.ToString());
                    jamhe_mablagh = (k.Ghimat_vahed * k.Count ) + jamhe_mablagh ;
                    t.SubItems.Add(k.Date_kharid);
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        private void Search()
        {
            var q_list = list.OrderBy(o => o.Date_kharid);
            if (cmb_type_search.SelectedIndex == 0)
                foreach (var item in q_list) lst_kharid.Add(item);
            if (cmb_type_search.SelectedIndex == 1)
            {
                var q = q_list.Where(s => s.Name_Foroshandeh.StartsWith(cmb_foroshandeh.Text) || s.Name_Foroshandeh.EndsWith(cmb_foroshandeh.Text));
                foreach (var item in q) lst_kharid.Add(item);
            }
            if (cmb_type_search.SelectedIndex == 2)
            {
                var q = q_list.Where(s => s.Name_kala == cmb_name_kala.Text && s.Model_kala == cmb_model.Text);
                foreach (var item in q) lst_kharid.Add(item);
            }
            if (cmb_type_search.SelectedIndex == 3)
            {
                int fact = Convert.ToInt32(txt_factor.Text);
                var q = context.Kharids.Where(s => s.Factor == fact);
                foreach (var item in q) lst_kharid.Add(item);
            }
        }
        private void Tarikh(Kharid  item)
        {
            string day, month, year;
            string[] result = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result = Reg.Split(item.Date_kharid);
            year = result[0].ToString();
            month = result[1].ToString();
            day = result[2].ToString();
            tarikh_kharid = Convert.ToInt64(year + month + day);
        }

        private void Rpt_Kharid_Load(object sender, EventArgs e)
        {
            try
            {
                Date();
                btn_search.Focus();
                foreach (var item in context.Foroshandeghans) cmb_foroshandeh.Items.Add(item);
                foreach (var item in context.Nkalas) cmb_name_kala.Items.Add(item);
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
                list.Clear();
                lst_kharid.Clear();
                foreach (var item in context.Kharids)
                {
                    Tarikh(item);
                    if (tarikh_start <= tarikh_kharid && tarikh_kharid <= tarikh_end) list.Add(item);
                }
                Search();

                load_form();
                lab_jamhe_mablagh.Text = jamhe_mablagh.ToString();
                lab_jamhe_tedad.Text = jamhe_tehdad.ToString();
                date_start = txt_year_1.Text + "/" + cmb_month_1.Text + "/" + cmb_day_1.Text;
                date_end = txt_year_2.Text + "/" + cmb_month_2.Text + "/" + cmb_day_2.Text;
            }
            catch { MessageBox.Show("خطا"); }
        }


        private void cmb_type_search_SelectedValueChanged(object sender, EventArgs e)
        {
            cmb_foroshandeh.Text = ""; txt_factor.Text = "";
            if (cmb_type_search.SelectedIndex ==0)
            {
                lab_froshandeh.Enabled = false ;
                cmb_foroshandeh.Enabled = false ;
                lab_name_kala.Enabled = false ;
                cmb_name_kala.Enabled = false ;
                lab_model.Enabled = false ;
                cmb_model.Enabled = false ;
                lab_factor.Enabled = false;
                txt_factor.Enabled = false;
            }
            if (cmb_type_search.SelectedIndex == 1)
            {
                lab_froshandeh.Enabled = true ;
                cmb_foroshandeh.Enabled = true ;
                lab_name_kala.Enabled = false;
                cmb_name_kala.Enabled = false;
                lab_model.Enabled = false;
                cmb_model.Enabled = false;
                lab_factor.Enabled = false;
                txt_factor.Enabled = false;
            }
            if (cmb_type_search.SelectedIndex == 2)
            {
                lab_froshandeh.Enabled = false;
                cmb_foroshandeh.Enabled = false;
                lab_name_kala.Enabled = true ;
                cmb_name_kala.Enabled = true ;
                lab_model.Enabled = true;
                cmb_model.Enabled = true;
                lab_factor.Enabled = false;
                txt_factor.Enabled = false;
            }
            if (cmb_type_search.SelectedIndex == 3)
            {
                lab_froshandeh.Enabled = false;
                cmb_foroshandeh.Enabled = false;
                lab_name_kala.Enabled = false;
                cmb_name_kala.Enabled = false;
                lab_model.Enabled = false;
                cmb_model.Enabled = false;
                lab_factor.Enabled = true ;
                txt_factor.Enabled = true;
            }
        }
        private void cmb_name_kala_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cmb_model.Items.Clear();
                var q = context.Kalas.Where(k => k.Name == cmb_name_kala.Text);
                foreach (var item in q) cmb_model.Items.Add(item);
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                Rpt_View_Gozaresh_Kharid f = new Rpt_View_Gozaresh_Kharid(lst_kharid, date_start, date_end, jamhe_tehdad, jamhe_mablagh);
                f.ShowDialog();
            }
            catch { }
        }


    }
}
