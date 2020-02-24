using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockInputForm : FormCommon
    {
        #region ITEMS
        pts_item itemData { get; set; }
        pts_stock stockItem { get; set; }
        PremacIn premacItem { get; set; }
        PrintItem printItem { get; set; }
        pts_supplier supplierItem { get; set; }
        List<PrintItem> listPrintItem { get; set; }
        BindingList<pts_stock> listStockItem { get; set; }

        TfPrint tfprinter = new TfPrint();
        Stopwatch stopWatch = new Stopwatch();
        ErrorProvider errorProvider = new ErrorProvider();

        public StockInputForm()
        {
            InitializeComponent();
            itemData = new pts_item();
            printItem = new PrintItem();
            premacItem = new PremacIn();
            stockItem = new pts_stock();
            supplierItem = new pts_supplier();
            listPrintItem = new List<PrintItem>();
            listStockItem = new BindingList<pts_stock>();
            tc_Main.ItemSize = new Size(0, 1);
        }

        private void StockInputForm_Load(object sender, EventArgs e)
        {
            rbtnEven.Checked = true;
            rbtnItemNumber.Checked = true;
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region MAIN TAB
        private void btnPremacImport_Click(object sender, EventArgs e)
        {
            try
            {
                //Set wait cursor when search data
                this.Cursor = Cursors.WaitCursor;
                //Start stopwatch for catch searching time
                stopWatch.Restart();
                //Get list data from premac 6-4-9 file
                premacItem.GetListPremacItem(SettingItem.premacFile);
                dgvPreInput.DataSource = premacItem.listPremacItem;
                tsRow.Text = dgvPreInput.Rows.Count.ToString();
                //Rename file after get data
                File.Move(SettingItem.premacFile, Path.ChangeExtension(SettingItem.premacFile, DateTime.Now.ToString("yyyyMMddHHmmss")));

                //Stop stopwatch and show time
                stopWatch.Stop();
                double total = dgvPreInput.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["Delivery_Qty"].Value));
                tsTime.Text = stopWatch.Elapsed.ToString("s\\.ff") + " s";
                tsRow.Text = dgvPreInput.Rows.Count.ToString();
                tsTotalQty.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tsTime.Text = "None";
            }
            this.Cursor = Cursors.Default;
        }

        private void btnAutoPacking_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int numberOfLot = 1;
                double sizePerLot = 1;
                double qtymod = 0;
                //Each row in datagridview
                foreach (DataGridViewRow dr in dgvPreInput.Rows)
                {
                    qtymod = 0;
                    //If item number is not exist in item database then skip it
                    try { itemData = itemData.GetItem(dr.Cells["Item_Number"].Value.ToString()); }
                    catch { continue; }
                    //Get lot size in database
                    sizePerLot = itemData.lot_size;
                    //If lot size = 0 then no cut lot
                    if (sizePerLot == 0) sizePerLot = (double)dr.Cells["Delivery_Qty"].Value;
                    //Calculator number of lot
                    numberOfLot = (int)((double)dr.Cells["Delivery_Qty"].Value / sizePerLot);
                    //Add new label item into print list
                    printItem.ListPrintItem.Add(new PrintItem
                    {
                        Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                        Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                        SupplierCD = dr.Cells["Supplier_Code"].Value.ToString(),
                        SupplierName = dr.Cells["Supplier_Name"].Value.ToString(),
                        Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                        Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                        Delivery_Qty = sizePerLot,
                        OrderNo = dr.Cells["Order_No"].Value.ToString(),
                        Label_Qty = numberOfLot
                    });
                    //If the last lot is not enough, create an odd label for it
                    if (sizePerLot * numberOfLot < (double)dr.Cells["Delivery_Qty"].Value)
                    {
                        qtymod = (double)dr.Cells["Delivery_Qty"].Value - (sizePerLot * numberOfLot);
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                            Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                            SupplierCD = dr.Cells["Supplier_Code"].Value.ToString(),
                            SupplierName = dr.Cells["Supplier_Name"].Value.ToString(),
                            Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                            Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                            Delivery_Qty = qtymod,
                            OrderNo = dr.Cells["Order_No"].Value.ToString(),
                            Label_Qty = 1
                        });
                    }
                    premacItem.listPremacItem[dr.Index].Delivery_Qty -= (sizePerLot * numberOfLot + qtymod);
                    dgvPreInput.DataSource = premacItem.listPremacItem;
                    //Change color of row when add print item completed
                    dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                //Update print list datagridview
                dgvPrintList.DataSource = printItem.ListPrintItem;
                tc_Main.SelectedTab = tab_Print;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnManualPacking_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                double qtymod = 0;
                int numberOfLot = 1;
                double sizePerLot = 1;
                if (dgvPreInput.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Please select a row before packing!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (rbtnEven.Checked)
                {
                    foreach (DataGridViewRow dr in dgvPreInput.SelectedRows)
                    {
                        qtymod = 0;
                        sizePerLot = double.Parse(txtCapaciy.Text);
                        if (sizePerLot > (double)dr.Cells["Delivery_Qty"].Value)
                        {
                            MessageBox.Show("Lot size you set is over stock-in qty! Please check and try again!", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (sizePerLot == 0) sizePerLot = (double)dr.Cells["Delivery_Qty"].Value;
                        numberOfLot = (int)((double)dr.Cells["Delivery_Qty"].Value / sizePerLot);
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                            Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                            SupplierCD = dr.Cells["Supplier_Code"].Value.ToString(),
                            SupplierName = dr.Cells["Supplier_Name"].Value.ToString(),
                            Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                            Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                            Delivery_Qty = sizePerLot,
                            OrderNo = dr.Cells["Order_No"].Value.ToString(),
                            Label_Qty = numberOfLot
                        });
                        if (sizePerLot * numberOfLot < (double)dr.Cells["Delivery_Qty"].Value)
                        {
                            qtymod = (double)dr.Cells["Delivery_Qty"].Value - (sizePerLot * numberOfLot);
                            printItem.ListPrintItem.Add(new PrintItem
                            {
                                Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                                Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                                SupplierCD = dr.Cells["Supplier_Code"].Value.ToString(),
                                SupplierName = dr.Cells["Supplier_Name"].Value.ToString(),
                                Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                                Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                                Delivery_Qty = qtymod,
                                OrderNo = dr.Cells["Order_No"].Value.ToString(),
                                Label_Qty = 1
                            });
                        }
                        premacItem.listPremacItem[dr.Index].Delivery_Qty -= (sizePerLot * numberOfLot + qtymod);
                        dr.DefaultCellStyle.BackColor = Color.Lime;
                    }
                }
                if (rbtnOdd.Checked)
                {
                    qtymod = 0;
                    sizePerLot = double.Parse(txtCapaciy.Text);
                    DataGridViewRow dr = dgvPreInput.SelectedRows[0];
                    printItem.ListPrintItem.Add(new PrintItem
                    {
                        Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                        Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                        SupplierCD = dr.Cells["Supplier_Code"].Value.ToString(),
                        SupplierName = dr.Cells["Supplier_Name"].Value.ToString(),
                        Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                        Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                        Delivery_Qty = sizePerLot,
                        OrderNo = dr.Cells["Order_No"].Value.ToString(),
                        Label_Qty = 1
                    });
                    dr.DefaultCellStyle.BackColor = Color.Yellow;
                    premacItem.listPremacItem[dr.Index].Delivery_Qty -= sizePerLot;
                }
                dgvPreInput.DataSource = premacItem.listPremacItem;
                dgvPrintList.DataSource = printItem.ListPrintItem;
                tc_Main.SelectedTab = tab_Print;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Print;
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Inspection;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingFrm = new SettingForm();
            settingFrm.ShowDialog();
        }

        private void btnMainClear_Click(object sender, EventArgs e)
        {
            txtCapaciy.Clear();
            tsRow.Text = "None";
            tsTime.Text = "None";
            tsTotalQty.Text = "None";
            dgvPreInput.DataSource = null;
        }

        private void btnSearchPreInput_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            stopWatch.Restart();
            //If search box is empty then show all data
            if (string.IsNullOrEmpty(txtSearchCode.Text))
            {
                dgvPreInput.DataSource = premacItem.listPremacItem;
            }
            else
            {
                //Search with item number
                if (rbtnItemNumber.Checked)
                {
                    dgvPreInput.DataSource = (from item in premacItem.listPremacItem
                                              where item.Item_Number == txtSearchCode.Text
                                              select item).ToList();
                }
                //Search with supplier code
                if (rbtnSupplierCD.Checked)
                {
                    dgvPreInput.DataSource = (from item in premacItem.listPremacItem
                                              where item.Supplier_Code == txtSearchCode.Text
                                              select item).ToList();
                }
                //Search with order number
                if (rbtnOrderNo.Checked)
                {
                    dgvPreInput.DataSource = (from item in premacItem.listPremacItem
                                              where item.Order_No == txtSearchCode.Text
                                              select item).ToList();
                }
                //Search with invoice
                if (rbtnInvoice.Checked)
                {
                    dgvPreInput.DataSource = (from item in premacItem.listPremacItem
                                              where item.Supplier_Invoice == txtSearchCode.Text
                                              select item).ToList();
                }
            }
            stopWatch.Stop();
            double total = dgvPreInput.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["Delivery_Qty"].Value));
            tsTime.Text = stopWatch.Elapsed.ToString("s\\.ff") + " s";
            tsRow.Text = dgvPreInput.Rows.Count.ToString();
            tsTotalQty.Text = total.ToString();
            this.Cursor = Cursors.Default;
        }

        private void rbtnEven_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEven.Checked) dgvPreInput.MultiSelect = true;
            if (rbtnOdd.Checked) dgvPreInput.MultiSelect = false;
        }
        #endregion

        #region PRINT TAB
        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            try
            {
                if (printItem.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    MessageBox.Show("Printer is offline", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                listPrintItem.Clear();
                if (dgvPrintList.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Please choose item first!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                foreach (DataGridViewRow dr in dgvPrintList.SelectedRows)
                {
                    listPrintItem.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.Lime;
                }
                if (printItem.PrintItems(listPrintItem, false))
                    MessageBox.Show("Print items are completed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (printItem.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    MessageBox.Show("Printer is offline", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                listPrintItem.Clear();
                if (dgvPrintList.Rows.Count == 0)
                {
                    MessageBox.Show("Don't have item to print!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (DataGridViewRow dr in dgvPrintList.Rows)
                {
                    listPrintItem.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.Lime;
                }
                if (printItem.PrintItems(listPrintItem, false))
                    MessageBox.Show("Print items are completed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManualPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (printItem.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    MessageBox.Show("Printer is offline", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                listPrintItem.Clear();
                if (dgvPrintList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please choose item first!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                foreach (DataGridViewRow dr in dgvPrintList.SelectedRows)
                {
                    listPrintItem.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (printItem.PrintItems(listPrintItem, true))
                    MessageBox.Show("Print items are completed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintClear_Click(object sender, EventArgs e)
        {
            listPrintItem.Clear();
            printItem.ListPrintItem.Clear();
            dgvPrintList.DataSource = null;
        }

        private void btnPrintBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region INSPECTION TAB
        #region BUTTONS EVENT
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddNewItem();
            txtBarcode.Clear();
            txtBarcode.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure register this list?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            for (int i = 0; i < dgvInspection.Rows.Count; i++)
            {
                //Register item into stock
                try
                {
                    if (stockItem.AddItem(dgvInspection.Rows[i].DataBoundItem as pts_stock) > 0)
                    {
                        listStockItem.Remove(dgvInspection.Rows[i].DataBoundItem as pts_stock);
                        i--;
                    }
                }
                catch (Exception ex)
                {
                    //If item already exists, skip it and set color it to red.
                    string errorNo = ex.Message.Split(':')[0];
                    switch (errorNo)
                    {
                        case "23505":
                            MessageBox.Show("This package already exists." + Environment.NewLine + "Please check and try again!",
                                "Error - " + errorNo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "23503":
                            MessageBox.Show("This Item Number is not exist in database!" + Environment.NewLine
                                + "Please check and try again!", "Error - " + errorNo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show(ex.Message, "Error - " + errorNo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    dgvInspection.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    continue;
                }
            }
            itemData.UpdateStockValue();
            UpdateInspectionGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell dc in dgvInspection.SelectedCells)
                {
                    if (MessageBox.Show("Are you sure delete this item?", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        listStockItem.Remove(dgvInspection.Rows[dc.RowIndex].DataBoundItem as pts_stock);
                }
                dgvInspection.DataSource = listStockItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateInspectionGrid();
            txtBarcode.Focus();
        }

        private void btnInspectionClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This list is not register. Are you sure to clear all?", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            txtBarcode.Clear();
            txtSupplierCD.Clear();
            listStockItem.Clear();
            dgvInspection.DataSource = null;
            txtSupplierName.Text = "Supplier Name";
            errorProvider.SetError(txtSupplierCD, null);
            txtBarcode.Focus();
        }
        #endregion

        #region FIELDS EVENT
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNewItem();
                txtBarcode.Clear();
                txtBarcode.Focus();
            }
        }

        private void txtSupplierCD_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Press F2 for add new supplier
                if (e.KeyCode == Keys.F2)
                {
                    supplierItem.AddSupplier(new pts_supplier
                    {
                        supplier_cd = txtSupplierCD.Text,
                        supplier_name = txtSupplierName.Text,
                        registration_user_cd = UserData.usercode,
                    });
                    MessageBox.Show("New supplier has been added with supplier code : " + txtSupplierCD.Text, "Noitice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider.SetError(txtSupplierCD, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tab_Inspection_Paint(object sender, PaintEventArgs e)
        {
            txtBarcode.Focus();
        }
        #endregion

        #region SUB EVENT
        /// <summary>
        /// Update datagridview
        /// </summary>
        private void UpdateInspectionGrid()
        {
            dgvInspection.DataSource = listStockItem;
            dgvInspection.Columns["stock_id"].HeaderText = "Stock ID";
            dgvInspection.Columns["packing_cd"].HeaderText = "Packing Code";
            dgvInspection.Columns["item_cd"].HeaderText = "Item Code";
            dgvInspection.Columns["supplier_cd"].HeaderText = "Supplier Code";
            dgvInspection.Columns["order_no"].HeaderText = "Order Number";
            dgvInspection.Columns["invoice"].HeaderText = "Invoice";
            dgvInspection.Columns["po_no"].HeaderText = "PO";
            dgvInspection.Columns["stockin_date"].HeaderText = "Stock In Date";
            dgvInspection.Columns["stockin_user_cd"].HeaderText = "Incharge";
            dgvInspection.Columns["stockin_qty"].HeaderText = "Stock In Qty";
            dgvInspection.Columns["packing_qty"].HeaderText = "Packing Qty";
            dgvInspection.Columns["registration_user_cd"].HeaderText = "Reg User";
            dgvInspection.Columns["registration_date_time"].HeaderText = "Reg Date";
            double total = listStockItem.Sum(x => x.stockin_qty);
            tsRow.Text = dgvInspection.Rows.Count.ToString();
            tsTotalQty.Text = total.ToString();
        }

        /// <summary>
        /// Add new stock item into temp list
        /// </summary>
        private void AddNewItem()
        {
            try
            {
                int n = 1;
                int temp = 0;
                txtSupplierCD.Clear();
                txtSupplierName.Clear();
                string[] barcode = txtBarcode.Text.Split(';');
                string orderno = "None";
                string suppliercd = string.Empty;
                if (barcode.Length > 6)
                {
                    if (!string.IsNullOrEmpty(barcode[8])) orderno = barcode[7];
                    if (!string.IsNullOrEmpty(barcode[6])) suppliercd = barcode[6];
                }
                #region CHECK SUPPLIER & NOTICE FOR USER
                errorProvider.SetError(txtSupplierCD, null);
                txtSupplierName.Text = barcode[2];
                try
                {
                    if (string.IsNullOrEmpty(suppliercd))
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
                        txtSupplierCD.Text = suppliercd;
                        supplierItem = supplierItem.GetSupplier(new pts_supplier
                        {
                            supplier_id = 0,
                            supplier_cd = txtSupplierCD.Text
                        });
                    }
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtSupplierCD, "This supplier is not exist!" + Environment.NewLine + "Please fill supplier code and press F2 for add new supplier (" + ex.Message + ")");
                    return;
                }
                #endregion

                #region CHECK INVOICE AND CREATE PACKING CODE
                try
                {
                    if (stockItem.SearchItem(new pts_stock { invoice = barcode[3], item_cd = barcode[0] }, DateTime.Now, DateTime.Now, false))
                    {
                        double total = stockItem.SumStockQty(new pts_stock { invoice = barcode[3] }, DateTime.Now, DateTime.Now, false, true);
                        if (MessageBox.Show("This Invoice of " + barcode[0] + " is exist! Stock-In numberOfLot in database: " + total + Environment.NewLine + "Are you sure add new packing with this Invoice?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }
                //Get max number packing of this Invoice in database
                foreach (pts_stock item in stockItem.listStockItems)
                {
                    if (item.invoice == barcode[3])
                    {
                        temp = int.Parse(item.packing_cd.Split('-')[1]);
                        if (temp == n) n++;
                    }
                }
                //Create new number of packing with Invoice number
                foreach (pts_stock item in listStockItem)
                {
                    if (item.invoice == barcode[3])
                    {
                        temp = int.Parse(item.packing_cd.Split('-')[1]);
                        if (temp == n) n++;
                    }
                }
                string packingcd = barcode[3] + "-" + n.ToString("00");
                #endregion

                //Add new barcode item into list stock item
                listStockItem.Add(new pts_stock
                {
                    item_cd = barcode[0],
                    supplier_cd = txtSupplierCD.Text,
                    invoice = barcode[3],
                    stockin_date = DateTime.Parse(barcode[4]),
                    stockin_qty = double.Parse(barcode[5]),
                    stockin_user_cd = UserData.usercode,
                    order_no = orderno,
                    packing_cd = packingcd,
                    packing_qty = double.Parse(barcode[5]),
                    registration_user_cd = UserData.usercode,
                });
                UpdateInspectionGrid();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Wrong format barcode!" + Environment.NewLine + "Please check barcode and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion
    }
}
