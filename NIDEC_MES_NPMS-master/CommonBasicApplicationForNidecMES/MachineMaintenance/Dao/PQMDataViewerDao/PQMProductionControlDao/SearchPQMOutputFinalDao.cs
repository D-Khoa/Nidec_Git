using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchPQMOutputFinalDao : AbstractDataAccessObject
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
            
            sql.Append("select count(distinct barcode) from t_serno where 1=1 ");
            sql.Append(" and regist_date >= :datefrom and regist_date <= :dateto ");
            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(@" and model  =:model");
                sqlParameter.AddParameterString("model", inVo.ModelCode);
            }
            if (!string.IsNullOrEmpty(inVo.LineCode))
            {
                sql.Append(@" and line  =:line");
                sqlParameter.AddParameterString("line", inVo.LineCode);
            }

            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                PQMProductionControlVo outVo = new PQMProductionControlVo
                {
                    InspecData = dataReader["count"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;

        }
    }
}