using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao
{
   public class AddAssetFAWHDao: AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AssetInfoFAWHVo inVo = (AssetInfoFAWHVo)vo;
            StringBuilder sql = new StringBuilder();

            sql.Append(@"INSERT INTO m_asset(
            asset_no, asset_cd, asset_name, asset_model, asset_serial, asset_supplier, asset_invoice, asset_life, acquistion_date,
            acquistion_cost, asset_type, registration_user_cd, registration_date_time, factory_cd, label_status, asset_po)
            VALUES(:asset_no, :asset_cd, :asset_name, :asset_model, :asset_serial, :asset_supplier, 
            :asset_invoice, :asset_life, :acquistion_date, :acquistion_cost, :asset_type, :registration_user_cd, 
            :registration_date_time, :factory_cd, :label_status, :asset_po)");

            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("asset_no", inVo.asset_no);
            sqlParameter.AddParameterString("asset_cd", inVo.asset_cd);
            sqlParameter.AddParameterString("asset_name", inVo.asset_name);
            sqlParameter.AddParameterString("asset_model", inVo.asset_model);
            sqlParameter.AddParameterString("asset_serial", inVo.asset_serial);
            sqlParameter.AddParameterString("asset_supplier", inVo.asset_supplier);
            sqlParameter.AddParameterString("asset_invoice", inVo.asset_invoice);
            sqlParameter.AddParameter("asset_life", inVo.asset_life);
            sqlParameter.AddParameterDateTime("acquistion_date", inVo.acquistion_date);
            sqlParameter.AddParameter("acquistion_cost", inVo.acquistion_cost);
            sqlParameter.AddParameterString("asset_type", inVo.asset_type);
            sqlParameter.AddParameterString("registration_user_cd", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registration_date_time", DateTime.Now);
            sqlParameter.AddParameterString("factory_cd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterString("label_status", inVo.label_status);
            sqlParameter.AddParameterString("asset_po", inVo.asset_po);
            sql.Clear();

            //EXECUTE READER FROM COMMAND
            AssetMasterFAWHVo outVo = new AssetMasterFAWHVo
            {
                executeInt = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };
            return outVo;
        }
    }
}
