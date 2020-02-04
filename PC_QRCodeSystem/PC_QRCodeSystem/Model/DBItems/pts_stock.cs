using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    /// <summary>
    ///STOCK ITEM IN PRODUCTION TRACEBILITY SYSTEM
    /// </summary>
    public class pts_stock
    {
        #region FIELDS OF STOCK ITEM
        public string stock_id { get; set; }
        public string packing_cd { get; set; }
        public string item_cd { get; set; }
        public string supplier_cd { get; set; }
        public string order_no { get; set; }
        public string invoice { get; set; }
        public string po_no { get; set; }
        public DateTime stockin_date { get; set; }
        public string stockin_user_cd { get; set; }
        public double stockin_qty { get; set; }
        public double packing_qty { get; set; }
        public string registration_user_cd { get; set; }
        public DateTime registration_date_time { get; set; }
        public List<pts_stock> listStockItems { get; set; }
        #endregion

        public pts_stock()
        {
            listStockItems = new List<pts_stock>();
        }
        public void GetListStockItem(pts_stock inItem)
        {

        }

    }
}
