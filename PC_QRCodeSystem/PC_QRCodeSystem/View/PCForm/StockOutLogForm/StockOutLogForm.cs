using System;
using System.Drawing;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Diagnostics;

namespace PC_QRCodeSystem.View
{
    public partial class StockOutLogForm : FormCommon
    {
        PrintItem lbData { get; set; }
        PrintItem printItem { get; set; }
        pts_stockout stockoutItem { get; set; }
        List<PrintItem> listPrintItem { get; set; }
        ErrorProvider errorProvider = new ErrorProvider();

        public StockOutLogForm()
        {
            InitializeComponent();
            tc_Main.ItemSize = new Size(0, 1);
            lbData = new PrintItem();
            printItem = new PrintItem();
            stockoutItem = new pts_stockout();
            listPrintItem = new List<PrintItem>();
        }

        private void StockOutLogForm_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Question("Are you sure delete this item?" + Environment.NewLine + "Bạn có chắc xóa nguyên liệu này?") == DialogResult.No)
                return;
            foreach (DataGridViewRow item in this.dgvInspection.SelectedRows)
            {
                dgvInspection.Rows.RemoveAt(item.Index);
            }
        }


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
                        Remark = string.Empty
                    };
                    if (barcode.Length > 7)
                    {
                        if (!string.IsNullOrEmpty(barcode[6])) lbData.SupplierCD = barcode[6].Trim();
                        if (!string.IsNullOrEmpty(barcode[7])) lbData.Remark = barcode[7].Trim();
                    }
                    txtInsInvoice.Text = lbData.Invoice;
                    txtItemName.Text = lbData.Item_Name;
                    txtItemNumber.Text = lbData.Item_Number;
                    txtSupplierName.Text = lbData.SupplierName;
                    txtDeliveryDate.Text = lbData.Delivery_Date.ToString("yyyy-MM-dd");
                    txtInQty.Text = lbData.Delivery_Qty.ToString();
                    txtInQty.Focus();
                }
            }
            catch (Exception)
            {

            }

        }

        private void txtInQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //Số lượng xuất được nhập vào
                    double stockoutQty = double.Parse(txtInQty.Text);
                    //Số lượng tồn
                    double stockQty = lbData.Delivery_Qty - stockoutQty;
                    if (stockoutQty <= 0)
                    {
                        CustomMessageBox.Notice("Please enter stock out qty!" + Environment.NewLine + "Nhập số lượng xuất!");
                        return;
                    }

                    if (stockQty < 0)
                    {
                        CustomMessageBox.Notice("This lot not enough!" + Environment.NewLine + "Lô này không đủ!");
                        return;
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
                            Label_Qty = 1
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
                    txtLabelQty.Text = "1";
                    txtInsInvoice.ResetText();
                    txtItemName.ResetText();
                    txtItemNumber.ResetText();
                    txtDeliveryDate.ResetText();
                    txtSupplierName.ResetText();
                    txtItemName.Text = "Item Name";
                    txtItemNumber.Text = "Item Number";
                    txtSupplierName.Text = "Supplier Name";
                    txtBarcode.Focus();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Error(ex.Message);
                }
            }
        }
        private void UpdatePrintGrid()
        {
            dgvInspection.DataSource = printItem.ListPrintItem;
            dgvInspection.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            double total = dgvInspection.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["Delivery_Qty"].Value));
            tsTotalQty.Text = total.ToString();
            tsRow.Text = dgvInspection.Rows.Count.ToString();
        }

        private void btnInsBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                stockoutItem.AddMultiItem(stockoutItem.listStockItems.ToList());
                if (printItem.PrintItems(listPrintItem, false))
                    CustomMessageBox.Notice("Print items and insert database are completed!" 
                        + Environment.NewLine + "In và thêm dữ liệu vào CSDL hoàn tất!");
                //Xóa dữ liệu sau khi in
                stockoutItem.listStockItems.Clear();
                printItem.ListPrintItem.Clear();
                dgvInspection.DataSource = null;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInspectionClear_Click(object sender, EventArgs e)
        {
            try
            {
                listPrintItem.Clear();
                printItem.ListPrintItem.Clear();
                dgvInspection.DataSource = null;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
    }
}