using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    public class pre_223
    {
        #region ALL FIELDS
        public string high_level_item { get; set; }
        public string low_level_item { get; set; }
        public double numerator { get; set; }
        public List<pre_223> listStructItem { get; set; }
        public pre_223()
        {
            listStructItem = new List<pre_223>();
        }
        #endregion

        #region QUERY
        /// <summary>
        /// Search product truct item
        /// </summary>
        /// <param name="inItem">high level item</param>
        /// <param name="orderQty">request qty</param>
        /// <returns>list low item and qty</returns>
        public List<pre_223_view> Search(string inItem, double orderQty)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            List<pre_223_view> outList = new List<pre_223_view>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            //Search low level item
            query = "WITH RECURSIVE top_level as (SELECT high_level_item, low_level_item, numerator FROM pre_223 where high_level_item = '" + inItem + "' ";
            query += "UNION SELECT b.high_level_item, b.low_level_item, b.numerator FROM top_level a, pre_223 b where b.high_level_item = a.low_level_item) ";
            query += "SELECT c.low_level_item, d.item_name, d.item_location, d.item_unit, (c.numerator*" + orderQty.ToString() + ") as request_qty, d.wh_qty ";
            query += "FROM top_level c LEFT JOIN  pts_item d on c.low_level_item = d.item_cd ORDER BY low_level_item;"; //WHERE type_id not in('2','5','9') if want skip
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pre_223_view outItem = new pre_223_view
                {
                    low_level_item = reader["low_level_item"].ToString(),
                    item_name = reader["item_name"].ToString(),
                    item_location = reader["item_location"].ToString(),
                    item_unit = reader["item_unit"].ToString(),
                    request_qty = (double)reader["request_qty"],
                    wh_qty = (double)reader["wh_qty"],
                };
                //Add item into list
                outList.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
            return outList;
        }
        #endregion
    }
}
