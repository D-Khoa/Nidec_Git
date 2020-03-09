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
    public partial class StockOutputForm : FormCommon
    {
        #region VARIABLE
        ErrorProvider errorProvider = new ErrorProvider();
        #endregion

        #region FORM EVENT
        public StockOutputForm()
        {
            InitializeComponent();
        }

        private void StockOutputForm_Load(object sender, EventArgs e)
        {
            GetCmb();
        }
        #endregion

        #region TAB_MAIN
        #region FIELDS EVENT
        #region USER EVENT
        private void txtUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string temp = txtUserCode.Text;
                if (temp.Contains(";"))
                    txtUserCode.Text = temp.Split(';')[0].Trim();
                txtItemCode.Focus();
            }
        }

        private void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserCode.Text))
                {
                    lbUserName.Text = "User Name";
                    lbUserName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                else
                {
                    m_mes_user muser = new m_mes_user();
                    muser = muser.GetUser(txtUserCode.Text);
                    lbUserName.Text = muser.user_name;
                    lbUserName.BackColor = Color.Lime;
                }
                errorProvider.SetError(txtUserCode, null);
            }
            catch (Exception ex)
            {
                errorProvider.SetError(txtUserCode, "Wrong User Code" + Environment.NewLine + ex.Message);
            }
        }
        #endregion

        #region ITEM EVENT
        private void txtNoPlanItemCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string temp = txtItemCode.Text;
                if (temp.Contains(";"))
                {
                    string[] barcode = temp.Split(';');
                    txtItemCode.Text = barcode[0].Trim();
                    txtInvoice.Text = barcode[3].Trim();
                }
                cmbIssue.Focus();
            }
        }

        private void txtNoPlanItemCD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtItemCode.Text))
                {
                    lbItemName.Text = "Item Name";
                    lbItemName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                else
                {
                    pts_item itemData = new pts_item();
                    itemData = itemData.GetItem(txtItemCode.Text);
                    lbItemName.Text = itemData.item_name;
                    lbItemName.BackColor = Color.Lime;
                }
                errorProvider.SetError(txtItemCode, null);
            }
            catch (Exception ex)
            {
                errorProvider.SetError(txtItemCode, "Wrong Item Code" + Environment.NewLine + ex.Message);
            }
        }
        #endregion

        #region ISSUE EVENT
        private void cmbIssue_Format(object sender, ListControlConvertEventArgs e)
        {
            string code = ((pts_issue_code)e.ListItem).issue_cd.ToString();
            string iname = ((pts_issue_code)e.ListItem).issue_name;
            e.Value = code + ": " + iname;
        }

        private void cmbIssue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbIssue.Text)) cmbDestination.Focus();
        }
        #endregion

        #region DESTINATION EVENT
        private void cmbDestination_Format(object sender, ListControlConvertEventArgs e)
        {
            string code = ((pts_destination)e.ListItem).destination_cd;
            string iname = ((pts_destination)e.ListItem).destination_name;
            e.Value = code + ": " + iname;
        }

        private void cmbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDestination.Text)) txtStockOutQty.Focus();
        }
        #endregion

        #region QTY EVENT
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        #endregion

        #region DATAGRIDVIEW EVENT
        private void dgvMainStockOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvMainStockOut.Columns["btnOpenSet"].Index)
            {
                if (!CheckFields()) return;
                DataGridViewRow dr = dgvMainStockOut.Rows[e.RowIndex];
                GetSetOptions(dr.Cells["order_number"].Value.ToString(), (double)dr.Cells["order_qty"].Value, (DateTime)dr.Cells["order_date"].Value);
                SearchLowItem(txtItemCode.Text, (double)dr.Cells["order_qty"].Value);
                tc_StockOut.SelectedTab = tab_ItemSet;
            }
        }
        #endregion
        #endregion

        #region BUTTONS EVENT

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!CheckFields()) return;
            if (cmbIssue.SelectedValue.ToString() == "20")
                SearchSet(txtItemCode.Text);
            else SearchNoSet(txtItemCode.Text);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void btnInspection_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion

        #region SUB EVENT
        private void GetCmb()
        {
            pts_issue_code issueData = new pts_issue_code();
            issueData.GetListIssueCode();
            cmbIssue.DataSource = issueData.listIssueCode;
            cmbIssue.ValueMember = "issue_cd";
            cmbIssue.Text = null;
            pts_destination desData = new pts_destination();
            desData.GetListDestination(string.Empty, string.Empty);
            cmbDestination.DataSource = desData.listdestination;
            cmbDestination.ValueMember = "destination_cd";
            cmbDestination.Text = null;
        }

        private void Clear()
        {
            txtWHQty.Clear();
            txtInvoice.Clear();
            txtComment.Clear();
            txtUserCode.Clear();
            txtItemCode.Clear();
            txtSetNumber.Clear();
            txtStockOutQty.Clear();
            cmbIssue.Text = null;
            cmbDestination.Text = null;
            dgvMainStockOut.DataSource = null;
        }

        private bool CheckFields()
        {
            if (string.IsNullOrEmpty(txtUserCode.Text))
            {
                CustomMessageBox.Error("User code is empty");
                return false;
            }
            if (string.IsNullOrEmpty(txtItemCode.Text))
            {
                CustomMessageBox.Error("Item code is empty");
                return false;
            }
            if (string.IsNullOrEmpty(cmbIssue.Text))
            {
                CustomMessageBox.Error("Issue code is empty");
                return false;
            }
            if (string.IsNullOrEmpty(cmbDestination.Text))
            {
                CustomMessageBox.Error("Destination code is empty");
                return false;
            }
            return true;
        }

        private void SearchSet(string itemNumber)
        {
            try
            {
                pre_649_order orderData = new pre_649_order();
                orderData.Search(new pre_649_order
                {
                    item_number = itemNumber
                });
                dgvMainStockOut.DataSource = orderData.listOrderItem;
                dgvMainStockOut.Columns["item_number"].HeaderText = "Item Number";
                dgvMainStockOut.Columns["order_number"].HeaderText = "Order Number";
                dgvMainStockOut.Columns["order_qty"].HeaderText = "Order Qty";
                dgvMainStockOut.Columns["order_date"].HeaderText = "Order Date";
                dgvMainStockOut.Columns["supplier_cd"].HeaderText = "Supplier Code";
                if (!dgvMainStockOut.Columns.Contains("btnOpenSet"))
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.Name = "btnOpenSet";
                    col.HeaderText = "Open Set";
                    col.Text = "Open";
                    col.UseColumnTextForButtonValue = true;
                    dgvMainStockOut.Columns.Insert(0, col);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void SearchNoSet(string itemNumber)
        {
            try
            {

            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void SearchLowItem(string hiItem, double orderQty)
        {
            pre_223 structData = new pre_223();
            List<pre_223_view> listData = new List<pre_223_view>();
            listData = structData.Search(hiItem, orderQty);
            dgvSetData.DataSource = listData;
            dgvSetData.Columns["low_level_item"].HeaderText = "Part Number";
            dgvSetData.Columns["item_name"].HeaderText = "Part Name";
            dgvSetData.Columns["item_location"].HeaderText = "Location";
            dgvSetData.Columns["item_unit"].HeaderText = "Unit";
            dgvSetData.Columns["request_qty"].HeaderText = "Request Qty";
            dgvSetData.Columns["wh_qty"].HeaderText = "W/H Qty";
            if (!dgvSetData.Columns.Contains("stockout_qty"))
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Name = "stockout_qty";
                col.HeaderText = "Stock-Out Qty";
                col.CellTemplate = new DataGridViewTextBoxCell();
                dgvSetData.Columns.Insert(6, col);
            }
            for (int i = 0; i < dgvSetData.Rows.Count; i++)
            {
                dgvSetData.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            dgvSetData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }
        #endregion

        #endregion

        #region TAB_ITEM SET
        #region FIELDS EVENT
        private void txtSetLowItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtSetLowItem.Text.Contains(";"))
                {
                    pts_stock stockData = new pts_stock();
                    string[] barcode = txtSetLowItem.Text.Split(';');
                    txtSetLowItem.Text = barcode[0].Trim();
                    txtSetInvoice.Text = barcode[3].Trim();
                    foreach (DataGridViewRow dr in dgvSetData.Rows)
                    {
                        if (dr.Cells["low_level_item"].Value.ToString() == txtSetLowItem.Text)
                        {
                            if(!stockData.SearchItem(new pts_stock { item_cd = txtSetLowItem.Text, invoice = txtSetInvoice.Text }))
                            {
                                CustomMessageBox.Error("This item is not exist in stock!");
                                return;
                            }
                            double stockQty = stockData.listStockItems.Sum(x => x.packing_qty);
                            double orderQty = (double)dr.Cells["request_qty"].Value;
                            if (orderQty > stockQty)
                            {
                                if (CustomMessageBox.Question("Request Qty is more than Stock Qty. Are you sure continue?") == DialogResult.Yes)
                                    dr.Cells["stockout_qty"].Value = stockQty;
                            }
                            else dr.Cells["stockout_qty"].Value = orderQty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        #endregion
        #region BUTTONS EVENT

        #endregion
        #region SUB EVENT
        private void GetSetOptions(string orderNo, double orderQty, DateTime orderDate)
        {
            dtpSetOrderDate.Value = orderDate;
            txtSetOrderNum.Text = orderNo;
            txtSetOrderQty.Text = orderQty.ToString();
            txtSetUserCD.Text = txtUserCode.Text;
            txtSetHiItem.Text = txtItemCode.Text;
            txtSetDesCode.Text = cmbDestination.SelectedValue.ToString();
            lbSetUserName.Text = lbUserName.Text;
            lbSetHiItemName.Text = lbItemName.Text;
            lbSetDesName.Text = cmbDestination.Text.Split(':')[1].Trim();
        }
        #endregion

        #endregion
    }
}
