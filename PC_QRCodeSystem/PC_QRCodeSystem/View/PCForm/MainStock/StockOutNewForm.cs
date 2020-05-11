using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockOutNewForm : FormCommon
    {
        #region VARIABLE
        double labelQty = 0;
        /// <summary>
        /// Biến kiểm tra tem khâu cuối
        /// </summary>
        bool isChecked = false;
        /// <summary>
        /// Biến kiểm tra nguyên liệu còn order number hay không
        /// </summary>
        bool isDeliveried = false;
        /// <summary>
        /// Biến chứa code xuất hàng
        /// </summary>
        string issueFlag = string.Empty;
        /// <summary>
        /// Biến chứa tên noplan/plan trong 2 bảng tương ứng
        /// </summary>
        string processCD = string.Empty;
        /// <summary>
        /// Danh sách tem cần kiểm tra
        /// </summary>
        BindingList<PrintItem> listLabel { get; set; }
        /// <summary>
        /// Danh sách nguyên liệu xuất ra csv
        /// </summary>
        BindingList<OutputItem> listOut { get; set; }
        /// <summary>
        /// Danh sách tem cần in
        /// </summary>
        BindingList<PrintItem> listPrint { get; set; }
        /// <summary>
        /// Danh sách nguyên liệu thay đổi số lượng tồn
        /// </summary>
        BindingList<pts_stock> listStock { get; set; }
        /// <summary>
        /// Danh sách nguyên liệu xuất theo gói tồn kho
        /// </summary>
        BindingList<pts_stockout_log> listStockOut { get; set; }
        #endregion

        #region FORM EVENT
        /// <summary>
        /// Form xuất hàng
        /// </summary>
        public StockOutNewForm()
        {
            InitializeComponent();
            //Ẩn thẻ tab
            tc_Main.ItemSize = new Size(0, 1);
            //Set ngày xuất là ngày hiện tại
            dtpStockOutDate.Value = DateTime.Today;
            //Khai báo các danh sách
            listLabel = new BindingList<PrintItem>();
            listOut = new BindingList<OutputItem>();
            listPrint = new BindingList<PrintItem>();
            listStock = new BindingList<pts_stock>();
            listStockOut = new BindingList<pts_stockout_log>();
        }

        private void StockOutNewForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Lấy dữ liệu vào các combobox
                GetCmb();
                txtUserCode.Select();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Khi nhấn phím Enter
            if (keyData == Keys.Enter)
            {
                //Nhập barcode trong Main menu
                if (ActiveControl == txtBarcode)
                {
                    //Lấy dữ liệu từ barcode điền vào các trường tương ứng
                    #region GET BARCODE INFO
                    string temp = txtBarcode.Text;
                    if (temp.Contains(";"))
                    {
                        string[] barcode = temp.Split(';');
                        txtItemCode.Text = barcode[0].Trim();
                        txtInvoice.Text = barcode[3].Trim();
                        labelQty = double.Parse(barcode[5].Trim());
                        txtStockOutQty.Text = labelQty.ToString();
                    }
                    else
                    {
                        txtItemCode.Text = temp;
                        txtInvoice.ResetText();
                        txtStockOutQty.ResetText();
                    }
                    txtBarcode.ResetText();
                    #endregion
                    //Thực hiện tìm kiếm danh sách nguyên liệu theo mã xuất hàng và mã nguyên liệu
                    MainSearch();
                }
                //Nhập barcode trong set menu
                if (ActiveControl == txtSetBarcode)
                {
                    //Lấy dữ liệu barcode
                    #region GET SET BARCODE INFO
                    string temp = txtSetBarcode.Text;
                    if (temp.Contains(";"))
                    {
                        string[] barcode = temp.Split(';');
                        txtSetItemCD.Text = barcode[0].Trim();
                        txtSetInvoice.Text = barcode[3].Trim();
                        labelQty = double.Parse(barcode[5].Trim());
                        txtSetOutQty.Text = labelQty.ToString();
                        txtSetBarcode.ResetText();
                        //Tìm dòng chứa nguyên liệu tương ứng
                        #region GET INDEX OF ITEM IF IT IS EXIST IN SET LIST
                        try
                        {
                            int rindex = dgvSetData.Rows.Cast<DataGridViewRow>()
                                         .Where(x => x.Cells["low_level_item"].Value.ToString() == barcode[0].Trim())
                                         .Select(x => x.Index).First();
                            dgvSetData.Rows[rindex].Selected = true;
                        }
                        catch (Exception ex)
                        {
                            CustomMessageBox.Error("This item is not exist in set!" + Environment.NewLine + "Nguyên liệu không có trong danh sách!" + Environment.NewLine + ex.Message);
                            txtSetBarcode.ResetText();
                            txtSetInvoice.ResetText();
                            txtSetBarcode.Focus();
                            return true;
                        }
                        #endregion

                        txtSetOutQty.Focus();
                        return true;
                    }
                    else
                    {
                        txtSetItemCD.Text = temp;
                        txtSetInvoice.ResetText();
                        txtSetOutQty.ResetText();
                        txtSetBarcode.ResetText();
                    }
                    #endregion
                }
                //Nhập số lượng xuất sau khi nhập barcode trong set menu
                if (ActiveControl == txtSetOutQty)
                {
                    //Nhập số lượng vào hàng nguyên liệu tương ứng
                    btnSetInputQty.PerformClick();
                    txtSetBarcode.Focus();
                    return true;
                }
                //Nhập số lượng tem cần kiểm tra khâu cuối
                if (ActiveControl == txtInsLabelQty)
                {
                    //Kiểm tra tem
                    #region CHECK LABEL
                    string temp = txtInsBarcode.Text;
                    if (temp.Contains(";"))
                    {
                        string[] barcode = temp.Split(';');
                        //Nếu tem khớp với tem được lưu trong danh sách ListLabel thì OK
                        isChecked = CheckLabel(barcode[0].Trim(), barcode[3].Trim(), double.Parse(barcode[5].Trim()));
                    }
                    else CustomMessageBox.Error("Wrong format barcode!" + Environment.NewLine + "Barcode sai!");
                    txtInsBarcode.ResetText();
                    txtInsBarcode.Focus();
                    return true;
                    #endregion
                }
                //Nhảy đến control kế tiếp
                SelectNextControl(ActiveControl, true, true, true, true);
                return true;
            }
            //Khi nhấn nút ESC
            else if (keyData == Keys.Escape)
            {
                //Lùi lại control trước đó
                SelectNextControl(ActiveControl, false, true, true, true);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region MAIN TAB
        #region BUTTONS EVENT
        private void btnStockOut_Click(object sender, EventArgs e)
        {
            try
            {
                //Nếu mã xuất là 30 thì bắt buộc nhập lí do hủy hàng
                if (issueFlag == "30" && string.IsNullOrEmpty(txtComment.Text))
                {
                    CustomMessageBox.Notice("Need comment when scrap item!" + Environment.NewLine + "Vui lòng điền lí do hủy hàng!");
                    return;
                }
                //Nếu mã xuất là 20 thì mở set menu
                else if (issueFlag == "20")
                {
                    int i = dgvSearch.SelectedRows[0].Index;
                    if (i < 0)
                    {
                        CustomMessageBox.Error("Please select one set!" + Environment.NewLine + "Vui lòng chọn một bộ nguyên liệu!");
                        return;
                    }
                    else OpenSet(i);
                }
                //Các mã xuất còn lại thì xuất thẳng
                else OutNoSet();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Tìm kiếm nguyên liệu
                MainSearch();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            try
            {
                //Nếu trong danh sách có tem cần in thì chuyển vào menu in tem
                if (dgvPrint.Rows.Count > 0) tc_Main.SelectedTab = tab_Print;
                else CustomMessageBox.Notice("No item in print list!" + Environment.NewLine + "Không có tem cần in!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            //Chuyển đến menu kiểm tra khâu cuối
            tc_Main.SelectedTab = tab_Inspection;
            txtInsBarcode.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //Xóa các trường dữ liệu trong main menu
                MainClear();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }
        #endregion

        #region FIELDS EVENT
        //Người dùng
        #region USER
        private void txtUserCode_Validated(object sender, EventArgs e)
        {
            string temp = txtUserCode.Text;
            //Lấy MSNV từ barcode
            if (temp.Contains(";")) temp = temp.Split(';')[0].Trim();
            //Nếu MSNV > 6 thì lấy 6 kí tự cuối
            if (temp.Length > 6) txtUserCode.Text = temp.Substring(temp.Length - 6);
            else txtUserCode.Text = temp;
            try
            {
                //Lấy username
                pre_user muser = new pre_user();
                muser = muser.GetUser(txtUserCode.Text);
                lbUserName.Text = muser.user_name;
                lbUserName.BackColor = Color.Lime;
            }
            catch (Exception ex)
            {
                txtUserCode.Focus();
                lbUserName.Text = "Wrong User Code";
                lbUserName.BackColor = Color.FromKnownColor(KnownColor.Yellow);
                System.Diagnostics.Debug.Print(ex.Message);
            }
        }

        private void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            //Khi user code trống thì label user name về mặc định
            if (string.IsNullOrEmpty(txtUserCode.Text))
            {
                lbUserName.Text = "User Name";
                lbUserName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }
        #endregion
        //Lí do xuất hàng
        #region ISSUE
        private void cmbIssue_Format(object sender, ListControlConvertEventArgs e)
        {
            //Hiển thị mã lí do xuất và tên lí do xuất hàng
            string code = ((pts_issue_code)e.ListItem).issue_cd.ToString();
            string iname = ((pts_issue_code)e.ListItem).issue_name;
            e.Value = code + ": " + iname;
        }

        private void cmbIssue_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Đặt biến issueFlag đại diện mã xuất hàng
            issueFlag = cmbIssue.SelectedValue.ToString();
            //Nếu chọn lí do xuất theo set thì ẩn panel xuất lẻ
            if (cmbIssue.SelectedIndex <= 0)
            {
                tbpNoSet.Visible = false;
                cmbDestination.Enabled = false;
            }
            else
            {
                tbpNoSet.Visible = true;
                cmbDestination.Enabled = true;
                cmbDestination.Focus();
            }
        }

        private void cmbIssue_Validated(object sender, EventArgs e)
        {
            //Nếu không chọn lí do xuất thì không thể chọn qua mục khác
            if (string.IsNullOrEmpty(cmbIssue.Text)) cmbIssue.Select();
        }
        #endregion
        //Phòng ban
        #region DESTINATION
        private void cmbDestination_Format(object sender, ListControlConvertEventArgs e)
        {
            //Hiển thị mã và tên phòng ban
            string code = ((pts_destination)e.ListItem).destination_cd;
            string iname = ((pts_destination)e.ListItem).destination_name;
            e.Value = code + ": " + iname;
        }

        private void cmbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Nếu phòng ban chưa chọn thì không thể qua mục khác
            if (string.IsNullOrEmpty(cmbDestination.Text) && cmbDestination.Enabled) cmbDestination.Select();
        }

        private void cmbDestination_Validated(object sender, EventArgs e)
        {
            //Nếu phòng ban chưa chọn thì không thể qua mục khác
            if (string.IsNullOrEmpty(cmbDestination.Text) && cmbDestination.Enabled) cmbDestination.Select();
        }
        #endregion
        //Nguyên liệu
        #region ITEM
        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Nếu mã nguyên liệu trống thì hiển thị mặc định
                if (string.IsNullOrEmpty(txtItemCode.Text))
                {
                    lbItemName.Text = "Item Name";
                    lbItemName.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                else
                {
                    //Lấy tên item
                    pts_item itemData = new pts_item();
                    itemData = itemData.GetItem(txtItemCode.Text);
                    lbItemName.Text = itemData.item_name;
                    lbItemName.BackColor = Color.Lime;
                }
            }
            catch (Exception ex)
            {
                lbItemName.Text = "Wrong Item Code";
                lbItemName.BackColor = Color.FromKnownColor(KnownColor.Yellow);
                System.Diagnostics.Debug.Print(ex.Message);
                txtBarcode.Focus();
            }
        }
        #endregion
        //Số lượng
        #region ITEM QTY
        private void CheckDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Không cho nhập kí tự vào ô nhập số lượng
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbSign_CheckedChanged(object sender, EventArgs e)
        {
            //Nếu check sign thì trả hàng lại với dấu -
            if (cbSign.Checked) txtStockOutQty.Text = "-" + txtStockOutQty.Text;
            else txtStockOutQty.Text = txtStockOutQty.Text.Replace("-", "");
        }
        #endregion
        //Data
        #region DATAGRIDVIEW
        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //Nếu xuất hàng theo set
            if (issueFlag == "20")
            {
                //Đổi tên button stock out thành open set
                btnStockOut.Text = "9. OPEN SET /" + Environment.NewLine + "Mở Bộ NL";
                //Khi nhấn button open set tại dòng nào thì open set theo dữ liệu dòng đó
                if (e.ColumnIndex == dgvSearch.Columns["btnOpenSet"].Index) OpenSet(e.RowIndex);
            }
            //Các trường hợp xuất hàng khác thì đổi tên button stock out thành stock out
            else btnStockOut.Text = "9. STOCK-OUT /" + Environment.NewLine + "Xuất Hàng";
        }

        private void dgvSearch_DataSourceChanged(object sender, EventArgs e)
        {
            //Khi thay đổi datasource của datagridview
            //Nếu datagridview null thì bỏ qua sự kiện này
            if (dgvSearch.DataSource == null) return;
            //Nếu lí do xuất hàng là theo set thì đổi tên button stock out thành open set
            if (issueFlag == "20") btnStockOut.Text = "9. OPEN SET /" + Environment.NewLine + "Mở Bộ NL";
            //Các lí do khác đổi tên thành stock out
            else btnStockOut.Text = "9. STOCK-OUT /" + Environment.NewLine + "Xuất Hàng";
            dgvSearch.ClearSelection();
        }
        #endregion
        #endregion

        #region SUBS EVENT
        /// <summary>
        /// Get data for issue and destination
        /// </summary>
        private void GetCmb()
        {
            //Lấy dữ liệu issue code vào combobox
            pts_issue_code issueData = new pts_issue_code();
            issueData.GetListIssueCode();
            cmbIssue.DataSource = issueData.listIssueCode;
            cmbIssue.ValueMember = "issue_cd";
            cmbIssue.ResetText();
            //Lấy dữ liệu phòng ban vào combobox
            pts_destination desData = new pts_destination();
            desData.GetListDestination(string.Empty, string.Empty);
            cmbDestination.DataSource = desData.listdestination;
            cmbDestination.ValueMember = "destination_cd";
            cmbDestination.ResetText();
        }

        /// <summary>
        /// Search item
        /// </summary>
        private void MainSearch()
        {
            try
            {
                //Nếu lí do xuất hàng theo set thì tìm kiếm các set theo mã model / order number
                if (issueFlag == "20") SearchItemSet(txtItemCode.Text, txtSetNumber.Text);
                //Các lí do khác tìm kiếm theo mã nguyên liệu
                else SearchNoSet(txtItemCode.Text, txtInvoice.Text);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        /// <summary>
        /// Clear all fields main tab
        /// </summary>
        private void MainClear()
        {
            //RESET TEXTBOX
            txtWHQty.ResetText();
            txtInvoice.ResetText();
            txtComment.ResetText();
            txtUserCode.ResetText();
            txtItemCode.ResetText();
            txtSetNumber.ResetText();
            txtStockOutQty.ResetText();
            //RESET COMBOBOX
            cmbIssue.ResetText();
            cmbDestination.ResetText();
            //CLEAR DGV
            dgvSearch.Columns.Clear();
            dgvSearch.DataSource = null;
            txtUserCode.Select();
            tbpNoSet.Visible = false;
            cmbDestination.Enabled = false;
        }

        /// <summary>
        /// Check empty fields
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            //Kiểm tra các hạng mục có rỗng thì báo lỗi
            if (string.IsNullOrEmpty(txtUserCode.Text))
            {
                CustomMessageBox.Error("User code is empty" + Environment.NewLine + "Vui lòng điền mã số nhân viên!");
                return false;
            }
            if (string.IsNullOrEmpty(txtItemCode.Text) && issueFlag != "20")
            {
                CustomMessageBox.Error("Item code is empty" + Environment.NewLine + "Vui lòng điền mã nguyên liệu!");
                return false;
            }
            if (string.IsNullOrEmpty(cmbIssue.Text))
            {
                CustomMessageBox.Error("Issue code is empty" + Environment.NewLine + "Vui lòng chọn lí do xuất hàng!");
                return false;
            }
            if (string.IsNullOrEmpty(cmbDestination.Text) && issueFlag != "20")
            {
                CustomMessageBox.Error("Destination code is empty" + Environment.NewLine + "Vui lòng chọn phòng ban!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Update datagirdview show no set item
        /// </summary>
        /// <param name="inList"></param>
        private void UpdateGridSearchNoSet(BindingList<pts_stock> inList)
        {
            //Xóa các cột của datagridview
            dgvSearch.Columns.Clear();
            //Nạp dữ liệu tìm kiếm theo mã nguyên liệu vào datagridview
            dgvSearch.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
            //Nạp danh sách nguyên liệu tìm được vào datasource
            dgvSearch.DataSource = inList;
            //Đổi tên các cột datagridview
            dgvSearch.Columns["packing_cd"].HeaderText = "Packing Code";
            dgvSearch.Columns["item_cd"].HeaderText = "Item Number";
            dgvSearch.Columns["supplier_cd"].HeaderText = "Supplier Code";
            dgvSearch.Columns["invoice"].HeaderText = "Invoice";
            dgvSearch.Columns["stockin_date"].HeaderText = "Stock-In Date";
            dgvSearch.Columns["stockin_user_cd"].HeaderText = "Incharge";
            dgvSearch.Columns["stockin_qty"].HeaderText = "Stock-In Qty";
            dgvSearch.Columns["packing_qty"].HeaderText = "Packing Qty";
            //Xóa các cột không cần dùng tới
            if (dgvSearch.Columns.Contains("stock_id")) dgvSearch.Columns.Remove("stock_id");
            if (dgvSearch.Columns.Contains("order_no")) dgvSearch.Columns.Remove("order_no");
            if (dgvSearch.Columns.Contains("registration_user_cd")) dgvSearch.Columns.Remove("registration_user_cd");
            if (dgvSearch.Columns.Contains("registration_date_time")) dgvSearch.Columns.Remove("registration_date_time");
            //Đổi tên button stock out thành stock out
            btnStockOut.Text = "9. STOCK-OUT /" + Environment.NewLine + "Xuất Hàng";
            //Cập nhật datagridview
            dgvSearch.Update();
            dgvSearch.Refresh();
            dgvSearch.ClearSelection();
        }

        /// <summary>
        /// Update datagridview show set item
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="isOld">old set</param>
        private void UpdateGridSearchSet(List<pre_649_order> inList, bool isOld)
        {
            //Xóa các cột datagridview
            dgvSearch.Columns.Clear();
            //Nếu là các set cũ thì tô màu xanh
            if (isOld) dgvSearch.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            //Các set mới tô màu mặc định
            else dgvSearch.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
            //Nạp danh sách set nguyên liệu vào datasource
            dgvSearch.DataSource = inList;
            //Đổi tên các cột
            dgvSearch.Columns["item_number"].HeaderText = "Item Number";
            dgvSearch.Columns["order_number"].HeaderText = "Order Number";
            dgvSearch.Columns["order_qty"].HeaderText = "Order Qty";
            dgvSearch.Columns["order_date"].HeaderText = "Order Date";
            dgvSearch.Columns["supplier_cd"].HeaderText = "Supplier Code";
            //Nếu chưa có cột chứa button open set thì add thêm vào
            if (!dgvSearch.Columns.Contains("btnOpenSet"))
            {
                //Khai báo cột kiểu button
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                //Tên cột
                col.Name = "btnOpenSet";
                //Tên header của cột
                col.HeaderText = "Open Set";
                //Button text
                col.Text = "Open";
                col.UseColumnTextForButtonValue = true;
                dgvSearch.Columns.Insert(0, col);
            }
            //Đổi tên button stock out thành open set
            btnStockOut.Text = "9. OPEN SET /" + Environment.NewLine + "Mở Bộ NL";
            //Cập nhật datagridview
            dgvSearch.Update();
            dgvSearch.Refresh();
            dgvSearch.ClearSelection();
        }
        #endregion
        #endregion

        #region SET TAB
        #region BUTTONS EVENT
        private void btnSetInputQty_Click(object sender, EventArgs e)
        {
            try
            {
                //Nhập liệu vào datagirdview khi nhấn nút input
                InputSet(dgvSetData.SelectedRows[0].Index);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnSetReg_Click(object sender, EventArgs e)
        {
            try
            {
                //Xuất set và in tem
                OutSet();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnSetDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Xóa dữ liệu nguyên liệu được chọn
                DeleteLowItem();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnSetBack_Click(object sender, EventArgs e)
        {
            //Chuyển về main menu
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region SUBS EVENT
        /// <summary>
        /// Input a low level item into list
        /// </summary>
        /// <param name="rindex">row index of item</param>
        private void InputSet(int rindex)
        {
            //Mã nguyên liệu
            string itemCode = txtSetItemCD.Text;
            //Khai báo dữ liệu tồn kho trên database
            pts_stock stockData = new pts_stock();
            //Kiểm tra nguyên liệu đã stock in chưa
            #region CHECK ITEM IS EXIST IN STOCK?
            //Nếu nguyên liệu tồn tại trên database thì sẽ thêm vào danh sách nguyên liệu tồn
            if (!stockData.SearchItem(new pts_stock { item_cd = itemCode, invoice = txtSetInvoice.Text }))
            {
                CustomMessageBox.Error("This item is not exist in stock!" + Environment.NewLine + "Nguyên liệu không có trong kho!");
                txtSetBarcode.ResetText();
                txtSetInvoice.ResetText();
                txtSetBarcode.Focus();
                return;
            }
            #endregion
            //Duyệt đến dòng dữ liệu tương ứng rindex
            DataGridViewRow dr = dgvSetData.Rows[rindex];
            //Khai báo số lượng chuyển
            double deliveryQty = 0;
            //Khai báo số lượng muốn xuất
            double packingQty = double.Parse(txtSetOutQty.Text);
            //Khai báo số lượng yêu cầu
            double orderQty = (double)dr.Cells["request_qty"].Value;
            //Khai báo số lượng xuất hiện tại
            double stockoutQty = (double)dr.Cells["stockout_qty"].Value;
            #region CHECK ITEM QTY
            //Kiểm tra số lượng tồn trên PREMAC
            double whQty = (double)dr.Cells["wh_qty"].Value;
            if (packingQty > whQty)
            {
                CustomMessageBox.Error("This item is not enough in PREMAC!" + Environment.NewLine + "Số lượng hàng tồn trên PREMAC không đủ!");
                return;
            }
            //Kiểm tra số lượng tồn trên SQL DB
            double totalpackingQty = stockData.listStockItems.Sum(x => x.packing_qty);
            if (packingQty > totalpackingQty)
            {
                CustomMessageBox.Error("This item's pack qty is not enough! Please stock-in first!" + Environment.NewLine + "Số lượng hàng không đủ! Cần nhập hàng trước!");
                return;
            }
            #endregion
            //Cộng dồn số lượng xuất
            stockoutQty += packingQty;
            //Nếu số lượng xuất lớn hơn số lượng yêu cầu thì xuất bằng yêu cầu
            if (stockoutQty > orderQty)
            {
                packingQty -= stockoutQty - orderQty;
                stockoutQty = orderQty;
            }
            //Nhập số lượng xuất của nguyên liệu
            dr.Cells["stockout_qty"].Value = stockoutQty;
            //Khai báo supplier
            pts_supplier supplierData = new pts_supplier();

            //Duyệt danh sách nguyên liệu tồn
            foreach (pts_stock item in stockData.listStockItems)
            {
                //Nếu số lượng tồn của gói bằng 0 thì bỏ qua
                if (item.packing_qty == 0) continue;
                //Nếu số lượng xuất nhỏ hơn số lượng tồn của gói thì tách gói
                if (packingQty < item.packing_qty)
                {
                    //Số lượng chuyển = số lượng xuất / gói
                    deliveryQty = packingQty;
                    //Trừ số lượng tồn của gói
                    item.packing_qty -= packingQty;
                    //Thêm item vào danh sách in nếu tách tem
                    #region ADD PRINT ITEM
                    //ADD STOCK-IN TO PRINT LIST
                    listPrint.Add(new PrintItem
                    {
                        Item_Number = item.item_cd,
                        Item_Name = dr.Cells["item_name"].Value.ToString(),
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = item.supplier_cd }).supplier_name,
                        Invoice = txtSetInvoice.Text,
                        Delivery_Date = item.stockin_date,
                        Delivery_Qty = item.packing_qty,
                        SupplierCD = item.supplier_cd,
                        isRec = true,
                        Label_Qty = 1
                    });
                    //ADD STOCK-OUT TO PRINT LIST
                    listPrint.Add(new PrintItem
                    {
                        Item_Number = item.item_cd,
                        Item_Name = dr.Cells["item_name"].Value.ToString(),
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = item.supplier_cd }).supplier_name,
                        Invoice = txtSetInvoice.Text,
                        Delivery_Date = dtpStockOutDate.Value,
                        Delivery_Qty = packingQty,
                        SupplierCD = item.supplier_cd,
                        isRec = false,
                        Label_Qty = 1
                    });
                    #endregion
                    packingQty = 0;
                }
                //Nếu số lượng tồn của gói nhỏ hoặc bằng số lượng xuất / gói
                else
                {
                    //Số lượng chuyển = số lượng tồn
                    deliveryQty = item.packing_qty;
                    //Trừ số lượng xuất / gói
                    packingQty -= item.packing_qty;
                    //Số lượng tồn = 0
                    item.packing_qty = 0;
                }
                #region ADD STOCK OUT ITEM
                string record = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                //Thêm nguyên liệu vào lịch sử xuất
                listStockOut.Add(new pts_stockout_log
                {
                    record_id = record,
                    packing_cd = item.packing_cd,
                    process_cd = txtSetOrderNo.Text,
                    issue_cd = 20,
                    stockout_date = dtpStockOutDate.Value,
                    stockout_user_cd = txtSetUserCD.Text,
                    stockout_qty = deliveryQty,
                    comment = txtComment.Text,
                    remark = "N",
                });
                //Thêm tem nguyên liệu vào danh sách tem kiểm tra
                //Nếu tem đã tồn tại thì cộng dồn lên, nếu chưa thì thêm vào
                try
                {
                    //Lấy index của tem mới quét vào trong danh sách tem kiểm tra
                    int lbindex = listLabel.Where(x => x.Item_Number == item.item_cd
                                                  && x.Invoice == item.invoice && x.Delivery_Qty == deliveryQty)
                                           .Select(x => listLabel.IndexOf(x)).First();
                    //Nếu tồn tại index thì số lượng tem cộng thêm 1
                    listLabel[lbindex].Label_Qty += 1;
                }
                catch
                {
                    //Nếu không tồn tại index thì thêm tem vào danh sách tem kiểm tra
                    listLabel.Add(new PrintItem
                    {
                        Item_Number = item.item_cd,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = item.supplier_cd }).supplier_name,
                        Invoice = item.invoice,
                        Delivery_Date = dtpStockOutDate.Value,
                        Delivery_Qty = deliveryQty,
                        SupplierCD = item.supplier_cd,
                        isRec = false,
                        Label_Qty = 1,
                    });
                }
                #endregion
                //Thêm nguyên liệu vào danh sách xuất CSV
                #region ADD OUTPUT ITEM

                listOut.Add(new OutputItem
                {
                    record_id = record,
                    issue_cd = 20,
                    destination_cd = cmbDestination.SelectedValue.ToString(),
                    item_number = itemCode,
                    supplier_invoice = item.invoice,
                    delivery_qty = deliveryQty,
                    delivery_date = dtpStockOutDate.Value,
                    order_number = txtSetOrderNo.Text,
                    incharge = txtSetUserCD.Text,
                });
                #endregion
                //Thêm nguyên liệu đã chỉnh sửa số lượng vào danh sách nguyên liệu tồn
                listStock.Add(item);
                //Nếu số lượng xuất = 0 thì thoát vòng lặp
                if (packingQty == 0) break;
            }
            //Tô màu những nguyên liệu đã xuất
            dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            //Nếu đủ số lượng yêu cầu thì tô màu lục
            if ((double)dr.Cells["stockout_qty"].Value == orderQty)
                dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Lime);
            txtSetBarcode.ResetText();
            txtSetBarcode.Focus();
        }

        /// <summary>
        /// Stock out list set item
        /// </summary>
        private void OutSet()
        {
            if (CustomMessageBox.Question("Do you want stock-out this set?" + Environment.NewLine + "Bạn có muốn xuất bộ nguyên liệu?") == DialogResult.No)
                return;
            //Xuất các danh sách xuất hàng, tem kiểm tra, danh sách in để in và kiểm tra
            UpdateGridStockOut(listStockOut);
            UpdateGridLabel(listLabel);
            UpdateGridPrint(listPrint);
            CustomMessageBox.Notice("Stock out this set successful! Please print label and check data!" + Environment.NewLine + "Đã xuất bộ nguyên liệu! Vui lòng in tem và kiểm tra!");
            //Nếu danh sách tem cần in > 0 thì đến menu in tem
            if (dgvPrint.Rows.Count > 0) tc_Main.SelectedTab = tab_Print;
            //Ngược lại thì đến menu kiểm tra cuối
            else
            {
                CustomMessageBox.Notice("No item in print list!" + Environment.NewLine + "Không có tem cần in!");
                tc_Main.SelectedTab = tab_Inspection;
                txtInsBarcode.Focus();
            }
        }

        /// <summary>
        /// Delete an item in set
        /// </summary>
        private void DeleteLowItem()
        {
            if (CustomMessageBox.Question("Are you sure delete this item?" + Environment.NewLine + "Bạn có chắc xóa nguyên liệu này?") == DialogResult.No)
                return;
            //Lấy mã nguyên liệu cần xóa
            string itemCD = dgvSetData.SelectedRows[0].Cells["low_level_item"].Value.ToString();
            //Cho số lượng xuất về bằng 0
            dgvSetData.SelectedRows[0].Cells["stockout_qty"].Value = "0";
            //Lấy danh sách các gói nguyên liệu xóa từ danh sách tồn
            var listDel = listStock.Where(x => x.item_cd == itemCD).Select(x => x).ToList();
            //Lấy index của nguyên liệu trong danh sách xuất ra csv
            var outIndex = listOut.Where(x => x.item_number == itemCD).Select(x => listOut.IndexOf(x)).First();
            //Xóa nguyên liệu trong danh sách xuất dựa theo index vừa tìm
            listOut.RemoveAt(outIndex);
            //Duyệt danh sách tem cần in nếu mã nguyên liệu = mã nguyên liệu cần xóa thì xóa
            for (int i = 0; i < listPrint.Count; i++)
            {
                if (listPrint[i].Item_Number == itemCD)
                {
                    listPrint.RemoveAt(i);
                    i--;
                }
            }
            //Duyệt danh sách nguyên liệu cần xóa
            for (int i = 0; i < listDel.Count; i++)
            {
                //Lấy index của gói nguyên liệu cần xóa trong danh sách xuất
                var stockoutIndex = listStockOut.Where(x => x.packing_cd == listDel[i].packing_cd).Select(x => listStockOut.IndexOf(x)).First();
                //Xóa gói nguyên liệu
                listStockOut.RemoveAt(stockoutIndex);
                listDel.RemoveAt(i);
                i--;
            }
            txtSetBarcode.Select();
        }
        #endregion
        #endregion

        #region PRINT TAB
        #region BUTTONS EVENT
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                List<PrintItem> listPrintItems = new List<PrintItem>();
                //Nếu danh sách tem = 0 thì báo lỗi
                if (dgvPrint.Rows.Count == 0)
                {
                    CustomMessageBox.Notice("Don't have item to print!" + Environment.NewLine + "Không có tem cần in!");
                    return;
                }
                //Kiểm tra máy in có online hay không
                if (listPrint[0].CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline" + Environment.NewLine + "Máy in chưa mở!");
                    return;
                }
                //Duyệt danh sách các tem cần in và tô màu
                foreach (DataGridViewRow dr in dgvPrint.Rows)
                {
                    listPrintItems.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                //In danh sách tem
                if (listPrint[0].PrintItems(listPrintItems, false))
                    CustomMessageBox.Notice("Print items are completed!" + Environment.NewLine + "In hoàn tất!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintSelect_Click(object sender, EventArgs e)
        {
            try
            {
                List<PrintItem> listPrintItems = new List<PrintItem>();
                //Nếu không có tem được chọn thì báo lỗi
                if (dgvPrint.SelectedRows.Count == 0)
                {
                    CustomMessageBox.Notice("Don't have item to print!" + Environment.NewLine + "Không có tem cần in!");
                    return;
                }
                //Kiểm tra kết nối máy in
                if (listPrint[0].CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline" + Environment.NewLine + "Máy in chưa mở!");
                    return;
                }
                //Duyệt và tô màu danh sách tem in
                foreach (DataGridViewRow dr in dgvPrint.SelectedRows)
                {
                    listPrintItems.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                //In danh sách tem
                if (listPrint[0].PrintItems(listPrintItems, false))
                    CustomMessageBox.Notice("Print items are completed!" + Environment.NewLine + "In hoàn tất!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintInspection_Click(object sender, EventArgs e)
        {
            //Duyệt danh sách tem in
            foreach (DataGridViewRow dr in dgvPrint.Rows)
            {
                //Nếu còn tem chưa được tô màu thì thông báo
                if (dr.DefaultCellStyle.BackColor != Color.FromKnownColor(KnownColor.ActiveCaption))
                {
                    if (CustomMessageBox.Warring("Have label no print yet! Are you sure continue?" + Environment.NewLine + "Có nhãn chưa in! Bạn có muốn tiếp tục?") == DialogResult.No)
                        return;
                }
            }
            //Tất cả tem được tô màu thì chuyển sang inspection menu
            tc_Main.SelectedTab = tab_Inspection;
            txtInsBarcode.Focus();
        }

        private void btnPrintBack_Click(object sender, EventArgs e)
        {
            //Nếu lí do xuất là 20 thì về lại set menu ngược lại về main menu
            if (issueFlag == "20")
                tc_Main.SelectedTab = tab_Set;
            else
                tc_Main.SelectedTab = tab_Main;
        }
        #endregion
        /// <summary>
        /// Update print grid
        /// </summary>
        /// <param name="inList"></param>
        private void UpdateGridPrint(BindingList<PrintItem> inList)
        {
            //Nhập danh sách tem cần in vào datagridview
            dgvPrint.DataSource = inList;
        }
        #endregion

        #region INSPECTIONS TAB
        #region BUTTONS EVENT
        private void btnInsReg_Click(object sender, EventArgs e)
        {
            try
            {
                //Nếu chưa kiểm tra tem thì báo lỗi
                if (!isChecked)
                {
                    CustomMessageBox.Notice("Please check all label before register!" + Environment.NewLine + "Vui lòng kiểm tra tất cả tem trước khi đăng ký!");
                    return;
                }
                if (CustomMessageBox.Question("Do you want register this data?" + Environment.NewLine + "Bạn có muốn đăng ký dữ liệu này?") == DialogResult.No)
                    return;
                //Nếu lí do xuất là 20 thì thêm lịch sử kế hoạch xuất
                if (issueFlag == "20")
                {
                    pts_plan planData = new pts_plan()
                    {
                        plan_cd = processCD,
                        plan_qty = double.Parse(txtSetRequestQty.Text),
                        plan_date = DateTime.Parse(txtSetRequestDate.Text),
                        set_number = txtSetNumber.Text,
                        model_cd = txtSetModelCD.Text,
                        delivery_date = dtpStockOutDate.Value,
                        plan_usercd = txtSetUserCD.Text,
                        comment = txtComment.Text
                    };
                    planData.Add(planData);
                }
                //Ngược lại thêm lịch sử xuất không kế hoạch
                else
                {
                    pts_noplan noPlanData = new pts_noplan()
                    {
                        noplan_cd = processCD,
                        item_cd = txtItemCode.Text,
                        destination_cd = cmbDestination.SelectedValue.ToString(),
                        noplan_date = dtpStockOutDate.Value,
                        noplan_qty = double.Parse(txtStockOutQty.Text),
                        noplan_usercd = txtUserCode.Text
                    };
                    noPlanData.AddItem(noPlanData);
                }
                //Cập nhật danh sách các gói nguyên liệu tồn kho
                listStock[0].UpdateMultiItem(listStock.ToList());
                //Thêm danh sách các gói nguyên liệu được xuất vào database
                listStockOut[0].AddMultiItem(listStockOut.ToList());
                //Khai báo bảng item và cập nhật số lượng tồn kho
                pts_item itemData = new pts_item();
                itemData.ListStockOutUpdateValue(listOut.ToList());
                //Xuất danh sách nguyên liệu ra file csv
                listOut[0].ExportCSV(listOut.ToList());
                CustomMessageBox.Notice("Register data completed!" + Environment.NewLine + "Dữ liệu được đăng ký hoàn tất!");
                isChecked = false;
                //Xóa các danh sách nguyên liệu hiện có sau khi đăng kí dữ liệu
                ClearDataList();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLabel.SelectedRows.Count <= 0) return;
                int deleteqty = 0;
                int rindex = dgvLabel.SelectedRows[0].Index;
                //Nhập số lượng tem muốn xóa
                InputCommon inputfrm = new InputCommon(false);
                if (inputfrm.ShowDialog() == DialogResult.OK) deleteqty = inputfrm.inputQty;
                if (deleteqty == 0)
                {
                    CustomMessageBox.Error("At least one label must be selected" + Environment.NewLine + "Ít nhất phải chọn 1 tem!");
                    return;
                }
                if (deleteqty > listLabel[rindex].Label_Qty)
                {
                    CustomMessageBox.Error("Delete qty more than label qty!" + Environment.NewLine + "Số lượng xóa lớn hơn số lượng tem hiện có!");
                    return;
                }
                //Tìm index của nguyên liệu muốn xóa trong danh sách xuất file csv
                int outIndex = listOut.Where(x => x.item_number == listLabel[rindex].Item_Number).Select(x => listOut.IndexOf(x)).First();
                //Lấy danh sách các gói của nguyên liệu
                var stockList = listStock.Where(x => x.item_cd == listLabel[rindex].Item_Number && x.invoice == listLabel[rindex].Invoice)
                                         .Select(x => x).ToList();
                int temp = deleteqty;
                //Dò danh sách các gói nguyên liệu
                for (int i = 0; i < stockList.Count; i++)
                {
                    try
                    {
                        //Tìm index của gói trong lịch sử xuất
                        int stockoutIndex = listStockOut.Where(x => x.packing_cd == stockList[i].packing_cd && x.stockout_qty == listLabel[rindex].Delivery_Qty)
                                                    .Select(x => listStockOut.IndexOf(x)).First();
                        //Tìm index của gói trong danh sách các gói
                        int stockIndex = listStock.Where(x => x.packing_cd == listStockOut[stockoutIndex].packing_cd).Select(x => listStock.IndexOf(x)).First();
                        //Xóa gói
                        listStock.RemoveAt(stockIndex);
                        listStockOut.RemoveAt(stockoutIndex);
                        temp--;
                        if (temp == 0) break;
                    }
                    catch { continue; }//Nếu không phải gói cần xóa thì bỏ qua
                }
                //Trừ số lượng xuất của nguyên liệu, nếu bằng 0 thì xóa nguyên liệu
                listOut[outIndex].delivery_qty -= listLabel[rindex].Delivery_Qty * deleteqty;
                if (listOut[outIndex].delivery_qty == 0) listOut.RemoveAt(outIndex);
                //Trừ số lượng tem xuất, nếu số lượng tem bằng 0 thì xóa loại tem đó
                listLabel[rindex].Label_Qty -= deleteqty;
                if (listLabel[rindex].Label_Qty == 0) listLabel.RemoveAt(rindex);
                UpdateGridStockOut(listStockOut);
                UpdateGridLabel(listLabel);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInsClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomMessageBox.Warring("Data is not register! Are you sure to clear all?" + Environment.NewLine + "Dữ liệu chưa được đăng ký! Bạn có chắc muốn xóa?") == DialogResult.No) return;
                ClearDataList();
                CustomMessageBox.Notice("Clear all data!" + Environment.NewLine + "Đã xóa toàn bộ dữ liệu!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInsBack_Click(object sender, EventArgs e)
        {
            //Nếu các danh sách nguyên liệu và tem khác rỗng thì cảnh báo
            if (dgvLabel.Rows.Count > 0 && dgvStockOut.Rows.Count > 0)
            {
                if (CustomMessageBox.Warring("If you go back, the current data is clear. Are you sure to go back?" + Environment.NewLine + "Nếu bạn trở lại menu chính, dữ liệu hiện tại sẽ bị xóa. Bạn có chắc muốn trở lại?") == DialogResult.No)
                    return;
            }
            //Xóa hết các danh sach dữ liệu và trở lại main menu
            ClearDataList();
            tc_Main.SelectedTab = tab_Main;
        }
        #endregion

        #region SUBS EVENT
        /// <summary>
        /// Clear all list item
        /// </summary>
        private void ClearDataList()
        {
            listOut.Clear();
            listLabel.Clear();
            listPrint.Clear();
            listStock.Clear();
            listStockOut.Clear();
        }

        /// <summary>
        /// Update datagridview of list label stock out
        /// </summary>
        /// <param name="inlist"></param>
        private void UpdateGridLabel(BindingList<PrintItem> inlist)
        {
            dgvLabel.Columns.Clear();
            dgvLabel.DataSource = null;
            dgvLabel.DataSource = inlist;
            //Nếu không tồn tại cột check_qty thì thêm vào
            if (!dgvLabel.Columns.Contains("check_qty"))
            {
                DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
                dc.Name = "check_qty";
                dc.HeaderText = "Check Qty";
                dgvLabel.Columns.Add(dc);
            }
            dgvSearch.Update();
            dgvSearch.Refresh();
        }

        /// <summary>
        /// Update datagridview of stock out history
        /// </summary>
        /// <param name="inList"></param>
        private void UpdateGridStockOut(BindingList<pts_stockout_log> inList)
        {
            dgvStockOut.DataSource = inList;
            dgvStockOut.Columns["process_cd"].HeaderText = "Process Code";
            dgvStockOut.Columns["issue_cd"].HeaderText = "Issue Code";
            dgvStockOut.Columns["stockout_date"].HeaderText = "Stock-out date";
            dgvStockOut.Columns["stockout_user_cd"].HeaderText = "Incharge";
            dgvStockOut.Columns["stockout_qty"].HeaderText = "Stock-out Qty";
            dgvStockOut.Columns["comment"].HeaderText = "Comment";
            dgvStockOut.Columns["remark"].HeaderText = "Remark";
            if (dgvStockOut.Columns.Contains("stockout_id")) dgvStockOut.Columns.Remove("stockout_id");
            if (dgvStockOut.Columns.Contains("real_qty")) dgvStockOut.Columns.Remove("real_qty");
            if (dgvStockOut.Columns.Contains("received_user_cd")) dgvStockOut.Columns.Remove("received_user_cd");
            dgvSearch.Update();
            dgvSearch.Refresh();
        }

        /// <summary>
        /// Check label before register
        /// </summary>
        /// <param name="itemCD"></param>
        /// <param name="invoice"></param>
        /// <param name="deliveryQty"></param>
        /// <returns></returns>
        private bool CheckLabel(string itemCD, string invoice, double deliveryQty)
        {
            try
            {
                int lbQty = int.Parse(txtInsLabelQty.Text);
                int rindex = 0;
                try
                {
                    //Lấy index của tem nếu tem có trong danh sách
                    rindex = listLabel.Where(x => x.Item_Number == itemCD && x.Invoice == invoice && x.Delivery_Qty == deliveryQty)
                                         .Select(x => listLabel.IndexOf(x)).First();
                }
                catch
                {
                    CustomMessageBox.Error("This label not in list!" + Environment.NewLine + "Tem không trong danh sách!");
                    return false;
                }
                dgvLabel.Rows[rindex].Cells["check_qty"].Value = lbQty * deliveryQty;
                for (int i = 0; i < dgvLabel.Rows.Count; i++)
                {
                    int lb = (int)dgvLabel.Rows[i].Cells["Label_Qty"].Value;
                    double dQty = (double)dgvLabel.Rows[i].Cells["Delivery_Qty"].Value;
                    //Nếu số lượng của tem kiểm tra đúng với số lượng tem trong danh sách thì duyệt
                    if ((lb * dQty) == (lbQty * deliveryQty) && i == rindex)
                    {
                        listLabel[i].Remark = "Checked";
                        dgvLabel.Rows[i].DefaultCellStyle.BackColor = Color.Lime;
                    }
                }
                var listChecked = listLabel.Where(x => x.Remark == "Checked").Select(x => x).ToList();
                if (listChecked.Count == listLabel.Count) return true;
                else return false;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
                return false;
            }
        }
        #endregion
        #endregion

        #region NO SET EVENT
        /// <summary>
        /// Search no set items
        /// </summary>
        /// <param name="itemNumber">item number</param>
        /// <param name="invoiceText">invoice</param>
        private void SearchNoSet(string itemNumber, string invoiceText)
        {
            try
            {
                //Lấy giá trị tồn kho của nguyên liệu
                pts_item itemdata = new pts_item();
                itemdata = itemdata.GetItem(itemNumber);
                double totalWHQty = itemdata.wh_qty;
                txtWHQty.Text = totalWHQty.ToString();
                //Lấy tổng số lượng các gói nguyên liệu trong stock
                pts_stock stockdata = new pts_stock();
                stockdata.SearchItem(new pts_stock { item_cd = itemNumber, invoice = invoiceText }, false);
                double totalPackingQty = stockdata.listStockItems.Select(x => x.packing_qty).Sum();
                txtTotalPackingQty.Text = totalPackingQty.ToString();
                //Cập nhật danh sách tìm kiếm không theo set
                UpdateGridSearchNoSet(stockdata.listStockItems);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        /// <summary>
        /// Create list stock, list stock out, list print of no set item
        /// </summary>
        private void OutNoSet()
        {
            //Kiểm tra rỗng các hạng mục trong main menu
            if (!CheckFields()) return;
            //Khai báo số lượng chuyển
            double deliveryQty = 0;
            //Khai báo số lượng tồn kho
            double whQty = double.Parse(txtWHQty.Text);
            //Khai báo số lượng xuất
            double stockoutQty = double.Parse(txtStockOutQty.Text);
            //Khai báo tổng số lượng các gói nguyên liệu trong stock
            double totalPackQty = double.Parse(txtTotalPackingQty.Text);
            //Kiểm tra số lượng xuất
            if (stockoutQty == 0 || string.IsNullOrEmpty(txtStockOutQty.Text))
            {
                CustomMessageBox.Notice("Please fill Stock-Out Q'ty" + Environment.NewLine + "Vui lòng điền số lượng cần xuất!");
                return;
            }
            //Kiểm tra số lượng tồn kho trong PREMAC và SQL DB
            if (stockoutQty > whQty || stockoutQty > totalPackQty)
            {
                CustomMessageBox.Notice("Stock-Out Q'ty can't more than Stock Q'ty!" + Environment.NewLine + "Số lượng xuất không thể lớn hơn số lượng tồn!");
                return;
            }
            //Số lượng tồn = số lượng tồn trừ số lượng xuất
            txtWHQty.Text = (whQty - stockoutQty).ToString();
            //Khai báo mã xuất không theo set
            processCD = "NP-" + dtpStockOutDate.Value.ToString("yyyyMMdd");
            //Khai báo truy xuất stock và supplier
            pts_stock stockData = new pts_stock();
            pts_supplier supplierData = new pts_supplier();
            //Dựa theo danh sách các gói nguyên liệu tìm được
            for (int i = 0; i < dgvSearch.Rows.Count; i++)
            {
                //Lấy dữ liệu từng gói nguyên liệu
                stockData = dgvSearch.Rows[i].DataBoundItem as pts_stock;
                //Nếu số lượng tồn của gói = 0 thì bỏ qua
                if (stockData.packing_qty == 0) continue;
                //Nếu số lượng xuất lớn hơn hoặc bằng số lượng tồn
                if (stockoutQty >= stockData.packing_qty)
                {
                    //Số lượng chuyển = số lượng tồn
                    deliveryQty = stockData.packing_qty;
                    //Số lượng xuất trừ số lượng tồn
                    stockoutQty -= stockData.packing_qty;
                    //Số lượng tồn  = 0
                    stockData.packing_qty = 0;
                }
                //Nếu số lượng tồn lớn hơn số lượng xuất
                else
                {
                    //Số lượng chuyển = số lượng xuất
                    deliveryQty = stockoutQty;
                    //Số lượng xuất = 0
                    stockoutQty = 0;
                    //Số lượng tồn trừ số lượng xuất
                    stockData.packing_qty -= deliveryQty;
                    //Thêm tem cần in vào danh sách
                    #region ADD PRINT ITEM
                    //Thêm tem nguyên liệu tồn
                    listPrint.Add(new PrintItem
                    {
                        Item_Number = txtItemCode.Text,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = stockData.supplier_cd }).supplier_name,
                        Invoice = stockData.invoice,
                        Delivery_Date = stockData.stockin_date,
                        Delivery_Qty = stockData.packing_qty,
                        SupplierCD = stockData.supplier_cd,
                        isRec = true,
                        Label_Qty = 1,
                    });
                    //Thêm tem nguyên liệu xuất
                    listPrint.Add(new PrintItem
                    {
                        Item_Number = txtItemCode.Text,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = stockData.supplier_cd }).supplier_name,
                        Invoice = stockData.invoice,
                        Delivery_Date = dtpStockOutDate.Value,
                        Delivery_Qty = deliveryQty,
                        SupplierCD = stockData.supplier_cd,
                        isRec = false,
                        Label_Qty = 1,
                    });
                    #endregion
                }
                //Thêm nguyên liệu cần xuất và tem cần kiểm tra vào danh sách
                #region ADD LIST STOCK-OUT AND LABEL
                //Thêm nguyên liệu cần xuất vào danh sách
                string record = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                listStockOut.Add(new pts_stockout_log
                {
                    record_id = record,
                    packing_cd = stockData.packing_cd,
                    process_cd = processCD,
                    issue_cd = (int)cmbIssue.SelectedValue,
                    stockout_date = dtpStockOutDate.Value,
                    stockout_user_cd = txtUserCode.Text,
                    stockout_qty = deliveryQty,
                    comment = txtComment.Text,
                    remark = "N",
                });
                try
                {
                    //Lấy index của tem vừa xuất, nếu tồn tại thì số lượng tem + 1
                    int lbindex = listLabel.Where(x => x.Item_Number == txtItemCode.Text && x.Invoice == stockData.invoice && x.Delivery_Qty == deliveryQty)
                                           .Select(x => listLabel.IndexOf(x)).First();
                    listLabel[lbindex].Label_Qty += 1;
                }
                catch
                {
                    //Nếu không tồn tại index thì thêm tem vào danh sách tem cần kiểm tra
                    listLabel.Add(new PrintItem
                    {
                        Item_Number = txtItemCode.Text,
                        Item_Name = lbItemName.Text,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = stockData.supplier_cd }).supplier_name,
                        Invoice = stockData.invoice,
                        Delivery_Date = dtpStockOutDate.Value,
                        Delivery_Qty = deliveryQty,
                        SupplierCD = stockData.supplier_cd,
                        isRec = false,
                        Label_Qty = 1,
                    });
                }
                #endregion
                //Thêm nguyên liệu cần xuất vào danh sách xuất ra file csv
                #region ADD OUT ITEM
                listOut.Add(new OutputItem
                {
                    record_id = record,
                    issue_cd = (int)cmbIssue.SelectedValue,
                    destination_cd = cmbDestination.SelectedValue.ToString(),
                    item_number = txtItemCode.Text,
                    supplier_invoice = stockData.invoice,
                    delivery_qty = deliveryQty,
                    delivery_date = dtpStockOutDate.Value,
                    order_number = string.Empty,
                    incharge = txtUserCode.Text,
                });
                #endregion
                //Thêm gói nguyên liệu tồn vào danh sách nguyên liệu tồn
                listStock.Add(stockData);
                //Nếu số lượng xuất = 0 thì thoát vòng lặp
                if (stockoutQty == 0) break;
            }
            CustomMessageBox.Notice("Stock out " + txtItemCode.Text + " successful! Qty: " + txtStockOutQty.Text + Environment.NewLine + "Xuất " + txtItemCode.Text + " thành công! Số lượng: " + txtStockOutQty.Text);
            //Cập nhật các danh sách nguyên liệu xuất, tem cần in, tem cần kiểm tra
            UpdateGridStockOut(listStockOut);
            UpdateGridLabel(listLabel);
            UpdateGridPrint(listPrint);
        }
        #endregion

        #region SET EVENT
        /// <summary>
        /// Search item set and order number
        /// </summary>
        /// <param name="itemNumber">model number</param>
        /// <param name="setNumber">order number</param>
        private void SearchItemSet(string itemNumber, string setNumber)
        {
            try
            {
                //Tìm kiếm order number của các set chưa được xuất
                //Tìm danh sách các order number từ menu 6-4-9 (mới)
                pre_649_order orderData = new pre_649_order();
                orderData.Search(new pre_649_order
                {
                    item_number = itemNumber,
                    order_number = setNumber
                });
                isDeliveried = false;
                //Tìm các order các set đã xuất (khuyến nghị tìm kiếm theo số order number)
                if (orderData.listOrderItem.Count <= 0)
                {
                    isDeliveried = true;
                    //Tìm danh sách các order number từ menu 6-4-9 (cũ)
                    pre_649 deliveriedData = new pre_649();
                    deliveriedData.SearchOrder(new pre_649
                    {
                        item_number = itemNumber,
                        order_number = setNumber
                    });
                    //Chuyển danh sách các order number từ bảng 6-4-9 sang bảng 6-4-9 order
                    orderData.listOrderItem = deliveriedData.listPremacItem.Select(x => new pre_649_order
                    {
                        item_number = x.item_number,
                        supplier_cd = x.supplier_cd,
                        order_number = x.order_number,
                        order_date = x.order_date,
                        order_qty = x.order_qty,
                    }).ToList();
                    //Cập nhật danh sách tìm kiếm theo set (có tô màu)
                    UpdateGridSearchSet(orderData.listOrderItem, true);
                }
                //Cập nhật danh sách tìm kiếm theo set (không tô màu)
                else UpdateGridSearchSet(orderData.listOrderItem, false);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        /// <summary>
        /// Open set
        /// </summary>
        /// <param name="RowIndex">index of row in list item set</param>
        private void OpenSet(int RowIndex)
        {
            //Kiểm tra rỗng các hạng mục dữ liệu main menu
            if (!CheckFields()) return;
            //Khai báo order number
            string orderNo = string.Empty;
            //Lấy dữ liệu hàng được chọn
            DataGridViewRow dr = dgvSearch.Rows[RowIndex];
            //Nếu textbox order number rỗng thì lấy order number từ dữ liệu được chọn
            if (string.IsNullOrEmpty(txtSetNumber.Text))
                orderNo = dr.Cells["order_number"].Value.ToString();
            else
                orderNo = txtSetNumber.Text;
            //Nhập các hạng mục giá trị từ main menu sang set menu
            GetSetOptions(dr.Cells["item_number"].Value.ToString(), orderNo, (double)dr.Cells["order_qty"].Value, (DateTime)dr.Cells["order_date"].Value);
            //Tìm kiếm danh sách nguyên liệu theo set model
            SearchLowItem(dr.Cells["item_number"].Value.ToString(), (double)dr.Cells["order_qty"].Value, orderNo);
            //Chuyển sang set menu
            tc_Main.SelectedTab = tab_Set;
            //Kiểm tra theo menu 6-5-5
            pre_655 issueData = new pre_655();
            pts_stockout_log stockoutData = new pts_stockout_log();
            double temp = 0;
            //Duyệt danh sách nguyên liệu theo set
            for (int i = 0; i < dgvSetData.Rows.Count; i++)
            {
                //Lấy số lượng nguyên liệu được xuất cho order number hiện tại
                temp = stockoutData.GetStockOutQty(orderNo, dgvSetData.Rows[i].Cells["low_level_item"].Value.ToString());
                //Nếu số lượng xuất = 0
                if (temp == 0)
                {
                    //Tìm kiếm trong bảng 655
                    issueData.Search(new pre_655
                    {
                        low_level_item = dgvSetData.Rows[i].Cells["low_level_item"].Value.ToString(),
                        high_level_item = txtSetModelCD.Text,
                        order_number = orderNo
                    });
                    try
                    {
                        //Lấy số lượng chưa được xuất của nguyên liệu từ menu 6-5-5
                        temp = issueData.listIssueItem[0].no_issue_qty;
                        //Nếu số lượng chưa được xuất > 0 
                        //thì số lượng yêu cầu của nguyên liệu trong set = số lượng chưa được xuất
                        if (temp > 0) dgvSetData.Rows[i].Cells["request_qty"].Value = temp;
                    }
                    catch
                    {
                        //Nếu nguyên liệu không tồn tại trong menu 655 nhưng mã order number đã chuyển 
                        //thì số lượng yêu cầu của nguyên liệu trong set = 0
                        if (isDeliveried) dgvSetData.Rows[i].Cells["request_qty"].Value = 0;
                    }
                }
                //Nếu số lượng xuất khác 0 thì số lượng yêu cầu của nguyên liêu sẽ trừ số lượng đã xuất
                else
                    dgvSetData.Rows[i].Cells["request_qty"].Value = (double)dgvSetData.Rows[i].Cells["request_qty"].Value - temp;
            }
            txtSetBarcode.Select();
        }

        /// <summary>
        /// Search list low item of item set
        /// </summary>
        /// <param name="hiItem">model number</param>
        /// <param name="orderQty">request qty</param>
        /// <param name="orderNumber">order number</param>
        private void SearchLowItem(string hiItem, double orderQty, string orderNumber)
        {
            //Khai báo dữ liệu menu 223
            pre_223 structData = new pre_223();
            List<pre_223_view> listData = new List<pre_223_view>();
            //Tìm kiếm danh sách nguyên liệu theo set tương ứng với model
            listData = structData.Search(hiItem, orderQty);
            dgvSetData.DataSource = listData;
            dgvSetData.Columns["low_level_item"].HeaderText = "Part Number";
            dgvSetData.Columns["item_name"].HeaderText = "Part Name";
            dgvSetData.Columns["item_location"].HeaderText = "Location";
            dgvSetData.Columns["item_unit"].HeaderText = "Unit";
            dgvSetData.Columns["request_qty"].HeaderText = "Request Qty";
            dgvSetData.Columns["wh_qty"].HeaderText = "W/H Qty";
            dgvSetData.Columns["stockout_qty"].HeaderText = "Stock-Out Qty";
            dgvSetData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        /// <summary>
        /// Get data field in main tab to set tab
        /// </summary>
        /// <param name="orderNo">order number</param>
        /// <param name="orderQty">request qty</param>
        /// <param name="orderDate">request date</param>
        private void GetSetOptions(string modelCode, string orderNo, double orderQty, DateTime orderDate)
        {
            //Chuyển dữ liệu từ main menu sang set menu
            txtSetOrderNo.Text = orderNo;
            txtSetUserCD.Text = txtUserCode.Text;
            txtSetModelCD.Text = modelCode;
            txtSetRequestQty.Text = orderQty.ToString();
            txtSetRequestDate.Text = orderDate.ToString("yyyy-MM-dd");
            txtSetOutDate.Text = dtpStockOutDate.Value.ToString("yyyy-MM-dd");
            lbSetUserName.Text = lbUserName.Text;
            pts_item itemData = new pts_item();
            itemData = itemData.GetItem(modelCode);
            lbSetModelName.Text = itemData.item_name;
            //txtSetDesCD.Text = cmbDestination.SelectedValue.ToString();
            //lbSetDesName.Text = cmbDestination.Text.Split(':')[1].Trim();
        }
        #endregion

        private void tc_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = "Stock Out - " + tc_Main.SelectedTab.Text;
            this.Update();
            this.Refresh();
        }
    }
}
