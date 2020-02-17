using System;
using System.Drawing;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class PlanningForm : FormCommon
    {
        #region VARIABLE
        private pts_plan planData { get; set; }
        private pts_item modelData { get; set; }
        private pts_stock stockData { get; set; }
        private m_mes_user userData { get; set; }
        private pts_destination desData { get; set; }
        private ErrorProvider errorProvider { get; set; }
        #endregion

        public PlanningForm()
        {
            InitializeComponent();
            planData = new pts_plan();
            modelData = new pts_item();
            stockData = new pts_stock();
            userData = new m_mes_user();
            desData = new pts_destination();
            errorProvider = new ErrorProvider();
            tc_PlanManagement.SelectedTab = tab_Main;
            tc_PlanManagement.ItemSize = new Size(0, 1);
        }

        private void PlanningForm_Load(object sender, EventArgs e)
        {
            GetCmb();
            ClearFields();
            LockButtons(true);
            rbtnNoCheckDate.Checked = true;
        }

        #region BUTTONS EVENT
        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGrid(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                planData.Add(new pts_plan
                {
                    plan_usercd = txtUserCD.Text,
                    model_cd = txtModelCD.Text,
                    set_number = txtSetNumber.Text,
                    destination_cd = cmbDestinationCD.Text,
                    plan_qty = double.Parse(txtPlanQty.Text),
                    plan_date = dtpPlanDate.Value,
                    delivery_date = dtpDeliveryDate.Value,
                    comment = txtComment.Text,
                });
                MessageBox.Show("Add new plan successed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateGrid(false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                planData.Update(new pts_plan
                {
                    model_cd = txtModelCD.Text,
                    plan_usercd = txtUserCD.Text,
                    set_number = txtSetNumber.Text,
                    destination_cd = cmbDestinationCD.Text,
                    plan_qty = double.Parse(txtPlanQty.Text),
                    plan_date = dtpPlanDate.Value,
                    delivery_date = dtpDeliveryDate.Value,
                    comment = txtComment.Text,
                });
                MessageBox.Show("Update plan successed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateGrid(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                planData.Delete();
                MessageBox.Show("Delet plan successed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateGrid(false);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            LockButtons(true);
            UpdateGrid(false);
        }
        #endregion

        #region FIELDS EVENT
        private void txtUserCD_TextChanged(object sender, EventArgs e)
        {
            lbUserName.Text = "User Name";
            errorProvider.SetError(txtUserCD, null);
            lbUserName.BackColor = Color.FromKnownColor(KnownColor.Control);
            if (string.IsNullOrEmpty(txtUserCD.Text))
                return;
            try
            {
                lbUserName.Text = userData.GetUser(txtUserCD.Text).user_name;
                lbUserName.BackColor = Color.Lime;
            }
            catch
            {
                errorProvider.SetError(txtUserCD, "Wrong user code");
            }
        }

        private void txtModelCD_TextChanged(object sender, EventArgs e)
        {
            lbModelName.Text = "Model Name";
            errorProvider.SetError(txtModelCD, null);
            lbModelName.BackColor = Color.FromKnownColor(KnownColor.Control);
            if (string.IsNullOrEmpty(txtModelCD.Text))
                return;
            try
            {
                modelData = modelData.GetItem(txtModelCD.Text);
                if (modelData.type_id != 0)
                    errorProvider.SetError(txtModelCD, "This item is not type 0 item!");
                lbModelName.Text = modelData.item_name;
                lbModelName.BackColor = Color.Lime;
                stockData = stockData.GetItem(new pts_stock { item_cd = txtModelCD.Text }, false);
                if (!string.IsNullOrEmpty(stockData.order_no)) txtSetNumber.Text = stockData.order_no;
                else txtSetNumber.Text = "None";
            }
            catch
            {
                errorProvider.SetError(txtModelCD, "Wrong Model Code");
            }
        }

        private void cmbDestinationCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDestinationCD.Text))
            {
                lbDestinationName.Text = cmbDestinationCD.SelectedValue.ToString();
                lbDestinationName.BackColor = Color.Lime;
            }
            else
            {
                lbDestinationName.Text = "Destination Name";
                lbDestinationName.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void txtPlanQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dgvPlanData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                planData = dgvPlanData.Rows[e.RowIndex].DataBoundItem as pts_plan;
                txtComment.Text = planData.comment;
                txtModelCD.Text = planData.model_cd;
                txtUserCD.Text = planData.plan_usercd;
                txtSetNumber.Text = planData.set_number;
                txtPlanQty.Text = planData.plan_qty.ToString();
                cmbDestinationCD.Text = planData.destination_cd;
                dtpPlanDate.Value = planData.plan_date;
                dtpDeliveryDate.Value = planData.delivery_date;
            }
            LockButtons(false);
        }
        #endregion

        #region SUB EVENT
        private void GetCmb()
        {
            desData.GetListDestination(string.Empty, string.Empty);
            cmbDestinationCD.DataSource = desData.listdestination;
            cmbDestinationCD.DisplayMember = "destination_cd";
            cmbDestinationCD.ValueMember = "destination_name";
            cmbDestinationCD.Text = null;
        }

        private void UpdateGrid(bool iSSearch)
        {
            try
            {
                #region SEARCH
                if (iSSearch)
                {
                    if (rbtnNoCheckDate.Checked)
                    {
                        planData.Search(new pts_plan
                        {
                            destination_cd = cmbDestinationCD.Text,
                            model_cd = txtModelCD.Text,
                            set_number = txtSetNumber.Text,
                            plan_usercd = txtUserCD.Text,
                        }, dtpPlanDate.Value, dtpPlanToDate.Value, 0);
                    }
                    if (rbtnPlanDate.Checked)
                    {
                        planData.Search(new pts_plan
                        {
                            destination_cd = cmbDestinationCD.Text,
                            model_cd = txtModelCD.Text,
                            set_number = txtSetNumber.Text,
                            plan_usercd = txtUserCD.Text,
                        }, dtpPlanDate.Value, dtpPlanToDate.Value, 1);
                    }
                    if (rbtnDeliveryDate.Checked)
                    {
                        planData.Search(new pts_plan
                        {
                            destination_cd = cmbDestinationCD.Text,
                            model_cd = txtModelCD.Text,
                            set_number = txtSetNumber.Text,
                            plan_usercd = txtUserCD.Text,
                        }, dtpDeliveryDate.Value, dtpDeliveryToDate.Value, 2);
                    }
                }
                #endregion

                dgvPlanData.DataSource = planData.listPlan;
                LockButtons(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LockButtons(bool islock)
        {
            btnPrint.Enabled = !islock;
            btnUpdate.Enabled = !islock;
            btnDelete.Enabled = !islock;
        }

        private void ClearFields()
        {
            txtUserCD.Clear();
            txtModelCD.Clear();
            txtPlanQty.Clear();
            txtSetNumber.Clear();
            cmbDestinationCD.Text = null;
            dgvPlanData.DataSource = null;
            lbUserName.Text = "User Name";
            lbModelName.Text = "Model Name";
            lbDestinationName.Text = "Destination Name";
        }
        #endregion
    }
}
