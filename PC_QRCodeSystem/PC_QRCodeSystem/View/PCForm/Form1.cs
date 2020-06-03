using System;
using System.Drawing;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;
using System.Collections.Generic;
using System.Linq;

namespace PC_QRCodeSystem.View
{
    public partial class Form1 : FormCommon
    {
        #region VARIABLE
        bool isdgvDup = false;
        PrintItem lbData { get; set; }
        PrintItem printItem { get; set; }
        pts_stockout stockoutItem { get; set; }
        List<PrintItem> listPrintItem { get; set; }
        ErrorProvider errorProvider = new ErrorProvider();
        #endregion
        #region FORM LOAD
        public Form1()
        {
            InitializeComponent();
            lbData = new PrintItem();
            printItem = new PrintItem();
            stockoutItem = new pts_stockout();
            listPrintItem = new List<PrintItem>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }
        #endregion
        #region BUTTON DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Question("Are you sure delete this item?" + Environment.NewLine + "Bạn có chắc xóa nguyên liệu này?") == DialogResult.No)
                return;
            foreach (DataGridViewRow item in this.dgvInspection.SelectedRows)
            {
                dgvInspection.Rows.RemoveAt(item.Index);
            }
        }
        #endregion
        #region BUTTON BACK
        private void btnInsBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region BUTTON PRINT ALL
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (printItem.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline" + Environment.NewLine + "Máy in chưa kết nối!");
                    return;
                }
                listPrintItem.Clear();
                if (dgvInspection.Rows.Count == 0)
                {
                    CustomMessageBox.Error("Don't have item to print!" + Environment.NewLine + "Không có tem để in!");
                    return;
                }
                foreach (DataGridViewRow dr in dgvInspection.Rows)
                {
                    listPrintItem.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.Lime;
                }
                //Thêm dữ liệu vào database
                if (bool.Parse(SettingItem.checkSaved))
                {
                    stockoutItem.AddMultiItem(stockoutItem.listStockItems.ToList());
                }
                if (printItem.PrintItems(listPrintItem, false))
                    CustomMessageBox.Notice("Print items are completed!"
                        + Environment.NewLine + "In hoàn tất!");
                //Xóa dữ liệu sau khi in
                stockoutItem.listStockItems.Clear();
                printItem.ListPrintItem.Clear();
                dgvInspection.DataSource = null;
                dgvOldData.Rows.Clear();
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion
        #region BUTTON PRINT ITEMS
        private void btnPrintItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (printItem.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline" + Environment.NewLine + "Máy in chưa kết nối!");
                    return;
                }
                listPrintItem.Clear();
                if (dgvInspection.SelectedRows.Count <= 0)
                {
                    CustomMessageBox.Notice("Please choose item first!" + Environment.NewLine + "Vui lòng chọn tem cần in!");
                    return;
                }
                foreach (DataGridViewRow dr in dgvInspection.SelectedRows)
                {
                    PrintItem lbTemp = dr.DataBoundItem as PrintItem;
                    listPrintItem.Add(lbTemp);
                    dgvInspection.Rows.Remove(dr);
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
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion
        #region BUTTON CLEAR ALL
        private void btnInspectionClear_Click_1(object sender, EventArgs e)
        {
            try
            {
                dgvOldData.Rows.Clear();
                listPrintItem.Clear();
                printItem.ListPrintItem.Clear();
                dgvInspection.Rows.Clear();
                txtBarcode.Clear();
                txtInQty.Clear();
                txtOld.Clear();
                txtLabelQty.Clear();
                txtBarcode.Focus();
                txtLabelQty.Text = "1";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion
        #region SUB EVENT BARCODE KEYDOWN
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)

                {
                    if (dgvOldData.Rows.Count == 1)
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
                            Remark = string.Empty
                        };
                        if (barcode.Length > 7)
                        {
                            if (!string.IsNullOrEmpty(barcode[6])) lbData.SupplierCD = barcode[6].Trim();
                            if (!string.IsNullOrEmpty(barcode[7])) lbData.Remark = barcode[7].Trim();
                        }
                        int n = dgvOldData.Rows.Add();
                        dgvOldData.Rows[n].Cells[0].Value = lbData.Item_Number;
                        dgvOldData.Rows[n].Cells[1].Value = lbData.Item_Name;
                        dgvOldData.Rows[n].Cells[2].Value = lbData.SupplierName;
                        dgvOldData.Rows[n].Cells[3].Value = lbData.Invoice;
                        dgvOldData.Rows[n].Cells[4].Value = lbData.Delivery_Qty;
                        dgvOldData.Rows[n].Cells[5].Value = lbData.Delivery_Date;
                        txtOld.Text = lbData.Delivery_Qty.ToString();
                        txtInQty.Text = lbData.Delivery_Qty.ToString();
                        txtInQty.Focus();
                        isdgvDup = false;
                    }
                    else if (dgvOldData.Rows.Count >= 2)
                    {
                        dgvOldData.Rows.Clear();
                        dgvInspection.Rows.Clear();
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
                            Remark = string.Empty
                        };
                        if (barcode.Length > 7)
                        {
                            if (!string.IsNullOrEmpty(barcode[6])) lbData.SupplierCD = barcode[6].Trim();
                            if (!string.IsNullOrEmpty(barcode[7])) lbData.Remark = barcode[7].Trim();
                        }
                        int n = dgvOldData.Rows.Add();
                        dgvOldData.Rows[n].Cells[0].Value = lbData.Item_Number;
                        dgvOldData.Rows[n].Cells[1].Value = lbData.Item_Name;
                        dgvOldData.Rows[n].Cells[2].Value = lbData.SupplierName;
                        dgvOldData.Rows[n].Cells[3].Value = lbData.Invoice;
                        dgvOldData.Rows[n].Cells[4].Value = lbData.Delivery_Qty;
                        dgvOldData.Rows[n].Cells[5].Value = lbData.Delivery_Date;
                        txtOld.Text = lbData.Delivery_Qty.ToString();
                        txtInQty.Text = lbData.Delivery_Qty.ToString();
                        txtInQty.Focus();
                        isdgvDup = false;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion
        #region SUB EVENT QTY KEYDOWN
        private void txtInQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    CalcQty(1);
                    txtOld.Text = txtInQty.Text;

                }
               
