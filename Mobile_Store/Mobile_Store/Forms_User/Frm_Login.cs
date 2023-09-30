using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mobile_Store.Forms_User
{
    public partial class Frm_Login : Form
    {
        ContextContainer context = new ContextContainer();
        string Type;
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            try
            {
                
                foreach (var item in context.Users)
                {
                    cmb_user.Items.Add(item);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                var q = context.Users.Where(s => s.UserName  == cmb_user.Text && s.Password == txt_password.Text);
                foreach (var item in q) { Type = item.Type; }
                if (q.Count() > 0)
                {
                    Forms.Frm_Main f_m = new Forms.Frm_Main(Type);
                    f_m.Show();
                    this.Hide();
                }
                else MessageBox.Show("رمز اشتباه است");
            }
            catch (Exception x) { MessageBox.Show("اطلاعات را درست وارد کنید"+x); }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
