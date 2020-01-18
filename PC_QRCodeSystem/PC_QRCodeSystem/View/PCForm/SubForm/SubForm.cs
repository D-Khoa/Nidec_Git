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
    public partial class SubForm : FormCommon
    {
        #region VARIABLE
        pts_item ptsItem { get; set; }
        pts_item_type ptsItemType { get; set; }
        pts_item_location ptsItemLocation { get; set; }
        #endregion

        public SubForm()
        {
            InitializeComponent();
            #region SETUP CONTROLS
            btnOK.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            lbUnitCode.Visible = true;
            cmbUnitCode.Visible = true;
            rbtnItemCode.Checked = true;
            ptsItem = new pts_item();
            ptsItemType = new pts_item_type();
            ptsItemLocation = new pts_item_location();
            #endregion
        }

        private void SubForm_Load(object sender, EventArgs e)
        {
            #region GET COMBOBOX DATA
            ptsItemType.GetListItemType();
            cmbItemType.DataSource = ptsItemType.listItemType;
            cmbItemType.DisplayMember = "type_id";
            cmbItemType.ValueMember = "type_name";
            cmbItemType.Text = null;
            ptsItemLocation.GetListItemLocation(string.Empty);
            cmbItemLocation.DataSource = ptsItemLocation.listItemLocation;
            cmbItemLocation.DisplayMember = "item_location_no";
            cmbItemLocation.ValueMember = "item_location_name";
            cmbItemLocation.Text = null;
            cmbUnitCode.DataSource = ptsItem.GetListUnit();
            cmbUnitCode.DisplayMember = "unit_cd";
            cmbUnitCode.Text = null;
            #endregion
        }

        #region GET NAME OF ITEMS
        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Get item name and show it
                    if (!string.IsNullOrEmpty(txtItem.Text))
                        txtItemName.Text = ptsItem.GetItem(txtItem.Text).item_name;
                    else
                        txtItemName.Text = "Item Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Show name of item type
                if (!string.IsNullOrEmpty(cmbItemType.Text))
                    txtTypeName.Text = cmbItemType.SelectedValue.ToString();
                else
                    txtTypeName.Text = "Item Type Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbItemLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Show name of item location
                if (!string.IsNullOrEmpty(cmbItemLocation.Text))
                    txtLocationName.Text = cmbItemLocation.SelectedValue.ToString();
                else
                    txtLocationName.Text = "Item Location Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ADD ITEM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //ADD NEW ITEM
            if (rbtnItemCode.Checked)
            {
                txtItemName.ReadOnly = false;
                txtTypeName.ReadOnly = true;
                txtLocationName.ReadOnly = true;
                txtItemName.Text = string.Empty;
                cmbUnitCode.DropDownStyle = ComboBoxStyle.DropDown;
            }
            //ADD NEW ITEM TYPE
            if (rbtnItemType.Checked)
            {
                txtItemName.ReadOnly = true;
                txtTypeName.ReadOnly = false;
                txtLocationName.ReadOnly = true;
                txtTypeName.Text = string.Empty;
                cmbItemType.DropDownStyle = ComboBoxStyle.DropDown;
            }
            //ADD NEW ITEM LOCATION
            if (rbtnItemLocation.Checked)
            {
                txtItemName.ReadOnly = true;
                txtTypeName.ReadOnly = true;
                txtLocationName.ReadOnly = false;
                txtLocationName.Text = string.Empty;
                cmbItemLocation.DropDownStyle = ComboBoxStyle.DropDown;
            }
            btnAdd.Enabled = false;
            btnOK.Visible = true;
            btnCancel.Visible = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int n = 0;
                if (rbtnItemCode.Checked)
                {
                    CapacityForm capfrm = new CapacityForm();
                    if (capfrm.ShowDialog() == DialogResult.OK)
                    {
                        //CALL FUNCTION ADD NEW ITEM
                        n = ptsItem.AddItem(new pts_item
                        {
                            item_cd = txtItem.Text,
                            item_name = txtItemName.Text,
                            type_id = int.Parse(cmbItemType.Text),
                            unit_cd = cmbUnitCode.Text,
                            unit_qty = capfrm.capacityNumber,
                            stock_qty = 0,
                            item_location_no = cmbItemLocation.Text,
                            registration_user_cd = UserData.usercode
                        });
                    }
                    ptsItem.GetListUnit();
                }
                if (rbtnItemType.Checked)
                {
                    //CALL FUNCTION ADD NEW ITEM TYPE
                    n = ptsItemType.AddItemType(new pts_item_type
                    {
                        type_id = int.Parse(cmbItemType.Text),
                        type_name = txtTypeName.Text,
                        registration_user_cd = UserData.usercode
                    });
                    ptsItemType.GetListItemType();
                }
                if(rbtnItemLocation.Checked)
                {
                    //CALL FUNCTION ADD NEW ITEM LOCATION
                    n = ptsItemLocation.AddItemLocation(new pts_item_location
                    {
                        item_location_no = cmbItemLocation.Text,
                        item_location_name = txtLocationName.Text,
                        registration_user_cd = UserData.usercode
                    });
                    ptsItemLocation.GetListItemLocation(string.Empty);
                }
                MessageBox.Show("Add " + n + " item complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Search and get items list
            if (rbtnItemCode.Checked)
            {
                ptsItem.GetListItems(txtItem.Text, cmbUnitCode.Text, cmbItemLocation.Text, int.Parse(cmbItemType.Text));
                dgvData.DataSource = null;
                dgvData.DataSource = ptsItem.listItems;
            }
            //Search and get item type list
            if (rbtnItemType.Checked)
            {
                ptsItemType.GetListItemType();
                dgvData.DataSource = null;
                dgvData.DataSource = ptsItemType.listItemType;
            }
            //Search and get item locaion list
            if (rbtnItemLocation.Checked)
            {
                ptsItemLocation.GetListItemLocation(string.Empty);
                dgvData.DataSource = null;
                dgvData.DataSource = ptsItemLocation.listItemLocation;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dgvData.DataSource != null)
                dgvData.DataSource = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region SELECT RADIO ITEM CHANGE
        private void rbtnItemCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnItemCode.Checked)
            {
                txtItem.Enabled = true;
                cmbItemType.Enabled = true;
                cmbItemLocation.Enabled = true;
                lbUnitCode.Visible = true;
                cmbUnitCode.Visible = true;
            }
            if (rbtnItemType.Checked)
            {
                txtItem.Enabled = false;
                cmbItemType.Enabled = true;
                cmbItemLocation.Enabled = false;
                lbUnitCode.Visible = false;
                cmbUnitCode.Visible = false;
            }
            if (rbtnItemLocation.Checked)
            {
                txtItem.Enabled = false;
                cmbItemType.Enabled = false;
                cmbItemLocation.Enabled = true;
                lbUnitCode.Visible = false;
                cmbUnitCode.Visible = false;
            }
        }

        /// <summary>
        /// Lock all name textbox
        /// </summary>
        private void LockAllNameTextbox()
        {
            txtItemName.ReadOnly = true;
            txtTypeName.ReadOnly = true;
            txtLocationName.ReadOnly = true;
            btnAdd.Enabled = true;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            cmbUnitCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItemType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItemLocation.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion
    }
}
