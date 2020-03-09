using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Npgsql;
using PostgreSQLCopyHelper;

namespace ConvertPremacFile.Model
{
    public class pre_223
    {
        public string high_level_item { get; set; }
        public string low_level_item { get; set; }
        public double numerator { get; set; }
        public List<pre_223> listStructItem { get; set; }
        public pre_223()
        {
            listStructItem = new List<pre_223>();
        }

        public List<pre_223> GetListItems(string inFile)
        {
            listStructItem = new List<pre_223>();
            string[] csvlines = File.ReadAllLines(inFile);
            IEnumerable<pre_223> query = from csvline in csvlines
                                         where (!string.IsNullOrEmpty(csvline) && !csvline.Contains("High item"))
                                         let columns = csvline.Split('?')
                                         select new pre_223
                                         {
                                             high_level_item = Regex.Replace(columns[1], " {2,}", " ").Trim(),
                                             low_level_item = Regex.Replace(columns[4], " {2,}", " ").Trim(),
                                             numerator = !string.IsNullOrEmpty(Regex.Replace(columns[10], " {2,}", " ").Trim()) ?
                                                          double.Parse(Regex.Replace(columns[10], " {2,}", " ").Trim()) : 0,
                                         };
            listStructItem = query.ToList();
            listStructItem.Sort((a, b) => a.high_level_item.CompareTo(b.high_level_item));
            return listStructItem;
        }

        public void WriteToDB(IEnumerable<pre_223> listPremacitem)
        {
            PostgreSQLCopyHelper<pre_223> coppyHelper = new PostgreSQLCopyHelper<pre_223>("pre_223")
                                                              .MapVarchar("high_level_item", x => x.high_level_item)
                                                              .MapVarchar("low_level_item", x => x.low_level_item)
                                                              .MapDouble("numerator", x => x.numerator);
            using (NpgsqlConnection connection = new NpgsqlConnection(Properties.Settings.Default.CONNECTSTRING_MES))
            {
                connection.Open();
                coppyHelper.SaveAll(connection, listPremacitem);
                connection.Close();
            }
        }

        public int DeleteFromDB()
        {
            int result;
            NpgsqlCommand command;
            using (NpgsqlConnection connection = new NpgsqlConnection(Properties.Settings.Default.CONNECTSTRING_MES))
            {
                connection.Open();
                command = new NpgsqlCommand("DELETE FROM pre_223", connection);
                result = command.ExecuteNonQuery();
                connection.Close();
            }
            return result;
        }
    }
}
