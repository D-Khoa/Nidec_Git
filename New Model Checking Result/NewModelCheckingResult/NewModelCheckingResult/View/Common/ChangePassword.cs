using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewModelCheckingResult.Model;

namespace NewModelCheckingResult.View.Common
{
    public partial class ChangePassword : Form
    {
        m_login_password mLoginUser { get; set; }
        ErrorProvider errorProvider { get; set; }
        public ChangePassword()
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
                    CustomMessageBox.Notice("Password contains at least 6 character!");
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
            string mess = string.Empty;
            if (string.IsNullOrEmpty(txtNewPass.Text) || string.IsNullOrEmpty(txtConfirmPass.Text))
                mess = "Please fill password and confirm password";
            else
            {
                if (txtConfirmPass.Text != txtNewPass.Text)
                {
                    mess = "Confirm password does not match!";
                    txtConfirmPass.Focus();
                }
                else
                {
                    if (mLoginUser.ChangePassword(new m_login_password { user_cd = UserData.usercode, password = txtNewPass.Text }))
                    {
                        mess = "Password change successfully!";
                        this.Close();
                    }
                    else
                        mess = "Password did not change successfully!";
                }
            }
            CustomMessageBox.Notice(mess);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
