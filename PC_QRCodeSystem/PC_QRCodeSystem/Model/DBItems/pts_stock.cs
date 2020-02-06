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
        public int AddItem(pts_stock inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "INSERT INTO pts_stock(packing_cd, item_cd, supplier_cd, order_no, invoice, po_no, stockin_date,";
            query += "stockin_user_cd, stockin_qty, packing_qty, registration_user_cd) VALUES ";
            query += "('" + inItem.packing_cd + "','" + inItem.item_cd + "','" + inItem.supplier_cd + "','" + inItem.order_no + "','";
            query += inItem.invoice + "','" + inItem.po_no + "','" + inItem.stockin_date + "','" + inItem.stockin_user_cd + "','";
            query += inItem.stockin_qty + "','" + inItem.packing_qty + "','" + inItem.registration_user_cd + "')";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }

    }
}
