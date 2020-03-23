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
        bool isSet = false;
        string processCD = string.Empty;
        Color tempColor = new Color();
        Control tempControl = new Control();
        List<pts_plan> listPlan { get; set; }
        List<pts_noplan> listNoPlan { get; set; }
        List<PrintItem> listLabelOut { get; set; }
        List<PrintItem> listLabelStock { get; set; }
        BindingList<OutputItem> listOut { get; set; }
        BindingList<PrintItem> listPrint { get; set; }
        BindingList<pts_stock> listStock { get; set; }
        BindingList<pts_stockout_log> listStockOut { get; set; }
        #endregion

        #region FORM EVENT
        public StockOutV2Form()
        {
            InitializeComponent();
            listPlan = new List<pts_plan>();
            listNoPlan = new List<pts_noplan>();
            listLabelOut = new List<PrintItem>();
            listLabelStock = new List<PrintItem>();
            listOut = new BindingList<OutputItem>();
            listPrint = new BindingList<PrintItem>();
            listStock = new BindingList<pts_stock>();
            listStockOut = new BindingList<pts_stockout_log>();
            dtpStockOutDate.Value = DateTime.Today;
        }

        private void StockOutV2Form_Load(object sender, EventArgs e)
        {
            GetCmb();
            MainClear();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && tc_Main.SelectedTab == tab_Main)
            {
                if (ActiveControl == txtBarcode) MainSearch();
                tempControl.BackColor = tempColor;
                ProcessTabKey(true);
                tempControl = ActiveControl;
                tempColor = ActiveControl.BackColor;
                ActiveControl.BackColor = Color.Yellow;
                return true;
            }
            else if (keyData == Keys.Enter && ActiveControl == txtSetBarcode)
            {
                GetSetBarcode();
                return true;
            }
            else if (keyData == Keys.Enter && ActiveControl == txtSetOutQty)
            {
                GetOutSetQty();
                return true;
            }
            else if (keyData == Keys.Enter && ActiveControl == txtInsBarcode)
            {
                txtInsLabelQty.Focus();
                return true;
            }
            else if (keyData == Keys.Enter && ActiveControl == txtInsLabelQty)
            {
                CheckItem();
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
                    CustomMessageBox.Notice("Need comment when scrap item!" + Environment.NewLine + "Vui lòng điền lí do hủy hàng!");
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
            //if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            if (char.IsLetter(e.KeyChar))
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
        /// Clear all list item
        /// </summary>
        private void ClearDataList()
        {
            listOut.Clear();
            listPrint.Clear();
            listStock.Clear();
            listStockOut.Clear();
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
                CustomMessageBox.Notice("Please fill Stock-Out Q'ty" + Environment.NewLine + "Vui lòng điền số lượng cần xuất!");
                return;
            }
            double deliveryQty = 0;
            double whQty = double.Parse(txtWHQty.Text);
            double stockoutQty = double.Parse(txtStockOutQty.Text);
            double totalPackQty = double.Parse(txtTotalPackingQty.Text);
            txtWHQty.Text = (whQty - stockoutQty).ToString();
            if (stockoutQty > whQty || stockoutQty > totalPackQty)
            {
                CustomMessageBox.Notice("This item is not enough!" + Environment.NewLine + "Không đủ hàng tồn trong kho!");
                return;
            }

            #region ADD NO-PLAN
            processCD = "NP-" + dtpStockOutDate.Value.ToString("yyyyMMdd-HHmmss");
            pts_noplan noplanData = new pts_noplan()
            {
                noplan_cd = processCD,
                item_cd = txtItemCode.Text,
                destination_cd = cmbDestination.SelectedValue.ToString(),
                noplan_date = dtpStockOutDate.Value,
                noplan_usercd = txtUserCode.Text,
                noplan_qty = stockoutQty
            };
            listNoPlan.Add(noplanData);
            #endregion

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
                    #region ADD LABEL OUT
                    listLabelOut.Add(new PrintItem
                    {
                        Item_Number = txtItemCode.Text,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = currentStock.supplier_cd }).supplier_name,
                        Invoice = currentStock.invoice,
                        Delivery_Date = currentStock.stockin_date,
                        Delivery_Qty = deliveryQty,
                        SupplierCD = currentStock.supplier_cd,
                        isRec = false,
                        Label_Qty = 1,
                    });
                    #endregion
                }
                else
                {
                    deliveryQty = stockoutQty;
                    stockoutQty = 0;
                    currentStock.packing_qty -= deliveryQty;
                    #region ADD PRINT ITEM
                    listLabelStock.Add(new PrintItem
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
                    #endregion
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
                #endregion
                if (stockoutQty == 0) break;
            }
            UpdateGridStock(listStock);
            UpdateGridPrint(listPrint);
            UpdateGridStockOut(listStockOut);
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

        #region SET-ITEM EVENT
        #region BUTTONS EVENT
        private void btnSetReg_Click(object sender, EventArgs e)
        {
            try
            {
                OutSet();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnSetDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteLowItem();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnSetBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region FIELDS EVENT
        private void txtSetOutQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            if (char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
        #endregion
        #region SUBS EVENT
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

        /// <summary>
        /// Get item info from barcode
        /// </summary>
        private void GetSetBarcode()
        {
            string temp = txtSetBarcode.Text;
            if (string.IsNullOrEmpty(temp))
            {
                CustomMessageBox.Error("No barcode is scanned!" + Environment.NewLine + "Chưa có barcode được quét!");
                return;
            }
            if (temp.Contains(";"))
            {
                string[] barcode = temp.Split(';');
                txtSetItemCD.Text = barcode[0].Trim();
                txtSetInvoice.Text = barcode[3].Trim();
                txtSetOutQty.Text = barcode[5].Trim();
            }
            else txtSetItemCD.Text = temp;
            txtSetOutQty.Focus();
        }

        /// <summary>
        /// Get stock out qty of each low item
        /// </summary>
        private void GetOutSetQty()
        {
            try
            {
                string itemCode = txtSetItemCD.Text;
                pts_stock stockData = new pts_stock();

                #region CHECK ITEM IS EXIST IN STOCK?
                if (!stockData.SearchItem(new pts_stock { item_cd = itemCode, invoice = txtSetInvoice.Text }))
                {
                    CustomMessageBox.Error("This item is not exist in stock!" + Environment.NewLine + "Nguyên liệu không có trong kho!");
                    txtSetBarcode.ResetText();
                    txtSetInvoice.ResetText();
                    txtSetBarcode.Focus();
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
                    CustomMessageBox.Error("This item is not exist in list!" + Environment.NewLine + "Nguyên liệu không có trong danh sách!" + Environment.NewLine + ex.Message);
                    txtSetBarcode.ResetText();
                    txtSetInvoice.ResetText();
                    txtSetBarcode.Focus();
                    return;
                }
                #endregion

                DataGridViewRow dr = dgvSetData.Rows[rindex];
                double packingQty = double.Parse(txtSetOutQty.Text);
                double orderQty = (double)dr.Cells["request_qty"].Value;
                double stockoutQty = 0;
                if (dr.Cells["stockout_qty"].Value != DBNull.Value && dr.Cells["stockout_qty"].Value != null)
                    stockoutQty = (double)dr.Cells["stockout_qty"].Value;

                #region CHECK ITEM QTY
                double whQty = (double)dr.Cells["wh_qty"].Value;
                double totalpackingQty = stockData.listStockItems.Sum(x => x.packing_qty);
                if (packingQty > whQty)
                {
                    CustomMessageBox.Error("This item is not enough in PREMAC!" + Environment.NewLine + "Số lượng hàng tồn trên PREMAC không đủ!");
                    return;
                }
                if (packingQty > totalpackingQty)
                {
                    CustomMessageBox.Error("This item's pack qty is not enough! Please stock-in first!" + Environment.NewLine + "Số lượng hàng không đủ! Cần nhập hàng trước!");
                    return;
                }
                #endregion

                stockoutQty += packingQty;
                if (stockoutQty > orderQty)
                {
                    packingQty -= stockoutQty - orderQty;
                    stockoutQty = orderQty;
                }
                dr.Cells["stockout_qty"].Value = stockoutQty;

                #region ADD OUTPUT ITEM
                listOut.Add(new OutputItem
                {
                    issue_cd = 20,
                    destination_cd = cmbDestination.SelectedValue.ToString(),
                    item_number = itemCode,
                    delivery_qty = packingQty,
                    delivery_date = dtpStockOutDate.Value,
                    order_number = txtSetOrderNo.Text,
                    incharge = txtSetUserCD.Text,
                });
                #endregion

                pts_supplier supplierData = new pts_supplier();
                foreach (pts_stock item in stockData.listStockItems)
                {
                    if (item.packing_qty == 0) continue;

                    #region ADD STOCK OUT ITEM
                    listStockOut.Add(new pts_stockout_log
                    {
                        packing_cd = item.packing_cd,
                        process_cd = txtSetOrderNo.Text,
                        issue_cd = 20,
                        stockout_date = dtpStockOutDate.Value,
                        stockout_user_cd = txtSetUserCD.Text,
                        stockout_qty = packingQty,
                        comment = txtComment.Text,
                        remark = "N",
                    });
                    #endregion

                    if (packingQty < item.packing_qty)
                    {
                        item.packing_qty -= packingQty;

                        #region ADD PRINT ITEM
                        //ADD LABEL STOCK
                        listLabelStock.Add(new PrintItem
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
                        #endregion

                        packingQty = 0;
                    }
                    else
                    {
                        //ADD LABEL OUT
                        listLabelOut.Add(new PrintItem
                        {
                            Item_Number = item.item_cd,
                            Item_Name = dr.Cells["item_name"].Value.ToString(),
                            SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = item.supplier_cd }).supplier_name,
                            Invoice = txtSetInvoice.Text,
                            Delivery_Date = dtpStockOutDate.Value,
                            Delivery_Qty = item.packing_qty,
                            SupplierCD = item.supplier_cd,
                            isRec = false,
                            Label_Qty = 1
                        });
                        packingQty -= item.packing_qty;
                        item.packing_qty = 0;
                    }
                    listStock.Add(item);
                    if (packingQty == 0) break;
                }
                dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                UpdateGridStockOut(listStockOut);
                UpdateGridPrint(listPrint);
                txtSetBarcode.ResetText();
                txtSetBarcode.Focus();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
                txtSetBarcode.ResetText();
                txtSetInvoice.ResetText();
                txtSetBarcode.Focus();
            }
        }

        /// <summary>
        /// Stock out set item
        /// </summary>
        private void OutSet()
        {
            if (CustomMessageBox.Question("Do you want stock-out this set?" + Environment.NewLine + "Bạn có muốn xuất bộ nguyên liệu?") == DialogResult.No)
                return;
            UpdateGridStock(listStock);
            UpdateGridPrint(listPrint);
            UpdateGridStockOut(listStockOut);
            tc_Main.SelectedTab = tab_Print;
        }

        private void DeleteLowItem()
        {
            if (CustomMessageBox.Question("Are you sure delete this item?" + Environment.NewLine + "Bạn có chắc xóa nguyên liệu này?") == DialogResult.No)
                return;
            string itemCD = dgvSetData.SelectedRows[0].Cells["low_level_item"].Value.ToString();
            dgvSetData.SelectedRows[0].Cells["stockout_qty"].Value = DBNull.Value;
            var listDel = listStock.Where(x => x.item_cd == itemCD).Select(x => x).ToList();
            var outIndex = listOut.Where(x => x.item_number == itemCD).Select(x => listOut.IndexOf(x)).First();
            listOut.RemoveAt(outIndex);
            for (int i = 0; i < listPrint.Count; i++)
            {
                if (listPrint[i].Item_Number == itemCD)
                {
                    listPrint.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < listDel.Count; i++)
            {
                var stockoutIndex = listStockOut.Where(x => x.packing_cd == listDel[i].packing_cd).Select(x => listStockOut.IndexOf(x)).First();
                listStockOut.RemoveAt(stockoutIndex);
                listDel.RemoveAt(i);
                i--;
            }
            txtSetBarcode.Focus();
        }
        #endregion
        #endregion

        #region PRINT EVENT
        #region BUTTONS EVENT
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                List<PrintItem> listPrintItems = new List<PrintItem>();
                if (dgvPrint.Rows.Count == 0)
                {
                    CustomMessageBox.Notice("Don't have item to print!" + Environment.NewLine + "Không có tem cần in!");
                    return;
                }
                if (listPrint[0].CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline" + Environment.NewLine + "Máy in chưa mở!");
                    return;
                }
                foreach (DataGridViewRow dr in dgvPrint.Rows)
                {
                    listPrintItems.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                if (listPrint[0].PrintItems(listPrintItems, false))
                    CustomMessageBox.Notice("Print items are completed!" + Environment.NewLine + "In hoàn tất!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintSelect_Click(object sender, EventArgs e)
        {
            try
            {
                List<PrintItem> listPrintItems = new List<PrintItem>();
                if (dgvPrint.Rows.Count == 0)
                {
                    CustomMessageBox.Notice("Don't have item to print!" + Environment.NewLine + "Không có tem cần in!");
                    return;
                }
                if (listPrint[0].CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline" + Environment.NewLine + "Máy in chưa mở!");
                    return;
                }
                foreach (DataGridViewRow dr in dgvPrint.SelectedRows)
                {
                    listPrintItems.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                if (listPrint[0].PrintItems(listPrintItems, false))
                    CustomMessageBox.Notice("Print items are completed!" + Environment.NewLine + "In hoàn tất!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintInspection_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Inspection;
        }

        private void btnPrintDelete_Click(object sender, EventArgs e)
        {
        }

        private void btnPrinClear_Click(object sender, EventArgs e)
        {
            ClearDataList();
        }

        private void btnPrintBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region SUBS EVENT
        /// <summary>
        /// Update print grid
        /// </summary>
        /// <param name="inList"></param>
        private void UpdateGridPrint(BindingList<PrintItem> inList)
        {
            dgvPrint.DataSource = inList;
        }
        #endregion
        #endregion

        #region INSPECTION
        #region BUTTONS EVENT
        private void btnInsReg_Click(object sender, EventArgs e)
        {

        }

        private void btnInsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomMessageBox.Warring("Are you sure delete this item?" + Environment.NewLine + "Bạn có chắc muốn xóa nguyên liệu này khỏi danh sách xuất?") == DialogResult.No) return;
                DeleteStockOutItem();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInsClear_Click(object sender, EventArgs e)
        {

        }

        private void btnInsBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Print;
        }
        #endregion

        #region FIELDS EVEMT
        private void txtInsLabelQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
            if (char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
        #endregion

        #region SUBS EVENT
        private void CheckItem()
        {
            string temp = txtInsBarcode.Text;
            string[] barcode = temp.Split(';');
            string itemCD = barcode[0].Trim();
            string invoice = barcode[3].Trim();
            double deliveryQty = double.Parse(barcode[5].Trim());
            double totalQty = deliveryQty * double.Parse(txtInsLabelQty.Text);
            var labeloutQty = listLabelOut.Where(x => x.Item_Number == itemCD && x.Invoice == invoice && x.Delivery_Qty == deliveryQty)
                                            .Sum(x => x.Label_Qty);
            var labelStock = listLabelStock.Where(x => x.Item_Number == itemCD && x.Invoice == invoice && x.Delivery_Qty == deliveryQty)
                                .Select(x => x).First();
            if (labelStock != null)
            {
                var stockindex = listStock.Where(x => x.item_cd == labelStock.Item_Number && x.invoice == labelStock.Invoice)
                                          .Select(x => listStock.IndexOf(x)).First();
                dgvInsStock.Rows[stockindex].Cells["check_stock_qty"].Value = labelStock.Delivery_Qty;
            }
            var checkList = listStock.Where(x => x.item_cd == itemCD && x.invoice == invoice).Select(x => x).ToList();
            for (int i = 0; i < checkList.Count; i++)
            {

            }
        }

        /// <summary>
        /// Delete stock out item
        /// </summary>
        private void DeleteStockOutItem()
        {
            DataGridViewRow dr = dgvStockOut.SelectedRows[0];
            string packingCD = dr.Cells["packing_cd"].Value.ToString();
            if (dr.Index < 0)
            {
                CustomMessageBox.Error("Please choose item first!" + Environment.NewLine + "Chưa chọn nguyên liệu cần xóa!");
                return;
            }
            int stockIndex = listStock.Where(x => x.packing_cd == packingCD).Select(x => listStock.IndexOf(x)).First();
            int outIndex = listOut.Where(x => x.item_number == listStock[stockIndex].item_cd).Select(x => listOut.IndexOf(x)).First();
            listOut[outIndex].delivery_qty -= (double)dr.Cells["stockout_qty"].Value;
            if (isSet)
            {
                int setIndex = dgvSetData.Rows.Cast<DataGridViewRow>()
                               .Where(x => x.Cells["low_level_item"].Value.ToString() == listStock[stockIndex].item_cd)
                               .Select(x => x.Index).First();
                double tempQty = (double)dgvSetData.Rows[setIndex].Cells["stockout_qty"].Value;
                tempQty -= (double)dr.Cells["stockout_qty"].Value;
                dgvSetData.Rows[setIndex].Cells["stockout_qty"].Value = tempQty;
            }
            else
            {
                int nosetIndex = dgvSearch.Rows.Cast<DataGridViewRow>()
                                  .Where(x => x.Cells["packing_cd"].Value.ToString() == packingCD)
                                  .Select(x => x.Index).First();
                dgvSearch.Rows[nosetIndex].Cells["packing_qty"].Value = dr.Cells["stockout_qty"].Value;
            }
            listOut.RemoveAt(outIndex);
            listStock.RemoveAt(stockIndex);
            listStockOut.RemoveAt(dr.Index);
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
            if (!dgvStockOut.Columns.Contains("check_stockout_qty"))
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Name = "check_stockout_qty";
                col.HeaderText = "Check Qty";
                col.ValueType = typeof(double);
                col.DefaultCellStyle.NullValue = "0";
                col.CellTemplate = new DataGridViewTextBoxCell();
                dgvStockOut.Columns.Add(col);
            }
        }

        private void UpdateGridStock(BindingList<pts_stock> inlist)
        {
            dgvInsStock.DataSource = inlist;
            //dgvInsStock.Columns["stock_id"].HeaderText = "ID";
            dgvInsStock.Columns["packing_cd"].HeaderText = "Packing Code";
            dgvInsStock.Columns["item_cd"].HeaderText = "Item Code";
            dgvInsStock.Columns["supplier_cd"].HeaderText = "Supplier Code";
            dgvInsStock.Columns["order_no"].HeaderText = "Order Number";
            dgvInsStock.Columns["invoice"].HeaderText = "Invoice";
            dgvInsStock.Columns["stockin_date"].HeaderText = "Stock-in Date";
            dgvInsStock.Columns["stockin_user_cd"].HeaderText = "Incharge";
            dgvInsStock.Columns["stockin_qty"].HeaderText = "Stock-in Qty";
            dgvInsStock.Columns["packing_qty"].HeaderText = "Packing Qty";
            //dgvInsStock.Columns["registration_user_cd"].HeaderText = "Reg User";
            //dgvInsStock.Columns["registration_date_time"].HeaderText = "Reg Date";
            if (dgvInsStock.Columns.Contains("stock_id")) dgvInsStock.Columns.Remove("stock_id");
            if (dgvInsStock.Columns.Contains("registration_user_cd")) dgvInsStock.Columns.Remove("registration_user_cd");
            if (dgvInsStock.Columns.Contains("registration_date_time")) dgvInsStock.Columns.Remove("registration_date_time");
            if (!dgvInsStock.Columns.Contains("check_stock_qty"))
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Name = "check_stock_qty";
                col.HeaderText = "Check Qty";
                col.ValueType = typeof(double);
                col.DefaultCellStyle.NullValue = "0";
                col.CellTemplate = new DataGridViewTextBoxCell();
                dgvInsStock.Columns.Add(col);
            }
        }
        #endregion

        #endregion
    }
}
