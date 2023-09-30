using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mobile_Store.Forms
{
    public partial class Frm_sabt_Check_pas_shode : Form
    {
        ContextContainer context = new ContextContainer();
        public Frm_sabt_Check_pas_shode()
        {
            InitializeComponent();
        }
        public void changh_1()
        {

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;


            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[8].HeaderText = "تاریخ چک ";
            dataGridView1.Columns[9].Width = 115;
            dataGridView1.Columns[9].HeaderText = "شماره حساب";
            dataGridView1.Columns[10].Width = 85;
            dataGridView1.Columns[10].HeaderText = " شماره چک ";
            dataGridView1.Columns[11].Width = 105;
            dataGridView1.Columns[11].HeaderText = " مبلغ چک ";
            dataGridView1.Columns[12].Width = 115;
            dataGridView1.Columns[12].HeaderText = " صاحب حساب ";
        }
        public void changh_2()
        {

            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            dataGridView2.Columns[7].Visible = false;
            dataGridView2.Columns[13].Visible = false;
            dataGridView2.Columns[14].Visible = false;
            dataGridView2.Columns[15].Visible = false;
            dataGridView2.Columns[16].Visible = false;


            dataGridView2.Columns[8].Width = 100;
            dataGridView2.Columns[8].HeaderText = "تاریخ چک ";
            dataGridView2.Columns[9].Width = 115;
            dataGridView2.Columns[9].HeaderText = "شماره حساب";
            dataGridView2.Columns[10].Width = 85;
            dataGridView2.Columns[10].HeaderText = " شماره چک ";
            dataGridView2.Columns[11].Width = 105;
            dataGridView2.Columns[11].HeaderText = " مبلغ چک ";
            dataGridView2.Columns[12].Width = 115;
            dataGridView2.Columns[12].HeaderText = " صاحب حساب ";
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                load_check();
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }
        }

        private void load_check()
        {
            if (cmb_search.SelectedIndex == 0)
            {
                var q_check_pass_nashodeh = context.Daryafts.Where(d => d.Saheb_Hesab.StartsWith (txt_search .Text ) && d.Pas_check == "0");
                dataGridView1.DataSource = q_check_pass_nashodeh;
                changh_1();
                var q_check_pass_shodeh = context.Daryafts.Where(d => d.Saheb_Hesab.StartsWith (txt_search .Text ) && d.Pas_check == "1");
                dataGridView2.DataSource = q_check_pass_shodeh;
                changh_2();
            }
            if (cmb_search.SelectedIndex == 1)
            {
                var q_check_pass_nashodeh = context.Daryafts.Where(d => d.Shomareh_check == txt_search.Text && d.Pas_check == "0");
                dataGridView1.DataSource = q_check_pass_nashodeh;
                changh_1();
                var q_check_pass_shodeh = context.Daryafts.Where(d => d.Shomareh_check == txt_search.Text && d.Pas_check == "1");
                dataGridView2.DataSource = q_check_pass_shodeh;
                changh_2();
            }
        }

        private void btn_pass_on_Click(object sender, EventArgs e)
        {
            try
            {
                Daryaft d = (Daryaft)dataGridView1.SelectedRows[0].DataBoundItem;
                d.Pas_check = "1";
                context.Daryafts.ApplyCurrentValues(d);
                context.SaveChanges();
                load_check();
            }
            catch { MessageBox.Show("یک رکورد را انتخاب کنید  "); }
        }

        private void btn_pass_off_Click(object sender, EventArgs e)
        {
            try
            {
                Daryaft d = (Daryaft)dataGridView2.SelectedRows[0].DataBoundItem;
                d.Pas_check = "0";
                context.Daryafts.ApplyCurrentValues(d);
                context.SaveChanges();
                load_check();
            }
            catch { MessageBox.Show("یک رکورد را انتخاب کنید  "); }
        }


    }
}
