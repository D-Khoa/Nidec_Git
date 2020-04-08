using System;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo
{
   public class FactoryInfoFAWHVo: ValueObject
    {
        public string factory_cd { get; set; }
        public string factory_name { get; set; }
    }
}
