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
    public partial class MeasurementFrm : Common.FormCommon
    {
        public MeasurementFrm(string boxid, string partnum)
        {
            InitializeComponent();
            txtBoxID.Text = boxid;
            txtPartNumber.Text = partnum;
        }

        private void MeasurementFrm_Load(object sender, EventArgs e)
        {
            try
            {
                GetCmb();
                UpdateGrid(true);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void GetCmb()
        {
            tbl_inspect_master masterData = new tbl_inspect_master();
            cmbTools.DataSource = masterData.GetTools();
            cmbTools.ResetText();
        }

        private void UpdateGrid(bool isSearch)
        {
            tbl_inspect_master masterData = new tbl_inspect_master();
            if (isSearch) masterData.Search(new tbl_inspect_master { part_number = txtPartNumber.Text, inspect_tool = cmbTools.Text });
            dgvMain.DataSource = masterData.listMaster;
        }

        private void OpenMeasurement(tbl_inspect_master inItem)
        {
            switch (inItem.inspect_tool)
            {
                case "DG":
                case "PG":
                    DGMeasureFrm dgfrm = new DGMeasureFrm(txtBoxID.Text, inItem);
                    dgfrm.ShowDialog();
                    break;
            }
        }

        private void btnOpenMaster_Click(object sender, EventArgs e)
        {
            MasterFrm masterfrm = new MasterFrm(txtPartNumber.Text);
            masterfrm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGrid(true);
        }

        private void btnOpenMeasure_Click(object sender, EventArgs e)
        {
            tbl_inspect_master masterData = dgvMain.SelectedRows[0].DataBoundItem as tbl_inspect_master;
            OpenMeasurement(masterData);
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            tbl_inspect_master masterData = dgvMain.Rows[e.RowIndex].DataBoundItem as tbl_inspect_master;
            OpenMeasurement(masterData);
        }

        private void cmbTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid(true);
        }
    }
}
