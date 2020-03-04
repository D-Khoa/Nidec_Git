using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private pts_issue_code issuedata { get; set; }
        Stopwatch stopWatch = new Stopwatch();
        #endregion
        #region LOAD FORM AND CLOSE FORM
        public ItemIssueForm()

        {
            InitializeComponent();
            ptsissuecode = new pts_issue_code();
            ptsissuecodecbm = new pts_issue_code();
            issuedata = new pts_issue_code();
            editMode = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
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
        /// <summary>
        /// Change cmb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Change Commobox
        private void cmbIssueCode_TextChanged(object sender, EventArgs e)
        {
            txtIssueCode.BackColor = Color.White;
            if (string.IsNullOrEmpty(cmbIssueCode.Text))
            {
                txtIssueCode.Text = "Issue Name";
                return;
            }
            try
            {
                ptsissuecode = issuedata.GetIssueCode(int.Parse(cmbIssueCode.Text));
                txtIssueCode.Text = ptsissuecode.issue_name;
                txtIssueCode.BackColor = Color.Lime;
            }
            catch (Exception ex)
            {
                txtIssueCode.Text = "";
                txtIssueCode.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        #endregion

        #region MAIN BUTTON
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                stopWatch.Restart();
                Searcheven(true);
                stopWatch.Stop();
                tsTime.Text = stopWatch.Elapsed.ToString("s\\.ff") + " s";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
            this.Cursor = Cursors.Default;
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UnlockFields(false);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cmbIssueCode.Enabled = false;
            UnlockFields(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This action is not undo" + Environment.NewLine + "Are you sure delete this item issue?", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            int n = 0;
            n = ptsissuecode.Delete(ptsissuecode.issue_cd);
            // ClearOK();
            Getcmbdata();
            UpdateGrid();
            MessageBox.Show("Delete " + n + " Issue Code", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbIssueCode.Enabled = true;
            ClearOK();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string messstring = string.Empty;
                int n = 0;
                #region Add And Update Issue Code
                {
                    if (editMode)
                    {  //CALL FUNTION UPDATE SUPPLIER

                        n = ptsissuecode.UpdateIssueCode(new pts_issue_code
                        {

                            issue_cd = int.Parse(cmbIssueCode.Text),
                            issue_name = txtIssueCode.Text,
                            registration_user_cd = UserData.usercode
                        });
                        cmbIssueCode.Enabled = true;
                    }
                    else
                    {  //CALL FUNCTION ADD NEW SUPPLIER

                        n = ptsissuecode.AddIssueCode(new pts_issue_code
                        {
                            issue_cd = int.Parse(cmbIssueCode.Text),
                            issue_name = txtIssueCode.Text,
                            registration_user_cd = UserData.usercode
                        });
                    }

                    ptsissuecode.GetListIssueCode();
                }
                #endregion
                ClearOK();
                Getcmbdata();
                UpdateGrid();
                if (editMode) messstring = "Update ";
                else messstring = "Add ";
                MessageBox.Show(messstring + n + " Issue Code Complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LockAllNameTextbox();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // LockAllNameTextbox();
            txtIssueCode.Text = "Issue Name";
            cmbIssueCode.Text = null;
            cmbIssueCode.DropDownStyle = ComboBoxStyle.DropDown;
            cmbIssueCode.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Visible = false;
            btnOK.Visible = false;

        }
        #endregion
        #region SUB PROGRAM

        private void UpdateGrid()
        {
            ptsissuecode.GetListIssueCode();
            dgvIssueCode.DataSource = null;
            dgvIssueCode.DataSource = ptsissuecode.listIssueCode;
        }

        private void ClearOK()
        {
            try
            {
                if (dgvIssueCode.DataSource != null)
                    dgvIssueCode.DataSource = null;
                cmbIssueCode.Text = null;
                txtIssueCode.Text = "Issue Name";
                ptsissuecode.listIssueCode.Clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }

        }

        private void Getcmbdata()
        {
            ptsissuecodecbm.GetListIssueCode();
            cmbIssueCode.DataSource = ptsissuecodecbm.listIssueCode;
            cmbIssueCode.DisplayMember = "issue_cd";
            cmbIssueCode.ValueMember = "issue_name";
            cmbIssueCode.Text = null;
        }
        /// <summary>
        /// Search even datagridview
        /// </summary>
        private void Searcheven(bool iSSearch)
        {
            if (iSSearch)
            {
                if (!string.IsNullOrEmpty(cmbIssueCode.Text))
                {
                    ptsissuecode.listIssueCode.Clear();
                    ptsissuecode.listIssueCode.Add(ptsissuecode.GetIssueCode(int.Parse(cmbIssueCode.Text)));
                    dgvIssueCode.DataSource = null;
                    dgvIssueCode.DataSource = ptsissuecode.listIssueCode;
                    tsIssueTotal.Text = dgvIssueCode.Rows.Count.ToString();
                }
                else
                {
                    ptsissuecode.GetListIssueCode();
                    dgvIssueCode.DataSource = null;
                    dgvIssueCode.DataSource = ptsissuecode.listIssueCode;
                    tsIssueTotal.Text = dgvIssueCode.Rows.Count.ToString();
                }
            }

        }
        /// <summary>
        /// Lock Textbox
        /// </summary>
        private void LockAllNameTextbox()
        {

            txtIssueCode.ReadOnly = true;
            btnAdd.Enabled = true;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            cmbIssueCode.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void UnlockFields(bool edit)
        {
            editMode = edit;
            txtIssueCode.ReadOnly = false;
            if (!edit) txtIssueCode.Text = string.Empty;
            cmbIssueCode.DropDownStyle = ComboBoxStyle.DropDown;
            btnOK.Visible = true;
            btnCancel.Visible = true;
            pnlButtons.Enabled = true;
        }

        private void dgvIssueCode_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ptsissuecode = dgvIssueCode.Rows[e.RowIndex].DataBoundItem as pts_issue_code;
            cmbIssueCode.Text = ptsissuecode.issue_cd.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        #endregion


    }
}

