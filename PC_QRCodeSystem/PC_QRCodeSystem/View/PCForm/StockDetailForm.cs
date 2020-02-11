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
        private pts_item itemData { get; set; }
        private pts_stock stockData { get; set; }
        private m_mes_user userData { get; set; }
        private pts_supplier supplierData { get; set; }
        private string[] barcode;

        public StockDetailForm()
        {
            InitializeComponent();
            itemData = new pts_item();
            stockData = new pts_stock();
            userData = new m_mes_user();
            supplierData = new pts_supplier();
        }

        private void StockDetailForm_Load(object sender, EventArgs e)
        {
            grt_StockDetail.SelectedTab = tab_StockDetail;
            txtItemCD.Focus();
        }

        #region FIELDS EVENT
        //GET BARCODE DATA INTO FIELDS IN FORM
        private void txtItemCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                barcode = txtItemCD.Text.Split(';');
                //GET ITEM CODE
                txtItemCD.Text = barcode[0];
                //GET SUPPLIER CODE
                txtSupplierCD.Text = barcode[6];
                //GET INVOICE
                txtInvoice.Text = barcode[3];
                //GET DATE
                dtpFromDate.Value = DateTime.Parse(barcode[4]);
                dtpToDate.Value = DateTime.Parse(barcode[4]);
                //GET PO NUMBER
                txtPONo.Text = barcode[7];
                //GET ORDER NO
                txtOrderNo.Text = barcode[8];
            }
        }

        private void txtItemCD_Validated(object sender, EventArgs e)
        {
            itemData = itemData.GetItem(txtItemCD.Text);
            lbItemName.Text = itemData.item_name;
        }

        private void txtSupplierCD_Validated(object sender, EventArgs e)
        {
            lbSupplierName.Text = supplierData.GetSupplierName(txtSupplierCD.Text);
        }

        private void txtInCharge_Validated(object sender, EventArgs e)
        {
            userData = userData.GetUser(txtInCharge.Text);
            lbInchagre.Text = userData.user_name;
        }
        #endregion

        #region BUTTONS EVENT
        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGrid(true);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPONo.Clear();
            txtItemCD.Clear();
            txtInvoice.Clear();
            txtOrderNo.Clear();
            txtInCharge.Clear();
            txtSupplierCD.Clear();
            itemData.listItems.Clear();
            stockData.listStockItems.Clear();
        }
        #endregion

        #region SUB EVENTS
        private void UpdateGrid(bool isSearch)
        {
            if (isSearch)
            {
                stockData.SearchItem(new pts_stock
                {
                    item_cd = txtItemCD.Text,
                    supplier_cd = txtSupplierCD.Text,
                    order_no = txtOrderNo.Text,
                    invoice = txtInvoice.Text,
                    po_no = txtPONo.Text,
                    stockin_user_cd = txtInCharge.Text,
                }, dtpFromDate.Value, dtpToDate.Value, cbSearchDate.Checked);
            }
            dgvStockDetail.DataSource = stockData.listStockItems;
            dgvStockDetail.Columns["stock_id"].HeaderText = "Stock ID";
            dgvStockDetail.Columns["packing_cd"].HeaderText = "Packing Code";
            dgvStockDetail.Columns["item_cd"].HeaderText = "Item Code";
            dgvStockDetail.Columns["supplier_cd"].HeaderText = "Supplier Code";
            dgvStockDetail.Columns["order_no"].HeaderText = "Order No";
            dgvStockDetail.Columns["invoice"].HeaderText = "Invoice";
            dgvStockDetail.Columns["po_no"].HeaderText = "PO No";
            dgvStockDetail.Columns["stockin_date"].HeaderText = "Stock-In Date";
            dgvStockDetail.Columns["stockin_user_cd"].HeaderText = "Stock-In User";
            dgvStockDetail.Columns["stockin_qty"].HeaderText = "Stock-In Qty";
            dgvStockDetail.Columns["packing_qty"].HeaderText = "Packing Qty";
            dgvStockDetail.Columns["registration_user_cd"].HeaderText = "Reg User";
            dgvStockDetail.Columns["registration_date_time"].HeaderText = "Reg Date";
        }

        private void UpdateGrid()
        {
            dgvItemInfo.Columns["item_id"].HeaderText = "Item ID";
            dgvItemInfo.Columns["type_id"].HeaderText = "Type";
            dgvItemInfo.Columns["item_cd"].HeaderText = "Item Code";
            dgvItemInfo.Columns["item_name"].HeaderText = "Item Name";
            dgvItemInfo.Columns["item_location"].HeaderText = "Location";
            dgvItemInfo.Columns["item_unit"].HeaderText = "Unit";
            dgvItemInfo.Columns["lot_size"].HeaderText = "Lot Size";
            dgvItemInfo.Columns["wh_qty"].HeaderText = "WH Qty";
            dgvItemInfo.Columns["wip_qty"].HeaderText = "W.I.P Qty";
            dgvItemInfo.Columns["repair_qty"].HeaderText = "Repair Qty";
            dgvItemInfo.Columns["registration_user_cd  "].HeaderText = "Reg User";
            dgvItemInfo.Columns["registration_date_time"].HeaderText = "Reg Date";
        }

        private void dgvStockDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemData.listItems.Clear();
            itemData.listItems.Add(itemData.GetItem(dgvStockDetail.Rows[e.RowIndex].Cells["item_cd"].Value.ToString()));
            dgvItemInfo.DataSource = itemData.listItems;
            UpdateGrid();
        }
        #endregion
    }
}
