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
    public partial class Frm_Esterdad : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year, tedad, number, count_kala, id, mojodi; long mablegh_kol, ghimat_forosh; string serial;
        PersianCalendar pc = new PersianCalendar();
        List<EsterdadKala> lst_Esterdad = new List<EsterdadKala>();
        List<Kharid > lst_kharid = new List<Kharid >();
        List<Anbar> lst_Anbar = new List<Anbar>();

        public Frm_Esterdad()
        {
            InitializeComponent();
        }

        public void load_form()
        {
            try
            {
                listView1.Items.Clear();
                number = 0;
                foreach (EsterdadKala  k in lst_Esterdad)
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

        private void Frm_Esterdad_Load(object sender, EventArgs e)
        {
            try
            {
                //var q = context.Kharids.Select(s => s);
                //foreach (var t in q) factor = t.Factor;
                //txt_factor.Text = factor.ToString();
                //var q1 = context.Kharids.Where(k => k.Factor == factor );
                //foreach (var item in q1) cmb_name_foroshandeh.Text = item.Name_Foroshandeh;


                //var q2 = context.Kharids.Where(k => k.Factor == factor  && k.Name_Foroshandeh == cmb_name_foroshandeh.Text).GroupBy(g => g.Name_kala);
                //foreach (var item in q2) cmb_nkala.Items.Add(item.Key);
                cmb_nkala.Items.Clear();
                Date();
               
            }
            catch (Exception x) { MessageBox.Show("" + x); }
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
                lab_mojodi.Text = "";
                txt_ghimat_vahed.Text = "0";
                txt_count.Text = "0";
                int fact=Convert.ToInt32 (txt_factor .Text );
                cmb_model.Items.Clear();
                var q = context.Kharids.Where(k => k.Name_kala == cmb_nkala.Text && k.Factor == fact);
                foreach (var item in q) cmb_model.Items.Add(item.Model_kala);
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }

        private void cmb_model_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                mojodi = 0;
                lab_mojodi.Text = "";
                txt_count.Text = "0";
                txt_ghimat_vahed.Text = "0";
                int fact = Convert.ToInt32(txt_factor.Text);
                var q = context.Kharids.Where(k => k.Factor == fact && k.Name_kala == cmb_nkala.Text && k.Model_kala == cmb_model.Text);
                foreach (var item in q)
                {
                   mojodi = item.Count;
                    txt_ghimat_vahed.Text = (item.Ghimat_vahed).ToString();
                    ghimat_forosh = item.Ghimat_forosh;
                    serial = item.Serial;
                }
                var q2 = context.EsterdadKalas.Where(k => k.Factor == fact && k.Name_kala == cmb_nkala.Text && k.Model_kala == cmb_model.Text);
                foreach (var item in q2) mojodi = mojodi - item.Count;

                lab_mojodi.Text = mojodi.ToString();
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }

        private void txt_factor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmb_nkala.Items.Clear();
                lst_Anbar.Clear();
                lst_Esterdad.Clear();
                txt_count.Text = "0";
                lab_mojodi.Text = "";
                txt_ghimat_vahed.Text = "0";
                listView1.Items.Clear();
                int fact = Convert.ToInt32(txt_factor.Text);
                var q = context.Kharids.Where(k => k.Factor == fact);
                if (q.Count() > 0)
                {
                    foreach (var item in q) cmb_name_foroshandeh.Text = item.Name_Foroshandeh;

                    var q2 = context.Kharids.Where(k => k.Factor == fact  && k.Name_Foroshandeh == cmb_name_foroshandeh.Text).GroupBy(g => g.Name_kala);
                    foreach (var item in q2) cmb_nkala.Items.Add(item.Key);
                }
                else cmb_name_foroshandeh.Text = "";
            }
            catch { }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                var q_mojodi = context.Anbars.Where(k => k.Name_kala == cmb_nkala.Text && k.Model_kala == cmb_model.Text);
                foreach (var item in q_mojodi) mojodi = item.Count_kala;

                if (cmb_nkala.Text != "" && cmb_model.Text != "")
                {
                    var q = lst_Esterdad.Where(s => s.Name_kala == cmb_nkala.Text && s.Model_kala == cmb_model.Text);
                    if (q.Count() > 0) MessageBox.Show("همچین کالایی اضافه شده است");
                    else
                    {
                        
                        if (Convert.ToInt32(txt_count.Text) > mojodi || Convert.ToInt32(txt_count.Text)> Convert.ToInt32 (lab_mojodi .Text )) MessageBox.Show("تعداد کالای انتخابی از موجودی  بیشتر است ");
                        else
                        {
                            EsterdadKala es = new EsterdadKala(Convert.ToInt32(txt_factor.Text), cmb_name_foroshandeh.Text, cmb_nkala.Text, cmb_model.Text, Convert.ToInt32(txt_count.Text), Convert.ToInt64(txt_ghimat_vahed.Text), ghimat_forosh, txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text, serial);
                            lst_Esterdad.Add(es);
                            Kharid  k = new Kharid (Convert.ToInt32(txt_factor.Text), cmb_name_foroshandeh.Text, cmb_nkala.Text, cmb_model.Text, Convert.ToInt32(txt_count.Text), Convert.ToInt64(txt_ghimat_vahed.Text), ghimat_forosh, txt_year.Text + "/" + cmb_month.Text + "/" + cmb_day.Text, serial);
                            lst_kharid .Add(k);
                            //Anbar a = new Anbar(cmb_nkala.Text, cmb_model.Text, Convert.ToInt32(txt_count.Text), Convert.ToInt64(txt_ghimat_vahed.Text), ghimat_forosh);
                            //lst_Anbar.Add(a);

                            load_form();
                            ///////////////
                            tedad++;
                            lab_jamhe_tehdad.Text = tedad.ToString();
                            mablegh_kol = mablegh_kol + (Convert.ToInt64(txt_ghimat_vahed.Text) * Convert.ToInt32(txt_count.Text));
                            lab_mablegh_kol.Text = mablegh_kol.ToString();
                            ///////////////
                        }
                    }
                }
                else MessageBox.Show("نام و مدل کالا را وارد کنید");
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }

        private void btn_sabt_factor_Click(object sender, EventArgs e)
        {
            try
            {
                int fact = Convert.ToInt32(txt_factor.Text);
                if (txt_count.Text == "" || txt_factor.Text == "0") { MessageBox.Show(" اطلاعات را به طور صحیح وارد کنید  "); }
                else
                {
                        if (lst_Esterdad.Count == 0) { MessageBox.Show("لطفا فاکتور را پر کنید"); }
                        else
                        {
                            /////////////////ثبت فاکتور استرداد////////////////
                            foreach (var es in lst_Esterdad)
                            {
                                context.EsterdadKalas.AddObject(es);
                                context.SaveChanges();
                            }
                            MessageBox.Show("فاکتور استرداد" + txt_factor.Text + "  ثبت شد");
                   

         
                            ///////////////////////ویرایش در انبار////////////////////////////////

                            foreach (var item in lst_Esterdad)
                            {
                                Anbar a = new Anbar(item.Name_kala , item.Model_kala , item.Count , item.Ghimat_vahed , ghimat_forosh);
                                lst_Anbar.Add(a);
                            }


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
                                    a.Count_kala = count_kala - a.Count_kala;
                                    context.Anbars.ApplyCurrentValues(a);
                                    context.SaveChanges();
                                }
                            }
                            ////////////////////////////////////////////////////////////////////
                            txt_count.Text = "0";
                            txt_ghimat_vahed.Text = "0";
                            cmb_model.Text = "";
                            cmb_nkala.Text = "";
                            cmb_name_foroshandeh.Enabled = true;
                            lst_Anbar.Clear();
                            lst_Esterdad.Clear();
                            listView1.Items.Clear();
                            lab_jamhe_tehdad.Text = "";
                            lab_mablegh_kol.Text = "";
                            txt_factor.Text = "0";
                        }
                    }
                
            }
            catch (Exception x) { MessageBox.Show(" خطا در ثبت : " + x); }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    EsterdadKala  k = (EsterdadKala )listView1.SelectedItems[0].Tag;
                    k.Name_kala = cmb_nkala.Text;
                    k.Model_kala = cmb_model.Text;
                    /////////////////////
                    mablegh_kol = mablegh_kol - (k.Ghimat_vahed * k.Count);

                    k.Count = Convert.ToInt32(txt_count.Text);

                    mablegh_kol = mablegh_kol + (k.Ghimat_vahed * k.Count);
                    lab_mablegh_kol.Text = mablegh_kol.ToString();
                    /////////////////////

                    load_form();
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
                    int count = listView1.SelectedItems.Count;
                    while (count != 0)
                    {
                        EsterdadKala  k = (EsterdadKala )listView1.SelectedItems[count - 1].Tag;
                        lst_Esterdad .Remove(k);
                        count--;
                        //////////////////////
                        tedad--;
                        lab_jamhe_tehdad .Text  = tedad.ToString();
                        mablegh_kol = mablegh_kol - (k.Ghimat_vahed * k.Count);
                        lab_mablegh_kol.Text = mablegh_kol.ToString();
                        /////////////////////
                    }
                    load_form();
                }
            }
            catch (Exception x) { MessageBox.Show("خطا در حذف " + x); }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EsterdadKala  es = new EsterdadKala();
                if (listView1.SelectedItems.Count > 0)
                {
                    es = (EsterdadKala )listView1.SelectedItems[0].Tag;
                    cmb_nkala.Text = es.Name_kala;
                    cmb_model.Text = es.Model_kala;
                    txt_count.Text = es.Count.ToString();
                    txt_ghimat_vahed.Text = es.Ghimat_vahed.ToString();

                }
            }
            catch { }
        }






    }
}
