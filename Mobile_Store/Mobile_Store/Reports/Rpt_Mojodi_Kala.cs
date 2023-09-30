using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;


namespace Mobile_Store.Reports
{
    public partial class Rpt_Mojodi_Kala : Form
    {
        PersianCalendar pc = new PersianCalendar();
        ContextContainer context = new ContextContainer();
        int day, month, year, number, jamhe_tehdad; long jamhe_mablagh; string tarikh;
        List<Anbar> lst_anbar = new List<Anbar>();
        public Rpt_Mojodi_Kala()
        {
            InitializeComponent();
        }
        private void Date()
        {
            DateTime dt = DateTime.Today;
            year = pc.GetYear(dt);
            month = pc.GetMonth(dt);
            day = pc.GetDayOfMonth(dt);
            string str_day, str_month, str_year;
            if (day % 10 == day) str_day = "0" + day;
            else str_day = day.ToString();
            if (month % 10 == month) str_month = "0" + month;
            else str_month = month.ToString();
            str_year = year.ToString();
            tarikh = str_year + "/" + str_month + "/" + str_day;

        }
        public void load_form()
        {
            try
            {
                listView1.Items.Clear();
                number = 0; jamhe_mablagh = 0; jamhe_tehdad = 0;
                foreach (Anbar k in lst_anbar)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number + "";
                    t.Tag = k;

                    t.SubItems.Add(k.Name_kala);
                    t.SubItems.Add(k.Model_kala);
                    t.SubItems.Add(k.Count_kala.ToString());
                    jamhe_tehdad += k.Count_kala;
                    t.SubItems.Add(k.Ghimat_vahed.ToString());
                    jamhe_mablagh = (k.Ghimat_vahed * k.Count_kala) + jamhe_mablagh;
                    t.SubItems.Add(k.Ghimat_forosh.ToString());
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Rpt_Mojodi_Kala_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in context.Nkalas) cmb_name_kala.Items.Add(item);
            }
            catch { }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            lst_anbar.Clear();
            if (cmb_name_kala.Text == "تمام کالا")
            {
                if (chk.Checked)
                {
                    var q = context.Anbars.Select(k => k);
                    foreach (var item in q) lst_anbar.Add(item);
                }
                else
                {
                    var q = context.Anbars.Where(k => k.Count_kala != 0);
                    foreach (var item in q) lst_anbar.Add(item);
                }
            }
            else
            {
                if (chk.Checked)
                {
                    var q = context.Anbars.Where(k => k.Name_kala == cmb_name_kala.Text && k.Model_kala == cmb_model.Text);
                    foreach (var item in q) lst_anbar.Add(item);
                }
                else
                {
                    var q = context.Anbars.Where(k => k.Name_kala == cmb_name_kala.Text && k.Model_kala == cmb_model.Text && k.Count_kala != 0);
                    foreach (var item in q) lst_anbar.Add(item);
                }
            }
            load_form();
            lab_jamhe_tedad.Text = jamhe_tehdad.ToString();
            lab_jamhe_mablagh.Text = jamhe_mablagh.ToString();
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

        private void btn_print_Click(object sender, EventArgs e)
        {
            Date();
            Rpt_View_Anbar f = new Rpt_View_Anbar(lst_anbar, tarikh, jamhe_tehdad, jamhe_mablagh);
            f.ShowDialog();
        }


    }
}
