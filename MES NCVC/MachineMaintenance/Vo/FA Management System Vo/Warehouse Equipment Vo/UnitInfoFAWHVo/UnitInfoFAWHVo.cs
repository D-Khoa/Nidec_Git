using System;
using System.Data;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo
{
   public class UnitInfoFAWHVo: ValueObject
    {
        public int unit_id { get; set; }
        public string unit_cd { get; set; }
        public string unit_name { get; set; }
    }
}
