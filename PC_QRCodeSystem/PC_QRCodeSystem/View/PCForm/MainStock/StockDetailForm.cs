using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;
using System.Diagnostics;
using System.Data;

namespace PC_QRCodeSystem.View
{
    public partial class StockDetailForm : FormCommon
    {
        #region VARIABLE
        private pts_stockout stockData { get; set; }
        PrintItem lbData { get; set; }
        Stopwatch stopwatch = new Stopwatch();
        DataTable dt2;
        DataTable dt;
        List<PrintItem> listPrintItem { get; set; }
        PrintItem printItem { get; set; }
        #endregion
        #region FORM EVENT
        public StockDetailForm()
        {
            InitializeComponent();
            stockData = new pts_stockout();
            lbData = new PrintItem();
            listPrintItem = new List<PrintItem>();
            printItem = new PrintItem();
            dt2 = new DataTable();
            dt = new DataTable();
            tc_MainStockDetail.ItemSize = new Size(0, 1);
        }

        private void StockDetailForm_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
            PSQL con = new PSQL();
            string sql = "select distinct remark from pts_stockout order by remark";
            con.getComboBoxData(sql, ref cmbRemark);
            txtBarcode.Focus();
            btnExport.Enabled = false;
            btnClear.Enabled = false;
            dtpFromDate.Checked = false;
            dtpToDate.Checked = false;
        }


        #endregion

        #region BUTTONS
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog savef = new SaveFileDialog();
            savef.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls|All file (*.*)|*.*";
            savef.AddExtension = true;
            if (savef.ShowDialog() == DialogResult.OK)
            {
                dt = (DataTable)dgvData.DataSource;
                ExcelClass excel = new ExcelClass(savef.FileName);
                excel.CreateWorkBook();
                excel.AddDatatable(dt);
                excel.SaveAndExit();
            }
            MessageBox.Show("Export Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                stopwatch.Restart();
                dt2 = new DataTable();
                dgvData.DataSource = dt2;
                SearchData(ref dt2);
                stopwatch.Stop();
                tsTime.Text = stopwatch.Elapsed.ToString("s\\.ff") + " s";
                if (dgvData.Rows.Count > 0)
                {
                    tsTotal.Text = (dgvData.Rows.Count - 1).ToString();

                }
                btnExport.Enabled = true;
                btnClear.Enabled = true;
            }

            catch (Exception)
            {

            }
            txtBarcode.Clear();
            this.Cursor = Cursors.Default;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                listPrintItem.Clear();
                printItem.ListPrintItem.Clear();
                dgvData.DataSource = null;
                txtBarcode.Clear();
                txtInvoice.Clear();
                txtItemName.Clear();
                txtItemNumber.Clear();
                txtQty.Clear();
                txtSupplierName.Clear();
                cmbRemark.Text = null;
                dtpFromDate.Checked = false;
                dtpToDate.Checked = false;
                btnExport.Enabled = false;
                btnClear.Enabled = false;
                tsTime.Text = null;
                tsTotal.Text = null;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion
        #region BARCODE KEY DOWN
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string[] barcode = txtBarcode.Text.Split(';');
                    //Label of PREMAC 6-4-9 have more 2 fields
                    lbData = new PrintItem
                    {
                        Item_Number = barcode[0].Trim(),
                        Item_Name = barcode[1].Trim(),
                        SupplierName = barcode[2].Trim(),
                        Invoice = barcode[3].Trim(),
                        Delivery_Date = DateTime.Parse(barcode[4].Trim()),
                        Delivery_Qty = int.Parse(barcode[5].Trim()),
                        Remark = barcode[7].Trim(),

                    };
                    if (barcode.Length > 7)
                    {
                        if (!string.IsNullOrEmpty(barcode[6])) lbData.SupplierCD = barcode[6].Trim();
                        if (!string.IsNullOrEmpty(barcode[7])) lbData.Remark = barcode[7].Trim();
                    }
                    txtInvoice.Text = lbData.Invoice;
                    txtItemName.Text = lbData.Item_Name;
                    txtItemNumber.Text = lbData.Item_Number;
                    txtSupplierName.Text = lbData.SupplierName;
                    txtQty.Text = lbData.Delivery_Qty.ToString();
                    //dtpFromDate.Value = lbData.Delivery_Date;
                    cmbRemark.Text = lbData.Remark;
                }
            }

            catch (Exception)
            {

            }

        }
        #endregion
        #region SUB EVENT SEARCH DATA
        public void SearchData(ref DataTable dt1)
        {
            dt1.Clear();
            string sql = ""; string sql1 = ""; string sql2 = ""; string sql3 = ""; string sql4 = ""; string sql5 = ""; string sql6 = "";
            string sql8 = ""; string sql9 = ""; string sql10 = "";
            if (dtpToDate.Checked && dtpFromDate.Checked)
            {
                sql = "select * from pts_stockout where stockout_date between ";
                if (dtpFromDate.Text != "")
                {
                    sql8 = "'" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "'";

                }
                if (dtpToDate.Text != "")
                {
                    sql9 = "and '" + dtpToDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                PSQL con1 = new PSQL();
                con1.sqlDataAdapterFillDatatable(sql + sql8 + sql9, ref dt1);
            }
            else
            {
            sql = "select * from pts_stockout where 1=1";
                if (txtItemNumber.Text != "")
                {
                    sql1 = " and item_cd = '" + txtItemNumber.Text + "'";
                }
                if (txtItemName.Text != "")
                {
                    sql2 = "and item_name = '" + txtItemName.Text + "'";

                }
                if (txtSupplierName.Text != "")
                {
                    sql3 = "and supplier_name = '" + txtSupplierName.Text + "'";
                }
                if (txtInvoice.Text != "")
                {
                    sql4 = "and invoice = '" + txtInvoice.Text + "'";
                }
                if (txtQty.Text != "")
                {
                    sql5 = "and stockout_qty = '" + txtQty.Text + "'";
                }
                if (cmbRemark.Text != "")
                {
                    sql6 = "and remark = '" + cmbRemark.Text + "'";
                }
                if (dtpFromDate.Checked)
                {
                    sql10 = " and stockout_date = '" + dtpFromDate.Value + "'";
                }
            
                PSQL con = new PSQL();
                con.sqlDataAdapterFillDatatable(sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6+ sql10, ref dt1);
            }
        }
        #endregion
    }
}
