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
    public partial class StockOutLogForm : FormCommon
    {
        #region VARIABLE
        private pts_item itemData { get; set; }
        private m_mes_user userData { get; set; }
        private pts_stock stockData { get; set; }
        private pts_destination desCode { get; set; }
        private pts_issue_code issueCode { get; set; }
        private pts_stockout_log stockoutData { get; set; }
        private ErrorProvider errorProvider = new ErrorProvider();
        #endregion

        #region FORM EVENT
        public StockOutLogForm()
        {
            InitializeComponent();
            itemData = new pts_item();
            userData = new m_mes_user();
            stockData = new pts_stock();
            desCode = new pts_destination();
            issueCode = new pts_issue_code();
            stockoutData = new pts_stockout_log();
        }

        private void StockOutLogForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region SUB EVENT
        /// <summary>
        /// Get list issue code, destination into combobox
        /// </summary>
        private void GetCmb()
        {
            try
            {
                //Get list issue code
                issueCode.GetListIssueCode();
                cmbIssueCD.DataSource = issueCode.listIssueCode;
                cmbIssueCD.DisplayMember = "issue_name";
                cmbIssueCD.ValueMember = "issue_cd";
                cmbIssueCD.Text = null;
                //Get list destination code
                desCode.GetListDestination(string.Empty, string.Empty);
                cmbDestination.DataSource = desCode.listdestination;
                cmbDestination.DisplayMember = "destination_name";
                cmbDestination.ValueMember = "destination_cd";
                cmbDestination.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateGrid(bool isSearch)
        {
            if(isSearch)
            {
                stockData.SearchItem(new pts_stock { item_cd = txtItemCD.Text, invoice = txtInvoice.Text });
                stockoutData.Search(new pts_stockout_log
                {

                });
            }
        }
        #endregion

        #region FIELDS EVENT
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] barcode = txtBarcode.Text.Split(';');
                txtItemCD.Text = barcode[0];
                txtInvoice.Text = barcode[3];
                dtpFromDate.Value = DateTime.Parse(barcode[4]);
                dtpToDate.Value = DateTime.Parse(barcode[4]);
            }
        }

        private void cmbIssueCD_Format(object sender, ListControlConvertEventArgs e)
        {
            string code = ((pts_issue_code)e.ListItem).issue_cd.ToString();
            string iname = ((pts_issue_code)e.ListItem).issue_name;
            e.Value = code + ": " + iname;
        }

        private void cmbDestination_Format(object sender, ListControlConvertEventArgs e)
        {
            string code = ((pts_destination)e.ListItem).destination_cd;
            string iname = ((pts_destination)e.ListItem).destination_name;
            e.Value = code + ": " + iname;
        }

        private void cmbIssueCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbIssueCD.Text))
                errorProvider.SetError(cmbIssueCD, null);
        }

        private void cmbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDestination.Text))
                errorProvider.SetError(cmbDestination, null);
        }

        private void txtItemCD_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtItemCD, null);
            lbItemName.Text = "Item Name";
            lbItemName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if (!string.IsNullOrEmpty(txtItemCD.Text))
            {
                try
                {
                    lbItemName.Text = itemData.GetItem(txtItemCD.Text).item_name;
                    lbItemName.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtItemCD, "Wrong Item Code" +
                                           Environment.NewLine + ex.Message);
                }
            }
        }

        private void txtUserCD_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtUserCD, null);
            lbUserName.Text = "User Name";
            lbUserName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if (!string.IsNullOrEmpty(txtUserCD.Text))
            {
                try
                {
                    lbUserName.Text = userData.GetUser(txtUserCD.Text).user_name;
                    lbUserName.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtUserCD, "Wrong User Code" +
                                           Environment.NewLine + ex.Message);
                }
            }
        }
        #endregion

        #region BUTTONS EVENT
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
