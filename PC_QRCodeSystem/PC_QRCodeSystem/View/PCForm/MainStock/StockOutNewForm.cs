﻿using System;
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
        #region VARIABLE
        double labelQty = 0;
        bool isChecked = false;
        bool isDeliveried = false;
        string issueFlag = string.Empty;
        string processCD = string.Empty;
        BindingList<PrintItem> listLabel { get; set; }
        BindingList<OutputItem> listOut { get; set; }
        BindingList<PrintItem> listPrint { get; set; }
        BindingList<pts_stock> listStock { get; set; }
        BindingList<pts_stockout_log> listStockOut { get; set; }
        #endregion

        #region FORM EVENT
        public StockOutNewForm()
        {
            InitializeComponent();
            tc_Main.ItemSize = new Size(0, 1);
            dtpStockOutDate.Value = DateTime.Today;
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
                if (issueFlag == "30" && string.IsNullOrEmpty(txtComment.Text))
                {
                    CustomMessageBox.Notice("Need comment when scrap item!" + Environment.NewLine + "Vui lòng điền lí do hủy hàng!");
                    return;
                }
                else if (issueFlag == "20")
                {
                    int i = dgvSearch.SelectedRows[0].Index;
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

        #region FIELDS EVENT
        #region USER
        private void txtUserCode_Validated(object sender, EventArgs e)
        {
            string temp = txtUserCode.Text;
            //Lấy MSNV từ barcode
            if (temp.Contains(";")) temp = temp.Split(';')[0].Trim();
            //Nếu MSNV > 6 thì lấy 6 kí tự cuối
            if (temp.Length > 6) txtUserCode.Text = temp.Substring(temp.Length - 6);
            else txtUserCode.Text = temp;
            try
            {
                //Lấy username
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
            //Đặt biến issueFlag đại diện mã xuất hàng
            issueFlag = cmbIssue.SelectedValue.ToString();
            if (cmbIssue.SelectedIndex <= 0)
            {
                tbpNoSet.Visible = false;
                cmbDestination.Enabled = false;
            }
            else
            {
                tbpNoSet.Visible = true;
                cmbDestination.Enabled = true;
                cmbDestination.Focus();
            }
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
            if (string.IsNullOrEmpty(cmbDestination.Text) && cmbDestination.Enabled) cmbDestination.Select();
        }

        private void cmbDestination_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDestination.Text) && cmbDestination.Enabled) cmbDestination.Select();
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
                    //Lấy tên item
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
            //Nếu check sign thì trả hàng lại với dấu -
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

        #region SUBS EVENT
        /// <summary>
        /// Get data for issue and destination
        /// </summary>
        private void GetCmb()
        {
            //Lấy dữ liệu issue code vào combobox
            pts_issue_code issueData = new pts_issue_code();
            issueData.GetListIssueCode();
            cmbIssue.DataSource = issueData.listIssueCode;
            cmbIssue.ValueMember = "issue_cd";
            cmbIssue.ResetText();
            //Lấy dữ liệu phòng ban vào combobox
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
            tbpNoSet.Visible = false;
            cmbDestination.Enabled = false;
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
            if (string.IsNullOrEmpty(txtItemCode.Text) && issueFlag != "20")
            {
                CustomMessageBox.Error("Item code is empty" + Environment.NewLine + "Vui lòng điền mã nguyên liệu!");
                return false;
            }
            if (string.IsNullOrEmpty(cmbIssue.Text))
            {
                CustomMessageBox.Error("Issue code is empty" + Environment.NewLine + "Vui lòng chọn lí do xuất hàng!");
                return false;
            }
            if (string.IsNullOrEmpty(cmbDestination.Text) && issueFlag != "20")
            {
                CustomMessageBox.Error("Destination code is empty" + Environment.NewLine + "Vui lòng chọn phòng ban!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Update datagirdview show no set item
        /// </summary>
        /// <param name="inList"></param>
        private void UpdateGridSearchNoSet(BindingList<pts_stock> inList)
        {
            dgvSearch.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
            dgvSearch.DataSource = inList;
            dgvSearch.Columns["packing_cd"].HeaderText = "Packing Code";
            dgvSearch.Columns["item_cd"].HeaderText = "Item Number";
            dgvSearch.Columns["supplier_cd"].HeaderText = "Supplier Code";
            dgvSearch.Columns["invoice"].HeaderText = "Invoice";
            dgvSearch.Columns["stockin_date"].HeaderText = "Stock-In Date";
            dgvSearch.Columns["stockin_user_cd"].HeaderText = "Incharge";
            dgvSearch.Columns["stockin_qty"].HeaderText = "Stock-In Qty";
            dgvSearch.Columns["packing_qty"].HeaderText = "Packing Qty";
            if (dgvSearch.Columns.Contains("stock_id")) dgvSearch.Columns.Remove("stock_id");
            if (dgvSearch.Columns.Contains("order_no")) dgvSearch.Columns.Remove("order_no");
            if (dgvSearch.Columns.Contains("registration_user_cd")) dgvSearch.Columns.Remove("registration_user_cd");
            if (dgvSearch.Columns.Contains("registration_date_time")) dgvSearch.Columns.Remove("registration_date_time");
            btnStockOut.Text = "9. STOCK-OUT /" + Environment.NewLine + "Xuất Hàng";
            dgvSearch.Update();
            dgvSearch.Refresh();
            dgvSearch.ClearSelection();
        }

        /// <summary>
        /// Update datagridview show set item
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="isOld"></param>
        private void UpdateGridSearchSet(List<pre_649_order> inList, bool isOld)
        {
            dgvSearch.Columns.Clear();
            if (isOld) dgvSearch.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            else dgvSearch.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
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
            dgvSearch.ClearSelection();
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

        #region SUBS EVENT
        /// <summary>
        /// Input a low level item into list
        /// </summary>
        /// <param name="rindex"></param>
        private void InputSet(int rindex)
        {
            string itemCode = txtSetItemCD.Text;
            pts_stock stockData = new pts_stock();
            //Kiểm tra nguyên liệu đã stock in chưa
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

            DataGridViewRow dr = dgvSetData.Rows[rindex];
            double deliveryQty = 0;
            double packingQty = double.Parse(txtSetOutQty.Text);
            double orderQty = (double)dr.Cells["request_qty"].Value;
            double stockoutQty = (double)dr.Cells["stockout_qty"].Value;

            #region CHECK ITEM QTY
            //Kiểm tra số lượng tồn trên PREMAC
            //double whQty = (double)dr.Cells["wh_qty"].Value;
            //if (packingQty > whQty)
            //{
            //    CustomMessageBox.Error("This item is not enough in PREMAC!" + Environment.NewLine + "Số lượng hàng tồn trên PREMAC không đủ!");
            //    return;
            //}

            //Kiểm tra số lượng tồn trên SQL DB
            double totalpackingQty = stockData.listStockItems.Sum(x => x.packing_qty);
            if (packingQty > totalpackingQty)
            {
                CustomMessageBox.Error("This item's pack qty is not enough! Please stock-in first!" + Environment.NewLine + "Số lượng hàng không đủ! Cần nhập hàng trước!");
                return;
            }
            #endregion

            //Cộng dồn số lượng xuất
            stockoutQty += packingQty;
            //Nếu số lượng xuất lớn hơn số lượng yêu cầu thì xuất bằng yêu cầu
            if (stockoutQty > orderQty)
            {
                packingQty -= stockoutQty - orderQty;
                stockoutQty = orderQty;
            }
            dr.Cells["stockout_qty"].Value = stockoutQty;

            pts_supplier supplierData = new pts_supplier();
            foreach (pts_stock item in stockData.listStockItems)
            {
                if (item.packing_qty == 0) continue;
                if (packingQty < item.packing_qty)
                {
                    deliveryQty = packingQty;
                    item.packing_qty -= packingQty;
                    //Thêm item vào danh sách in nếu tách tem
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
                //Thêm nguyên liệu vào lịch sử xuất
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
                //Thêm tem nguyên liệu vào danh sách tem kiểm tra
                //Nếu tem đã tồn tại thì cộng dồn lên, nếu chưa thì thêm vào
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
                //Thêm nguyên liệu vào danh sách xuất CSV
                #region ADD OUTPUT ITEM
                listOut.Add(new OutputItem
                {
                    issue_cd = 20,
                    destination_cd = cmbDestination.SelectedValue.ToString(),
                    item_number = itemCode,
                    supplier_invoice = item.invoice,
                    delivery_qty = deliveryQty,
                    delivery_date = dtpStockOutDate.Value,
                    order_number = txtSetOrderNo.Text,
                    incharge = txtSetUserCD.Text,
                });
                #endregion
                listStock.Add(item);
                if (packingQty == 0) break;
            }
            //Tô màu những nguyên liệu đã xuất
            dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            //Nếu đủ số lượng yêu cầu thì tô màu lục
            if ((double)dr.Cells["stockout_qty"].Value == orderQty)
                dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Lime);
            txtSetBarcode.ResetText();
            txtSetBarcode.Focus();
        }

        /// <summary>
        /// Stock out list set item
        /// </summary>
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
            foreach (DataGridViewRow dr in dgvPrint.Rows)
            {
                if (dr.DefaultCellStyle.BackColor != Color.FromKnownColor(KnownColor.ActiveCaption))
                {
                    if (CustomMessageBox.Warring("Have label no print yet! Are you sure continue?" + Environment.NewLine + "Có nhãn chưa in! Bạn có muốn tiếp tục?") == DialogResult.No)
                        return;
                }
            }
            tc_Main.SelectedTab = tab_Inspection;
            txtInsBarcode.Focus();
        }

        private void btnPrintBack_Click(object sender, EventArgs e)
        {
            if (issueFlag == "20")
                tc_Main.SelectedTab = tab_Set;
            else
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
                if (issueFlag == "20")
                {
                    pts_plan planData = new pts_plan()
                    {
                        plan_cd = processCD,
                        plan_qty = double.Parse(txtSetRequestQty.Text),
                        plan_date = DateTime.Parse(txtSetRequestDate.Text),
                        set_number = txtSetNumber.Text,
                        model_cd = txtSetModelCD.Text,
                        delivery_date = dtpStockOutDate.Value,
                        plan_usercd = txtSetUserCD.Text,
                        comment = txtComment.Text
                    };
                    planData.Add(planData);
                }
                else
                {
                    pts_noplan noPlanData = new pts_noplan()
                    {
                        noplan_cd = processCD,
                        item_cd = txtItemCode.Text,
                        destination_cd = cmbDestination.SelectedValue.ToString(),
                        noplan_date = dtpStockOutDate.Value,
                        noplan_qty = double.Parse(txtStockOutQty.Text),
                        noplan_usercd = txtUserCode.Text
                    };
                    noPlanData.AddItem(noPlanData);
                }
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
                //Nhập số lượng tem muốn xóa
                InputCommon inputfrm = new InputCommon(false);
                if (inputfrm.ShowDialog() == DialogResult.OK) deleteqty = inputfrm.inputQty;
                if (deleteqty == 0)
                {
                    CustomMessageBox.Error("At least one label must be selected" + Environment.NewLine + "Ít nhất phải chọn 1 tem!");
                    return;
                }
                if (deleteqty > listLabel[rindex].Label_Qty)
                {
                    CustomMessageBox.Error("Delete qty more than label qty!" + Environment.NewLine + "Số lượng xóa lớn hơn số lượng tem hiện có!");
                    return;
                }
                //Tìm index của nguyên liệu muốn xóa trong danh sách xuất file csv
                int outIndex = listOut.Where(x => x.item_number == listLabel[rindex].Item_Number).Select(x => listOut.IndexOf(x)).First();
                //Lấy danh sách các gói của nguyên liệu
                var stockList = listStock.Where(x => x.item_cd == listLabel[rindex].Item_Number && x.invoice == listLabel[rindex].Invoice)
                                         .Select(x => x).ToList();
                int temp = deleteqty;
                //Dò danh sách các gói nguyên liệu
                for (int i = 0; i < stockList.Count; i++)
                {
                    try
                    {
                        //Tìm index của gói trong lịch sử xuất
                        int stockoutIndex = listStockOut.Where(x => x.packing_cd == stockList[i].packing_cd && x.stockout_qty == listLabel[rindex].Delivery_Qty)
                                                    .Select(x => listStockOut.IndexOf(x)).First();
                        //Tìm index của gói trong danh sách các gói
                        int stockIndex = listStock.Where(x => x.packing_cd == listStockOut[stockoutIndex].packing_cd).Select(x => listStock.IndexOf(x)).First();
                        //Xóa gói
                        listStock.RemoveAt(stockIndex);
                        listStockOut.RemoveAt(stockoutIndex);
                        temp--;
                        if (temp == 0) break;
                    }
                    catch { continue; }//Nếu không phải gói cần xóa thì bỏ qua
                }
                //Trừ số lượng xuất của nguyên liệu, nếu bằng 0 thì xóa nguyên liệu
                listOut[outIndex].delivery_qty -= listLabel[rindex].Delivery_Qty * deleteqty;
                if (listOut[outIndex].delivery_qty == 0) listOut.RemoveAt(outIndex);
                //Trừ số lượng tem xuất, nếu số lượng tem bằng 0 thì xóa loại tem đó
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
            if (dgvLabel.Rows.Count > 0 && dgvStockOut.Rows.Count > 0)
            {
                if (CustomMessageBox.Warring("If you go back, the current data is clear. Are you sure to go back?" + Environment.NewLine + "Nếu bạn trở lại menu chính, dữ liệu hiện tại sẽ bị xóa. Bạn có chắc muốn trở lại?") == DialogResult.No)
                    return;
            }
            ClearDataList();
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

        /// <summary>
        /// Update datagridview of list label stock out
        /// </summary>
        /// <param name="inlist"></param>
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
        /// Update datagridview of stock out history
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

        /// <summary>
        /// Check label before register
        /// </summary>
        /// <param name="itemCD"></param>
        /// <param name="invoice"></param>
        /// <param name="deliveryQty"></param>
        /// <returns></returns>
        private bool CheckLabel(string itemCD, string invoice, double deliveryQty)
        {
            try
            {
                int lbQty = int.Parse(txtInsLabelQty.Text);
                int rindex = 0;
                try
                {
                    //Lấy index của tem nếu tem có trong danh sách
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
                    //Nếu số lượng của tem kiểm tra đúng với số lượng tem trong danh sách thì duyệt
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
            //Kiểm tra số lượng tồn kho trong PREMAC và SQL DB
            if (/*stockoutQty > whQty ||*/ stockoutQty > totalPackQty)
            {
                CustomMessageBox.Notice("Stock-Out Q'ty can't more than Stock Q'ty!" + Environment.NewLine + "Số lượng xuất không thể lớn hơn số lượng tồn!");
                return;
            }
            txtWHQty.Text = (whQty - stockoutQty).ToString();
            processCD = "NP-" + dtpStockOutDate.Value.ToString("yyyyMMdd");

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
                #region ADD OUT ITEM
                listOut.Add(new OutputItem
                {
                    issue_cd = (int)cmbIssue.SelectedValue,
                    destination_cd = cmbDestination.SelectedValue.ToString(),
                    item_number = txtItemCode.Text,
                    supplier_invoice = stockData.invoice,
                    delivery_qty = deliveryQty,
                    delivery_date = dtpStockOutDate.Value,
                    order_number = string.Empty,
                    incharge = txtUserCode.Text,
                });
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
                //Tìm kiếm order number của các set chưa được xuất
                pre_649_order orderData = new pre_649_order();
                orderData.Search(new pre_649_order
                {
                    item_number = itemNumber,
                    order_number = setNumber
                });
                isDeliveried = false;
                //Tìm các order các set đã xuất (khuyến nghị tìm kiếm theo số order number)
                if (orderData.listOrderItem.Count <= 0)
                {
                    isDeliveried = true;
                    pre_649 deliveriedData = new pre_649();
                    deliveriedData.SearchOrder(new pre_649
                    {
                        item_number = itemNumber,
                        order_number = setNumber
                    });
                    orderData.listOrderItem = deliveriedData.listPremacItem.Select(x => new pre_649_order
                    {
                        item_number = x.item_number,
                        supplier_cd = x.supplier_cd,
                        order_number = x.order_number,
                        order_date = x.order_date,
                        order_qty = x.order_qty,
                    }).ToList();
                    UpdateGridSearchSet(orderData.listOrderItem, true);
                }
                else UpdateGridSearchSet(orderData.listOrderItem, false);
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
            string orderNo = string.Empty;
            DataGridViewRow dr = dgvSearch.Rows[RowIndex];
            if (string.IsNullOrEmpty(txtSetNumber.Text))
                orderNo = dr.Cells["order_number"].Value.ToString();
            else
                orderNo = txtSetNumber.Text;
            GetSetOptions(dr.Cells["item_number"].Value.ToString(), orderNo, (double)dr.Cells["order_qty"].Value, (DateTime)dr.Cells["order_date"].Value);
            SearchLowItem(dr.Cells["item_number"].Value.ToString(), (double)dr.Cells["order_qty"].Value, orderNo);
            tc_Main.SelectedTab = tab_Set;
            pre_655 issueData = new pre_655();
            pts_stockout_log stockoutData = new pts_stockout_log();
            double temp = 0;
            for (int i = 0; i < dgvSetData.Rows.Count; i++)
            {
                temp = stockoutData.GetStockOutQty(orderNo, dgvSetData.Rows[i].Cells["low_level_item"].Value.ToString());
                if (temp == 0)
                {
                    issueData.Search(new pre_655
                    {
                        low_level_item = dgvSetData.Rows[i].Cells["low_level_item"].Value.ToString(),
                        high_level_item = txtSetModelCD.Text,
                        order_number = orderNo
                    });
                    try
                    {
                        temp = issueData.listIssueItem[0].no_issue_qty;
                        if (temp > 0) dgvSetData.Rows[i].Cells["request_qty"].Value = temp;
                    }
                    catch
                    {
                        if (isDeliveried) dgvSetData.Rows[i].Cells["request_qty"].Value = 0;
                    }
                }
                else
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
        private void GetSetOptions(string modelCode, string orderNo, double orderQty, DateTime orderDate)
        {
            txtSetOrderNo.Text = orderNo;
            txtSetUserCD.Text = txtUserCode.Text;
            txtSetModelCD.Text = modelCode;
            txtSetRequestQty.Text = orderQty.ToString();
            txtSetRequestDate.Text = orderDate.ToString("yyyy-MM-dd");
            txtSetOutDate.Text = dtpStockOutDate.Value.ToString("yyyy-MM-dd");
            lbSetUserName.Text = lbUserName.Text;
            pts_item itemData = new pts_item();
            itemData = itemData.GetItem(modelCode);
            lbSetModelName.Text = itemData.item_name;
            //txtSetDesCD.Text = cmbDestination.SelectedValue.ToString();
            //lbSetDesName.Text = cmbDestination.Text.Split(':')[1].Trim();
        }
        #endregion

        private void tc_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = "Stock Out - " + tc_Main.SelectedTab.Text;
            this.Update();
            this.Refresh();
        }
    }
}
