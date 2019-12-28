using System;
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

namespace PC_QRCodeSystem.View
{
    public partial class StockInForm : FormCommon
    {
        string premacpath, printername, settingpath = @"setting.ini";
        List<string> allsetting = new List<string>();
        GetData getData = new GetData();
        TfPrint tfprinter = new TfPrint();
        PremacIn preitem = new PremacIn();
        UnitItem unititem = new UnitItem();
        StockInItem stockitem = new StockInItem();
        List<PremacIn> preitems = new List<PremacIn>();
        BindingList<UnitItem> unititems = new BindingList<UnitItem>();
        BindingList<StockInItem> stockitems = new BindingList<StockInItem>();
        BindingList<StockInItem> printeditems = new BindingList<StockInItem>();

        public StockInForm()
        {
            InitializeComponent();
            grt_StockIn.ItemSize = new Size(0, 1);
            BindingList<string> listprinter = new BindingList<string>();
            cmbPrinterName.DataSource = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().ToList();
            cmbPrinterName.Text = null;
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {
            grt_StockIn.SelectedTab = tab_StockIn;
            foreach (string line in File.ReadLines(settingpath))
            {
                if (line.Contains("premac file ="))
                    premacpath = line.Split('=')[1];
                if (line.Contains("printer name ="))
                    printername = line.Split('=')[1];
            }
            txtPremacURL.Text = premacpath;
            cmbPrinterName.Text = printername;
            pnlPacking.Visible = false;
            pnlPrinter.Visible = false;
        }

        #region TAB_STOCKIN
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

        /// <summary>
        /// Auto cut lot follow unit qty in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoPacking_Click(object sender, EventArgs e)
        {
            stockitems = stockitem.GetStockInItem(preitems);
            dgvStockIn.DataSource = stockitems;
            tsRows.Text = stockitems.Count.ToString();
        }

        /// <summary>
        /// Manual cut lot and paking item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManualPacking_Click(object sender, EventArgs e)
        {

        }

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
        /// Printer Barcode Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrinter_Click(object sender, EventArgs e)
        {
            //Move item into print list
            List<StockInItem> list_print = new List<StockInItem>();
            for (int i = 0; i < stockitems.Count; i++)
            {
                if (stockitems[i].PO_No == stockitem.PO_No)
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
                //Input item printed into database
                if (list_print.Count > 0)
                {
                    if (getData.InputStock(list_print))
                        MessageBox.Show("Print & register complete!!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Print OK but register incomplete!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Update datagrid
                dgvprinter.DataSource = printeditems;
                tsRows.Text = dgvStockIn.Rows.Count.ToString();
                tsPrinterRows.Text = dgvprinter.Rows.Count.ToString();
            }
        }

        /// <summary>
        /// Choose all packing have a same PO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStockIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            stockitem.PO_No = dgvStockIn.Rows[e.RowIndex].Cells["PO_No"].Value.ToString();
            for (int i = 0; i < dgvStockIn.Rows.Count; i++)
            {
                if (dgvStockIn.Rows[i].Cells["PO_No"].Value.ToString() == stockitem.PO_No)
                    dgvStockIn.Rows[i].Selected = true;
            }
            pnlPrinter.Visible = true;
        }

        /// <summary>
        /// Print items
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        public bool PrintItems(List<StockInItem> Items)
        {
            try
            {
                TfPrint.printerName = printername;
                for (int i = 0; i < Items.Count; i++)
                    TfPrint.printBarCode(Items[i].Item_Number, Items[i].Item_Name, Items[i].Supplier_Name, Items[i].Supplier_Invoice, Items[i].StockIn_Date.ToString("yyyy/MM/dd"), Items[i].Delivery_Qty.ToString(), "");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CAUTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region TAB_SETTING
        /// <summary>
        /// Select folder contains premac file
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
        /// Go to unit manager tab
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
        /// Show list of printed items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintedList_Click(object sender, EventArgs e)
        {
            grt_StockIn.SelectedTab = tab_printer;
        }

        /// <summary>
        /// Apply setting
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

        /// <summary>
        /// Go back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettingBack_Click(object sender, EventArgs e)
        {
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
            if (string.IsNullOrEmpty(txtItemNo.Text) || string.IsNullOrEmpty(txtItemName.Text)
                || string.IsNullOrEmpty(txtQtyUnit.Text) || string.IsNullOrEmpty(txtUnitType.Text))
            {
                MessageBox.Show("Please fill all infomations of item!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            unititem.Item_Number = txtItemNo.Text;
            unititem.Item_Name = txtItemName.Text;
            unititem.Unit_Qty = double.Parse(txtQtyUnit.Text);
            unititem.Unit_Type = txtUnitType.Text;
            if (getData.AddUnitItem(unititem))
            {
                unititems = unititem.GetAllUnitItem();
                dgvUnit.DataSource = unititems;
                MessageBox.Show("Process complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Process incomplete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dgvUnit.Refresh();
        }

        /// <summary>
        /// Update infomation an unit item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateUnitItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemNo.Text) || string.IsNullOrEmpty(txtItemName.Text)
                || string.IsNullOrEmpty(txtQtyUnit.Text) || string.IsNullOrEmpty(txtUnitType.Text))
            {
                MessageBox.Show("Please fill all infomations of item!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (getData.UpdateUnitItem(txtItemNo.Text, txtItemName.Text, txtQtyUnit.Text, txtUnitType.Text, unititem.Item_Number))
            {
                unititems = unititem.GetAllUnitItem();
                dgvUnit.DataSource = unititems;
                MessageBox.Show("Update complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Update incomplete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dgvUnit.Refresh();
        }

        /// <summary>
        /// Delete an unit item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteUnitItem_Click(object sender, EventArgs e)
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
            dgvUnit.Refresh();
        }

        /// <summary>
        /// Only allow input digital in unit qty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQtyUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            grt_StockIn.SelectedTab = tab_StockIn;
        }
        #endregion

        #region TAB_PRINTER
        private void btnPrinterBack_Click(object sender, EventArgs e)
        {
            grt_StockIn.SelectedTab = tab_StockIn;
        }
        #endregion
    }
}
