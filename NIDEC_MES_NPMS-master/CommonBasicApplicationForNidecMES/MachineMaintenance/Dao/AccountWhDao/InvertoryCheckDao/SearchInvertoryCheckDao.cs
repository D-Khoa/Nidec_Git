﻿using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchInvertoryCheckDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InvertoryVo inVo = (InvertoryVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<InvertoryVo> voList = new ValueObjectList<InvertoryVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            #region OLD SQL
            //sql.Append(@"select c.asset_id, a.invertory_time_id, a.invertory_time_cd,  a.invertory_time_name,b.invertory_equipments_id,  b.invertory_value, b.registration_user_cd, b.registration_date_time, b.factory_cd, d.asset_cd, d.asset_name, e.location_cd as beforelocation, f.rank_name , g.location_cd as nowlocation, c.warehouse_main_id from t_invertory_equipments b 
            //    left join m_invertory_time a on b.invertory_time_id = a.invertory_time_id
            //     left join t_warehouse_main c on b.warehouse_main_id = c.warehouse_main_id
            //    left join m_asset d on d.asset_id = c.asset_id
            //    left join m_location e on e.location_id = c.after_location_id
            //    left join m_rank f on f.rank_id = c.rank_id
            //      left join m_location g on g.location_id = b.location_id
            //    ");
            //sql.Append(" Where 1=1 ");

            //if (!string.IsNullOrEmpty(inVo.AssetCode))
            //{
            //    sql.Append(" and d.asset_cd = :asset_cd ");
            //    sqlParameter.AddParameterString("asset_cd", inVo.AssetCode);
            //}
            //if (!string.IsNullOrEmpty(inVo.InvertoryTimeCode))
            //{
            //    sql.Append(" and a.invertory_time_cd = :invertory_time_cd ");
            //    sqlParameter.AddParameterString("invertory_time_cd", inVo.InvertoryTimeCode);
            //}
            //if (!string.IsNullOrEmpty(inVo.NowLocation))
            //{
            //    sql.Append(" and g.location_cd = :location_cd ");
            //    sqlParameter.AddParameterString("location_cd", inVo.NowLocation);
            //}
            #endregion

            #region NEW SQL
            sql.Append("SELECT a.asset_id, a.asset_cd, a.asset_name, r.rank_name, lb.location_cd as beforelocation, ");
            sql.Append("ln.location_cd as nowlocation,  i.invertory_equipments_id, i.invertory_value, i.factory_cd, ");
            sql.Append("w.warehouse_main_id, i.registration_user_cd, i.registration_date_time ");
            sql.Append("FROM t_invertory_equipments i ");
            sql.Append("left join m_location ln on ln.location_id = i.location_id ");
            sql.Append("left join m_invertory_time t on t.invertory_time_id = i.invertory_time_id ");
            sql.Append("left join t_warehouse_main w on w.warehouse_main_id = i.warehouse_main_id ");
            sql.Append("left join m_asset a on a.asset_id = w.asset_id ");
            sql.Append("left join m_location lb on lb.location_id = w.after_location_id ");
            sql.Append("left join m_rank r on r.rank_id = w.rank_id ");
            //sql.Append("left join m_detail_postion dt on dt.detail_postion_id = w.detail_position_id ");
            sql.Append("WHERE 1=1 ");

            if (!string.IsNullOrEmpty(inVo.AssetCode))
            {
                sql.Append(" and a.asset_cd = :asset_cd ");
                sqlParameter.AddParameterString("asset_cd", inVo.AssetCode);
            }
            if (!string.IsNullOrEmpty(inVo.InvertoryTimeCode))
            {
                sql.Append(" and t.invertory_time_cd = :invertory_time_cd ");
                sqlParameter.AddParameterString("invertory_time_cd", inVo.InvertoryTimeCode);
            }
            if (!string.IsNullOrEmpty(inVo.NowLocation))
            {
                sql.Append(" and ln.location_cd = :location_cd ");
                sqlParameter.AddParameterString("location_cd", inVo.NowLocation);
            }
            //if (!string.IsNullOrEmpty(inVo.DetailPosition))
            //{
            //    sql.Append("and ld.detail_postion_cd = :detail_postion_cd ");
            //    sqlParameter.AddParameterString("detail_postion_cd", inVo.DetailPosition);
            //}
            #endregion
            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            while (dataReader.Read())
            {
                InvertoryVo outVo = new InvertoryVo
                {
                    InvertoryEquipmentId = int.Parse(dataReader["invertory_equipments_id"].ToString()),
                    AssetCode = dataReader["asset_cd"].ToString(),
                    AssetName = dataReader["asset_name"].ToString(),
                    InvertoryValue = bool.Parse(dataReader["invertory_value"].ToString()),
                    BeforeLocation = dataReader["beforelocation"].ToString(),
                    NowLocation = dataReader["nowlocation"].ToString(),
                   // DetailPosition = dataReader["detailpostion"].ToString(),
                    RankNameBefore = dataReader["rank_name"].ToString(),
                    RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    FactoryCode = dataReader["factory_cd"].ToString(),
                    WarehouseMainId = int.Parse(dataReader["warehouse_main_id"].ToString()),
                    AssetId = int.Parse(dataReader["asset_id"].ToString()),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
