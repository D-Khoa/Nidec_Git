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
    public partial class StockOutNewForm : FormCommon
    {
        string issueFlag = string.Empty;
        string processCD = string.Empty;
        List<PrintItem> listLabel { get; set; }
        BindingList<OutputItem> listOut { get; set; }
        BindingList<PrintItem> listPrint { get; set; }
        BindingList<pts_stock> listStock { get; set; }
        BindingList<pts_stockout_log> listStockOut { get; set; }


        #region FORM EVENT
        public StockOutNewForm()
        {
            InitializeComponent();
            listLabel = new List<PrintItem>();
            listOut = new BindingList<OutputItem>();
            listPrint = new BindingList<PrintItem>();
            listStock = new BindingList<pts_stock>();
            listStockOut = new BindingList<pts_stockout_log>();

        }

        private void StockOutNewForm_Load(object sender, EventArgs e)
        {
            GetCmb();
            EventLoadControl(true);
            txtUserCode.Select();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (ActiveControl == txtBarcode)
                {
                    if (!tbpNoSet.Visible)
                    {
                        return true;
                    }
                    else
                    {

                    }
                }
                SelectNextControl(ActiveControl, true, true, true, true);
                return true;
            }
            else if (keyData == Keys.Back)
            {
                SelectNextControl(ActiveControl, false, true, true, true);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region MAIN TAB
        //OK
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
                System.Diagnostics.Debug.Print(ex.Message);
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
            issueFlag = cmbIssue.SelectedValue.ToString();
            if (issueFlag == "20") tbpNoSet.Visible = true;
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
        private void CheckDigit_KeyPress(object sender, KeyPressEventArgs e)
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

        #region CONTROL SELECT EVENT
        private void EventLoadControl(bool isAdd)
        {
            foreach (Control c in Controls)
            {
                if (c.TabStop && isAdd)
                {
                    c.Enter += ControlEnterEvent;
                    c.Leave += ControlLeaveEvent;
                }
                else if (c.TabStop && !isAdd)
                {
                    c.Enter -= ControlEnterEvent;
                    c.Leave -= ControlLeaveEvent;
                }
            }
        }
        private void ControlEnterEvent(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.FromKnownColor(KnownColor.Yellow);
        }

        private void ControlLeaveEvent(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.FromKnownColor(KnownColor.Window);
        }
        #endregion
        #endregion

        //OK
        #region SUBS EVENT
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
                double packingqty = 0;
                if (temp.Contains(";"))
                {
                    string[] barcode = temp.Split(';');
                    txtItemCode.Text = barcode[0].Trim();
                    txtInvoice.Text = barcode[3].Trim();
                    packingqty = double.Parse(barcode[5].Trim());
                }
                else
                {
                    txtItemCode.Text = temp;
                    txtInvoice.ResetText();
                }
                if (issueFlag == "20") SearchItemSet(txtItemCode.Text, txtSetNumber.Text);
                else SearchNoSet(txtItemCode.Text, txtInvoice.Text, packingqty);
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
            //dgvSearch.Columns.Clear();
            dgvSearch.DataSource = null;
            txtUserCode.Select();
        }

        /// <summary>
        /// Check empty fields
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            if (string.IsNullOrEmpty(txtUserCode.Text))
            {
                CustomMessageBox.Error("User code is empty" + Environment.NewLine + "Vui lòng điền mã số nhân viên!");
                return false;
            }
            if (string.IsNullOrEmpty(txtItemCode.Text))
            {
                CustomMessageBox.Error("Item code is empty" + Environment.NewLine + "Vui lòng điền mã nguyên liệu!");
                return false;
            }
            if (string.IsNullOrEmpty(cmbIssue.Text))
            {
                CustomMessageBox.Error("Issue code is empty" + Environment.NewLine + "Vui lòng chọn lí do xuất hàng!");
                return false;
            }
            if (string.IsNullOrEmpty(cmbDestination.Text))
            {
                CustomMessageBox.Error("Destination code is empty" + Environment.NewLine + "Vui lòng chọn phòng ban!");
                return false;
            }
            return true;
        }

        #endregion

        #region NO SET EVENT
        /// <summary>
        /// Search no set items
        /// </summary>
        /// <param name="itemNumber">item number</param>
        /// <param name="invoiceText">invoice</param>
        private void SearchNoSet(string itemNumber, string invoiceText, double deliveryQty)
        {
            try
            {
                pts_item itemdata = new pts_item();
                itemdata = itemdata.GetItem(itemNumber);
                double totalWHQty = itemdata.wh_qty;
                txtWHQty.Text = totalWHQty.ToString();
                pts_stock stockdata = new pts_stock();
                stockdata.SearchItem(new pts_stock { item_cd = itemNumber, invoice = invoiceText, packing_qty = deliveryQty }, true);
                double totalPackingQty = stockdata.listStockItems.Select(x => x.packing_qty).Sum();
                txtTotalPackingQty.Text = totalPackingQty.ToString();
                dgvSearch.Columns.Clear();
                dgvSearch.DataSource = null;
                dgvSearch.DataSource = stockdata.listStockItems;
                //dgvSearch.Columns["stock_id"].HeaderText = "ID";
                dgvSearch.Columns["packing_cd"].HeaderText = "Packing Code";
                dgvSearch.Columns["item_cd"].HeaderText = "Item Number";
                dgvSearch.Columns["supplier_cd"].HeaderText = "Supplier Code";
                //dgvSearch.Columns["order_no"].HeaderText = "Order Number";
                dgvSearch.Columns["invoice"].HeaderText = "Invoice";
                dgvSearch.Columns["stockin_date"].HeaderText = "Stock-In Date";
                dgvSearch.Columns["stockin_user_cd"].HeaderText = "Incharge";
                dgvSearch.Columns["stockin_qty"].HeaderText = "Stock-In Qty";
                dgvSearch.Columns["packing_qty"].HeaderText = "Packing Qty";
                //dgvSearch.Columns["registration_user_cd"].HeaderText = "Reg User";
                //dgvSearch.Columns["registration_date_time"].HeaderText = "Reg Time";
                if (dgvSearch.Columns.Contains("stock_id")) dgvSearch.Columns.Remove("stock_id");
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
            double deliveryQty = 0;
            double whQty = double.Parse(txtWHQty.Text);
            double stockoutQty = double.Parse(txtStockOutQty.Text);
            double totalPackQty = double.Parse(txtTotalPackingQty.Text);
            txtWHQty.Text = (whQty - stockoutQty).ToString();
            processCD = "NP-" + dtpStockOutDate.Value.ToString("yyyyMMdd-HHmmss");
            if (stockoutQty == 0 || string.IsNullOrEmpty(txtStockOutQty.Text))
            {
                CustomMessageBox.Notice("Please fill Stock-Out Q'ty" + Environment.NewLine + "Vui lòng điền số lượng cần xuất!");
                return;
            }
            if (stockoutQty > whQty || stockoutQty > totalPackQty)
            {
                CustomMessageBox.Notice("Stock-Out Q'ty can't more than Stock Q'ty!" + Environment.NewLine + "Số lượng xuất không thể lớn hơn số lượng tồn!");
                return;
            }
            pts_stock stockData = new pts_stock();
            pts_supplier supplierData = new pts_supplier();
            for (int i = 0; i < dgvSearch.Rows.Count; i++)
            {
                stockData = dgvSearch.Rows[i].DataBoundItem as pts_stock;
                if (stockData.packing_qty == 0) continue;
                if (stockoutQty > stockData.packing_qty)
                {
                    deliveryQty = stockData.packing_qty;
                    stockoutQty -= stockData.packing_qty;
                    stockData.packing_qty = 0;
                }
                else
                {
                    deliveryQty = stockoutQty;
                    stockoutQty = 0;
                    stockData.packing_qty -= deliveryQty;
                    #region ADD PRINT ITEM
                    listPrint.Add(new PrintItem
                    {
                        Item_Number = txtItemCode.Text,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = stockData.supplier_cd }).supplier_name,
                        Invoice = stockData.invoice,
                        Delivery_Date = stockData.stockin_date,
                        Delivery_Qty = stockData.packing_qty,
                        SupplierCD = stockData.supplier_cd,
                        isRec = true,
                        Label_Qty = 1,
                    });
                    listPrint.Add(new PrintItem
                    {
                        Item_Number = txtItemCode.Text,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = stockData.supplier_cd }).supplier_name,
                        Invoice = stockData.invoice,
                        Delivery_Date = dtpStockOutDate.Value,
                        Delivery_Qty = deliveryQty,
                        SupplierCD = stockData.supplier_cd,
                        isRec = false,
                        Label_Qty = 1,
                    });
                    #endregion
                }
                int lbqty = listLabel.Where(x => x.Item_Number == txtItemCode.Text && x.Invoice == stockData.invoice)
                                     .Sum(x => x.Label_Qty);
                if (lbqty == 0)
                {
                    listLabel.Add(new PrintItem
                    {
                        Item_Number = txtItemCode.Text,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = stockData.supplier_cd }).supplier_name,
                        Invoice = stockData.invoice,
                        Delivery_Date = dtpStockOutDate.Value,
                        Delivery_Qty = deliveryQty,
                        SupplierCD = stockData.supplier_cd,
                        isRec = false,
                        Label_Qty = 1,
                    });
                }
                else
                {
                    int lbindex = listLabel.Where(x => x.Item_Number == txtItemCode.Text && x.Invoice == stockData.invoice)
                     .Select(x => listLabel.IndexOf(x)).First();
                    listLabel[lbindex].Label_Qty += 1;
                }
                ListOutAdd(stockData.packing_cd, deliveryQty);
                listStock.Add(stockData);
            }
            UpdateGridLabel(listLabel);
            UpdateGridPrint(listPrint);
            UpdateGridStockOut(listStockOut);
        }
        #endregion

        #region SET EVENT
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
                btnStockOut.Text = "9. OPEN SET";
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
                //dgvSetData.Rows[i].Cells["stockout_qty"].Value = temp;
                dgvSetData.Rows[i].Cells["request_qty"].Value = (double)dgvSetData.Rows[i].Cells["request_qty"].Value - temp;
            }
            txtSetBarcode.Focus();
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
            dgvSetData.Columns["stockout_qty"].HeaderText = "Stock-Out Qty";
            dgvSetData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        /// <summary>
        /// Get data field in main tab to set tab
        /// </summary>
        /// <param name="orderNo">order number</param>
        /// <param name="orderQty">request qty</param>
        /// <param name="orderDate">request date</param>
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

        #region ADD LIST
        private void ListOutAdd(string packingcode, double deliveryQty)
        {
            listStockOut.Add(new pts_stockout_log
            {
                packing_cd = packingcode,
                process_cd = processCD,
                issue_cd = (int)cmbIssue.SelectedValue,
                stockout_date = dtpStockOutDate.Value,
                stockout_user_cd = txtUserCode.Text,
                stockout_qty = deliveryQty,
                comment = txtComment.Text,
                remark = "N",
            });

            listOut.Add(new OutputItem
            {
                issue_cd = (int)cmbIssue.SelectedValue,
                destination_cd = issueFlag,
                item_number = txtItemCode.Text,
                delivery_qty = deliveryQty,
                delivery_date = dtpStockOutDate.Value,
                order_number = string.Empty,
                incharge = txtUserCode.Text,
            });
        }
        #endregion
        #endregion

        #region SET TAB

        #endregion

        #region PRINT TAB
        /// <summary>
        /// Update print grid
        /// </summary>
        /// <param name="inList"></param>
        private void UpdateGridPrint(BindingList<PrintItem> inList)
        {
            dgvPrint.DataSource = inList;
        }
        #endregion

        #region INSPECTIONS TAB
        /// <summary>
        /// Clear all list item
        /// </summary>
        private void ClearDataList()
        {
            listOut.Clear();
            listLabel.Clear();
            listPrint.Clear();
            listStock.Clear();
            listStockOut.Clear();
        }

        private void UpdateGridLabel(List<PrintItem> inlist)
        {
            dgvLabel.DataSource = inlist;
        }

        /// <summary>
        /// Update stock out grid
        /// </summary>
        /// <param name="inList"></param>
        private void UpdateGridStockOut(BindingList<pts_stockout_log> inList)
        {
            dgvStockOut.DataSource = inList;
            //dgvStockOut.Columns["stockout_id"].HeaderText = "ID";
            dgvStockOut.Columns["process_cd"].HeaderText = "Process Code";
            dgvStockOut.Columns["issue_cd"].HeaderText = "Issue Code";
            dgvStockOut.Columns["stockout_date"].HeaderText = "Stock-out date";
            dgvStockOut.Columns["stockout_user_cd"].HeaderText = "Incharge";
            dgvStockOut.Columns["stockout_qty"].HeaderText = "Stock-out Qty";
            //dgvStockOut.Columns["real_qty"].HeaderText = "Real Qty";
            //dgvStockOut.Columns["received_user_cd"].HeaderText = "Received User";
            dgvStockOut.Columns["comment"].HeaderText = "Comment";
            dgvStockOut.Columns["remark"].HeaderText = "Remark";
            if (dgvStockOut.Columns.Contains("stockout_id")) dgvStockOut.Columns.Remove("stockout_id");
            if (dgvStockOut.Columns.Contains("real_qty")) dgvStockOut.Columns.Remove("real_qty");
            if (dgvStockOut.Columns.Contains("received_user_cd")) dgvStockOut.Columns.Remove("received_user_cd");
        }
        #endregion

    }
}
