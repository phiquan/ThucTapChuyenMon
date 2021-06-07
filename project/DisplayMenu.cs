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
    public partial class DisplayMenu : Form
    {
        public DisplayMenu()
        {
            InitializeComponent();
            btnAddFood.Enabled = false;
            btnDeleteFood.Enabled = false;
            textBox1.ReadOnly = true;
        }

        public string id;
        public string time;
        public string idBill;
        public string timeStaff;
        public string name;

        int idFood;

        private void button1_Click(object sender, EventArgs e)
        {            
            DisplayMenuDAO.Instance.addFood(int.Parse(idBill), idFood);
            dataGridView2.DataSource = DisplayMenuDAO.Instance.bill(int.Parse(idBill));
            textBox1.Text = DisplayMenuDAO.Instance.totalprice(int.Parse(idBill));
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    idFood = int.Parse(row.Cells[0].Value.ToString());
                }
            }
            catch (Exception) { }
            btnAddFood.Enabled = true;
            btnDeleteFood.Enabled = false;
            dataGridView2.ClearSelection();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddFood.Enabled = false;
            btnDeleteFood.Enabled = true;
            dataGridView1.ClearSelection();
            try
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    idFood = int.Parse(row.Cells[0].Value.ToString());
                }
            }
            catch (Exception) { }
        }

        

        private void DisplayStaff_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DisplayMenuDAO.Instance.menu();
            dataGridView2.DataSource = DisplayMenuDAO.Instance.bill(int.Parse(idBill));

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();

            lbName.Text = name;
            lbID.Text = "Số Bill " + idBill;
            lbDate.Text = time;
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayMenuDAO.Instance.deleteFood(int.Parse(idBill), idFood);
                dataGridView2.DataSource = DisplayMenuDAO.Instance.bill(int.Parse(idBill));
                textBox1.Text = DisplayMenuDAO.Instance.totalprice(int.Parse(idBill));
                dataGridView2.ClearSelection();
            }
            catch (Exception)
            {
                textBox1.Text = "0";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DisplayStaff disS = new DisplayStaff();
            DisplayMenuDAO.Instance.back(int.Parse(idBill));
            disS.id = id;
            disS.time = timeStaff;
            this.Hide();
            disS.ShowDialog();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            int price = int.Parse(textBox1.Text);
            DisplayMenuDAO.Instance.upPrice(int.Parse(idBill), price);
            DisplayMenuDAO.Instance.upKho(int.Parse(idBill));
            DisplayStaff disS = new DisplayStaff();            
            disS.id = id;
            disS.time = timeStaff;
            this.Hide();
            disS.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                dataGridView1.ClearSelection();
            }
            else
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("NameFood LIKE '{0}%'", textBox2.Text);
                dataGridView1.ClearSelection();
            }
        }
    }
}
