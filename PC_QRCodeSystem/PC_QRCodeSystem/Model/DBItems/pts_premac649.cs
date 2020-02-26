using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PC_QRCodeSystem.Model
{
    public class pts_premac649
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
        public string oder_number { get; set; }
        public string incharge { get; set; }
        public List<pts_premac649> listPremacItem;
        public pts_premac649()
        {
            listPremacItem = new List<pts_premac649>();
        }
        #endregion

        /// <summary>
        /// Get list PREMAC 6-4-9 from txt file
        /// </summary>
        /// <param name="premacfile">path of PREMAC file</param>
        /// <returns></returns>
        public void GetListPremacItem(string premacfile)
        {
            string[] csvlines = File.ReadAllLines(premacfile);
            IEnumerable<pts_premac649> query = from csvline in csvlines
                                               where (!csvline.Contains("(CPFXE049)") && !csvline.Contains("SupplierCD"))
                                               let columns = csvline.Split('?')
                                               select new pts_premac649
                                               {
                                                   item_number = Regex.Replace(columns[2], " {2,}", " ").Trim(),
                                                   item_name = Regex.Replace(columns[3], " {2,}", " ").Trim(),
                                                   po_number = Regex.Replace(columns[4], " {2,}", " ").Trim(),
                                                   oder_number = Regex.Replace(columns[5], " {2,}", " ").Trim(),
                                                   supplier_cd = Regex.Replace(columns[0], " {2,}", " ").Trim(),
                                                   supplier_name = Regex.Replace(columns[1], " {2,}", " ").Trim(),
                                                   supplier_invoice = Regex.Replace(columns[29], " {2,}", " ").Trim(),
                                                   delivery_date = DateTime.Parse(Regex.Replace(columns[9], " {2,}", " ").Trim()),
                                                   delivery_qty = !string.IsNullOrEmpty(Regex.Replace(columns[10], " {2,}", " ").Trim()) ?
                                                                  double.Parse(Regex.Replace(columns[10], " {2,}", " ").Trim()) : 0,
                                                   incharge = Regex.Replace(columns[15], " {2,}", " ").Trim(),
                                               };
            listPremacItem = query.ToList();
            listPremacItem.Sort((a, b) => a.item_number.CompareTo(b.item_number));
        }

        public void Search(pts_premac649 inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listPremacItem = new List<pts_premac649>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT premac_id, item_number, item_name, supplier_cd, supplier_name, supplier_invoice, po_number, delivery_qty, delivery_date, oder_number, incharge";
            query += "FROM pts_premac649 WHERE 1=1 ";
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
            if (!string.IsNullOrEmpty(inItem.oder_number))
                query += "AND oder_number ='" + inItem.oder_number + "' ";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pts_premac649 outItem = new pts_premac649
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
                    oder_number = reader["oder_number"].ToString(),
                    incharge = reader["incharge"].ToString()
                };
                //Add item into list
                listPremacItem.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }
    }
}