                catch (Exception ex)
                {
                    CustomMessageBox.Error(ex.Message);
                }
            }
        }
        #endregion
        #region SUB EVENT LABEL QTY KEYDOWN
        private void txtLabelQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, true, true, true, true);
                }
            }
            catch
            {

            }
        }
        #endregion
        #region SUB EVENT CACULATOR LABEL QTY
        private void CalcQty(int lbQty)
        {
            lbQty = int.Parse(txtLabelQty.Text);
            //Số lượng xuất được nhập vào
            double stockoutQty = double.Parse(txtInQty.Text);

            //Số lượng tồn
            double totalQty = double.Parse(txtOld.Text);
            double stockQty = totalQty - (stockoutQty * lbQty);
            txtOld.Text = stockQty.ToString();
            if (stockoutQty <= 0)
            {
                CustomMessageBox.Notice("Please enter stock out qty!" + Environment.NewLine + "Nhập số lượng xuất!");
                return;
            }
            if (stockoutQty == totalQty)
            {
                CustomMessageBox.Notice("Duplicate label stockin! Please try again " + Environment.NewLine + "Trùng tem! Vui lòng nhập lại");
                return;
            }
            if (stockQty < 0)
            {
                CustomMessageBox.Notice("This lot not enough! Please try again" + Environment.NewLine + "Lô này không đủ! Vui lòng nhập lại");
                // stockQty = lbData.Delivery_Qty;
                dgvOldData.Rows.Clear();
                listPrintItem.Clear();
                printItem.ListPrintItem.Clear();
                dgvInspection.Rows.Clear();
                txtBarcode.Clear();
                txtInQty.Clear();
                txtOld.Clear();
                txtLabelQty.Clear();
                txtBarcode.Focus();
                txtLabelQty.Text = "1";

            }
            //Nếu còn tồn thì mới in tem
            if (stockQty > 0)
            {
                //Thêm tem xuất vào danh sách in
                printItem.ListPrintItem.Add(new PrintItem
                {
                    Item_Number = lbData.Item_Number,
                    Item_Name = lbData.Item_Name,
                    SupplierName = lbData.SupplierName,
                    Invoice = lbData.Invoice,
                    Delivery_Date = lbData.Delivery_Date,
                    Delivery_Qty = stockoutQty,
                    Remark = "O",
                    isRec = false,
                    Label_Qty = lbQty
                });
                //Thêm tem tồn vào danh sách in
                printItem.ListPrintItem.Add(new PrintItem
                {
                    Item_Number = lbData.Item_Number,
                    Item_Name = lbData.Item_Name,
                    SupplierName = lbData.SupplierName,
                    Invoice = lbData.Invoice,
                    Delivery_Date = lbData.Delivery_Date,
                    Delivery_Qty = stockQty,
                    Remark = "R",
                    isRec = true,
                    Label_Qty = 1
                });
                //Nếu còn tồn thì lưu lại vào database
                stockoutItem.listStockItems.Add(new pts_stockout
                {
                    packing_cd = string.Format("{0}-{1}", lbData.Invoice, lbData.Item_Number),
                    item_cd = lbData.Item_Number,
                    item_name = lbData.Item_Name,
                    supplier_name = lbData.SupplierName,
                    invoice = lbData.Invoice,
                    stockout_date = DateTime.Now,
                    stockout_qty = stockQty,
                    remark = "R",
                    registration_user_cd = UserData.usercode,
                });
            }
            if (stockQty == 0)
            {
                printItem.ListPrintItem.Add(new PrintItem
                {
                    Item_Number = lbData.Item_Number,
                    Item_Name = lbData.Item_Name,
                    SupplierName = lbData.SupplierName,
                    Invoice = lbData.Invoice,
                    Delivery_Date = lbData.Delivery_Date,
                    Delivery_Qty = stockoutQty,
                    Remark = "O",
                    isRec = false,
                    Label_Qty = lbQty
                });
            }
            //Lưu số lượng xuất vào database
            stockoutItem.listStockItems.Add(new pts_stockout
            {
                packing_cd = string.Format("{0}-{1}", lbData.Invoice, lbData.Item_Number),
                item_cd = lbData.Item_Number,
                item_name = lbData.Item_Name,
                supplier_name = lbData.SupplierName,
                invoice = lbData.Invoice,
                stockout_date = DateTime.Now,
                stockout_qty = stockoutQty,
                remark = "O",
                registration_user_cd = UserData.usercode,
            });

            //Thêm tem tồn vào danh sách
            UpdatePrintGrid();
            txtBarcode.ResetText();
            txtInQty.ResetText();
            //txtBarcode.Focus();
            if (isdgvDup)
            {
                dgvInspection.Rows.RemoveAt(dgvInspection.SelectedRows[0].Index);
                var indexList = stockoutItem.listStockItems.Where(x => x.item_cd == lbData.Item_Number && x.invoice == lbData.Invoice && x.stockout_qty == lbData.Delivery_Qty)
                                            .Select(x => stockoutItem.listStockItems.IndexOf(x)).First();
                stockoutItem.listStockItems.RemoveAt(indexList);
                isdgvDup = false;
            }
            // }
        }
        #endregion
        #region SUB EVENT UPDATE PRINT GRID
        private void UpdatePrintGrid()
        {
            dgvInspection.DataSource = printItem.ListPrintItem;
            dgvInspection.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            double total = dgvInspection.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["Delivery_Qty"].Value));
            tsTotalQty.Text = total.ToString();
            tsRow.Text = dgvInspection.Rows.Count.ToString();
        }
        #endregion
        #region DGV DOUBLE CLICK
        private void dgvInspection_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtInQty.Text = dgvInspection.CurrentRow.Cells[5].Value.ToString();
            txtInQty.Focus();
            isdgvDup = true;
            lbData = dgvInspection.Rows[e.RowIndex].DataBoundItem as PrintItem;
            txtOld.Text = lbData.Delivery_Qty.ToString();
            txtInQty.Focus();
        }
        #endregion
    }
}
