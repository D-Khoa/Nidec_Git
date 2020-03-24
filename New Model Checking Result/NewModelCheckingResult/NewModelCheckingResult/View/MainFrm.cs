using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewModelCheckingResult.Model;

namespace NewModelCheckingResult.View
{
    public partial class MainFrm : Common.FormCommon
    {
        #region FORM EVENT
        public MainFrm()
        {
            InitializeComponent();
            dtpDate.Value = DateTime.Today;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region BUTTONS EVENT
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateGrid(true);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnAddBox_Click(object sender, EventArgs e)
        {
            if (!CheckFields()) return;
            string boxCD = txtPartNumber.Text + "#" + txtInvoice.Text + "#" + dtpDate.Value.ToString("yyyyMMdd");
            BoxDataFrom boxfrm = new BoxDataFrom(new tbl_part_box
            {
                invoice = txtInvoice.Text,
                model_cd = txtModel.Text,
                part_box_cd = boxCD,
                part_box_date = dtpDate.Value,
                part_name = txtPartName.Text,
                part_number = txtPartNumber.Text,
                vender_cd = txtVender.Text,
                purpose_cmt = txtPurpose.Text
            });
            boxfrm.ShowDialog();
        }

        private void btnOpenBox_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count > 0)
                OpenBox(dgvMain.SelectedRows[0].Index);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox(tbpMain);
            dgvMain.DataSource = null;
        }
        #endregion

        #region FIELDS EVENT
        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            OpenBox(e.RowIndex);
        }
        #endregion
        #region SUBS EVENT
        private void UpdateGrid(bool isSearch)
        {
            tbl_part_box boxData = new tbl_part_box();
            if (isSearch)
            {
                int itemQty = boxData.Search(new tbl_part_box
                {
                    part_number = txtPartNumber.Text,
                    part_name = txtPartName.Text,
                    model_cd = txtModel.Text,
                    invoice = txtInvoice.Text,
                    part_box_cd = txtBoxID.Text,
                    part_box_date = dtpDate.Value,
                    vender_cd = txtVender.Text,
                    purpose_cmt = txtPurpose.Text
                }, cbCheckDate.Checked);
                //CustomMessageBox.Notice("Found " + itemQty + " boxes!" + Environment.NewLine + "Tìm được " + itemQty + " hộp dữ liệu!");
            }
            dgvMain.DataSource = boxData.listBox;
            dgvMain.Columns["part_box_id"].HeaderText = "Box ID";
            dgvMain.Columns["part_box_cd"].HeaderText = "Box CD";
            dgvMain.Columns["part_number"].HeaderText = "Part Number";
            dgvMain.Columns["part_name"].HeaderText = "Part Name";
            dgvMain.Columns["model_cd"].HeaderText = "Model";
            dgvMain.Columns["invoice"].HeaderText = "Invoice";
            dgvMain.Columns["part_box_qty"].HeaderText = "Box Qty";
            dgvMain.Columns["part_box_lot"].HeaderText = "Box Lot";
            dgvMain.Columns["part_box_date"].HeaderText = "Box Date";
            dgvMain.Columns["vender_cd"].HeaderText = "Vender";
            dgvMain.Columns["purpose_cmt"].HeaderText = "Purpose";
            dgvMain.Columns["incharge"].HeaderText = "Incharge";
        }

        private bool CheckFields()
        {
            if (string.IsNullOrEmpty(txtPartNumber.Text))
            {
                CustomMessageBox.Error("Part number is empty!" + Environment.NewLine + "Mã số linh kiện trống!");
                txtPartNumber.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtPartName.Text))
            {
                CustomMessageBox.Error("Part name is empty!" + Environment.NewLine + "Tên linh kiện trống!");
                txtPartName.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtModel.Text))
            {
                CustomMessageBox.Error("Model is empty!" + Environment.NewLine + "Model trống!");
                txtModel.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtInvoice.Text))
            {
                CustomMessageBox.Error("Invoice is empty!" + Environment.NewLine + "Số hóa đơn trống!");
                txtInvoice.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtVender.Text))
            {
                CustomMessageBox.Error("Vender is empty!" + Environment.NewLine + "Nhà sản xuất trống!");
                txtVender.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtPurpose.Text))
            {
                CustomMessageBox.Error("Purpose is empty!" + Environment.NewLine + "Cần điền mục đích!");
                txtPurpose.Select();
                return false;
            }
            return true;
        }

        private void ClearTextBox(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c.GetType().Name == "TextBox") c.ResetText();
            }
        }

        private void OpenBox(int index)
        {
            tbl_part_box boxData = dgvMain.Rows[index].DataBoundItem as tbl_part_box;
            BoxDataFrom boxfrm = new BoxDataFrom(boxData);
            boxfrm.ShowDialog();
        }
        #endregion
    }
}
