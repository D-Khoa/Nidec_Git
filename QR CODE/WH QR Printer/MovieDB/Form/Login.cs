using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WhQrPrinter
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            TfSQL con = new TfSQL();
            string sql = "select distinct user_name from m_user order by user_name";
            con.getComboBoxData(sql, ref cmbLoginname);
            AcceptButton = btnOK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (cmbLoginname.Text != "")
            {
                TfSQL con = new TfSQL();
                string sqlpass = "select user_pass from m_user where user_name = '" + cmbLoginname.Text + "'";
                if (con.sqlExecuteScalarString(sqlpass) == txtpass.Text)
                {
                    if (cmbLoginname.Text == "pc1")
                    {
                        Form lt = new FormStart();
                        this.Hide();
                        lt.ShowDialog();
                        this.Close();
                    }
                    else if
                        (cmbLoginname.Text == "pro1")
                    {
                        Form rq = new RequestPC ();
                        this.Hide();
                        rq.ShowDialog();
                        this.Close();
                    }
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
            DialogResult = MessageBox.Show("Do you want to exit?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }


    }
}
