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
    public partial class MasterFrm : Common.FormCommon
    {
        public MasterFrm(string partnum)
        {
            InitializeComponent();
            tcMaster.ItemSize = new Size(0, 1);
            txtPartNumber.Text = partnum;
        }

        private void MasterFrm_Load(object sender, EventArgs e)
        {
            GetCmb();
            UpdateGrid(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGrid(true);
        }

        private void btnAddMaster_Click(object sender, EventArgs e)
        {
            txtInsPart.Text = txtPartNumber.Text;
            cmbInsTool.Text = cmbTools.Text;
            tcMaster.SelectedTab = tabAddMaster;
        }

        private void btnDelMaster_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_inspect_master masterData = dgvMain.SelectedRows[0].DataBoundItem as tbl_inspect_master;
                int n = masterData.Delete(masterData.inspect_id);
                CustomMessageBox.Notice("Deleted " + n + " master inspect!" + Environment.NewLine + "Đã xóa " + n + " hạng mục!");
                UpdateGrid(true);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPartNumber.ResetText();
            cmbTools.ResetText();
            dgvMain.DataSource = null;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_inspect_master masterData = new tbl_inspect_master();
                int n = masterData.Add(new tbl_inspect_master
                {
                    inspect_cd = txtInsCode.Text,
                    part_number = txtInsPart.Text,
                    inspect_name = txtInsName.Text,
                    inspect_tool = cmbInsTool.Text,
                    inspect_spec = double.Parse(txtInsSpec.Text),
                    tol_plus = double.Parse(txtInsPlus.Text),
                    tol_minus = double.Parse(txtInsMinus.Text)
                });
                CustomMessageBox.Notice("Add " + n + " master inspect!" + Environment.NewLine + "Đã thêm " + n + " hạng mục!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInsClear_Click(object sender, EventArgs e)
        {
            foreach (TextBox t in tbpAddMaster.Controls)
                t.ResetText();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcMaster.SelectedTab = tabMain;
        }

        private void cmbTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid(true);
        }

        private void UpdateGrid(bool isSearch)
        {
            tbl_inspect_master masterData = new tbl_inspect_master();
            if (isSearch) masterData.Search(new tbl_inspect_master { part_number = txtPartNumber.Text, inspect_tool = cmbTools.Text });
            dgvMain.DataSource = masterData.listMaster;
        }

        private void GetCmb()
        {
            tbl_inspect_master masterData = new tbl_inspect_master();
            cmbTools.DataSource = masterData.GetTools();
            cmbTools.ResetText();
            cmbInsTool.DataSource = masterData.GetTools();
            cmbInsTool.ResetText();
        }
    }
}
