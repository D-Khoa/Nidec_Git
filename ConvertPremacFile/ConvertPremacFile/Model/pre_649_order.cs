using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Npgsql;
using PostgreSQLCopyHelper;

namespace ConvertPremacFile.Model
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
        /// Coppy all data to pre_649
        /// </summary>
        /// <param name="listPremacitem">list item</param>
        public void WriteToDB(IEnumerable<pre_649_order> listPremacitem)
        {
            PostgreSQLCopyHelper<pre_649_order> coppyHelper = new PostgreSQLCopyHelper<pre_649_order>("pre_649_order")
                                                              .MapVarchar("item_number", x => x.item_number)
                                                              .MapVarchar("order_number", x => x.order_number)
                                                              .MapDouble("order_qty", x => x.order_qty)
                                                              .MapVarchar("supplier_cd", x => x.supplier_cd)
                                                              .MapDate("order_date", x => x.order_date);
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
                command = new NpgsqlCommand("DELETE FROM pre_649_order", connection);
                result = command.ExecuteNonQuery();
                connection.Close();
            }
            return result;
        }
    }
}