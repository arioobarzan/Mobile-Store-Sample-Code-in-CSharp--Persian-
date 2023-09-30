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
    public partial class Frm_Eshterak : Form
    {
        ContextContainer context = new ContextContainer();
        public Frm_Eshterak()
        {
            InitializeComponent();
        }

        public void changh()
        {
            var q = context.Moshtarekins .Select(s => s);
            dataGridView1.DataSource = q;

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].HeaderText = "اشتراک";
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[2].HeaderText = "نام ";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[3].HeaderText = " نام خانوادگی ";
            dataGridView1.Columns[4].Width = 110;
            dataGridView1.Columns[4].HeaderText = " تلفن ";
            dataGridView1.Columns[5].Width = 110;
            dataGridView1.Columns[5].HeaderText = " موبایل ";
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[6].HeaderText = " شماره چک ";
            dataGridView1.Columns[7].Width = 120;
            dataGridView1.Columns[7].HeaderText = " شماره حساب ";
            dataGridView1.Columns[8].Width = 160;
            dataGridView1.Columns[8].HeaderText = "محل کار ";
            dataGridView1.Columns[9].Width = 160;
            dataGridView1.Columns[9].HeaderText = "آدرس ";
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
                        context.Moshtarekins .DeleteObject((Moshtarekin )dataGridView1.SelectedRows[0].DataBoundItem);
                        context.SaveChanges();
                        count--;
                    }

                }
            }
            catch { MessageBox.Show("خطا در حذف "); }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Moshtarekin  m = (Moshtarekin )dataGridView1.SelectedRows[0].DataBoundItem;
                    m.Eshterak =Convert .ToInt64 ( txt_eshterak.Text);
                    m.Name = txt_name.Text;
                    m.Family = txt_family.Text;
                    m.Tel = txt_tel.Text;
                    m.Mobile = txt_mobile.Text;
                    m.Shomareh_Hesab = txt_shomareh_hesab.Text;
                    m.Shomareh_check = txt_shomareh_check.Text;
                    m.Adress_kar = txt_adress_kar.Text;
                    m.Adress = txt_adress.Text;
                    
                    context.Moshtarekins .ApplyCurrentValues(m);
                    context.SaveChanges();
                }
                else MessageBox.Show("یک رکورد را انتخاب کنید ");
            }

            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void txt_add_Click(object sender, EventArgs e)
        {
            try
            {
                long eshterak=Convert.ToInt64 (txt_eshterak .Text );
                var q = context.Moshtarekins.Where(s => s.Eshterak == eshterak);
                if (q.Count() > 0) { MessageBox.Show("این شماره اشتراک ثبت شده است"); }
                else
                {
                    if (txt_eshterak.Text == "0") { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
                    else
                    {
                        string tel = Convert.ToInt64(txt_tel.Text).ToString();
                        string mobile = Convert.ToInt64(txt_mobile.Text).ToString();
                        string shomare_hesab = Convert.ToInt64(txt_shomareh_hesab.Text).ToString();
                        string shomare_check = Convert.ToInt64(txt_shomareh_check.Text).ToString();
                        Moshtarekin m = new Moshtarekin(Convert.ToInt64(txt_eshterak.Text), txt_name.Text, txt_family.Text, txt_tel.Text, txt_mobile.Text, txt_shomareh_hesab.Text, txt_shomareh_check.Text, txt_adress_kar.Text, txt_adress.Text);

                        context.Moshtarekins.AddObject(m);
                        context.SaveChanges();
                        changh();
                    }
                }
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void Frm_Eshterak_Load(object sender, EventArgs e)
        {
            changh();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_eshterak.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_name.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_family.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_tel.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_mobile.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txt_shomareh_check .Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txt_shomareh_hesab .Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                txt_adress_kar .Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txt_adress.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();

            }
            catch { }
        }


    }
}
