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

    public partial class Rpt_Par_Dar_Mot : Form
    {
        PersianCalendar pc = new PersianCalendar();
        List<ParDarMot> lst_pardar = new List<ParDarMot>();
        ContextContainer context = new ContextContainer();
        int day, month, year,number; long mablegh_bedehi,mablegh_bestankar,tarikh_start,tarikh_end,tarikh_pardar;
        public Rpt_Par_Dar_Mot()
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
                number = 0; mablegh_bedehi = 0; mablegh_bestankar = 0;
                foreach (ParDarMot  pd in lst_pardar)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number.ToString () ;
                    t.Tag = pd;

                    t.SubItems.Add(pd.Name_shakhs );
                    t.SubItems.Add(pd.Bedehkar .ToString ());
                    t.SubItems.Add(pd.Bestankar .ToString ());
                    mablegh_bedehi += pd.Bedehkar;
                    mablegh_bestankar += pd.Bestankar;
                    t.SubItems.Add(pd.Date );
                    t.SubItems.Add(pd.Tozih );
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        private void Tarikh(ParDarMot  item)
        {
            string day, month, year;
            string[] result_sodor = new string[3];
            Regex Reg = new Regex(@"\b\/\b");
            result_sodor = Reg.Split(item.Date );
            year = result_sodor[0].ToString();
            month = result_sodor[1].ToString();
            day = result_sodor[2].ToString();
            tarikh_pardar= Convert.ToInt64(year + month + day);
        }

        private void Rpt_Par_Dar_Mot_Load(object sender, EventArgs e)
        {
            Date();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //////////////////////از تاریخ////////////////////////////////
            tarikh_start = Convert.ToInt64(txt_year_1.Text + cmb_month_1.Text + cmb_day_1.Text);
            //////////////////////////////////////////////////////////////

            //////////////////////////تا تاریخ///////////////////////////
            tarikh_end = Convert.ToInt64(txt_year_2.Text + cmb_month_2.Text + cmb_day_2.Text);
            //////////////////////////////////////////////////////////////

            lst_pardar.Clear();

            var q = context.ParDarMots.Where(pd => pd.Name_shakhs.StartsWith (txt_shakhs.Text) || pd.Name_shakhs .EndsWith (txt_shakhs .Text ));
            if (txt_shakhs.Text  =="")
            {
                foreach (var item in context .ParDarMots )
                {
                    Tarikh(item);
                    if (tarikh_start <= tarikh_pardar && tarikh_pardar <= tarikh_end) lst_pardar.Add(item);
                }
            }
            else
            {
                foreach (var item in q)  lst_pardar.Add(item);
            }
            load_form();
            lab_mablegh_bedehi.Text = mablegh_bedehi.ToString();
            lab_bestankar.Text = mablegh_bestankar.ToString();

        }
    }
}
