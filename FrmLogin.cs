using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLyCF
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text;
            string passWord = txtPass.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
                MessageBox.Show("Bạn phải nhập đủ UserName và Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (Login1(userName, passWord) == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Nhap sai", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                        Application.Exit();
                    else
                        txtUser.Focus();
                }
            }
        }
        private bool Login1(string user, string pass)
        {
            string cnStr = "Data Source=DESKTOP-PH5OAA4;Database = CoffeeShop;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cnStr);

            cn.Open();
            string sql = "SELECT COUNT(UserName) FROM Users WHERE UserName ='" + user + "' AND Password = '" + pass + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            int count = (int)cmd.ExecuteScalar();
            cn.Close();

            if (count == 1)
                return true;
            else
                return false;
        }
    }
}
