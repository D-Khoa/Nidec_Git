using System;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo
{
   public class RankInfoFAWHVo: ValueObject
    {
        public int rank_id { get; set; }
        public string rank_cd { get; set; }
        public string rank_name { get; set; }
    }
}
