using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockOutNewForm : FormCommon
    {
        double labelQty = 0;
        bool isChecked = false;
        string issueFlag = string.Empty;
        string processCD = string.Empty;
        BindingList<PrintItem> listLabel { get; set; }
        BindingList<OutputItem> listOut { get; set; }
        BindingList<PrintItem> listPrint { get; set; }
        BindingList<pts_stock> listStock { get; set; }
        BindingList<pts_stockout_log> listStockOut { get; set; }

        #region FORM EVENT
        public StockOutNewForm()
        {
            InitializeComponent();
            tc_Main.ItemSize = new Size(0, 1);
            listLabel = new BindingList<PrintItem>();
            listOut = new BindingList<OutputItem>();
            listPrint = new BindingList<PrintItem>();
            listStock = new BindingList<pts_stock>();
            listStockOut = new BindingList<pts_stockout_log>();
        }

        private void StockOutNewForm_Load(object sender, EventArgs e)
        {
            try
            {
                GetCmb();
                txtUserCode.Select();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (ActiveControl == txtBarcode)
                {
                    #region GET BARCODE INFO
                    string temp = txtBarcode.Text;
                    if (temp.Contains(";"))
                    {
                        string[] barcode = temp.Split(';');
                        txtItemCode.Text = barcode[0].Trim();
                        txtInvoice.Text = barcode[3].Trim();
                        labelQty = double.Parse(barcode[5].Trim());
                        txtStockOutQty.Text = labelQty.ToString();
                    }
                    else
                    {
                        txtItemCode.Text = temp;
                        txtInvoice.ResetText();
                        txtStockOutQty.ResetText();
                    }
                    txtBarcode.ResetText();
                    #endregion

                    MainSearch();
                }
                if (ActiveControl == txtSetBarcode)
                {
                    #region GET SET BARCODE INFO
                    string temp = txtSetBarcode.Text;
                    if (temp.Contains(";"))
                    {
                        string[] barcode = temp.Split(';');
                        txtSetItemCD.Text = barcode[0].Trim();
                        txtSetInvoice.Text = barcode[3].Trim();
                        labelQty = double.Parse(barcode[5].Trim());
                        txtSetOutQty.Text = labelQty.ToString();
                        txtSetBarcode.ResetText();

                        #region GET INDEX OF ITEM IF IT IS EXIST IN SET LIST
                        try
                        {
                            int rindex = dgvSetData.Rows.Cast<DataGridViewRow>()
                                         .Where(x => x.Cells["low_level_item"].Value.ToString() == barcode[0].Trim())
                                         .Select(x => x.Index).First();
                            dgvSetData.Rows[rindex].Selected = true;
                        }
                        catch (Exception ex)
                        {
                            CustomMessageBox.Error("This item is not exist in set!" + Environment.NewLine + "Nguyên liệu không có trong danh sách!" + Environment.NewLine + ex.Message);
                            txtSetBarcode.ResetText();
                            txtSetInvoice.ResetText();
                            txtSetBarcode.Focus();
                            return true;
                        }
                        #endregion

                        txtSetOutQty.Focus();
                        return true;
                    }
                    else
                    {
                        txtSetItemCD.Text = temp;
                        txtSetInvoice.ResetText();
                        txtSetOutQty.ResetText();
                        txtSetBarcode.ResetText();
                    }
                    #endregion
                }
                if (ActiveControl == txtSetOutQty)
                {
                    btnSetInputQty.PerformClick();
                    txtSetBarcode.Focus();
                    return true;
                }
                if (ActiveControl == txtInsLabelQty)
                {
                    #region CHECK LABEL
                    string temp = txtInsBarcode.Text;
                    if (temp.Contains(";"))
                    {
                        string[] barcode = temp.Split(';');
                        isChecked = CheckLabel(barcode[0].Trim(), barcode[3].Trim(), double.Parse(barcode[5].Trim()));
                    }
                    else CustomMessageBox.Error("Wrong format barcode!" + Environment.NewLine + "Barcode sai!");
                    txtInsBarcode.ResetText();
                    txtInsBarcode.Focus();
                    return true;
                    #endregion
                }
                SelectNextControl(ActiveControl, true, true, true, true);
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                SelectNextControl(ActiveControl, false, true, true, true);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region MAIN TAB
        #region BUTTONS EVENT
        private void btnStockOut_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dgvSearch.SelectedRows[0].Index;
                if (issueFlag == "30" && string.IsNullOrEmpty(txtComment.Text))
                {
                    CustomMessageBox.Notice("Need comment when scrap item!" + Environment.NewLine + "Vui lòng điền lí do hủy hàng!");
                    return;
                }
                else if (issueFlag == "20")
                {
                    if (i < 0)
                    {
                        CustomMessageBox.Error("Please select one set!" + Environment.NewLine + "Vui lòng chọn một bộ nguyên liệu!");
                        return;
                    }
                    else OpenSet(i);
                }
                else OutNoSet();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                MainSearch();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrint.Rows.Count > 0) tc_Main.SelectedTab = tab_Print;
                else CustomMessageBox.Notice("No item in print list!" + Environment.NewLine + "Không có tem cần in!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Inspection;
            txtInsBarcode.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                MainClear();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion
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
            if (cmbIssue.SelectedIndex <= 0) tbpNoSet.Visible = false;
            else tbpNoSet.Visible = true;
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
                txtBarcode.Focus();
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
                btnStockOut.Text = "9. OPEN SET /" + Environment.NewLine + "Mở Bộ NL";
                if (e.ColumnIndex == dgvSearch.Columns["btnOpenSet"].Index) OpenSet(e.RowIndex);
            }
            else btnStockOut.Text = "9. STOCK-OUT /" + Environment.NewLine + "Xuất Hàng";
        }

        private void dgvSearch_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvSearch.DataSource == null) return;
            if (cmbIssue.SelectedValue.ToString() == "20") btnStockOut.Text = "9. OPEN SET /" + Environment.NewLine + "Mở Bộ NL";
            else btnStockOut.Text = "9. STOCK-OUT /" + Environment.NewLine + "Xuất Hàng";
            dgvSearch.ClearSelection();
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

        /// <summary>
        /// Search item
        /// </summary>
        private void MainSearch()
        {
            try
            {
                if (issueFlag == "20") SearchItemSet(txtItemCode.Text, txtSetNumber.Text);
                else SearchNoSet(txtItemCode.Text, txtInvoice.Text);
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

        private void UpdateGridSearchNoSet(BindingList<pts_stock> inList)
        {
            dgvSearch.DataSource = inList;
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
            btnStockOut.Text = "9. STOCK-OUT /" + Environment.NewLine + "Xuất Hàng";
            dgvSearch.Update();
            dgvSearch.Refresh();
        }

        private void UpdateGridSearchSet(List<pre_649_order> inList)
        {
            dgvSearch.Columns.Clear();
            dgvSearch.DataSource = inList;
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
            btnStockOut.Text = "9. OPEN SET /" + Environment.NewLine + "Mở Bộ NL";
            dgvSearch.Update();
            dgvSearch.Refresh();
        }
        #endregion
        #endregion

        #region SET TAB
        #region BUTTONS EVENT
        private void btnSetInputQty_Click(object sender, EventArgs e)
        {
            try
            {
                InputSet(dgvSetData.SelectedRows[0].Index);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

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
        private void InputSet(int rindex)
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
            //int rindex = 0;
            //try
            //{
            //    rindex = dgvSetData.Rows.Cast<DataGridViewRow>()
            //                .Where(x => x.Cells["low_level_item"].Value.ToString() == itemCode)
            //                .Select(x => x.Index).First();
            //    dgvSetData.Rows[rindex].Selected = true;
            //}
            //catch (Exception ex)
            //{
            //    CustomMessageBox.Error("This item is not exist in set!" + Environment.NewLine + "Nguyên liệu không có trong danh sách!" + Environment.NewLine + ex.Message);
            //    txtSetBarcode.ResetText();
            //    txtSetInvoice.ResetText();
            //    txtSetBarcode.Focus();
            //    return;
            //}
            #endregion

            DataGridViewRow dr = dgvSetData.Rows[rindex];
            double deliveryQty = 0;
            double packingQty = double.Parse(txtSetOutQty.Text);
            double orderQty = (double)dr.Cells["request_qty"].Value;
            double stockoutQty = (double)dr.Cells["stockout_qty"].Value;

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
                if (packingQty < item.packing_qty)
                {
                    deliveryQty = packingQty;
                    item.packing_qty -= packingQty;

                    #region ADD PRINT ITEM
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
                    deliveryQty = item.packing_qty;
                    packingQty -= item.packing_qty;
                    item.packing_qty = 0;
                }
                #region ADD STOCK OUT ITEM
                listStockOut.Add(new pts_stockout_log
                {
                    packing_cd = item.packing_cd,
                    process_cd = txtSetOrderNo.Text,
                    issue_cd = 20,
                    stockout_date = dtpStockOutDate.Value,
                    stockout_user_cd = txtSetUserCD.Text,
                    stockout_qty = deliveryQty,
                    comment = txtComment.Text,
                    remark = "N",
                });
                try
                {
                    int lbindex = listLabel.Where(x => x.Item_Number == item.item_cd && x.Invoice == item.invoice && x.Delivery_Qty == deliveryQty)
                                           .Select(x => listLabel.IndexOf(x)).First();
                    listLabel[lbindex].Label_Qty += 1;
                }
                catch
                {
                    listLabel.Add(new PrintItem
                    {
                        Item_Number = item.item_cd,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = item.supplier_cd }).supplier_name,
                        Invoice = item.invoice,
                        Delivery_Date = dtpStockOutDate.Value,
                        Delivery_Qty = deliveryQty,
                        SupplierCD = item.supplier_cd,
                        isRec = false,
                        Label_Qty = 1,
                    });
                }
                #endregion
                listStock.Add(item);
                if (packingQty == 0) break;
            }
            dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if ((double)dr.Cells["stockout_qty"].Value == orderQty)
                dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Lime);
            txtSetBarcode.ResetText();
            txtSetBarcode.Focus();
        }

        private void OutSet()
        {
            if (CustomMessageBox.Question("Do you want stock-out this set?" + Environment.NewLine + "Bạn có muốn xuất bộ nguyên liệu?") == DialogResult.No)
                return;
            UpdateGridStockOut(listStockOut);
            UpdateGridLabel(listLabel);
            UpdateGridPrint(listPrint);
            CustomMessageBox.Notice("Stock out this set successful! Please print label and check data!" + Environment.NewLine + "Đã xuất bộ nguyên liệu! Vui lòng in tem và kiểm tra!");
            if (dgvPrint.Rows.Count > 0) tc_Main.SelectedTab = tab_Print;
            else
            {
                CustomMessageBox.Notice("No item in print list!" + Environment.NewLine + "Không có tem cần in!");
                tc_Main.SelectedTab = tab_Inspection;
                txtInsBarcode.Focus();
            }
        }
        #endregion

        #region SUBS EVENT
        /// <summary>
        /// Delete an item in set
        /// </summary>
        private void DeleteLowItem()
        {
            if (CustomMessageBox.Question("Are you sure delete this item?" + Environment.NewLine + "Bạn có chắc xóa nguyên liệu này?") == DialogResult.No)
                return;
            string itemCD = dgvSetData.SelectedRows[0].Cells["low_level_item"].Value.ToString();
            dgvSetData.SelectedRows[0].Cells["stockout_qty"].Value = "0";
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
            txtSetBarcode.Select();
        }
        #endregion
        #endregion

        #region PRINT TAB
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
            txtInsBarcode.Focus();
        }

        private void btnPrintBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion
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
        #region BUTTONS EVENT
        private void btnInsReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isChecked)
                {
                    CustomMessageBox.Notice("Please check all label before register!" + Environment.NewLine + "Vui lòng kiểm tra tất cả tem trước khi đăng ký!");
                    return;
                }
                if (CustomMessageBox.Question("Do you want register this data?" + Environment.NewLine + "Bạn có muốn đăng ký dữ liệu này?") == DialogResult.No)
                    return;
                listOut[0].ExportCSV(listOut.ToList());
                listStock[0].UpdateMultiItem(listStock.ToList());
                listStockOut[0].AddMultiItem(listStockOut.ToList());
                pts_item itemData = new pts_item();
                itemData.ListStockOutUpdateValue(listOut.ToList());
                CustomMessageBox.Notice("Register data completed!" + Environment.NewLine + "Dữ liệu được đăng ký hoàn tất!");
                isChecked = false;
                ClearDataList();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLabel.SelectedRows.Count <= 0) return;
                int deleteqty = 0;
                int rindex = dgvLabel.SelectedRows[0].Index;
                InputCommon inputfrm = new InputCommon(false);
                if (inputfrm.ShowDialog() == DialogResult.OK) deleteqty = inputfrm.inputQty;
                if (deleteqty > listLabel[rindex].Label_Qty)
                {
                    CustomMessageBox.Error("Delete qty more than label qty!" + Environment.NewLine + "Số lượng xóa lớn hơn số lượng tem hiện có!");
                    return;
                }
                int outIndex = listOut.Where(x => x.item_number == listLabel[rindex].Item_Number).Select(x => listOut.IndexOf(x)).First();
                var stockList = listStock.Where(x => x.item_cd == listLabel[rindex].Item_Number && x.invoice == listLabel[rindex].Invoice)
                                         .Select(x => x).ToList();
                int temp = deleteqty;
                for (int i = 0; i < stockList.Count; i++)
                {
                    try
                    {
                        int stockoutIndex = listStockOut.Where(x => x.packing_cd == stockList[i].packing_cd && x.stockout_qty == listLabel[rindex].Delivery_Qty)
                                                    .Select(x => listStockOut.IndexOf(x)).First();
                        int stockIndex = listStock.Where(x => x.packing_cd == listStockOut[stockoutIndex].packing_cd).Select(x => listStock.IndexOf(x)).First();
                        listStock.RemoveAt(stockIndex);
                        listStockOut.RemoveAt(stockoutIndex);
                        temp--;
                        if (temp == 0) break;
                    }
                    catch { continue; }
                }
                listOut[outIndex].delivery_qty -= listLabel[rindex].Delivery_Qty * deleteqty;
                if (listOut[outIndex].delivery_qty == 0) listOut.RemoveAt(outIndex);
                listLabel[rindex].Label_Qty -= deleteqty;
                if (listLabel[rindex].Label_Qty == 0) listLabel.RemoveAt(rindex);
                UpdateGridStockOut(listStockOut);
                UpdateGridLabel(listLabel);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInsClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomMessageBox.Warring("Data is not register! Are you sure to clear all?" + Environment.NewLine + "Dữ liệu chưa được đăng ký! Bạn có chắc muốn xóa?") == DialogResult.No) return;
                ClearDataList();
                CustomMessageBox.Notice("Clear all data!" + Environment.NewLine + "Đã xóa toàn bộ dữ liệu!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInsBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region SUBS EVENT
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

        private void UpdateGridLabel(BindingList<PrintItem> inlist)
        {
            dgvLabel.Columns.Clear();
            dgvLabel.DataSource = null;
            dgvLabel.DataSource = inlist;
            if (!dgvLabel.Columns.Contains("check_qty"))
            {
                DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
                dc.Name = "check_qty";
                dc.HeaderText = "Check Qty";
                dgvLabel.Columns.Add(dc);
            }
            dgvSearch.Update();
            dgvSearch.Refresh();
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
            dgvSearch.Update();
            dgvSearch.Refresh();
        }

        private bool CheckLabel(string itemCD, string invoice, double deliveryQty)
        {
            try
            {
                int lbQty = int.Parse(txtInsLabelQty.Text);
                int rindex = 0;
                try
                {
                    rindex = listLabel.Where(x => x.Item_Number == itemCD && x.Invoice == invoice && x.Delivery_Qty == deliveryQty)
                                         .Select(x => listLabel.IndexOf(x)).First();
                }
                catch
                {
                    CustomMessageBox.Error("This label not in list!" + Environment.NewLine + "Tem không trong danh sách!");
                    return false;
                }
                dgvLabel.Rows[rindex].Cells["check_qty"].Value = lbQty * deliveryQty;
                for (int i = 0; i < dgvLabel.Rows.Count; i++)
                {
                    int lb = (int)dgvLabel.Rows[i].Cells["Label_Qty"].Value;
                    double dQty = (double)dgvLabel.Rows[i].Cells["Delivery_Qty"].Value;
                    if ((lb * dQty) == (lbQty * deliveryQty) && i == rindex)
                    {
                        listLabel[i].Remark = "Checked";
                        dgvLabel.Rows[i].DefaultCellStyle.BackColor = Color.Lime;
                    }
                }
                var listChecked = listLabel.Where(x => x.Remark == "Checked").Select(x => x).ToList();
                if (listChecked.Count == listLabel.Count) return true;
                else return false;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
                return false;
            }
        }
        #endregion
        #endregion

        #region NO SET EVENT
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
                stockdata.SearchItem(new pts_stock { item_cd = itemNumber, invoice = invoiceText }, false);
                double totalPackingQty = stockdata.listStockItems.Select(x => x.packing_qty).Sum();
                txtTotalPackingQty.Text = totalPackingQty.ToString();
                UpdateGridSearchNoSet(stockdata.listStockItems);
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
            txtWHQty.Text = (whQty - stockoutQty).ToString();
            processCD = "NP-" + dtpStockOutDate.Value.ToString("yyyyMMdd");

            #region ADD OUT ITEM
            listOut.Add(new OutputItem
            {
                issue_cd = (int)cmbIssue.SelectedValue,
                destination_cd = cmbDestination.SelectedValue.ToString(),
                item_number = txtItemCode.Text,
                delivery_qty = stockoutQty,
                delivery_date = dtpStockOutDate.Value,
                order_number = string.Empty,
                incharge = txtUserCode.Text,
            });
            #endregion

            pts_stock stockData = new pts_stock();
            pts_supplier supplierData = new pts_supplier();
            for (int i = 0; i < dgvSearch.Rows.Count; i++)
            {
                stockData = dgvSearch.Rows[i].DataBoundItem as pts_stock;
                if (stockData.packing_qty == 0) continue;
                if (stockoutQty >= stockData.packing_qty)
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
                #region ADD LIST STOCK-OUT AND LABEL
                listStockOut.Add(new pts_stockout_log
                {
                    packing_cd = stockData.packing_cd,
                    process_cd = processCD,
                    issue_cd = (int)cmbIssue.SelectedValue,
                    stockout_date = dtpStockOutDate.Value,
                    stockout_user_cd = txtUserCode.Text,
                    stockout_qty = deliveryQty,
                    comment = txtComment.Text,
                    remark = "N",
                });
                try
                {
                    int lbindex = listLabel.Where(x => x.Item_Number == txtItemCode.Text && x.Invoice == stockData.invoice && x.Delivery_Qty == deliveryQty)
                                           .Select(x => listLabel.IndexOf(x)).First();
                    listLabel[lbindex].Label_Qty += 1;
                }
                catch
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
                #endregion
                listStock.Add(stockData);
                if (stockoutQty == 0) break;
            }
            CustomMessageBox.Notice("Stock out " + txtItemCode.Text + " successful! Qty: " + txtStockOutQty.Text + Environment.NewLine + "Xuất " + txtItemCode.Text + " thành công! Số lượng: " + txtStockOutQty.Text);
            UpdateGridStockOut(listStockOut);
            UpdateGridLabel(listLabel);
            UpdateGridPrint(listPrint);
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
                UpdateGridSearchSet(orderData.listOrderItem);
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
            txtSetBarcode.Select();
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
            txtSetOutDate.Text = dtpStockOutDate.Value.ToString("yyyy-MM-dd");
            lbSetUserName.Text = lbUserName.Text;
            lbSetModelName.Text = lbItemName.Text;
            lbSetDesName.Text = cmbDestination.Text.Split(':')[1].Trim();
        }
        #endregion
    }
}
