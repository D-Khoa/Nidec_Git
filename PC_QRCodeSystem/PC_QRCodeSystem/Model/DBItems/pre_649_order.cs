using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PC_QRCodeSystem.Model
{
    public class pre_649_order
    {
        #region ALL FIELDS
        public string item_number { get; set; }
        public string order_number { get; set; }
        public double order_qty { get; set; }
        public string supplier_cd { get; set; }
        public DateTime order_date { get; set; }
        public List<pre_649_order> listOrderItem;
        public pre_649_order()
        {
            listOrderItem = new List<pre_649_order>();
        }
        #endregion

        /// <summary>
        /// Get list PREMAC 6-4-9 from txt file
        /// </summary>
        /// <param name="premacfile">path of PREMAC file</param>
        /// <returns></returns>
        public List<pre_649_order> GetListPremacItem(string premacfile)
        {
            listOrderItem = new List<pre_649_order>();
            string[] csvlines = File.ReadAllLines(premacfile);
            IEnumerable<pre_649_order> query = from csvline in csvlines
                                               where (!csvline.Contains("(CPFXE049)") && !csvline.Contains("SupplierCD"))
                                               let columns = csvline.Split('?')
                                               select new pre_649_order
                                               {
                                                   item_number = Regex.Replace(columns[2], " {2,}", " ").Trim(),
                                                   order_number = Regex.Replace(columns[5], " {2,}", " ").Trim(),
                                                   order_qty = !string.IsNullOrEmpty(Regex.Replace(columns[8], " {2,}", " ").Trim()) ?
                                                                double.Parse(Regex.Replace(columns[8], " {2,}", " ").Trim()) : 0,
                                                   supplier_cd = Regex.Replace(columns[0], " {2,}", " ").Trim(),
                                                   order_date = DateTime.Parse(Regex.Replace(columns[7], " {2,}", " ").Trim()),
                                               };
            listOrderItem = query.ToList();
            listOrderItem.Sort((a, b) => a.item_number.CompareTo(b.item_number));
            return listOrderItem;
        }

        /// <summary>
        /// Search list premac item from DB
        /// </summary>
        /// <param name="inItem">search info</param>
        public void Search(pre_649_order inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listOrderItem = new List<pre_649_order>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT item_number, order_number, order_qty, supplier_cd, order_date ";
            query += "FROM pre_649_order WHERE 1=1 ";
            if (!string.IsNullOrEmpty(inItem.item_number))
                query += "AND item_number ='" + inItem.item_number + "' ";
            if (!string.IsNullOrEmpty(inItem.order_number))
                query += "AND order_number ='" + inItem.order_number + "' ";
            query += "ORDER BY item_number, order_date";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pre_649_order outItem = new pre_649_order
                {
                    item_number = reader["item_number"].ToString(),
                    order_number = reader["order_number"].ToString(),
                    order_qty = (double)reader["order_qty"],
                    supplier_cd = reader["supplier_cd"].ToString(),
                    order_date = (DateTime)reader["order_date"],
                };
                //Add item into list
                listOrderItem.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }

        /// <summary>
        /// Search list premac item from DB
        /// </summary>
        /// <param name="inItem">search info</param>
        public void Search(pre_649_order inItem, DateTime fromdate, DateTime todate, bool checkdate)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listOrderItem = new List<pre_649_order>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT item_number, order_number, order_qty, supplier_cd, order_date ";
            query += "FROM pre_649_order WHERE 1=1 ";
            if (!string.IsNullOrEmpty(inItem.item_number))
                query += "AND item_number ='" + inItem.item_number + "' ";
            if (!string.IsNullOrEmpty(inItem.order_number))
                query += "AND order_number ='" + inItem.order_number + "' ";
            if (checkdate)
                query += "AND order_date >='" + fromdate + "' AND order_date <='" + todate + "' ";
            query += "ORDER BY item_number, order_date";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pre_649_order outItem = new pre_649_order
                {
                    item_number = reader["item_number"].ToString(),
                    order_number = reader["order_number"].ToString(),
                    order_qty = (double)reader["order_qty"],
                    supplier_cd = reader["supplier_cd"].ToString(),
                    order_date = (DateTime)reader["order_date"],
                };
                //Add item into list
                listOrderItem.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }
    }
}
