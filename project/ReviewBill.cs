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
    public partial class ReviewBill : Form
    {
        public ReviewBill()
        {
            InitializeComponent();
        }

        public string email;
        public string id;
        public string date;
        public string time;
        

        int idbill;

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayStaff dis = new DisplayStaff();
            dis.id = id;
            dis.time = time;
            this.Hide();
            dis.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginDelete lgd = new LoginDelete();
            lgd.id = idbill;
            lgd.ShowDialog();
            dataGridView1.DataSource = ReviewBillDAO.Instance.Review(int.Parse(id), date, time);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ClearSelection();
        }

        private void ReviewBill_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ReviewBillDAO.Instance.Review(int.Parse(id),date,time);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ClearSelection();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.Handled)
                MessageBox.Show("Vui lòng nhập số hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    idbill = int.Parse(row.Cells[0].Value.ToString());

                }
            }
            catch (Exception) { }
        }

        private void txtIdBill_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdBill.Text))
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(IDBill, 'System.String') LIKE '%{0}%'",txtIdBill.Text);
            }
        }
    }
}
