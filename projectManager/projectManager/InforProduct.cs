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
    public partial class InforProduct : Form
    {
        public InforProduct()
        {
            InitializeComponent();

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtName.ReadOnly = true;

        }
        public int id;
        public string nameProd;
        private int idName;
        private void InforProduct_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = InforProductDAO.Instance.InforProduct(id);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[3].Width = 60;
            txtName.Text = nameProd;

            cbNameInfor.DataSource = InforProductDAO.Instance.comboboxNameInfor();
            cbNameInfor.DisplayMember = "Name";
            cbNameInfor.ValueMember = "ID";
            cbNameInfor.SelectedValue = 0;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    idName = int.Parse(row.Cells[0].Value.ToString());
                    txtNumber.Text = row.Cells[3].Value.ToString();

                    cbNameInfor.SelectedValue = idName;

                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnAdd.Enabled = false;
                }
            }
            catch (Exception) { }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtNumber.Text != "")
            {
                idName = int.Parse(cbNameInfor.SelectedValue.ToString());
                if (InforProductDAO.Instance.checkName(id, idName))
                {
                    InforProductDAO.Instance.Add(id, idName, int.Parse(txtNumber.Text));
                    dataGridView1.DataSource = InforProductDAO.Instance.InforProduct(id);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[0].Width = 50;
                    dataGridView1.Columns[3].Width = 60;
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbNameInfor.SelectedValue = 0;
                    txtNumber.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Thông tin đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show("Vui lòng đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if(txtNumber.Text != "")
            {
                InforProductDAO.Instance.Update(id,idName,int.Parse(cbNameInfor.SelectedValue.ToString()),int.Parse(txtNumber.Text));
                dataGridView1.DataSource = InforProductDAO.Instance.InforProduct(id);
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[3].Width = 60;
                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbNameInfor.SelectedValue = 0;
                txtNumber.Text = string.Empty;
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Vui lòng đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            InforProductDAO.Instance.Delete(id, idName);
            dataGridView1.DataSource = InforProductDAO.Instance.InforProduct(id);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[3].Width = 60;
            MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbNameInfor.SelectedValue = 0;
            txtNumber.Text = string.Empty;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        
    }
}
