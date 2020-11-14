using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
   public class GetInventoryTimeFAWHDao: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InventoryTimeFAWHVo inVo = (InventoryTimeFAWHVo)vo;
            ValueObjectList<InventoryTimeFAWHVo> voList = new ValueObjectList<InventoryTimeFAWHVo>();
            StringBuilder sql = new StringBuilder();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select invertory_time_id, invertory_time_cd, invertory_time_name from m_invertory_time where 1=1 ");
            if (!string.IsNullOrEmpty(inVo.invertory_time_cd))
                sql.Append("and invertory_time_cd='").Append(inVo.invertory_time_cd).Append("' ");
            if (!string.IsNullOrEmpty(inVo.invertory_time_name))
                sql.Append("and invertory_time_name='").Append(inVo.invertory_time_name).Append("' ");
            sql.Append("order by invertory_time_id");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Clear();
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            while (datareader.Read())
            {
                InventoryTimeFAWHVo outVo = new InventoryTimeFAWHVo
                {
                    invertory_time_id = (int)datareader["invertory_time_id"],
                    invertory_time_cd = datareader["invertory_time_cd"].ToString(),
                    invertory_time_name = datareader["invertory_time_name"].ToString()
                };
                voList.add(outVo);
            }
            datareader.Close();
            return voList;
        }
    }
}
