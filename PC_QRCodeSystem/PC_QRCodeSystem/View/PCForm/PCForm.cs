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
            grt_Main.ItemSize = new Size(0, 1);
        }

        /// <summary>
        /// Open Stock In Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockIn_Click(object sender, EventArgs e)
        {
            StockInForm inFrm = new StockInForm();
            //StockInputForm inFrm = new StockInputForm();
            inFrm.ShowDialog();
        }

        /// <summary>
        /// Open Stock Out Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockOut_Click(object sender, EventArgs e)
        {
            StockOutForm outFrm = new StockOutForm();
            outFrm.ShowDialog();
        }

        /// <summary>
        /// Open Stock Detail Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockDetail_Click(object sender, EventArgs e)
        {
            StockDetailForm dtlFrm = new StockDetailForm();
            dtlFrm.ShowDialog();

        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            ItemManagement itemfrm = new ItemManagement();
            itemfrm.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm spfrm = new SupplierForm();
            spfrm.ShowDialog();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            DestinationManager desmg = new DestinationManager();
            desmg.Show();
        }

        private void btnIssueCode_Click(object sender, EventArgs e)
        {
            ItemIssueForm issfrm = new ItemIssueForm();
            issfrm.Show();
        }

        private void btnUserPosition_Click(object sender, EventArgs e)
        {
            UserPosition upfrm = new UserPosition();
            upfrm.Show();
        }
    }
}
