using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCF
{
    public partial class CoffeeApp : Form
    {
        public CoffeeApp()
        {
            InitializeComponent();
        }

        private void CoffeeApp_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;
            FrmLogin frm = new FrmLogin();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Enabled = true;
            }
        }
    }
}
