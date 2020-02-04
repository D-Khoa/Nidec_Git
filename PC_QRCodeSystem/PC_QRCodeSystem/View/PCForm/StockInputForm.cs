using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockInputForm : FormCommon
    {
        #region INPUT
        pts_item itemunit { get; set; }
        pts_stock stockitem { get; set; }
        PrintItem printItem { get; set; }
        PremacIn premacItem { get; set; }
        pts_supplier fieldSupplier { get; set; }
        #endregion

        #region SETTING
        string settingpath;
        string premacPath, printername;
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
            itemunit = new pts_item();
            stockitem = new pts_stock();
            printItem = new PrintItem();
            premacItem = new PremacIn();
            fieldSupplier = new pts_supplier();
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

        private void txtBarcode_Validated(object sender, EventArgs e)
        {
            string[] barcode = txtBarcode.Text.Split(';');
        }

        private void txtSupplierCode_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                string name = fieldSupplier.GetSupplierName(txtSupplierCode.Text);
                if (!string.IsNullOrEmpty(name))
                    txtSupplierName.Text = name;
            }
        }

        #region MAIN BUTTONS
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
                        itemunit = itemunit.GetItem(dr.Cells["Item_Number"].Value.ToString());
                    }
                    catch
                    {
                        continue;
                    }
                    unit = itemunit.unit_qty;
                    if (unit == 0) unit = (double)dr.Cells["Delivery_Qty"].Value;
                    qty = (int)((double)dr.Cells["Delivery_Qty"].Value / unit);
                    printItem.ListPrintItem.Add(new PrintItem
                    {
                        Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                        Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                        Supplier = dr.Cells["Supplier_Name"].Value.ToString(),
                        Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                        Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                        Delivery_Qty = unit,
                        Label_Qty = qty
                    });
                    if (unit * qty < (double)dr.Cells["Delivery_Qty"].Value)
                    {
                        qtymod = (double)dr.Cells["Delivery_Qty"].Value - (unit * qty);
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                            Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                            Supplier = dr.Cells["Supplier_Name"].Value.ToString(),
                            Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                            Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                            Delivery_Qty = qtymod,
                            Label_Qty = 1
                        });
                    }
                    dr.DefaultCellStyle.BackColor = Color.Blue;
                }
                dgvPacking.DataSource = printItem.ListPrintItem;
                tc_Main.SelectedTab = tab_Print;
            }
            catch(Exception ex)
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
                        Supplier = dr.Cells["Supplier_Name"].Value.ToString(),
                        Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                        Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                        Delivery_Qty = unit,
                        Label_Qty = qty
                    });
                    if (unit * qty < (double)dr.Cells["Delivery_Qty"].Value)
                    {
                        qtymod = (double)dr.Cells["Delivery_Qty"].Value - (unit * qty);
                        printItem.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = dr.Cells["Item_Number"].Value.ToString(),
                            Item_Name = dr.Cells["Item_Name"].Value.ToString(),
                            Supplier = dr.Cells["Supplier_Name"].Value.ToString(),
                            Invoice = dr.Cells["Supplier_Invoice"].Value.ToString(),
                            Delivery_Date = (DateTime)dr.Cells["Delivery_Date"].Value,
                            Delivery_Qty = qtymod,
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
        private void btnPrint_Click(object sender, EventArgs e)
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
        #endregion

        #region SETTING BUTTONS
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region PRINT TAB
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
        /// <returns></returns>
        public bool PrintItems(List<StockInItem> Items)
        {
            TfPrint.printerName = printername;
            for (int i = 0; i < Items.Count; i++)
                TfPrint.printBarCode(Items[i].Item_Number, Items[i].Item_Name, Items[i].Supplier_Name, Items[i].Supplier_Invoice, Items[i].StockIn_Date.ToString("yyyy/MM/dd"), Items[i].Delivery_Qty.ToString(), "");
            return true;
        }
        #endregion
    }
}
