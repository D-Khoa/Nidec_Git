﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;
using System.Data.SqlClient;

namespace PC_QRCodeSystem.View
{
    public partial class StockInputForm : FormCommon
    {
        #region ITEMS
        PrintItem lbData { get; set; }
        pts_item itemData { get; set; }
        pre_649 premacData { get; set; }
        //pts_stock stockItem { get; set; }
        pts_stockout stockoutItem { get; set; }
        PrintItem printItem { get; set; }
        pts_supplier supplierItem { get; set; }
        List<PrintItem> listPrintItem { get; set; }
        List<pre_649> listPremac { get; set; }
        List<pre_649> listInputPremac { get; set; }
        //BindingList<pts_stock> listStockItem { get; set; }
        BindingList<pts_stockout> listStockOutItem { get; set; }

        //TfPrint tfprinter = new TfPrint();
        Stopwatch stopWatch = new Stopwatch();
        ErrorProvider errorProvider = new ErrorProvider();

        public StockInputForm()
        {
            InitializeComponent();
            lbData = new PrintItem();
            itemData = new pts_item();
            printItem = new PrintItem();
            //stockItem = new pts_stock();
            premacData = new pre_649();
            supplierItem = new pts_supplier();
            listPrintItem = new List<PrintItem>();
            listPremac = new List<pre_649>();
            listInputPremac = new List<pre_649>();
            stockoutItem = new pts_stockout();
            //listStockItem = new BindingList<pts_stock>();
            listStockOutItem = new BindingList<pts_stockout>();
            tc_Main.ItemSize = new Size(0, 1);
        }

