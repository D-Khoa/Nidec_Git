using System;
using System.Threading;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem
{
    public partial class Login : Form
    {
        m_mes_user mesuser = new m_mes_user();
        m_mes_user_role userrole = new m_mes_user_role();
        m_login_password loginpass = new m_login_password();

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

        /// <summary>
        /// Press ENTER for jump to password textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtpass.Focus();
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginEvent();
        }

        /// <summary>
        /// Click button OK for login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            LoginEvent();
        }

        /// <summary>
        /// Click button Cancel for return
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Login Event
        /// </summary>
        private void LoginEvent()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    loginpass = loginpass.CheckLogIn(txtUsername.Text, txtpass.Text);
                    if (loginpass.is_online)
                        if (MessageBox.Show("This user is online." + Environment.NewLine + "Are you want re-login?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                    loginpass.LogIO(txtUsername.Text, false);
                    UserData.isOnline = loginpass.CheckOnline(txtUsername.Text);
                    Thread.Sleep(1000);
                    loginpass.LogIO(txtUsername.Text, true);
                    UserData.isOnline = loginpass.CheckOnline(txtUsername.Text);
                    mesuser = mesuser.GetUser(loginpass.user_cd);
                    UserData.onTime = 0;
                    timerOnTimeSet.Enabled = true;
                    UserData.dept = mesuser.dept_cd;
                    UserData.usercode = mesuser.user_cd;
                    UserData.username = mesuser.user_name;
                    UserData.position = mesuser.user_position_cd;
                    UserData.logintime = loginpass.last_login_time;
                    UserData.role_permision = userrole.GetListRole(loginpass.user_cd);
                    //Show main form
                    MainForm main = new MainForm();
                    this.Hide();
                    txtpass.Clear();
                    main.ShowDialog();
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

        private void timerOnTimeSet_Tick(object sender, EventArgs e)
        {
            UserData.onTime++;
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            timerOnTimeSet.Enabled = false;
        }
    }
}
