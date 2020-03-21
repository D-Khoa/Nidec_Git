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
        private string boxID { get; set; }
        public MeasurementFrm(string boxid, string partnum)
        {
            InitializeComponent();
            boxID = boxid;
            txtPartNumber.Text = partnum;
        }

        private void MeasurementFrm_Load(object sender, EventArgs e)
        {
            try
            {
                GetCmb();
                tbl_inspect_master masterData = new tbl_inspect_master();
                masterData.Search(new tbl_inspect_master { part_number = txtPartNumber.Text, inspect_tool = cmbTools.Text });
                dgvMain.DataSource = masterData.listMaster;
            }
            catch(Exception ex)
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

        private void btnOpenMaster_Click(object sender, EventArgs e)
        {
            MasterFrm masterfrm = new MasterFrm();
            masterfrm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tbl_inspect_master masterData = new tbl_inspect_master();
            masterData.Search(new tbl_inspect_master { part_number = txtPartNumber.Text, inspect_tool = cmbTools.Text });
            dgvMain.DataSource = masterData.listMaster;
        }

        private void btnOpenMeasure_Click(object sender, EventArgs e)
        {
            DiagaugeForm.DiagaugeForm dgfrm = new DiagaugeForm.DiagaugeForm();
            dgfrm.ShowDialog();
        }
    }
}
