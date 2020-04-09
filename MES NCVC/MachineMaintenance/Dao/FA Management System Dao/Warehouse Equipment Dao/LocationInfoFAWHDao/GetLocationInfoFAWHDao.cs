using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
   public class GetLocationInfoFAWHDao: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            LocationInfoFAWHVo inVo = (LocationInfoFAWHVo)vo;
            ValueObjectList<LocationInfoFAWHVo> voList = new ValueObjectList<LocationInfoFAWHVo>();
            StringBuilder sql = new StringBuilder();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select distinct location_id, location_cd, location_name from m_location where 1=1");
            if (!string.IsNullOrEmpty(inVo.location_cd))
                sql.Append("and location_cd='").Append(inVo.location_cd).Append("' ");
            if (!string.IsNullOrEmpty(inVo.location_name))
                sql.Append("and location_name='").Append(inVo.location_name).Append("' ");
            sql.Append("order by location_id");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Clear();
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            while (datareader.Read())
            {
                LocationInfoFAWHVo outVo = new LocationInfoFAWHVo
                {
                    location_id = (int)datareader["location_id"],
                    location_cd = datareader["location_cd"].ToString(),
                    location_name = datareader["location_name"].ToString()
                };
                voList.add(outVo);
            }
            datareader.Close();
            return voList;
        }
    }
}
