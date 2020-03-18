using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockOutputForm : FormCommon
    {
        #region VARIABLE
        bool isSet = false;
        string processCD = string.Empty;
        List<pts_plan> listPlan = new List<pts_plan>();
        ErrorProvider errorProvider = new ErrorProvider();
        List<PrintItem> listPrint = new List<PrintItem>();
        List<pts_stock> listStock = new List<pts_stock>();
        List<OutputItem> listOut = new List<OutputItem>();
        List<pts_noplan> listNoplan = new List<pts_noplan>();
        List<PrintItem> listPrintItems = new List<PrintItem>();
        List<pts_stockout_log> listStockOut = new List<pts_stockout_log>();
        #endregion

        #region FORM EVENT
        public StockOutputForm()
        {
            InitializeComponent();
            tc_StockOut.ItemSize = new Size(0, 1);
            dtpStockOutDate.Value = DateTime.Today;
        }

        private void StockOutputForm_Load(object sender, EventArgs e)
        {
            GetCmb();
            cmbIssue.Select();
        }
        #endregion

        #region TAB_MAIN
        #region FIELDS EVENT
        #region USER EVENT
        private void txtUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string temp = txtUserCode.Text;
                if (temp.Contains(";"))
                    temp = temp.Split(';')[0].Trim();
                if (temp.Length > 6) txtUserCode.Text = temp.Substring(temp.Length - 6);
                else txtUserCode.Text = temp;
                txtBarcode.Focus();
            }
        }

        private void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserCode.Text))
            {
                errorProvider.SetError(txtUserCode, null);
                lbUserName.Text = "User Name";
                lbUserName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        private void txtUserCode_Validated(object sender, EventArgs e)
        {
            try
            {
                m_mes_user muser = new m_mes_user();
                muser = muser.GetUser(txtUserCode.Text);
                lbUserName.Text = muser.user_name;
                lbUserName.BackColor = Color.Lime;
                errorProvider.SetError(txtUserCode, null);
            }
            catch (Exception ex)
            {
                txtUserCode.Focus();
                lbUserName.Text = "User Name";
                lbUserName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                errorProvider.SetError(txtUserCode, "Wrong User Code" + Environment.NewLine + ex.Message);
            }
        }
        #endregion

        #region ITEM EVENT
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                    txtInvoice.Clear();
                }
                if (cmbIssue.SelectedValue.ToString() == "20") SearchSet(txtItemCode.Text, txtSetNumber.Text);
                else SearchNoSet(txtItemCode.Text, txtInvoice.Text);
                txtBarcode.Clear();
                txtStockOutQty.Focus();
            }
        }

        private void txtNoPlanItemCD_TextChanged(object sender, EventArgs e)
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
                errorProvider.SetError(txtItemCode, null);
            }
            catch (Exception ex)
            {
                lbItemName.Text = "Item Name";
                lbItemName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                errorProvider.SetError(txtItemCode, "Wrong Item Code" + Environment.NewLine + ex.Message);
            }
        }
        #endregion

        #region ISSUE EVENT
        private void cmbIssue_Format(object sender, ListControlConvertEventArgs e)
        {
            string code = ((pts_issue_code)e.ListItem).issue_cd.ToString();
            string iname = ((pts_issue_code)e.ListItem).issue_name;
            e.Value = code + ": " + iname;
        }

        private void cmbIssue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIssue.SelectedIndex > 0) pnlNoSetOption.Visible = true;
            else pnlNoSetOption.Visible = false;
            cmbDestination.Select();
        }
        #endregion

        #region DESTINATION EVENT
        private void cmbDestination_Format(object sender, ListControlConvertEventArgs e)
        {
            string code = ((pts_destination)e.ListItem).destination_cd;
            string iname = ((pts_destination)e.ListItem).destination_name;
            e.Value = code + ": " + iname;
        }

        private void cmbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDestination.Text)) txtUserCode.Focus();
        }
        #endregion

        #region QTY EVENT
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
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

        #region DATAGRIDVIEW EVENT
        private void dgvMainStockOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (cmbIssue.SelectedValue.ToString() == "20")
            {
                //btnRegister.Enabled = true;
                btnRegister.Text = "9. Open Set";
                if (e.ColumnIndex == dgvMainStockOut.Columns["btnOpenSet"].Index)
                {
                    //if (!CheckFields()) return;
                    OpenSet(e.RowIndex);
                }
            }
            else
            {
                //btnRegister.Enabled = true;
                btnRegister.Text = "9. Create Item";
            }
        }

        private void dgvMainStockOut_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvMainStockOut.DataSource == null)
            {
                //btnRegister.Enabled = false;
                return;
            }
            if (cmbIssue.SelectedValue.ToString() == "20") btnRegister.Text = "9. Open Set";
            else btnRegister.Text = "9. Create Item";
            dgvMainStockOut.ClearSelection();
            //btnRegister.Enabled = false;
        }
        #endregion
        #endregion

        #region BUTTONS EVENT
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMainStockOut.DataSource = null;
            dgvMainStockOut.Columns.Clear();
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
                txtInvoice.Clear();
            }
            if (cmbIssue.SelectedValue.ToString() == "20")
                SearchSet(txtItemCode.Text, txtSetNumber.Text);
            else SearchNoSet(txtItemCode.Text, txtInvoice.Text);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                isSet = false;
                listOut.Clear();
                listPlan.Clear();
                listPrint.Clear();
                listStock.Clear();
                listNoplan.Clear();
                listStockOut.Clear();
                if (cmbIssue.SelectedValue.ToString() == "30" && string.IsNullOrEmpty(txtComment.Text))
                {
                    CustomMessageBox.Error("Please write comment when scrap item");
                    return;
                }
                if (cmbIssue.SelectedValue.ToString() == "20")
                    OpenSet(dgvMainStockOut.SelectedCells[0].RowIndex);
                else
                {
                    if (CustomMessageBox.Question("Do you want stock-out this item?") == DialogResult.No) return;
                    CreateListNoSet();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            tc_StockOut.SelectedTab = tab_Print;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion

        #region SUB EVENT
        #region FIELDS
        /// <summary>
        /// Get data lis for combobox
        /// </summary>
        private void GetCmb()
        {
            pts_issue_code issueData = new pts_issue_code();
            issueData.GetListIssueCode();
            cmbIssue.DataSource = issueData.listIssueCode;
            cmbIssue.ValueMember = "issue_cd";
            cmbIssue.SelectedIndex = -1;
            pts_destination desData = new pts_destination();
            desData.GetListDestination(string.Empty, string.Empty);
            cmbDestination.DataSource = desData.listdestination;
            cmbDestination.ValueMember = "destination_cd";
            cmbDestination.SelectedIndex = -1;
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        private void Clear()
        {
            txtWHQty.Clear();
            txtInvoice.Clear();
            txtComment.Clear();
            txtUserCode.Clear();
            txtItemCode.Clear();
            txtSetNumber.Clear();
            txtStockOutQty.Clear();
            cmbIssue.Text = null;
            cmbDestination.Text = null;
            dgvMainStockOut.Columns.Clear();
            dgvMainStockOut.DataSource = null;
        }

        /// <summary>
        /// Check fields empty and alert
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

        #region NO SET
        /// <summary>
        /// Search stock item
        /// </summary>
        /// <param name="itemNumber"></param>
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
                dgvMainStockOut.DataSource = stockdata.listStockItems;
                dgvMainStockOut.Columns["stock_id"].HeaderText = "ID";
                dgvMainStockOut.Columns["packing_cd"].HeaderText = "Packing Code";
                dgvMainStockOut.Columns["item_cd"].HeaderText = "Item Number";
                dgvMainStockOut.Columns["supplier_cd"].HeaderText = "Supplier Code";
                dgvMainStockOut.Columns["order_no"].HeaderText = "Order Number";
                dgvMainStockOut.Columns["invoice"].HeaderText = "Invoice";
                dgvMainStockOut.Columns["stockin_date"].HeaderText = "Stock-In Date";
                dgvMainStockOut.Columns["stockin_user_cd"].HeaderText = "Incharge";
                dgvMainStockOut.Columns["stockin_qty"].HeaderText = "Stock-In Qty";
                dgvMainStockOut.Columns["packing_qty"].HeaderText = "Packing Qty";
                dgvMainStockOut.Columns["registration_user_cd"].HeaderText = "Reg User";
                dgvMainStockOut.Columns["registration_date_time"].HeaderText = "Reg Time";
                if (dgvMainStockOut.Columns.Contains("order_no")) dgvMainStockOut.Columns.Remove("order_no");
                if (dgvMainStockOut.Columns.Contains("registration_user_cd")) dgvMainStockOut.Columns.Remove("registration_user_cd");
                if (dgvMainStockOut.Columns.Contains("registration_date_time")) dgvMainStockOut.Columns.Remove("registration_date_time");
                if (dgvMainStockOut.Columns.Contains("btnOpenSet")) dgvMainStockOut.Columns.Remove("btnOpenSet");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        /// <summary>
        /// Create list no plan items
        /// </summary>
        private void CreateListNoSet()
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
            foreach (DataGridViewRow dr in dgvMainStockOut.Rows)
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
                }

                #region ADD LIST STOCK AND LIST STOCK OUT
                listStock.Add(currentStock);
                listStockOut.Add(new pts_stockout_log
                {
                    packing_cd = currentStock.packing_cd,
                    process_cd = processCD,
                    issue_cd = (int)cmbIssue.SelectedValue,
                    stockout_date = dtpStockOutDate.Value,
                    stockout_user_cd = txtSetUserCD.Text,
                    stockout_qty = deliveryQty,
                    comment = txtComment.Text,
                    remark = "N",
                });
                if (currentStock.packing_qty > 0)
                {
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
            UpdateGridPrint(listPrint);
            UpdateGridStockOut(listStockOut);
            tc_StockOut.SelectedTab = tab_Print;
        }

        /// <summary>
        /// Register No Set
        /// </summary>
        private void RegNoSet()
        {
            if (CustomMessageBox.Question("Do you want register this stock-out item?") == DialogResult.No) return;
            #region ADD NEW NO PLAN ITEM
            string processCD = "NP" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
            pts_noplan noplanData = new pts_noplan()
            {
                noplan_cd = processCD,
                destination_cd = cmbDestination.SelectedValue.ToString(),
                item_cd = txtItemCode.Text,
                noplan_qty = double.Parse(txtStockOutQty.Text),
                noplan_usercd = txtUserCode.Text,
                noplan_date = dtpStockOutDate.Value
            };
            noplanData.AddItem(noplanData);
            listNoplan.Add(noplanData);
            #endregion
            UpdateGridProcess(0);
            listOut[0].ExportCSV(listOut);
            listStock[0].UpdateMultiItem(listStock);
            listStockOut[0].AddMultiItem(listStockOut);
            CustomMessageBox.Notice("Register process " + processCD + " successful!");
        }
        #endregion

        #region SET
        /// <summary>
        /// Search order number
        /// </summary>
        /// <param name="itemNumber"></param>
        private void SearchSet(string itemNumber, string setNumber)
        {
            try
            {
                pre_649_order orderData = new pre_649_order();
                orderData.Search(new pre_649_order
                {
                    item_number = itemNumber,
                    order_number = setNumber
                });
                dgvMainStockOut.DataSource = orderData.listOrderItem;
                dgvMainStockOut.Columns["item_number"].HeaderText = "Item Number";
                dgvMainStockOut.Columns["order_number"].HeaderText = "Order Number";
                dgvMainStockOut.Columns["order_qty"].HeaderText = "Order Qty";
                dgvMainStockOut.Columns["order_date"].HeaderText = "Order Date";
                dgvMainStockOut.Columns["supplier_cd"].HeaderText = "Supplier Code";
                if (!dgvMainStockOut.Columns.Contains("btnOpenSet"))
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.Name = "btnOpenSet";
                    col.HeaderText = "Open Set";
                    col.Text = "Open";
                    col.UseColumnTextForButtonValue = true;
                    dgvMainStockOut.Columns.Insert(0, col);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        /// <summary>
        /// Open set list item with select cell
        /// </summary>
        /// <param name="RowIndex"></param>
        private void OpenSet(int RowIndex)
        {
            if (!CheckFields()) return;
            DataGridViewRow dr = dgvMainStockOut.Rows[RowIndex];
            GetSetOptions(dr.Cells["order_number"].Value.ToString(), (double)dr.Cells["order_qty"].Value, (DateTime)dr.Cells["order_date"].Value);
            SearchLowItem(txtItemCode.Text, (double)dr.Cells["order_qty"].Value, dr.Cells["order_number"].Value.ToString());
            tc_StockOut.SelectedTab = tab_ItemSet;
            pts_stockout_log stockoutData = new pts_stockout_log();
            double temp = 0;
            for (int i = 0; i < dgvSetData.Rows.Count; i++)
            {
                temp = stockoutData.GetStockOutQty(dr.Cells["order_number"].Value.ToString(), dgvSetData.Rows[i].Cells["low_level_item"].Value.ToString());
                dgvSetData.Rows[i].Cells["stockout_qty"].Value = temp;
            }
            txtSetLowItem.Focus();
        }

        /// <summary>
        /// Search list low item
        /// </summary>
        /// <param name="hiItem"></param>
        /// <param name="orderQty"></param>
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
        #endregion
        #endregion

        #region TAB_ITEM SET
        #region FIELDS EVENT
        private void txtSetLowItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region GET QR-CODE DATA
                if (txtSetLowItem.Text.Contains(";"))
                {
                    string[] barcode = txtSetLowItem.Text.Split(';');
                    txtSetLowItemCode.Text = barcode[0].Trim();
                    txtSetInvoice.Text = barcode[3].Trim();
                    txtSetStockOutQty.Text = barcode[5];
                }
                #endregion

                #region OLD
                //CHECK STOCKOUT QTY
                ////IF STOCKOUT QTY < REQUEST QTY => GET ALL
                //if (orderQty > (stockQty + stockoutQty))
                //{
                //    dr.Cells["stockout_qty"].Value = stockQty + stockoutQty;
                //    res = stockQty;
                //}
                ////ELSE GET ENOUGH REQUEST QTY
                //else
                //{
                //    dr.Cells["stockout_qty"].Value = orderQty;
                //    res = orderQty - stockoutQty;
                //}
                //pts_supplier supplierData = new pts_supplier();
                //#region ADD LIST STOCK AND LIST STOCK OUT WITH RES QTY
                //foreach (pts_stock item in stockData.listStockItems)
                //{
                //    //IF PACKING QTY = 0 SKIP
                //    if (item.packing_qty == 0) continue;
                //    //ADD NEW STOCK OUT LOG
                //    listStockOut.Add(new pts_stockout_log
                //    {
                //        packing_cd = item.packing_cd,
                //        process_cd = txtSetOrderNum.Text,
                //        issue_cd = 20,
                //        stockout_date = dtpStockOutDate.Value,
                //        stockout_user_cd = txtSetUserCD.Text,
                //        stockout_qty = res,
                //        comment = txtComment.Text,
                //        remark = "N",
                //    });
                //    //ADD OUTPUT ITEM FOR CSV
                //    listOut.Add(new OutputItem
                //    {
                //        issue_cd = 20,
                //        destination_cd = cmbDestination.SelectedValue.ToString(),
                //        item_number = item.item_cd,
                //        delivery_qty = res,
                //        delivery_date = dtpStockOutDate.Value,
                //        order_number = txtSetOrderNum.Text,
                //        incharge = txtSetUserCD.Text,
                //    });
                //    //ADD STOCK-OUT TO PRINT LIST
                //    listPrint.Add(new PrintItem
                //    {
                //        Item_Number = item.item_cd,
                //        Item_Name = dr.Cells["item_name"].Value.ToString(),
                //        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = item.supplier_cd }).supplier_name,
                //        Invoice = txtSetInvoice.Text,
                //        Delivery_Date = dtpStockOutDate.Value,
                //        Delivery_Qty = res,
                //        SupplierCD = item.supplier_cd,
                //        isRec = false,
                //        Label_Qty = 1,
                //    });
                //    //IF PACKING QTY > RES QTY THEN PACKING QTY = PACKING QTY - RES QTY
                //    if (item.packing_qty > res)
                //    {
                //        item.packing_qty -= res;
                //        res = 0;
                //    }
                //    //ELSE RES QTY = RES QTY - PACKING QTY
                //    else
                //    {
                //        res -= item.packing_qty;
                //        item.packing_qty = 0;
                //    }
                //    //ADD STOCK ITEM
                //    item.order_no = txtSetOrderNum.Text;
                //    listStock.Add(item);
                //    if (item.packing_qty > 0)
                //    {
                //        //ADD STOCK-IN TO PRINT LIST
                //        listPrint.Add(new PrintItem
                //        {
                //            Item_Number = item.item_cd,
                //            Item_Name = dr.Cells["item_name"].Value.ToString(),
                //            SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = item.supplier_cd }).supplier_name,
                //            Invoice = txtSetInvoice.Text,
                //            Delivery_Date = item.stockin_date,
                //            Delivery_Qty = item.packing_qty,
                //            SupplierCD = item.supplier_cd,
                //            isRec = true,
                //            Label_Qty = 1
                //        });
                //    }
                //    if (res == 0) break;
                //}
                //#endregion
                #endregion

                txtSetStockOutQty.Focus();
            }
        }

        private void txtSetStockOutQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string itemCode = txtSetLowItemCode.Text;

                    pts_stock stockData = new pts_stock();
                    #region CHECK ITEM IS EXIST IN STOCK?
                    if (!stockData.SearchItem(new pts_stock { item_cd = itemCode, invoice = txtSetInvoice.Text }))
                    {
                        CustomMessageBox.Error("This item is not exist in stock!");
                        txtSetLowItem.Clear();
                        txtSetInvoice.Clear();
                        txtSetLowItem.Focus();
                        return;
                    }
                    #endregion

                    #region GET INDEX OF ITEM IF IT IS EXIST IN SET LIST
                    int rindex = 0;
                    try
                    {
                        rindex = dgvSetData.Rows.Cast<DataGridViewRow>()
                                    .Where(x => x.Cells["low_level_item"].Value.ToString() == itemCode)
                                    .Select(x => x.Index).First();
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Error("This item is not exist in list!" + Environment.NewLine + ex.Message);
                        txtSetLowItem.Clear();
                        txtSetInvoice.Clear();
                        txtSetLowItem.Focus();
                        return;
                    }
                    #endregion

                    DataGridViewRow dr = dgvSetData.Rows[rindex];
                    double totalpackingQty = stockData.listStockItems.Sum(x => x.packing_qty);
                    double packingQty = double.Parse(txtSetStockOutQty.Text);
                    double orderQty = (double)dr.Cells["request_qty"].Value;
                    //double stockQty = (double)dr.Cells["wh_qty"].Value;
                    double stockoutQty = 0;
                    double residualQty = 0;
                    if (dr.Cells["stockout_qty"].Value != null)
                        stockoutQty = (double)dr.Cells["stockout_qty"].Value;

                    //Check qty of label
                    if (packingQty > totalpackingQty)
                    {
                        packingQty = totalpackingQty;
                        CustomMessageBox.Notice("Packing Qty of this item is empty! Please stock-in first!");
                    }
                    stockoutQty += packingQty;
                    if (stockoutQty > orderQty)
                    {
                        packingQty -= stockoutQty - orderQty;
                        stockoutQty = orderQty;
                    }
                    residualQty = totalpackingQty - packingQty;
                    dr.Cells["stockout_qty"].Value = stockoutQty;
                    //ADD OUTPUT ITEM FOR CSV
                    listOut.Add(new OutputItem
                    {
                        issue_cd = 20,
                        destination_cd = cmbDestination.SelectedValue.ToString(),
                        item_number = itemCode,
                        delivery_qty = packingQty,
                        delivery_date = dtpStockOutDate.Value,
                        order_number = txtSetOrderNum.Text,
                        incharge = txtSetUserCD.Text,
                    });

                    pts_supplier supplierData = new pts_supplier();
                    foreach (pts_stock item in stockData.listStockItems)
                    {
                        if (item.packing_qty == 0) continue;
                        //ADD NEW STOCK OUT LOG
                        listStockOut.Add(new pts_stockout_log
                        {
                            packing_cd = item.packing_cd,
                            process_cd = txtSetOrderNum.Text,
                            issue_cd = 20,
                            stockout_date = dtpStockOutDate.Value,
                            stockout_user_cd = txtSetUserCD.Text,
                            stockout_qty = packingQty,
                            comment = txtComment.Text,
                            remark = "N",
                        });
                        if (packingQty < item.packing_qty)
                        {
                            item.packing_qty -= packingQty;
                            //ADD STOCK-IN TO PRINT LIST
                            listPrint.Add(new PrintItem
                            {
                                Item_Number = item.item_cd,
                                Item_Name = dr.Cells["item_name"].Value.ToString(),
                                SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = item.supplier_cd }).supplier_name,
                                Invoice = txtSetInvoice.Text,
                                Delivery_Date = item.stockin_date,
                                Delivery_Qty = item.packing_qty,
                                SupplierCD = item.supplier_cd,
                                isRec = true,
                                Label_Qty = 1
                            });
                            //ADD STOCK-OUT TO PRINT LIST
                            listPrint.Add(new PrintItem
                            {
                                Item_Number = item.item_cd,
                                Item_Name = dr.Cells["item_name"].Value.ToString(),
                                SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = item.supplier_cd }).supplier_name,
                                Invoice = txtSetInvoice.Text,
                                Delivery_Date = dtpStockOutDate.Value,
                                Delivery_Qty = packingQty,
                                SupplierCD = item.supplier_cd,
                                isRec = false,
                                Label_Qty = 1
                            });
                            packingQty = 0;
                        }
                        else
                        {
                            packingQty -= item.packing_qty;
                            item.packing_qty = 0;
                        }
                        listStock.Add(item);
                        if (packingQty == 0) break;
                    }
                    dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                    UpdateGridStockOut(listStockOut);
                    UpdateGridPrint(listPrint);
                    txtSetLowItem.Clear();
                    txtSetLowItem.Focus();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
                txtSetLowItem.Clear();
                txtSetInvoice.Clear();
                txtSetLowItem.Focus();
            }
        }

        private void txtSetStockOutQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        #endregion

        #region BUTTONS EVENT
        private void btnSetReg_Click(object sender, EventArgs e)
        {
            isSet = true;
            if (dgvStockOut.Rows.Count > 0)
                tc_StockOut.SelectedTab = tab_Print;
            else
                CustomMessageBox.Notice("This set no data! Please check and try again!");
        }

        private void btnSetClear_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Warring("Do you want clear all data?" + Environment.NewLine + "All data will be lost") == DialogResult.No) return;
            SetClear();
        }

        private void btnSetBack_Click(object sender, EventArgs e)
        {
            tc_StockOut.SelectedTab = tab_Main;
        }
        #endregion

        #region SUB EVENT
        private void RegSet()
        {
            try
            {
                if (CustomMessageBox.Question("Do you want register this set items?") == DialogResult.No) return;
                string plancode = txtSetOrderNum.Text + "-" + dtpStockOutDate.Value.ToString("yyMMdd");
                pts_plan planData = new pts_plan();
                planData = new pts_plan
                {
                    plan_cd = plancode,
                    destination_cd = cmbDestination.SelectedValue.ToString(),
                    model_cd = txtSetHiItem.Text,
                    set_number = txtSetOrderNum.Text,
                    plan_date = dtpSetOrderDate.Value,
                    plan_usercd = txtSetUserCD.Text,
                    plan_qty = double.Parse(txtSetOrderQty.Text),
                    delivery_date = dtpStockOutDate.Value,
                    comment = txtComment.Text
                };
                try
                {
                    planData.Search(planData);
                    if (planData.listPlan.Count <= 0) planData.Add(planData);
                }
                catch { planData.Add(planData); }
                listPlan.Add(planData);
                listOut[0].ExportCSV(listOut);
                listStock[0].UpdateMultiItem(listStock);
                listStockOut[0].AddMultiItem(listStockOut);
                CustomMessageBox.Notice("Register process " + txtSetOrderNum.Text + " successful!");
                UpdateGridProcess(1);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void GetSetOptions(string orderNo, double orderQty, DateTime orderDate)
        {
            dtpSetOrderDate.Value = orderDate;
            txtSetOrderNum.Text = orderNo;
            txtSetOrderQty.Text = orderQty.ToString();
            txtSetUserCD.Text = txtUserCode.Text;
            txtSetHiItem.Text = txtItemCode.Text;
            txtSetDesCode.Text = cmbDestination.SelectedValue.ToString();
            lbSetUserName.Text = lbUserName.Text;
            lbSetHiItemName.Text = lbItemName.Text;
            lbSetDesName.Text = cmbDestination.Text.Split(':')[1].Trim();
        }

        private void SetClear()
        {
            listOut.Clear();
            listStock.Clear();
            listPrint.Clear();
            listStockOut.Clear();
            txtSetInvoice.Clear();
            txtSetLowItem.Clear();
            foreach (DataGridViewRow dr in dgvSetData.Rows)
            {
                dr.Cells["stockout_qty"].Value = "0";
                dr.DefaultCellStyle.BackColor = Color.White;
            }
        }
        #endregion
        #endregion

        #region TAB_PRINT
        #region BUTTONS EVENT
        private void btnInsClear_Click(object sender, EventArgs e)
        {
            listPlan.Clear();
            listPrint.Clear();
            listNoplan.Clear();
            listStockOut.Clear();
            dgvPrint.DataSource = null;
            dgvProcess.DataSource = null;
            dgvStockOut.DataSource = null;
        }

        private void btnPrintSelect_Click(object sender, EventArgs e)
        {
            try
            {
                listPrintItems.Clear();
                if (dgvPrint.Rows.Count == 0)
                {
                    CustomMessageBox.Notice("Don't have item to print!");
                    return;
                }
                if (listPrint[0].CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline");
                    return;
                }
                foreach (DataGridViewRow dr in dgvPrint.SelectedRows)
                {
                    listPrintItems.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                if (listPrint[0].PrintItems(listPrintItems, false))
                    CustomMessageBox.Notice("Print items are completed!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                listPrintItems.Clear();
                if (dgvPrint.Rows.Count == 0)
                {
                    CustomMessageBox.Notice("Don't have item to print!");
                    return;
                }
                if (listPrint[0].CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline");
                    return;
                }
                foreach (DataGridViewRow dr in dgvPrint.Rows)
                {
                    listPrintItems.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                if (listPrint[0].PrintItems(listPrintItems, false))
                    CustomMessageBox.Notice("Print items are completed!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintInspection_Click(object sender, EventArgs e)
        {
            tc_StockOut.SelectedTab = tab_Inspection;
        }
        #endregion

        #region SUB EVENT
        private void UpdateGridProcess(int state)
        {
            switch (state)
            {
                case 0:
                    dgvProcess.DataSource = listNoplan;
                    break;
                case 1:
                    dgvProcess.DataSource = listPlan;
                    break;
            }
        }

        private void UpdateGridStockOut(List<pts_stockout_log> inList)
        {
            dgvStockOut.DataSource = inList;
        }

        private void UpdateGridPrint(List<PrintItem> inList)
        {
            dgvPrint.DataSource = inList;
        }
        #endregion

        #endregion

        #region TAB_INSPECTION
        private void btnFinalRegister_Click(object sender, EventArgs e)
        {
            if (isSet) RegSet();
            else RegNoSet();
            pts_item itemData = new pts_item();
            itemData.ListStockOutUpdateValue(listOut);
        }
        #endregion
    }
}
