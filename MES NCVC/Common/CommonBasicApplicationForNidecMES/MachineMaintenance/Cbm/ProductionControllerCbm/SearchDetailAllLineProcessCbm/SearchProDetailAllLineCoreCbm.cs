﻿using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ProductionControllerCbm.SearchDetailAllLineProcessCbm
{
    public class SearchProDetailAllLineCoreCbm : CbmController
    {
        private static readonly DataAccessObject getDao = new SearchProDetailAllLineCoreDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            if (vo == null)
            {
                return null;
            }
            return getDao.Execute(trxContext, vo);
        }
    }
}