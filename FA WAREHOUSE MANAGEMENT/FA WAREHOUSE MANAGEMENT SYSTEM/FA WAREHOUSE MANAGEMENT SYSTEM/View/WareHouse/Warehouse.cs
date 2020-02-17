using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FA_WAREHOUSE_MANAGEMENT_SYSTEM.View
{
    public partial class Warehouse :FormCommon
    {
        public Warehouse()
        {
            InitializeComponent();
        }

        private void btnWHEquipment_Click(object sender, EventArgs e)
        {
            Warehouse_Equipment_Form wheq = new Warehouse_Equipment_Form();
            wheq.ShowDialog();

        }

        private void btnWHInput_Click(object sender, EventArgs e)
        {
            Warehouse_Input_Form whip = new Warehouse_Input_Form();
            whip.ShowDialog();
        }

        private void btnWHOutput_Click(object sender, EventArgs e)
        {
            Warehouse_Output_Form whop = new Warehouse_Output_Form();
            whop.ShowDialog();
        }
    }
}
