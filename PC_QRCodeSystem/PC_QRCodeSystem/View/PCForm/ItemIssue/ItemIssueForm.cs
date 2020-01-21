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
    public partial class ItemIssueForm : FormCommon
    {
        #region VARIABLE
        bool editMode { get; set; }
        pts_issue_code ptsissuecode { get; set; }
        pts_issue_code ptsissuecodecbm { get; set; }
        #endregion
        #region LOAD FORM AND CLOSE FORM
        public ItemIssueForm()
        {
            ptsissuecode = new pts_issue_code();
            ptsissuecodecbm = new pts_issue_code();
            editMode = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            InitializeComponent();
        }

        private void ItemIssueForm_Load(object sender, EventArgs e)
        {
            ptsissuecode.GetListIssueCode();
            cmbIssueCode.DataSource = ptsissuecode.listIssueCode;
            cmbIssueCode.DisplayMember = "issue_cd";
            cmbIssueCode.ValueMember = "issue_name";
            cmbIssueCode.Text = null;
        }

        private void ItemIssueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnOK.Visible)
            {
                if (MessageBox.Show("You are in processing! Are you sure exit?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        #endregion

        private void cmbIssueCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbIssueCode.Text))
                    txtIssueCode.Text = cmbIssueCode.SelectedValue.ToString();
                else
                    txtIssueCode.Text = "Issue Name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
