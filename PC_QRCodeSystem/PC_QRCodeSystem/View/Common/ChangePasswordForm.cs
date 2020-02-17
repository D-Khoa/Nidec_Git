using System;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem
{
    public partial class ChangePasswordForm : Form
    {
        m_login_password mLoginUser { get; set; }
        ErrorProvider errorProvider { get; set; }

        public ChangePasswordForm()
        {
            InitializeComponent();
            mLoginUser = new m_login_password();
            errorProvider = new ErrorProvider();
            lbUsername.Text = UserData.username;
            txtNewPass.Focus();
        }

        private void txtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtNewPass.Text.Length < 6)
                {
                    MessageBox.Show("Password contains at least 6 character!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewPass.Focus();
                }
                else
                {
                    txtConfirmPass.Focus();
                }
            }
        }

        private void txtConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                errorProvider.SetError(txtConfirmPass, null);
                if (txtConfirmPass.Text != txtNewPass.Text)
                {
                    errorProvider.SetError(txtConfirmPass, "Confirm password does not match!");
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPass.Text) || string.IsNullOrEmpty(txtConfirmPass.Text))
                MessageBox.Show("Please fill password and confirm password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (txtConfirmPass.Text != txtNewPass.Text)
                {
                    MessageBox.Show("Confirm password does not match!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConfirmPass.Focus();
                }
                else
                {
                    if (mLoginUser.ChangePassword(new m_login_password { user_cd = UserData.usercode, password = txtNewPass.Text }))
                    {
                        MessageBox.Show("Password change successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Password did not change successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
