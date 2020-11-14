using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetPQMProductionModelDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            PQMProductionControlVo inVo = (PQMProductionControlVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<PQMProductionControlVo> voList = new ValueObjectList<PQMProductionControlVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select distinct model from modeltbl order by model");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                PQMProductionControlVo outVo = new PQMProductionControlVo
                {
                    ModelCode = dataReader["model"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}