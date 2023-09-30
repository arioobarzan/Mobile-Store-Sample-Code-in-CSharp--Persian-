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

namespace Mobile_Store.Forms
{
    public partial class Frm_sar_resid_aghsat : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year;
        long tarikh_ghest, tarikh_amroz;
        List<Aghsat> lst_aghsat = new List<Aghsat>();
        PersianCalendar pc = new PersianCalendar();
        public Frm_sar_resid_aghsat()
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
        public void load_form()
        {
            try
            {
                listView1.Items.Clear();
                foreach (Aghsat a in lst_aghsat)
                {
                    ListViewItem t = new ListViewItem();
                    t.Text = a.Eshterak .ToString ();
                    t.Tag = a;

                    t.SubItems.Add(a.Factor.ToString () );
                    t.SubItems.Add(a.Shomare_ghest.ToString () );
                    t.SubItems.Add(a.Mablegh_ghest .ToString ());
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }

        private void Frm_sar_resid_aghsat_Load(object sender, EventArgs e)
        {
            Date();
            //////////////////////اقساط امروز/////////////////////
            string date = txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text;
            load_aghsat_amrooz(date );
            ///////////////////////////////////////////////////////

            /////////////////////////////اقساط معوقه/////////////
            Tarikh_amrooz(date);
            load_aghsat_aghab_oftade();
            //////////////////////////////////////////////////////
        }

        public void  load_aghsat_amrooz(string date)
        {
            var q_sar_ghest_amrooz = context.Aghsats.Where (s => s.Date_pardakht == date);
            dataGridView1.DataSource = q_sar_ghest_amrooz;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;


            dataGridView1.Columns[1].Width = 108;
            dataGridView1.Columns[1].HeaderText = "اشتراک ";
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[2].HeaderText = "فاکتور";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[3].HeaderText = " شماره قسط ";
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[4].HeaderText = " مبلغ قسط ";

        }

        public void load_aghsat_aghab_oftade()
        {
            lst_aghsat.Clear();

            foreach (var item in context.Aghsats )
            {
                /////////////بدست آوردن تاریخ قسط ها///////////
                Tarikh_ghest(item);
                /////////////////////////////////////////////////
                if (tarikh_ghest < tarikh_amroz && item.Pass =="0") lst_aghsat.Add(item);

            }
            load_form();

        }

        private void Tarikh_ghest(Aghsat item)
        {
            string day, month, year;
            string[] result_sodor = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result_sodor = Reg.Split(item.Date_pardakht);
            year = result_sodor[0].ToString();
            month = result_sodor[1].ToString();
            day = result_sodor[2].ToString();
            tarikh_ghest = Convert.ToInt64(year + month + day);
        }

        private void Tarikh_amrooz(string date)
        {
            string day, month, year;
            string[] result_sodor = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result_sodor = Reg.Split(date);
            year = result_sodor[0].ToString();
            month = result_sodor[1].ToString();
            day = result_sodor[2].ToString();
            tarikh_amroz = Convert.ToInt64(year + month + day);
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            ///////////////////////قسط های امروز////////////////
            string date = txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text;
            load_aghsat_amrooz(date);
            ////////////////////////////قسط های معوقه//////////
            Tarikh_amrooz(date);
            load_aghsat_aghab_oftade();
            ////////////////////////////////////////
        }
    }
}
