using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FA_WAREHOUSE_MANAGEMENT_SYSTEM.View
{
    public partial class Login : Form
    {
        GetData getData = new GetData();
        m_login_password loginpass = new m_login_password();
        m_mes_user mesuser = new m_mes_user();
        m_mes_user_role userrole = new m_mes_user_role();
        public Login()
        {
            InitializeComponent();
            this.Text = lbTittle.Text + "-" + this.Text;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = null;
            txtUsername.Focus();

        }
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtpass.Focus();
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginEvent2();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            LoginEvent2();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginEvent2()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    loginpass = loginpass.CheckLogIn(txtUsername.Text, txtpass.Text);
                    if (loginpass.is_online)
                        if (MessageBox.Show("This user is online." + Environment.NewLine + "Are you want re-login?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                    loginpass.LogIO(txtUsername.Text, true);
                    mesuser = mesuser.GetUser(loginpass.user_cd);
                    UserData.dept = mesuser.dept_cd;
                    UserData.usercode = mesuser.user_cd;
                    UserData.username = mesuser.user_name;
                    UserData.logintime = loginpass.last_login_time;
                  //  UserData.role_permision = userrole.GetListRole(loginpass.user_cd);
                    //Show main form
                    Warehouse wh = new Warehouse();
                    this.Hide();
                    txtpass.Clear();
                    wh.ShowDialog();
                    loginpass.LogIO(txtUsername.Text, false);
                    this.Show();
                    this.Focus();
                }
                else
                {
                    MessageBox.Show("Please fill user code!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
