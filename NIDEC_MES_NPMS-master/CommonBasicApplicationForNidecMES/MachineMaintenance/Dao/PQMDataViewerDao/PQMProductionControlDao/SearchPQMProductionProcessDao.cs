using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchPQMProductionProcessDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            PQMProductionControlVo inVo = (PQMProductionControlVo)vo;
            StringBuilder sql = new StringBuilder();
            PQMProductionControlVo voList = new PQMProductionControlVo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select inspect, sum(inspectdata) inspectdata  from  " + inVo.TableName);
            sql.Append(" a left join " + inVo.TableName + "data b on a.serno = b.serno where a.inspectdate = b.inspectdate ");
            sql.Append(@" and a.inspectdate >= :datefrom and a.inspectdate <= :dateto ");
            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);

            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(@" and a.model  =:model");
                sqlParameter.AddParameterString("model", inVo.ModelCode);
            }
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

            sql.Append(@" group by inspect order by inspect");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //execute SQL

            PQMProductionControlVo outVo1 = new PQMProductionControlVo
            {
                dt = ds.Tables[0],
            };

            return outVo1;

        }
    }
}