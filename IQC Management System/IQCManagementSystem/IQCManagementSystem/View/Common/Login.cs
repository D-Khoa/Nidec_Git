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
using IQCManagementSystem.View.Common;
using IQCManagementSystem.View.Formmain;

namespace IQCManagementSystem
{
    public partial class Login : Form
    {
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (ActiveControl == cbmname)
                {
                    string temp = cbmname.Text;
                    if (temp.Contains(";"))
                        cbmname.Text = temp.Split(';')[0];
                    txtpass.Focus();
                    return true;
                }
                else if (ActiveControl == txtpass)
                {
                    btnOK.PerformClick();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbmname.Text))
            {
                TfSQL con = new TfSQL();
                string sqlpass = "select user_name, user_pass, full_name, admin_flag from iqc_user where user_name = '" + cbmname.Text + "' and user_pass = '" + txtpass.Text + "' ";
                {
                    DataTable dt = new DataTable();
                    dt = con.sqlExecuteReader(sqlpass);
                    //if (con.sqlExecuteScalarString(sqlpass) == cbmname.Text)
                    if (dt.Rows.Count > 0 && dt.Rows[0]["user_name"].ToString() == cbmname.Text && dt.Rows[0]["user_pass"].ToString() == txtpass.Text)
                    {
                        UserData.usercode = dt.Rows[0]["user_name"].ToString();
                        UserData.username = dt.Rows[0]["full_name"].ToString();
                        UserData.isadmin = bool.Parse(dt.Rows[0]["admin_flag"].ToString());
                        Formmain Feq = new Formmain();
                        this.Hide();
                        Feq.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Pass is not correct", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("User name is null.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
