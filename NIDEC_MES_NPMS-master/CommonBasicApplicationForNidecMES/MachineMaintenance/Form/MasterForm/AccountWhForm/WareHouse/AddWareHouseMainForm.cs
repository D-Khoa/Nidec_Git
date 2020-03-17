using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using System;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.WareHouseMainCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.InvertoryCheckCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.DetailPositionCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountCodeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountLocationCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AssetMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.UnitMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.RankMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.UserLocationMasterCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.WareHouse
{
    public partial class AddWareHouseMainForm : FormCommonNCVP
    {
        public AddWareHouseMainForm()
        {
            InitializeComponent();
        }
        public WareHouseMainVo WareHouseMainVo = new WareHouseMainVo(); //dv
        private void AddWareHouseMainForm_Load(object sender, EventArgs e)
        {
            
            //rank
            ValueObjectList<RankVo> rankname = (ValueObjectList<RankVo>)DefaultCbmInvoker.Invoke(new GetRankCbm(), new RankVo());
            cmbRankCode.DisplayMember = "RankCode";
            cmbRankCode.DataSource = rankname.GetList();
            cmbRankCode.Text = "";


            //location 
            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            cmbBeforeLocation.DataSource = Locationvo.LocationListVo;
            cmbBeforeLocation.DisplayMember = "LocationCode";
            cmbBeforeLocation.Text = "";

            // account_code
            ValueObjectList<AccountCodeVo> accountcodevo = (ValueObjectList<AccountCodeVo>)DefaultCbmInvoker.Invoke(new GetAccountCodeCbm(), new AccountCodeVo());
            cmbAccountCode.DisplayMember = "AccountCodeCode";
            cmbAccountCode.DataSource = accountcodevo.GetList();
            cmbAccountCode.Text = "";

            //accountlocationcode
            ValueObjectList<AccountLocationVo> accountlocationcodevo = (ValueObjectList<AccountLocationVo>)DefaultCbmInvoker.Invoke(new GetAccountLocationCbm(), new AccountLocationVo());
            cmbSectionCode.DisplayMember = "AccountLocationCode";
            cmbSectionCode.DataSource = accountlocationcodevo.GetList();
            cmbSectionCode.Text = "";


            //cau cua dang
            ValueObjectList<AssetVo> assetmodelvo = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetCbm(), new AssetVo());
            cmbNoNumber.DisplayMember = "AssetNo";
            cmbNoNumber.ValueMember = "AssetId";
            cmbNoNumber.DataSource = assetmodelvo.GetList();
            //end

            ValueObjectList<UnitVo> unitvo = (ValueObjectList<UnitVo>)DefaultCbmInvoker.Invoke(new GetUnitCbm(), new UnitVo());
            cmbUnit.DisplayMember = "UnitCode";
            cmbUnit.DataSource = unitvo.GetList();
            cmbUnit.Text = "";
           
            {

                cmbUserName.Enabled = false;
                cmbAssetModel.Enabled = false;
                dtpEndDepreciation.Enabled = false;
                cmbAssetLife.Enabled = false;
                cmbAcquisitionCost.Enabled = false;
                txtCurrentDepreciation.Enabled = false;
                txtMonthlyDepreciation.Enabled = false;
                txtAccumDepreciation.Enabled = false;
                txtNetValue.Enabled = false;
              
            }
            if (WareHouseMainVo.WareHouseMainId > 0)
            {
                txtAssetCode.Enabled = false;
                cmbNoNumber.Enabled = false;

                cmbBeforeLocation.Text = WareHouseMainVo.BeforeLocationCd;
                cmbAfterLocation.Text = WareHouseMainVo.AfterLocationCd;
                cmbDetailPosition.Text = WareHouseMainVo.DetailPositionCd;
                cmbNoNumber.Text = WareHouseMainVo.AssetNo.ToString();
                txtAssetCode.Text = WareHouseMainVo.AssetCode;
                cmbAssetModel.Text = WareHouseMainVo.AssetModel;
                cmbRankCode.Text = WareHouseMainVo.RankCode;
                cmbAccountCode.Text = WareHouseMainVo.AccountCodeCode;
                cmbSectionCode.Text = WareHouseMainVo.AccountLocationCode;
                txtqty.Text = WareHouseMainVo.QTY.ToString();
                cmbUnit.Text = WareHouseMainVo.UnitName;
                dtpStartDepreciation.Value = WareHouseMainVo.StartDepreciation;
                dtpEndDepreciation.Value = WareHouseMainVo.EndDepreciation;
                cmbAssetLife.Text = WareHouseMainVo.AssetLife.ToString();
                cmbAcquisitionCost.Text = WareHouseMainVo.AcquisitionCost.ToString();
                txtCurrentDepreciation.Text = WareHouseMainVo.CurrentDepreciation.ToString();
                txtMonthlyDepreciation.Text = WareHouseMainVo.MonthlyDepreciation.ToString();
                txtAccumDepreciation.Text = WareHouseMainVo.AccumDepreciation.ToString();
                txtNetValue.Text = WareHouseMainVo.NetValue.ToString();

                this.TitleText = Com.Nidec.Mes.GlobalMasterMaintenance.CommonConstants.MODE_UPDATE;
            }
            else
            {
                txtComment.Text = "Add";
                this.TitleText = Com.Nidec.Mes.GlobalMasterMaintenance.CommonConstants.MODE_ADD;
            }
        }
        private void after_location_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueObjectList<DetailPositionVo> detailposition = (ValueObjectList<DetailPositionVo>)DefaultCbmInvoker.Invoke(new GetDetailPositionCbm(), new DetailPositionVo() { LocationCd = cmbAfterLocation.Text, });
            cmbDetailPosition.DisplayMember = "DetailPositionCode";
            cmbDetailPosition.DataSource = detailposition.GetList();
            cmbDetailPosition.Text = "";
        }
        private void before_location_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //location 
            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            cmbAfterLocation.DataSource = Locationvo.LocationListVo;
            cmbAfterLocation.DisplayMember = "LocationCode";

        }
        private void ok_btn_Click(object sender, EventArgs e)
        {
            if (Checkdata())
            {
                InvertoryVo CheckTimeIdVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new GetMaxCheckTimeIdCbm(), new InvertoryVo());
                WareHouseMainVo outVo1 = new WareHouseMainVo();
                WareHouseMainVo outVo2 = new WareHouseMainVo();
                WareHouseMainVo inVo = new WareHouseMainVo()
                {

                    WareHouseMainId = WareHouseMainVo.WareHouseMainId,
                    ///
                    BeforeLocationId = ((LocationVo)this.cmbBeforeLocation.SelectedItem).LocationId,
                    DetailPositionId = ((DetailPositionVo)this.cmbDetailPosition.SelectedItem).DetailPositionId,
                    AfterLocationId = ((LocationVo)this.cmbAfterLocation.SelectedItem).LocationId,
                    AssetId = ((AssetVo)this.cmbNoNumber.SelectedItem).AssetId,
                    QTY = Int16.Parse(txtqty.Text),
                    UnitId = ((UnitVo)cmbUnit.SelectedItem).UnitId,
                    AssetNo = Int16.Parse(cmbNoNumber.Text),
                    AccountCodeId = ((AccountCodeVo)this.cmbAccountCode.SelectedItem).AccountCodeId,
                    AccountLocationId = ((AccountLocationVo)this.cmbSectionCode.SelectedItem).AccountLocationId,
                    RankId = ((RankVo)this.cmbRankCode.SelectedItem).RankId,
                    CommnetsData = txtComment.Text,
                    StartDepreciation = dtpStartDepreciation.Value,
                    EndDepreciation = dtpEndDepreciation.Value,
                    CurrentDepreciation = double.Parse(txtCurrentDepreciation.Text),
                    MonthlyDepreciation = double.Parse(txtMonthlyDepreciation.Text),
                    AccumDepreciation = double.Parse(txtAccumDepreciation.Text),
                    NetValue = double.Parse(txtNetValue.Text),
                    //  LocationId = ((LocationVo)this.location_cmb.SelectedItem).LocationId,
                    UserLocationId = ((UserLocationVo)this.cmbUserName.SelectedItem).UserLocationId,
                    RegistrationDateTime = DateTime.Now,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    InvertoryId = CheckTimeIdVo.InvertoryTimeId,
                };
                try
                {

                    if (inVo.WareHouseMainId > 0) //update
                    {
                        outVo1 = (WareHouseMainVo)DefaultCbmInvoker.Invoke(new UpdateWareHouseMainCbm(), inVo);//sai 
                        outVo2 = (WareHouseMainVo)DefaultCbmInvoker.Invoke(new AddWareHouseHistoryMainCbm(), inVo);
                        
                    }
                    else//add
                    {
                        outVo1 = (WareHouseMainVo)DefaultCbmInvoker.Invoke(new AddWareHouseMainCbm(), inVo);
                        outVo2 = (WareHouseMainVo)DefaultCbmInvoker.Invoke(new AddWareHouseHistoryMainCbm(), inVo);

                        if (outVo1.AffectedCount > 0)
                        {
                            ValueObjectList<WareHouseMainVo> outVoWareHouse = (ValueObjectList<WareHouseMainVo>)DefaultCbmInvoker.Invoke(new GetWarehouseMainIdCbm(), new WareHouseMainVo() { AssetCode = txtAssetCode.Text });

                            InvertoryVo outVoCheckTime = new InvertoryVo();
                            InvertoryVo inVoCheckTime = new InvertoryVo()
                            {
                                WarehouseMainId = outVoWareHouse.GetList()[0].WareHouseMainId,
                                InvertoryTimeId = CheckTimeIdVo.InvertoryTimeId,
                                InvertoryValue = true,
                                RegistrationUserCode = UserData.GetUserData().UserName,
                                FactoryCode = UserData.GetUserData().FactoryCode,
                                LocationID = ((LocationVo)this.cmbAfterLocation.SelectedItem).LocationId,
                            };
                            outVoCheckTime = (InvertoryVo)DefaultCbmInvoker.Invoke(new AddInvertoryCheckCbm(), inVoCheckTime);
                        }
                        cmbUnit.Text = "";
                        txtAssetCode.Text = "";
                    }
                    AccountMainVo accountOutVo = new AccountMainVo();
                    accountOutVo = (AccountMainVo)DefaultCbmInvoker.Invoke(new UpdateItemAccountMainCbm(), new AccountMainVo() { AssetId = inVo.AssetId, LocationId = inVo.AfterLocationId, RankId = inVo.RankId, UserLocationId = inVo.UserLocationId, RegistrationUserCode = inVo.RegistrationUserCode, RegistrationDateTime = DateTime.Now, });

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if (outVo1.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, asset_code_lbl.Text + " : " + txtAssetCode.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }
                if (outVo2.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, asset_code_lbl.Text + " : " + txtAssetCode.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                    return;
                }
               
            }
            
        }

        private void user_location_code_txt_TextChanged(object sender, EventArgs e)
        {
            if ((txtUserCode.Text.Length == 13) || (txtUserCode.Text.Length == 10))
            {
                WareHouseMainVo inVo = new WareHouseMainVo()
                {
                    UserTem = txtUserCode.Text
                };
                ValueObjectList<UserLocationVo> userlocationvo = (ValueObjectList<UserLocationVo>)DefaultCbmInvoker.Invoke(new GetUserLocationCbm(), new UserLocationVo { UserLocationCode = inVo.UserTem });
                cmbUserName.DisplayMember = "UserLocationName";
                cmbUserName.DataSource = userlocationvo.GetList();
            }
            else
            {
                cmbUserName.Text = "";
                cmbUserName.SelectedItem = null;
            }
        }

        private void unit_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
     
            try
            {
                callvaluecost(sender, e);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }
        public string assetcodetrim = "";
        private void asset_code_txt_TextChanged(object sender, EventArgs e)
        {
           // if (asset_code_txt.Text.Length >= 10)
            {
                //assetcodetrim = asset_code_txt.Text.Substring(0, 10);
                string str = txtAssetCode.Text;
                string[] arrListStr = str.Split(',');
                assetcodetrim = arrListStr[0];
            }
            if (WareHouseMainVo.WareHouseMainId > 0)
            {
                ValueObjectList<AssetVo> assetmodelvo = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetCbm(), new AssetVo { AssetNo = int.Parse(WareHouseMainVo.AssetNo.ToString()), AssetCode = assetcodetrim });
                cmbNoNumber.DisplayMember = "AssetNo";
                cmbNoNumber.DataSource = assetmodelvo.GetList();
            }
            else
            {
                ValueObjectList<AssetVo> assetmodelvo = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetCbm(), new AssetVo { AssetNo = 10000, AssetCode = assetcodetrim });
                cmbNoNumber.DisplayMember = "AssetNo";
                cmbNoNumber.DataSource = assetmodelvo.GetList();
                cmbNoNumber.Text = "";

            }
        }
        private void callvaluecost(object sender, EventArgs e)
        {
            //call asset model ok
            ValueObjectList<AssetVo> assetmodelvo = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetCbm(), new AssetVo { AssetCode = assetcodetrim, AssetNo = int.Parse(cmbNoNumber.Text) });

            cmbAssetModel.DisplayMember = "AssetModel";
            cmbAssetModel.DataSource = assetmodelvo.GetList();

            //life                    
            cmbAssetLife.DisplayMember = "AssetLife";
            cmbAssetLife.DataSource = assetmodelvo.GetList();
            //AcquistionCost                    
            cmbAcquisitionCost.DisplayMember = "AcquistionCost";
            cmbAcquisitionCost.DataSource = assetmodelvo.GetList();
            //call again datetime
            start_depreciation_dtp_CloseUp(sender, e);
            //call vaule
        }

        private void start_depreciation_dtp_CloseUp(object sender, EventArgs e)
        {
            DateTime dt = dtpStartDepreciation.Value.Date.AddMonths(int.Parse(cmbAssetLife.Text) * 12);
            dtpEndDepreciation.Value = dt.AddDays(-1);

            // WareHouseMainVo
            int YearNow = int.Parse(dtpDateTimeView.Value.ToString("yyyy"));
            int MonthNow = int.Parse(dtpDateTimeView.Value.ToString("MM"));
            int YearStart = int.Parse(dtpStartDepreciation.Value.ToString("yyyy"));
            int MonthStart = int.Parse(dtpStartDepreciation.Value.ToString("MM"));
            WareHouseMainVo.MonthCounter = ((YearNow - YearStart) * 12) + (MonthNow - MonthStart);

            //callmonthly dep 
            double monthl_value = double.Parse(cmbAcquisitionCost.Text) / (double.Parse(cmbAssetLife.Text) * 12);
            txtMonthlyDepreciation.Text = Math.Round(monthl_value, 3).ToString();

            //call current_depreciation_txt
            double current_depr = (WareHouseMainVo.MonthCounter - 1) * monthl_value;
            txtCurrentDepreciation.Text = Math.Round(current_depr, 3).ToString();
            if (current_depr > double.Parse(cmbAcquisitionCost.Text))
            {
                txtCurrentDepreciation.Text = cmbAcquisitionCost.Text;
            }
            if (current_depr < 0)
            {
                txtCurrentDepreciation.Text = 0.ToString();
            }
            //call accum_depreciation_txt
            double accum_depr = WareHouseMainVo.MonthCounter * monthl_value;
            txtAccumDepreciation.Text = Math.Round(accum_depr, 3).ToString();
            if (accum_depr > double.Parse(cmbAcquisitionCost.Text))
            {
                txtAccumDepreciation.Text = cmbAcquisitionCost.Text;
            }
            if (accum_depr < 0)
            {
                txtAccumDepreciation.Text = 0.ToString();
            }
            //call net_value_txt
            double net_value = (double.Parse(cmbAcquisitionCost.Text) - accum_depr);
            txtNetValue.Text = Math.Round(net_value, 3).ToString();
            if (net_value < 0)
            {
                txtNetValue.Text = 0.ToString();
            }
            if (net_value > double.Parse(cmbAcquisitionCost.Text))
            {
                txtNetValue.Text = cmbAcquisitionCost.Text;
            }
        }
        /*
        thuat toan
        A = acquisition_cost_cmb.Text
        B = current_depreciation_txt.Text
        C =  monthl_depreciation_txt.Text
        D = accum_depreciation_txt.Text
        E = net_value_txt.Text
        WareHouseMainVo.MonthCounter = y nhu tren
        TL = asset_life_cmb.Text
        ==>
        C= A/(TL*12)
        B = WareHouseMainVo.MonthCounter*c
        D = B+ C
        E = A -D
        */
        bool Checkdata()
        {
            if (txtUserCode.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, UserCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                txtUserCode.Focus();
                return false;
            }
            if (txtAssetCode.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, asset_code_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                txtAssetCode.Focus();
                return false;
            }
            if (cmbRankCode.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, rank_code_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cmbRankCode.Focus();
                return false;
            }
            if (cmbAccountCode.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, account_code_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cmbAccountCode.Focus();
                return false;
            }
            if (cmbUserName.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, user_location_name_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cmbUserName.Focus();
                return false;
            }
            if (cmbSectionCode.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, section_cd_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cmbSectionCode.Focus();
                return false;
            }
            if (cmbAfterLocation.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, location_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cmbAfterLocation.Focus();
                return false;
            }
            if (cmbUnit.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, unit_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cmbUnit.Focus();
                return false;
            }
            if (cmbBeforeLocation.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, before_location_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cmbBeforeLocation.Focus();
                return false;
            }
            if (cmbDetailPosition.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, detail_position_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cmbDetailPosition.Focus();
                return false;
            }
            if (txtqty.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, qty_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                txtqty.Focus();
                return false;
            }

            if (dtpEndDepreciation.Value <= dtpStartDepreciation.Value)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, end_depreciation_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                dtpEndDepreciation.Focus();
                return false;
            }
            return true;
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void no_cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string no = this.no_cbm.SelectedValue.ToString();
        }

     
    }
}
