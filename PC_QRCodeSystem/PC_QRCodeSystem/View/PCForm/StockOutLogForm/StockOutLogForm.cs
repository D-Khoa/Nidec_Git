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
        pts_item itemData { get; set; }
        pts_stockout stockItem { get; set; }
        ErrorProvider errorProvider = new ErrorProvider();
        BindingList<pts_stockout> listStockItem { get; set; }
        List<PrintItem> listPrintItem { get; set; }
        public StockOutLogForm()
        {
            InitializeComponent();
            tc_Main.ItemSize = new Size(0, 1);
            lbData = new PrintItem();
            itemData = new pts_item();
            stockItem = new pts_stockout();
            listStockItem = new BindingList<pts_stockout>();
            printItem = new PrintItem();
            listPrintItem = new List<PrintItem>();
        }

        private void StockOutLogForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

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
                    txtDeliveryDate.Text = lbData.Delivery_Date.ToString("yyyy-MM-dd");
                    txtItemName.Text = lbData.Item_Name;
                    txtItemNumber.Text = lbData.Item_Number;
                    txtSupplierName.Text = lbData.SupplierName;
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
                    double qtymod = 0;
                    int numberOfLot = 1;
                    double sizePerLot = 1;
                    qtymod = 0;
                    sizePerLot = double.Parse(txtInQty.Text);
                    double deliveryQty = lbData.Delivery_Qty;
                    deliveryQty -= sizePerLot;
                    if (deliveryQty < 0)
                    {
                        CustomMessageBox.Notice("This lot is null" + Environment.NewLine + "Lô này trống!");
                        return;
                    }
                    if (deliveryQty == 0)
                    {
                        CustomMessageBox.Notice("This lot is null" + Environment.NewLine + "Trùng tem Stockin!");
                        return;
                    }

                    //if (deliveryQty <= 0)
                    //{
                    //    sizePerLot = lbData.Delivery_Qty;
                    //    lbData.Delivery_Qty = 0;
                    //}
                    else lbData.Delivery_Qty = deliveryQty;
                    printItem.ListPrintItem.Add(new PrintItem
                    {
                        Item_Number = lbData.Item_Number,
                        Item_Name = lbData.Item_Name,
                        SupplierName = lbData.SupplierName,
                        Invoice = lbData.Invoice,
                        Delivery_Date = lbData.Delivery_Date,
                        Delivery_Qty = sizePerLot,
                        Remark = "P",
                        isRec = true,
                        Label_Qty = 1
                    });
                    if (sizePerLot * numberOfLot <= deliveryQty)
                    {
                        qtymod = deliveryQty;
                        // qtymod = deliveryQty - (sizePerLot * numberOfLot);
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = lbData.Item_Number,
                            Item_Name = lbData.Item_Name,
                            SupplierName = lbData.SupplierName,
                            Invoice = lbData.Invoice,
                            Delivery_Date = lbData.Delivery_Date,
                            Delivery_Qty = qtymod,
                            Remark = "R",
                            isRec = true,
                            Label_Qty = numberOfLot
                        });
                    }
                    if (sizePerLot * numberOfLot > deliveryQty)
                    {
                        qtymod = deliveryQty;
                        // qtymod = deliveryQty - (sizePerLot * numberOfLot);
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = lbData.Item_Number,
                            Item_Name = lbData.Item_Name,
                            SupplierName = lbData.SupplierName,
                            Invoice = lbData.Invoice,
                            Delivery_Date = lbData.Delivery_Date,
                            Delivery_Qty = qtymod,
                            Remark = "R",
                            isRec = true,
                            Label_Qty = numberOfLot
                        });
                    }
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
                if (printItem.PrintItems(listPrintItem, false))
                    CustomMessageBox.Notice("Print items are completed!" + Environment.NewLine + "In hoàn tất!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInspectionClear_Click(object sender, EventArgs e)
        {
            dgvInspection.DataSource = null;
        }
    }
}