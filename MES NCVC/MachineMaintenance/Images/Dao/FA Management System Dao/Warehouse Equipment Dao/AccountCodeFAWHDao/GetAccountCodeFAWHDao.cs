using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
  public  class GetAccountCodeFAWHDao: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountCodeFAWHVo inVo = (AccountCodeFAWHVo)vo;
            ValueObjectList<AccountCodeFAWHVo> voList = new ValueObjectList<AccountCodeFAWHVo>();
            StringBuilder sql = new StringBuilder();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select account_code_id, account_code_cd, account_code_name from m_account_code where 1=1 ");
            if (!string.IsNullOrEmpty(inVo.account_code_cd))
                sql.Append("and account_code_cd='").Append(inVo.account_code_cd).Append("' ");
            if (!string.IsNullOrEmpty(inVo.account_code_name))
                sql.Append("and account_code_name='").Append(inVo.account_code_name).Append("' ");
            sql.Append("order by account_code_id");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Clear();
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            while (datareader.Read())
            {
                AccountCodeFAWHVo outVo = new AccountCodeFAWHVo
                {
                    account_code_id = (int)datareader["account_code_id"],
                    account_code_cd = datareader["account_code_cd"].ToString(),
                    account_code_name = datareader["account_code_name"].ToString()
                };
                voList.add(outVo);
            }
            datareader.Close();
            return voList;
        }
    }
}
