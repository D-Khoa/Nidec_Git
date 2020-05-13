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

namespace IQCManagementSystem.View
{
    public partial class FormEquipment : FormCommon
    {
        DataTable dt2;
        DataTable dt;
        public FormEquipment()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnOk.Visible = false;
            btnCancel.Visible = false;
            dt = new DataTable();
        }

        private void FormEquipment_Load(object sender, EventArgs e)
        {
            #region QUERY
            TfSQL con = new TfSQL();
            string sql = "select distinct invertory_time_cd from m_invertory_time order by invertory_time_cd";
            con.getComboBoxData(sql, ref cmbInventory);
            string sql1 = "select distinct asset_serial from m_asset order by asset_serial";
            con.getComboBoxData(sql1, ref cmbSerial);
            string sql2 = "select distinct asset_model from m_asset order by asset_model";
            con.getComboBoxData(sql2, ref cmbModel);
            string sql3 = "select distinct asset_supplier from m_asset order by asset_supplier";
            con.getComboBoxData(sql3, ref cmbMarker);
            string sql4 = "select distinct dept from m_asset order by dept";
            con.getComboBoxData(sql4, ref cmbDept);
            string sql5 = "select distinct section from m_asset order by section";
            con.getComboBoxData(sql5, ref cmbSection);
            string sql6 = "select distinct line from m_asset order by line";
            con.getComboBoxData(sql6, ref cmbLine);
            string sql7 = "select distinct period from m_asset order by period";
            con.getComboBoxData(sql7, ref cmbPeriod);
            string sql8 = "select distinct label_status from m_asset order by label_status";
            con.getComboBoxData(sql8, ref cmbStatus);
            #endregion

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dt2 = new DataTable();
            dgvdata.DataSource = dt2;
            SearchData(ref dt2);

        }
        #region SEARCH DATA EVENT
        public void SearchData(ref DataTable dt1)
        {
            dt1.Clear();

            string sql10 = ""; string sql11 = ""; string sql12 = ""; string sql13 = "";
            string sql14 = ""; string sql15 = ""; string sql16 = ""; string sql17 = "";
            string sql18 = ""; string sql19 = ""; string sql20 = ""; string sql21 = "";
            string sql22 = "";
            sql10 = "select * from m_asset where 1=1";
            if (txtAssetCode.Text != "")
            {
                sql11 = " and asset_cd = '" + txtAssetCode.Text + "'";
            }
            if (txtAssetName.Text != "")
            {
                sql12 = "and asset_name = '" + txtAssetName.Text + "'";
            }
            if (cmbModel.Text != "")
            {
                sql13 = "and asset_model = '" + cmbModel.Text + "'";
            }
            if (cmbDept.Text != "")
            {
                sql14 = "and dept = '" + cmbDept.Text + "'";
            }
            if (cmbSection.Text != "")
            {
                sql15 = "and section = '" + cmbSection.Text + "'";
            }
            if (cmbLine.Text != "")
            {
                sql16 = "and line = '" + cmbLine.Text + "'";
            }
            if (cmbInventory.Text != "")
            {
                sql17 = "and inventory = '" + cmbInventory.Text + "'";
            }
            if (cmbSerial.Text != "")
            {
                sql18 = "and asset_serial = '" + cmbSerial.Text + "'";
            }
            if (cmbMarker.Text != "")
            {
                sql19 = "and asset_supplier = '" + cmbMarker.Text + "'";
            }
            if (txtInvoice.Text != "")
            {
                sql20 = "and asset_invoice = '" + txtInvoice.Text + "'";
            }
            if (cmbPeriod.Text != "")
            {
                sql21 = "and period = '" + cmbPeriod.Text + "'";
            }
            if (cmbStatus.Text != "")
            {
                sql22 = "and label_status = '" + cmbStatus.Text + "'";
            }
            TfSQL con = new TfSQL();
            con.sqlDataAdapterFillDatatable(sql10 + sql11 + sql12 + sql13 + sql14 + sql15 + sql16 + sql17 + sql18 + sql19 + sql20 + sql21 + sql22, ref dt1);
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnOk.Visible = true;
            btnCancel.Visible = true;
            btnSearch.Enabled = false;
            btnAdd.Enabled = false;
            btnClear.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnBrowser.Enabled = false;
            btnExportExel.Enabled = false;
            txtBrowser.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnOk.Visible = true;
            btnCancel.Visible = true;
            btnSearch.Enabled = false;
            btnAdd.Enabled = false;
            btnClear.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnBrowser.Enabled = false;
            btnExportExel.Enabled = false;
            txtBrowser.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int dong;
            if (dgvdata.RowCount > 0)
            {
                dong = (dgvdata.SelectedCells[0].RowIndex);
                string a = dgvdata.Rows[dong].Cells[0].Value.ToString();
                string b = dgvdata.Rows[dong].Cells[1].Value.ToString();
                if (MessageBox.Show("Do You Sure Delete Asset Code: " + b, "Information",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqldelete = "delete from m_asset where asset_id = '" + a + "'";
                    TfSQL con = new TfSQL();
                    con.sqlExecuteScalarString(sqldelete);
                    MessageBox.Show("Delete Succesfully: " + b, "Information", MessageBoxButtons.OK);
                }
                btnClear_Click(sender, e);
                btnSearch_Click(sender, e);
            }
        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
           
        }
        private void btnExportExel_Click(object sender, EventArgs e)
        {
            SaveFileDialog savef = new SaveFileDialog();
            savef.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls|All file (*.*)|*.*";
            savef.AddExtension = true;
            if (savef.ShowDialog() == DialogResult.OK)
            {
                dt = (DataTable)dgvdata.DataSource;
                ExcelClass excel = new ExcelClass(savef.FileName);
                excel.CreateWorkBook();
                excel.AddDatatable(dt);
                excel.SaveAndExit();
            }
            MessageBox.Show("Export Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAssetCode.Text = dgvdata.CurrentRow.Cells[1].Value.ToString();
            txtAssetName.Text = dgvdata.CurrentRow.Cells[2].Value.ToString();
            cmbModel.Text = dgvdata.CurrentRow.Cells[3].Value.ToString();
            cmbSerial.Text = dgvdata.CurrentRow.Cells[4].Value.ToString();
            cmbMarker.Text = dgvdata.CurrentRow.Cells[5].Value.ToString();
            cmbDept.Text = dgvdata.CurrentRow.Cells[6].Value.ToString();
            cmbSection.Text = dgvdata.CurrentRow.Cells[7].Value.ToString();
            cmbLine.Text = dgvdata.CurrentRow.Cells[8].Value.ToString();
            txtInvoice.Text = dgvdata.CurrentRow.Cells[9].Value.ToString();
            cmbPeriod.Text = dgvdata.CurrentRow.Cells[10].Value.ToString();
            cmbStatus.Text = dgvdata.CurrentRow.Cells[14].Value.ToString();
            cmbInventory.Text = dgvdata.CurrentRow.Cells[15].Value.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnBrowser.Enabled = true;
            btnDelete.Enabled = false;
            btnClear.Enabled = true;
            btnExportExel.Enabled = true;
            btnOk.Visible = false;
            btnCancel.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnBrowser.Enabled = true;
            btnDelete.Enabled = false;
            btnClear.Enabled = true;
            btnExportExel.Enabled = true;
            btnOk.Visible = false;
            btnCancel.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAssetCode.Clear();
            txtAssetName.Clear();
            txtInvoice.Clear();
            cmbModel.Text = null;
            cmbDept.Text = null;
            cmbInventory.Text = null;
            cmbLine.Text = null;
            cmbMarker.Text = null;
            cmbPeriod.Text = null;
            cmbSection.Text = null;
            cmbSerial.Text = null;
            cmbStatus.Text = null;
        }
    }
}
