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
    public partial class Frm_Nkala : Form
    {
        ContextContainer context = new ContextContainer();
        public Frm_Nkala()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Nkala nk = new Nkala(txt_nkala.Text);
                context.Nkalas.AddObject(nk);
                context.SaveChanges();
                changh();
            }
            catch 
            {
                MessageBox.Show("اطلاعات را درست وارد کنید ");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Kala f_k = new Frm_Kala();
            f_k.ShowDialog();
            this.Hide();
        }

        private void Frm_Nkala_Load(object sender, EventArgs e)
        {
            changh();
            
        }

        public void changh()
        {
            var q = context.Nkalas.Select(s => s);
            dataGridView1.DataSource = q;

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].HeaderText = "کد کالا";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[1].HeaderText = " نام کالا";
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                int result = Convert.ToInt32(MessageBox.Show("آیا شما مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                if (result == 6)
                {
                    int count = dataGridView1.SelectedRows.Count;
                    while (count != 0)
                    {
                        context.Nkalas .DeleteObject((Nkala)dataGridView1.SelectedRows[0].DataBoundItem);
                        context.SaveChanges();
                        count--;
                    }

                }
            }
            catch (Exception x) { MessageBox.Show(x + "  :شماره خطا"); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_nkala.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            }
            catch  {}
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Nkala nk = (Nkala)dataGridView1.SelectedRows[0].DataBoundItem;
                    nk.Name = txt_nkala.Text;
                    context.Nkalas .ApplyCurrentValues(nk);
                    context.SaveChanges();
                }
                else MessageBox.Show("یک رکورد را انتخاب کنید ");
            }
            catch 
            {
                MessageBox.Show("اطلاعات را درست وارد کنید ");
            }
        }
    }
}
