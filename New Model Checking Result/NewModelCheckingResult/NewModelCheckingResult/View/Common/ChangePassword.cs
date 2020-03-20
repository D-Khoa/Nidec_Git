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
    public partial class ChangePassword : Form
    {
     
        ErrorProvider errorProvider { get; set; }
        public ChangePassword()
        {
            InitializeComponent();
          
        }

        private void txtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
           
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
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
