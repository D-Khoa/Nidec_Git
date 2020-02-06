﻿using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
   public class DeleteAssetFAWHDao: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AssetMasterFAWHVo inVo = (AssetMasterFAWHVo)vo;
            StringBuilder sql = new StringBuilder();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("DELETE from m_asset where 1=1 ");
            if (!string.IsNullOrEmpty(inVo.asset_cd))
                sql.Append("and asset_cd = '").Append(inVo.asset_cd).Append("' ");
            if (!string.IsNullOrEmpty(inVo.asset_name))
                sql.Append("and asset_name = '").Append(inVo.asset_name).Append("' ");
            if (!string.IsNullOrEmpty(inVo.asset_type))
                sql.Append("and asset_type = '").Append(inVo.asset_type).Append("' ");
            if (!string.IsNullOrEmpty(inVo.asset_life))
                sql.Append("and asset_life = '").Append(inVo.asset_life).Append("' ");
            //if (inVo.checkDateFrom)
            //    sql.Append("and acquistion_date > '").Append(inVo.dateFrom.ToString("yyyy-MM-dd")).Append("' ");
            //if (inVo.checkDateTo)
            //    sql.Append("and acquistion_date < '").Append(inVo.dateTo.ToString("yyyy-MM-dd")).Append("' ");
            //sql.Append("order by asset_cd");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Clear();
            //EXECUTE READER FROM COMMAND
            int datareader = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);
            return inVo;
        }
    }
}
