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
    public partial class Frm_Banks : Form
    {
        ContextContainer context = new ContextContainer();
        public Frm_Banks()
        {
            InitializeComponent();
        }
        public void changh()
        {
            var q = context.Banks.Select(s => s);
            dataGridView1.DataSource = q;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;


            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].HeaderText = "بانک ";
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[2].HeaderText = "شعبه";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[3].HeaderText = " شماره حساب ";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[4].HeaderText = " موجودی ";
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[5].HeaderText = " صاحب حساب ";

        }
        private void Frm_Banks_Load(object sender, EventArgs e)
        {
            changh();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                string shomareh_hesab = Convert.ToInt64(txt_shomareh_hesab.Text).ToString();

                Bank b = new Bank(txt_name_bank.Text, txt_shohbeh.Text, txt_shomareh_hesab.Text, Convert.ToInt64(txt_mojodi.Text), txt_saheb_hesab.Text);
                context.Banks.AddObject(b);
                context.SaveChanges();
                changh();
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Bank b = (Bank)dataGridView1.SelectedRows[0].DataBoundItem;
                    b.Name = txt_name_bank.Text;
                    b.Shohbeh = txt_shohbeh.Text;
                    b.Shomareh_Hesab = txt_shomareh_hesab.Text;
                    b.Mojodi = Convert.ToInt64(txt_mojodi.Text);
                    b.Saheb_Hesab = txt_saheb_hesab.Text;
                    context.Banks.ApplyCurrentValues(b);
                    context.SaveChanges();
                }
                else MessageBox.Show("یک رکورد را انتخاب کنید ");
            }

            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                int result = Convert.ToInt32(MessageBox.Show("آیا  مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                if (result == 6)
                {
                    int count = dataGridView1.SelectedRows.Count;
                    while (count != 0)
                    {
                        context.Banks.DeleteObject((Bank)dataGridView1.SelectedRows[0].DataBoundItem);
                        context.SaveChanges();
                        count--;
                    }

                }
            }
            catch { MessageBox.Show("خطا در حذف "); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_name_bank.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_shohbeh.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_shomareh_hesab.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_mojodi.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_saheb_hesab.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();


            }
            catch { }
        }

        private void Frm_Banks_Load_1(object sender, EventArgs e)
        {
            changh();
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                txt_name_bank.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_shohbeh.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_shomareh_hesab.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_mojodi.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_saheb_hesab.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();


            }
            catch { }
        }
    }
}
