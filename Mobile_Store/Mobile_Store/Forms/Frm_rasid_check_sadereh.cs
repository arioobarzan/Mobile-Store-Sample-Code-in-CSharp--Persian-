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
    public partial class Frm_rasid_check_sadereh : Form
    {
        PersianCalendar pc = new PersianCalendar();
        ContextContainer context = new ContextContainer();
        int day, month, year; long mablegh_check;
        public Frm_rasid_check_sadereh()
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
        public void changh()
        {

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;


            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[5].HeaderText = "تاریخ چک ";
            dataGridView1.Columns[6].Width = 110;
            dataGridView1.Columns[6].HeaderText = "شماره حساب";
            dataGridView1.Columns[7].Width = 90;
            dataGridView1.Columns[7].HeaderText = " شماره چک ";
            dataGridView1.Columns[8].Width = 93;
            dataGridView1.Columns[8].HeaderText = " مبلغ چک ";
            dataGridView1.Columns[9].Width = 135;
            dataGridView1.Columns[9].HeaderText = " در وجه  ";
        }

        private void Load_Data()
        {
            var q = context.Pardakhts .Select(s => s);
            dataGridView1.DataSource = q;
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_rasid_check_sadereh_Load(object sender, EventArgs e)
        {
            Date();
            var q = context.Pardakhts.Where(p => p.Date_sodoor == txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text);
            dataGridView1.DataSource = q;
           changh();

           Mablegh_Check();
        }

        private void Mablegh_Check()
        {
            mablegh_check = 0;
            int count = dataGridView1.RowCount - 1;
            while (count != 0)
            {
                mablegh_check = Convert.ToInt64(dataGridView1.Rows[count - 1].Cells[8].Value.ToString()) + mablegh_check;
                count--;
            }
            lab_mablegh_check.Text = mablegh_check.ToString();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_shomareh_hesab.Text != "")
            {
                var q = context.Pardakhts.Where(p => p.Shomareh_Hesab == txt_shomareh_hesab.Text);
                dataGridView1.DataSource = q;
            }
            else
            {
                var q = context.Pardakhts.Where(p => p.Date_sodoor == txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text );
                dataGridView1.DataSource = q;
            }
                changh();

            Mablegh_Check();
        }
    }
}
