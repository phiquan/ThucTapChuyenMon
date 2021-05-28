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
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnFind.Enabled = false;
            btnUpdate.Enabled = false;

            btnAddProd.Enabled = false;
            btnUpdateProd.Enabled = false;
            btnDeleteProd.Enabled = false;
            btnClear.Enabled = false;

        }

    
    }
}
