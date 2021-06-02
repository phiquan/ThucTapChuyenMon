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

        }
        private int id;
        private void InforProduct_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = InforProductDAO.Instance.InforProduct();
            
            cbNameInfor.DataSource = InforProductDAO.Instance.comboboxNameInfor();
            cbNameInfor.DisplayMember = "Name";
            cbNameInfor.ValueMember = "ID";

            cbName.DataSource = InforProductDAO.Instance.comboboxName();
            cbName.DisplayMember = "NameFood";
            cbName.ValueMember = "IDFood";
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    id = int.Parse(row.Cells[0].Value.ToString());
                    cbName.Text = row.Cells[1].Value.ToString();
                    cbNameInfor.Text = row.Cells[2].Value.ToString();
                    txtNumber.Text = row.Cells[3].Value.ToString();


                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
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

        
    }
}
