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
    public partial class StockOutV2Form : FormCommon
    {
        #region VARIABLE
        string processCD = string.Empty;
        Color tempColor = new Color();
        Control tempControl = new Control();
        List<OutputItem> listOut { get; set; }
        List<PrintItem> listPrint { get; set; }
        List<pts_stock> listStock { get; set; }
        List<pts_stockout_log> listStockOut { get; set; }
        #endregion

        #region FORM EVENT
        public StockOutV2Form()
        {
            InitializeComponent();
            listOut = new List<OutputItem>();
            listPrint = new List<PrintItem>();
            listStock = new List<pts_stock>();
            listStockOut = new List<pts_stockout_log>();
        }

        private void StockOutV2Form_Load(object sender, EventArgs e)
        {
            GetCmb();
            MainClear();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if(ActiveControl == txtBarcode) MainSearch();
                tempControl.BackColor = tempColor;
                ProcessTabKey(true);
                tempControl = ActiveControl;
                tempColor = ActiveControl.BackColor;
                ActiveControl.BackColor = Color.Yellow;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region MAIN EVENT
        #region BUTTONS EVENT
        private void btnSearch_Click(object sender, EventArgs e)
        {
            MainSearch();
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDataList();
                if (cmbIssue.SelectedValue.ToString() == "30" && string.IsNullOrEmpty(txtComment.Text))
                {
                    CustomMessageBox.Notice("Need comment when scrap item!");
                    return;
                }
                else if (cmbIssue.SelectedValue.ToString() == "20") OpenSet(dgvSearch.SelectedRows[0].Index);
                else OutNoSet();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            if (dgvStockOut.Rows.Count > 0) tc_Main.SelectedTab = tab_Print;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MainClear();
        }
        #endregion

        #region FIELDS EVENT
        #region USER
        private void txtUserCode_Validated(object sender, EventArgs e)
        {
            string temp = txtUserCode.Text;
            if (temp.Contains(";"))
                temp = temp.Split(';')[0].Trim();
            if (temp.Length > 6) txtUserCode.Text = temp.Substring(temp.Length - 6);
            else txtUserCode.Text = temp;
            try
            {
                m_mes_user muser = new m_mes_user();
                muser = muser.GetUser(txtUserCode.Text);
                lbUserName.Text = muser.user_name;
                lbUserName.BackColor = Color.Lime;
            }
            catch (Exception ex)
            {
                txtUserCode.Focus();
                lbUserName.Text = "Wrong User Code";
                lbUserName.BackColor = Color.FromKnownColor(KnownColor.Yellow);
            }
        }

        private void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserCode.Text))
            {
                lbUserName.Text = "User Name";
                lbUserName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }
        #endregion

        #region ISSUE
        private void cmbIssue_Format(object sender, ListControlConvertEventArgs e)
        {
            string code = ((pts_issue_code)e.ListItem).issue_cd.ToString();
            string iname = ((pts_issue_code)e.ListItem).issue_name;
            e.Value = code + ": " + iname;
        }

        private void cmbIssue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIssue.SelectedIndex > 0) tbpNoSet.Visible = true;
            else tbpNoSet.Visible = false;
        }

        private void cmbIssue_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbIssue.Text)) cmbIssue.Select();
        }
        #endregion

        #region DESTINATION
        private void cmbDestination_Format(object sender, ListControlConvertEventArgs e)
        {
            string code = ((pts_destination)e.ListItem).destination_cd;
            string iname = ((pts_destination)e.ListItem).destination_name;
            e.Value = code + ": " + iname;
        }

        private void cmbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDestination.Text)) cmbDestination.Select();
        }

        private void cmbDestination_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDestination.Text)) cmbDestination.Select();
        }
        #endregion

        #region ITEM
        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtItemCode.Text))
                {
                    lbItemName.Text = "Item Name";
                    lbItemName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                else
                {
                    pts_item itemData = new pts_item();
                    itemData = itemData.GetItem(txtItemCode.Text);
                    lbItemName.Text = itemData.item_name;
                    lbItemName.BackColor = Color.Lime;
                }
            }
            catch (Exception ex)
            {
                lbItemName.Text = "Wrong Item Code";
                lbItemName.BackColor = Color.FromKnownColor(KnownColor.Yellow);
                System.Diagnostics.Debug.Print(ex.Message);
            }
        }
        #endregion

        #region ITEM QTY
        private void txtStockOutQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbSign_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSign.Checked) txtStockOutQty.Text = "-" + txtStockOutQty.Text;
            else txtStockOutQty.Text = txtStockOutQty.Text.Replace("-", "");
        }
        #endregion

        #region DATAGRIDVIEW
        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (cmbIssue.SelectedValue.ToString() == "20")
            {
                btnStockOut.Text = "9. OPEN SET";
                if (e.ColumnIndex == dgvSearch.Columns["btnOpenSet"].Index) OpenSet(e.RowIndex);
            }
            else btnStockOut.Text = "9. STOCK-OUT";
        }

        private void dgvSearch_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvSearch.DataSource == null) return;
            if (cmbIssue.SelectedValue.ToString() == "20") btnStockOut.Text = "9. OPEN SET";
            else btnStockOut.Text = "9. STOCK-OUT";
            dgvSearch.ClearSelection();
        }
        #endregion
        #endregion

        #region SUBS EVENT
        #region FILEDS
        /// <summary>
        /// Get data for issue and destination
        /// </summary>
        private void GetCmb()
        {
            pts_issue_code issueData = new pts_issue_code();
            issueData.GetListIssueCode();
            cmbIssue.DataSource = issueData.listIssueCode;
            cmbIssue.ValueMember = "issue_cd";
            cmbIssue.ResetText();
            pts_destination desData = new pts_destination();
            desData.GetListDestination(string.Empty, string.Empty);
            cmbDestination.DataSource = desData.listdestination;
            cmbDestination.ValueMember = "destination_cd";
            cmbDestination.ResetText();
        }

        private void MainSearch()
        {
            try
            {
                string temp = txtBarcode.Text;
                if (temp.Contains(";"))
                {
                    string[] barcode = temp.Split(';');
                    txtItemCode.Text = barcode[0].Trim();
                    txtInvoice.Text = barcode[3].Trim();
                }
                else
                {
                    txtItemCode.Text = temp;
                    txtInvoice.ResetText();
                }
                if (cmbIssue.SelectedValue.ToString() == "20") SearchItemSet(txtItemCode.Text, txtSetNumber.Text);
                else SearchNoSet(txtItemCode.Text, txtInvoice.Text);
                txtBarcode.Clear();
                txtBarcode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        /// <summary>
        /// Clear all fields main tab
        /// </summary>
        private void MainClear()
        {
            //RESET TEXTBOX
            txtWHQty.ResetText();
            txtInvoice.ResetText();
            txtComment.ResetText();
            txtUserCode.ResetText();
            txtItemCode.ResetText();
            txtSetNumber.ResetText();
            txtStockOutQty.ResetText();
            //RESET COMBOBOX
            cmbIssue.ResetText();
            cmbDestination.ResetText();
            //CLEAR DGV
            dgvSearch.Columns.Clear();
            dgvSearch.DataSource = null;
            tempControl.BackColor = tempColor;
            txtUserCode.Select();
            tempControl = txtUserCode;
            tempColor = txtUserCode.BackColor;
            txtUserCode.BackColor = Color.Yellow;
        }

        /// <summary>
        /// Check empty fields
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            if (string.IsNullOrEmpty(txtUserCode.Text))
            {
                CustomMessageBox.Error("User code is empty");
                return false;
            }
            if (string.IsNullOrEmpty(txtItemCode.Text))
            {
                CustomMessageBox.Error("Item code is empty");
                return false;
            }
            if (string.IsNullOrEmpty(cmbIssue.Text))
            {
                CustomMessageBox.Error("Issue code is empty");
                return false;
            }
            if (string.IsNullOrEmpty(cmbDestination.Text))
            {
                CustomMessageBox.Error("Destination code is empty");
                return false;
            }
            return true;
        }
        #endregion

        #region NO SET ITEM
        /// <summary>
        /// Search no set items
        /// </summary>
        /// <param name="itemNumber">item number</param>
        /// <param name="invoiceText">invoice</param>
        private void SearchNoSet(string itemNumber, string invoiceText)
        {
            try
            {
                pts_item itemdata = new pts_item();
                itemdata = itemdata.GetItem(itemNumber);
                double totalWHQty = itemdata.wh_qty;
                txtWHQty.Text = totalWHQty.ToString();
                pts_stock stockdata = new pts_stock();
                stockdata.SearchItem(new pts_stock { item_cd = itemNumber, invoice = invoiceText });
                double totalPackingQty = stockdata.listStockItems.Select(x => x.packing_qty).Sum();
                txtTotalPackingQty.Text = totalPackingQty.ToString();
                dgvSearch.Columns.Clear();
                dgvSearch.DataSource = null;
                dgvSearch.DataSource = stockdata.listStockItems;
                dgvSearch.Columns["stock_id"].HeaderText = "ID";
                dgvSearch.Columns["packing_cd"].HeaderText = "Packing Code";
                dgvSearch.Columns["item_cd"].HeaderText = "Item Number";
                dgvSearch.Columns["supplier_cd"].HeaderText = "Supplier Code";
                dgvSearch.Columns["order_no"].HeaderText = "Order Number";
                dgvSearch.Columns["invoice"].HeaderText = "Invoice";
                dgvSearch.Columns["stockin_date"].HeaderText = "Stock-In Date";
                dgvSearch.Columns["stockin_user_cd"].HeaderText = "Incharge";
                dgvSearch.Columns["stockin_qty"].HeaderText = "Stock-In Qty";
                dgvSearch.Columns["packing_qty"].HeaderText = "Packing Qty";
                dgvSearch.Columns["registration_user_cd"].HeaderText = "Reg User";
                dgvSearch.Columns["registration_date_time"].HeaderText = "Reg Time";
                if (dgvSearch.Columns.Contains("order_no")) dgvSearch.Columns.Remove("order_no");
                if (dgvSearch.Columns.Contains("registration_user_cd")) dgvSearch.Columns.Remove("registration_user_cd");
                if (dgvSearch.Columns.Contains("registration_date_time")) dgvSearch.Columns.Remove("registration_date_time");
                //if (dgvSearch.Columns.Contains("btnOpenSet")) dgvSearch.Columns.Remove("btnOpenSet");
                btnStockOut.Text = "STOCK-OUT";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        /// <summary>
        /// Create list stock, list stock out, list print of no set item
        /// </summary>
        private void OutNoSet()
        {
            if (!CheckFields()) return;
            if (txtStockOutQty.Text == "0" || string.IsNullOrEmpty(txtStockOutQty.Text))
            {
                CustomMessageBox.Notice("Please fill Stock-Out Q'ty");
                return;
            }
            double deliveryQty = 0;
            double whQty = double.Parse(txtWHQty.Text);
            double stockoutQty = double.Parse(txtStockOutQty.Text);
            if (stockoutQty > whQty)
            {
                CustomMessageBox.Notice("This item is not enough!");
                return;
            }
            //CALCULATOR STOCK AND STOCK OUT QTY
            pts_stock currentStock = new pts_stock();
            pts_supplier supplierData = new pts_supplier();
            foreach (DataGridViewRow dr in dgvSearch.Rows)
            {
                currentStock = dr.DataBoundItem as pts_stock;
                if (currentStock.packing_qty == 0 && stockoutQty > 0) continue;
                if (stockoutQty >= currentStock.packing_qty)
                {
                    deliveryQty = currentStock.packing_qty;
                    currentStock.packing_qty = 0;
                    stockoutQty -= deliveryQty;
                }
                else
                {
                    deliveryQty = stockoutQty;
                    stockoutQty = 0;
                    currentStock.packing_qty -= deliveryQty;
                    listPrint.Add(new PrintItem
                    {
                        Item_Number = txtItemCode.Text,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = currentStock.supplier_cd }).supplier_name,
                        Invoice = currentStock.invoice,
                        Delivery_Date = currentStock.stockin_date,
                        Delivery_Qty = currentStock.packing_qty,
                        SupplierCD = currentStock.supplier_cd,
                        isRec = true,
                        Label_Qty = 1,
                    });
                    listPrint.Add(new PrintItem
                    {
                        Item_Number = txtItemCode.Text,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = currentStock.supplier_cd }).supplier_name,
                        Invoice = currentStock.invoice,
                        Delivery_Date = dtpStockOutDate.Value,
                        Delivery_Qty = deliveryQty,
                        SupplierCD = currentStock.supplier_cd,
                        isRec = false,
                        Label_Qty = 1,
                    });
                }

                #region ADD LIST STOCK AND LIST STOCK OUT
                listStock.Add(currentStock);
                listStockOut.Add(new pts_stockout_log
                {
                    packing_cd = currentStock.packing_cd,
                    process_cd = processCD,
                    issue_cd = (int)cmbIssue.SelectedValue,
                    stockout_date = dtpStockOutDate.Value,
                    stockout_user_cd = txtUserCode.Text,
                    stockout_qty = deliveryQty,
                    comment = txtComment.Text,
                    remark = "N",
                });
                #endregion
                //ADD LIST OUPUT ITEM
                listOut.Add(new OutputItem
                {
                    issue_cd = (int)cmbIssue.SelectedValue,
                    destination_cd = cmbDestination.SelectedValue.ToString(),
                    item_number = currentStock.item_cd,
                    delivery_qty = deliveryQty,
                    delivery_date = dtpStockOutDate.Value,
                    order_number = string.Empty,
                    incharge = txtUserCode.Text,
                });
                if (stockoutQty == 0) break;
            }
            //UpdateGridPrint(listPrint);
            //UpdateGridStockOut(listStockOut);
            tc_Main.SelectedTab = tab_Print;
        }
        #endregion

        #region SET ITEM
        /// <summary>
        /// Search item set and order number
        /// </summary>
        /// <param name="itemNumber">model number</param>
        /// <param name="setNumber">order number</param>
        private void SearchItemSet(string itemNumber, string setNumber)
        {
            try
            {
                pre_649_order orderData = new pre_649_order();
                orderData.Search(new pre_649_order
                {
                    item_number = itemNumber,
                    order_number = setNumber
                });
                dgvSearch.Columns.Clear();
                dgvSearch.DataSource = null;
                dgvSearch.DataSource = orderData.listOrderItem;
                dgvSearch.Columns["item_number"].HeaderText = "Item Number";
                dgvSearch.Columns["order_number"].HeaderText = "Order Number";
                dgvSearch.Columns["order_qty"].HeaderText = "Order Qty";
                dgvSearch.Columns["order_date"].HeaderText = "Order Date";
                dgvSearch.Columns["supplier_cd"].HeaderText = "Supplier Code";
                if (!dgvSearch.Columns.Contains("btnOpenSet"))
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.Name = "btnOpenSet";
                    col.HeaderText = "Open Set";
                    col.Text = "Open";
                    col.UseColumnTextForButtonValue = true;
                    dgvSearch.Columns.Insert(0, col);
                }
                btnStockOut.Text = "OPEN SET";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        /// <summary>
        /// Open set
        /// </summary>
        /// <param name="RowIndex">index of row in list item set</param>
        private void OpenSet(int RowIndex)
        {
            if (!CheckFields()) return;
            DataGridViewRow dr = dgvSearch.Rows[RowIndex];
            GetSetOptions(dr.Cells["order_number"].Value.ToString(), (double)dr.Cells["order_qty"].Value, (DateTime)dr.Cells["order_date"].Value);
            SearchLowItem(txtItemCode.Text, (double)dr.Cells["order_qty"].Value, dr.Cells["order_number"].Value.ToString());
            tc_Main.SelectedTab = tab_Set;
            pts_stockout_log stockoutData = new pts_stockout_log();
            double temp = 0;
            for (int i = 0; i < dgvSetData.Rows.Count; i++)
            {
                temp = stockoutData.GetStockOutQty(dr.Cells["order_number"].Value.ToString(), dgvSetData.Rows[i].Cells["low_level_item"].Value.ToString());
                dgvSetData.Rows[i].Cells["stockout_qty"].Value = temp;
            }
            txtBarcode.Focus();
        }

        /// <summary>
        /// Search list low item of item set
        /// </summary>
        /// <param name="hiItem">model number</param>
        /// <param name="orderQty">request qty</param>
        /// <param name="orderNumber">order number</param>
        private void SearchLowItem(string hiItem, double orderQty, string orderNumber)
        {
            pre_223 structData = new pre_223();
            List<pre_223_view> listData = new List<pre_223_view>();
            listData = structData.Search(hiItem, orderQty);
            dgvSetData.DataSource = listData;
            dgvSetData.Columns["low_level_item"].HeaderText = "Part Number";
            dgvSetData.Columns["item_name"].HeaderText = "Part Name";
            dgvSetData.Columns["item_location"].HeaderText = "Location";
            dgvSetData.Columns["item_unit"].HeaderText = "Unit";
            dgvSetData.Columns["request_qty"].HeaderText = "Request Qty";
            dgvSetData.Columns["wh_qty"].HeaderText = "W/H Qty";
            if (!dgvSetData.Columns.Contains("stockout_qty"))
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Name = "stockout_qty";
                col.HeaderText = "Stock-Out Qty";
                col.ValueType = typeof(double);
                col.DefaultCellStyle.NullValue = "0";
                col.CellTemplate = new DataGridViewTextBoxCell();
                //dgvSetData.Columns.Insert(6, col);
                dgvSetData.Columns.Add(col);
            }
            dgvSetData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        #endregion

        private void ClearDataList()
        {
            listOut.Clear();
            listPrint.Clear();
            listStock.Clear();
            listStockOut.Clear();
        }
        #endregion
        #endregion

        #region SET-ITEM EVENT
        #region BUTTONS EVENT
        private void btnSetReg_Click(object sender, EventArgs e)
        {

        }

        private void btnSetClear_Click(object sender, EventArgs e)
        {

        }

        private void btnSetBack_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region FIELDS EVENT

        #endregion
        #region SUBS EVENT
        private void GetSetOptions(string orderNo, double orderQty, DateTime orderDate)
        {
            txtSetOrderNo.Text = orderNo;
            txtSetUserCD.Text = txtUserCode.Text;
            txtSetModelCD.Text = txtItemCode.Text;
            txtSetRequestQty.Text = orderQty.ToString();
            txtSetRequestDate.Text = orderDate.ToString("yyyy-MM-dd");
            txtSetDesCD.Text = cmbDestination.SelectedValue.ToString();
            lbSetUserName.Text = lbUserName.Text;
            lbSetModelName.Text = lbItemName.Text;
            lbSetDesName.Text = cmbDestination.Text.Split(':')[1].Trim();
        }
        #endregion

        #endregion

        #region PRINT EVENT
        #region BUTTONS EVENT
        private void btnPrintAll_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintSelect_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintInspection_Click(object sender, EventArgs e)
        {

        }

        private void btnPrinClear_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintBack_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region FIELDS EVENT

        #endregion

        #region SUBS EVENT
        #endregion

        #endregion

        #region INSPECTION
        #region BUTTONS EVENT

        #endregion
        #region FIELDS EVEMT

        #endregion
        #region SUBS EVENT

        #endregion
        #endregion
    }
}
