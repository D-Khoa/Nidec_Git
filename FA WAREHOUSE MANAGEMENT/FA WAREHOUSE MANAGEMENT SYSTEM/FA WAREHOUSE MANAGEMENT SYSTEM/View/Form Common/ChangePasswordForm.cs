using System;
using System.Windows.Forms;
using FA_WAREHOUSE_MANAGEMENT_SYSTEM.View;

namespace FA_WAREHOUSE_MANAGEMENT_SYSTEM
{
    public partial class ChangePasswordForm : Form
    {
        public string newpass { get; set; }
        public string confirmpass { get; set; }
        public ChangePasswordForm()
        {
            InitializeComponent();
            lbUsername.Text = UserData.username;
            txtNewPass.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text != txtNewPass.Text)
            {
                MessageBox.Show("Confirm password is not correct!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmPass.Focus();
            }
            else
            {
                GetData gdata = new GetData();
                if (gdata.ChangePassword(txtNewPass.Text))
                    MessageBox.Show("Change password successful!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Change password not successful!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNewPass.Text.Length < 6)
                {
                    MessageBox.Show("Password contains at least 6 character!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewPass.Focus();
                }
                else
                {
                    txtConfirmPass.Focus();
                    AcceptButton = btnOK;
                }
            }
        }

       
    }
}
