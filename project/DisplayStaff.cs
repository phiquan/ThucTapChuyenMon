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
    public partial class DisplayStaff : Form
    {
        public DisplayStaff()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                if(dataGridView1.Rows[i].Selected == true)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[i];
                    this.dataGridView2.Rows.Add(row);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            dataGridView2.ClearSelection();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            dataGridView1.ClearSelection();
        }

        private void DisplayStaff_FormClosing(object sender, FormClosingEventArgs e)
        {
            var close = MessageBox.Show("Do you want to exit this program ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(close == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            else
            {

            }
        }
    }
}
