using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Npgsql;
using PostgreSQLCopyHelper;

namespace ConvertPremacFile.Model
{
    public class pts_premac649
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
                                                   delivery_qty = !string.IsNullOrEmpty(Regex.Replace(columns[10], " {2,}", " ").Trim()) ? double.Parse(Regex.Replace(columns[10], " {2,}", " ").Trim()) : 0,
                                                   incharge = Regex.Replace(columns[15], " {2,}", " ").Trim(),
                                               };
            listPremacItem = query.ToList();
            listPremacItem.Sort((a, b) => a.item_number.CompareTo(b.item_number));
        }

        public void WriteToDB(IEnumerable<pts_premac649> listPremacitem)
        {
            PostgreSQLCopyHelper<pts_premac649> coppyHelper = new PostgreSQLCopyHelper<pts_premac649>("pts_premac649")
                                                              .MapVarchar("item_number", x => x.item_number)
                                                              .MapVarchar("item_name", x => x.item_name)
                                                              .MapVarchar("supplier_cd", x => x.supplier_cd)
                                                              .MapText("supplier_name", x => x.supplier_name)
                                                              .MapVarchar("supplier_invoice", x => x.supplier_invoice)
                                                              .MapVarchar("po_number", x => x.po_number)
                                                              .MapDouble("delivery_qty", x => x.delivery_qty)
                                                              .MapDate("delivery_date", x => x.delivery_date)
                                                              .MapVarchar("oder_number", x => x.oder_number)
                                                              .MapVarchar("incharge", x => x.incharge);
            using (NpgsqlConnection connection = new NpgsqlConnection(Properties.Settings.Default.CONNECTSTRING_MES))
            {
                connection.Open();
                coppyHelper.SaveAll(connection, listPremacitem);
                connection.Close();
            }
        }
    }
}
