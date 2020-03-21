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
        private int limit { get; set; }
        private int current { get; set; }
        public BoxDataFrom(tbl_part_box inBox, int limitQty)
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
            limit = limitQty;
            current = dgvMain.Rows.Count;
        }

        private void BoxDataFrom_Load(object sender, EventArgs e)
        {
            UpdateGrid(true);
        }

        private void UpdateGrid(bool isSearch)
        {
            tbl_inspect_data insData = new tbl_inspect_data();
            tbl_inspect_master masterData = new tbl_inspect_master();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dtFinal = new DataTable();
            if (isSearch)
            {
                DateTime date = DateTime.Parse(txtDate.Text);
                int n = 3;
                ChangeDate:
                if (insData.Search(txtBoxID.Text, date) == 0)
                {
                    n--;
                    if (n > 0)
                    {
                        date = date.AddMonths(-1);
                        goto ChangeDate;
                    }
                }
                dt1 = insData.listData.CreateDatatableFromClass<tbl_inspect_data>();
                dtFinal = DatatableClass.Joined(dt1, dt2);
                dt1 = DatatableClass.Pivot(dt1, dt1.Columns["inspect_id"], dt1.Columns["inspect_data"]);
                int masterQty = masterData.Search(new tbl_inspect_master { inspect_id = 0, part_number = txtPartNumber.Text });
            }
            dgvMain.DataSource = dtFinal;
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

        }
    }
}
