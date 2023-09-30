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
    public partial class Frm_Kala : Form
    {
        ContextContainer context = new ContextContainer();
        public Frm_Kala()
        {
            InitializeComponent();
        }

        private void Frm_Kala_Load(object sender, EventArgs e)
        {
            foreach (var item in context.Nkalas)
            {
                cmb_nkala.Items.Add(item);
            }
            changh();
        }
        public void changh()
        {
            var q = context.Kalas.Where (s => s.Name ==cmb_nkala .Text );
            dataGridView1.DataSource = q;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[1].HeaderText = "نام کالا";
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[2].HeaderText = " مدل کالا";
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Kala k = new Kala();
                k.Name = cmb_nkala.Text;
                k.Model = txt_model.Text;
                context.Kalas.AddObject(k);
                context.SaveChanges();
                changh();
            }
            catch { MessageBox.Show("اطلاعات را درست وارد کنید "); }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cmb_nkala.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_model.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            }
            catch { }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Kala k = (Kala)dataGridView1.SelectedRows[0].DataBoundItem;
                    k.Name = cmb_nkala.Text;
                    k.Model = txt_model.Text;
                    context.Kalas.ApplyCurrentValues(k);
                    context.SaveChanges();
                }
                else MessageBox.Show("یک رکورد را انتخاب کنید ");
            }

            catch { MessageBox.Show("اطلاعات را درست وارد کنید "); }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                int result = Convert.ToInt32(MessageBox.Show("آیا  مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                if (result == 6)
                {
                    int count = dataGridView1.SelectedRows.Count;
                    while (count != 0)
                    {
                        context.Kalas.DeleteObject((Kala)dataGridView1.SelectedRows[0].DataBoundItem);
                        context.SaveChanges();
                        count--;
                    }

                }
            }
            catch { MessageBox.Show("خطا در حذف "); }
        }

        private void cmb_nkala_SelectedValueChanged(object sender, EventArgs e)
        {
            //var q = context.Kalas.Where(k => k.Name == cmb_nkala.Text);
            //dataGridView1.DataSource = q;
            changh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
