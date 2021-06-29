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
    public partial class DisMan : Form
    {
        public DisMan()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 0;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 1;
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 2;
        }
    }
}
