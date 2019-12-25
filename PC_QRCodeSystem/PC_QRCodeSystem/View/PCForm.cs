using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_QRCodeSystem.View
{
    public partial class PCForm : FormCommon
    {
        public PCForm()
        {
            InitializeComponent();
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            StockInForm inFrm = new StockInForm();
            inFrm.ShowDialog();
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {

        }

        private void btnStockDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
