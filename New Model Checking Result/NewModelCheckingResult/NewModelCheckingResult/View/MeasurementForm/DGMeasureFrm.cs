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
    public partial class DGMeasureFrm : Common.FormCommon
    {
        int insID = 0;
        int maxNo = 0;
        int currNo = 0;
        BindingList<tbl_inspect_data> listNewData { get; set; }

        public DGMeasureFrm(string boxid, tbl_inspect_master inItem)
        {
            InitializeComponent();
            txtBoxID.Text = boxid;
            insID = inItem.inspect_id;
            txtInsCode.Text = inItem.inspect_cd;
            txtInsName.Text = inItem.inspect_name;
            txtInsPart.Text = inItem.part_number;
            txtInsTool.Text = inItem.inspect_tool;
            txtInsSpec.Text = inItem.inspect_spec.ToString();
            txtUSL.Text = (inItem.inspect_spec + inItem.tol_plus).ToString();
            txtLSL.Text = (inItem.inspect_spec - inItem.tol_minus).ToString();
            listNewData = new BindingList<tbl_inspect_data>();
        }

        private void DGMeasureFrm_Load(object sender, EventArgs e)
        {
            tbpEnterValue.Visible = false;
            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateGridNew();
            UpdateGridReg();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tbpEnterValue.Visible = true;
            txtMeasureValue.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_inspect_data insData = new tbl_inspect_data();
                int n = insData.AddMultiData(listNewData.ToList());
                tbl_part_box boxData = new tbl_part_box();
                if (boxData.Search(new tbl_part_box { part_box_cd = listNewData[0].part_box_cd }, false) > 0)
                {
                    boxData = boxData.listBox[0];
                    if (string.IsNullOrEmpty(boxData.incharge)) boxData.incharge = UserData.username;
                    else if (!boxData.incharge.Contains(UserData.username)) boxData.incharge += "+" + UserData.username;
                    int m = insData.GetMaxQty(boxData.part_box_cd);
                    if (currNo < m) currNo = m;
                    boxData.UpdateInchargeQty(boxData.part_box_cd, boxData.incharge, currNo);
                }
                CustomMessageBox.Notice("Added " + n + " item!" + Environment.NewLine + "Đăng ký " + n + " con hàng!");
                currNo = 0;
                listNewData.Clear();
                btnRefresh.PerformClick();
                txtMeasureValue.Focus();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNewMeasure.SelectedRows.Count <= 0) return;
            if (CustomMessageBox.Question("Do you want delete this item?" + Environment.NewLine + "Bạn có muốn xóa con hàng này?") == DialogResult.No)
                return;
            listNewData.RemoveAt(dgvNewMeasure.SelectedRows[0].Index);
            btnRefresh.PerformClick();
        }

        private void txtMeasureValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEnterValue.PerformClick();
        }

        private void btnEnterValue_Click(object sender, EventArgs e)
        {
            try
            {
                currNo++;
                if (string.IsNullOrEmpty(txtMeasureValue.Text)) return;
                double measVal = double.Parse(txtMeasureValue.Text);
                double uslVal = double.Parse(txtUSL.Text);
                double lslVal = double.Parse(txtLSL.Text);
                string judge = "0";
                if (measVal > uslVal || measVal < lslVal) judge = "1";
                else judge = "0";
                tbl_inspect_data insData = new tbl_inspect_data
                {
                    judge = judge,
                    item_no = currNo,
                    inspect_id = insID,
                    part_box_cd = txtBoxID.Text,
                    inspect_date = DateTime.Now,
                    inspect_data = measVal,
                    incharge = UserData.username
                };
                listNewData.Add(insData);
                UpdateGridNew();
                //UpdateGridReg();
                txtMeasureValue.ResetText();
                txtMeasureValue.Focus();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void txtMeasureValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) e.Handled = true;
        }

        private void UpdateGridNew()
        {
            dgvNewMeasure.DataSource = listNewData;
            foreach (DataGridViewRow dr in dgvNewMeasure.Rows)
            {
                if (dr.Cells["judge"].Value.ToString() == "1") dr.DefaultCellStyle.BackColor = Color.Red;
                else dr.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void UpdateGridReg()
        {
            tbl_inspect_data insData = new tbl_inspect_data();
            insData.Search(txtBoxID.Text);
            maxNo = insData.GetMax(txtBoxID.Text, insID);
            dgvRegMeasure.DataSource = insData.listData;
            foreach (DataGridViewRow dr in dgvRegMeasure.Rows)
            {
                if (dr.Cells["judge"].Value.ToString() == "1") dr.DefaultCellStyle.BackColor = Color.Red;
                else dr.DefaultCellStyle.BackColor = Color.White;
            }
            currNo = maxNo;
        }
    }
}
