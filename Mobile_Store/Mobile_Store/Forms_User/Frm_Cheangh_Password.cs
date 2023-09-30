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
    public partial class Frm_Cheangh_Password : Form
    {
        ContextContainer context = new ContextContainer();

        public Frm_Cheangh_Password()
        {
            InitializeComponent();
        }

        private void Frm_Cheangh_Password_Load(object sender, EventArgs e)
        {

            foreach (var item in context.Users)
            {
                cmb_username.Items.Add(item);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_new_password.Text == "" || txt_tekrar_new_password.Text == "") MessageBox.Show("رمز را به درستی وارد کنید", "پیام");
                else
                {
                    if (txt_new_password.Text != txt_tekrar_new_password.Text) MessageBox.Show("رمز جدید اشتباه است", "پیام");
                    else
                    {
                        var q = context.Users.Where(s => s.UserName == cmb_username.Text && s.Password == txt_pass_ghadim.Text);
                        if (q.Count() > 0)
                        {
                            User u = (User)cmb_username.SelectedItem;
                            u.Password = txt_new_password.Text;
                            context.Users.ApplyCurrentValues(u);
                            context.SaveChanges();
                            MessageBox.Show("اطلاعات کاربر ویرایش شد ");
                        }
                        else { MessageBox.Show("رمز قبلی اشتباه است"); }
                    }
                }
            }
            catch { }
        }
    }
}
