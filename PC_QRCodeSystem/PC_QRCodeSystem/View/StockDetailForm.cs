using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockDetailForm : FormCommon
    {
        GetData gdata = new GetData();
        PCStockItem PCitem = new PCStockItem();
        BindingList<PCStockItem> PCItems = new BindingList<PCStockItem>();

        public StockDetailForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Search data stock items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PCitem = new PCStockItem
            {
                Packing_Code = txtPackingCD.Text,
                Item_Number = txtItemCD.Text,
                Item_Name = txtItemName.Text,
                Supplier_Name = txtSupplier.Text,
                Supplier_Invoice = txtInvoice.Text,
                PO_No = txtPONo.Text,
                Incharge = txtIncharge.Text
            };
            if (dtpFromDate.Checked)
            {
                PCitem.CheckDateFrom = true;
                PCitem.FromDate = dtpFromDate.Value;
            }
            if (dtpToDate.Checked)
            {
                PCitem.CheckDateTo = true;
                PCitem.ToDate = dtpToDate.Value;
            }
            PCItems = new BindingList<PCStockItem>(gdata.GetPCStockItems(PCitem));
        }
    }
}
