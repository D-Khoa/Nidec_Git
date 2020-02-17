using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
   public class GetInventoryTimeMaxFAWHDao: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InventoryTimeFAWHVo inVo = (InventoryTimeFAWHVo)vo;
            InventoryTimeFAWHVo outVo = new InventoryTimeFAWHVo();
            StringBuilder sql = new StringBuilder();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select invertory_time_id, invertory_time_cd, invertory_time_name from m_invertory_time ");
            sql.Append("where registration_date_time = (select max(registration_date_time) from m_invertory_time)");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Clear();
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            while (datareader.Read())
            {
                outVo.invertory_time_id = (int)datareader["invertory_time_id"];
                outVo.invertory_time_cd = datareader["invertory_time_cd"].ToString();
                outVo.invertory_time_name = datareader["invertory_time_name"].ToString();
            }
            datareader.Close();
            return outVo;
        }
    }
}
