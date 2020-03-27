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
        private bool _isBoxMode;
        public bool IsBoxMode
        {
            get
            {
                return _isBoxMode;
            }

            set
            {
                _isBoxMode = value;
                btnMeasurement.Visible = !_isBoxMode;
            }
        }

        public MainFrm()
        {
            InitializeComponent();
            IsBoxMode = true;
            dtpDate.Value = DateTime.Today;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            try
            {
                btnDeletebox.Enabled = UserData.isadmin;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion

        #region BUTTONS EVENT
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateGridSearch(true);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnAddBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckFields()) return;
                string boxCD = txtPartNumber.Text + "#" + txtInvoice.Text + "#" + dtpDate.Value.ToString("yyyyMMdd");
                //BoxDataFrom boxfrm = new BoxDataFrom(new tbl_part_box
                //{
                //    invoice = txtInvoice.Text,
                //    model_cd = txtModel.Text,
                //    part_box_cd = boxCD,
                //    part_box_date = dtpDate.Value,
                //    part_name = txtPartName.Text,
                //    part_number = txtPartNumber.Text,
                //    vender_cd = txtVender.Text,
                //    purpose_cmt = txtPurpose.Text
                //});
                //boxfrm.ShowDialog();
                if (CustomMessageBox.Question("Do you want register this box?" + Environment.NewLine + "Bạn có muốn đăng ký dữ liệu hiện tại?") == DialogResult.No)
                    return;
                tbl_part_box boxData = new tbl_part_box()
                {
                    part_box_cd = boxCD,
                    model_cd = txtModel.Text,
                    invoice = txtInvoice.Text,
                    part_number = txtPartNumber.Text,
                    part_name = txtPartName.Text,
                    part_box_date = dtpDate.Value,
                    vender_cd = txtVender.Text,
                    purpose_cmt = txtPurpose.Text,
                    part_box_lot = txtLot.Text,
                    part_box_qty = int.Parse(txtQty.Text)
                };
                boxData.Add(boxData);
                CustomMessageBox.Notice("Add box " + boxCD + " successful!" + Environment.NewLine + "Thêm hộp " + boxCD + " thành công!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnOpenBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count < 0) return;
                //OpenBox(dgvMain.SelectedRows[0].Index);
                tbl_part_box boxData = dgvMain.Rows[dgvMain.SelectedRows[0].Index].DataBoundItem as tbl_part_box;
                txtModel.Text = boxData.model_cd;
                txtInvoice.Text = boxData.invoice;
                txtLot.Text = boxData.part_box_lot;
                txtVender.Text = boxData.vender_cd;
                txtBoxID.Text = boxData.part_box_cd;
                txtPartName.Text = boxData.part_name;
                txtPurpose.Text = boxData.purpose_cmt;
                txtPartNumber.Text = boxData.part_number;
                txtQty.Text = boxData.part_box_qty.ToString();
                LockTextBox(tbpMain, true);
                UpdateGridBox(boxData.part_box_cd, true);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnMeasurement_Click(object sender, EventArgs e)
        {
            try
            {
                MeasurementFrm measurefrm = new MeasurementFrm(txtBoxID.Text, txtPartNumber.Text);
                measurefrm.ShowDialog();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string boxCode = string.Empty;
                string partCode = string.Empty;
                tbl_part_box boxData = new tbl_part_box();
                tbl_inspect_data insData = new tbl_inspect_data();
                tbl_inspect_master masterData = new tbl_inspect_master();
                if (IsBoxMode)
                {
                    if (dgvMain.SelectedRows.Count <= 0)
                    {
                        CustomMessageBox.Notice("Please choose a box!" + Environment.NewLine + "Vui lòng chọn 1 box!");
                        return;
                    }
                    boxData = dgvMain.SelectedRows[0].DataBoundItem as tbl_part_box;
                    boxCode = boxData.part_box_cd;
                    partCode = boxData.part_number;
                }
                else
                {
                    boxCode = txtBoxID.Text;
                    partCode = txtPartNumber.Text;
                }
                insData.Search(boxCode);
                boxData.Search(new tbl_part_box { part_box_cd = boxCode }, false);
                masterData.Search(new tbl_inspect_master { inspect_id = 0, part_number = partCode });
                ExcelClassnew excel = new ExcelClassnew();
                excel.exportExcelIQC(boxData.listBox[0], masterData.listMaster, insData.listData);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnDeletebox_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count <= 0) return;
                if (IsBoxMode)
                {
                    if (CustomMessageBox.Question("Are you sure delete this box?" + Environment.NewLine + "Bạn có muốn xóa hộp dữ liệu này?") == DialogResult.No)
                        return;
                    tbl_part_box boxData = dgvMain.SelectedRows[0].DataBoundItem as tbl_part_box;
                    int n = boxData.Delete(boxData.part_box_id);
                    CustomMessageBox.Notice("Deleted box " + txtBoxID.Text + " !" + Environment.NewLine + "Đã xóa hộp " + txtBoxID.Text + " !");
                }
                else
                {
                    if (CustomMessageBox.Question("Are you sure delete this inspect?" + Environment.NewLine + "Bạn có muốn xóa hạng mục này?") == DialogResult.No)
                        return;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox(tbpMain);
            dgvMain.DataSource = null;
        }
        #endregion

        #region FIELDS EVENT
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnOpenBox.PerformClick();
        }
        #endregion

        #region SUBS EVENT
        private void UpdateGridSearch(bool isSearch)
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
            IsBoxMode = true;
            dgvMain.DataSource = null;
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
            dgvMain.Update();
            dgvMain.Refresh();
        }

        private void UpdateGridBox(string boxcode, bool isSearch)
        {
            tbl_inspect_data insData = new tbl_inspect_data();
            DataTable dt1 = new DataTable();
            DataTable dtFinal = new DataTable();
            if (isSearch)
            {
                insData.Search(boxcode);
                txtQty.Text = insData.GetMaxQty(boxcode).ToString();
                dt1 = insData.listData.CreateDatatableFromClass<tbl_inspect_data>();
                if (dt1.Columns.Contains("inspect_date")) dt1.Columns.Remove("inspect_date");
                if (dt1.Columns.Contains("judge")) dt1.Columns.Remove("judge");
                dtFinal = DatatableClass.Pivot(dt1, dt1.Columns["item_no"], dt1.Columns["inspect_data"]);
            }
            tbl_inspect_master masterData = new tbl_inspect_master();
            masterData.Search(new tbl_inspect_master { inspect_id = 0, part_number = txtPartNumber.Text });
            for (int i = 0; i < dtFinal.Rows.Count; i++)
            {
                int id = int.Parse(dtFinal.Rows[i]["inspect_id"].ToString());
                string insName = masterData.listMaster.Where(x => x.inspect_id == id).Select(x => x.inspect_name).First();
                dtFinal.Rows[i]["inspect_id"] = insName;
            }
            IsBoxMode = false;
            dgvMain.DataSource = dtFinal;
            dgvMain.Update();
            dgvMain.Refresh();
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
            //if (string.IsNullOrEmpty(txtModel.Text))
            //{
            //    CustomMessageBox.Error("Model is empty!" + Environment.NewLine + "Model trống!");
            //    txtModel.Select();
            //    return false;
            //}
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
            if (string.IsNullOrEmpty(txtLot.Text))
            {
                CustomMessageBox.Error("Lot is empty!" + Environment.NewLine + "Cần điền lot!");
                txtLot.Select();
                return false;
            }
            return true;
        }

        private void ClearTextBox(Control ctrl)
        {
            //foreach (Control c in ctrl.Controls)
            //{
            //    if (c.GetType().Name == "TextBox") c.ResetText();
            //}
            LockTextBox(ctrl, false);
            foreach (TextBox c in ctrl.Controls.OfType<TextBox>())
            {
                c.ResetText();
            }
        }

        private void LockTextBox(Control ctrl, bool isLock)
        {
            foreach (TextBox c in ctrl.Controls.OfType<TextBox>())
            {
                c.ReadOnly = isLock;
            }
        }

        private void OpenBox(int index)
        {
            //tbl_part_box boxData = dgvMain.Rows[index].DataBoundItem as tbl_part_box;
            //BoxDataFrom boxfrm = new BoxDataFrom(boxData);
            //boxfrm.ShowDialog();
        }
        #endregion

        private void txtPartNumber_ReadOnlyChanged(object sender, EventArgs e)
        {
            TextBox control = ((TextBox)sender);
            control.TabStop = !control.ReadOnly;
            if (control.ReadOnly) control.BackColor = Color.FromKnownColor(KnownColor.Control);
            else control.BackColor = Color.FromKnownColor(KnownColor.Window);
            control.Update();
            control.Refresh();
        }
    }
}
