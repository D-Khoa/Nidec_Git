using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View.Common
{

    public partial class CreateAccount : FormCommon
    {
        System.Data.DataTable dt2;
        public CreateAccount()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnClear.Enabled = false;
        }
        private void CreateAccount_Load(object sender, EventArgs e)
        {
            btnOK.Visible = false;
            btnCancel.Visible = false;
            PSQL con = new PSQL();
            string sql1 = "select distinct user_position_cd from m_user_position order by user_position_cd";
            con.getComboBoxData(sql1, ref cmbPosition);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dt2 = new System.Data.DataTable();
            dgvData.DataSource = dt2;
            SearchData(ref dt2);
        }
        public void SearchData(ref System.Data.DataTable dt1)
        {
            dt1.Clear();
            string sql = ""; string sql1 = ""; string sql2 = ""; string sql3 = "";
            string sql4 = ""; string sql5 = "";
            sql = "select * from m_mes_user where 1=1";
            if (txtUserCode.Text != "")
            {
                sql1 = " and user_cd = '" + txtUserCode.Text + "'";
            }
            if (txtUserName.Text != "")
            {
                sql2 = "and user_name = '" + txtUserName.Text + "'";
            }
            if (txtDept.Text !="")
            {
                 sql4 = "and dept_cd = '" + txtDept.Text + "'";
            }
            if (cmbPosition.Text!= "")
            {
                 sql5 = "and user_position_cd = '" + cmbPosition.Text + "'";
            }
             sql3 = "and dept_cd in( '" + "PC" + "', '" + "IS" + "')";

            PSQL con = new PSQL();
            con.sqlDataAdapterFillDatatable(sql + sql1 + sql2 + sql4 + sql5 + sql3, ref dt1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCreateAccountForm addcr = new AddCreateAccountForm();
            addcr.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnOK.Visible = true;
            btnCancel.Visible = true;
            btnSearch.Visible = false;
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnBack.Visible = false;
            btnClear.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int dong;
            if (dgvData.RowCount > 0)
            {
                dong = (dgvData.SelectedCells[0].RowIndex);
                string a = dgvData.Rows[dong].Cells[0].Value.ToString();
                string b = dgvData.Rows[dong].Cells[1].Value.ToString();
                if (MessageBox.Show("Do You Sure Delete Position: " + b, "Information",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sqldelete = "delete from m_mes_user where user_cd = '" + a + "'";
                    PSQL con = new PSQL();
                    con.sqlExecuteScalarString(sqldelete);
                    MessageBox.Show("Delete Succesfully: " + b, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtUserCode.Text = null;
                txtUserName.Text = null;
                txtDept.Text = null;
                cmbPosition.Text = null;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
                btnSearch_Click(sender, e);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserCode.Text = dgvData.CurrentRow.Cells[0].Value.ToString();
            txtUserName.Text = dgvData.CurrentRow.Cells[1].Value.ToString();
            txtDept.Text = dgvData.CurrentRow.Cells[7].Value.ToString();
            cmbPosition.Text = dgvData.CurrentRow.Cells[8].Value.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount > 0)
            {
                int dong = (dgvData.SelectedCells[0].RowIndex);
                string usercd = dgvData.Rows[dong].Cells[0].Value.ToString();
                string sqlupdate = "UPDATE m_mes_user SET user_cd = '" + txtUserCode.Text + "', user_name = '" + txtUserName.Text + "',dept_cd = '" + txtDept.Text + "', user_position_cd = '" +cmbPosition.Text + "', registration_user_cd = '" + UserData.username + "', registration_date_time = now() WHERE user_cd = '" + usercd + "'";
                PSQL con = new PSQL();
                con.sqlExecuteScalarString(sqlupdate);
                MessageBox.Show("Update Finish", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserCode.Text = null;
                txtUserName.Text = null;
                txtDept.Text = null;
                cmbPosition.Text = null;
                btnSearch_Click(sender, e);
            }
            btnOK.Visible = false;
            btnCancel.Visible = false;
            btnSearch.Visible = true;
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
            btnDelete.Visible = false;
            btnBack.Visible = true;
            btnClear.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            btnBack.Visible = true;
            btnClear.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserCode.Clear();
            txtUserName.Clear();
            txtDept.Clear();
            cmbPosition.Text = null;
            dgvData.DataSource = null;
            btnAdd.Enabled = true;
            btnCancel.Visible = false;
            btnOK.Visible = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnClear.Enabled = false;
        }
    }
}
