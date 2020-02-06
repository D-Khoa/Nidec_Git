using System;
using System.Data;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo
{
   public class AssetInfoFAWHVo: ValueObject
    {
        public int asset_id { get; set; }
        public string asset_cd { get; set; }
        public int asset_no { get; set; }
        public string asset_name { get; set; }
        public string asset_model { get; set; }
        public string asset_serial { get; set; }

        #region ACQUISITION
        public DateTime acquistion_date { get; set; }
        public double acquistion_cost { get; set; }
        public double asset_life { get; set; }
        #endregion

        public string asset_type { get; set; }
        public string asset_invoice { get; set; }
        public string asset_supplier { get; set; }
        public string factory_cd { get; set; }
        public string label_status { get; set; }
        public string asset_po { get; set; }

        #region REGISTRATION
        public string registration_user_cd { get; set; }
        public DateTime registration_date_time { get; set; }
        #endregion
    }
}
