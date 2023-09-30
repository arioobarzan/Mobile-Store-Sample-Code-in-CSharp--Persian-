using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mobile_Store.Forms_User
{
    public partial class Frm_Restore : Form
    {
        string filename;
        SqlDataAdapter Adapter = new SqlDataAdapter();
        SqlConnection Con = new SqlConnection(@"Data Source=.;Initial Catalog=Database_Mobile_Store;Integrated Security=True");
        SqlConnection Con1 = new SqlConnection(@"Data Source=.;Initial Catalog=master;Integrated Security=True");
        public Frm_Restore()
        {
            InitializeComponent();
        }

        private void btn_Brows_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                if ((openFileDialog1.FileName != "") && (openFileDialog1.FileName != "openFileDialog1"))
                {
                    filename = openFileDialog1.FileName;
                    textBox1.Text = filename;
                }
            }
            catch { }
        }

        private void btn_Restor_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {

                    string command_text= "ALTER DATABASE Database_Mobile_Store SET SINGLE_USER WITH ROLLBACK IMMEDIATE" + " USE master; RESTORE DATABASE Database_Mobile_Store FROM DISK =N'" + filename + "'WITH REPLACE ;" + "ALTER DATABASE Database_Mobile_Store SET MULTI_USER WITH ROLLBACK IMMEDIATE USE MASTER";
                    Adapter.SelectCommand = new SqlCommand();
                    Adapter.SelectCommand.Connection = Con;
                    Adapter.SelectCommand.CommandText = command_text;
                    Con.Open();
                    Adapter.SelectCommand.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("بازیابی اطلاعات با موفقیت انجام شد");
                    MessageBox.Show("اعمال تغییرات بعد از راه اندازی مجدد سیستم انجام می شود");
                    Application.Exit();
                }
                catch
                {
                    MessageBox.Show("خطا در بازیابی اطلاعات");

                }
            }
        }
    }
}
