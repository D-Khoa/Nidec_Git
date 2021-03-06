﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class StockOutForm : FormCommon
    {
        #region VARIABLE
        private pre_649 pre649Data { get; set; }

        private OutputItem outData { get; set; }
        private PrintItem printData { get; set; }
        private List<PrintItem> listPrintItems { get; set; }

        private pts_stock stockData { get; set; }
        private List<pts_stock> listStock { get; set; }

        private pts_noplan noplanData { get; set; }
        private List<pts_noplan> listNoPlan { get; set; }

        private pts_plan planData { get; set; }
        private List<pts_plan> listPlan { get; set; }

        private pts_stockout_log stockOutData { get; set; }
        private List<pts_stockout_log> listStockOut { get; set; }

        private pts_item itemData { get; set; }
        private pts_supplier supplierData { get; set; }
        private m_mes_user mUserData { get; set; }
        private pts_issue_code issueCode { get; set; }
        private pts_destination destinationData { get; set; }
        private ErrorProvider errorProvider = new ErrorProvider();
        #endregion

        #region FORM EVENT
        public StockOutForm()
        {
            InitializeComponent();
            tc_Main.ItemSize = new Size(0, 1);
            pre649Data = new pre_649();
            planData = new pts_plan();
            itemData = new pts_item();
            outData = new OutputItem();
            stockData = new pts_stock();
            printData = new PrintItem();
            mUserData = new m_mes_user();
            noplanData = new pts_noplan();
            issueCode = new pts_issue_code();
            supplierData = new pts_supplier();
            stockOutData = new pts_stockout_log();
            destinationData = new pts_destination();
            listPlan = new List<pts_plan>();
            listStock = new List<pts_stock>();
            listNoPlan = new List<pts_noplan>();
            listPrintItems = new List<PrintItem>();
            listStockOut = new List<pts_stockout_log>();
        }

        private void StockOutForm_Load(object sender, EventArgs e)
        {
            GetCmb();
        }
        #endregion

        #region STOCK-OUT NO PLANNED
        #region BUTTONS EVENT
        private void btnNoPlanRegister_Click(object sender, EventArgs e)
        {
            try
            {
                #region CHECK INFO BEFORE ADD ITEM
                //Check item empty
                if (string.IsNullOrEmpty(txtNoPlanItemCD.Text))
                {
                    CustomMessageBox.Notice("Item can't empty! Please check and scan barcode again!");
                    return;
                }
                //Check issue code empty
                if (string.IsNullOrEmpty(cmbNoPlanIssueCD.Text))
                {
                    errorProvider.SetError(cmbNoPlanIssueCD, "Please choose issue code!");
                    return;
                }
                //Check destination empty
                if (string.IsNullOrEmpty(cmbNoPlanDestinationCD.Text))
                {
                    errorProvider.SetError(cmbNoPlanDestinationCD, "Please choose destination!");
                    return;
                }
                //Check user code empty
                if (string.IsNullOrEmpty(txtNoPlanUserCD.Text))
                {
                    errorProvider.SetError(txtNoPlanUserCD, "Please fill user code!");
                    return;
                }
                //Check stock-in-hand qty
                if (double.Parse(txtNoPlanWHQty.Text) == 0)
                {
                    CustomMessageBox.Notice("Don't have item in stock. Please check and try again!");
                    return;
                }
                //Check stock-out qty
                if (string.IsNullOrEmpty(txtNoPlanStockOutQty.Text) || double.Parse(txtNoPlanStockOutQty.Text) == 0)
                {
                    CustomMessageBox.Notice("Please fill stock-out qty!");
                    return;
                }
                //When issue code is 30 then required fill comment
                if (cmbNoPlanIssueCD.SelectedValue.ToString() == "30" && string.IsNullOrEmpty(txtNoPlanComment.Text))
                {
                    CustomMessageBox.Notice("Please fill comment when Scrap Item!");
                    return;
                }
                double stockOutQty = double.Parse(txtNoPlanStockOutQty.Text);
                //If stock out qty > packing qty then alert
                if (stockOutQty > double.Parse(txtNoPlanWHQty.Text))
                {
                    //if (CustomMessageBox.Warring("Stock-out qty is over than stock-in-hand qty!" + Environment.NewLine + "Are you sure to continue?") == DialogResult.No)
                    CustomMessageBox.Notice("Stock-out qty is over than stock-in-hand qty! Please set another!");
                    return;
                }
                if (CustomMessageBox.Question("Are you sure add this stock-out item?") == DialogResult.No) return;
                #endregion

                double temp;
                string processcd = string.Empty;
                if (txtNoPlanSetNumber.ReadOnly)
                {
                    #region ADD NEW NO-PLAN
                    processcd = "NP" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                    //Add noplan item into list
                    listNoPlan.Add(new pts_noplan
                    {
                        noplan_cd = processcd,
                        destination_cd = cmbNoPlanDestinationCD.SelectedValue.ToString(),
                        item_cd = txtNoPlanItemCD.Text,
                        noplan_qty = stockOutQty,
                        noplan_usercd = txtNoPlanUserCD.Text,
                        noplan_date = dtpNoPlanStockOutDate.Value,
                    });
                    #endregion
                    //Update grid in inspection tab
                    UpdateProcessGrid(0);
                    //Check all packing in dgv
                    foreach (DataGridViewRow dr in dgvNoPlan.Rows)
                    {
                        //Get packing stockOutQty & packing code
                        stockData = dr.DataBoundItem as pts_stock;

                        //If packing is empty then skip it
                        if (!cbSign.Checked && stockData.packing_qty <= 0) continue;

                        //Get item info
                        itemData = itemData.GetItem(stockData.item_cd);
                        //Get supplier
                        supplierData = supplierData.GetSupplier(new pts_supplier { supplier_cd = stockData.supplier_cd });

                        #region ADD STOCK-OUT ITEM
                        //If stock-out qty > packing qty then stock-out next pack
                        if (stockOutQty > stockData.packing_qty)
                        {
                            temp = stockData.packing_qty;
                            stockOutQty = stockOutQty - stockData.packing_qty;
                        }
                        else //When stock-out qty < pack qty then get a number = stock-out qty
                        {
                            temp = stockOutQty;
                            stockOutQty = 0;
                        }
                        //Add stock-out item into a list
                        listStockOut.Add(new pts_stockout_log
                        {
                            packing_cd = stockData.packing_cd,
                            process_cd = processcd,
                            issue_cd = (int)cmbNoPlanIssueCD.SelectedValue,
                            stockout_date = dtpNoPlanStockOutDate.Value,
                            stockout_user_cd = txtNoPlanUserCD.Text,
                            stockout_qty = temp,
                            comment = txtNoPlanComment.Text,
                            remark = "N",
                        });
                        #region ADD LIST LABEL STOCK-OUT AND LIST ITEM FOR CSV
                        //Add new label stock-out
                        printData.ListPrintItem.Add(new PrintItem
                        {
                            Item_Number = txtNoPlanItemCD.Text,
                            Item_Name = itemData.item_name,
                            SupplierName = supplierData.supplier_name,
                            Invoice = txtNoPlanInvoice.Text,
                            Delivery_Date = dtpNoPlanStockOutDate.Value,
                            Delivery_Qty = temp,
                            SupplierCD = supplierData.supplier_cd,
                            //OrderNo = stockData.order_no,
                            isRec = false,
                            Label_Qty = 1
                        });
                        //Add Output item
                        outData.listOutputItem.Add(new OutputItem
                        {
                            issue_cd = (int)cmbNoPlanIssueCD.SelectedValue,
                            destination_cd = cmbNoPlanDestinationCD.SelectedValue.ToString(),
                            item_number = txtNoPlanItemCD.Text,
                            //item_name = itemData.item_name,
                            //supplier_cd = supplierData.supplier_cd,
                            //supplier_name = supplierData.supplier_name,
                            //supplier_invoice = txtNoPlanInvoice.Text,
                            //order_number = stockData.order_no,
                            delivery_date = dtpNoPlanStockOutDate.Value,
                            delivery_qty = temp,
                            incharge = txtNoPlanUserCD.Text,
                        });
                        #endregion
                        #endregion

                        #region CALCULATOR, ADD LIST STOCK ITEM AND ADD LIST LABEL STOCK-ON-HAND
                        //Calculator pack qty in stock
                        stockData.packing_qty = stockData.packing_qty - temp;
                        listStock.Add(stockData);
                        //Add new label stock-in when it not empty
                        if (stockData.packing_qty > 0)
                        {
                            printData.ListPrintItem.Add(new PrintItem
                            {
                                Item_Number = txtNoPlanItemCD.Text,
                                Item_Name = itemData.item_name,
                                SupplierName = supplierData.supplier_name,
                                Invoice = txtNoPlanInvoice.Text,
                                Delivery_Date = stockData.stockin_date,
                                Delivery_Qty = stockData.packing_qty,
                                SupplierCD = supplierData.supplier_cd,
                                //OrderNo = stockData.order_no,
                                isRec = true,
                                Label_Qty = 1
                            });
                        }
                        #endregion

                        //If get enough stock-out qty then break
                        if (stockOutQty == 0) break;
                    }
                    btnNoPlanInspection.Visible = true;
                    if (CustomMessageBox.Question("Successful!. Do you want go to Inspection Tab to see it?") == DialogResult.Yes)
                        tc_Main.SelectedTab = tab_Inspection;
                }
                else
                {
                    #region ADD NEW PLAN
                    listPlan.Clear();
                    processcd = "P" + txtNoPlanSetNumber.Text;
                    listPlan.Add(new pts_plan
                    {
                        plan_cd = processcd,
                        model_cd = txtNoPlanItemCD.Text,
                        set_number = txtNoPlanSetNumber.Text,
                        destination_cd = cmbNoPlanDestinationCD.SelectedValue.ToString(),
                        plan_qty = stockOutQty,
                        plan_usercd = txtNoPlanUserCD.Text,
                        plan_date = dtpNoPlanStockOutDate.Value,
                        delivery_date = dtpNoPlanStockOutDate.Value.AddDays(7),
                        comment = txtNoPlanComment.Text
                    });
                    #endregion
                    //Update grid in inspection tab
                    UpdateProcessGrid(1);
                    txtNoPlanItemCD.Clear();
                    tc_Main.SelectedTab = tab_Plan;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnNoPlanSearch_Click(object sender, EventArgs e)
        {
            UpdateNoPlanGrid(true);
        }

        private void btnNoPlanInspection_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_Inspection;
        }

        private void btnNoPlanSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingFrm = new SettingForm();
            settingFrm.ShowDialog();
        }

        private void btnNoplanClear_Click(object sender, EventArgs e)
        {
            ClearNoPlan();
        }
        #endregion

        #region FIELDS EVENT
        private void cmbNoPlanIssueCD_Format(object sender, ListControlConvertEventArgs e)
        {
            string code = ((pts_issue_code)e.ListItem).issue_cd.ToString();
            string iname = ((pts_issue_code)e.ListItem).issue_name;
            e.Value = code + ": " + iname;
        }

        private void cmbNoPlanDestinationCD_Format(object sender, ListControlConvertEventArgs e)
        {
            string code = ((pts_destination)e.ListItem).destination_cd;
            string iname = ((pts_destination)e.ListItem).destination_name;
            e.Value = code + ": " + iname;
        }

        private void txtItemCDStockOut_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtNoPlanItemCD, null);
            errorProvider.SetError(txtPlanItemCD, null);
            lbPlanItem.Text = "Item Name";
            lbNoPlanItem.Text = "Item Name";
            lbPlanItem.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            lbNoPlanItem.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if (!string.IsNullOrEmpty(txtNoPlanItemCD.Text))
            {
                try
                {
                    lbNoPlanItem.Text = itemData.GetItem(txtNoPlanItemCD.Text).item_name;
                    lbNoPlanItem.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtNoPlanItemCD, "Wrong Item Code" +
                                           Environment.NewLine + ex.Message);
                }
            }
            if (!string.IsNullOrEmpty(txtPlanItemCD.Text))
            {
                try
                {
                    lbPlanItem.Text = itemData.GetItem(txtPlanItemCD.Text).item_name;
                    lbPlanItem.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtPlanItemCD, "Wrong Item Code" +
                                           Environment.NewLine + ex.Message);
                }
            }

        }

        private void txtStockOutUser_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtNoPlanUserCD, null);
            lbNoPlanUser.Text = "User Name";
            lbNoPlanUser.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            if (!string.IsNullOrEmpty(txtNoPlanUserCD.Text))
            {
                try
                {
                    lbNoPlanUser.Text = mUserData.GetUser(txtNoPlanUserCD.Text).user_name;
                    lbNoPlanUser.BackColor = Color.Lime;
                }
                catch (Exception ex)
                {
                    errorProvider.SetError(txtNoPlanUserCD, "Wrong User Code" +
                                           Environment.NewLine + ex.Message);
                }
            }
        }

        private void cmbNoPlanIssueCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbNoPlanIssueCD.Text))
            {
                errorProvider.SetError(cmbNoPlanIssueCD, null);
                if (cmbNoPlanIssueCD.SelectedValue.ToString() == "20") txtNoPlanSetNumber.ReadOnly = false;
                else txtNoPlanSetNumber.ReadOnly = true;
            }
        }

        private void cmbNoPlanDestinationCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbNoPlanDestinationCD.Text))
                errorProvider.SetError(cmbNoPlanDestinationCD, null);
        }

        private void txtNoPlanStockOutQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbSign_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSign.Checked) txtNoPlanStockOutQty.Text = "-" + txtNoPlanStockOutQty.Text;
            else txtNoPlanStockOutQty.Text = txtNoPlanStockOutQty.Text.Replace("-", "");
        }

        private void dgvNoPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtNoPlanItemCD.Text = dgvNoPlan.Rows[e.RowIndex].Cells["item_cd"].Value.ToString();
            txtNoPlanInvoice.Text = dgvNoPlan.Rows[e.RowIndex].Cells["invoice"].Value.ToString();
        }

        private void tab_NoPlan_Paint(object sender, PaintEventArgs e)
        {
            if (dgvProcess.Rows.Count > 0) btnNoPlanInspection.Visible = true;
            else btnNoPlanInspection.Visible = false;
            UpdateNoPlanGrid(false);
        }
        #endregion

        #region SUB EVENT
        /// <summary>
        /// Get list issue code, destination into combobox
        /// </summary>
        private void GetCmb()
        {
            try
            {
                issueCode.GetListIssueCode();
                cmbNoPlanIssueCD.DataSource = issueCode.listIssueCode;
                cmbNoPlanIssueCD.DisplayMember = "issue_name";
                cmbNoPlanIssueCD.ValueMember = "issue_cd";
                cmbNoPlanIssueCD.Text = null;
                destinationData.GetListDestination(string.Empty, string.Empty);
                cmbNoPlanDestinationCD.DataSource = destinationData.listdestination;
                cmbNoPlanDestinationCD.DisplayMember = "destination_name";
                cmbNoPlanDestinationCD.ValueMember = "destination_cd";
                cmbNoPlanDestinationCD.Text = null;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        /// <summary>
        /// Update No plan tab grid
        /// </summary>
        /// <param name="isSearch">true: search stock item</param>
        private void UpdateNoPlanGrid(bool isSearch)
        {
            if (isSearch)
            {
                bool result = false;
                if (txtNoPlanSetNumber.ReadOnly)
                {
                    //Search stock item with item code and invoice
                    result = stockData.SearchItem(new pts_stock { item_cd = txtNoPlanItemCD.Text });
                }
                else
                {
                    //Search stock item with set number
                    pre649Data.Search(new pre_649 { order_number = txtNoPlanSetNumber.Text });
                    result = stockData.SearchItem(new pts_stock { item_cd = pre649Data.listPremacItem[0].item_number });
                }
                if (!result)
                {
                    CustomMessageBox.Error("This stock item is not exist! Please check and try again!");
                    ClearNoPlan();
                }
            }
            dgvNoPlan.DataSource = stockData.listStockItems;
            if (dgvNoPlan.Columns.Contains("order_no")) dgvNoPlan.Columns.Remove("order_no");
            dgvNoPlan.Columns["stock_id"].HeaderText = "Stock ID";
            dgvNoPlan.Columns["packing_cd"].HeaderText = "Packing Code";
            dgvNoPlan.Columns["item_cd"].HeaderText = "Item Code";
            dgvNoPlan.Columns["supplier_cd"].HeaderText = "Supplier Code";
            //dgvNoPlan.Columns["order_no"].HeaderText = "Order Number";
            dgvNoPlan.Columns["invoice"].HeaderText = "Invoice";
            dgvNoPlan.Columns["stockin_date"].HeaderText = "Stock In Date";
            dgvNoPlan.Columns["stockin_user_cd"].HeaderText = "Incharge";
            dgvNoPlan.Columns["stockin_qty"].HeaderText = "Stock In Qty";
            dgvNoPlan.Columns["packing_qty"].HeaderText = "Packing Qty";
            dgvNoPlan.Columns["registration_user_cd"].HeaderText = "Reg User";
            dgvNoPlan.Columns["registration_date_time"].HeaderText = "Reg Date";
            if (dgvNoPlan.Rows.Count > 0)
            {
                //Calculator W/H qty of current item
                txtNoPlanWHQty.Text = dgvNoPlan.Rows.Cast<DataGridViewRow>()
                    .Sum(x => Convert.ToDouble(x.Cells["packing_qty"].Value)).ToString();
                tsRows.Text = dgvNoPlan.Rows.Count.ToString();
            }
            else
            {
                tsRows.Text = "None";
                txtNoPlanWHQty.Text = "0";
            }
        }

        /// <summary>
        /// Clear all fields of No plan tab
        /// </summary>
        private void ClearNoPlan()
        {
            UpdateNoPlanGrid(false);
            dgvNoPlan.DataSource = null;
            cmbNoPlanIssueCD.Text = null;
            cmbNoPlanDestinationCD.Text = null;
            txtNoPlanWHQty.Clear();
            txtNoPlanUserCD.Clear();
            txtNoPlanItemCD.Clear();
            txtNoPlanInvoice.Clear();
            txtNoPlanComment.Clear();
            txtNoPlanSetNumber.Clear();
            txtNoPlanStockOutQty.Clear();
        }
        #endregion
        #endregion

        #region INSPECTION STOCK-OUT
        #region BUTTONS EVENT
        private void btnStockOutReg_Click(object sender, EventArgs e)
        {
            try
            {
                int n = 0;
                //Add no-plan item into DB
                if (listNoPlan.Count > 0)
                {
                    n = noplanData.AddMultiItem(listNoPlan);
                    CustomMessageBox.Notice("Add " + n + " No-Planned item successed!");
                }
                //Add stock-out logs into DB
                if (listStockOut.Count > 0)
                {
                    n = stockOutData.AddMultiItem(listStockOut);
                    outData.ExportCSV(outData.listOutputItem);
                    CustomMessageBox.Notice("Add " + n + " Stock-Out logs!");
                }
                //Update packing qty of stock item in DB
                foreach (pts_stock item in listStock)
                {
                    item.UpdateItem(item);
                }
                //Update stock qty
                itemData.ListStockOutUpdateValue(outData.listOutputItem);
                CustomMessageBox.Notice("Register completed!");
                ClearInspection();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                listPrintItems.Clear();
                if (dgvPrintList.Rows.Count == 0)
                {
                    CustomMessageBox.Notice("Don't have item to print!");
                    return;
                }
                if (printData.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline");
                    return;
                }
                foreach (DataGridViewRow dr in dgvPrintList.Rows)
                {
                    listPrintItems.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                }
                if (printData.PrintItems(listPrintItems, false))
                    CustomMessageBox.Notice("Print items are completed!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnPrintManual_Click(object sender, EventArgs e)
        {
            try
            {
                listPrintItems.Clear();
                if (dgvPrintList.Rows.Count == 0)
                {
                    CustomMessageBox.Notice("Don't have item to print!");
                    return;
                }
                if (printData.CheckPrinterIsOffline(SettingItem.printerSName))
                {
                    CustomMessageBox.Notice("Printer is offline");
                    return;
                }
                foreach (DataGridViewRow dr in dgvPrintList.SelectedRows)
                {
                    listPrintItems.Add(dr.DataBoundItem as PrintItem);
                    dr.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (printData.PrintItems(listPrintItems, true))
                    CustomMessageBox.Notice("Print items are completed!");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Error(ex.Message);
            }
        }

        private void btnInspectionClear_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Warring("Data is not register." + Environment.NewLine + "Are you sure to clear it?") == DialogResult.Yes)
                ClearInspection();
        }

        private void btnInspectionBack_Click(object sender, EventArgs e)
        {
            tc_Main.SelectedTab = tab_NoPlan;
            txtPlanItemCD.Clear();
        }
        #endregion

        #region SUB EVENT
        /// <summary>
        /// Update datagridview to show process data
        /// </summary>
        /// <param name="state">0: No planned. 1: Planning. 2: Request</param>
        private void UpdateProcessGrid(int state)
        {
            switch (state)
            {
                case 0:
                    dgvProcess.DataSource = listNoPlan;
                    break;
                case 1:
                    dgvProcess.DataSource = listPlan;
                    break;
                case 2:
                    break;
            }
            dgvPrintList.DataSource = printData.ListPrintItem;
        }

        private void ClearInspection()
        {
            listPlan.Clear();
            listStock.Clear();
            listNoPlan.Clear();
            listStockOut.Clear();
            outData.listOutputItem.Clear();
            printData.ListPrintItem.Clear();
            dgvProcess.DataSource = null;
            dgvPrintList.DataSource = null;
        }
        #endregion

        #endregion
        pts_stock itemAdd = new pts_stock();
        List<pts_stock> listADd = new List<pts_stock>();
        private void btnPlanAddItem_Click(object sender, EventArgs e)
        {
            itemAdd.SearchItem(new pts_stock { item_cd = txtPlanItemCD.Text });
            listADd.AddRange(itemAdd.listStockItems.Where(x => x.packing_qty > 0).Select(x => x));
            UpdatePlanGrid();
        }

        private void btnPlanReg_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvPlan.Rows)
            {
                if ((double)dr.Cells["packing_qty"].Value <= 0 || dr.Cells["stockout_qty"].Value == null) continue;

                #region ADD STOCK-OUT ITEM
                //Add stock-out item into a list
                listStockOut.Add(new pts_stockout_log
                {
                    packing_cd = dr.Cells["packing_cd"].Value.ToString(),
                    process_cd = listPlan[0].plan_cd,
                    issue_cd = (int)cmbNoPlanIssueCD.SelectedValue,
                    stockout_date = dtpNoPlanStockOutDate.Value,
                    stockout_user_cd = txtNoPlanUserCD.Text,
                    stockout_qty = (double)dr.Cells["stockout_qty"].Value,
                    comment = txtNoPlanComment.Text,
                    remark = "N",
                });
                #region ADD LIST LABEL STOCK-OUT AND LIST ITEM FOR CSV
                //Add new label stock-out
                printData.ListPrintItem.Add(new PrintItem
                {
                    Item_Number = dr.Cells["item_cd"].Value.ToString(),
                    Item_Name = itemData.GetItem(dr.Cells["item_cd"].Value.ToString()).item_name,
                    SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = dr.Cells["supplier_cd"].Value.ToString() }).supplier_name,
                    Invoice = dr.Cells["invoice"].Value.ToString(),
                    Delivery_Date = dtpNoPlanStockOutDate.Value,
                    Delivery_Qty = (double)dr.Cells["stockout_qty"].Value,
                    SupplierCD = dr.Cells["supplier_cd"].Value.ToString(),
                    //OrderNo = stockData.order_no,
                    isRec = false,
                    Label_Qty = 1
                });
                //Add Output item
                outData.listOutputItem.Add(new OutputItem
                {
                    issue_cd = (int)cmbNoPlanIssueCD.SelectedValue,
                    destination_cd = cmbNoPlanDestinationCD.SelectedValue.ToString(),
                    item_number = dr.Cells["item_cd"].Value.ToString(),
                    //item_name = itemData.item_name,
                    //supplier_cd = supplierData.supplier_cd,
                    //supplier_name = supplierData.supplier_name,
                    //supplier_invoice = txtNoPlanInvoice.Text,
                    //order_number = stockData.order_no,
                    delivery_date = dtpNoPlanStockOutDate.Value,
                    delivery_qty = (double)dr.Cells["stockout_qty"].Value,
                    incharge = txtNoPlanUserCD.Text,
                });
                #endregion
                #endregion

                #region CALCULATOR, ADD LIST STOCK ITEM AND ADD LIST LABEL STOCK-ON-HAND
                //Calculator pack qty in stock
                double oddnum = (double)dr.Cells["packing_qty"].Value - (double)dr.Cells["stockout_qty"].Value;
                //listStock.Add(stockData);
                //Add new label stock-in when it not empty
                if (oddnum > 0)
                {
                    printData.ListPrintItem.Add(new PrintItem
                    {
                        Item_Number = dr.Cells["item_cd"].Value.ToString(),
                        Item_Name = itemData.GetItem(dr.Cells["item_cd"].Value.ToString()).item_name,
                        SupplierName = supplierData.GetSupplier(new pts_supplier { supplier_cd = dr.Cells["supplier_cd"].Value.ToString() }).supplier_name,
                        Invoice = dr.Cells["invoice"].Value.ToString(),
                        Delivery_Date = (DateTime)dr.Cells["stockin_date"].Value,
                        Delivery_Qty = oddnum,
                        SupplierCD = dr.Cells["supplier_cd"].Value.ToString(),
                        //OrderNo = stockData.order_no,
                        isRec = true,
                        Label_Qty = 1
                    });
                }
                #endregion
            }
            btnNoPlanInspection.Visible = true;
            if (CustomMessageBox.Question("Successful!. Do you want go to Inspection Tab to see it?") == DialogResult.Yes)
                tc_Main.SelectedTab = tab_Inspection;
        }

        private void btnPlanClear_Click(object sender, EventArgs e)
        {
            listADd.Clear();
            itemAdd.listStockItems.Clear();
            dgvPlan.DataSource = null;
            txtPlanItemCD.Clear();
        }

        private void UpdatePlanGrid()
        {
            dgvPlan.DataSource = listADd;
            if (dgvPlan.Columns.Contains("order_no")) dgvPlan.Columns.Remove("order_no");
            if (dgvPlan.Columns.Contains("stock_id")) dgvPlan.Columns.Remove("stock_id");
            //if (dgvPlan.Columns.Contains("stockin_date")) dgvPlan.Columns.Remove("stockin_date");
            if (dgvPlan.Columns.Contains("registration_user_cd")) dgvPlan.Columns.Remove("registration_user_cd");
            if (dgvPlan.Columns.Contains("registration_date_time")) dgvPlan.Columns.Remove("registration_date_time");
            if (dgvPlan.Columns.Contains("stockin_qty")) dgvPlan.Columns.Remove("stockin_qty");
            if (dgvPlan.Columns.Contains("stockin_user_cd")) dgvPlan.Columns.Remove("stockin_user_cd");

            //dgvPlan.Columns["stock_id"].HeaderText = "Stock ID";
            dgvPlan.Columns["packing_cd"].HeaderText = "Packing Code";
            dgvPlan.Columns["item_cd"].HeaderText = "Item Code";
            dgvPlan.Columns["supplier_cd"].HeaderText = "Supplier Code";
            //dgvPlan.Columns["order_no"].HeaderText = "Order Number";
            dgvPlan.Columns["invoice"].HeaderText = "Invoice";
            dgvPlan.Columns["stockin_date"].HeaderText = "Stock In Date";
            //dgvPlan.Columns["stockin_user_cd"].HeaderText = "Incharge";
            //dgvPlan.Columns["stockin_qty"].HeaderText = "Stock In Qty";
            dgvPlan.Columns["packing_qty"].HeaderText = "Packing Qty";
            //dgvPlan.Columns["registration_user_cd"].HeaderText = "Reg User";
            //dgvPlan.Columns["registration_date_time"].HeaderText = "Reg Date";
            if (!dgvPlan.Columns.Contains("stockout_qty")) dgvPlan.Columns.Add("stockout_qty", "Stock-Out Qty");
            dgvPlan.Columns["stockout_qty"].ValueType = typeof(double);
        }
    }
}
