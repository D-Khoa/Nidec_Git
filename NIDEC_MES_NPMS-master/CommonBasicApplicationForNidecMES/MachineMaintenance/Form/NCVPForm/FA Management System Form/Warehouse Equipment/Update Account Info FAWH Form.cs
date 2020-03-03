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

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.NCVPForm.FA_Management_System_Form
{
    public partial class UpdateAccountInfoFAWHForm : FormCommonNCVP
    {
        AccountInfoFAWHVo accountVo = new AccountInfoFAWHVo();
        ValueObjectList<UserLocationFAWHVo> userlocVoList = new ValueObjectList<UserLocationFAWHVo>();
        int user_location_id;
        public UpdateAccountInfoFAWHForm()
        {
            InitializeComponent();
        }
        public UpdateAccountInfoFAWHForm(int account_id)
        {
            InitializeComponent();
            //pnlAddAccount.Visible = false;
            //this.Width -= pnlAddAccount.Width;
            accountVo.account_main_id = account_id;
            accountVo = (AccountInfoFAWHVo)DefaultCbmInvoker.Invoke(new GetAccountInfoFAWHCbm(), accountVo);
        }

        private void UpdateAccountInfoFAWHForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<UnitInfoFAWHVo> unitVo =
               (ValueObjectList<UnitInfoFAWHVo>)DefaultCbmInvoker.Invoke(new GetUnitInfoFAWHCbm(), new UnitInfoFAWHVo());
            cmbUnit.DataSource = unitVo.GetList();
            cmbUnit.DisplayMember = "unit_name";
            cmbUnit.ValueMember = "unit_id";
            cmbUnit.SelectedItem = accountVo.unit_id;
            ValueObjectList<AccountCodeFAWHVo> accVo =
                (ValueObjectList<AccountCodeFAWHVo>)DefaultCbmInvoker.Invoke(new GetAccountCodeFAWHCbm(), new AccountCodeFAWHVo());
            cmbAccountCode.DataSource = accVo.GetList();
            cmbAccountCode.DisplayMember = "account_code_name";
            cmbAccountCode.ValueMember = "account_code_id";
            cmbAccountCode.SelectedItem = accountVo.account_code_id;
            ValueObjectList<RankInfoFAWHVo> rankVo =
                (ValueObjectList<RankInfoFAWHVo>)DefaultCbmInvoker.Invoke(new GetRankInfoFAWHCbm(), new RankInfoFAWHVo());
            cmbRank.DataSource = rankVo.GetList();
            cmbRank.DisplayMember = "rank_name";
            cmbRank.ValueMember = "rank_id";
            cmbRank.SelectedItem = accountVo.rank_id;
            ValueObjectList<AccountLocationFAWHVo> sectionVo =
               (ValueObjectList<AccountLocationFAWHVo>)DefaultCbmInvoker.Invoke(new GetAccountLocationFAWHCbm(), new AccountLocationFAWHVo());
            cmbSection.DataSource = sectionVo.GetList();
            cmbSection.DisplayMember = "account_location_name";
            cmbSection.ValueMember = "account_location_id";
            cmbSection.SelectedItem = accountVo.account_location_id;
            ValueObjectList<LocationInfoFAWHVo> locationVo =
               (ValueObjectList<LocationInfoFAWHVo>)DefaultCbmInvoker.Invoke(new GetLocationInfoFAWHCbm(), new LocationInfoFAWHVo());
            cmbLocation.DataSource = locationVo.GetList();
            cmbLocation.DisplayMember = "location_name";
            cmbLocation.ValueMember = "location_id";
            cmbLocation.SelectedItem = accountVo.location_id;
            ValueObjectList<AssetInfoFAWHVo> assetVoList = (ValueObjectList<AssetInfoFAWHVo>)DefaultCbmInvoker.Invoke(new GetAssetInfoFAWHCbm(), new AssetInfoFAWHVo
            {
                asset_id = accountVo.asset_id,
            });
            foreach (AssetInfoFAWHVo assetVo in assetVoList.GetList())
            {
                txtAssetCode.Text = assetVo.asset_cd;
                txtAssetNo.Text = assetVo.asset_no.ToString();
                accountVo.acquisition_cost = assetVo.acquistion_cost;
                accountVo.asset_life = assetVo.asset_life;
            }
            txtQty.Text = accountVo.qty.ToString();
            txtComment.Text = accountVo.comment_data;
            dtpDeprStart.Value = accountVo.depreciation_start;
            dtpDeprEnd.Value = accountVo.depreciation_end;
            getUserLocation(accountVo.user_location_id);
            CalcCost();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                AssetInfoFAWHVo outAsset = (AssetInfoFAWHVo)DefaultCbmInvoker.Invoke(new GetAssetInfoFAWHCbm(), new AssetInfoFAWHVo
                {
                    asset_cd = txtAssetCode.Text,
                    asset_no = int.Parse(txtAssetNo.Text)
                });
                AccountInfoFAWHVo outVo = new AccountInfoFAWHVo
                {
                    account_main_id = accountVo.account_main_id,
                    asset_id = outAsset.asset_id,
                    qty = int.Parse(txtQty.Text),
                    unit_id = int.Parse(cmbUnit.ValueMember),
                    account_code_id = int.Parse(cmbAccountCode.ValueMember),
                    account_location_id = int.Parse(cmbSection.ValueMember),
                    rank_id = int.Parse(cmbRank.ValueMember),
                    comment_data = txtComment.Text,
                    depreciation_start = dtpDeprStart.Value,
                    depreciation_end = dtpDeprEnd.Value,

                    location_id = int.Parse(cmbLocation.ValueMember),
                    user_location_id = user_location_id,
                };
                outVo = (AccountInfoFAWHVo)DefaultCbmInvoker.Invoke(new UpdateAccountInfoFAWHCbm(), outVo);
                MessageBox.Show("Update finish!!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARRING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dgvAddAccount.Rows.Count > 0)
            {
                if (MessageBox.Show("Data has not been saved. Are you sure to exit?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }

        private void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            getUserLocation(txtUserCode.Text);
        }
        private void getUserLocation(int id)
        {
            userlocVoList = (ValueObjectList<UserLocationFAWHVo>)DefaultCbmInvoker.Invoke(new GetUserLocationFAWHCbm(), new UserLocationFAWHVo
            {
                user_location_id = id,
            });
            foreach (UserLocationFAWHVo userlocVo in userlocVoList.GetList())
            {
                user_location_id = userlocVo.user_location_id;
                txtUserCode.Text = userlocVo.user_location_cd;
                lbUserLocation.Text = userlocVo.user_location_name;
            }
        }
        private void getUserLocation(string cd)
        {
            userlocVoList = (ValueObjectList<UserLocationFAWHVo>)DefaultCbmInvoker.Invoke(new GetUserLocationFAWHCbm(), new UserLocationFAWHVo
            {
                user_location_cd = cd,
            });
            foreach (UserLocationFAWHVo userlocVo in userlocVoList.GetList())
            {
                user_location_id = userlocVo.user_location_id;
                txtUserCode.Text = userlocVo.user_location_cd;
                lbUserLocation.Text = userlocVo.user_location_name;
            }
        }
        private void CalcCost()
        {
            accountVo.monthly_depreciation = accountVo.acquisition_cost / (accountVo.asset_life * 12);
            TimeSpan totalMonth = DateTime.Now.Subtract(dtpDeprStart.Value);
            // accountVo.accum_depreciation = accountVo.monthly_depreciation * ((totalMonth.TotalDays / 365) * 12);
            accountVo.accum_depreciation = accountVo.current_depreciation + accountVo.monthly_depreciation;
            accountVo.current_depreciation = accountVo.accum_depreciation - accountVo.monthly_depreciation;
            accountVo.net_value = accountVo.acquisition_cost - accountVo.accum_depreciation;
            dgvCost.Rows.Add(accountVo.acquisition_cost, accountVo.monthly_depreciation, accountVo.current_depreciation, accountVo.accum_depreciation, accountVo.net_value);
            /*
     thuat toan
     A = acquisition_cost
     B = current_depreciation
     C =  monthl_depreciation
     D = accum_depreciation
     E = net_value
     accountmainVo.MonthCounter = y nhu tren
     TL = asset_life
     ==>
     C= A/(TL*12)
     B = accountmainVo.MonthCounter*c
     D = B+ C
     E = A -D
     */
        }
    }
}
