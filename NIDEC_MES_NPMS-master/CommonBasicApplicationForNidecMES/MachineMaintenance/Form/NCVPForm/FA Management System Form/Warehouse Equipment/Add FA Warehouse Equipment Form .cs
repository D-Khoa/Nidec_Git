using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.FA_Management_System_Vo.Warehouse_Equipment_Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao.FA_Management_System_Dao.Warehouse_Equipment_Dao;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.FA_Management_System_Cbm.Warehouse_Equipment_Cbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.NCVPForm.FA_Management_System_Form
{
    public partial class Add_FA_Warehouse_Equipment_Form : FormCommonNCVP
    {
        public Add_FA_Warehouse_Equipment_Form()
        {
            InitializeComponent();
        }
        public AccountInfoFAWHVo accountmainVo = new AccountInfoFAWHVo();
    }
}
