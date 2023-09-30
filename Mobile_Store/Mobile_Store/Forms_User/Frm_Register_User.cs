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
    public partial class Frm_Register_User : Form
    {
        ContextContainer context = new ContextContainer();
        public Frm_Register_User()
        {
            InitializeComponent();
        }
        private void Load_data()
        {
            var q = context.Users.Where(s => s.Type == "1").Select(s => s).OrderBy(s => s.UserName);
            dataGridView1.DataSource = q;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[1].Width = 122;
            dataGridView1.Columns[1].HeaderText = "نام کاربری";
            dataGridView1.Columns[2].Width = 240;
            dataGridView1.Columns[2].HeaderText = " رمز عبور";
        }
        private void pic_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_username.Text == "" || txt_password.Text == "") { MessageBox.Show("اطلاعات را به طور کامل وارد کنید"); }
                else
                {
                    User u = new User();
                    u.UserName  = txt_username.Text;
                    u.Password = txt_password.Text;
                    u.Type = "1";
                    var q_user = context.Users.Where(s => s.UserName == txt_username.Text);
                    var q_ramz = context.Users.Where(s => s.Password == txt_password.Text);
                    if (q_user.Count() > 0) MessageBox.Show("همچنین نام کاربری وجود دارد");
                    else
                    {
                        if (q_ramz.Count() > 0) MessageBox.Show("همچنین رمزی وجود دارد");
                        else
                        {
                            context.Users.AddObject(u);
                            context.SaveChanges();
                            Load_data();
                        }
                    }
                }
            }
            catch (Exception x) { MessageBox.Show("اطلاعات را درست وارد کنید" + "error" + x); }
        }

        private void pic_del_Click(object sender, EventArgs e)
        {
            try
            {
                int result = Convert.ToInt32(MessageBox.Show("آیا شما مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                if (result == 6)
                {
                    int count = dataGridView1.SelectedRows.Count;
                    while (count != 0)
                    {
                        context.Users.DeleteObject((User)dataGridView1.SelectedRows[0].DataBoundItem);
                        context.SaveChanges();
                        count--;
                    }
                    Load_data();
                }
            }
            catch { MessageBox.Show("اطلاعات را درست وارد کنید"); }
        }

        private void Frm_Register_User_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        
   
    
    }
}
