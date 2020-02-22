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
    public partial class StockOutForm : FormCommon
    {
        #region VARIABLE
        private pts_item itemData { get; set; }
        private pts_stock stockData { get; set; }
        private m_mes_user mUserData { get; set; }
        private pts_issue_code issueCode { get; set; }
        private pts_stock_log stockDataLog { get; set; }
        private pts_stockout_log stockOutData { get; set; }
        private pts_destination destinationData { get; set; }
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool noPlanMode, planMode, requestMode;
        #endregion

        #region FORM EVENT
        public StockOutForm()
        {
            InitializeComponent();
            itemData = new pts_item();
            stockData = new pts_stock();
            mUserData = new m_mes_user();
            issueCode = new pts_issue_code();
            stockDataLog = new pts_stock_log();
            stockOutData = new pts_stockout_log();
            destinationData = new pts_destination();
        }

        private void StockOutForm_Load(object sender, EventArgs e)
        {
            GetCmb();
        }
        #endregion

        #region STOCK-OUT NO PLANNED
        #region BUTTONS EVENT

        #endregion

        #region FIELDS EVENT
        private void GetCmb()
        {
            try
            {
                issueCode.GetListIssueCode();
                cmbNoPlanIssueCD.DataSource = issueCode.listIssueCode;
                cmbNoPlanIssueCD.DisplayMember = "issue_cd";
                cmbNoPlanIssueCD.ValueMember = "issue_name";
                cmbNoPlanIssueCD.Text = null;
                destinationData.GetListDestination(string.Empty, string.Empty);
                cmbNoPlanDestinationCD.DataSource = destinationData.listdestination;
                cmbNoPlanDestinationCD.DisplayMember = "destination_cd";
                cmbNoPlanDestinationCD.ValueMember = "destination_name";
                cmbNoPlanDestinationCD.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbIssueStockOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbNoPlanIssueCD.Text))
            {
                lbNoPlanIssue.Text = cmbNoPlanIssueCD.SelectedValue.ToString();
                lbNoPlanIssue.BackColor = Color.Lime;
            }
            else
            {
                lbNoPlanIssue.Text = "Issue Name";
                lbNoPlanIssue.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        private void cmbDestinationStockOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbNoPlanDestinationCD.Text))
            {
                lbNoPlanDestination.Text = cmbNoPlanDestinationCD.SelectedValue.ToString();
                lbNoPlanDestination.BackColor = Color.Lime;
            }
            else
            {
                lbNoPlanDestination.Text = "Destination Name";
                lbNoPlanDestination.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        private void txtItemCDStockOut_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtNoPlanItemCD, null);
            lbNoPlanItem.Text = "Item Name";
            lbNoPlanItem.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if (!string.IsNullOrEmpty(txtNoPlanItemCD.Text))
            {
                try
                {
                    lbNoPlanItem.Text = itemData.GetItem(txtNoPlanItemCD.Text).item_name;
                    lbNoPlanItem.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtNoPlanItemCD, "Wrong Item Code" +
                                           Environment.NewLine + ex.Message);
                }
            }
        }

        private void txtStockOutUser_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtNoPlanUserCD, null);
            lbNoPlanUser.Text = "User Name";
            lbNoPlanUser.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if (!string.IsNullOrEmpty(txtNoPlanUserCD.Text))
            {
                try
                {
                    lbNoPlanUser.Text = mUserData.GetUser(txtNoPlanUserCD.Text).user_name;
                    lbNoPlanUser.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtNoPlanUserCD, "Wrong Item Code" +
                                           Environment.NewLine + ex.Message);
                }
            }
        }

        private void txtNoPlanStockOutQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] barcode = txtBarcode.Text.Split(';');
                txtNoPlanItemCD.Text = barcode[0];
                txtNoPlanInvoice.Text = barcode[3];
                txtBarcode.Clear();
                UpdateGrid(true);
            }
        }

        private void dgvNoPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            stockData = dgvNoPlan.Rows[e.RowIndex].DataBoundItem as pts_stock;
            txtNoPlanStockOutQty.ReadOnly = false;
            txtNoPlanPackingCD.Text = stockData.packing_cd;
        }

        private void tab_NoPlan_Paint(object sender, PaintEventArgs e)
        {
            txtBarcode.Focus();
        }
        #endregion

        #region SUB EVENT
        private void UpdateGrid(bool isSearch)
        {
            if (isSearch)
            {
                if (!stockData.SearchItem(new pts_stock
                {
                    item_cd = txtNoPlanItemCD.Text,
                    invoice = txtNoPlanInvoice.Text
                }, DateTime.Now, DateTime.Now, false))
                {
                    MessageBox.Show("This item is not exist! Please check and try again!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            dgvNoPlan.DataSource = stockData.listStockItems;
            dgvNoPlan.Columns["stock_id"].HeaderText = "Stock ID";
            dgvNoPlan.Columns["packing_cd"].HeaderText = "Packing Code";
            dgvNoPlan.Columns["item_cd"].HeaderText = "Item Code";
            dgvNoPlan.Columns["supplier_cd"].HeaderText = "Supplier Code";
            dgvNoPlan.Columns["order_no"].HeaderText = "Order Number";
            dgvNoPlan.Columns["invoice"].HeaderText = "Invoice";
            dgvNoPlan.Columns["po_no"].HeaderText = "PO";
            dgvNoPlan.Columns["stockin_date"].HeaderText = "Stock In Date";
            dgvNoPlan.Columns["stockin_user_cd"].HeaderText = "Incharge";
            dgvNoPlan.Columns["stockin_qty"].HeaderText = "Stock In Qty";
            dgvNoPlan.Columns["packing_qty"].HeaderText = "Packing Qty";
            dgvNoPlan.Columns["registration_user_cd"].HeaderText = "Reg User";
            dgvNoPlan.Columns["registration_date_time"].HeaderText = "Reg Date";
        }
        #endregion
        #endregion

    }
}
