﻿using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.FA_Management_System_Cbm
{
   public class GetRankDeprFAWHCbm: CbmController
    {
        private static readonly DataAccessObject getDao = new GetRankDeprFAWHDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            if (vo == null)
                return null;
            return getDao.Execute(trxContext, vo);
        }
    }
}
