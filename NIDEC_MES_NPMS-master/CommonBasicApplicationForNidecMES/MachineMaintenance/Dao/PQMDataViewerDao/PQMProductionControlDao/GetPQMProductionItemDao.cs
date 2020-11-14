using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetPQMProductionItemDao : AbstractDataAccessObject
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
            sql.Append(@"select distinct b.inspect from " +  inVo.TableName);
            sql.Append(" a left join " + inVo.TableName +"data b on a.serno = b.serno where a.inspectdate = b.inspectdate ");

            if (!string.IsNullOrEmpty(inVo.LineCode))
            {
                sql.Append(@" and a.line  =:line");
                sqlParameter.AddParameterString("line", inVo.LineCode);
            }
            if (!string.IsNullOrEmpty(inVo.ProcessCode))
            {
                sql.Append(@" and a.process  =:process");
                sqlParameter.AddParameterString("process", inVo.ProcessCode);
            }
            sql.Append(@" order by b.inspect");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                PQMProductionControlVo outVo = new PQMProductionControlVo
                {
                    ItemCode = dataReader["inspect"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}