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
    public partial class BoxDataFrom : Common.FormCommon
    {
        private int boxID { get; set; }
        private int current { get; set; }
        public BoxDataFrom(tbl_part_box inBox)
        {
            InitializeComponent();
            txtBoxID.Text = inBox.part_box_cd;
            txtModel.Text = inBox.model_cd;
            txtInvoice.Text = inBox.invoice;
            txtPartNumber.Text = inBox.part_number;
            txtPartName.Text = inBox.part_name;
            txtDate.Text = inBox.part_box_date.ToString("yyyy-MM-dd");
            txtVender.Text = inBox.vender_cd;
            txtPurpose.Text = inBox.purpose_cmt;
            txtLot.Text = inBox.part_box_lot;
            boxID = inBox.part_box_id;
        }

        private void BoxDataFrom_Load(object sender, EventArgs e)
        {
            UpdateGrid(true);
        }

        private void UpdateGrid(bool isSearch)
        {
            tbl_inspect_data insData = new tbl_inspect_data();
            DataTable dt1 = new DataTable();
            DataTable dtFinal = new DataTable();
            if (isSearch)
            {
                insData.Search(txtBoxID.Text);
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
            dgvMain.DataSource = dtFinal;
            current = insData.GetMaxQty(txtBoxID.Text);
            txtBoxQty.Text = current.ToString();
        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            MeasurementFrm measurefrm = new MeasurementFrm(txtBoxID.Text, txtPartNumber.Text);
            measurefrm.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Question("Do you want register this box?" + Environment.NewLine + "Bạn có muốn đăng ký dữ liệu hiện tại?") == DialogResult.No)
                return;
            tbl_part_box boxData = new tbl_part_box()
            {
                part_box_cd = txtBoxID.Text,
                model_cd = txtModel.Text,
                invoice = txtInvoice.Text,
                part_number = txtPartNumber.Text,
                part_name = txtPartName.Text,
                part_box_date = DateTime.Parse(txtDate.Text),
                vender_cd = txtVender.Text,
                purpose_cmt = txtPurpose.Text,
                part_box_lot = txtLot.Text,
                part_box_qty = current
            };
            boxData.Add(boxData);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_part_box boxData = new tbl_part_box();
                tbl_inspect_data insData = new tbl_inspect_data();
                tbl_inspect_master masterData = new tbl_inspect_master();
                insData.Search(txtBoxID.Text);
                boxData.Search(new tbl_part_box { part_box_cd = txtBoxID.Text }, false);
                masterData.Search(new tbl_inspect_master { inspect_id = 0, part_number = txtPartNumber.Text });
                ExcelClassnew excel = new ExcelClassnew();
                excel.exportExcelIQC(boxData.listBox[0], masterData.listMaster, insData.listData);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnDeleteBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomMessageBox.Question("Are you sure delete this box?" + Environment.NewLine + "Bạn có đồng ý xóa hộp dữ liệu này?") == DialogResult.No)
                    return;
                tbl_part_box boxData = new tbl_part_box();
                int n = boxData.Delete(boxID);
                CustomMessageBox.Notice("Deleted box " + txtBoxID.Text + " !" + Environment.NewLine + "Đã xóa hộp " + txtBoxID.Text + " !");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void tbpMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
