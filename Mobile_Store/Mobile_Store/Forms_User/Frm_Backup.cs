using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Mobile_Store.Forms_User
{
    public partial class Frm_Backup : Form
    {
        ContextContainer context = new ContextContainer();
        int day, month, year; string str_year, str_month, str_day, tarikh;
        PersianCalendar pc = new PersianCalendar();
        public Frm_Backup()
        {
            InitializeComponent();
        }
        private void Date()
        {

            DateTime dt = DateTime.Today;
            year = pc.GetYear(dt);
            month = pc.GetMonth(dt);
            day = pc.GetDayOfMonth(dt);

            if (day % 10 == day) str_day = "0" + day;
            else str_day = day.ToString();
            if (month % 10 == month) str_month = "0" + month;
            else str_month = month.ToString();
            str_year = year.ToString();

            tarikh = str_year + str_month + str_day;

        }
        private void btn_Brows_Click(object sender, EventArgs e)
        {
            try
            {
                Date();
                saveFileDialog1.ShowDialog();
                string root = saveFileDialog1.FileName;
                root += "(" + tarikh + ")" + ".bak";
                if (root.StartsWith(".bak")) textBox1.Text = "";
                else textBox1.Text = root;
            }
            catch { }
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "USE MASTER BACKUP DATABASE [Database_Mobile_Store] TO DISK = N'" + textBox1.Text + "' WITH NOFORMAT, NOINIT, NAME = N'Database_Mobile_Store-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
                cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=Database_Mobile_Store;Integrated Security=True");
                cmd.CommandType = CommandType.Text;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                MessageBox.Show("با موفقیت اطلاعات ذخیره شد");

            }
            catch { MessageBox.Show("خطا در ذخیره اطلاعات"); }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
