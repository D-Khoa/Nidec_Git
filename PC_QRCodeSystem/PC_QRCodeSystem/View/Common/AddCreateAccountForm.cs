﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View.Common
{
    public partial class AddCreateAccountForm : FormCommon
    {
        public AddCreateAccountForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserCode.Text != "" && txtUserName.Text != "")
            {
                string sqladd = "INSERT INTO m_mes_user( user_cd, user_name, locale_id, multi_login_flag, registration_user_cd, registration_date_time, registrated_factory_cd, dept_cd, user_position_cd) VALUES('" + txtUserCode.Text + "' , '" + txtUserName.Text + "' , '" +"3"+"','"+"1"+"', '" + UserData.username + "', '"+ "now()"+"','"+"NCVP"+"', '"+txtDept.Text+"', '"+cmbPosition.Text+"')";
                PSQL con = new PSQL();
                con.sqlExecuteScalarString(sqladd);
                MessageBox.Show("Add Finish", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else MessageBox.Show("User Code Not Null", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void AddCreateAccountForm_Load(object sender, EventArgs e)
        {
            PSQL con = new PSQL();
            string sql1 = "select distinct user_position_cd from m_user_position order by user_position_cd";
            con.getComboBoxData(sql1, ref cmbPosition);
        }
    }
}
