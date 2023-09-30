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
    public partial class Frm_kharid : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year, tedad, number,max, count_kala, id; long mablegh_kol;
        PersianCalendar pc = new PersianCalendar();
        List<Kharid> lst_kharid = new List<Kharid>();
        List<Anbar> lst_Anbar = new List<Anbar>();
        public Frm_kharid()
        {
            InitializeComponent();
        }
        public void load_form()
        {
            try
            {
                listView1.Items.Clear();
                number = 0;
                foreach (Kharid k in lst_kharid)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number + "";
                    t.Tag = k;

                    t.SubItems.Add(k.Name_kala);
                    t.SubItems.Add(k.Model_kala);
                    t.SubItems.Add(k.Count.ToString());
                    t.SubItems.Add(k.Ghimat_vahed.ToString());
                    t.SubItems.Add(k.Serial);
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        private void Frm_kharid_Load(object sender, EventArgs e)
        {
            try
            {
                
                var q = context.Kharids.Select(s => s);
                foreach (var item in q)
                {
                    if (max < item.Factor) max = item.Factor;
                }
                max++;
                txt_factor.Text = max.ToString();
                Date();
                foreach (var item in context.Foroshandeghans) cmb_name_foroshandeh.Items.Add(item);
                foreach (var item in context.Nkalas) cmb_nkala.Items.Add(item);
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
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
           else  cmb_month.Text = month.ToString();
            txt_year.Text = year.ToString();
        }

        private void cmb_nkala_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cmb_name_foroshandeh.Enabled = false;
                cmb_model.Items.Clear();
                var q = context.Kalas.Where(k => k.Name == cmb_nkala.Text);
                foreach (var item in q) cmb_model.Items.Add(item);
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmb_nkala.Text != "" && cmb_model.Text != "")
                {
                    cmb_name_foroshandeh.Enabled = false;
                    var q = lst_kharid.Where(s => s.Name_kala == cmb_nkala.Text && s.Model_kala == cmb_model.Text);
                    if (q.Count() > 0) MessageBox.Show("همچین کالایی اضافه شده است");
                    else
                    {
                        Kharid kh = new Kharid(Convert.ToInt32(txt_factor.Text), cmb_name_foroshandeh.Text, cmb_nkala.Text, cmb_model.Text, Convert.ToInt32(txt_count.Text), Convert.ToInt64(txt_ghimat_vahed.Text), Convert.ToInt64(txt_ghimat_forosh.Text), txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text, txt_serial.Text);
                        lst_kharid.Add(kh);
                        //Anbar a = new Anbar(cmb_nkala.Text, cmb_model.Text, Convert.ToInt32(txt_count.Text), Convert.ToInt64(txt_ghimat_vahed.Text), Convert.ToInt64(txt_ghimat_forosh.Text));
                        //lst_Anbar.Add(a);

                        load_form();
                        ///////////////
                        tedad++;
                        lab_jamhe_tedad.Text = tedad.ToString();
                        mablegh_kol = mablegh_kol + (Convert.ToInt64(txt_ghimat_vahed.Text) * Convert.ToInt32(txt_count.Text));
                        lab_mablegh_kol.Text = mablegh_kol.ToString();
                        ///////////////
                    }
                }
                else MessageBox.Show("نام و مدل کالا را وارد کنید");
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    Kharid k = (Kharid)listView1.SelectedItems[0].Tag;
                    k.Name_kala = cmb_nkala.Text;
                    k.Model_kala = cmb_model.Text;
                    /////////////////////
                    mablegh_kol = mablegh_kol - (k.Ghimat_vahed * k.Count);


                    k.Count = Convert.ToInt32(txt_count.Text);
                    k.Ghimat_vahed = Convert.ToInt64(txt_ghimat_vahed.Text);

                    mablegh_kol = mablegh_kol + (k.Ghimat_vahed * k.Count);
                    lab_mablegh_kol.Text = mablegh_kol.ToString();
                    /////////////////////
                    k.Ghimat_forosh = Convert.ToInt64(txt_ghimat_forosh.Text);
                    k.Serial = txt_serial.Text;
                    load_form();
                }
                else MessageBox.Show("یک رکورد را انتخاب کنید ");

            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Kharid k = new Kharid();
                if (listView1.SelectedItems.Count > 0)
                {
                    k = (Kharid)listView1.SelectedItems[0].Tag;
                    cmb_nkala.Text = k.Name_kala;
                    cmb_model.Text = k.Model_kala;
                    txt_count.Text = k.Count.ToString();
                    txt_ghimat_vahed.Text = k.Ghimat_vahed.ToString();
                    txt_ghimat_forosh.Text = k.Ghimat_forosh.ToString();
                    txt_serial.Text = k.Serial;
                }
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
                    int count = listView1.SelectedItems.Count;
                    while (count != 0)
                    {
                        Kharid k = (Kharid)listView1.SelectedItems[count - 1].Tag;
                        lst_kharid.Remove(k);
                        count--;
                        ///////////////
                        tedad--;
                        lab_jamhe_tedad.Text = tedad.ToString();
                        mablegh_kol = mablegh_kol - (k.Ghimat_vahed * k.Count);
                        lab_mablegh_kol.Text = mablegh_kol.ToString();
                        ///////////////
                    }
                    load_form();
                }
            }
            catch (Exception x) { MessageBox.Show("خطا در حذف " + x); }
        }

        private void btn_sabt_factor_Click(object sender, EventArgs e)
        {

            try
            {
                int fact = Convert.ToInt32(txt_factor.Text);
                var check_factor = context.Kharids.Where(k => k.Factor == fact);
                if (txt_factor.Text == "0" || txt_factor.Text == "") { MessageBox.Show("اطلاعات را به طور صحیح وارد کنید"); }
                else
                {
                    if (check_factor.Count() > 0) { MessageBox.Show("فاکتور شماره " + fact + " وجود دارد"); }
                    else
                    {
                        if (lst_kharid.Count == 0) { MessageBox.Show("لطفا فاکتور را پر کنید"); }
                        else
                        {
                            /////////////////ثبت فاکتور خرید////////////////
                            foreach (var kh in lst_kharid) kh.Factor = fact;
                            foreach (var kh in lst_kharid)
                            {
                                context.Kharids.AddObject(kh);
                                context.SaveChanges();
                            }
                            ////////////////////اضافه کردن به لیست انبار/////////////////////
                            foreach (var item in lst_kharid)
                            {
                                Anbar a = new Anbar(item.Name_kala , item.Model_kala , item.Count , item.Ghimat_vahed , item.Ghimat_forosh );
                                lst_Anbar.Add(a);
                            }

                            ///////////////////////ثبت در انبار////////////////////////////////
                            foreach (var a in lst_Anbar)
                            {
                                var q = context.Anbars.Where(s => s.Name_kala == a.Name_kala && s.Model_kala == a.Model_kala);

                                if (q.Count() > 0)
                                {

                                    foreach (var c in q)
                                    {
                                        id = c.Id;
                                        count_kala = c.Count_kala;
                                    }

                                    a.Id = id;
                                    a.Count_kala = count_kala + a.Count_kala;
                                    context.Anbars.ApplyCurrentValues(a);
                                    context.SaveChanges();

                                }
                                else
                                {
                                    context.Anbars.AddObject(a);
                                    context.SaveChanges();
                                }
                            }
                            ////////////////////////////////////////////////////////////////////
                            MessageBox.Show(" فاکتور" + txt_factor.Text + "  ثبت شد");
                            txt_count.Text = "0";
                            txt_serial.Text = "";
                            txt_ghimat_forosh.Text = "0";
                            txt_ghimat_vahed.Text = "0";
                            cmb_model.Text = "";
                            cmb_nkala.Text = "";
                            cmb_name_foroshandeh.Enabled = true;
                            lst_Anbar.Clear();
                            lst_kharid.Clear();
                            listView1.Items.Clear();
                            lab_jamhe_tedad.Text = "";
                            lab_mablegh_kol.Text = "";
                            txt_factor.Text = "0";
                            tedad = 0;
                            mablegh_kol = 0;
                        }
                    }
                }
            }
            catch (Exception x) { MessageBox.Show(" خطا در ثبت : " + x); }
        }


        private void txt_factor_TextChanged(object sender, EventArgs e)
        {
            cmb_name_foroshandeh.Enabled = true;
        }





        private void btn_add_MouseUp(object sender, MouseEventArgs e)
        {
            btn_add.FlatStyle = FlatStyle.Standard ;
        }

        private void btn_add_MouseDown(object sender, MouseEventArgs e)
        {
            btn_add.FlatStyle = FlatStyle.Flat;
        }


    }
}