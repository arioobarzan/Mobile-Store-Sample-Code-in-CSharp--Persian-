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
    public partial class Frm_bardasht_bank : Form
    {
        PersianCalendar pc = new PersianCalendar();
        ContextContainer context = new ContextContainer();
        int day, month, year; long mablagh_bardashti;
        public Frm_bardasht_bank()
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
            dataGridView1.Columns[6].Visible = false;


            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[1].HeaderText = "شماره حساب ";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[2].HeaderText = "دریافت کننده";
            dataGridView1.Columns[3].Width = 105;
            dataGridView1.Columns[3].HeaderText = " مبلغ واریزی ";
            dataGridView1.Columns[4].Width = 121;
            dataGridView1.Columns[4].HeaderText = "تاریخ ";
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[5].HeaderText = " شرح ";
        }
        private void Load_Bardasht_Emrooz()
        {
            var q = context.Bardashts .Where(v => v.Date == txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text);
            dataGridView1.DataSource = q;
            changh();
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

        private void Frm_bardasht_bank_Load(object sender, EventArgs e)
        {
            Date();
            Load_Bardasht_Emrooz();
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
                long shomare_hesab = Convert.ToInt64(txt_shomare_hesab.Text);
                Bank b = Select_Bank();
                if (Convert.ToInt64(txt_mablegh_bardashti.Text) > b.Mojodi) { MessageBox.Show("مبلغ برداشتی بیش از موجودی است"); }
                else
                {
                    Bardasht bar = new Bardasht(txt_shomare_hesab.Text, txt_daryaft_konandeh.Text, Convert.ToInt64(txt_mablegh_bardashti.Text), txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text, txt_tozih.Text, b);
                    context.Bardashts.AddObject(bar);
                    context.SaveChanges();
                    Load_Bardasht_Emrooz();

                    ///////////////////ویرایش حساب بانکی////////////////
                    b.Mojodi = b.Mojodi - Convert.ToInt64(txt_mablegh_bardashti.Text);
                    context.Banks.ApplyCurrentValues(b);
                    context.SaveChanges();
                    /////////////////////////////////////////////////////
                }
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); } 
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Bank b = Select_Bank();
                    b.Mojodi = b.Mojodi + mablagh_bardashti;
                    if (Convert.ToInt64(txt_mablegh_bardashti.Text) > b.Mojodi) { MessageBox.Show("مبلغ برداشتی بیش از موجودی است"); }
                    else
                    {
                    
                    Bardasht  bar = (Bardasht )dataGridView1.SelectedRows[0].DataBoundItem;
                    bar.Shomareh_Hesab = txt_shomare_hesab.Text;
                    bar.DaryaftKonandeh  = txt_daryaft_konandeh.Text;
                    bar.Mablagh = Convert.ToInt64(txt_mablegh_bardashti.Text);
                    bar.Tozih = txt_tozih.Text;
                    

                    
                        bar.Bank = b;
                        context.Bardashts.ApplyCurrentValues(bar);
                        context.SaveChanges();

                        /////////////////////ویرایش حساب بانکی////////////////
                        
                        b.Mojodi = b.Mojodi - Convert.ToInt64(txt_mablegh_bardashti.Text);
                        context.Banks.ApplyCurrentValues(b);
                        context.SaveChanges();
                        ///////////////////////////////////////////////////////
                    }
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
                    Bardasht  v = (Bardasht )dataGridView1.SelectedRows[0].DataBoundItem;
                    context.Bardashts .DeleteObject(v);
                    context.SaveChanges();

                    Bank b = Select_Bank();

                    //////ویرایش موجودی بانک/////////////
                    b.Mojodi = b.Mojodi + mablagh_bardashti;
                    context.Banks.ApplyCurrentValues(b);
                    context.SaveChanges();
                    ///////////////////////////////////////
                }
            }
            catch { MessageBox.Show("خطا در حذف "); }
        }




        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
                                try
            {
                txt_shomare_hesab.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_daryaft_konandeh.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_mablegh_bardashti.Text  = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                mablagh_bardashti = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                txt_tozih.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch { }
        
        }


    }
}
