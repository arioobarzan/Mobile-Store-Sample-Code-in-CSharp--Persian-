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
    public partial class Frm_mohasebeh_aghsat : Form
    {
        int Count_ghest;
        long Mablegh_ghest;
        public Frm_mohasebeh_aghsat(int count,long mablegh)
        {
           this. Count_ghest = count;
           this.Mablegh_ghest = mablegh;
            InitializeComponent();
        }

        private void Frm_mohasebeh_aghsat_Load(object sender, EventArgs e)
        {
            lab_count_ghest.Text  = Count_ghest.ToString();
            lab_mablegh_ghest.Text = Mablegh_ghest.ToString();
            lab_aghsat.Text = (Count_ghest * Mablegh_ghest).ToString();
        }
    }
}
