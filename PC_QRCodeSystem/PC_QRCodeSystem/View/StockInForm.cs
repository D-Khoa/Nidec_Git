using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockInForm : FormCommon
    {
        string premacpath;
        GetData getData = new GetData();
        TfPrint tfprinter = new TfPrint();
        PremacIn preitem = new PremacIn();
        StockInItem stockitem = new StockInItem();
        List<PremacIn> preitems = new List<PremacIn>();
        List<StockInItem> stockitems = new List<StockInItem>();
        List<StockInItem> printeditems = new List<StockInItem>();

        public StockInForm()
        {
            InitializeComponent();
            grt_StockIn.ItemSize = new Size(0, 1);
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {
            grt_StockIn.SelectedTab = tab_StockIn;
        }

        /// <summary>
        /// Add item from premac file into list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPremacItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(premacpath))
                {
                    MessageBox.Show("Please choose folder contains premac file!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                preitems = preitem.GetItemFromPremacFile(premacpath);
                dgvStockIn.DataSource = preitems;
                tsRows.Text = preitems.Count.ToString();
                btnAutoPacking.Enabled = true;
                btnManualPacking.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {

        }

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
            dgvStockIn.Columns.Remove("Packing_ID");
            tsRows.Text = stockitems.Count.ToString();
        }

        private void btnManualPacking_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            grt_StockIn.SelectedTab = tab_Setting;
        }

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
        /// Apply setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettingApply_Click(object sender, EventArgs e)
        {
            premacpath = txtPremacURL.Text;
            grt_StockIn.SelectedTab = tab_StockIn;
        }

        /// <summary>
        /// Add list item into database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (printeditems.Count > 0)
            {
                if (getData.InputStock(printeditems))
                    MessageBox.Show("Register complete!!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Register incomplete!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
        }

        private void dgvStockIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
