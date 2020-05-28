using PC_QRCodeSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_QRCodeSystem.View.Common
{
    public partial class AddCheckUser : Form
    {
        m_mes_user mesuser = new m_mes_user();
        m_mes_user_role userrole = new m_mes_user_role();
        m_login_password loginpass = new m_login_password();
        public AddCheckUser()
        {
            InitializeComponent();
        }
        private void AddCheckUser_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    loginpass = loginpass.CheckLogIn(txtUsername.Text, txtpass.Text);
                    UserData.isOnline = loginpass.LogIO(txtUsername.Text, true);
                    mesuser = mesuser.GetUser(loginpass.user_cd);
                    UserData.onTime = 0;
                    // timerOnTimeSet.Enabled = true;
                    UserData.dept = mesuser.dept_cd;
                    UserData.usercode = mesuser.user_cd;
                    UserData.username = mesuser.user_name;
                    UserData.position = mesuser.user_position_cd;
                    UserData.logintime = loginpass.last_login_time;
                    UserData.role_permision = userrole.GetListRole(loginpass.user_cd);
                    //Show main form
                    txtpass.Clear();
                    MessageBox.Show("User Login Successfully", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    CustomMessageBox.Notice("Please fill user code!");
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
                txtpass.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
