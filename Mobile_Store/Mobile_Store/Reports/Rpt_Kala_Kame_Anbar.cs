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
    public partial class Rpt_Kala_Kame_Anbar : Form
    {
        List<Anbar> lst_Anbar = new List<Anbar>();
        ContextContainer context = new ContextContainer();
        int number, count, jamhe_tehdad; long jamhe_mablagh;
        public Rpt_Kala_Kame_Anbar()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            try
            {
                listView1.Items.Clear();
                number = 0; jamhe_mablagh = 0; jamhe_tehdad= 0;
                foreach (Anbar k in lst_Anbar)
                {
                    ListViewItem t = new ListViewItem();
                    number++;
                    t.Text = number.ToString();
                    t.Tag = k;

                    t.SubItems.Add(k.Name_kala);
                    t.SubItems.Add(k.Model_kala);

                    t.SubItems.Add(k.Count_kala.ToString());
                    jamhe_tehdad += k.Count_kala;
                    t.SubItems.Add(k.Ghimat_forosh.ToString());
                    jamhe_mablagh = (k.Ghimat_forosh * k.Count_kala) + jamhe_mablagh;
                    listView1.Items.Add(t);
                }
            }
            catch (Exception x) { MessageBox.Show(x + "خطا : "); }

        }
        private void Kamterin_Kala()
        {
            if (txt_count.Text != "") count = Convert.ToInt32(txt_count.Text);
            else count = 5;

            lst_Anbar.Clear();
            var q_kamterin = context.Anbars.OrderBy(a => a.Count_kala);
            foreach (var item in q_kamterin)
            {
                if (count == 0) break;
                lst_Anbar.Add(item);
                count--;
            }
            load_data();
            lab_jamhe_mablagh.Text = jamhe_mablagh.ToString();
            lab_jamhe_tedad.Text = jamhe_tehdad.ToString();
        }
        private void Rpt_Kala_Kame_Anbar_Load(object sender, EventArgs e)
        {
            try
            {
                btn_search.Focus();
                Kamterin_Kala();
            }
            catch { }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Kamterin_Kala();
        }




    }
}
