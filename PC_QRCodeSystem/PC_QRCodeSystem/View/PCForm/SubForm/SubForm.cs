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
        pts_item ptsItem { get; set; }
        pts_item_type ptsItemType { get; set; }
        pts_item_loction ptsItemLocation { get; set; }

        public SubForm()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            rbtnItemCode.Checked = true;
            ptsItem = new pts_item();
            ptsItemType = new pts_item_type();
            ptsItemLocation = new pts_item_loction();
        }

        private void SubForm_Load(object sender, EventArgs e)
        {
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
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {
            //Get item name and show it
            if (!string.IsNullOrEmpty(txtItem.Text))
                lbItemName.Text = ptsItem.GetItem(txtItem.Text).item_name;
        }

        private void cmbItemType_TextChanged(object sender, EventArgs e)
        {
            //Show name of item type
            if (!string.IsNullOrEmpty(cmbItemType.Text))
                lbItemTypeName.Text = cmbItemType.SelectedValue.ToString();
            else
                lbItemTypeName.Text = "None";
        }

        private void cmbItemLocation_TextChanged(object sender, EventArgs e)
        {
            //Show name of item location
            if (!string.IsNullOrEmpty(cmbItemLocation.Text))
                lbItemLocationName.Text = cmbItemLocation.SelectedValue.ToString();
            else
                lbItemLocationName.Text = "None";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

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

        private void rbtnItemCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnItemCode.Checked)
            {
                txtItem.Enabled = true;
                cmbItemType.Enabled = true;
                cmbItemLocation.Enabled = true;
            }
            if (rbtnItemType.Checked)
            {
                txtItem.Enabled = false;
                cmbItemType.Enabled = true;
                cmbItemLocation.Enabled = false;
            }
            if (rbtnItemLocation.Checked)
            {
                txtItem.Enabled = false;
                cmbItemType.Enabled = false;
                cmbItemLocation.Enabled = true;
            }
        }
    }
}
