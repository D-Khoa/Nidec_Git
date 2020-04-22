using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchListWareHouseMainDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            WareHouseMainVo inVo = (WareHouseMainVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<WareHouseMainVo> voList = new ValueObjectList<WareHouseMainVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            #region OLD SQL
            //sql.Append("select m.invertory_time_cd,  m.invertory_time_id,  k.unit_name, d.user_location_name, ");
            //sql.Append("c.location_cd as before, j.location_cd as after, n.location_cd as nowlocation, h.detail_postion_cd, ");
            //sql.Append("g.warehouse_main_id, c.location_cd,e.asset_cd, e.asset_no, e.asset_name, e.asset_model, ");
            //sql.Append("e.asset_serial, e.asset_supplier, e.asset_invoice, e.label_status, e.asset_po, g.qty, ");
            //sql.Append("a.account_code_cd, b.account_location_cd, f.rank_cd, b.account_location_name, g.comment_data, ");
            //sql.Append("e.asset_life, e.acquistion_date, e.acquistion_cost,e.asset_type, g.depreciation_start, ");
            //sql.Append("g.depreciation_end, g.current_depreciation,g.monthly_depreciation, g.accum_depreciation_now, ");
            //sql.Append("g.net_value, g.registration_date_time, g.registration_user_cd from t_warehouse_main g ");
            //sql.Append("left join m_account_code a on a.account_code_id = g.account_code_id ");
            //sql.Append("left join m_account_location b on b.account_location_id = g.account_location_id ");
            //sql.Append("left join m_location c on c.location_id = g.before_location_id ");
            //sql.Append("left join m_location j on j.location_id = g.after_location_id ");
            //sql.Append("left join m_user_location d on d.user_location_id = g.user_location_id ");
            //sql.Append("left join m_asset e on e.asset_id = g.asset_id ");
            //sql.Append("left join m_rank f on f.rank_id = g.rank_id ");
            //sql.Append("left join m_detail_postion h on h.detail_postion_id = g.detail_position_id ");
            //sql.Append("left join m_unit k on k.unit_id = g.unit_id ");
            //sql.Append("left join t_invertory_equipments l on l.warehouse_main_id = g.warehouse_main_id ");
            //sql.Append("left join m_invertory_time m on m.invertory_time_id = l.invertory_time_id ");
            //sql.Append("left join m_location n on n.location_id = l.location_id ");
            //sql.Append("where 1=1  ");
            #endregion
            #region NEW SQL
            sql.Append("select a.asset_cd, a.asset_no, a.asset_name, a.asset_model, a.asset_serial, a.asset_supplier, ");
            sql.Append("a.label_status, i.invertory_time_cd, w.qty, u.unit_name, a.asset_type, w.registration_user_cd, ");
            sql.Append("w.registration_date_time, c.account_code_cd, d.account_location_cd, r.rank_cd, ");
            sql.Append("lb.location_cd as before, la.location_cd as after, ln.location_cd as nowloc, ld.detail_postion_cd, ");
            sql.Append("d.account_location_name, w.comment_data, a.asset_life, a.acquistion_date, w.depreciation_start, ");
            sql.Append("w.depreciation_end, a.acquistion_cost, w.current_depreciation, w.monthly_depreciation, ");
            sql.Append("w.accum_depreciation_now, w.net_value, a.asset_invoice, a.asset_po, w.warehouse_main_id, ");
            sql.Append("us.user_location_name, w.invertory_time_id ");
            sql.Append("FROM t_warehouse_main w left join m_asset a on a.asset_id = w.asset_id ");
            sql.Append("left join m_invertory_time i on i.invertory_time_id = w.invertory_time_id ");
            sql.Append("left join m_unit u on u.unit_id = w.unit_id ");
            sql.Append("left join m_account_code c on c.account_code_id = w.account_code_id ");
            sql.Append("left join m_account_location d on d.account_location_id = w.account_location_id ");
            sql.Append("left join m_rank r on r.rank_id = w.rank_id ");
            sql.Append("left join m_location lb on lb.location_id = w.before_location_id ");
            sql.Append("left join m_location la on la.location_id = w.after_location_id ");
            sql.Append("left join m_detail_postion ld on ld.detail_postion_id = w.detail_position_id ");
            sql.Append("left join m_user_location us on us.user_location_id = w.user_location_id ");
            sql.Append("left join t_invertory_equipments t on t.warehouse_main_id = w.warehouse_main_id ");
            sql.Append("left join m_location ln on ln.location_id = t.location_id ");
            sql.Append("where 1=1  ");
            #endregion
            #region CONDITION
            if (!String.IsNullOrEmpty(inVo.AssetCode))
            {
                sql.Append(@" and a.asset_cd  =:asset_cd");
                sqlParameter.AddParameterString("asset_cd", inVo.AssetCode);
            }
            if (!String.IsNullOrEmpty(inVo.RankCode))
            {
                sql.Append(" and r.rank_cd  =:rank_cd");
                sqlParameter.AddParameterString("rank_cd", inVo.RankCode);
            }

            if (!String.IsNullOrEmpty(inVo.AssetModel))
            {
                sql.Append(" and a.asset_model =:asset_model");
                sqlParameter.AddParameterString("asset_model", inVo.AssetModel);
            }
            if (!String.IsNullOrEmpty(inVo.AssetName))
            {
                sql.Append(" and a.asset_name =:asset_name");
                sqlParameter.AddParameterString("asset_name", inVo.AssetName);
            }
            if (!String.IsNullOrEmpty(inVo.AssetType))
            {
                sql.Append(" and a.asset_type =:asset_type");
                sqlParameter.AddParameterString("asset_type", inVo.AssetType);
            }
            if (!String.IsNullOrEmpty(inVo.AssetInvoice))
            {
                sql.Append(" and a.asset_invoice =:asset_invoice");
                sqlParameter.AddParameterString("asset_invoice", inVo.AssetInvoice);
            }

            if (!String.IsNullOrEmpty(inVo.AfterLocationCd))
            {
                sql.Append(" and la.location_cd =:location_cd");
                sqlParameter.AddParameterString("location_cd", inVo.AfterLocationCd);
            }
            if (!String.IsNullOrEmpty(inVo.NowLocation))
            {
                sql.Append(" and ln.location_cd =:location_cd");
                sqlParameter.AddParameterString("location_cd", inVo.NowLocation);
            }
            if (!String.IsNullOrEmpty(inVo.DetailPositionCd))
            {
                sql.Append(" and ld.detail_postion_cd =:detail_postion_cd");
                sqlParameter.AddParameterString("detail_postion_cd", inVo.DetailPositionCd);
            }
            if (!String.IsNullOrEmpty(inVo.LabelStatus))//label status
            {
                sql.Append(" and a.label_status =:label_status");
                sqlParameter.AddParameterString("label_status", inVo.LabelStatus);
            }
            if (!String.IsNullOrEmpty(inVo.AssetPO))//label status
            {
                sql.Append(" and a.asset_po =:asset_po");
                sqlParameter.AddParameterString("asset_po", inVo.AssetPO);
            }
            if (!String.IsNullOrEmpty(inVo.InventoryTime))//label status
            {
                sql.Append(" and w.invertory_time_id in ");
                sql.Append("(select invertory_time_id from m_invertory_time where invertory_time_cd = :invertory_time_cd)");
                sqlParameter.AddParameterString("invertory_time_cd", inVo.InventoryTime);
            }
            if (!String.IsNullOrEmpty(inVo.Net_Value) && inVo.Net_Value != "All")//search theo net value
            {
                if (inVo.Net_Value == "0$")
                {
                    sql.Append(" and w.net_value = 0");
                }
                else if (inVo.Net_Value == ">0$")
                {
                    sql.Append(" and w.net_value > 0");
                }
            }
            sql.Append(" and t.invertory_equipments_id in (select max(invertory_equipments_id) from t_invertory_equipments group by warehouse_main_id) ");
            sql.Append(" order by w.registration_date_time desc");
            #endregion

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                WareHouseMainVo outVo = new WareHouseMainVo
                {
                    //  , h., i., k., o.prodution_work_content_name
                    WareHouseMainId = int.Parse(dataReader["warehouse_main_id"].ToString()),
                    AfterLocationCd = dataReader["after"].ToString(),
                    BeforeLocationCd = dataReader["before"].ToString(),
                    DetailPositionCd = dataReader["detail_postion_cd"].ToString(),
                    AssetCode = dataReader["asset_cd"].ToString(),
                    AssetNo = int.Parse(dataReader["asset_no"].ToString()),
                    AssetName = dataReader["asset_name"].ToString(),
                    AssetModel = dataReader["asset_model"].ToString(),
                    AssetSerial = dataReader["asset_serial"].ToString(),
                    AssetSupplier = dataReader["asset_supplier"].ToString(),
                    QTY = int.Parse(dataReader["qty"].ToString()),
                    UnitName = dataReader["unit_name"].ToString(),
                    UserLocationName = dataReader["user_location_name"].ToString(),
                    AccountCodeCode = dataReader["account_code_cd"].ToString(),
                    AccountLocationCode = dataReader["account_location_cd"].ToString(),
                    RankCode = dataReader["rank_cd"].ToString(),
                    AccountLocationName = dataReader["account_location_name"].ToString(),
                    CommnetsData = dataReader["comment_data"].ToString(),
                    AssetLife = int.Parse(dataReader["asset_life"].ToString()),
                    AcquisitionDate = DateTime.Parse(dataReader["acquistion_date"].ToString()),
                    AcquisitionCost = double.Parse(dataReader["acquistion_cost"].ToString()),
                    StartDepreciation = DateTime.Parse(dataReader["depreciation_start"].ToString()),
                    EndDepreciation = DateTime.Parse(dataReader["depreciation_end"].ToString()),
                    CurrentDepreciation = double.Parse(dataReader["current_depreciation"].ToString()),
                    MonthlyDepreciation = double.Parse(dataReader["monthly_depreciation"].ToString()),
                    AccumDepreciation = double.Parse(dataReader["accum_depreciation_now"].ToString()),
                    NetValue = double.Parse(dataReader["net_value"].ToString()),
                    AssetInvoice = (dataReader["asset_invoice"].ToString()),
                    AssetType = dataReader["asset_type"].ToString(),
                    LabelStatus = (dataReader["label_status"].ToString()),
                    AssetPO = dataReader["asset_po"].ToString(),
                    Invertory = dataReader["invertory_time_cd"].ToString(),
                    InvertoryId = int.Parse(dataReader["invertory_time_id"].ToString()),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    RegistrationUserCode = (dataReader["registration_user_cd"].ToString()),
                    NowLocation = dataReader["nowloc"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }
}
