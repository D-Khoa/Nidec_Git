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
            rbtnNonPlan.Checked = true;
        }
        #endregion

        #region BUTTONS EVENT

        #endregion

        #region FIELDS EVENT
        private void GetCmb()
        {
            try
            {
                issueCode.GetListIssueCode();
                cmbIssueStockOut.DataSource = issueCode.listIssueCode;
                cmbIssueStockOut.DisplayMember = "issue_cd";
                cmbIssueStockOut.ValueMember = "issue_name";
                cmbIssueStockOut.Text = null;
                destinationData.GetListDestination(string.Empty, string.Empty);
                cmbDestinationStockOut.DataSource = destinationData.listdestination;
                cmbDestinationStockOut.DisplayMember = "destination_cd";
                cmbDestinationStockOut.ValueMember = "destination_name";
                cmbDestinationStockOut.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbIssueStockOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbIssueStockOut.Text))
            {
                lbIssueStockOut.Text = cmbIssueStockOut.SelectedValue.ToString();
                lbIssueStockOut.BackColor = Color.Lime;
            }
            else
            {
                lbIssueStockOut.Text = "Issue Name";
                lbIssueStockOut.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        private void cmbDestinationStockOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDestinationStockOut.Text))
            {
                lbDestinationStockOut.Text = cmbDestinationStockOut.SelectedValue.ToString();
                lbDestinationStockOut.BackColor = Color.Lime;
            }
            else
            {
                lbDestinationStockOut.Text = "Destination Name";
                lbDestinationStockOut.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        private void txtItemCDStockOut_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtItemCDStockOut, null);
            lbItemStockOut.Text = "Item Name";
            lbItemStockOut.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if (!string.IsNullOrEmpty(txtItemCDStockOut.Text))
            {
                try
                {
                    lbItemStockOut.Text = itemData.GetItem(txtItemCDStockOut.Text).item_name;
                    lbItemStockOut.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtItemCDStockOut, "Wrong Item Code" +
                                           Environment.NewLine + ex.Message);
                }
            }
        }

        private void txtStockOutUser_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtStockOutUser, null);
            lbStockOutUser.Text = "User Name";
            lbStockOutUser.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if (!string.IsNullOrEmpty(txtStockOutUser.Text))
            {
                try
                {
                    lbStockOutUser.Text = mUserData.GetUser(txtStockOutUser.Text).user_name;
                    lbStockOutUser.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtStockOutUser, "Wrong Item Code" +
                                           Environment.NewLine + ex.Message);
                }
            }
        }

        private void rbtnNonPlan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNonPlan.Checked)
            {
                planMode = false;
                noPlanMode = true;
                requestMode = false;
                cmbDestinationStockOut.Enabled = true;
            }
            if (rbtnPlanned.Checked)
            {
                planMode = true;
                noPlanMode = false;
                requestMode = false;
                cmbDestinationStockOut.Enabled = false;
            }
            if (rbtnRequest.Checked)
            {
                planMode = false;
                noPlanMode = false;
                requestMode = true;
                cmbDestinationStockOut.Enabled = false;
            }
        }
        #endregion
    }
}
