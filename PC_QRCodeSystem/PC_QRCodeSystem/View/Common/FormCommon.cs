﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;
using PC_QRCodeSystem.View.Common;

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
        /// list permision of user
        /// </summary>
        public List<string> listper { get; set; }

        private Color tempColor { get; set; }

        public FormCommon()
        {
            InitializeComponent();
            tempColor = new Color();
            listper = new List<string>();
            timerFormLoad.Enabled = true;
        }

        private void FormCommon_Load(object sender, EventArgs e)
        {
            tittle = this.Text;
            //Load infomation of user
            dept = UserData.dept;
            name = UserData.username;
            position = UserData.position;
            logintime = UserData.logintime;
            listper = UserData.role_permision;

            this.Text = tittle + "- Warehouse QrCode Tracy System";
            lbOnlineTime.Text = TimeSpan.FromSeconds(UserData.onTime).ToString();
            SettingItem settingItem = new SettingItem();
            settingItem.LoadSetting();
            ControlLoadEvent(this, true);
           
        }
        #endregion

        #region BUTTONS EVENT
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpfrm = new ChangePasswordForm();
            cpfrm.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Question("Are you sure to log-out?" + Environment.NewLine + "Bạn có muốn đăng xuất?") == DialogResult.Yes)
            {
                m_login_password mlog = new m_login_password();
                UserData.isOnline = mlog.LogIO(UserData.usercode, false);
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            ControlLoadEvent(this, false);
            this.Close();
        }
        #endregion

        #region SUB EVENT
        /// <summary>
        /// Add/remove event enter and leave for controls
        /// </summary>
        /// <param name="ctrl">parent control</param>
        /// <param name="isAdd">true: add event</param>
        private void ControlLoadEvent(Control ctrl, bool isAdd)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c.Controls.Count > 0) ControlLoadEvent(c, true);
                if (c.TabStop && isAdd)
                {
                    c.Enter += ControlEventEnter;
                    c.Leave += ControlEventLeave;
                }
                else if (c.TabStop && !isAdd)
                {
                    c.Enter -= ControlEventEnter;
                    c.Leave -= ControlEventLeave;
                }
            }
        }

        private void ControlEventEnter(object sender, EventArgs e)
        {
            tempColor = ((Control)sender).BackColor;
            ((Control)sender).BackColor = Color.FromKnownColor(KnownColor.Yellow);
        }

        private void ControlEventLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = tempColor;
            if (sender.GetType().Name == "Button") ((Button)sender).UseVisualStyleBackColor = true;
        }

        /// <summary>
        /// Check current open form before show form
        /// </summary>
        public new void Show()
        {
            var isExist = Application.OpenForms.OfType<FormCommon>().Where(x => x.Name == base.Name).Select(x => x);
            if (isExist.Count() > 0)
            {
                CustomMessageBox.Notice(base.Text + " is openning! Please close it first!" + Environment.NewLine + "Có một cửa sổ tương tự đang mở!");
                return;
            }
            else base.Show();
        }

        private void FormCommon_Shown(object sender, EventArgs e)
        {
            FormCommon frm = (FormCommon)sender;
            CheckPermision(frm.Controls);
        }

        /// <summary>
        /// Check permision of user
        /// </summary>
        /// <param name="controls"></param>
        public void CheckPermision(Control.ControlCollection controls)
        {
            if (UserData.role_permision != null)
            {
                foreach (Control control in controls)
                {
                    //If user's permision no have control tag then disable it
                    if (!UserData.role_permision.Contains(control.Tag) && (control.Tag != null))
                    {
                        control.Enabled = false;
                    }
                }
            }
        }

        private void timerFormLoad_Tick(object sender, EventArgs e)
        {
            if (!UserData.isOnline && !string.IsNullOrEmpty(UserData.usercode)) this.Close();
            lbOnlineTime.Text = TimeSpan.FromSeconds(UserData.onTime).ToString();
        }

        private void FormCommon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (UserData.isOnline)
            //{
            //    if (CustomMessageBox.Question("Are you want to close?") == DialogResult.No)
            //        e.Cancel = true;
            //}
        }
        #endregion

       
    }
}
