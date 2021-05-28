using project.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            string userName = txtID.Text;
            string pass = txtPass.Text;
            if (Login1(userName, pass))
            {
                DisplayStaff d = new DisplayStaff();
                this.Hide();
                d.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc tài khoản không hợp lệ, Xin vui lòng nhập lại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        bool Login1(string userName, string pass)
        {
            return LoginDAO.Instance.Login(userName, pass);
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {

            DialogResult close = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (close == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
