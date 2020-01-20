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
        pts_supplier ptssupllier { get; set; }
        public SupplierForm()
        {
            InitializeComponent();
            ptssupllier = new pts_supplier();
            btnOK.Visible = false;
            btnCancel.Visible = false;
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            ptssupllier.GetListSupplier(string.Empty);
            cmbSupplierCode.DataSource = ptssupllier.listSupplier;
            cmbSupplierCode.DisplayMember = "supplier_cd";
            cmbSupplierCode.ValueMember = "supplier_name";
            cmbSupplierCode.Text = null;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ptssupllier.GetListSupplier(string.Empty);
            dgvDataSupllier.DataSource = null;
            dgvDataSupllier.DataSource = ptssupllier.listSupplier;
        }
        private void cmbSupplierCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbSupplierCode.Text))
                    txtSupplierName.Text = cmbSupplierCode.SelectedValue.ToString();
                else
                    txtSupplierName.Text = "Supplier Name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtSupplierName.ReadOnly = false;
            txtSupplierName.Text = string.Empty;
            cmbSupplierCode.DropDownStyle = ComboBoxStyle.DropDown;
            btnAdd.Enabled = false;
            btnOK.Visible = true;
            btnCancel.Visible = true;
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            try
            {
                int n = 0;

                //CALL FUNCTION ADD NEW ITEM TYPE
                n = ptssupllier.AddSupplier(new pts_supplier
                {
                    supplier_cd = cmbSupplierCode.Text,
                    supplier_name = txtSupplierName.Text,
                    registration_user_cd = UserData.usercode
                });
                ptssupllier.GetListSupplier(string.Empty);


                MessageBox.Show("Add " + n + " item complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSupplierName.Text = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LockAllNameTextbox();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dgvDataSupllier.DataSource != null)
                dgvDataSupllier.DataSource = null;
            cmbSupplierCode.Text = null;
            txtSupplierName.Text = null;
        }
        private void LockAllNameTextbox()
        {

            txtSupplierName.ReadOnly = true;
            btnAdd.Enabled = true;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            cmbSupplierCode.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LockAllNameTextbox();

        }
    }
}
