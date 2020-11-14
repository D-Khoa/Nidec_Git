using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.PQMDataViewerCbm.PQMProductionControlCbm
{
    public class GetPQMProductionLineCbm : CbmController
    {
        private static readonly DataAccessObject getDao = new GetPQMProductionLineDao();
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