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
    public partial class DisplayStaff : Form
    {
        public Label name { get { return this.lbNameStaff; } }
        public string time;
        public string email;
        public string id;

        public DisplayStaff()
        {
            InitializeComponent();
        }
        
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.ShowDialog();
        }

        private void btnSeeRevenue_Click(object sender, EventArgs e)
        {
            ReviewBill rv = new ReviewBill();
            this.Hide();

            rv.id = id;
            rv.time = time;
            rv.date = DateTime.Now.ToString("yyyy/MM/dd");

            rv.ShowDialog();
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string timeCreate = DateTime.Now.ToString("hh:mm:ss");
            DisplayStaffDAO.Instance.createBill(int.Parse(id), lbDate.Text, timeCreate);
            DisplayMenu disM = new DisplayMenu();
            disM.id = id;
            disM.time = timeCreate;
            disM.timeStaff = time;
            disM.idBill = DisplayStaffDAO.Instance.getIdBill(lbDate.Text, timeCreate);
            this.Hide();
            disM.ShowDialog();

        }

        private void DisplayStaff_Load(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }
        
    }
}
