using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockDetailForm : FormCommon
    {
        #region VARIABLE
        private pts_item itemData { get; set; }
        private pts_stock stockData { get; set; }
        private m_mes_user userData { get; set; }
        private pts_item_type typeData { get; set; }
        private pts_supplier supplierData { get; set; }
        private ErrorProvider errprovider = new ErrorProvider();
        private string[] barcode;
        #endregion

        public StockDetailForm()
        {
            InitializeComponent();
            itemData = new pts_item();
            stockData = new pts_stock();
            userData = new m_mes_user();
            typeData = new pts_item_type();
            supplierData = new pts_supplier();
            grt_StockDetail.ItemSize = new Size(0, 1);
        }

        private void StockDetailForm_Load(object sender, EventArgs e)
        {
            ClearFields();
            txtItemCD.Focus();
            grt_StockDetail.SelectedTab = tab_StockDetail;
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

        private void txtItemCD_TextChanged(object sender, EventArgs e)
        {
            errprovider.SetError(txtItemCD, null);
            txtItemCD.BackColor = Color.White;
            if (string.IsNullOrEmpty(txtItemCD.Text))
                return;
            try
            {
                itemData = itemData.GetItem(txtItemCD.Text);
                lbItemName.Text = itemData.item_name;
                lbItemName.BackColor = Color.Lime;
            }
            catch
            {
                errprovider.SetError(txtItemCD, "Wrong item code!");
                txtItemCD.BackColor = Color.Yellow;
                lbItemName.Text = "Item Name";
                lbItemName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        private void txtSupplierCD_TextChanged(object sender, EventArgs e)
        {
            txtSupplierCD.BackColor = Color.White;
            if (string.IsNullOrEmpty(txtSupplierCD.Text))
                return;
            try
            {
                lbSupplierName.Text = supplierData.GetSupplier(new pts_supplier
                {
                    supplier_id = 0,
                    supplier_cd = txtSupplierCD.Text
                }).supplier_name;
                lbSupplierName.BackColor = Color.Lime;
            }
            catch
            {
                txtSupplierCD.BackColor = Color.Yellow;
                lbSupplierName.Text = "Supplier Name";
                lbSupplierName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        private void txtInCharge_TextChanged(object sender, EventArgs e)
        {
            txtInCharge.BackColor = Color.White;
            if (string.IsNullOrEmpty(txtInCharge.Text))
                return;
            try
            {
                userData = userData.GetUser(txtInCharge.Text);
                lbInchagre.Text = userData.user_name;
                lbInchagre.BackColor = Color.Lime;
            }
            catch
            {
                txtInCharge.BackColor = Color.Yellow;
                lbInchagre.Text = "User Incharge";
                lbInchagre.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
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
            ClearFields();
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
            dgvItemInfo.Columns["registration_user_cd"].HeaderText = "Reg User";
            dgvItemInfo.Columns["registration_date_time"].HeaderText = "Reg Date";
            if (dgvItemInfo.Rows.Count > 0)
            {
                int t = (int)dgvItemInfo.Rows[0].Cells["type_id"].Value;
                typeData = typeData.GetItemType(4);
                lbItemTypeName.Text = typeData.type_name;
                lbItemTypeName.BackColor = Color.Lime;
            }
        }

        private void ClearFields()
        {
            txtPONo.Clear();
            txtItemCD.Clear();
            txtInvoice.Clear();
            txtOrderNo.Clear();
            txtInCharge.Clear();
            txtSupplierCD.Clear();
            itemData.listItems.Clear();
            stockData.listStockItems.Clear();
            lbInchagre.Text = "User Incharge";
            lbInchagre.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            lbItemName.Text = "Item Name";
            lbItemName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            lbItemTypeName.Text = "Item Type Name";
            lbItemTypeName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            lbSupplierName.Text = "Supplier Name";
            lbSupplierName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
        }

        private void dgvStockDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            itemData.listItems.Clear();
            itemData.listItems.Add(itemData.GetItem(dgvStockDetail.Rows[e.RowIndex].Cells["item_cd"].Value.ToString()));
            dgvItemInfo.DataSource = itemData.listItems;
            txtPONo.Text = dgvStockDetail.Rows[e.RowIndex].Cells["po_no"].Value.ToString();
            txtItemCD.Text = dgvStockDetail.Rows[e.RowIndex].Cells["item_cd"].Value.ToString();
            txtInvoice.Text = dgvStockDetail.Rows[e.RowIndex].Cells["invoice"].Value.ToString();
            txtOrderNo.Text = dgvStockDetail.Rows[e.RowIndex].Cells["order_no"].Value.ToString();
            txtSupplierCD.Text = dgvStockDetail.Rows[e.RowIndex].Cells["supplier_cd"].Value.ToString();
            txtInCharge.Text = dgvStockDetail.Rows[e.RowIndex].Cells["stockin_user_cd"].Value.ToString();
            dtpFromDate.Value = (DateTime)dgvStockDetail.Rows[e.RowIndex].Cells["stockin_date"].Value;
            dtpToDate.Value = (DateTime)dgvStockDetail.Rows[e.RowIndex].Cells["stockin_date"].Value;
            UpdateGrid();
        }
        #endregion

        #region PRINT
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog pDL = new PrintDialog();
            PrintDocument pDOC = new PrintDocument();
            pDOC.DocumentName = "Print Doc";
            pDL.Document = pDOC;
            pDL.AllowSelection = true;
            pDL.AllowSomePages = true;
            if (pDL.ShowDialog() == DialogResult.OK)
            {
                pDOC.Print();
            }
        }

        PrintClass pcla = new PrintClass(400, 600, 10, 10, 10, 10);

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            PrintDocument pDOC = new PrintDocument();
            pDOC.DocumentName = "Print Doc";
            pDOC.PrintPage += PDOC_PrintPage;
            PrintPreviewDialog ppDL = new PrintPreviewDialog();
            ppDL.Document = pDOC;
            ppDL.ShowDialog();
        }

        private void PDOC_PrintPage(object sender, PrintPageEventArgs e)
        {
            int temp = 10;
            Bitmap page = new Bitmap(dgvStockDetail.Width, dgvStockDetail.Height);
            for (int c = 0; c < dgvStockDetail.Columns.Count; c++)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(temp, 50, dgvStockDetail.Columns[c].Width, 100));
                e.Graphics.DrawString(dgvStockDetail.Columns[c].HeaderText, dgvStockDetail.Columns[c].InheritedStyle.Font, new SolidBrush(Color.Black), temp + 5, 90);
                temp += dgvStockDetail.Columns[c].Width;
            }
            e.Graphics.DrawImage(page, 0, 0);
        }
        #endregion
    }
}
