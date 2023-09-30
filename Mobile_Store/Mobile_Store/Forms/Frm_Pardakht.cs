using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
namespace Mobile_Store.Forms
{
    public partial class Frm_Pardakht : Form
    {
        ContextContainer contex = new ContextContainer();
        int day, month, year, number;
        List<Pardakht> lst_pardakht = new List<Pardakht>();
        PersianCalendar pc = new PersianCalendar();
        public Frm_Pardakht()
        {
            InitializeComponent();
        }
        public void load_form()
        {
            try
            {
                listView1.Items.Clear();
                number = 0;
                foreach (Pardakht p in lst_pardakht)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number + "";
                    t.Tag = p;

                    t.SubItems.Add(p.Date_check);
                    t.SubItems.Add(p.Shomareh_Hesab);
                    t.SubItems.Add(p.Shomareh_check);
                    t.SubItems.Add(p.Mablegh_check.ToString());
                    t.SubItems.Add(p.Dar_vajhe);
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        private void Date()
        {
            DateTime dt = DateTime.Today;
            year = pc.GetYear(dt);
            month = pc.GetMonth(dt);
            day = pc.GetDayOfMonth(dt);
            if (day % 10 == day)
            {
                cmb_day_naghdi.Text = "0" + day;
                cmb_day_sodor.Text = "0" + day;
            }
            else
            {
                cmb_day_naghdi.Text = day.ToString();
                cmb_day_sodor.Text = day.ToString ();
            }
            if (month % 10 == month)
            {
                cmb_month_naghdi.Text = "0" + month;
                cmb_month_sodor.Text = "0" + month;
            }
            else
            {
                cmb_month_naghdi.Text = month.ToString();
                cmb_month_sodor.Text = month.ToString ();
            }
            txt_year_naghdi.Text = year.ToString();
            txt_year_sodor.Text = year.ToString();
            txt_year_check.Text = year.ToString();
        }
        private void cmb_type_pardakht_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_type_pardakht.SelectedIndex == 0)
                {
                    label8.Enabled = true;
                    txt_mablegh_naghdi.Enabled = true;
                    label11.Enabled = true;
                    cmb_day_naghdi.Enabled = true;
                    label10.Enabled = true;
                    cmb_month_naghdi.Enabled = true;
                    label9.Enabled = true;
                    txt_year_naghdi.Enabled = true;
                    btn_pardakht_naghdi.Enabled = true;
                    label12.Enabled = false;
                    cmb_day_sodor.Enabled = false;
                    label14.Enabled = false;
                    cmb_month_sodor.Enabled = false;
                    label13.Enabled = false;
                    txt_year_sodor.Enabled = false;
                    label15.Enabled = false;
                    cmb_day_check.Enabled = false;
                    label17.Enabled = false;
                    cmb_month_check.Enabled = false;
                    label16.Enabled = false;
                    txt_year_check.Enabled = false;
                    label18.Enabled = false;
                    txt_shomareh_hesab.Enabled = false;
                    label19.Enabled = false;
                    txt_shomareh_check.Enabled = false;
                    label20.Enabled = false;
                    txt_mablegh_check.Enabled = false;
                    label21.Enabled = false;
                    txt_dar_vajhe.Enabled = false;
                    label22.Enabled = false;
                    label23.Enabled = false;
                    lab_bank.Enabled = false;
                    btn_add.Enabled = false;
                    btn_update.Enabled = false;
                    btn_delete.Enabled = false;
                    btn_sabt_Chek.Enabled = false;
                }
                if (cmb_type_pardakht.SelectedIndex == 1)
                {
                    label8.Enabled = false;
                    txt_mablegh_naghdi.Enabled = false;
                    label11.Enabled = false;
                    cmb_day_naghdi.Enabled = false;
                    label10.Enabled = false;
                    cmb_month_naghdi.Enabled = false;
                    label9.Enabled = false;
                    txt_year_naghdi.Enabled = false;
                    btn_pardakht_naghdi.Enabled = false;
                    label12.Enabled = true;
                    cmb_day_sodor.Enabled = true;
                    label14.Enabled = true;
                    cmb_month_sodor.Enabled = true;
                    label13.Enabled = true;
                    txt_year_sodor.Enabled = true;
                    label15.Enabled = true;
                    cmb_day_check.Enabled = true;
                    label17.Enabled = true;
                    cmb_month_check.Enabled = true;
                    label16.Enabled = true;
                    txt_year_check.Enabled = true;
                    label18.Enabled = true;
                    txt_shomareh_hesab.Enabled = true;
                    label19.Enabled = true;
                    txt_shomareh_check.Enabled = true;
                    label20.Enabled = true;
                    txt_mablegh_check.Enabled = true;
                    label21.Enabled = true;
                    txt_dar_vajhe.Enabled = true;
                    label22.Enabled = true;
                    label23.Enabled = true;
                    lab_bank.Enabled = true;
                    btn_add.Enabled = true;
                    btn_update.Enabled = true;
                    btn_delete.Enabled = true;
                    btn_sabt_Chek.Enabled = true;
                    txt_dar_vajhe.Text = lab_name_foroshandeh.Text;
                }
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }
        }

