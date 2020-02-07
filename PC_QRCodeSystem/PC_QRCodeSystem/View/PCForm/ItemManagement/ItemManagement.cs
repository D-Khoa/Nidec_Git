using System;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class ItemManagement : FormCommon
    {
        #region VARIABLE
        bool editMode { get; set; }
        pts_item unitCbm { get; set; }
        pts_item ptsItem { get; set; }
        pts_item locationCbm { get; set; }
        pts_item_type typeCbm { get; set; }
        pts_item_type ptsItemType { get; set; }
        #endregion

        public ItemManagement()
        {
            InitializeComponent();
            #region SETUP CONTROLS
            ptsItem = new pts_item();
            unitCbm = new pts_item();
            locationCbm = new pts_item();
            typeCbm = new pts_item_type();
            ptsItemType = new pts_item_type();
            editMode = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            rbtnItemCode.Checked = true;
            pnlSubButton.Visible = false;
            #endregion
        }

        private void SubForm_Load(object sender, EventArgs e)
        {
            GetCmbData();
        }

        #region EVENT CHANGE TEXT ON FIELDS
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

        private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void txtStockOnHand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }
        #endregion

        #region MAIN BUTTON
        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGrid(true);
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
            if (MessageBox.Show("This action is not undo" + Environment.NewLine + "Are you sure delete this item?", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            int n = 0;
            if (rbtnItemCode.Checked)
            {
                n = ptsItem.Delete(ptsItem.item_id);
            }
            if (rbtnItemType.Checked)
            {
                n = ptsItemType.Delete(ptsItemType.type_id);
            }
            ClearFields();
            GetCmbData();
            UpdateGrid(true);
            MessageBox.Show("Delete " + n + " Item", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region QUERY BUTTON
        /// <summary>
        /// Get data fro combobox
        /// </summary>
        private void GetCmbData()
        {
            typeCbm.GetListItemType();
            cmbItemType.DataSource = typeCbm.listItemType;
            cmbItemType.DisplayMember = "type_id";
            cmbItemType.ValueMember = "type_name";
            cmbItemType.Text = null;
            unitCbm.GetListUnit();
            cmbUnitCode.DataSource = unitCbm.listItems;
            cmbUnitCode.DisplayMember = "unit_cd";
            cmbUnitCode.Text = null;
            locationCbm.GetListLocation();
            cmbLocation.DataSource = locationCbm.listItems;
            cmbLocation.DisplayMember = "item_location";
            cmbLocation.Text = null;
        }

        /// <summary>
        /// Search and update grid
        /// </summary>
        private void UpdateGrid(bool isSearch)
        {
            //Search and get items list
            if (rbtnItemCode.Checked)
            {
                if (isSearch)
                {
                    //Search with item type
                    if (!string.IsNullOrEmpty(cmbItemType.Text))
                        ptsItem.GetListItems(txtItem.Text, cmbUnitCode.Text, cmbLocation.Text, int.Parse(cmbItemType.Text));
                    else
                        //Search without item type
                        ptsItem.GetListItems(txtItem.Text, cmbUnitCode.Text, cmbLocation.Text);
                }
                dgvData.DataSource = null;
                dgvData.DataSource = ptsItem.listItems;
                dgvData.Columns["item_id"].HeaderText = "Item ID";
                dgvData.Columns["item_cd"].HeaderText = "Item Number";
                dgvData.Columns["item_name"].HeaderText = "Item Name";
                dgvData.Columns["type_id"].HeaderText = "Type ID";
                dgvData.Columns["unit_cd"].HeaderText = "Unit";
                dgvData.Columns["unit_qty"].HeaderText = "Unit Qty";
                dgvData.Columns["stock_qty"].HeaderText = "Stock Qty";
                dgvData.Columns["item_location"].HeaderText = "Item Location";
                dgvData.Columns["registration_user_cd"].HeaderText = "Registration User";
                dgvData.Columns["registration_date_time"].HeaderText = "Registration Date";
            }
            //Search and get item type list
            if (rbtnItemType.Checked)
            {
                if (isSearch)
                    ptsItemType.GetListItemType();
                dgvData.DataSource = null;
                dgvData.DataSource = ptsItemType.listItemType;
                dgvData.Columns["type_id"].HeaderText = "Type ID";
                dgvData.Columns["type_name"].HeaderText = "Type Name";
                dgvData.Columns["registration_user_cd"].HeaderText = "Registration User";
                dgvData.Columns["registration_date_time"].HeaderText = "Registration Date";
            }
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            isSearch = false;
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        private void ClearFields()
        {
            txtItem.Clear();
            txtCapacity.Clear();
            txtStockOnHand.Clear();
            cmbLocation.Text = null;
            cmbUnitCode.Text = null;
            cmbItemType.Text = null;
            txtItemName.Text = "Item Name";
            ptsItem.listItems.Clear();
            ptsItemType.listItemType.Clear();
        }

        /// <summary>
        /// Unlock all fields of items
        /// </summary>
        /// <param name="edit">false: add item, true: update item</param>
        private void UnlockFields(bool edit)
        {
            editMode = edit;
            if (rbtnItemCode.Checked)
            {
                txtTypeName.ReadOnly = true;
                txtItemName.ReadOnly = false;
                txtCapacity.ReadOnly = false;
                txtStockOnHand.ReadOnly = false;
                if (!edit) txtItemName.Clear();
                //if (edit) txtStockOnHand.ReadOnly = true;
                cmbLocation.DropDownStyle = ComboBoxStyle.DropDown;
                cmbUnitCode.DropDownStyle = ComboBoxStyle.DropDown;
            }
            if (rbtnItemType.Checked)
            {
                txtItemName.ReadOnly = true;
                txtTypeName.ReadOnly = false;
                if (!edit) txtTypeName.Clear();
                cmbItemType.DropDownStyle = ComboBoxStyle.DropDown;
            }
            pnlButtons.Visible = false;
            pnlSubButton.Visible = true;
        }

        /// <summary>
        /// Lock all name textbox
        /// </summary>
        private void LockFields()
        {
            pnlButtons.Visible = true;
            pnlSubButton.Visible = false;
            txtItemName.ReadOnly = true;
            txtTypeName.ReadOnly = true;
            txtCapacity.ReadOnly = true;
            txtStockOnHand.ReadOnly = true;
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnitCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItemType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int n = 0;
                string messstring = string.Empty;
                #region ADD & UPDATE ITEM
                if (rbtnItemCode.Checked)
                {
                    //Edit mode for update item
                    if (editMode)
                    {
                        n = ptsItem.Update(new pts_item
                        {
                            item_id = ptsItem.item_id,
                            item_cd = txtItem.Text,
                            item_name = txtItemName.Text,
                            type_id = int.Parse(cmbItemType.Text),
                            unit_cd = cmbUnitCode.Text,
                            unit_qty = double.Parse(txtCapacity.Text),
                            stock_qty = double.Parse(txtStockOnHand.Text),
                            item_location = cmbLocation.Text,
                            registration_user_cd = UserData.usercode
                        });
                    }
                    else
                    {
                        //CALL FUNCTION ADD NEW ITEM
                        n = ptsItem.AddItem(new pts_item
                        {
                            item_cd = txtItem.Text,
                            item_name = txtItemName.Text,
                            type_id = int.Parse(cmbItemType.Text),
                            unit_cd = cmbUnitCode.Text,
                            unit_qty = double.Parse(txtCapacity.Text),
                            stock_qty = 0,
                            item_location = cmbLocation.Text,
                            registration_user_cd = UserData.usercode
                        });
                    }
                    unitCbm.GetListUnit();
                }
                #endregion

                #region ADD & UPDATE ITEM TYPE
                if (rbtnItemType.Checked)
                {
                    //Edit mode for update item
                    if (editMode)
                    {
                        n = ptsItemType.Update(new pts_item_type
                        {
                            type_id = int.Parse(cmbItemType.Text),
                            type_name = txtTypeName.Text,
                            registration_user_cd = UserData.usercode
                        });
                    }
                    else
                    {
                        //CALL FUNCTION ADD NEW ITEM TYPE
                        n = ptsItemType.AddItemType(new pts_item_type
                        {
                            type_id = int.Parse(cmbItemType.Text),
                            type_name = txtTypeName.Text,
                            registration_user_cd = UserData.usercode
                        });
                    }
                    typeCbm.GetListItemType();
                }
                #endregion

                ClearFields();
                GetCmbData();
                UpdateGrid(true);
                if (editMode) messstring = "Update ";
                else messstring = "Add ";
                MessageBox.Show(messstring + n + " item complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LockFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LockFields();
        }
        #endregion

        #region SUB EVENT
        private void rbtnItemCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnItemCode.Checked)
            {
                lbUnitCode.Visible = true;
                lbCapacity.Visible = true;
                lbLocation.Visible = true;
                lbStockInHand.Visible = true;

                txtItem.Enabled = true;
                cmbUnitCode.Visible = true;
                cmbLocation.Visible = true;
                txtCapacity.Visible = true;
                txtStockOnHand.Visible = true;

                dgvData.DataSource = null;
                dgvData.DataSource = ptsItem.listItems;
                txtItemName.BackColor = System.Drawing.Color.Yellow;
                rbtnItemCode.BackColor = System.Drawing.Color.Yellow;
                txtTypeName.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control);
                rbtnItemType.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control);
            }
            if (rbtnItemType.Checked)
            {
                lbUnitCode.Visible = false;
                lbCapacity.Visible = false;
                lbLocation.Visible = false;
                lbStockInHand.Visible = false;

                txtItem.Enabled = false;
                cmbUnitCode.Visible = false;
                cmbLocation.Visible = false;
                txtCapacity.Visible = false;
                txtStockOnHand.Visible = false;

                dgvData.DataSource = null;
                dgvData.DataSource = ptsItemType.listItemType;
                txtTypeName.BackColor = System.Drawing.Color.Yellow;
                rbtnItemType.BackColor = System.Drawing.Color.Yellow;
                txtItemName.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control);
                rbtnItemCode.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control);
            }
            UpdateGrid(false);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get data from datagrid to pts item
            if (rbtnItemCode.Checked)
            {
                ptsItem = dgvData.Rows[e.RowIndex].DataBoundItem as pts_item;
                txtItem.Text = ptsItem.item_cd;
                txtItemName.Text = ptsItem.item_name;
                cmbLocation.Text = ptsItem.item_location;
                txtCapacity.Text = ptsItem.unit_qty.ToString();
                txtStockOnHand.Text = ptsItem.stock_qty.ToString();
                cmbUnitCode.Text = ptsItem.unit_cd;
                cmbItemType.Text = ptsItem.type_id.ToString();
            }
            //Get data from datagrid to pts item type
            if (rbtnItemType.Checked)
            {
                ptsItemType = dgvData.Rows[e.RowIndex].DataBoundItem as pts_item_type;
                cmbItemType.Text = ptsItemType.type_id.ToString();
            }
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void SubForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnOK.Visible)
            {
                if (MessageBox.Show("You are in processing!" + Environment.NewLine + "Are you sure exit?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        #endregion
    }
}
