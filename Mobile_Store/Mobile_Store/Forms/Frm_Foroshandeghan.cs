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
    public partial class Frm_Foroshandeghan : Form
    {
        ContextContainer context = new ContextContainer();
        public Frm_Foroshandeghan()
        {
            InitializeComponent();
        }
        public void changh()
        {
            var q = context.Foroshandeghans.Select(s => s);
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
            dataGridView1.Columns[5].Width = 120;
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
                Foroshandeghan f = new Foroshandeghan(txt_name.Text, txt_family.Text, txt_tel.Text, txt_mobile.Text, txt_foroshghah.Text, txt_adress.Text, 0, 0);

                context.Foroshandeghans.AddObject(f);

                context.SaveChanges();
                changh();
            }
            catch { MessageBox.Show("اطلاعات را درست وارد کنید "); }
        }

        private void Frm_Foroshandeghan_Load(object sender, EventArgs e)
        {
            changh();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Foroshandeghan f = (Foroshandeghan)dataGridView1.SelectedRows[0].DataBoundItem;
                    f.Name = txt_name.Text;
                    f.Family = txt_family.Text;
                    f.Tel = txt_tel.Text;
                    f.Mobile = txt_mobile.Text;
                    f.Adress = txt_adress.Text;
                    f.Foroshghah = txt_foroshghah.Text;

                    context.Foroshandeghans.ApplyCurrentValues(f);
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
                txt_foroshghah.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txt_adress.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            }
            catch { }
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
                        context.Foroshandeghans .DeleteObject((Foroshandeghan )dataGridView1.SelectedRows[0].DataBoundItem);
                        context.SaveChanges();
                        count--;
                    }

                }
            }
            catch { MessageBox.Show("خطا در حذف "); }
        }
    }
}
