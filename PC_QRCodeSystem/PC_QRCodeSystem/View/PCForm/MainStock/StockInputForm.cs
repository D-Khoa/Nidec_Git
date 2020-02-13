using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockInputForm : FormCommon
    {
        #region ITEMS
        pts_item itemUnit { get; set; }
        PremacIn premacItem { get; set; }
        PrintItem printItem { get; set; }
        pts_stock stockItem { get; set; }
        pts_supplier supplierItem { get; set; }
        List<PrintItem> listPrintItem { get; set; }
        BindingList<pts_stock> listStockItem { get; set; }
        #endregion

        #region SETTING
        int n = 1;
        string settingpath, premacPath, printername;
        List<string> allsetting = new List<string>();
        #region PRINTER
        //Class TfPrint is library of printer
        TfPrint tfprinter = new TfPrint();
        //List all printer name
        List<string> listprintername =
            System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().ToList();
        #endregion
        #endregion

        public StockInputForm()
        {
            InitializeComponent();
            itemUnit = new pts_item();
            printItem = new PrintItem();
            premacItem = new PremacIn();
            stockItem = new pts_stock();
            supplierItem = new pts_supplier();
            listPrintItem = new List<PrintItem>();
            listStockItem = new BindingList<pts_stock>();
            tc_Main.ItemSize = new Size(0, 1);
            tc_Main.SelectedTab = tab_Main;
            settingpath = @"setting.ini";
            //Get list printer name into combobox printer
            cmbPrinter.DataSource = listprintername;
            cmbPrinter.Text = null;
        }

        private void StockInputForm_Load(object sender, EventArgs e)
        {
            #region LOAD SETTING.INI
            foreach (string line in File.ReadLines(settingpath))
            {
                if (line.Contains("premac file ="))
                    premacPath = line.Split('=')[1];
                if (line.Contains("printer name ="))
                    printername = line.Split('=')[1];
            }
            txtPremacFolder.Text = premacPath;
            cmbPrinter.Text = printername;
            #endregion
        }

        #region MAIN TAB
        private void btnPremacImport_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = Path.GetDirectoryName(premacPath) + @"\Temp\";
                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
                premacItem.GetListPremacItem(premacPath);
                dgvPreInput.DataSource = premacItem.listPremacItem;
                File.Move(premacPath, temp + Path.GetFileName(premacPath));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAutoPacking_Click(object sender, EventArgs e)
        {
            try
            {
                int qty = 1;
                double unit = 1;
                double qtymod = 0;
                foreach (DataGridViewRow dr in dgvPreInput.Rows)
                {
                    try
                    {
                        itemUnit = itemUnit.GetItem(dr.Cells["Item_Number"].Value.ToString());
                    }
                    catch
                    {
                        continue;
                    }
                    unit = itemUnit.lot_size;
                    if (unit == 0) unit = (double)dr.Cells["Delivery_Qty"].Value;
                    qty = (int)((double)dr.Cells["Delivery_Qty"].Value / unit);
                    printItem.ListPrintItem.Add(new PrintItem
                    {
                        Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                        Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                        SupplierCD = dr.Cells["Supplier_Code"].Value.ToString(),
                        SupplierName = dr.Cells["Supplier_Name"].Value.ToString(),
                        Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                        Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                        Delivery_Qty = unit,
                        PONo = dr.Cells["PO_No"].Value.ToString(),
                        OrderNo = dr.Cells["Order_No"].Value.ToString(),
                        Label_Qty = qty
                    });
                    if (unit * qty < (double)dr.Cells["Delivery_Qty"].Value)
                    {
                        qtymod = (double)dr.Cells["Delivery_Qty"].Value - (unit * qty);
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                            Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                            SupplierCD = dr.Cells["Supplier_Code"].Value.ToString(),
                            SupplierName = dr.Cells["Supplier_Name"].Value.ToString(),
                            Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                            Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                            Delivery_Qty = qtymod,
                            PONo = dr.Cells["PO_No"].Value.ToString(),
                            OrderNo = dr.Cells["Order_No"].Value.ToString(),
                            Label_Qty = 1
                        });
                    }
                    dr.DefaultCellStyle.BackColor = Color.Blue;
                }
                dgvPacking.DataSource = printItem.ListPrintItem;
                tc_Main.SelectedTab = tab_Print;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManualPacking_Click(object sender, EventArgs e)
        {
            try
            {
                int qty = 1;
                double unit = 1;
                double qtymod = 0;
                foreach (DataGridViewRow dr in dgvPreInput.SelectedRows)
                {
                    unit = double.Parse(txtCapaciy.Text);
                    if (unit == 0) unit = (double)dr.Cells["Delivery_Qty"].Value;
                    qty = (int)((double)dr.Cells["Delivery_Qty"].Value / unit);
                    printItem.ListPrintItem.Add(new PrintItem
                    {
                        Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                        Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                        SupplierCD = dr.Cells["Supplier_Code"].Value.ToString(),
                        SupplierName = dr.Cells["Supplier_Name"].Value.ToString(),
                        Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                        Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                        Delivery_Qty = unit,
                        PONo = dr.Cells["PO_No"].Value.ToString(),
                        OrderNo = dr.Cells["Order_No"].Value.ToString(),
                        Label_Qty = qty
                    });
                    if (unit * qty < (double)dr.Cells["Delivery_Qty"].Value)
                    {
                        qtymod = (double)dr.Cells["Delivery_Qty"].Value - (unit * qty);
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                            Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                            SupplierCD = dr.Cells["Supplier_Code"].Value.ToString(),
                            SupplierName = dr.Cells["Supplier_Name"].Value.ToString(),
                            Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                            Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                            Delivery_Qty = qtymod,
                            PONo = dr.Cells["PO_No"].Value.ToString(),
                            OrderNo = dr.Cells["Order_No"].Value.ToString(),
                            Label_Qty = 1
                        });
                    }
                    dr.DefaultCellStyle.BackColor = Color.Blue;
                }
                dgvPacking.DataSource = printItem.ListPrintItem;
                tc_Main.SelectedTab = tab_Print;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            tc_Main.SelectedTab = tab_Setting;
        }

        private void btnMainClear_Click(object sender, EventArgs e)
        {
            txtCapaciy.Clear();
            dgvPreInput.DataSource = null;
        }
        #endregion

        #region SETTING TAB
        private void cmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            printername = cmbPrinter.Text;
        }

        private void btnBrowserPremac_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Premac file text (*.txt)|*.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                txtPremacFolder.Text = of.FileName;
            }
        }

        private void btnPrinterCheck_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(printername))
            {
                if (!CheckPrinterIsOffline(printername))
                {
                    lbPrinterStatus.Text = "Online";
                    lbPrinterStatus.BackColor = Color.Green;
                }
                else
                {
                    lbPrinterStatus.Text = "Offline";
                    lbPrinterStatus.BackColor = Color.Red;
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            premacPath = txtPremacFolder.Text;
            printername = cmbPrinter.Text;
            allsetting.Add("premac file =" + premacPath);
            allsetting.Add("printer name =" + printername);
            if (!File.Exists(settingpath))
            {
                FileStream myfile = File.Create(settingpath);
                myfile.Close();
            }
            File.WriteAllLines(settingpath, allsetting);
            tc_Main.SelectedTab = tab_Main;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region PRINT TAB
        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckPrinterIsOffline(cmbPrinter.Text))
                {
                    MessageBox.Show("Printer is offline", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                listPrintItem.Clear();
                if (dgvPacking.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please choose item first!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                foreach (DataGridViewRow dr in dgvPacking.SelectedRows)
                {
                    listPrintItem.Add(dr.DataBoundItem as PrintItem);
                }
                if (PrintItems(listPrintItem, false))
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
                if (CheckPrinterIsOffline(cmbPrinter.Text))
                {
                    MessageBox.Show("Printer is offline", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                listPrintItem.Clear();
                if (dgvPacking.Rows.Count == 0)
                {
                    MessageBox.Show("Don't have item to print!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (DataGridViewRow dr in dgvPacking.Rows)
                {
                    listPrintItem.Add(dr.DataBoundItem as PrintItem);
                }
                if (PrintItems(listPrintItem, false))
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
                if (CheckPrinterIsOffline(cmbPrinter.Text))
                {
                    MessageBox.Show("Printer is offline", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                listPrintItem.Clear();
                if (dgvPacking.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please choose item first!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                foreach (DataGridViewRow dr in dgvPacking.SelectedRows)
                {
                    listPrintItem.Add(dr.DataBoundItem as PrintItem);
                }
                if (PrintItems(listPrintItem, true))
                    MessageBox.Show("Print items are completed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region PRINTER
        /// <summary>
        /// Check status of printer
        /// </summary>
        /// <param name="printer">Printer name</param>
        /// <returns>TRUE: OFFLINE, FALSE: ONLINE</returns>
        private bool CheckPrinterIsOffline(string printer)
        {
            ManagementObjectSearcher printerSearch = new ManagementObjectSearcher("Select Name, WorkOffline from Win32_Printer");
            foreach (ManagementBaseObject searchprint in printerSearch.Get())
            {
                if (searchprint["Name"].ToString() == printer)
                {
                    return (Boolean)searchprint["WorkOffline"];
                }
            }
            throw new Exception("Printer is not install");
        }

        /// <summary>
        /// Print pc stock items
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="printOneCoppy">true: print 1 label</param>
        /// <returns></returns>
        public bool PrintItems(List<PrintItem> Items, bool printOneCoppy)
        {
            TfPrint.printerName = printername;
            for (int i = 0; i < Items.Count; i++)
            {
                if (printOneCoppy)
                {
                    TfPrint.printBarCodeNew(Items[i].Item_Number, Items[i].Item_Name, Items[i].SupplierName, Items[i].Invoice,
                         Items[i].Delivery_Date.ToString("yyyy/MM/dd"), Items[i].Delivery_Qty.ToString(), Items[i].SupplierCD,
                         Items[i].PONo, Items[i].OrderNo);
                }
                else
                {
                    for (int j = 0; j < Items[i].Label_Qty; j++)
                    {
                        TfPrint.printBarCodeNew(Items[i].Item_Number, Items[i].Item_Name, Items[i].SupplierName, Items[i].Invoice,
                            Items[i].Delivery_Date.ToString("yyyy/MM/dd"), Items[i].Delivery_Qty.ToString(), Items[i].SupplierCD,
                            Items[i].PONo, Items[i].OrderNo);
                    }
                }
            }
            return true;
        }
        #endregion

        #region INSPECTION TAB
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
            tsLabelNumber.Text = dgvInspection.Rows.Count.ToString();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int temp = 0;
                    string[] barcode = txtBarcode.Text.Split(';');
                    txtSupplierCD.Text = barcode[6];
                    txtSupplierName.Text = barcode[2];
                    foreach (pts_stock item in listStockItem)
                    {
                        if (item.po_no == barcode[7])
                        {
                            temp = int.Parse(item.packing_cd.Split('-')[1]);
                            if (temp == n)
                                n++;
                        }
                    }
                    listStockItem.Add(new pts_stock
                    {
                        item_cd = barcode[0],
                        supplier_cd = barcode[6],
                        invoice = barcode[3],
                        stockin_date = DateTime.Parse(barcode[4]),
                        stockin_qty = double.Parse(barcode[5]),
                        stockin_user_cd = UserData.usercode,
                        po_no = barcode[7],
                        order_no = barcode[8],
                        packing_cd = barcode[7] + "-" + n.ToString("00"),
                        packing_qty = double.Parse(barcode[5]),
                        registration_user_cd = UserData.usercode,
                    });
                    UpdateInspectionGrid();
                    n = 1;
                }
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvInspection.Rows.Count; i++)
            {
                //Check supplier exist.
                try
                {
                    supplierItem.GetSupplierName(dgvInspection.Rows[i].Cells["supplier_cd"].Value.ToString());
                }
                catch
                {
                    //If supplier not exist, add new supplier
                    supplierItem.AddSupplier(new pts_supplier
                    {
                        supplier_cd = txtBarcode.Text.Split(';')[6],
                        supplier_name = txtBarcode.Text.Split(';')[2],
                        registration_user_cd = UserData.usercode,
                    });
                }
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
            UpdateInspectionGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell dc in dgvInspection.SelectedCells)
                {
                    listStockItem.Remove(dgvInspection.Rows[dc.RowIndex].DataBoundItem as pts_stock);
                }
                dgvInspection.DataSource = listStockItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInspectionClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Clear();
            txtSupplierCD.Clear();
            txtSupplierName.Clear();
            dgvInspection.DataSource = null;
        }
        #endregion
    }
}