        private void Frm_Pardakht_Load(object sender, EventArgs e)
        {
            Date();

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                long mablegh_check = 0;
                var q = contex.Banks.Where(b => b.Shomareh_Hesab == txt_shomareh_hesab.Text);
                var q2 = lst_pardakht.Where(p => p.Shomareh_Hesab == txt_shomareh_hesab.Text && p.Shomareh_check == txt_shomareh_check.Text);
                var q3 = contex.Pardakhts .Where(p => p.Shomareh_Hesab == txt_shomareh_hesab.Text && p.Shomareh_check == txt_shomareh_check.Text);
                if (txt_shomareh_hesab.Text == "0" || txt_shomareh_check.Text == "0" || txt_mablegh_check.Text == "0" || txt_dar_vajhe.Text == "" || cmb_day_check.Text == "" || cmb_month_check.Text == "" || txt_factor.Text == "0") { MessageBox.Show("اطلاعات به طور صحیح پر کنید"); }
                else
                {
                    if (q.Count() > 0)
                    {
                        if (q2.Count() > 0 || q3.Count ()>0) { MessageBox.Show("اطلاعات را به طور صحیح وارد کنید"); }
                        else
                        {
                            long shomare_hesab = Convert.ToInt64(txt_shomareh_hesab.Text);
                            long shomare_check = Convert.ToInt64(txt_shomareh_check.Text);
                            Pardakht p = new Pardakht(Convert.ToInt32(txt_factor.Text), 0, null, txt_year_sodor.Text + "/" + cmb_month_sodor.Text + "/" + cmb_day_sodor.Text, txt_year_check.Text + "/" + cmb_month_check.Text + "/" + cmb_day_check.Text, txt_shomareh_hesab.Text, txt_shomareh_check.Text, Convert.ToInt64(txt_mablegh_check.Text), txt_dar_vajhe.Text, "1");
                            lst_pardakht.Add(p);
                            load_form();

                            mablegh_check = Mablegh_check_ha(mablegh_check);
                            lab_mablegh_check.Text = mablegh_check.ToString();


                        }
                    }
                    else MessageBox.Show("این شماره حساب ثبت نشده است");
                }
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }

        }

        private long Mablegh_check_ha(long mablegh_check)
        {
            foreach (var item in lst_pardakht)
            {
                mablegh_check = Convert.ToInt64(item.Mablegh_check) + mablegh_check;
            }
            return mablegh_check;
        }

        private void txt_factor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lab_manlegh_factor.Text = ""; lab_name_foroshandeh.Text = ""; lab_bedehkar.Text = "";
                int fact = Convert.ToInt32(txt_factor.Text); long mablegh_fact = 0;
                var q_mablegh_factor = contex.Kharids.Where(k => k.Factor == fact);
                var q_mablegh_esterdad = contex.EsterdadKalas.Where(k => k.Factor == fact);
                if (q_mablegh_factor.Count() > 0)
                {
                    foreach (var item in q_mablegh_factor)
                    {
                        mablegh_fact = mablegh_fact + (item.Ghimat_vahed * item.Count);
                        lab_name_foroshandeh.Text = item.Name_Foroshandeh;
                    }
                    foreach (var item in q_mablegh_esterdad )
                    {
                        mablegh_fact = mablegh_fact - (item.Ghimat_vahed * item.Count);
                    }
                    lab_manlegh_factor.Text = mablegh_fact.ToString();

                    /////////////باقیمانده بدهی///////////////////
                    Baghimandeh();
                    ///////////////////////////////////////////////
                }
            }
            catch { }
        }
        public void Baghimandeh()
        {
            int fact = Convert.ToInt32(txt_factor.Text); long baghimandeh = 0, jamhe_pardakhti = 0;
            var q_par = contex.Pardakhts.Where(p => p.Factor == fact);
            foreach (var item in q_par)
            {
                jamhe_pardakhti = Convert.ToInt64(item.Mablegh_check) + Convert.ToInt64(item.mablegh_naghdi) + jamhe_pardakhti;
            }
            baghimandeh = Convert.ToInt64(lab_manlegh_factor.Text) - jamhe_pardakhti;
            lab_bedehkar.Text = baghimandeh.ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Pardakht P = new Pardakht();
                string date_check, date_sodor;
                if (listView1.SelectedItems.Count > 0)
                {
                    P = (Pardakht)listView1.SelectedItems[0].Tag;
                    txt_shomareh_hesab.Text = P.Shomareh_Hesab;
                    txt_shomareh_check.Text = P.Shomareh_check;
                    txt_mablegh_check.Text = P.Mablegh_check.ToString();
                    txt_dar_vajhe.Text = P.Dar_vajhe;
                    date_sodor = P.Date_sodoor;
                    date_check = P.Date_check;


                    string[] result_sodor = new string[3];
                    Regex Reg = new Regex(@"\b\/\b");
                    result_sodor = Reg.Split(date_sodor);
                    txt_year_sodor.Text = result_sodor[0].ToString();
                    cmb_month_sodor.Text = result_sodor[1].ToString();
                    cmb_day_sodor.Text = result_sodor[2].ToString();

                    string[] result_check = new string[3];
                    Regex theReg = new Regex(@"\b\/\b");
                    result_check = theReg.Split(date_check);
                    txt_year_check.Text = result_check[0].ToString();
                    cmb_month_check.Text = result_check[1].ToString();
                    cmb_day_check.Text = result_check[2].ToString();




                }
            }
            catch { }
        }

        private void txt_shomareh_hesab_TextChanged(object sender, EventArgs e)
        {
            var q = contex.Banks.Where(b => b.Shomareh_Hesab == txt_shomareh_hesab.Text);
            if (q.Count() > 0)
            {
                foreach (var item in q) { lab_bank.Text = item.Name; lab_shohbe.Text = item.Shohbeh; }
            }
            else
            {
                lab_bank.Text = ""; lab_shohbe.Text = "";
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                long mablegh_check = 0;
                if (listView1.SelectedItems.Count > 0)
                {
                    Pardakht p = (Pardakht)listView1.SelectedItems[0].Tag;
                    p.Date_sodoor = txt_year_sodor.Text + "/" + cmb_month_sodor.Text + "/" + cmb_day_sodor.Text;
                    p.Date_check = txt_year_check.Text + "/" + cmb_month_check.Text + "/" + cmb_day_check.Text;
                    p.Shomareh_Hesab = txt_shomareh_hesab.Text;
                    p.Shomareh_check = txt_shomareh_check.Text;
                    p.Mablegh_check = Convert.ToInt64(txt_mablegh_check.Text);
                    p.Dar_vajhe = txt_dar_vajhe.Text;

                    load_form();
                    mablegh_check = Mablegh_check_ha(mablegh_check);
                    lab_mablegh_check.Text = mablegh_check.ToString();
                }
                else MessageBox.Show("یک رکورد را انتخاب کنید ");

            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                long mablegh_check = 0;
                int result = Convert.ToInt32(MessageBox.Show("آیا  مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                if (result == 6)
                {
                    int count = listView1.SelectedItems.Count;
                    while (count != 0)
                    {
                        Pardakht p = (Pardakht)listView1.SelectedItems[count - 1].Tag;
                        lst_pardakht.Remove(p);
                        count--;
                    }
                    load_form();
                    mablegh_check = Mablegh_check_ha(mablegh_check);
                    lab_mablegh_check.Text = mablegh_check.ToString();
                }
            }
            catch (Exception x) { MessageBox.Show("خطا در حذف " + x); }
        }

        private void btn_sabt_Chek_Click(object sender, EventArgs e)
        {
            try
            {
                long baghimandeh = 0, jamhe_pardakhti = 0; lab_mablegh_check.Text = "";
                int fact = Convert.ToInt32(txt_factor.Text);
                /////////////باقیمانده بدهی///////////////////
                var q_par = contex.Pardakhts.Where(p => p.Factor == fact);
                foreach (var item in q_par)
                {
                    jamhe_pardakhti = Convert.ToInt64(item.Mablegh_check) + Convert.ToInt64(item.mablegh_naghdi) + jamhe_pardakhti;
                }
                baghimandeh = Convert.ToInt64(lab_manlegh_factor.Text) - jamhe_pardakhti;
                ///////////////////////////////////////////////


                //////////////////مبلغ پرداختی/////////////////////
                jamhe_pardakhti = 0;
                var q_list = lst_pardakht.Where(p => p.Factor == fact);
                foreach (var item in q_list) { jamhe_pardakhti = Convert.ToInt64(item.Mablegh_check) + Convert.ToInt64(item.mablegh_naghdi) + jamhe_pardakhti; }
                ///////////////////////////////////////////////


                if (jamhe_pardakhti > baghimandeh) { MessageBox.Show("مبلغ پرداختی از بدهی بیشتر است "); }
                else
                {
                    foreach (var item in lst_pardakht) item.Factor = fact;
                    foreach (var item in lst_pardakht)
                    {
                        contex.Pardakhts.AddObject(item);
                        contex.SaveChanges();
                    }
                    MessageBox.Show("چک ها ثبت شد");
                    lst_pardakht.Clear();
                    listView1.Items.Clear();
                    Baghimandeh();



                }
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }
        }

        private void btn_pardakht_naghdi_Click(object sender, EventArgs e)
        {

            try
            {
                long baghimandeh = 0, jamhe_pardakhti = 0; lab_mablegh_check.Text = "";
                int fact = Convert.ToInt32(txt_factor.Text);
                /////////////باقیمانده بدهی///////////////////
                var q_par = contex.Pardakhts.Where(p => p.Factor == fact);
                foreach (var item in q_par)
                {
                    jamhe_pardakhti = Convert.ToInt64(item.Mablegh_check) + Convert.ToInt64(item.mablegh_naghdi) + jamhe_pardakhti;
                }
                baghimandeh = Convert.ToInt64(lab_manlegh_factor.Text) - jamhe_pardakhti;
                ///////////////////////////////////////////////



                if (Convert.ToInt64(txt_mablegh_naghdi.Text) > baghimandeh) { MessageBox.Show("مبلغ پرداختی از بدهی بیشتر است "); }
                else
                {
                    if (txt_mablegh_naghdi.Text == "0" || txt_year_naghdi.Text == "") { MessageBox.Show("اطلاعات را به طور صحیح وارد کنید"); }
                    else
                    {
                        Pardakht p = new Pardakht(Convert.ToInt32(txt_factor.Text), Convert.ToInt64(txt_mablegh_naghdi.Text), txt_year_naghdi.Text + "/" + cmb_month_naghdi.Text + "/" + cmb_day_naghdi.Text, null, null, null, null, 0, null, "0");
                        contex.Pardakhts.AddObject(p);
                        contex.SaveChanges();

                        lst_pardakht.Clear();
                        listView1.Items.Clear();
                        Baghimandeh();
                        MessageBox.Show("مبلغ نقدی ثبت شد");
                    }

                }
            }
            catch (Exception x) { MessageBox.Show("خطا" + x); }
        }






    }
}
