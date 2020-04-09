﻿using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.OvenBarcodeLS12Cbm.OvenLS12Cbm
{
    public class GetBarcodeOvenLS12Cbm : CbmController
    {
        private static readonly DataAccessObject getDao = new GetBarcodeOvenLS12Dao();
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