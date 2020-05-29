using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;


namespace PC_QRCodeSystem.View
{
    public partial class PCForm : FormCommon
    {
        #region FORM EVENT
        bool pcmMocde = false;
        bool isEditErrorData = false;
        pts_item itemData { get; set; }
        pts_request_log requestData { get; set; }

        public PCForm()
        {
            InitializeComponent();
            itemData = new pts_item();
            requestData = new pts_request_log();
            grt_Main.ItemSize = new Size(0, 1);
            if (UserData.position == "MGR")
            {
                pcmMocde = true;
                btnAccept.Text = "Confirm";
                this.Text += "[PC Manager]";
            }
            else
            {
                pcmMocde = false;
                btnAccept.Text = "Apccept";
            }
            rbtnAllRequest.Checked = true;
        }
        #endregion

        #region MAIN TAB
        private void btnStockIn_Click(object sender, EventArgs e)
        {
            //StockInForm inFrm = new StockInForm();
            StockInputForm inFrm = new StockInputForm();
            inFrm.Show();
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            Form1 outFrm = new Form1();
            //StockOutLogForm outFrm = new StockOutLogForm();
            //StockOutNewForm outFrm = new StockOutNewForm();
            outFrm.Show();
        }

        private void btnStockDetail_Click(object sender, EventArgs e)
        {
            StockDetailForm dtlFrm = new StockDetailForm();
            dtlFrm.Show();

        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            ItemManagement itemfrm = new ItemManagement();
            itemfrm.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm spfrm = new SupplierForm();
            spfrm.Show();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            DestinationManager desmg = new DestinationManager();
            desmg.Show();
        }

        private void btnIssueCode_Click(object sender, EventArgs e)
        {
            ItemIssueForm issfrm = new ItemIssueForm();
            issfrm.Show();
        }

        private void btnUserPosition_Click(object sender, EventArgs e)
        {
            UserPosition upfrm = new UserPosition();
            upfrm.Show();
        }

        private void btnRequestLog_Click(object sender, EventArgs e)
        {
            grt_Main.SelectedTab = tab_Request;
        }

        private void btnPlanning_Click(object sender, EventArgs e)
        {
            PlanningForm planFrm = new PlanningForm();
            planFrm.Show();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingFrm = new SettingForm();
            settingFrm.Show();
        }

        private void btnStockOutLog_Click(object sender, EventArgs e)
        {
            StockOutLogForm stockoutLogFrm = new StockOutLogForm();
            stockoutLogFrm.Show();
        }

        private void btnErrorData_Click(object sender, EventArgs e)
        {
            isEditErrorData = true;
            grt_Main.SelectedTab = tab_ErrorData;
        }
        #endregion

