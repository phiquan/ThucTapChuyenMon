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

            btnAddProd.Enabled = false;
            btnUpdateProd.Enabled = false;
            btnDeleteProd.Enabled = false;
            btnClear.Enabled = false;

        }

        private int id;
        private string clear = string.Empty;

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            AddProduct add = new AddProduct();
            add.Show();
        }

        private void DisplayManager_Load(object sender, EventArgs e)
        {
            //Staff
            dataGridView1.DataSource = StaffDAO.Instance.staff();
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 80;
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
            if(name != null || email != null || pass != null || gender != null)
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
                MessageBox.Show("Bạn không được bỏ trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            string gender = txtGender.Text;

            if (name != null || email != null || pass != null || gender != null)
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
    }
}
