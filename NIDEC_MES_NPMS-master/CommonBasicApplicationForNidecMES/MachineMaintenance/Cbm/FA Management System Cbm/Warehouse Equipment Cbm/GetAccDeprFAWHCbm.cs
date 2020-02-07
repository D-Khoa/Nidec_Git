﻿using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.FA_Management_System_Cbm
{
   public class GetAccDeprFAWHCbm:CbmController
    {
        private static readonly DataAccessObject getDao = new GetAccDeprFAWHDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            if (vo == null)
                return null;
            return getDao.Execute(trxContext, vo);
        }
    }
}