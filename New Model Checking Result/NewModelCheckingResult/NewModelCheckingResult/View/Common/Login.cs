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
using NewModelCheckingResult.View;
using NewModelCheckingResult.View.Common;
using NewModelCheckingResult.View.DiagaugeForm;


namespace NewModelCheckingResult
{
    public partial class Login : Form
    {
        #region VARIABLE



        #endregion
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                Version deploy = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                StringBuilder version = new StringBuilder();
                version.Append("VERSION: ");
                version.Append(deploy.Major);
                version.Append("_");
                version.Append(deploy.Build);
                version.Append("_");
                version.Append(deploy.Revision);
                lbVersion.Text = version.ToString();
            }
            cbmname.Focus();
            TfSQL con = new TfSQL();
            string sql = "select distinct user_name from iqc_user order by user_name";
            con.getComboBoxData(sql, ref cbmname);
            AcceptButton = btnOK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbmname.Text != "")
            {
                TfSQL con = new TfSQL();
                string sqlpass = "select user_pass from iqc_user where user_name = '" + cbmname.Text + "'";
                //  select user_pass from m_user where user_name = 'dang'
                if (con.sqlExecuteScalarString(sqlpass) == txtpass.Text)
                {
                    UserData.username = cbmname.Text;
                    MainFrm dg = new MainFrm();
                    this.Hide();
                    dg.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Pass is not correct", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("User name is null.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
