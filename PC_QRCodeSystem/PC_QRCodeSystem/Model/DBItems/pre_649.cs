﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PC_QRCodeSystem.Model
{
    public class pre_649
    {
        #region ALL FIELDS
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
        public double order_qty { get; set; }
        public DateTime order_date { get; set; }
        public List<pre_649> listPremacItem;
        public pre_649()
        {
            listPremacItem = new List<pre_649>();
        }
        #endregion

        #region QUERY
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
            listPremacItem = query.OrderBy(x => x.delivery_date).ThenBy(x => x.supplier_invoice).ThenBy(x => x.item_number).ToList();
            //listPremacItem.Sort((a, b) => a.item_number.CompareTo(b.item_number));
            //listPremacItem.OrderBy(x => x.delivery_date).ThenBy(x => x.supplier_invoice).ThenBy(x => x.item_number);
            return listPremacItem;
        }

        /// <summary>
        /// Search list premac item from DB
        /// </summary>
        /// <param name="inItem">search info</param>
        public void Search(pre_649 inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listPremacItem = new List<pre_649>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT item_number, item_name, supplier_cd, supplier_name, supplier_invoice, sum(delivery_qty) as delivery_qty, delivery_date, incharge ";
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
            query += "GROUP BY item_number, item_name, supplier_cd, supplier_name, supplier_invoice, delivery_date, incharge ";
            query += "ORDER BY delivery_date, supplier_invoice, item_number";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pre_649 outItem = new pre_649
                {
                    //premac_id = (int)reader["premac_id"],
                    item_number = reader["item_number"].ToString(),
                    item_name = reader["item_name"].ToString(),
                    supplier_cd = reader["supplier_cd"].ToString(),
                    supplier_name = reader["supplier_name"].ToString(),
                    supplier_invoice = reader["supplier_invoice"].ToString(),
                    //po_number = reader["po_number"].ToString(),
                    delivery_qty = (double)reader["delivery_qty"],
                    delivery_date = (DateTime)reader["delivery_date"],
                    //order_number = reader["order_number"].ToString(),
                    incharge = reader["incharge"].ToString()
                };
                //Add item into list
                listPremacItem.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
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
            query = "SELECT item_number, item_name, supplier_cd, supplier_name, supplier_invoice, sum(delivery_qty) as delivery_qty, delivery_date, incharge ";
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
            query += "GROUP BY item_number, item_name, supplier_cd, supplier_name, supplier_invoice, delivery_date, incharge ";
            query += "ORDER BY delivery_date DESC, supplier_invoice, item_number";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pre_649 outItem = new pre_649
                {
                    //premac_id = (int)reader["premac_id"],
                    item_number = reader["item_number"].ToString(),
                    item_name = reader["item_name"].ToString(),
                    supplier_cd = reader["supplier_cd"].ToString(),
                    supplier_name = reader["supplier_name"].ToString(),
                    supplier_invoice = reader["supplier_invoice"].ToString(),
                    //po_number = reader["po_number"].ToString(),
                    delivery_qty = (double)reader["delivery_qty"],
                    delivery_date = (DateTime)reader["delivery_date"],
                    //order_number = reader["order_number"].ToString(),
                    incharge = reader["incharge"].ToString()
                };
                //Add item into list
                listPremacItem.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }

        public void SearchOrder(pre_649 inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listPremacItem = new List<pre_649>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT item_number, order_number, order_qty, order_date,supplier_cd ";
            query += "FROM pre_649 WHERE 1=1 ";
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
                pre_649 outItem = new pre_649
                {
                    item_number = reader["item_number"].ToString(),
                    order_number = reader["order_number"].ToString(),
                    order_qty = (double)reader["order_qty"],
                    order_date = (DateTime)reader["order_date"],
                    supplier_cd = reader["supplier_cd"].ToString(),
                };
                //Add item into list
                listPremacItem.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }

        public string AddLenData(string datastring, int leng)
        {
            int datalen = datastring.Length;
            if (datalen < leng)
            {
                for (int i = 0; i < (leng - datalen); i++)
                {
                    datastring += " ";
                }
            }
            return datastring;
        }
        /// <summary>
        /// Export list item for menu PREMAC 6-4-9
        /// </summary>
        /// <param name="inList"></param>
        public void ExportCSV(List<pre_649> inList)
        {
            var properties = inList[0].GetType().GetProperties();
            string foldername = SettingItem.outputFolder + @"\StockIn";
            string bkfoldername = SettingItem.backupFolder + @"\BKStockIn";
            if (!Directory.Exists(foldername)) Directory.CreateDirectory(foldername);
            if (!Directory.Exists(bkfoldername)) Directory.CreateDirectory(bkfoldername);
            string filename = @"\stockin_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            using (StreamWriter sw = new StreamWriter(foldername + filename))
            {
                string line = string.Empty;
                //Write columns
                line = string.Join("?", properties.Where(x => x.Name != "premac_id").Select(x => x.Name));
                sw.WriteLine(line);
                for (int i = 0; i < inList.Count; i++)
                {
                    //var propretiesValue = inList[i].GetType().GetProperties();
                    //line = string.Join("?", (from x in propretiesValue
                    //                         where x.Name != "premac_id"
                    //                         select x.Name == "delivery_date" ?
                    //                         ((DateTime)x.GetValue(inList[i], null)).ToString("yyyy-MM-dd")
                    //                         : x.GetValue(inList[i], null)));

                    line = AddLenData(inList[i].item_number.ToString(), 30);
                    line += "?" + AddLenData(inList[i].item_name.ToString(), 30);
                    line += "?" + AddLenData(inList[i].supplier_cd.ToString(), 30);
                    line += "?" + AddLenData(inList[i].supplier_name.ToString(), 30);
                    line += "?" + AddLenData(inList[i].supplier_invoice.ToString(), 30);
                    line += "?" + AddLenData(inList[i].po_number.ToString(), 30);
                    line += "?" + AddLenData(inList[i].delivery_qty.ToString(), 30);
                    line += "?" + AddLenData(inList[i].delivery_date.ToString("yyyy-MM-dd"), 30);
                    line += "?" + AddLenData(inList[i].order_number.ToString(), 30);
                    line += "?" + AddLenData(inList[i].incharge.ToString(), 30);
                    line += "?" + AddLenData(inList[i].order_qty.ToString(), 30);
                    line += "?" + AddLenData(inList[i].order_date.ToString("yyyy-MM-dd"), 30);
                    sw.WriteLine(line);
                }
                sw.Flush();
                sw.Close();
            }
            File.Copy(foldername + filename, bkfoldername + filename);
        }
        #endregion
    }
}
