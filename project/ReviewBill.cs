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

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayStaff dis = new DisplayStaff();
            this.Hide();
            dis.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginDelete lgd = new LoginDelete();
            lgd.ShowDialog();

        }
    }
}
