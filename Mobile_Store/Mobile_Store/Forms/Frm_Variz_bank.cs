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
    public partial class Frm_Variz_bank : Form
    {
        PersianCalendar pc = new PersianCalendar();
        ContextContainer context = new ContextContainer();
        int day, month, year; long mablagh_varizi;
        public Frm_Variz_bank()
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
            dataGridView1.Columns[7].Visible = false;


            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[1].HeaderText = "شماره حساب ";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[2].HeaderText = "پرداخت کننده";
            dataGridView1.Columns[3].Width = 105;
            dataGridView1.Columns[3].HeaderText = " مبلغ واریزی ";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[4].HeaderText = " شماره فیش ";
            dataGridView1.Columns[5].Width = 121;
            dataGridView1.Columns[5].HeaderText = "تاریخ ";
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[6].HeaderText = " شرح ";
        }
        private void Frm_Variz_bank_Load(object sender, EventArgs e)
        {
            Date();
            Load_Variz_Emrooz();
        }

        private void Load_Variz_Emrooz()
        {
            var q = context.Varizs.Where(v => v.Date == txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text);
            dataGridView1.DataSource = q;
            changh();
        }

        private void txt_shomare_hesab_TextChanged(object sender, EventArgs e)
        {
            var q = context.Banks.Where(b => b.Shomareh_Hesab == txt_shomare_hesab.Text);
            if (q.Count() > 0)
            {
                foreach (var item in q)
                {
                    txt_mojodi.Text = item.Mojodi.ToString();
                    lab_bank.Text = item.Name;
                    lab_shohbeh.Text = item.Shohbeh;
                }
            }
            else
            {
                txt_mojodi.Text = ""; lab_bank.Text = ""; lab_shohbeh.Text = "";
            }

        }

        private void btn_sabt_Click(object sender, EventArgs e)
        {
            try
            {
                int fish = Convert.ToInt32(txt_shomare_fish.Text);
                var q = context.Varizs.Where(v => v.Shomareh_Fish == fish  &&  v.Shomareh_Hesab ==txt_shomare_hesab .Text );
                if (q.Count() == 0)
                {
                    long shomare_hesab = Convert.ToInt64(txt_shomare_hesab.Text);
                    Bank b = Select_Bank();

                    Variz v = new Variz(txt_shomare_hesab.Text, txt_pardakht_konandeh.Text, Convert.ToInt64(txt_mablegh_varizi.Text), Convert.ToInt32(txt_shomare_fish.Text), txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text, txt_tozih.Text, b);
                    context.Varizs.AddObject(v);
                    context.SaveChanges();
                    Load_Variz_Emrooz();

                    /////////////////////ویرایش حساب بانکی////////////////
                    b.Mojodi = b.Mojodi + Convert.ToInt64(txt_mablegh_varizi.Text);
                    context.Banks.ApplyCurrentValues(b);
                    context.SaveChanges();
                    ///////////////////////////////////////////////////////
                }
                else MessageBox.Show("این شماره فیش ثبت شده است");
            }
            catch (Exception x) { MessageBox.Show("خطا" + x);} 
        }

        private Bank Select_Bank()
        {
            Bank b = new Bank();
            foreach (var item in context.Banks)
            {
                if (item.Shomareh_Hesab == txt_shomare_hesab.Text)
                {
                    b = item;
                }
            }
            return b;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                 txt_shomare_hesab .Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_pardakht_konandeh .Text  = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_mablegh_varizi.Text  = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                mablagh_varizi  =Convert.ToInt64( dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                txt_shomare_fish .Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_tozih  .Text  = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            }
            catch { }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Variz  v = (Variz )dataGridView1.SelectedRows[0].DataBoundItem;
                    v.Shomareh_Hesab = txt_shomare_hesab.Text;
                    v.PardakhtKonandeh = txt_pardakht_konandeh.Text;
                    v.Mablagh =Convert .ToInt64( txt_mablegh_varizi.Text);
                    v.Shomareh_Fish  = Convert.ToInt32(txt_shomare_fish .Text );
                    v.Tozih = txt_tozih.Text;
                    Bank b = Select_Bank();
                   
                    v.Bank = b;
                    context.Varizs .ApplyCurrentValues(v);
                    context.SaveChanges();

                    /////////////////////ویرایش حساب بانکی////////////////
                    b.Mojodi = b.Mojodi - mablagh_varizi ;
                    b.Mojodi = b.Mojodi + Convert.ToInt64(txt_mablegh_varizi.Text);
                    context.Banks.ApplyCurrentValues(b);
                    context.SaveChanges();
                    ///////////////////////////////////////////////////////

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
                    Variz v =(Variz ) dataGridView1.SelectedRows[0].DataBoundItem;
                    context.Varizs .DeleteObject(v);
                    context.SaveChanges();

                    Bank b = Select_Bank();

                    //////ویرایش موجودی بانک/////////////
                    b.Mojodi = b.Mojodi - mablagh_varizi;
                    context.Banks.ApplyCurrentValues(b);
                    context.SaveChanges();
                    ///////////////////////////////////////
                }
            }
            catch { MessageBox.Show("خطا در حذف "); }
        }
    }
}
