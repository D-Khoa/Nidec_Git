using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class PCForm : FormCommon
    {
        bool pcmMocde;
        pts_item itemData { get; set; }
        pts_request_log requestData { get; set; }

        public PCForm()
        {
            InitializeComponent();
            itemData = new pts_item();
            requestData = new pts_request_log();
            grt_Main.ItemSize = new Size(0, 1);
            if (UserData.position == "MGR")
            {
                pcmMocde = true;
                btnAccept.Text = "Confirm";
                this.Text += "[PC Manager]";
            }
            else
            {
                pcmMocde = false;
                btnAccept.Text = "Apccept";
            }
        }

        #region MAIN TAB
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
        #endregion

        #region APPROVE REQUEST TAB
        private void btnSearch_Click(object sender, EventArgs e)
        {
            requestData.Search(new pts_request_log
            {
                item_cd = string.Empty,
                model_cd = string.Empty,
                destination_cd = string.Empty,
                remark = string.Empty,
            }, false, false, false);
            dgvRequest.DataSource = requestData.listRequestItem;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void btnDeny_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
