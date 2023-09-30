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
    public partial class Frm_Moshtariha : Form
    {
        ContextContainer context = new ContextContainer();
        public Frm_Moshtariha()
        {
            InitializeComponent();
        }

        public void changh()
        {
            var q = context.Coustomers.Select(s => s);
            dataGridView1.DataSource = q;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;

            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].HeaderText = "نام ";
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[2].HeaderText = "نام خانوادگی ";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[3].HeaderText = " تلفن ";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[4].HeaderText = " موبایل ";
            dataGridView1.Columns[5].Width = 110;
            dataGridView1.Columns[5].HeaderText = " فروشگاه ";
            dataGridView1.Columns[6].Width = 160;
            dataGridView1.Columns[6].HeaderText = " آدرس ";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                string tel = Convert.ToInt64(txt_tel.Text).ToString();
                string mobile = Convert.ToInt64(txt_mobile.Text).ToString();
                Coustomer c = new Coustomer(txt_name.Text, txt_family.Text, txt_tel.Text, txt_mobile.Text, txt_foroshgah.Text, txt_adress.Text, 0, 0);

                context.Coustomers.AddObject(c);

                context.SaveChanges();
                changh();
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void Frm_Moshtariha_Load_1(object sender, EventArgs e)
        {
            changh();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Coustomer coust = (Coustomer)dataGridView1.SelectedRows[0].DataBoundItem;
                    coust.Name = txt_name.Text;
                    coust.Family = txt_family.Text;
                    coust.Tel = txt_tel.Text;
                    coust.Mobile = txt_mobile.Text;
                    coust.Adress = txt_adress.Text;
                    coust.Foroshghah = txt_foroshgah.Text;

                    context.Coustomers.ApplyCurrentValues(coust);
                    context.SaveChanges();
                }
                else MessageBox.Show("یک رکورد را انتخاب کنید ");
            }

            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_family.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_tel.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_mobile.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_foroshgah.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txt_adress.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            }
            catch {  }
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
                        context.Coustomers .DeleteObject((Coustomer )dataGridView1.SelectedRows[0].DataBoundItem);
                        context.SaveChanges();
                        count--;
                    }

                }
            }
            catch { MessageBox.Show("خطا در حذف "); }
        }


    }
}
