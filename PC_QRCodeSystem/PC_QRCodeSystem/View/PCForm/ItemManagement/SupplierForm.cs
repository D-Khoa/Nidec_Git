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
    public partial class SupplierForm : FormCommon
    {
        #region VARIABLE
        bool editMode { get; set; }
        pts_supplier suppliercbm { get; set; }
        pts_supplier ptssupllier { get; set; }
        private pts_supplier supplierData { get; set; }

        #endregion
        public SupplierForm()
        {
            InitializeComponent();
            suppliercbm = new pts_supplier();
            ptssupllier = new pts_supplier();
            supplierData = new pts_supplier();
            editMode = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }
        //Load Form
        #region Load Form
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            ptssupllier.GetListSupplier(string.Empty);
            cmbSupplierCode.DataSource = ptssupllier.listSupplier;
            cmbSupplierCode.DisplayMember = "supplier_cd";
            cmbSupplierCode.ValueMember = "supplier_name";
            cmbSupplierCode.Text = null;

        }
        private void SupplierForm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void cmbSupplierCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbSupplierCode.Text))
                    txtSupplierName.Text = cmbSupplierCode.SelectedValue.ToString();
                else
                {
                    txtSupplierName.Text = "Supplier Name";
                    txtSupplierTelephone.Text = "Supplier Telephone";
                    txtFaxNumber.Text = "Fax Number";
                    txtSupplierAddress.Text = "Supplier Address";

                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cmbSupplierCode_TextChanged(object sender, EventArgs e)
        {
            txtSupplierName.BackColor = Color.White;
            if (string.IsNullOrEmpty(cmbSupplierCode.Text))
                return;
            try
            {
                txtSupplierName.Text = supplierData.GetSupplier(new pts_supplier
                {
                    supplier_id = 0,
                    supplier_cd = cmbSupplierCode.Text
                }).supplier_name;
                txtSupplierName.BackColor = Color.Lime;
            }
            catch
            {
                // cmbSupplierCode.BackColor = Color.Yellow;
                txtSupplierName.Text = "";
                txtSupplierName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }
        #region MAIN BUTTON
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Searcheven();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UnlockFields(false);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UnlockFields(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This action is not undo" + Environment.NewLine + "Are you sure delete this supplier?", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            int n = 0;
            n = ptssupllier.Delete();
            // ClearOK();
            Getcmbdata();
            UpdateGrid();
            MessageBox.Show("Delete " + n + " Supplier", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearOK();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            try
            {
                string messstring = string.Empty;
                int n = 0;
                #region Add And Update Supplier
                {
                    if (editMode)
                    {  //CALL FUNTION UPDATE SUPPLIER

                        n = ptssupllier.UpdateSuplier(new pts_supplier
                        {
                            supplier_cd = cmbSupplierCode.Text,
                            supplier_name = txtSupplierName.Text,
                            supplier_tel = txtSupplierTelephone.Text,
                            supplier_fax = txtFaxNumber.Text,
                            supplier_address = txtSupplierAddress.Text,
                            registration_user_cd = UserData.usercode
                        });
                    }
                    else
                    {  //CALL FUNCTION ADD NEW SUPPLIER

                        n = ptssupllier.AddSupplier(new pts_supplier
                        {
                            supplier_cd = cmbSupplierCode.Text,
                            supplier_name = txtSupplierName.Text,
                            supplier_tel = txtSupplierTelephone.Text,
                            supplier_fax = txtFaxNumber.Text,
                            supplier_address = txtSupplierAddress.Text,
                            registration_user_cd = UserData.usercode
                        });
                    }

                    ptssupllier.GetListSupplier(string.Empty);
                }
                #endregion
                ClearOK();
                Getcmbdata();
                UpdateGrid();
                if (editMode) messstring = "Update ";
                else messstring = "Add ";
                MessageBox.Show(messstring + n + " Supplier Complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSupplierCode.Text = null;
                txtSupplierName.Text = "Supplier Name";
                txtSupplierTelephone.Text = "Telephone";
                txtFaxNumber.Text = "Fax Number";
                txtSupplierAddress.Text = "Supplier Address";

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LockAllNameTextbox();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LockAllNameTextbox();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            cmbSupplierCode.Text = null;
            txtSupplierName.Text = "Supplier Name";
            txtSupplierTelephone.Text = "Telephone";
            txtFaxNumber.Text = "Fax Number";
            txtSupplierAddress.Text = "Supplier Address";

        }
        #endregion
        #region SUB PROGRAM

        private void UpdateGrid()
        {
            ptssupllier.GetListSupplier(string.Empty);
            dgvDataSupllier.DataSource = null;
            dgvDataSupllier.DataSource = ptssupllier.listSupplier;
        }
        private void ClearOK()
        {
            try
            {
                if (dgvDataSupllier.DataSource != null)
                    dgvDataSupllier.DataSource = null;
                cmbSupplierCode.Text = null;
                txtSupplierName.Text = "Supplier Name";
                txtSupplierTelephone.Text = "Telephone";
                txtFaxNumber.Text = "Fax Number";
                txtSupplierAddress.Text = "Supplier Address";
                ptssupllier.listSupplier.Clear();
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
            suppliercbm.GetListSupplier(string.Empty);
            cmbSupplierCode.DataSource = suppliercbm.listSupplier;
            cmbSupplierCode.DisplayMember = "supplier_cd";
            cmbSupplierCode.ValueMember = "supplier_name";
            cmbSupplierCode.Text = null;
        }
        private void Searcheven()
        {
            ptssupllier.GetListSupplier(string.Empty);
            dgvDataSupllier.DataSource = null;
            dgvDataSupllier.DataSource = ptssupllier.listSupplier;
        }
        /// <summary>
        /// Lock Textbox
        /// </summary>
        private void LockAllNameTextbox()
        {

            txtSupplierName.ReadOnly = true;
            txtSupplierTelephone.ReadOnly = true;
            txtFaxNumber.ReadOnly = true;
            txtSupplierAddress.ReadOnly = true;
            btnAdd.Enabled = true;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            cmbSupplierCode.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        /// <summary>
        /// Unlock all fields of items
        /// </summary>
        /// <param name="edit"></param>
        private void UnlockFields(bool edit)
        {
            editMode = edit;
            txtSupplierName.ReadOnly = false;
            txtSupplierTelephone.ReadOnly = false;
            txtFaxNumber.ReadOnly = false;
            txtSupplierAddress.ReadOnly = false;
            if (!edit) txtSupplierName.Text = string.Empty;
            if (!edit) txtSupplierTelephone.Text = string.Empty;
            if (!edit) txtFaxNumber.Text = string.Empty;
            if (!edit) txtSupplierAddress.Text = string.Empty;
            cmbSupplierCode.DropDownStyle = ComboBoxStyle.DropDown;
            btnOK.Visible = true;
            btnCancel.Visible = true;
            pnlButtons.Enabled = true;
        }

        #endregion
        #region DATAGRID VIEW
        private void dgvDataSupllier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ptssupllier = dgvDataSupllier.Rows[e.RowIndex].DataBoundItem as pts_supplier;
            cmbSupplierCode.Text = ptssupllier.supplier_cd.ToString();
            txtSupplierName.Text = ptssupllier.supplier_name.ToString();
            txtSupplierTelephone.Text = ptssupllier.supplier_tel.ToString();
            txtFaxNumber.Text = ptssupllier.supplier_fax.ToString();
            txtSupplierAddress.Text = ptssupllier.supplier_address.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
        #endregion

       
    }
}
