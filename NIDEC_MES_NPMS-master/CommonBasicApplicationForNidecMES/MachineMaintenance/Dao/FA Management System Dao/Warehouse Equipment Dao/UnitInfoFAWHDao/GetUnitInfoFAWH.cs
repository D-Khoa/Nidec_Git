using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
   public class GetUnitInfoFAWH: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UnitInfoFAWHVo inVo = (UnitInfoFAWHVo)vo;
            ValueObjectList<UnitInfoFAWHVo> voList = new ValueObjectList<UnitInfoFAWHVo>();
            StringBuilder sql = new StringBuilder();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select unit_id, unit_cd, unit_name from m_unit where 1=1 ");
            if (!string.IsNullOrEmpty(inVo.unit_cd))
                sql.Append("unit_cd='").Append(inVo.unit_cd).Append("' ");
            if (!string.IsNullOrEmpty(inVo.unit_name))
                sql.Append("unit_name='").Append(inVo.unit_name).Append("' ");
            sql.Append("order by unit_id");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Clear();
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            while (datareader.Read())
            {
                UnitInfoFAWHVo outVo = new UnitInfoFAWHVo
                {
                    unit_id = (int)datareader["unit_id"],
                    unit_cd = datareader["unit_cd"].ToString(),
                    unit_name = datareader["unit_name"].ToString()
                };
                voList.add(outVo);
            }
            datareader.Close();
            return voList;
        }
    }
}
