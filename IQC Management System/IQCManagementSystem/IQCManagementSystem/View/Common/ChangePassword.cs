using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IQCManagementSystem.Model;

namespace IQCManagementSystem.View.Common
{
    public partial class ChangePassword : Form
    {
        ErrorProvider errorProvider { get; set; }
        public ChangePassword()
        {
            InitializeComponent();
        }
        public string name
        {
            get { return lbUsername.Text; }
            set { lbUsername.Text = value; }
        }
        public string code
        {
            get { return lbCode.Text; }
            set { lbCode.Text = value; }
        }
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            name = UserData.username;
            code = UserData.usercode;
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
            TfSQL tf = new TfSQL();
            // string mess = string.Empty;
            if (string.IsNullOrEmpty(txtNewPass.Text) || string.IsNullOrEmpty(txtConfirmPass.Text))
                MessageBox.Show("Please fill password and confirm password!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (txtConfirmPass.Text != txtNewPass.Text)
                {
                    MessageBox.Show("Confirm password does not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPass.Clear();
                    txtNewPass.Clear();
                }
                else
                {
                    tf.sqlExecuteScalarString("update iqc_user set user_pass = '" + txtNewPass.Text + "' where user_name = '" + lbCode.Text + "' and  full_name = '" + lbUsername.Text + "'");
                    DialogResult result = MessageBox.Show("Your password has been changed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
