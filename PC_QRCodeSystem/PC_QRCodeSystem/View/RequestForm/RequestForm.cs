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
    public partial class RequestForm : FormCommon
    {
        pts_destination descmb { get; set; }
        pts_request_log requestdata { get; set; }
        pts_item itemdata { get; set; }

        public RequestForm()
        {
            InitializeComponent();
            LockFields(true);
            itemdata = new pts_item();
            descmb = new pts_destination();
            requestdata = new pts_request_log();
        }

        #region FIELD EVENT
        private void RequestForm_Load(object sender, EventArgs e)
        {
            getCmbData();
        }

        /// <summary>
        /// Get list destination code
        /// </summary>
        private void getCmbData()
        {
            descmb.GetListDestination(string.Empty, UserData.dept);
            cmbDestination.DataSource = descmb.listDepartment;
            cmbDestination.DisplayMember = "destination_cd";
            cmbDestination.ValueMember = "destination_name";
            cmbDestination.Text = null;
        }

        private void cmbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDestination.Text))
                txtDestinationName.Text = cmbDestination.ValueMember;
        }

        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItemCode.Text))
                txtItemName.Text = itemdata.GetItem(txtItemCode.Text).item_name;
        }

        private void txtModelCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtModelCode.Text))
                txtModelName.Text = itemdata.GetItem(txtModelCode.Text).item_name;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        #endregion

        #region BUTTON EVENT
        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                requestdata.Add(new pts_request_log
                {
                    item_cd = txtItemCode.Text,
                    model_cd = txtModelCode.Text,
                    destination_cd = cmbDestination.Text,
                    use_date = dtpUseDate.Value,
                    request_date = DateTime.Now,
                    request_qty = double.Parse(txtQty.Text),
                    request_usercd = UserData.usercode,
                    comment = txtComment.Text,
                });
                MessageBox.Show("Add request completed!!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LockFields(true);
            UpdateGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LockFields(true);
            UpdateGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvRequest.DataSource = null;
            cmbDestination.Text = null;
            txtModelCode.Clear();
            txtItemCode.Clear();
            txtComment.Clear();
            txtQty.Clear();
            LockFields(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region SUB EVENT
        private void UpdateGrid()
        {
            requestdata.Search(new pts_request_log
            {
                item_cd = txtItemCode.Text,
                model_cd = txtModelCode.Text,
                destination_cd = cmbDestination.Text,
            }, false, false, false);
            dgvRequest.DataSource = null;
            dgvRequest.DataSource = requestdata.listRequestItem;
            dgvRequest.Columns["request_id"].HeaderText = "Request ID";
            dgvRequest.Columns["item_cd"].HeaderText = "Item Code";
            dgvRequest.Columns["model_cd"].HeaderText = "Model";
            dgvRequest.Columns["destination_cd"].HeaderText = "Destination Code";
            dgvRequest.Columns["use_date"].HeaderText = "Use Date";
            dgvRequest.Columns["request_date"].HeaderText = "Request Date";
            dgvRequest.Columns["request_qty"].HeaderText = "Request Qty";
            dgvRequest.Columns["request_usercd"].HeaderText = "Request User";
            dgvRequest.Columns["m_confirm"].HeaderText = "Manager Confirm";
            dgvRequest.Columns["gm_confirm"].HeaderText = "GM Confirm";
            dgvRequest.Columns["available_qty"].HeaderText = "Available Qty";
            dgvRequest.Columns["approve_usercd"].HeaderText = "Approve User";
            dgvRequest.Columns["pc_m_cofirm"].HeaderText = "PC Confirm";
            dgvRequest.Columns["comment"].HeaderText = "Comment";
            dgvRequest.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
        }

        private void LockFields(bool isLock)
        {
            btnDelete.Enabled = !isLock;
            btnUpdate.Enabled = !isLock;
        }

        private void dgvRequest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            requestdata = dgvRequest.Rows[e.RowIndex].DataBoundItem as pts_request_log;
            txtItemCode.Text = requestdata.item_cd;
            txtModelCode.Text = requestdata.model_cd;
            txtComment.Text = requestdata.comment;
            txtQty.Text = requestdata.request_qty.ToString();
            cmbDestination.Text = requestdata.destination_cd;
            LockFields(false);
        }
        #endregion

    }
}
