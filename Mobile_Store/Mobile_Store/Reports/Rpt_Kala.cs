using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mobile_Store.Reports
{
    public partial class Rpt_Kala : Form
    {
        ContextContainer context = new ContextContainer();
        int number; long q1, q2;
        List<Kharid> lst_kharid = new List<Kharid>();
        public Rpt_Kala()
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

                    t.SubItems.Add(k.Factor .ToString ());
                    t.SubItems.Add(k.Name_Foroshandeh );
                    t.SubItems.Add(k.Count .ToString ());
                    t.SubItems.Add(k.Ghimat_vahed.ToString());
                    t.SubItems.Add(k.Date_kharid );
                    t.SubItems.Add(k.Ghimat_forosh.ToString());
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        private void Rpt_Kala_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in context.Nkalas) cmb_name_kala.Items.Add(item);
            }
            catch { }
        }
        private void cmb_name_kala_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cmb_model.Items.Clear();
                var q = context.Kalas.Where(k => k.Name == cmb_name_kala.Text);
                foreach (var item in q) cmb_model.Items.Add(item);
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                lst_kharid.Clear();
                if (cmb_type_search.SelectedIndex == 0)
                {
                    var q = context.Kharids.Where(k => k.Serial == txt_serial_kala.Text);
                    foreach (var item in q) lst_kharid.Add(item);
                }
                if (cmb_type_search.SelectedIndex == 1)
                {
                    var q = context.Kharids.Where(k => k.Name_kala == cmb_name_kala.Text && k.Model_kala == cmb_model.Text);
                    foreach (var item in q) lst_kharid.Add(item);
                }
                if (cmb_type_search.SelectedIndex == 2)
                {
                    q1 = Convert.ToInt64(txt_ghimat1.Text);
                    q2 = Convert.ToInt64(txt_ghimat2.Text);
                    var q = context.Kharids.Where(k => k.Ghimat_forosh >= q1 && k.Ghimat_forosh <= q2);
                    foreach (var item in q)
                    {
                        lst_kharid.Add(item);
                    }
                }
                load_form();
            }
            catch { }
        }

    }
}
