using System;
using System.Data;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo
{
  public  class UserLocationFAWHVo: ValueObject
    {
        public int user_location_id { get; set; }
        public string user_location_cd { get; set; }
        public string user_location_name { get; set; }
    }
}
