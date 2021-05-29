using projectManager.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectManager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            string user = txtEmail.Text;
            string pass = txtPass.Text;
            if(LoginManager(user,pass) == true)
            {
                DisplayManager dis = new DisplayManager();
                this.Hide();
                dis.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mật khẩu hoặc tài khoản sai!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        bool LoginManager(string user, string pass)
        {
            return LoginDAO.Instance.LoginManager(user, pass);
        }
    }
}
