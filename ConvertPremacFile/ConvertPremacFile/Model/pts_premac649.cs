using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Npgsql;
using PostgreSQLCopyHelper;

namespace ConvertPremacFile.Model
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
        public void GetListPremacItem(string premacfile)
        {
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
                                                   delivery_qty = !string.IsNullOrEmpty(Regex.Replace(columns[10], " {2,}", " ").Trim()) ? double.Parse(Regex.Replace(columns[10], " {2,}", " ").Trim()) : 0,
                                                   incharge = Regex.Replace(columns[14], " {2,}", " ").Trim(),
                                               };
            listPremacItem = query.ToList();
            listPremacItem.Sort((a, b) => a.item_number.CompareTo(b.item_number));
        }

        /// <summary>
        /// Coppy all data to pre_649
        /// </summary>
        /// <param name="listPremacitem">list item</param>
        public void WriteToDB(IEnumerable<pre_649> listPremacitem)
        {
            PostgreSQLCopyHelper<pre_649> coppyHelper = new PostgreSQLCopyHelper<pre_649>("pre_649")
                                                              .MapVarchar("item_number", x => x.item_number)
                                                              .MapText("item_name", x => x.item_name)
                                                              .MapVarchar("supplier_cd", x => x.supplier_cd)
                                                              .MapText("supplier_name", x => x.supplier_name)
                                                              .MapVarchar("supplier_invoice", x => x.supplier_invoice)
                                                              .MapVarchar("po_number", x => x.po_number)
                                                              .MapDouble("delivery_qty", x => x.delivery_qty)
                                                              .MapDate("delivery_date", x => x.delivery_date)
                                                              .MapVarchar("order_number", x => x.order_number)
                                                              .MapVarchar("incharge", x => x.incharge);
            using (NpgsqlConnection connection = new NpgsqlConnection(Properties.Settings.Default.CONNECTSTRING_MES))
            {
                connection.Open();
                coppyHelper.SaveAll(connection, listPremacitem);
                connection.Close();
            }
        }

        /// <summary>
        /// Delete all data of pre_649
        /// </summary>
        /// <returns></returns>
        public int DeleteFromDB()
        {
            int result;
            NpgsqlCommand command;
            using (NpgsqlConnection connection = new NpgsqlConnection(Properties.Settings.Default.CONNECTSTRING_MES))
            {
                connection.Open();
                command = new NpgsqlCommand("DELETE FROM pre_649", connection);
                result = command.ExecuteNonQuery();
                connection.Close();
            }
            return result;
        }
    }
}
