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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void btnUpdateProd_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "" && txtName.Text != "" && txtPrice.Text != "")
            {                
                var mess = MessageBox.Show("Vui lòng thêm thông tin sản phẩm", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                {
                    ProductDAO.Instance.Add(int.Parse(txtID.Text), txtName.Text, int.Parse(txtPrice.Text));
                    InforProduct ifp = new InforProduct();
                    ifp.id = int.Parse(txtID.Text);
                    ifp.nameProd = txtName.Text;
                    this.Hide();
                    ifp.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng không bỏ trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
