using System;
using System.Data;
using System.Text;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetListLocationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UserLocationVo inVo = (UserLocationVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<LocationVo> voList = new ValueObjectList<LocationVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("SELECT location_id, location_cd, location_name, building_id, registration_user_cd, registration_date_time, factory_cd FROM m_location WHERE 1=1 ");
            if (inVo.DeptCode != "ACT" && inVo.UserLocationCode != "admin")
            {
                sql.Append("AND location_cd in (select dept_cd from  m_user_location Where 1=1");
                if (!string.IsNullOrEmpty(inVo.UserLocationCode))
                {
                    sql.Append(" and user_location_cd = :user_location_cd ");
                    sqlParameter.AddParameterString("user_location_cd", inVo.UserLocationCode);
                }
                sql.Append(")");
            }
            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                LocationVo outVo = new LocationVo
                {
                    LocationId = int.Parse(dataReader["location_id"].ToString()),
                    LocationCode = dataReader["location_cd"].ToString(),
                    LocationName = dataReader["location_name"].ToString(),
                    BuildingId = int.Parse(dataReader["building_id"].ToString()),
                    RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    FactoryCode = dataReader["factory_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
