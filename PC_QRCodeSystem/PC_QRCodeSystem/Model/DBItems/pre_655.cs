using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    class pre_655
    {
        #region ALL FIELDS
        public string low_level_item { get; set; }
        public string high_level_item { get; set; }
        public string order_number { get; set; }
        public double request_qty { get; set; }
        public double no_issue_qty { get; set; }
        public List<pre_655> listIssueItem;
        public pre_655()
        {
            listIssueItem = new List<pre_655>();
        }
        #endregion

        /// <summary>
        /// Search request and no issue item
        /// </summary>
        /// <param name="inItem"></param>
        public void Search(pre_655 inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listIssueItem = new List<pre_655>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT low_level_item, high_level_item, order_number, request_qty, no_issue_qty ";
            query += "FROM pre_655 WHERE 1=1 ";
            if (!string.IsNullOrEmpty(inItem.low_level_item))
                query += "AND low_level_item ='" + inItem.low_level_item + "' ";
            if (!string.IsNullOrEmpty(inItem.high_level_item))
                query += "AND high_level_item ='" + inItem.high_level_item + "' ";
            if (!string.IsNullOrEmpty(inItem.order_number))
                query += "AND order_number ='" + inItem.order_number + "' ";
            query += "ORDER BY low_level_item, order_number";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pre_655 outItem = new pre_655
                {
                    low_level_item = reader["low_level_item"].ToString(),
                    high_level_item = reader["high_level_item"].ToString(),
                    order_number = reader["order_number"].ToString(),
                    request_qty = (double)reader["request_qty"],
                    no_issue_qty = (double)reader["no_issue_qty"],
                };
                //Add item into list
                listIssueItem.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }
    }
}
