using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchPQMQtyNOICHKfromMesdbDao : AbstractDataAccessObject
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

            sql.Append("select count (*) datas from (");
            sql.Append("select distinct barcode from t_noisecheck_a90 ");
            sql.Append("where  date_check >= :datefrom and date_check <= :dateto ");
           if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(@" and model  =:model");
                sqlParameter.AddParameterString("model", inVo.ModelCode);
            }
            if (inVo.change)//search theo line
            {
                sql.Append(@" and line  =:line");
                sqlParameter.AddParameterString("line", inVo.LineCode);
            }
            else//search tat ca line
            {
                //de cho vui thui @@
            }
            sql.Append(@" ) tbl");

            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                PQMProductionControlVo outVo = new PQMProductionControlVo
                {
                    InspecData = dataReader["datas"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;

        }
    }
}