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

        string time;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            string userName = txtID.Text;
            string pass = txtPass.Text;
            if (Login1(userName, pass))
            {
                DisplayStaff d = new DisplayStaff();
                this.Hide();
                d.name = fullname(userName);
                d.time = time;
                d.email = txtID.Text;
                d.id = idStaff(userName);
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

        string fullname(string username)
        {
            return LoginDAO.Instance.getName(username);
        }

        string idStaff(string username)
        {
            return LoginDAO.Instance.getId(username);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            time = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
