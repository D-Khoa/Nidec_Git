using System;
using System.Windows.Forms;

namespace IQCManagementSystem.View.Common
{
    public partial class CreatAccount : Form
    {
        public CreatAccount()
        {
            InitializeComponent();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
