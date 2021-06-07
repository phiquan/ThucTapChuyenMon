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
    public partial class LoginDelete : Form
    {
        public LoginDelete()
        {
            InitializeComponent();
        }
        public int id;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtID.Text;
            string pass = txtPass.Text;
            if (Login(userName, pass))
            {
                LoginDeleteDAO.Instance.upKho(id);
                LoginDeleteDAO.Instance.DeleteBill(id);                
                MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Hide();           
            }
            else
            {
                MessageBox.Show("Đăng Nhập Sai Vui Lòng Nhập Lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        bool Login(string userName, string pass)
        {
            return LoginDeleteDAO.Instance.Login(userName, pass);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ReviewBill rv = new ReviewBill();
            this.Hide();
            rv.ShowDialog();
        }
    }
}
