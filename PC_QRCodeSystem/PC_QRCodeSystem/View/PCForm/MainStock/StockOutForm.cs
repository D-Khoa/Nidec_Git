using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockOutForm : FormCommon
    {
        #region VARIABLE
        private PrintItem printData { get; set; }
        private pts_plan planData { get; set; }
        private pts_item itemData { get; set; }
        private pts_supplier supplierData { get; set; }
        private pts_stock stockData { get; set; }
        private m_mes_user mUserData { get; set; }
        private pts_noplan noplanData { get; set; }
        private pts_issue_code issueCode { get; set; }
        private pts_stock_log stockDataLog { get; set; }
        private pts_request_log requestData { get; set; }
        private pts_stockout_log stockOutData { get; set; }
        private pts_destination destinationData { get; set; }
        private List<PrintItem> listPrintItems { get; set; }
        private List<pts_stock> listStock { get; set; }
        private List<pts_noplan> listNoPlan { get; set; }
        private List<pts_stockout_log> listStockOut { get; set; }
        private ErrorProvider errorProvider = new ErrorProvider();
        #endregion

        #region FORM EVENT
        public StockOutForm()
        {
            InitializeComponent();
            //tc_Main.ItemSize = new Size(0, 1);
            supplierData = new pts_supplier();
            printData = new PrintItem();
            planData = new pts_plan();
            itemData = new pts_item();
            stockData = new pts_stock();
            mUserData = new m_mes_user();
            noplanData = new pts_noplan();
            issueCode = new pts_issue_code();
            stockDataLog = new pts_stock_log();
            requestData = new pts_request_log();
            stockOutData = new pts_stockout_log();
            destinationData = new pts_destination();
            listPrintItems = new List<PrintItem>();
            listStock = new List<pts_stock>();
            listNoPlan = new List<pts_noplan>();
            listStockOut = new List<pts_stockout_log>();
        }

        private void StockOutForm_Load(object sender, EventArgs e)
        {
            GetCmb();
        }
        #endregion

        #region STOCK-OUT NO PLANNED
        #region BUTTONS EVENT
        private void btnNoPlanRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbNoPlanIssueCD.Text == "30" && string.IsNullOrEmpty(txtNoPlanComment.Text))
                {
                    MessageBox.Show("Please fill comment when Scrap Item!", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string noplancd = "no" + DateTime.Now.ToString("yyyyMMddHHmmss");
                double qty = double.Parse(txtNoPlanStockOutQty.Text);
                double total = double.Parse(txtNoPlanWHQty.Text);
                double temp;
                //If stock out qty > packing qty then alert
                if (qty > total)
                {
                    if (MessageBox.Show("Stock-out qty is over than stock-in-hand qty! Are you sure to continue?", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
                }
                //Add noplan item into list
                listNoPlan.Add(new pts_noplan
                {
                    noplan_cd = noplancd,
                    destination_cd = cmbNoPlanDestinationCD.Text,
                    item_cd = txtNoPlanItemCD.Text,
                    noplan_qty = qty,
                    noplan_usercd = txtNoPlanUserCD.Text,
                    noplan_date = dtpNoPlanStockOutDate.Value,
                });
                //Check all packing in dgv
                foreach (DataGridViewRow dr in dgvNoPlan.Rows)
                {
                    //Get packing qty & packing code
                    stockData = dr.DataBoundItem as pts_stock;
                    if (stockData.packing_qty <= 0) continue;
                    if (qty > stockData.packing_qty)
                    {
                        temp = stockData.packing_qty;
                        qty = qty - stockData.packing_qty;
                    }
                    else
                    {
                        temp = qty;
                        qty = 0;
                    }
                    listStockOut.Add(new pts_stockout_log
                    {
                        packing_cd = stockData.packing_cd,
                        process_cd = noplancd,
                        issue_cd = int.Parse(cmbNoPlanIssueCD.Text),
                        stockout_date = dtpNoPlanStockOutDate.Value,
                        stockout_user_cd = txtNoPlanUserCD.Text,
                        stockout_qty = temp,
                        comment = txtNoPlanComment.Text,
                        remark = "N",
                    });
                    stockData.packing_qty = stockData.packing_qty - temp;
                    listStock.Add(stockData);
                    if (qty == 0) break;
                }
                UpdateProcessGrid(0);
                UpdateStockOutGrid();
                if (MessageBox.Show("Register new stock-out item." + Environment.NewLine + "Do you want go to Inspection Tab to see it?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    tc_Main.SelectedTab = tab_Inspection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNoPlanInspection_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Inspection;
        }

        private void btnNoPlanSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingFrm = new SettingForm();
            settingFrm.Show();
        }

        private void btnNoplanClear_Click(object sender, EventArgs e)
        {
            txtNoPlanUserCD.Clear();
            txtNoPlanItemCD.Clear();
            txtNoPlanInvoice.Clear();
            txtNoPlanComment.Clear();
            txtNoPlanWHQty.Clear();
            txtNoPlanStockOutQty.Clear();
            cmbNoPlanIssueCD.Text = null;
            cmbNoPlanDestinationCD.Text = null;
            dgvNoPlan.DataSource = null;
        }
        #endregion

        #region FIELDS EVENT
        private void GetCmb()
        {
            try
            {
                issueCode.GetListIssueCode();
                cmbNoPlanIssueCD.DataSource = issueCode.listIssueCode;
                cmbNoPlanIssueCD.DisplayMember = "issue_cd"+":"+ "issue_name";
                cmbNoPlanIssueCD.ValueMember = "issue_name";
                cmbNoPlanIssueCD.Text = null;
                destinationData.GetListDestination(string.Empty, string.Empty);
                cmbNoPlanDestinationCD.DataSource = destinationData.listdestination;
                cmbNoPlanDestinationCD.DisplayMember = "destination_cd";
                cmbNoPlanDestinationCD.ValueMember = "destination_name";
                cmbNoPlanDestinationCD.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbIssueStockOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbNoPlanIssueCD.Text))
            {
                lbNoPlanIssue.Text = cmbNoPlanIssueCD.SelectedValue.ToString();
                lbNoPlanIssue.BackColor = Color.Lime;
            }
            else
            {
                lbNoPlanIssue.Text = "Issue Name";
                lbNoPlanIssue.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        private void cmbDestinationStockOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbNoPlanDestinationCD.Text))
            {
                lbNoPlanDestination.Text = cmbNoPlanDestinationCD.SelectedValue.ToString();
                lbNoPlanDestination.BackColor = Color.Lime;
            }
            else
            {
                lbNoPlanDestination.Text = "Destination Name";
                lbNoPlanDestination.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        private void txtItemCDStockOut_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtNoPlanItemCD, null);
            lbNoPlanItem.Text = "Item Name";
            lbNoPlanItem.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if (!string.IsNullOrEmpty(txtNoPlanItemCD.Text))
            {
                try
                {
                    lbNoPlanItem.Text = itemData.GetItem(txtNoPlanItemCD.Text).item_name;
                    lbNoPlanItem.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtNoPlanItemCD, "Wrong Item Code" +
                                           Environment.NewLine + ex.Message);
                }
            }
        }

        private void txtStockOutUser_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtNoPlanUserCD, null);
            lbNoPlanUser.Text = "User Name";
            lbNoPlanUser.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if (!string.IsNullOrEmpty(txtNoPlanUserCD.Text))
            {
                try
                {
                    lbNoPlanUser.Text = mUserData.GetUser(txtNoPlanUserCD.Text).user_name;
                    lbNoPlanUser.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtNoPlanUserCD, "Wrong Item Code" +
                                           Environment.NewLine + ex.Message);
                }
            }
        }

        private void txtNoPlanStockOutQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] barcode = txtBarcode.Text.Split(';');
                txtNoPlanItemCD.Text = barcode[0];
                txtNoPlanInvoice.Text = barcode[3];
                txtBarcode.Clear();
                UpdateNoPlanGrid(true);
                txtNoPlanWHQty.Text = dgvNoPlan.Rows.Cast<DataGridViewRow>()
                     .Sum(x => Convert.ToDouble(x.Cells["packing_qty"].Value)).ToString();
            }
        }

        private void dgvNoPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            stockData = dgvNoPlan.Rows[e.RowIndex].DataBoundItem as pts_stock;
        }

        private void tab_NoPlan_Paint(object sender, PaintEventArgs e)
        {
            txtBarcode.Focus();
        }
        #endregion

        #region SUB EVENT
        private void UpdateNoPlanGrid(bool isSearch)
        {
            if (isSearch)
            {
                if (!stockData.SearchItem(new pts_stock { item_cd = txtNoPlanItemCD.Text, invoice = txtNoPlanInvoice.Text }, DateTime.Now, DateTime.Now, false))
                {
                    MessageBox.Show("This item is not exist! Please check and try again!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            dgvNoPlan.DataSource = stockData.listStockItems;
            dgvNoPlan.Columns["stock_id"].HeaderText = "Stock ID";
            dgvNoPlan.Columns["packing_cd"].HeaderText = "Packing Code";
            dgvNoPlan.Columns["item_cd"].HeaderText = "Item Code";
            dgvNoPlan.Columns["supplier_cd"].HeaderText = "Supplier Code";
            dgvNoPlan.Columns["order_no"].HeaderText = "Order Number";
            dgvNoPlan.Columns["invoice"].HeaderText = "Invoice";
            dgvNoPlan.Columns["po_no"].HeaderText = "PO";
            dgvNoPlan.Columns["stockin_date"].HeaderText = "Stock In Date";
            dgvNoPlan.Columns["stockin_user_cd"].HeaderText = "Incharge";
            dgvNoPlan.Columns["stockin_qty"].HeaderText = "Stock In Qty";
            dgvNoPlan.Columns["packing_qty"].HeaderText = "Packing Qty";
            dgvNoPlan.Columns["registration_user_cd"].HeaderText = "Reg User";
            dgvNoPlan.Columns["registration_date_time"].HeaderText = "Reg Date";
            tsRows.Text = dgvNoPlan.Rows.Count.ToString();
        }
        #endregion
        #endregion

        #region INSPECTION STOCK-OUT
        #region BUTTONS EVENT
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateNoPlanGrid(false);
            UpdateStockOutGrid();
        }

        private void btnStockOutReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (listNoPlan.Count > 0)
                {
                    int n = noplanData.AddMultiItem(listNoPlan);
                    MessageBox.Show("Add " + n + " no planned item!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (listStockOut.Count > 0)
                {
                    int n = stockOutData.AddMultiItem(listStockOut);
                    MessageBox.Show("Add " + n + " stock out logs!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                foreach (pts_stock item in listStock)
                {
                    item.UpdateItem(item);
                }
                itemData.UpdateStockValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (printData.CheckPrinterIsOffline(TfPrint.printerName))
                {
                    MessageBox.Show("Printer is offline", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                listPrintItems.Clear();
                if (dgvStockAfter.Rows.Count == 0)
                {
                    MessageBox.Show("Don't have item to print!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (DataGridViewRow dr in dgvStockAfter.Rows)
                {
                    stockData = dr.DataBoundItem as pts_stock;
                    DataGridViewRow stockoutrow = dgvStockOutLog.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => x.Cells["packing_cd"].Value.ToString() == stockData.packing_cd);
                    listPrintItems.Add(new PrintItem
                    {
                        Item_Number = stockData.item_cd,
                        Item_Name = itemData.GetItem(stockData.item_cd).item_name,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = stockData.supplier_cd }).supplier_name,
                        Invoice = stockData.invoice,
                        Delivery_Date = (DateTime)stockoutrow.Cells["stockout_date"].Value,
                        Delivery_Qty = (double)stockoutrow.Cells["stockout_qty"].Value
                    });
                    dr.DefaultCellStyle.BackColor = Color.Lime;
                }
                dgvPrintList.DataSource = listPrintItems;
                if (printData.PrintItems(listPrintItems, false))
                    MessageBox.Show("Print items are completed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInspectionClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data is not register. Are you sure to clear it?", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            ClearInspection();
        }

        private void btnInspectionBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_NoPlan;
        }
        #endregion

        #region SUB EVENT
        private void UpdateStockOutGrid()
        {
            dgvStockOutLog.DataSource = listStockOut;
            dgvStockAfter.DataSource = listStock;
        }

        private void UpdateProcessGrid(int state)
        {
            switch (state)
            {
                case 0:
                    dgvProcess.DataSource = listNoPlan;
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        private void ClearInspection()
        {
            listNoPlan.Clear();
            listStock.Clear();
            listStockOut.Clear();
            dgvProcess.DataSource = null;
            dgvStockOutLog.DataSource = null;
        }
        #endregion

        #endregion
    }
}
