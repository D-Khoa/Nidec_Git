using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.FA_Management_System_Cbm.Warehouse_Equipment_Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.NCVPForm.FA_Management_System_Form;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.FA_Management_System
{
    public partial class Warehouse_Equipment_Form : FormCommonNCVP
    {
        AccountManagerFAWHVo Vo = new AccountManagerFAWHVo();
        public Warehouse_Equipment_Form()
        {
            InitializeComponent();
        }

        private void Warehouse_Equipment_Form_Load(object sender, EventArgs e)
        {
            #region GET NODES FROM DATABASE
            ValueObjectList<AssetInfoFAWHVo> assetInfo = (ValueObjectList<AssetInfoFAWHVo>)DefaultCbmInvoker
                                                   .Invoke(new GetAssetInfoFAWHCbm(), new AssetInfoFAWHVo());
            foreach (string node in assetInfo.GetList().Select(x => x.asset_model).Distinct())
            {
                trvAsset.Nodes["asset_model"].Nodes.Add(node);
            }
            foreach (string node in assetInfo.GetList().Select(x => x.asset_type).Distinct())
            {
                trvAsset.Nodes["asset_type"].Nodes.Add(node);
            }
            foreach (string node in assetInfo.GetList().Select(x => x.asset_invoice).Distinct())
            {
                trvAsset.Nodes["asset_invoice"].Nodes.Add(node);
            }
            foreach (string node in assetInfo.GetList().Select(x => x.label_status).Distinct())
            {
                trvAsset.Nodes["label_status"].Nodes.Add(node);
            }
            ValueObjectList<AccountCodeFAWHVo> accountCode = (ValueObjectList<AccountCodeFAWHVo>)DefaultCbmInvoker
                                                       .Invoke(new GetAccountCodeFAWHCbm(), new AccountCodeFAWHVo());
            foreach (AccountCodeFAWHVo node in accountCode.GetList())
            {
                TreeNode nodename = new TreeNode();
                nodename.Name = node.account_code_id.ToString();
                nodename.Text = node.account_code_cd + " : " + node.account_code_name;
                trvOther.Nodes["account_cd"].Nodes.Add(nodename);
            }
            ValueObjectList<RankInfoFAWHVo> rankCode = (ValueObjectList<RankInfoFAWHVo>)DefaultCbmInvoker
                                                 .Invoke(new GetRankInfoFAWHCbm(), new RankInfoFAWHVo());
            foreach (RankInfoFAWHVo node in rankCode.GetList())
            {
                TreeNode nodename = new TreeNode();
                nodename.Name = node.rank_id.ToString();
                nodename.Text = node.rank_cd + " : " + node.rank_name;
                trvOther.Nodes["rank_cd"].Nodes.Add(nodename);
            }
            ValueObjectList<AccountLocationFAWHVo> sectionCode = (ValueObjectList<AccountLocationFAWHVo>)DefaultCbmInvoker
                                                           .Invoke(new GetAccountLocationFAWHCbm(), new AccountLocationFAWHVo());
            foreach (AccountLocationFAWHVo node in sectionCode.GetList())
            {
                TreeNode nodename = new TreeNode();
                nodename.Name = node.account_location_id.ToString();
                nodename.Text = node.account_location_cd + " : " + node.account_location_name;
                trvOther.Nodes["account_location_cd"].Nodes.Add(nodename);
            }
            ValueObjectList<LocationInfoFAWHVo> locationCode = (ValueObjectList<LocationInfoFAWHVo>)DefaultCbmInvoker
                                                         .Invoke(new GetLocationInfoFAWHCbm(), new LocationInfoFAWHVo());
            foreach (LocationInfoFAWHVo node in locationCode.GetList())
            {
                TreeNode nodename = new TreeNode();
                nodename.Name = node.location_id.ToString();
                nodename.Text = node.location_cd + " : " + node.location_name;
                trvOther.Nodes["location_cd"].Nodes.Add(nodename);
            }
            ValueObjectList<InventoryTimeFAWHVo> invertoryTime = (ValueObjectList<InventoryTimeFAWHVo>)DefaultCbmInvoker
                                                           .Invoke(new GetInventoryTimeFAWHCbm(), new InventoryTimeFAWHVo());
            foreach (InventoryTimeFAWHVo node in invertoryTime.GetList())
            {
                TreeNode nodename = new TreeNode();
                nodename.Name = node.invertory_time_id.ToString();
                nodename.Text = node.invertory_time_name;
                trvOther.Nodes["invertory_time_cd"].Nodes.Add(nodename);
            }
            ValueObjectList<FactoryInfoFAWHVo> factoryCode = (ValueObjectList<FactoryInfoFAWHVo>)DefaultCbmInvoker
                                                       .Invoke(new GetFactoryInfoFAWHCbm(), new FactoryInfoFAWHVo());
            foreach (FactoryInfoFAWHVo node in factoryCode.GetList())
            {
                TreeNode nodename = new TreeNode();
                nodename.Name = node.factory_cd;
                nodename.Text = node.factory_name;
                trvOther.Nodes["factory_cd"].Nodes.Add(nodename);
            }
            ValueObjectList<UnitInfoFAWHVo> unitCode = (ValueObjectList<UnitInfoFAWHVo>)DefaultCbmInvoker
                                           .Invoke(new GetUnitInfoFAWHCbm(), new UnitInfoFAWHVo());
            foreach (UnitInfoFAWHVo node in unitCode.GetList())
            {
                TreeNode nodename = new TreeNode();
                nodename.Name = node.unit_id.ToString();
                nodename.Text = node.unit_name;
                trvOther.Nodes["unit_cd"].Nodes.Add(nodename);
            }
            #endregion

        }
        #region BUTTON
        private void btnSearch_Click(object sender, EventArgs e)
        {
            CheckTreeView(trvAsset, false);
            CheckTreeView(trvOther, true);
            Vo.asset_cd = txtAssetCode.Text;
            Vo.asset_name = txtAssetName.Text;
            Vo = (AccountManagerFAWHVo)DefaultCbmInvoker.Invoke(new SearchAccountFAWHCbm(), Vo);
            UpdateGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_FA_Warehouse_Equipment_Form adFrm = new Add_FA_Warehouse_Equipment_Form();
            adFrm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfoFAWHForm upFrm = new UpdateAccountInfoFAWHForm(Vo.account_main_id);
            upFrm.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (Vo.table.Rows.Count > 0)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Excel Documents (*.xlsx)|*.xlsx|Excel Documents 97-2003 (*.xls)|*.xls|All file (*.*)|*.*";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    sf.FileName.CreateExcelWorkBook();
                    Vo.table.DatatableToExcel();
                    sf.FileName.SaveAndExit(true);
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Renew();
        }

        private void btnAccDepr_Click(object sender, EventArgs e)
        {
            AccountManagerFAWHVo accDepr = (AccountManagerFAWHVo)DefaultCbmInvoker.Invoke(new GetAccDeprFAWHCbm(), new AccountManagerFAWHVo());
            UpdateDeprGrid(accDepr);
        }

        private void btnRankDepr_Click(object sender, EventArgs e)
        {
            AccountManagerFAWHVo rankDepr = (AccountManagerFAWHVo)DefaultCbmInvoker.Invoke(new GetRankDeprFAWHCbm(), new AccountManagerFAWHVo());
            UpdateDeprGrid(rankDepr);
        }

        private void btnTransferAsset_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region SUB EVENT
       
        private void UpdateGrid()
        {
            dgvAccountData.DataSource = Vo.table;
            dgvAccountData.AutoResizeColumnHeadersHeight();
            dgvAccountData.Columns["Acquisition_Cost"].DefaultCellStyle.Format = "N3";
            dgvAccountData.Columns["Monthly_Depr"].DefaultCellStyle.Format = "N3";
            dgvAccountData.Columns["Current_Depr"].DefaultCellStyle.Format = "N3";
            dgvAccountData.Columns["Accum_Depr"].DefaultCellStyle.Format = "N3";
            dgvAccountData.Columns["Net_Value"].DefaultCellStyle.Format = "N3";
            dgvAccountData.Columns["Acquisition_Cost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAccountData.Columns["Monthly_Depr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAccountData.Columns["Current_Depr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAccountData.Columns["Accum_Depr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAccountData.Columns["Net_Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAccountData.Refresh();
            tsRowCounter.Text = Vo.table.Rows.Count + " rows";
            CounterCost();
        }
        private void UpdateDeprGrid(AccountManagerFAWHVo inVo)
        {
            if (inVo.table.Rows.Count > 0)
            {
                dgvDeprCalc.DataSource = inVo.table;
                dgvDeprCalc.Columns["acquistion_cost"].DefaultCellStyle.Format = "N3";
                dgvDeprCalc.Columns["monthly_depreciation"].DefaultCellStyle.Format = "N3";
                dgvDeprCalc.Columns["current_depreciation"].DefaultCellStyle.Format = "N3";
                dgvDeprCalc.Columns["accum_depreciation_now"].DefaultCellStyle.Format = "N3";
                dgvDeprCalc.Columns["net_value"].DefaultCellStyle.Format = "N3";
                dgvDeprCalc.Columns["acquistion_cost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDeprCalc.Columns["monthly_depreciation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDeprCalc.Columns["current_depreciation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDeprCalc.Columns["accum_depreciation_now"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDeprCalc.Columns["net_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDeprCalc.Columns["acquistion_cost"].HeaderText = "Acquisition Cost ($)";
                dgvDeprCalc.Columns["monthly_depreciation"].HeaderText = "Monthly Depreception ($)";
                dgvDeprCalc.Columns["current_depreciation"].HeaderText = "Current Depreception ($)";
                dgvDeprCalc.Columns["accum_depreciation_now"].HeaderText = "Accum Depreception ($)";
                dgvDeprCalc.Columns["net_value"].HeaderText = "Netbooks ($)";
                try
                {
                    dgvDeprCalc.Columns["account_code_name"].HeaderText = "Account Code Name";
                }
                catch
                {
                    dgvDeprCalc.Columns["rank_name"].HeaderText = "Rank Name";
                }
                dgvDeprCalc.Refresh();
                grt_Option.SelectedTab = tab_depreciation;
            }
        }
        private void CounterCost()
        {
            InventoryTimeFAWHVo maxInvertory = (InventoryTimeFAWHVo)DefaultCbmInvoker.Invoke(new GetInventoryTimeMaxFAWHCbm(), new InventoryTimeFAWHVo());
            object totalMachine = Vo.table.Compute("sum(Qty)", "");
            int inventoried = 0;
            double aqui_cost = 0;
            double month_depr = 0;
            double curr_depr = 0;
            double accum_depr = 0;
            double net_value = 0;
            foreach (DataGridViewRow dr in dgvAccountData.Rows)
            {
                if (dr != null)
                {
                    if (dr.Cells["Inventory_Time"].Value.ToString() == maxInvertory.invertory_time_name)
                    {
                        inventoried += int.Parse(dr.Cells["Qty"].Value.ToString());
                    }
                    aqui_cost += double.Parse(dr.Cells["Acquisition_Cost"].Value.ToString());
                    month_depr += double.Parse(dr.Cells["Monthly_Depr"].Value.ToString());
                    curr_depr += double.Parse(dr.Cells["Current_Depr"].Value.ToString());
                    accum_depr += double.Parse(dr.Cells["Accum_Depr"].Value.ToString());
                    net_value += double.Parse(dr.Cells["Net_Value"].Value.ToString());
                }
            }
            dgvAccCounter.Rows.Clear();
            dgvAccCounter.Rows.Add(aqui_cost, month_depr, curr_depr, accum_depr, net_value, inventoried, totalMachine);
            dgvAccCounter.Refresh();
            grt_Option.SelectedTab = tab_TotalCost;
        }
        private void Renew()
        {
            grt_Option.SelectedTab = tab_Search;
            Vo = new AccountManagerFAWHVo();
            dgvAccountData.DataSource = null;
            dgvAccCounter.Rows.Clear();
            dgvDeprCalc.DataSource = null;
            foreach (TreeNode root in trvAsset.Nodes)
                root.Checked = false;
            foreach (TreeNode root in trvOther.Nodes)
                root.Checked = false;
        }

        private void txtAssetCode_TextChanged(object sender, EventArgs e)
        {
            if (txtAssetCode.Text.Length > 10)
            {
                txtAssetCode.Text.Remove(10);
            }
        }
        #endregion
        #region TREEVIEW CHECKBOX
        private void trvAsset_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Nodes_Check(e.Node, e.Node.Checked);
        }

        private void trvOther_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Nodes_Check(e.Node, e.Node.Checked);
        }
        private void Nodes_Check(TreeNode root, bool check)
        {
            foreach (TreeNode node in root.Nodes)
            {
                node.Checked = check;
                Nodes_Check(node, node.Checked);
            }
        }
        private string CheckList(TreeNode root, bool name)
        {
            string list = "'0'";
            foreach (TreeNode node in root.Nodes)
            {
                if (node.Checked && !name)
                    list += ",'" + node.Text + "'";
                if (node.Checked && name)
                    list += ",'" + node.Name + "'";
            }
            return list;
        }
        private void CheckTreeView(TreeView tree, bool name)
        {
            Vo.value_expired = false;
            Vo.value_valid = false;
            foreach (TreeNode root in tree.Nodes)
            {
                if (root.Name == "asset_model")
                    Vo.list_asset_model = CheckList(root, name);
                if (root.Name == "asset_type")
                    Vo.list_asset_type = CheckList(root, name);
                if (root.Name == "asset_invoice")
                    Vo.list_asset_invoice = CheckList(root, name);
                if (root.Name == "label_status")
                    Vo.list_asset_label = CheckList(root, name);
                if (root.Name == "account_cd")
                    Vo.list_account_cd = CheckList(root, name);
                if (root.Name == "account_location_cd")
                    Vo.list_account_location = CheckList(root, name);
                if (root.Name == "location_cd")
                    //Vo.list_location = CheckList(root, name);
                    Vo.list_location = "('15'),('16'),('17'),('31')";
                if (root.Name == "invertory_time_cd")
                    Vo.list_invertory_times = CheckList(root, name);
                if (root.Name == "rank_cd")
                    Vo.list_rank = CheckList(root, name);
                if (root.Name == "factory_cd")
                    Vo.list_factory = CheckList(root, name);
                if (root.Name == "unit_cd")
                    Vo.list_unit = CheckList(root, name);
                if (root.Name == "net_value" && root.Nodes["valid"].Checked)
                    Vo.value_valid = true;
                if (root.Name == "net_value" && root.Nodes["expired"].Checked)
                    Vo.value_expired = true;
            }
        }
        #endregion
        #region DGVDATA
        private void dgvAccountData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            DataGridViewRow dr = dgvAccountData.Rows[e.RowIndex];
            Vo.account_main_id = (int)dr.Cells["Account_ID"].Value;
        }

        private void dgvAccountData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
    }
}
