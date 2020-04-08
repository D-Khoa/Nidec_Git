using System;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo
{
   public class LocationInfoFAWHVo: ValueObject
    {
        public int location_id { get; set; }
        public string location_cd { get; set; }
        public string location_name { get; set; }
    }
}
