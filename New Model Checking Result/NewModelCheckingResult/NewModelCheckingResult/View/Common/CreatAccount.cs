using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewModelCheckingResult.View.Common
{
    public partial class CreatAccount : Form
    {
        public CreatAccount()
        {
            InitializeComponent();
        }

        private void CreatAccount_Load(object sender, EventArgs e)
        {

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((txtUserName.Text != "") && txtPassword.Text != "")
            {
                TfSQL con = new TfSQL();
                string sqladd = "insert into iqc_user (user_name, user_pass, full_name) values ( '" + txtUserName.Text + "','" + txtPassword.Text + "', '" + txtFullName.Text + "')";
                con.sqlExecuteScalarString(sqladd);
                MessageBox.Show("You have add account successfully ", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            else
            {
                MessageBox.Show("Please fill user code and password ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