        #region APPROVE REQUEST TAB
        private void UpdateGrid()
        {
            if (rbtnAllRequest.Checked)
            {
                requestData.Search(new pts_request_log
                {
                    item_cd = string.Empty,
                    model_cd = string.Empty,
                    destination_cd = string.Empty,
                    m_confirm = true,
                    gm_confirm = true,
                    remark = string.Empty,
                }, true, true, false);
            }
            if (rbtnWaitApprove.Checked)
            {
                requestData.Search(new pts_request_log
                {
                    item_cd = string.Empty,
                    model_cd = string.Empty,
                    destination_cd = string.Empty,
                    m_confirm = true,
                    gm_confirm = true,
                    remark = "N",
                }, true, true, true);
            }
            if (rbtnApproved.Checked)
            {
                requestData.Search(new pts_request_log
                {
                    item_cd = string.Empty,
                    model_cd = string.Empty,
                    destination_cd = string.Empty,
                    m_confirm = true,
                    gm_confirm = true,
                    remark = "A",
                }, true, true, true);
            }
            if (rbtnReject.Checked)
            {
                requestData.Search(new pts_request_log
                {
                    item_cd = string.Empty,
                    model_cd = string.Empty,
                    destination_cd = string.Empty,
                    m_confirm = true,
                    gm_confirm = true,
                    remark = "R",
                }, true, true, true);
            }
            dgvRequest.DataSource = requestData.listRequestItem;
            foreach (DataGridViewRow dr in dgvRequest.Rows)
            {
                if (dr.Cells["remark"].Value.ToString() == "R")
                    dr.DefaultCellStyle.BackColor = Color.Red;
                else if (dr.Cells["remark"].Value.ToString() == "A" && (bool)dr.Cells["pc_m_cofirm"].Value)
                    dr.DefaultCellStyle.BackColor = Color.Lime;
                else
                    dr.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            grt_Main.SelectedTab = tab_Menu;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (pcmMocde)
            {
                foreach (DataGridViewCell cell in dgvRequest.SelectedCells)
                {
                    requestData.PC_MConfirm(new pts_request_log
                    {
                        request_id = (int)dgvRequest.Rows[cell.RowIndex].Cells["request_id"].Value,
                        comment = string.Empty,
                    });
                }
            }
            else
            {
                foreach (DataGridViewCell cell in dgvRequest.SelectedCells)
                {
                    requestData.PC_Approve(new pts_request_log
                    {
                        request_id = (int)dgvRequest.Rows[cell.RowIndex].Cells["request_id"].Value,
                        approve_usercd = UserData.usercode,
                        comment = string.Empty,
                        remark = "A"
                    });
                }
            }
            UpdateGrid();
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgvRequest.SelectedCells)
            {
                requestData.PC_Approve(new pts_request_log
                {
                    request_id = (int)dgvRequest.Rows[cell.RowIndex].Cells["request_id"].Value,
                    approve_usercd = UserData.usercode,
                    comment = string.Empty,
                    remark = "R"
                });
            }
            UpdateGrid();
        }
        #endregion

        #region ERROR DATA TAB
        //Danh sách dữ liệu lỗi
        BindingList<OutputItem> listOut = new BindingList<OutputItem>();
        BindingList<pts_stockout_log> outlist = new BindingList<pts_stockout_log>();

        private void btnOpenItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Xem chi tiết dữ liệu đang chọn
                OutputItem outData = dgvDataError.SelectedRows[0].DataBoundItem as OutputItem;
                UpdateStockOutGrid(outData);
                //StockOutLogForm outlogs = new StockOutLogForm();
                //outlogs.SetFields(outData);
                //outlogs.Show();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDataError.SelectedRows.Count <= 0) return;
                if (CustomMessageBox.Question("Are you sure remove this item?" + Environment.NewLine + "Bạn có chắc muốn xóa dữ liệu này?") == DialogResult.No) return;
                //Xóa dữ liệu trong stock out logs
                pts_stockout_log stockoutData = new pts_stockout_log();
                for (int i = 0; i < outlist.Count; i++)
                {
                    stockoutData.DeleteItem(outlist[i]);
                    outlist.RemoveAt(i);
                    i--;
                }
                //Xóa dữ liệu đang chọn
                listOut.RemoveAt(dgvDataError.SelectedRows[0].Index);
                //Xóa file chứa dữ liệu
                if (File.Exists(libFileName.Text)) File.Delete(libFileName.Text);
                //Nếu danh sách còn dữ liệu thì tạo lại file ngược lại xóa file
                if (listOut.Count > 0) listOut[0].ExportCSV(listOut.ToList(), libFileName.Text);
                else libFileName.Items.RemoveAt(libFileName.Items.IndexOf(libFileName.Text));
                CustomMessageBox.Notice("Delete successful!" + Environment.NewLine + "Xóa thành công!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnErrorBack_Click(object sender, EventArgs e)
        {
            isEditErrorData = false;
            grt_Main.SelectedTab = tab_Menu;
        }

        private void libFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Nếu danh sách file lớn hơn 0 thì cập nhật danh sách dữ liệu lỗi
            if (libFileName.SelectedItems.Count > 0) UpdateErrorDataGrid(libFileName.Text);
        }

