using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
   public class GetFactoryInfoFAWHDao: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            FactoryInfoFAWHVo inVo = (FactoryInfoFAWHVo)vo;
            ValueObjectList<FactoryInfoFAWHVo> voList = new ValueObjectList<FactoryInfoFAWHVo>();
            StringBuilder sql = new StringBuilder();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select distinct factory_cd, factory_name from m_factory where 1=1 ");
            if (!string.IsNullOrEmpty(inVo.factory_name))
                sql.Append("and factory_name='").Append(inVo.factory_name).Append("' ");
            sql.Append("order by factory_cd");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Clear();
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            while (datareader.Read())
            {
                FactoryInfoFAWHVo outVo = new FactoryInfoFAWHVo
                {
                    factory_cd = datareader["factory_cd"].ToString(),
                    factory_name = datareader["factory_name"].ToString()
                };
                voList.add(outVo);
            }
            datareader.Close();
            return voList;
        }
    }
}
