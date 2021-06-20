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
    public partial class ProductUpdate : Form
    {
        public ProductUpdate()
        {
            InitializeComponent();
        }
        public int id;
        public string name;
        public int price;

        private void ProductUpdate_Load(object sender, EventArgs e)
        {
            txtID.Text = id.ToString();
            txtName.Text = name;
            txtPrice.Text = price.ToString();
            txtID.ReadOnly = true;



        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtPrice.Text != "")
            {
                ProductDAO.Instance.Update(id, txtName.Text, int.Parse(txtPrice.Text));
                var mess = MessageBox.Show("Sủa thành công, bạn có muốn sửa chi tiết món ăn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (mess == DialogResult.Yes)
                {
                    this.Hide();
                    InforProduct ifp = new InforProduct();
                    ifp.ShowDialog();
                }
                else
                {
                    this.Hide();                   
                }

            }
            else
            {
                MessageBox.Show("Không được bỏ trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
