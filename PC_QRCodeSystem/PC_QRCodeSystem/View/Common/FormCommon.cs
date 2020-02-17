using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem
{
    public partial class FormCommon : Form
    {
        #region ALL OPTION FIELDS
        /// <summary>
        /// Get tittle of form
        /// </summary>
        public string tittle
        {
            get { return lbTittle.Text; }
            set { lbTittle.Text = value; }
        }

        /// <summary>
        /// Get username
        /// </summary>
        public string name
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }

        /// <summary>
        /// Get user position
        /// </summary>
        public string position
        {
            get { return lbPosition.Text; }
            set { lbPosition.Text = value; }
        }

        /// <summary>
        /// Get department
        /// </summary>
        public string dept
        {
            get { return lbDept.Text; }
            set { lbDept.Text = value; }
        }

        /// <summary>
        /// Get login time of user
        /// </summary>
        public DateTime logintime
        {
            get { return DateTime.Parse(lbLoginTime.Text); }
            set { lbLoginTime.Text = value.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        /// <summary>
        /// list role of user
        /// </summary>
        public List<string> listper { get; set; }

        public FormCommon()
        {
            InitializeComponent();
            listper = new List<string>();
        }

        private void FormCommon_Load(object sender, EventArgs e)
        {
            tittle = this.Text;
            name = UserData.username;
            position = UserData.position;
            dept = UserData.dept;
            logintime = UserData.logintime;
            listper = UserData.role_permision;
            this.Text = tittle + "-QRCode System";
            timerFormLoad.Enabled = true;
        }
        #endregion

        private TimeSpan timefromSec = new TimeSpan();

        #region BUTTONS EVENT
        public void CheckPermision(Control.ControlCollection controls)
        {
            if (UserData.role_permision != null)
            {
                foreach (Control control in controls)
                {
                    if (!UserData.role_permision.Contains(control.Tag) && (control.Tag != null))
                    {
                        control.Enabled = false;
                    }
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpfrm = new ChangePasswordForm();
            cpfrm.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Noice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_login_password mlog = new m_login_password();
                mlog.LogIO(UserData.usercode, false);
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType().BaseType == typeof(FormCommon))
                    {
                        frm.Close();
                    }
                }
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to exit?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region SUB EVENT
        private void FormCommon_Shown(object sender, EventArgs e)
        {
            FormCommon frm = (FormCommon)sender;
            CheckPermision(frm.Controls);
        }

        private void timerFormLoad_Tick(object sender, EventArgs e)
        {
            if (!UserData.isOnline) this.Close();
            timefromSec = TimeSpan.FromSeconds(UserData.onTime);
            lbOnlineTime.Text = timefromSec.ToString();
        }
        #endregion
    }
}