        private void StockInputForm_Load(object sender, EventArgs e)
        {
            try
            {
                rbtnEven.Checked = true;
                tc_Main.SelectedTab = tab_Main;
                txtItemNum.Focus();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                try
                {
                    //Press F2 for add new supplier
                    supplierItem.AddSupplier(new pts_supplier
                    {
                        supplier_cd = txtSupplierCD.Text,
                        supplier_name = txtSupplierName.Text,
                        registration_user_cd = UserData.usercode,
                    });
                    CustomMessageBox.Notice("New supplier has been added with supplier code : " + txtSupplierCD.Text + Environment.NewLine + "NSX mới được thêm vào với mã: " + txtSupplierCD.Text);
                    txtSupplierCD.Clear();
                    errorProvider.SetError(txtSupplierCD, null);
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Error(ex.Message);
                }
                txtBarcode.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region MAIN TAB
        #region BUTTON EVENT
        #region BUTTON PREMAC IMPORT
        private void btnPremacImport_Click(object sender, EventArgs e)
        {
            try
            {
                //Set wait cursor when search data
                this.Cursor = Cursors.WaitCursor;
                //Start stopwatch for catch searching time
                stopWatch.Restart();
                //Get list data from premac 6-4-9 file
                listPremac = premacData.GetListPremacItem(SettingItem.premacFile);
                dgvPreInput.DataSource = listPremac;
                //Search data
                SearchPremacFile();
                //Rename file after get data
                //File.Move(SettingItem.premacFile, Path.ChangeExtension(SettingItem.premacFile, DateTime.Now.ToString("yyyyMMddHHmmss")));
                //Stop stopwatch and show time
                stopWatch.Stop();
                tsTime.Text = stopWatch.Elapsed.ToString("s\\.ff") + " s";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
            UpdatePremacGrid(false);
            this.Cursor = Cursors.Default;
        }
        #endregion
        #region BUTTON SEARCH
        private void btnSearchPreInput_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                stopWatch.Restart();
                //search premac item from SQL
                premacData.Search(new pre_649
                {
                    item_number = txtItemNum.Text,
                    supplier_cd = txtSupplierCode.Text,
                    supplier_invoice = txtSupplierInvoice.Text,
                    order_number = txtOrderNo.Text,
                    po_number = txtPONo.Text,
                    incharge = txtIncharge.Text
                }, dtpFromDate.Value, dtpToDate.Value, cbCheckDate.Checked);
                dgvPreInput.ColumnHeadersVisible = false;
                dgvPreInput.DataSource = premacData.listPremacItem;
                dgvPreInput.ColumnHeadersVisible = true;
                stopWatch.Stop();
                tsTime.Text = stopWatch.Elapsed.ToString("s\\.ff") + " s";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
            UpdatePremacGrid(false);
            this.Cursor = Cursors.Default;
        }
        #endregion
        #region BUTTON AUTO PACKING
        private void btnAutoPacking_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int numberOfLot = 1;
                double sizePerLot = 1;
                double qtymod = 0;
                //Each row in datagridview
                foreach (DataGridViewRow dr in dgvPreInput.SelectedRows)
                {
                    qtymod = 0;
                    //If item number is not exist in item database then skip it
                    try { itemData = itemData.GetItem(dr.Cells["item_number"].Value.ToString()); }
                    catch { continue; }
                    //Get lot size in database
                    sizePerLot = itemData.lot_size;
                    //If lot size = 0 then no cut lot
                    if (sizePerLot == 0) sizePerLot = (double)dr.Cells["item_name"].Value;
                    //Calculator number of lot
                    numberOfLot = (int)((double)dr.Cells["delivery_qty"].Value / sizePerLot);
                    //Add new label item into print list
                    if (numberOfLot > 0)
                    {
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = dr.Cells["item_number"].Value.ToString(),
                            Item_Name = dr.Cells["item_name"].Value.ToString(),
                            SupplierCD = dr.Cells["supplier_cd"].Value.ToString(),
                            SupplierName = dr.Cells["supplier_name"].Value.ToString(),
                            Invoice = dr.Cells["supplier_invoice"].Value.ToString(),
                            Delivery_Date = (DateTime)dr.Cells["delivery_date"].Value,
                            Delivery_Qty = sizePerLot,
                            //OrderNo = dr.Cells["order_number"].Value.ToString(),
                            Remark = "P",
                            isRec = true,
                            Label_Qty = numberOfLot
                        });
                    }
                    //If the last lot is not enough, create an odd label for it
                    if (sizePerLot * numberOfLot < (double)dr.Cells["delivery_qty"].Value)
                    {
                        qtymod = (double)dr.Cells["delivery_qty"].Value - (sizePerLot * numberOfLot);
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = dr.Cells["item_number"].Value.ToString(),
                            Item_Name = dr.Cells["item_name"].Value.ToString(),
                            SupplierCD = dr.Cells["supplier_cd"].Value.ToString(),
                            SupplierName = dr.Cells["supplier_name"].Value.ToString(),
                            Invoice = dr.Cells["supplier_invoice"].Value.ToString(),
                            Delivery_Date = (DateTime)dr.Cells["delivery_date"].Value,
                            Delivery_Qty = qtymod,
                            //OrderNo = dr.Cells["order_number"].Value.ToString(),
                            Remark = "P",
                            isRec = true,
                            Label_Qty = 1
                        });
                    }
                    //Change color of row when add print item completed
                    dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                //Update print list datagridview
                UpdatePrintGrid();
                tc_Main.SelectedTab = tab_Print;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion
        #region BUTTON MANUAL PACKING
        private void btnManualPacking_Click(object sender, EventArgs e)
        {
            try
            {
                double qtymod = 0;
                int numberOfLot = 1;
                double sizePerLot = 1;
                if (dgvPreInput.SelectedRows.Count <= 0)
                {
                    CustomMessageBox.Notice("Please select a row before packing!" + Environment.NewLine + "Vui lòng chọn 1 nguyên liệu!");
                    return;
                }
                //Chọn xuất chẵn
                if (rbtnEven.Checked)
                {
                    foreach (DataGridViewRow dr in dgvPreInput.SelectedRows)
                    {
                        //Khai báo số lượng nhập vào PREMAC
                        double deliveryQty = (double)dr.Cells["delivery_qty"].Value;
                        if (deliveryQty <= 0)
                        {
                            CustomMessageBox.Notice("This lot is null" + Environment.NewLine + "Lô này trống!");
                            return;
                        }
                        //Nhập lot size
                        sizePerLot = double.Parse(txtCapacity.Text);
                        //Nếu lot size = 0 thì lot size = tổng số lượng nhập vào
                        if (sizePerLot == 0) sizePerLot = deliveryQty;
                        //Số lượng lot = tổng số lượng / lot size
                        numberOfLot = (int)(deliveryQty / sizePerLot);
                        //Tạo tem và số lượng tem tương ứng số lượng lot
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = dr.Cells["item_number"].Value.ToString(),
                            Item_Name = dr.Cells["item_name"].Value.ToString(),
                            SupplierCD = dr.Cells["supplier_cd"].Value.ToString(),
                            SupplierName = dr.Cells["supplier_name"].Value.ToString(),
                            Invoice = dr.Cells["supplier_invoice"].Value.ToString(),
                            Delivery_Date = (DateTime)dr.Cells["delivery_date"].Value,
                            Delivery_Qty = sizePerLot,
                            Remark = "P",
                            isRec = true,
                            Label_Qty = numberOfLot
                        });
                        //Nếu còn thừa số lượng < lot size thì tạo tem tương ứng số lượng thừa
                        if (sizePerLot * numberOfLot < deliveryQty)
                        {
                            qtymod = deliveryQty - (sizePerLot * numberOfLot);
                            printItem.ListPrintItem.Add(new PrintItem
                            {
                                Item_Number = dr.Cells["item_number"].Value.ToString(),
                                Item_Name = dr.Cells["item_name"].Value.ToString(),
                                SupplierCD = dr.Cells["supplier_cd"].Value.ToString(),
                                SupplierName = dr.Cells["supplier_name"].Value.ToString(),
                                Invoice = dr.Cells["supplier_invoice"].Value.ToString(),
                                Delivery_Date = (DateTime)dr.Cells["delivery_date"].Value,
                                Delivery_Qty = qtymod,
                                Remark = "P",
                                isRec = true,
                                Label_Qty = 1
                            });
                        }
                        //Chuyển tổng số lượng nhập vào = 0 và tô màu
                        dr.Cells["delivery_qty"].Value = 0;
                        dr.DefaultCellStyle.BackColor = Color.Lime;
                    }
                }
                if (rbtnOdd.Checked)
                {
                    qtymod = 0;
                    sizePerLot = double.Parse(txtCapacity.Text);
                    DataGridViewRow dr = dgvPreInput.SelectedRows[0];
                    double deliveryQty = (double)dr.Cells["delivery_qty"].Value;
                    if (deliveryQty <= 0)
                    {
                        CustomMessageBox.Notice("This lot is null" + Environment.NewLine + "Lô này trông!");
                        return;
                    }
                    else
                    {
                        deliveryQty -= sizePerLot;
                        if (deliveryQty <= 0)
                        {
                            sizePerLot = (double)dr.Cells["delivery_qty"].Value;
                            dr.Cells["delivery_qty"].Value = 0;
                        }
                        else dr.Cells["delivery_qty"].Value = deliveryQty;
                    }
                    printItem.ListPrintItem.Add(new PrintItem
                    {
                        Item_Number = dr.Cells["item_number"].Value.ToString(),
                        Item_Name = dr.Cells["item_name"].Value.ToString(),
                        SupplierCD = dr.Cells["supplier_cd"].Value.ToString(),
                        SupplierName = dr.Cells["supplier_name"].Value.ToString(),
                        Invoice = dr.Cells["supplier_invoice"].Value.ToString(),
                        Delivery_Date = (DateTime)dr.Cells["delivery_date"].Value,
                        Delivery_Qty = sizePerLot,
                        //OrderNo = dr.Cells["order_number"].Value.ToString(),
                        Remark = "P",
                        isRec = true,
                        Label_Qty = 1
                    });
                    dr.DefaultCellStyle.BackColor = Color.Yellow;
                }
                UpdatePrintGrid();
                tc_Main.SelectedTab = tab_Print;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion
        #region BUTTON SETTING
        private void btnSetting_Click(object sender, EventArgs e)
        {
            try
            {
                SettingForm settingFrm = new SettingForm();
                settingFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion
        #region BUTTON CLEAR
        private void btnMainClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtPONo.Clear();
                txtOrderNo.Clear();
                txtCapacity.Clear();
                txtItemNum.Clear();
                txtIncharge.Clear();
                txtSupplierCode.Clear();
                txtSupplierInvoice.Clear();
                tsRow.Text = "None";
                tsTime.Text = "None";
                tsTotalQty.Text = "None";
                UpdatePremacGrid(false);
                dgvPreInput.DataSource = null;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion
        #region BUTTON BACK
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void btnPrintList_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Print;
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Inspection;
        }

        private void rbtnEven_CheckedChanged(object sender, EventArgs e)
        {
            //Nếu tách lot chẵn thì cho phép chọn nhiều dòng dữ liệu
            if (rbtnEven.Checked) dgvPreInput.MultiSelect = true;
            if (rbtnOdd.Checked) dgvPreInput.MultiSelect = false;
        }
        #endregion

        #region SUB EVENT
        /// <summary>
        /// Update datagridview search PREMAC
        /// </summary>
        /// <param name="isLock"></param>
        private void UpdatePremacGrid(bool isLock)
        {
            btnPremacImport.Enabled = !isLock;
            btnSearchPreInput.Enabled = !isLock;
            if (dgvPreInput.DataSource != null)
            {
                //Xóa bỏ các cột không cần thiết
                if (dgvPreInput.Columns.Contains("premac_id")) dgvPreInput.Columns.Remove("premac_id");
                if (dgvPreInput.Columns.Contains("po_number")) dgvPreInput.Columns.Remove("po_number");
                if (dgvPreInput.Columns.Contains("order_number")) dgvPreInput.Columns.Remove("order_number");
                if (dgvPreInput.Columns.Contains("order_qty")) dgvPreInput.Columns.Remove("order_qty");
                //Đổi tên cột
                dgvPreInput.Columns["item_number"].HeaderText = "Item Number";
                dgvPreInput.Columns["item_name"].HeaderText = "Item Name";
                dgvPreInput.Columns["supplier_cd"].HeaderText = "Supplier Code";
                dgvPreInput.Columns["supplier_name"].HeaderText = "Supplier Name";
                dgvPreInput.Columns["supplier_invoice"].HeaderText = "Invoice";
                dgvPreInput.Columns["delivery_qty"].HeaderText = "Delivery Qty";
                dgvPreInput.Columns["delivery_date"].HeaderText = "Delivery Date";
                dgvPreInput.Columns["incharge"].HeaderText = "Incharge";
                dgvPrintList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                //Nếu số lượng dòng > 0 thì đếm tổng số dòng và tính tổng số lượng
                if (dgvPreInput.Rows.Count > 0)
                {
                    double total = dgvPreInput.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["delivery_qty"].Value));
                    tsRow.Text = dgvPreInput.Rows.Count.ToString();
                    tsTotalQty.Text = total.ToString();
                }
                else
                {
                    tsRow.Text = "None";
                    tsTotalQty.Text = "None";
                }
            }
        }

        /// <summary>
        /// Search PREMAC file data with fields in main menu
        /// </summary>
        private void SearchPremacFile()
        {
            try
            {
                //Search with item number
                if (!string.IsNullOrEmpty(txtItemNum.Text))
                {
                    listPremac = (from item in listPremac
                                  where item.item_number == txtItemNum.Text
                                  select item).ToList();
                }
                //Search with supplier code
                if (!string.IsNullOrEmpty(txtSupplierCode.Text))
                {
                    listPremac = (from item in listPremac
                                  where item.supplier_cd == txtSupplierCode.Text
                                  select item).ToList();
                }
                //Search with order number
                if (!string.IsNullOrEmpty(txtOrderNo.Text))
                {
                    listPremac = (from item in listPremac
                                  where item.order_number == txtOrderNo.Text
                                  select item).ToList();
                }
                //Search with invoice
                if (!string.IsNullOrEmpty(txtSupplierInvoice.Text))
                {
                    listPremac = (from item in listPremac
                                  where item.supplier_invoice == txtSupplierInvoice.Text
                                  select item).ToList();
                }
                //Search with incharge user
                if (!string.IsNullOrEmpty(txtIncharge.Text))
                {
                    listPremac = (from item in listPremac
                                  where item.incharge == txtIncharge.Text
                                  select item).ToList();
                }
                //Search with PO
                if (!string.IsNullOrEmpty(txtPONo.Text))
                {
                    listPremac = (from item in listPremac
                                  where item.po_number == txtPONo.Text
                                  select item).ToList();
                }
                //Search with date
                if (cbCheckDate.Checked)
                {
                    listPremac = (from item in listPremac
                                  where (item.delivery_date >= dtpFromDate.Value && item.delivery_date <= dtpToDate.Value)
                                  select item).ToList();
                }
                dgvPreInput.DataSource = (from item in listPremac
                                          group item by new
                                          {
                                              item.item_number,
                                              item.item_name,
                                              item.supplier_cd,
                                              item.supplier_name,
                                              item.supplier_invoice,
                                              item.delivery_date,
                                              item.incharge
                                          } into g
                                          select new pre_649()
                                          {
                                              item_number = g.Key.item_number,
                                              item_name = g.Key.item_name,
                                              supplier_cd = g.Key.supplier_cd,
                                              supplier_name = g.Key.supplier_name,
                                              supplier_invoice = g.Key.supplier_invoice,
                                              delivery_qty = g.Sum(a => a.delivery_qty),
                                              delivery_date = g.Key.delivery_date,
                                              incharge = g.Key.incharge
                                          }).OrderBy(x => x.supplier_invoice).ToList();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void dgvPreInput_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dr = dgvPreInput.Rows[e.RowIndex];
            txtItemNum.Text = dr.Cells["item_number"].Value.ToString();
            txtSupplierCode.Text = dr.Cells["supplier_cd"].Value.ToString();
            txtSupplierInvoice.Text = dr.Cells["supplier_invoice"].Value.ToString();
            txtIncharge.Text = dr.Cells["incharge"].Value.ToString();
        }
        #endregion
        #endregion

        #region PRINT TAB
        #region BUTTON EVENT
        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            try
            {
                if (printItem.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline" + Environment.NewLine + "Máy in chưa kết nối!");
                    return;
                }
                listPrintItem.Clear();
                if (dgvPrintList.SelectedRows.Count <= 0)
                {
                    CustomMessageBox.Notice("Please choose item first!" + Environment.NewLine + "Vui lòng chọn tem cần in!");
                    return;
                }
                CallAdd1RowDB();
                //foreach (DataGridViewRow dr in dgvPrintList.SelectedRows)
                //{
                //    listPrintItem.Add(dr.DataBoundItem as PrintItem);
                //    dr.DefaultCellStyle.BackColor = Color.Lime;
                //}
                //if (bool.Parse(SettingItem.checkSaved))
                //{
                //    CallAdd1RowDB();
                //}
                if (printItem.PrintItems(listPrintItem, false))
                    CustomMessageBox.Notice("Print items are completed!" + Environment.NewLine + "In hoàn tất!");
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
                if (printItem.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline" + Environment.NewLine + "Máy in chưa kết nối!");
                    return;
                }
                listPrintItem.Clear();
                if (dgvPrintList.Rows.Count == 0)
                {
                    CustomMessageBox.Error("Don't have item to print!" + Environment.NewLine + "Không có tem để in!");
                    return;
                }
                CallAddDB();
                //foreach (DataGridViewRow dr in dgvPrintList.Rows)
                //{
                //    listPrintItem.Add(dr.DataBoundItem as PrintItem);
                //    // dgvPrintList.Rows.Remove(dr);
                //    dr.DefaultCellStyle.BackColor = Color.Lime;
                //}
                //if (bool.Parse(SettingItem.checkSaved))
                //{
                //    CallAddDB();
                //}
                if (printItem.PrintItems(listPrintItem, false))
                    CustomMessageBox.Notice("Print items are completed!" + Environment.NewLine + "In hoàn tất!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnManualPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (printItem.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline" + Environment.NewLine + "Máy in chưa kết nối!");
                    return;
                }
                listPrintItem.Clear();
                if (dgvPrintList.SelectedRows.Count == 0)
                {
                    CustomMessageBox.Notice("Please choose item first!" + Environment.NewLine + "Vui lòng chọn tem muốn in!");
                    return;
                }
                CallAddSelectRow();
                //foreach (DataGridViewRow dr in dgvPrintList.SelectedRows)
                //{
                //    //listPrintItem.Add(dr.DataBoundItem as PrintItem);
                //    //dr.DefaultCellStyle.BackColor = Color.Yellow;
                //    CallAddSelectRow();

                //}
                //if (bool.Parse(SettingItem.checkSaved))
                //{
                //    CallAddSelectRow();
                //}
                if (printItem.PrintItems(listPrintItem, int.Parse(txtPrintLabelQty.Text)))
                    CustomMessageBox.Notice("Print " + txtPrintLabelQty.Text + " items are completed!" + Environment.NewLine + "Đã in " + txtPrintLabelQty.Text + " tem!");
                txtPrintLabelQty.Text = "1";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnRegPre649_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Inspection;
        }

        private void btnPrintClear_Click(object sender, EventArgs e)
        {
            try
            {
                listPrintItem.Clear();
                printItem.ListPrintItem.Clear();
                dgvPrintList.DataSource = null;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region SUB EVENT
        /// <summary>
        /// Update datagridview print items
        /// </summary>
        private void UpdatePrintGrid()
        {
            dgvPrintList.DataSource = printItem.ListPrintItem;
            dgvPrintList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            double total = dgvPrintList.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["Delivery_Qty"].Value));
            tsTotalQty.Text = total.ToString();
            tsRow.Text = dgvPrintList.Rows.Count.ToString();
        }

        private void txtPrintLabelQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void tab_Print_Paint(object sender, PaintEventArgs e)
        {
            UpdatePrintGrid();
        }
        #endregion
        #endregion

        #region INSPECTION TAB
        #region BUTTONS EVENT
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomMessageBox.Question("Are you sure register this list?" + Environment.NewLine + "Bạn có muốn đăng ký danh sách này?") == DialogResult.No)
                    return;
                for (int i = 0; i < dgvInspection.Rows.Count; i++)
                {
                    //Register item into stock
                    try
                    {
                        //Add item into database and remove from list item
                        #region OLD
                        //if (stockItem.AddItem(dgvInspection.Rows[i].DataBoundItem as pts_stock) > 0)
                        //{
                        //    listStockItem.Remove(dgvInspection.Rows[i].DataBoundItem as pts_stock);
                        //    i--;
                        //}
                        #endregion
                        #region NEW
                        if (stockoutItem.AddItem(dgvInspection.Rows[i].DataBoundItem as pts_stockout) > 0)
                        {
                            listStockOutItem.Remove(dgvInspection.Rows[i].DataBoundItem as pts_stockout);
                            i--;
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        //If add error then change color to red
                        CustomMessageBox.Error(ex.Message);
                        dgvInspection.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        continue;
                    }
                    //Export new item stock-in to csv for register PREMAC
                    if (listInputPremac.Count > 0)
                        premacData.ExportCSV(GroupByPremac());
                }
                CustomMessageBox.Notice("Register Successful!" + Environment.NewLine + "Đăng ký hoàn tất!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
            //Update stock value
            if (listInputPremac.Count > 0)
                itemData.ListStockInUpdateValue(GroupByPremac());
            listInputPremac.Clear();
            UpdateInspectionGrid();
            txtBarcode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region OLD
                //foreach (DataGridViewRow dr in dgvInspection.SelectedRows)
                //{
                //    if (CustomMessageBox.Warring("Are you sure delete this item?" + Environment.NewLine + "Bạn có chắc xóa tem này?") == DialogResult.Yes)
                //    {
                //        //Search item want to delete
                //        stockItem = dr.DataBoundItem as pts_stock;
                //        var tempItem = (from x in listInputPremac
                //                        where x.item_number == stockItem.item_cd &&
                //                              x.supplier_cd == stockItem.supplier_cd &&
                //                              x.supplier_invoice == stockItem.invoice &&
                //                              x.delivery_date == stockItem.stockin_date &&
                //                              x.delivery_qty == stockItem.stockin_qty
                //                        select x);
                //        //Delete item from list
                //        listInputPremac.Remove(tempItem.FirstOrDefault());
                //        listStockItem.Remove(stockItem);
                //    }
                //}
                //dgvInspection.DataSource = listStockItem;
                #endregion
                #region NEW
                foreach (DataGridViewRow dr in dgvInspection.SelectedRows)
                {
                    if (CustomMessageBox.Warring("Are you sure delete this item?" + Environment.NewLine + "Bạn có chắc xóa tem này?") == DialogResult.Yes)
                    {
                        //Search item want to delete
                        stockoutItem = dr.DataBoundItem as pts_stockout;
                        var tempItem = (from x in listInputPremac
                                        where x.item_number == stockoutItem.item_cd &&
                                              x.supplier_name == stockoutItem.supplier_name &&
                                              x.supplier_invoice == stockoutItem.invoice &&
                                              x.delivery_date == stockoutItem.stockout_date &&
                                              x.delivery_qty == stockoutItem.stockout_qty
                                        select x);
                        //Delete item from list
                        listInputPremac.Remove(tempItem.FirstOrDefault());
                        listStockOutItem.Remove(stockoutItem);
                    }
                }
                dgvInspection.DataSource = listStockOutItem;
                #endregion
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
            UpdateInspectionGrid();
            txtBarcode.Focus();
        }

        private void btnInspectionClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomMessageBox.Warring("This list is not register. Are you sure to clear all?" + Environment.NewLine + "Danh sách này chưa được đăng ký. Bạn có chắc muốn xóa tất cả?") == DialogResult.No)
                    return;
                //  txtUserCD.Clear();
                txtBarcode.Clear();
                txtSupplierCD.Clear();
                //listStockItem.Clear();
                listStockOutItem.Clear();
                listInputPremac.Clear();
                txtSupplierName.Text = "Supplier Name";
                errorProvider.SetError(txtSupplierCD, null);
                UpdateInspectionGrid();
                dgvInspection.DataSource = null;
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion

        #region FIELDS EVENT
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
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
                    SupplierCD = string.Empty,
                    Remark = string.Empty
                };
                if (barcode.Length > 7)
                {
                    if (!string.IsNullOrEmpty(barcode[6])) lbData.SupplierCD = barcode[6].Trim();
                    if (!string.IsNullOrEmpty(barcode[7])) lbData.Remark = barcode[7].Trim();
                }
                txtInsInvoice.Text = lbData.Invoice;
                txtInQty.Text = lbData.Delivery_Qty.ToString();
                txtLabelQty.Focus();
            }
        }

        private void txtLabelQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNewItem(lbData, int.Parse(txtLabelQty.Text));
                txtInQty.ResetText();
                txtBarcode.ResetText();
                txtInsInvoice.ResetText();
                txtSupplierCD.ResetText();
                txtSupplierName.Text = "Supplier Name";
                txtBarcode.Focus();
                txtLabelQty.Text = "1";
            }
        }

        private void txtLabelQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        //private void txtUserCD_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        string temp = txtUserCD.Text;
        //        if (temp.Contains(";")) temp = temp.Split(';')[0].Trim();
        //        if (temp.Length > 6) txtUserCD.Text = temp.Substring(temp.Length - 6);
        //        else txtUserCD.Text = temp;
        //        try
        //        {
        //            pre_user mUser = new pre_user();
        //            lbUserName.Text = mUser.GetUser(txtUserCD.Text).user_name;
        //            lbUserName.BackColor = Color.Lime;
        //            pnlInspection.Visible = true;
        //            txtBarcode.Focus();
        //        }
        //        catch (Exception ex)
        //        {
        //            txtUserCD.Focus();
        //            lbUserName.Text = "User Name";
        //            lbUserName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
        //            CustomMessageBox.Error("Wrong User Code!" + Environment.NewLine + "(" + ex.Message + ")");
        //        }
        //    }
        //}



        private void tab_Inspection_Paint(object sender, PaintEventArgs e)
        {
            UpdateInspectionGrid();
            txtBarcode.Focus();
            //   if (!pnlInspection.Visible);
        }
        #endregion

        #region SUB EVENT
        /// <summary>
        /// Update datagridview
        /// </summary>
        private void UpdateInspectionGrid()
        {
            #region OLD
            //dgvInspection.DataSource = listStockItem;
            //dgvInspection.Columns["stock_id"].HeaderText = "Stock ID";
            //dgvInspection.Columns["packing_cd"].HeaderText = "Packing Code";
            //dgvInspection.Columns["item_cd"].HeaderText = "Item Code";
            //dgvInspection.Columns["supplier_cd"].HeaderText = "Supplier Code";
            //dgvInspection.Columns["order_no"].HeaderText = "Order Number";
            //dgvInspection.Columns["invoice"].HeaderText = "Invoice";
            //dgvInspection.Columns["stockin_date"].HeaderText = "Stock In Date";
            //dgvInspection.Columns["stockin_user_cd"].HeaderText = "Incharge";
            //dgvInspection.Columns["stockin_qty"].HeaderText = "Stock In Qty";
            //dgvInspection.Columns["packing_qty"].HeaderText = "Packing Qty";
            //dgvInspection.Columns["registration_user_cd"].HeaderText = "Reg User";
            //dgvInspection.Columns["registration_date_time"].HeaderText = "Reg Date";
            //dgvInspection.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            //double total = listStockItem.Sum(x => x.stockin_qty);
            //tsRow.Text = dgvInspection.Rows.Count.ToString();
            //tsTotalQty.Text = total.ToString();
            #endregion
            #region NEW
            dgvInspection.DataSource = listStockOutItem;
            dgvInspection.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            double total = listStockOutItem.Sum(x => x.stockout_qty);
            tsRow.Text = dgvInspection.Rows.Count.ToString();
            tsTotalQty.Text = total.ToString();
            #endregion
        }

        /// <summary>
        /// Add new stock item into temp list
        /// </summary>
        private void AddNewItem(PrintItem lbItem, int labelQty)
        {
            try
            {
                int n = 0;
                int temp = 0;
                string invoice = "None";
                //string remark = string.Empty;
                //string suppliercd = string.Empty;
                txtSupplierCD.Clear();
                txtSupplierName.Clear();
                try
                {
                    itemData.GetItem(lbItem.Item_Number);
                }
                catch
                {
                    CustomMessageBox.Error("This item is not exisits! Please check and try again!" + Environment.NewLine + "Nguyên liệu này không tồn tại!");
                    return;
                }
                #region CHECK SUPPLIER & NOTICE FOR USER
                errorProvider.SetError(txtSupplierCD, null);
                txtSupplierName.Text = lbItem.SupplierName;
                try
                {
                    //If don't have supplier code then search with supplier name and return supplier code
                    if (string.IsNullOrEmpty(lbItem.SupplierCD))
                    {
                        supplierItem = supplierItem.GetSupplier(new pts_supplier
                        {
                            supplier_id = 0,
                            supplier_name = txtSupplierName.Text
                        });
                        txtSupplierCD.Text = supplierItem.supplier_cd;
                    }
                    else
                    {
                        txtSupplierCD.Text = lbItem.SupplierCD;
                        //Searh with supplier code
                        supplierItem = supplierItem.GetSupplier(new pts_supplier
                        {
                            supplier_id = 0,
                            supplier_cd = txtSupplierCD.Text
                        });
                    }
                }
                catch (Exception ex)
                {
                    //If supplier is not exist, create a supplier with simple info
                    errorProvider.SetError(txtSupplierCD, "This supplier is not exist!" + Environment.NewLine + "Please fill supplier code and press F2 for add new supplier (" + ex.Message + ")" + Environment.NewLine + "NSX này không tồn tại! Vui lòng điền mã NSX và nhấn F2 để thêm mới NSX");
                    return;
                }
                #endregion

                #region CHECK INVOICE EXIST
                try
                {
                    #region OLD
                    //Search item in stock with invoice number
                    //if (stockItem.SearchItem(new pts_stock { item_cd = lbItem.Item_Number, invoice = lbItem.Invoice }))
                    //{
                    //    double totalStockIn = (from x in stockItem.listStockItems where x.item_cd == lbItem.Item_Number select x.stockin_qty).Sum();
                    //    double totalPacking = (from x in stockItem.listStockItems where x.item_cd == lbItem.Item_Number select x.packing_qty).Sum();
                    //    //If this item is exist, notice user
                    //    string mess = "Item code: " + lbItem.Item_Number + " and Invoice: " + lbItem.Invoice + "is exist!" + Environment.NewLine;
                    //    mess += "Total stock-in: " + totalStockIn + Environment.NewLine + "Total packing: " + totalPacking + Environment.NewLine;
                    //    mess += "Are you sure add new packing with this Invoice?" + Environment.NewLine + "Bạn có muốn thêm gói mới với mã hóa đơn này không?";
                    //    if (CustomMessageBox.Question(mess) == DialogResult.No) return;
                    //}
                    #endregion

                    #region NEW
                    if (stockoutItem.SearchItem(new pts_stockout { item_cd = lbItem.Item_Number, invoice = lbItem.Invoice }))
                    {
                        double totalStockIn = (from x in stockoutItem.listStockItems
                                               where x.item_cd == lbItem.Item_Number
         && x.remark == "I"
                                               select x.stockout_qty).Sum();
                        double totalPacking = (from x in stockoutItem.listStockItems
                                               where x.item_cd == lbItem.Item_Number
         && x.remark == "I"
                                               select x.stockout_qty).Sum();
                        //If this item is exist, notice user
                        string mess = "Item code: " + lbItem.Item_Number + " and Invoice: " + lbItem.Invoice + "is exist!" + Environment.NewLine;
                        mess += "Total stock-in: " + totalStockIn + Environment.NewLine + "Total packing: " + totalPacking + Environment.NewLine;
                        mess += "Are you sure add new packing with this Invoice?" + Environment.NewLine + "Bạn có muốn thêm gói mới với mã hóa đơn này không?";
                        if (CustomMessageBox.Question(mess) == DialogResult.No) return;
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Error(ex.Message);
                }
                #endregion

                for (int i = 0; i < labelQty; i++)
                {
                    #region CHECK INVOICE AND CREATE PACKING CODE OLD
                    ////Get max number packing of this Invoice in database
                    //foreach (pts_stock item in stockItem.listStockItems)
                    //{
                    //    if (!string.IsNullOrEmpty(item.invoice))
                    //        temp = int.Parse(item.packing_cd.Substring(item.invoice.Length + 1));
                    //    else
                    //        temp = int.Parse(item.packing_cd.Substring(5));
                    //    if (temp > n) n = temp;
                    //}
                    ////Create new number of packing with Invoice number
                    //foreach (pts_stock item in listStockItem)
                    //{
                    //    if (item.invoice == lbItem.Invoice)
                    //    {
                    //        if (!string.IsNullOrEmpty(item.invoice))
                    //            temp = int.Parse(item.packing_cd.Substring(item.invoice.Length + 1));
                    //        else
                    //            temp = int.Parse(item.packing_cd.Substring(5));
                    //        if (temp > n) n = temp;
                    //    }
                    //}
                    //n++;
                    //if (!string.IsNullOrEmpty(lbItem.Invoice)) invoice = lbItem.Invoice;
                    //string packingcd = invoice + "-" + n.ToString("00");
                    #endregion

                    #region CHECK INVOICE AND CREATE PACKING CODE NEW
                    //Get max number packing of this Invoice in database
                    foreach (pts_stockout item in stockoutItem.listStockItems)
                    {
                        if (item.remark != "I") continue;
                        if (!string.IsNullOrEmpty(item.invoice))
                            temp = int.Parse(item.packing_cd.Substring(item.invoice.Length + 1));
                        else
                            temp = int.Parse(item.packing_cd.Substring(5));
                        if (temp > n) n = temp;
                    }
                    //Create new number of packing with Invoice number
                    foreach (pts_stockout item in listStockOutItem)
                    {
                        if (item.invoice == lbItem.Invoice)
                        {
                            if (!string.IsNullOrEmpty(item.invoice))
                                temp = int.Parse(item.packing_cd.Substring(item.invoice.Length + 1));
                            else
                                temp = int.Parse(item.packing_cd.Substring(5));
                            if (temp > n) n = temp;
                        }
                    }
                    n++;
                    if (!string.IsNullOrEmpty(lbItem.Invoice)) invoice = lbItem.Invoice;
                    string packingcd = invoice + "-" + n.ToString("00");
                    #endregion

                    //Add new barcode item into list stock item
                    listStockOutItem.Add(new pts_stockout
                    {
                        item_cd = lbItem.Item_Number,
                        item_name = lbItem.Item_Name,
                        supplier_name = lbItem.SupplierName,
                        invoice = lbItem.Invoice,
                        stockout_date = lbItem.Delivery_Date,
                        stockout_qty = lbItem.Delivery_Qty,
                        packing_cd = packingcd,
                        remark = "I",
                        registration_user_cd = UserData.usercode,
                        registration_date_time = DateTime.Today,
                    });
                    if (lbItem.Remark != "P")
                    {
                        listInputPremac.Add(new pre_649
                        {
                            item_number = lbItem.Item_Number,
                            item_name = lbItem.Item_Name,
                            supplier_cd = txtSupplierCD.Text,
                            supplier_name = txtSupplierName.Text,
                            supplier_invoice = lbItem.Invoice,
                            delivery_date = lbItem.Delivery_Date,
                            delivery_qty = lbItem.Delivery_Qty,
                            // incharge = txtUserCD.Text,
                            //order_number = orderno,
                        });
                    }
                }
                UpdateInspectionGrid();
            }
            catch (IndexOutOfRangeException)
            {
                CustomMessageBox.Error("Wrong format barcode!" + Environment.NewLine + "Please check barcode and try again!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private List<pre_649> GroupByPremac()
        {
            List<pre_649> list = new List<pre_649>();
            list = (from item in listInputPremac
                    group item by new
                    {
                        item.item_number,
                        item.item_name,
                        item.supplier_cd,
                        item.supplier_name,
                        item.supplier_invoice,
                        item.delivery_date,
                        item.incharge
                    } into g
                    select new pre_649()
                    {
                        item_number = g.Key.item_number,
                        item_name = g.Key.item_name,
                        supplier_cd = g.Key.supplier_cd,
                        supplier_name = g.Key.supplier_name,
                        supplier_invoice = g.Key.supplier_invoice,
                        delivery_qty = g.Sum(a => a.delivery_qty),
                        delivery_date = g.Key.delivery_date,
                        incharge = g.Key.incharge
                    }).OrderBy(x => x.supplier_invoice).ToList();
            return list;
        }

        #endregion

        #endregion

        #region CALL ADD DGV TO DATABASE
        private void CallAddDB()
        {
            foreach (DataGridViewRow dr in dgvPrintList.Rows)
            {
                PrintItem lbTemp = dr.DataBoundItem as PrintItem;
                listPrintItem.Add(lbTemp);
                dr.DefaultCellStyle.BackColor = Color.Lime;
                // dgvPrintList.Rows.Remove(dr);
                if (bool.Parse(SettingItem.checkSaved))
                {
                    stockoutItem.AddItem(new pts_stockout
                    {
                        packing_cd = string.Format("{0}-{1}", lbTemp.Invoice, lbTemp.Item_Number),
                        item_cd = lbTemp.Item_Number,
                        item_name = lbTemp.Item_Name,
                        supplier_name = lbTemp.SupplierName,
                        invoice = lbTemp.Invoice,
                        stockout_date = DateTime.Now,
                        stockout_qty = lbTemp.Delivery_Qty * lbTemp.Label_Qty,
                        remark = "I",
                        registration_user_cd = UserData.usercode,
                    });
                }
            }
        }
        #endregion
        #region CALL ADD 1 ROW TO DB
        private void CallAdd1RowDB()
        {
            foreach (DataGridViewRow dr in dgvPrintList.SelectedRows)
            {
                PrintItem lbTemp = dr.DataBoundItem as PrintItem;
                listPrintItem.Add(lbTemp);
                dr.DefaultCellStyle.BackColor = Color.Lime;
                // dgvPrintList.Rows.Remove(dr);
                if (bool.Parse(SettingItem.checkSaved))
                {
                    stockoutItem.AddItem(new pts_stockout
                    {
                        packing_cd = string.Format("{0}-{1}", lbTemp.Invoice, lbTemp.Item_Number),
                        item_cd = lbTemp.Item_Number,
                        item_name = lbTemp.Item_Name,
                        supplier_name = lbTemp.SupplierName,
                        invoice = lbTemp.Invoice,
                        stockout_date = DateTime.Now,
                        stockout_qty = lbTemp.Delivery_Qty * lbTemp.Label_Qty,
                        remark = "I",
                        registration_user_cd = UserData.usercode,
                    });
                }
            }

        }
        #endregion
        #region ADD SELECT ROW TO DB
        private void CallAddSelectRow()
        {
            double lbelqty = double.Parse(txtPrintLabelQty.Text);
            //if (txtPrintLabelQty.Text == lbelqty)
            // {

            foreach (DataGridViewRow dr in dgvPrintList.SelectedRows)
            {
                PrintItem lbTemp = dr.DataBoundItem as PrintItem;
                listPrintItem.Add(lbTemp);
                dr.DefaultCellStyle.BackColor = Color.Lime;
                if (bool.Parse(SettingItem.checkSaved))
                {
                    stockoutItem.AddItem(new pts_stockout
                    {
                        packing_cd = string.Format("{0}-{1}", lbTemp.Invoice, lbTemp.Item_Number),
                        item_cd = lbTemp.Item_Number,
                        item_name = lbTemp.Item_Name,
                        supplier_name = lbTemp.SupplierName,
                        invoice = lbTemp.Invoice,
                        stockout_date = DateTime.Now,
                        stockout_qty = lbTemp.Delivery_Qty * lbelqty,
                        remark = "I",
                        registration_user_cd = UserData.usercode,
                    });
                }
                //  }

            }
        }
        #endregion

        #region PRINTITEM

        private void btnPrintItem_Click_1(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tabPrintNew;
            txtbarcodenew.Focus();
        }
        #endregion
        #region BARCODE NEW KEYDOWN
        private void txtbarcodenew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string[] barcode = txtbarcodenew.Text.Split(';');
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
                    txtsupliername.Text = lbData.SupplierName;
                    txtQty.Text = lbData.Delivery_Qty.ToString();
                    dtpfromdatenew.Value = lbData.Delivery_Date;
                    cmbRemark.Text = lbData.Remark;

                    //Thêm tem tồn vào danh sách in
                    printItem.ListPrintItem.Add(new PrintItem
                    {
                        Item_Number = txtItemNumber.Text,
                        Item_Name = txtItemName.Text,
                        SupplierName = txtsupliername.Text,
                        Invoice = txtInvoice.Text,
                        Delivery_Date = dtpfromdatenew.Value,
                        Delivery_Qty = double.Parse(txtQty.Text),
                        Remark = cmbRemark.Text,
                        isRec = true,
                        Label_Qty = int.Parse(txtqtylabel.Text)
                    });
                    UpdatePrintNewGrid();
                }

                catch (Exception ex)
                {
                    CustomMessageBox.Error(ex.Message);
                }
            }
        }
        #endregion

        private void btnback2_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Main;

        }

        private void UpdatePrintNewGrid()
        {
            dgvData.DataSource = printItem.ListPrintItem;
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            double total = dgvData.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["Delivery_Qty"].Value));
            tsTotalQty.Text = total.ToString();
            tsRow.Text = dgvData.Rows.Count.ToString();
        }
        #region BUTTON CLEAR
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbarcodenew.Clear();
            txtItemNumber.Clear();
            txtItemName.Clear();
            txtsupliername.Clear();
            txtQty.Clear();
            txtInvoice.Clear();
            cmbRemark.Text = null;
            dtpfromdatenew.Value = DateTime.Now;
            dgvData.DataSource = null;
        }
        #endregion
        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string[] barcode = txtbarcodenew.Text.Split(';');
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
                    txtInvoice.Text = txtInvoice.Text;
                    txtItemName.Text = txtItemName.Text;
                    txtItemNumber.Text = txtItemNumber.Text;
                    txtsupliername.Text = txtsupliername.Text;
                    txtQty.Text = txtQty.Text;
                    dtpfromdatenew.Value = dtpfromdatenew.Value;
                    cmbRemark.Text =cmbRemark.Text;

                    //Thêm tem tồn vào danh sách in
                    printItem.ListPrintItem.Add(new PrintItem
                    {
                        Item_Number = txtItemNumber.Text,
                        Item_Name = txtItemName.Text,
                        SupplierName = txtsupliername.Text,
                        Invoice = txtInvoice.Text,
                        Delivery_Date = dtpfromdatenew.Value,
                        Delivery_Qty = double.Parse(txtQty.Text),
                        Remark = cmbRemark.Text,
                        isRec = true,
                        Label_Qty = int.Parse(txtqtylabel.Text)
                    });
                    UpdatePrintNewGrid();
                    dgvData.Rows.RemoveAt(0);
                }

                catch (Exception ex)
                {
                    CustomMessageBox.Error(ex.Message);
                }
            }

        }
 
      
        #region PRINT SELECT 
        private void btnPrintSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (printItem.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline" + Environment.NewLine + "Máy in chưa kết nối!");
                    return;
                }
                listPrintItem.Clear();
                if (dgvData.SelectedRows.Count <= 0)
                {
                    CustomMessageBox.Notice("Please choose item first!" + Environment.NewLine + "Vui lòng chọn tem cần in!");
                    return;
                }
                foreach (DataGridViewRow dr in dgvData.SelectedRows)
                {
                    PrintItem lbTemp = dr.DataBoundItem as PrintItem;
                    listPrintItem.Add(lbTemp);
                    dgvData.Rows.Remove(dr);
                    if (bool.Parse(SettingItem.checkSaved))
                    {
                        stockoutItem.AddItem(new pts_stockout
                        {
                            packing_cd = string.Format("{0}-{1}", lbTemp.Invoice, lbTemp.Item_Number),
                            item_cd = lbTemp.Item_Number,
                            item_name = lbTemp.Item_Name,
                            supplier_name = lbTemp.SupplierName,
                            invoice = lbTemp.Invoice,
                            stockout_date = DateTime.Now,
                            stockout_qty = lbTemp.Delivery_Qty,
                            remark = lbTemp.Remark,
                            registration_user_cd = UserData.usercode,
                        });
                    }
                }
                if (printItem.PrintItems(listPrintItem, false))
                    CustomMessageBox.Notice("Print items are completed!"
                        + Environment.NewLine + "In hoàn tất!");
                txtbarcodenew.Focus();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion

        private void dgvData_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtItemNumber.Text = dgvData.CurrentRow.Cells[0].Value.ToString();
            txtItemName.Text = dgvData.CurrentRow.Cells[1].Value.ToString();
            txtsupliername.Text = dgvData.CurrentRow.Cells[2].Value.ToString();
            txtInvoice.Text = dgvData.CurrentRow.Cells[3].Value.ToString();
            dtpfromdatenew.Text = dgvData.CurrentRow.Cells[4].Value.ToString();
            txtQty.Text = dgvData.CurrentRow.Cells[5].Value.ToString();
            cmbRemark.Text = dgvData.CurrentRow.Cells[7].Value.ToString();
            txtLabelQty.Text = dgvData.CurrentRow.Cells[8].Value.ToString();
        }

     
    }
}
