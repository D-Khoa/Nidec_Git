﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    public class pre_649
    {
        #region ALL FIELDS
        public int premac_id { get; set; }
        public string item_number { get; set; }
        public string item_name { get; set; }
        public string supplier_cd { get; set; }
        public string supplier_name { get; set; }
        public string supplier_invoice { get; set; }
        public string po_number { get; set; }
        public double delivery_qty { get; set; }
        public DateTime delivery_date { get; set; }
        public string order_number { get; set; }
        public string incharge { get; set; }
        public List<pre_649> listPremacItem;
        public pre_649()
        {
            listPremacItem = new List<pre_649>();
        }
        #endregion

        /// <summary>
        /// Get list PREMAC 6-4-9 from txt file
        /// </summary>
        /// <param name="premacfile">path of PREMAC file</param>
        /// <returns></returns>
        public List<pre_649> GetListPremacItem(string premacfile)
        {
            listPremacItem = new List<pre_649>();
            string[] csvlines = File.ReadAllLines(premacfile);
            IEnumerable<pre_649> query = from csvline in csvlines
                                         where (!csvline.Contains("(CPFXE049)") && !csvline.Contains("SupplierCD"))
                                         let columns = csvline.Split('?')
                                         select new pre_649
                                         {
                                             item_number = Regex.Replace(columns[2], " {2,}", " ").Trim(),
                                             item_name = Regex.Replace(columns[3], " {2,}", " ").Trim(),
                                             po_number = Regex.Replace(columns[4], " {2,}", " ").Trim(),
                                             order_number = Regex.Replace(columns[5], " {2,}", " ").Trim(),
                                             supplier_cd = Regex.Replace(columns[0], " {2,}", " ").Trim(),
                                             supplier_name = Regex.Replace(columns[1], " {2,}", " ").Trim(),
                                             supplier_invoice = Regex.Replace(columns[29], " {2,}", " ").Trim(),
                                             delivery_date = DateTime.Parse(Regex.Replace(columns[9], " {2,}", " ").Trim()),
                                             delivery_qty = !string.IsNullOrEmpty(Regex.Replace(columns[10], " {2,}", " ").Trim()) ?
                                                            double.Parse(Regex.Replace(columns[10], " {2,}", " ").Trim()) : 0,
                                             incharge = Regex.Replace(columns[14], " {2,}", " ").Trim(),
                                         };
            listPremacItem = query.ToList();
            listPremacItem.Sort((a, b) => a.item_number.CompareTo(b.item_number));
            return listPremacItem;
        }

        /// <summary>
        /// Search list premac item from DB
        /// </summary>
        /// <param name="inItem">search info</param>
        public void Search(pre_649 inItem, DateTime fromdate, DateTime todate, bool checkdate)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listPremacItem = new List<pre_649>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT premac_id, item_number, item_name, supplier_cd, supplier_name, supplier_invoice, po_number, delivery_qty, delivery_date, order_number, incharge ";
            query += "FROM pre_649 WHERE 1=1 ";
            if (!string.IsNullOrEmpty(inItem.item_number))
                query += "AND item_number ='" + inItem.item_number + "' ";
            if (!string.IsNullOrEmpty(inItem.item_name))
                query += "AND item_name ='" + inItem.item_name + "' ";
            if (!string.IsNullOrEmpty(inItem.supplier_cd))
                query += "AND supplier_cd ='" + inItem.supplier_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.supplier_invoice))
                query += "AND supplier_invoice ='" + inItem.supplier_invoice + "' ";
            if (!string.IsNullOrEmpty(inItem.po_number))
                query += "AND po_number ='" + inItem.po_number + "' ";
            if (!string.IsNullOrEmpty(inItem.order_number))
                query += "AND order_number ='" + inItem.order_number + "' ";
            if (checkdate)
                query += "AND delivery_date >='" + fromdate + "' AND delivery_date <='" + todate + "' ";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pre_649 outItem = new pre_649
                {
                    premac_id = (int)reader["premac_id"],
                    item_number = reader["item_number"].ToString(),
                    item_name = reader["item_name"].ToString(),
                    supplier_cd = reader["supplier_cd"].ToString(),
                    supplier_name = reader["supplier_name"].ToString(),
                    supplier_invoice = reader["supplier_invoice"].ToString(),
                    po_number = reader["po_number"].ToString(),
                    delivery_qty = (double)reader["delivery_qty"],
                    delivery_date = (DateTime)reader["delivery_date"],
                    order_number = reader["order_number"].ToString(),
                    incharge = reader["incharge"].ToString()
                };
                //Add item into list
                listPremacItem.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }

        public void ExportCSV(List<pre_649> inList)
        {

        }
    }
}
