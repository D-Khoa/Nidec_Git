﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using PC_QRCodeSystem.Model;
using System.Printing;
using System.Management;

namespace PC_QRCodeSystem.View
{
    public partial class StockInForm : FormCommon
    {
        string premacpath, printername, settingpath = @"setting.ini";
        GetData getData = new GetData();
        TfPrint tfprinter = new TfPrint();
        PremacIn preitem = new PremacIn();
        UnitItem unititem = new UnitItem();
        StockInItem stockitem = new StockInItem();
        List<string> allsetting = new List<string>();
        List<PremacIn> preitems = new List<PremacIn>();
        BindingList<UnitItem> unititems = new BindingList<UnitItem>();
        BindingList<StockInItem> stockitems = new BindingList<StockInItem>();
        BindingList<StockInItem> printeditems = new BindingList<StockInItem>();
        List<string> listprintername = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().ToList();

        public StockInForm()
        {
            InitializeComponent();
            grt_StockIn.ItemSize = new Size(0, 1);
            grt_StockIn.SelectedTab = tab_StockIn;
            cmbPrinterName.DataSource = listprintername;
            cmbPrinterName.Text = null;
            pnlPacking.Visible = false;
            pnlPrinter.Visible = false;
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {
            #region LOAD SETTING.INI
            foreach (string line in File.ReadLines(settingpath))
            {
                if (line.Contains("premac file ="))
                    premacpath = line.Split('=')[1];
                if (line.Contains("printer name ="))
                    printername = line.Split('=')[1];
            }
            txtPremacURL.Text = premacpath;
            cmbPrinterName.Text = printername;
            #endregion
        }

        #region TAB_STOCKIN
        #region IMPORT ITEMS
        /// <summary>
        /// Add item from premac file into list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPremacItems_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = Path.GetDirectoryName(premacpath) + "\\temp";
                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
                if (string.IsNullOrEmpty(premacpath))
                {
                    MessageBox.Show("Please choose folder contains premac file!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                preitems = preitem.GetItemFromPremacFile(premacpath);
                File.Move(premacpath, temp + "\\" + Path.GetFileName(premacpath));
                dgvStockIn.DataSource = preitems;
                tsRows.Text = preitems.Count.ToString();
                pnlPacking.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Add list items from Excel file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportExcel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Manual add item not in Premac
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region PACKING ITEM
        /// <summary>
        /// Auto cut lot follow unit qty in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoPacking_Click(object sender, EventArgs e)
        {
            try
            {
                stockitems = stockitem.GetStockInItem(preitems);
                dgvStockIn.DataSource = stockitems;
                tsRows.Text = stockitems.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manual cut lot and paking item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManualPacking_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region PRINTER ITEM & SHOW PRINTER LIST
        /// <summary>
        /// Printer Barcode Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                //Move item into print list
                List<StockInItem> list_print = new List<StockInItem>();
                for (int i = 0; i < stockitems.Count; i++)
                {
                    if (stockitems[i].PO_No == stockitem.PO_No || stockitems[i].Packing_Code == stockitem.Packing_Code)
                    {
                        list_print.Add(stockitems[i]);
                        printeditems.Add(stockitems[i]);
                        stockitems.Remove(stockitems[i]);
                        i--;
                    }
                }
                //Print Items List
                if (PrintItems(list_print))
                {
                    //Update datagrid
                    dgvprinter.DataSource = printeditems;
                    tsRows.Text = dgvStockIn.Rows.Count.ToString();
                    tsPrinterRows.Text = dgvprinter.Rows.Count.ToString();
                    MessageBox.Show("Print items complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Show list of printed items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintedList_Click(object sender, EventArgs e)
        {
            grt_StockIn.SelectedTab = tab_printer;
            if (printeditems.Count > 0)
                btnRegisterItems.Enabled = true;
            else
                btnRegisterItems.Enabled = false;
        }
        #endregion

        #region SETTING & DATAGRIDVIEW
        /// <summary>
        /// Open Setting Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            grt_StockIn.SelectedTab = tab_Setting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStockIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStockIn.Columns.Contains("Packing_Code"))
            {
                stockitem.Packing_Code = dgvStockIn.Rows[e.RowIndex].Cells["Packing_Code"].Value.ToString();
                stockitem.PO_No = null;
            }
            pnlPrinter.Visible = true;
        }

        /// <summary>
        /// Choose all packing have a same PO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStockIn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStockIn.Columns.Contains("Packing_Code"))
            {
                stockitem.Packing_Code = null;
                stockitem.PO_No = dgvStockIn.Rows[e.RowIndex].Cells["PO_No"].Value.ToString();
                for (int i = 0; i < dgvStockIn.Rows.Count; i++)
                {
                    if (dgvStockIn.Rows[i].Cells["PO_No"].Value.ToString() == stockitem.PO_No)
                        dgvStockIn.Rows[i].Selected = true;
                }
                pnlPrinter.Visible = true;
            }
        }
        #endregion
        #endregion

        #region TAB_SETTING
        /// <summary>
        /// Show unit manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnitManager_Click(object sender, EventArgs e)
        {
            unititems = unititem.GetAllUnitItem();
            dgvUnit.DataSource = unititems;
            grt_StockIn.SelectedTab = tab_Unit;
        }

        /// <summary>
        /// Select file data PREMAC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPremacFileBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Premac file text (*.txt)|*.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                txtPremacURL.Text = of.FileName;
            }
        }

        /// <summary>
        /// Change printer name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPrinterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            printername = cmbPrinterName.Text;
        }

        /// <summary>
        /// Get status of printer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintCheck_Click(object sender, EventArgs e)
        {
            if (!CheckPrinterIsOffline(printername))
            {
                lbStatusPrinter.Text = "Online";
                lbStatusPrinter.BackColor = Color.Green;
            }
            lbStatusPrinter.Text = "Offline";
            lbStatusPrinter.BackColor = Color.Red;
        }

        /// <summary>
        /// Apply setting and save to SETTING.INI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettingApply_Click(object sender, EventArgs e)
        {
            premacpath = txtPremacURL.Text;
            printername = cmbPrinterName.Text;
            allsetting.Add("premac file =" + premacpath);
            allsetting.Add("printer name =" + printername);
            if (!File.Exists(settingpath))
            {
                FileStream myfile = File.Create(settingpath);
                myfile.Close();
            }
            File.WriteAllLines(settingpath, allsetting);
            grt_StockIn.SelectedTab = tab_StockIn;
        }
        #endregion

        #region UNIT MANAGER
        /// <summary>
        /// Add unit item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUnitItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Check empty informations
                if (string.IsNullOrEmpty(txtItemNo.Text) || string.IsNullOrEmpty(txtItemName.Text)
                    || string.IsNullOrEmpty(txtQtyUnit.Text) || string.IsNullOrEmpty(txtUnitType.Text))
                {
                    throw new Exception("Please fill all infomations of item!");
                }
                //Get data into unit item
                unititem.Item_Number = txtItemNo.Text;
                unititem.Item_Name = txtItemName.Text;
                unititem.Unit_Qty = double.Parse(txtQtyUnit.Text);
                unititem.Unit_Type = txtUnitType.Text;
                //Add unit item into database
                if (getData.AddUnitItem(unititem))
                {
                    unititems = unititem.GetAllUnitItem();
                    dgvUnit.DataSource = unititems;
                    MessageBox.Show("Process complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Process incomplete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Update infomation an unit item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateUnitItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Check empty infomations
                if (string.IsNullOrEmpty(txtItemNo.Text) || string.IsNullOrEmpty(txtItemName.Text)
                    || string.IsNullOrEmpty(txtQtyUnit.Text) || string.IsNullOrEmpty(txtUnitType.Text))
                    throw new Exception("Please fill all infomations of item!");
                //Update unit item is selected
                if (getData.UpdateUnitItem(txtItemNo.Text, txtItemName.Text, txtQtyUnit.Text, txtUnitType.Text, unititem.Item_Number))
                {
                    unititems = unititem.GetAllUnitItem();
                    dgvUnit.DataSource = unititems;
                    MessageBox.Show("Update complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Update incomplete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete an unit item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteUnitItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (getData.DeleteUnitItem(unititem.Item_Number))
                {
                    unititems = unititem.GetAllUnitItem();
                    dgvUnit.DataSource = unititems;
                    txtItemNo.Clear();
                    txtItemName.Clear();
                    txtQtyUnit.Clear();
                    txtUnitType.Clear();
                    MessageBox.Show("Delete complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Delete incomplete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Only allow input digital in unit qty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQtyUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //If key press is digit and control key then true
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Please only input number", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Select unit item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdateUnitItem.Enabled = true;
            btnDeleteUnitItem.Enabled = true;
            unititem.Item_Number = dgvUnit.Rows[e.RowIndex].Cells["Item_Number"].Value.ToString();
            unititem.Item_Name = dgvUnit.Rows[e.RowIndex].Cells["Item_Name"].Value.ToString();
            unititem.Unit_Qty = (double)dgvUnit.Rows[e.RowIndex].Cells["Unit_Qty"].Value;
            unititem.Unit_Type = dgvUnit.Rows[e.RowIndex].Cells["Unit_Type"].Value.ToString();
            txtItemNo.Text = unititem.Item_Number;
            txtItemName.Text = unititem.Item_Name;
            txtQtyUnit.Text = unititem.Unit_Qty.ToString();
            txtUnitType.Text = unititem.Unit_Type;
        }
        #endregion

        #region PRINTER & CHECK STATUS PRINTER
        /// <summary>
        /// Check status of printer
        /// </summary>
        /// <param name="printer">Printer name</param>
        /// <returns>TRUE: OFFLINE, FALSE: ONLINE</returns>
        private bool CheckPrinterIsOffline(string printer)
        {
            ManagementObjectSearcher search = new ManagementObjectSearcher("Select * from Win32_Printer");
            foreach (ManagementBaseObject searchprint in search.Get())
            {
                if (searchprint["Name"].ToString() == printer)
                {
                    return (Boolean)searchprint["WorkOffline"];
                }
                break;
            }
            return true;
        }

        /// <summary>
        /// Print pc stock items
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        public bool PrintItems(List<StockInItem> Items)
        {
            if (CheckPrinterIsOffline(printername))
            {
                throw new Exception("Printer is offline!");
            }
            TfPrint.printerName = printername;
            for (int i = 0; i < Items.Count; i++)
                TfPrint.printBarCode(Items[i].Item_Number, Items[i].Item_Name, Items[i].Supplier_Name, Items[i].Supplier_Invoice, Items[i].StockIn_Date.ToString("yyyy/MM/dd"), Items[i].Delivery_Qty.ToString(), "");
            return true;
        }

        private void btnRegisterItems_Click(object sender, EventArgs e)
        {
            try
            {
                //Input item printed into database
                int n = getData.InputStock(printeditems);
                MessageBox.Show("Register " + n + " items complete!!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary>
        /// Click back then go back main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            grt_StockIn.SelectedTab = tab_StockIn;
        }
    }
}
