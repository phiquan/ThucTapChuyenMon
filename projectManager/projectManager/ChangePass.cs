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
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            string passOld = txtPassOld.Text;
            string passNew = txtPassNew.Text;
            string passAgain = txtPassAgain.Text;
            if (LoginDAO.Instance.checkPass(passOld))
            {
                if (passNew == passAgain)
                {
                    LoginDAO.Instance.ChangePass(passNew);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập lại đúng mật khẩu!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng mật khẩu cũ!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
