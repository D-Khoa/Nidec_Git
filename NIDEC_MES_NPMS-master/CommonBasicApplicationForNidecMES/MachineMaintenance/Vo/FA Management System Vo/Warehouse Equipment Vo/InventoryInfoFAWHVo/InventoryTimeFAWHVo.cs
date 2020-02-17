using System;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo
{
   public class InventoryTimeFAWHVo: ValueObject
    {
        public int invertory_time_id { get; set; }
        public string invertory_time_cd { get; set; }
        public string invertory_time_name { get; set; }
    }
}