        private void dgvDataError_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDataError.SelectedRows.Count > 0) btnOpenItem.PerformClick();
        }

        private void dgvDataError_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnOpenItem.PerformClick();
        }

        private void UpdateListBoxErrorFiled()
        {
            //Nếu thư mục ErrorLogs tồn tại thì lấy địa chỉ tất cả các file chứa trong nó
            if (Directory.Exists(SettingItem.outputFolder + @"\ErrorLogs"))
            {
                libFileName.Items.Clear();
                string[] files = Directory.GetFiles(SettingItem.outputFolder + @"\ErrorLogs");
                libFileName.Items.AddRange(files);
            }
        }

        private void UpdateErrorDataGrid(string filename)
        {
            OutputItem outData = new OutputItem();
            //Lấy dữ liệu từ file
            outData.ImportCSV(filename);
            listOut = new BindingList<OutputItem>(outData.listOutputItem);
            //Đưa dữ liệu lỗi vào datagridview
            dgvDataError.DataSource = listOut;
            for (int i = 0; i < listOut.Count; i++)
            {
                if (listOut[i].errorColumns.Count > 0)
                {
                    for (int x = 0; x < listOut[i].errorColumns.Count; x++)
                        dgvDataError.Rows[i].Cells[int.Parse(listOut[i].errorColumns[x])].Style.BackColor = Color.Red;
                }
            }
            dgvDataError.ClearSelection();
        }

        private void UpdateStockOutGrid(OutputItem inItem)
        {
            pts_stockout_log stockoutData = new pts_stockout_log();
            stockoutData.Search(new pts_stockout_log
            {
                issue_cd = inItem.issue_cd,
                stockout_user_cd = inItem.incharge
            }, inItem.item_number, inItem.supplier_invoice, inItem.order_number, inItem.destination_cd, inItem.delivery_date, inItem.delivery_date, true);
            if (stockoutData.listStockOutItem != null)
            {
                outlist = new BindingList<pts_stockout_log>(stockoutData.listStockOutItem);
                dgvStockOutLog.DataSource = outlist;
            }
            if (dgvStockOutLog.Rows.Count > 0)
            {
                for (int i = 0; i < dgvStockOutLog.Rows.Count; i++)
                {
                    dgvStockOutLog.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }
                dgvStockOutLog.Columns["stockout_id"].HeaderText = "ID";
                dgvStockOutLog.Columns["packing_cd"].HeaderText = "Packing Code";
                dgvStockOutLog.Columns["process_cd"].HeaderText = "Process Code";
                dgvStockOutLog.Columns["issue_cd"].HeaderText = "Issue Code";
                dgvStockOutLog.Columns["stockout_date"].HeaderText = "Stock-Out Date";
                dgvStockOutLog.Columns["stockout_user_cd"].HeaderText = "Incharge";
                dgvStockOutLog.Columns["stockout_qty"].HeaderText = "Stoc-Out Qty";
                dgvStockOutLog.Columns["real_qty"].HeaderText = "Real Qty";
                dgvStockOutLog.Columns["received_user_cd"].HeaderText = "Receive User";
                dgvStockOutLog.Columns["comment"].HeaderText = "Comment";
                dgvStockOutLog.Columns["remark"].HeaderText = "Remark";
                dgvStockOutLog.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
        }

        private void timerFormLoad_Tick(object sender, EventArgs e)
        {
            //Nếu đang ở main menu thì cập nhật danh sách file lỗi, ngược lại thì vào chế độ chỉnh sửa
            if (!isEditErrorData)
            {
                UpdateListBoxErrorFiled();
                if (libFileName.Items.Count > 0) btnErrorData.BackColor = Color.Red;
                else btnErrorData.UseVisualStyleBackColor = true;
                btnErrorData.Update();
                btnErrorData.Refresh();
            }
        }
        #endregion

        private void PCForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SettingItem.checkSaved) && bool.Parse(SettingItem.checkSaved) && string.IsNullOrEmpty(UserData.usercode))
            {
                Login logfrm = new Login();
                logfrm.ShowDialog();
            }
            else
            {
                PCForm pcf = new PCForm();
                pcf.ShowDialog();
            }
        }
    }
}
