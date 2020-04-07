using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Npgsql;
using PostgreSQLCopyHelper;

namespace ConvertPremacFile.Model
{
    class pre_655
    {
        #region ALL FIELDS
        public string low_level_item { get; set; }
        public string high_level_item { get; set; }
        public string order_number { get; set; }
        public double request_qty { get; set; }
        public double no_issue_qty { get; set; }
        public List<pre_655> list655;
        public pre_655()
        {
            list655 = new List<pre_655>();
        }
        #endregion

        /// <summary>
        /// Get list PREMAC 6-5-5 from txt file
        /// </summary>
        /// <param name="premacfile">path of PREMAC file</param>
        /// <returns></returns>
        public void GetListPremacItem(string premacfile)
        {
            string low_temp = string.Empty;
            string high_temp = string.Empty;
            string[] csvlines = File.ReadAllLines(premacfile);
            //IEnumerable<pre_655> query = from csvline in csvlines
            //                             where (!csvline.Contains("< T O T A L >") && !string.IsNullOrEmpty(csvline) && !csvline.Contains("Low-Level Item"))
            //                             let columns = csvline.Split('?')
            //                             where (!string.IsNullOrEmpty(Regex.Replace(columns[5], " {2,}", " ").Trim().Replace("\"", "")))
            //                             select new pre_655
            //                             {
            //                                 low_level_item = Regex.Replace(columns[0], " {2,}", " ").Trim().Replace("\"", ""),
            //                                 high_level_item = Regex.Replace(columns[2], " {2,}", " ").Trim().Replace("\"", ""),
            //                                 order_number = Regex.Replace(columns[4], " {2,}", " ").Trim().Replace("\"", ""),
            //                                 request_qty = !string.IsNullOrEmpty(Regex.Replace(columns[6], " {2,}", " ").Trim().Replace("\"", "")) ?
            //                                 double.Parse(Regex.Replace(columns[6], " {2,}", " ").Trim().Replace("\"", "")) : 0,
            //                                 no_issue_qty = !string.IsNullOrEmpty(Regex.Replace(columns[7], " {2,}", " ").Trim().Replace("\"", "")) ?
            //                                 double.Parse(Regex.Replace(columns[7], " {2,}", " ").Trim().Replace("\"", "")) : 0,
            //                             };
            csvlines.ToList().ForEach(x =>
            {
                if (!x.Contains("< T O T A L >") && !string.IsNullOrEmpty(x) && !x.Contains("Low-Level Item"))
                {
                    var columns = x.Split('?');
                    if (!string.IsNullOrEmpty(Regex.Replace(columns[5], " {2,}", " ").Trim().Replace("\"", "")))
                    {
                        low_temp = !string.IsNullOrEmpty(Regex.Replace(columns[0], " {2,}", " ").Trim().Replace("\"", "")) ?
                                   Regex.Replace(columns[0], " {2,}", " ").Trim().Replace("\"", "") : low_temp;
                        high_temp = !string.IsNullOrEmpty(Regex.Replace(columns[2], " {2,}", " ").Trim().Replace("\"", "")) ?
                                   Regex.Replace(columns[2], " {2,}", " ").Trim().Replace("\"", "") : high_temp;
                        list655.Add(new pre_655
                        {
                            low_level_item = low_temp,
                            high_level_item = high_temp,
                            order_number = Regex.Replace(columns[4], " {2,}", " ").Trim().Replace("\"", ""),
                            request_qty = !string.IsNullOrEmpty(Regex.Replace(columns[6], " {2,}", " ").Trim().Replace("\"", "")) ?
                                             double.Parse(Regex.Replace(columns[6], " {2,}", " ").Trim().Replace("\"", "")) : 0,
                            no_issue_qty = !string.IsNullOrEmpty(Regex.Replace(columns[7], " {2,}", " ").Trim().Replace("\"", "")) ?
                                             double.Parse(Regex.Replace(columns[7], " {2,}", " ").Trim().Replace("\"", "")) : 0,
                        });
                    }
                }
            });
            //list655 = query.ToList();
            list655.Sort((a, b) => a.low_level_item.CompareTo(b.low_level_item));
        }

        /// <summary>
        /// Coppy all data to pre_655
        /// </summary>
        /// <param name="listPremacitem">list item</param>
        public void WriteToDB(IEnumerable<pre_655> listPremacitem)
        {
            PostgreSQLCopyHelper<pre_655> coppyHelper = new PostgreSQLCopyHelper<pre_655>("pre_655")
                                                              .MapVarchar("low_level_item", x => x.low_level_item)
                                                              .MapVarchar("high_level_item", x => x.high_level_item)
                                                              .MapVarchar("order_number", x => x.order_number)
                                                              .MapDouble("request_qty", x => x.request_qty)
                                                              .MapDouble("no_issue_qty", x => x.no_issue_qty);
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
                command = new NpgsqlCommand("DELETE FROM pre_655", connection);
                result = command.ExecuteNonQuery();
                connection.Close();
            }
            return result;
        }
    }
}
