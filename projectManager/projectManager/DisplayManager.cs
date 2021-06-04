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
    public partial class DisplayManager : Form
    {
        public DisplayManager()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
            btnFind.Enabled = false;
            btnUpdate.Enabled = false;

            btnUpdateProduct.Enabled = false;
            btnDeleteProduct.Enabled = false;

            btnUpdateProd.Enabled = false;
            btnDeleteProd.Enabled = false;
            btnUpdateInfor.Enabled = false;
            

        }

        private int id;
        private string clear = string.Empty;

        

        public void DisplayManager_Load(object sender, EventArgs e)
        {
            //Staff
            dataGridView1.DataSource = StaffDAO.Instance.staff();
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.ClearSelection();

            //Warehouse
            dataGridView2.DataSource = WarehouseDAO.Instance.warehouse();
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ClearSelection();

            //Product
            dataGridView3.DataSource = ProductDAO.Instance.product();
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.ClearSelection();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    txtName.Text = row.Cells[1].Value.ToString();
                    txtEmail.Text = row.Cells[2].Value.ToString();
                    txtPass.Text = row.Cells[3].Value.ToString();
                    txtGender.Text = row.Cells[4].Value.ToString();
                    id = int.Parse(row.Cells[0].Value.ToString());

                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                    btnFind.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
            catch(Exception)
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            StaffDAO.Instance.Delete(id);
            dataGridView1.DataSource = StaffDAO.Instance.staff();
            MessageBox.Show("Xóa thông tin thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtName.Text = clear;
            txtEmail.Text = clear;
            txtPass.Text = clear;
            txtGender.Text = clear;

            btnDelete.Enabled = false;
            btnFind.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            string gender = txtGender.Text;
            if(name != "" && email != "" && pass != "" && gender != "")
            {
                if (StaffDAO.Instance.checkAdd(email))
                {
                    StaffDAO.Instance.Update(id, name, email, pass, gender);
                    dataGridView1.DataSource = StaffDAO.Instance.staff();
                    MessageBox.Show("Update thông tin thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtName.Text = clear;
                    txtEmail.Text = clear;
                    txtPass.Text = clear;
                    txtGender.Text = clear;

                    btnDelete.Enabled = false;
                    btnFind.Enabled = false;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Email đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show("Bạn không được bỏ trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            string gender = txtGender.Text;

            if (name != "" && email != "" && pass != "" && gender != "")
            {
                if (StaffDAO.Instance.checkAdd(email))
                {
                    StaffDAO.Instance.Add(name, email, pass, gender);
                    dataGridView1.DataSource = StaffDAO.Instance.staff();
                    MessageBox.Show("Thêm thông tin thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtName.Text = clear;
                    txtEmail.Text = clear;
                    txtPass.Text = clear;
                    txtGender.Text = clear;

                    btnDelete.Enabled = false;
                    btnFind.Enabled = false;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Email đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show("Bạn không được bỏ trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //Chưa xong 
        private void btnFind_Click(object sender, EventArgs e)
        {
            string name = txtName.Text + "#";
            string email = txtEmail.Text + "#";
            string pass = txtPass.Text + "#";
            string gender = txtGender.Text;
            string chuoi = name + email + pass + gender;
        }

        public string nameProduct;
        public int priceProdct;

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                    id = int.Parse(row.Cells[0].Value.ToString());
                    nameProduct = row.Cells[1].Value.ToString();
                    priceProdct = int.Parse(row.Cells[2].Value.ToString());

                    btnDeleteProd.Enabled = true;
                    btnUpdateProd.Enabled = true;
                    btnUpdateInfor.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void btnUpdateProd_Click(object sender, EventArgs e)
        {
            ProductUpdate prodUpdate = new ProductUpdate();
            prodUpdate.id = id;
            prodUpdate.name = nameProduct;
            prodUpdate.price = priceProdct;
            prodUpdate.ShowDialog();
            dataGridView3.DataSource = ProductDAO.Instance.product();
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnUpdateProd.Enabled = false;
            btnDeleteProd.Enabled = false;
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            Product add = new Product();
            add.ShowDialog();
            dataGridView3.DataSource = ProductDAO.Instance.product();
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnUpdateProd.Enabled = false;
            btnDeleteProd.Enabled = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = WarehouseDAO.Instance.warehouse();
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    txtID.Text = row.Cells[0].Value.ToString();
                    txtNameProd.Text = row.Cells[1].Value.ToString();
                    txtNumber.Text = row.Cells[2].Value.ToString();

                    txtID.ReadOnly = true;
                    btnAddProduct.Enabled = false;
                    btnUpdateProduct.Enabled = true;
                    btnDeleteProduct.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            txtID.Text = clear;
            txtNameProd.Text = clear;
            txtNumber.Text = clear;
            txtID.ReadOnly = false;
            btnAddProduct.Enabled = true;
            btnDeleteProduct.Enabled = false;
            btnUpdateProduct.Enabled = false;
            
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtNameProd.Text;
            string number = txtNumber.Text;

            if(id != "" && name != "" && number != "")
            {
                if (WarehouseDAO.Instance.checkId(int.Parse(id)))
                {
                    WarehouseDAO.Instance.add(int.Parse(id), name, int.Parse(number));
                    dataGridView2.DataSource = WarehouseDAO.Instance.warehouse();
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = clear;
                    txtNameProd.Text = clear;
                    txtNumber.Text = clear;
                }
                else
                {
                    MessageBox.Show("ID đã tồn tại, vui lòng chọn ID khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtNameProd.Text;
            string number = txtNumber.Text;

            if (id != "" && name != "" && number != "")
            {
                WarehouseDAO.Instance.Update(int.Parse(id), name, int.Parse(number));
                dataGridView2.DataSource = WarehouseDAO.Instance.warehouse();
                MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Text = clear;
                txtNameProd.Text = clear;
                txtNumber.Text = clear;
            }
            else
            {
                MessageBox.Show("Vui lòng không bỏ trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (WarehouseDAO.Instance.checkFood(int.Parse(txtID.Text)))
            {
                WarehouseDAO.Instance.Delete(int.Parse(txtID.Text));
                dataGridView2.DataSource = WarehouseDAO.Instance.warehouse();
                MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Text = clear;
                txtNameProd.Text = clear;
                txtNumber.Text = clear;
            }
            else
            {
                MessageBox.Show("Sản phẩm này còn bán,Vui lòng không được xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            e.Handled = true;
            if (e.Handled)
            {
                MessageBox.Show("Bạn phải nhâp số","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            e.Handled = true;
            if (e.Handled)
            {
                MessageBox.Show("Bạn phải nhâp số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteProd_Click(object sender, EventArgs e)
        {
            try
            {
                var mess = MessageBox.Show("Bạn có muốn xóa sản phẩm này", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (mess == DialogResult.Yes)
                {
                    ProductDAO.Instance.Delete(id);
                    dataGridView3.DataSource = ProductDAO.Instance.product();
                    dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sản phẩm đã được bán không xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnUpdateInfor_Click(object sender, EventArgs e)
        {
            InforProduct dis = new InforProduct();
            dis.id = id;
            dis.nameProd = nameProduct;
            dis.ShowDialog();
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("NameStaff LIKE '{0}%'", txtName.Text);
            }
        }
    }
}
