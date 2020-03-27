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
//using NewModelCheckingResult.View.Common;


namespace NewModelCheckingResult.View.Common
{
    public partial class FormCommon : Form
    {
        #region ALL OPTION FIELDS
        Color tempColor = new Color();
        public string code
        {
            get { return lbCode.Text; }
            set { lbCode.Text = value; }
        }
        public string name
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }

        public string tittle
        {
            get { return lbTittle.Text; }
            set { lbTittle.Text = value; }
        }
        public FormCommon()
        {
            InitializeComponent();
            btnCreatAccount.Enabled = false;
        }
        #endregion

        private void FormCommon_Load(object sender, EventArgs e)
        {
            tittle = this.Text;
            name = UserData.username;
            code = UserData.usercode;
            this.Text = tittle + "- IQC Model Checking Result";
            btnCreatAccount.Enabled = UserData.isadmin;
            AddEventLoad(this, true);
        }

        private void AddEventLoad(Control ctrl, bool isAdd)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c.Controls.Count > 0) AddEventLoad(c, true);
                if (c.TabStop && isAdd)
                {
                    c.Enter += ControlEnterEvent;
                    c.Leave += ControlLeaveEvent;
                }
                else if (c.TabStop && isAdd)
                {
                    c.Enter -= ControlEnterEvent;
                    c.Leave -= ControlLeaveEvent;
                }
            }
        }

        private void ControlEnterEvent(object sender, EventArgs e)
        {
            tempColor = ((Control)sender).BackColor;
            ((Control)sender).BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
        }

        private void ControlLeaveEvent(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.FromKnownColor(KnownColor.Window);
            if (sender.GetType().Name == "Button") ((Button)sender).UseVisualStyleBackColor = true;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changeps = new ChangePassword();
            changeps.ShowDialog();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreatAccount_Click(object sender, EventArgs e)
        {
            CreatAccount cracc = new CreatAccount();
            cracc.ShowDialog();
        }


    }
}
