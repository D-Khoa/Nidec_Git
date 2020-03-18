using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Npgsql;
using PostgreSQLCopyHelper;

namespace ConvertPremacFile.Model
{
    public class pre_232
    {
        public int supplier_id { get; set; }
        public string supplier_cd { get; set; }
        public string supplier_name { get; set; }
        public string supplier_tel { get; set; }
        public string supplier_fax { get; set; }
        public string supplier_address { get; set; }
        public string registration_user_cd { get; set; }
        public DateTime registration_date_time { get; set; }
        public List<pre_232> listSupplier { get; set; }
        StringBuilder query = new StringBuilder();
        public pre_232()
        {
            listSupplier = new List<pre_232>();
        }
        public void GetListItems(string premacitem)
        {
            string[] csvlines = File.ReadAllLines(premacitem);
            IEnumerable<pre_232> query = from csvline in csvlines
                                         where (!csvline.Contains("(CPBE0032)") && !csvline.Contains("Supplier"))
                                         let columns = csvline.Split('?')
                                         select new pre_232
                                         {
                                             // supplier_id = int.Parse(Regex.Replace(columns[1], " {2,}", " ").Trim()),
                                             supplier_cd = Regex.Replace(columns[0], " {2,}", " ").Trim(),
                                             supplier_name = Regex.Replace(columns[1], " {2,}", " ").Trim(),
                                             supplier_tel = Regex.Replace(columns[6], " {2,}", " ").Trim(),
                                             supplier_fax = Regex.Replace(columns[7], " {2,}", " ").Trim(),
                                             supplier_address = Regex.Replace(columns[2], " {2,}", " ").Trim(),
                                             registration_user_cd = "admin"
                                         };
            listSupplier = query.ToList();
            listSupplier.Sort((a, b) => a.supplier_id.CompareTo(b.supplier_id));
        }
        public void WriteToDB(IEnumerable<pre_232> listPremacitem)
        {
            PostgreSQLCopyHelper<pre_232> coppyHelper = new PostgreSQLCopyHelper<pre_232>("pts_supplier")
                                                              .MapVarchar("supplier_cd", x => x.supplier_cd)
                                                              .MapText("supplier_name", x => x.supplier_name)
                                                              .MapVarchar("supplier_tel", x => x.supplier_tel)
                                                              .MapVarchar("supplier_fax", x => x.supplier_fax)
                                                              .MapVarchar("supplier_address", x => x.supplier_address)
                                                              .MapVarchar("registration_user_cd", x => x.registration_user_cd);
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
                command = new NpgsqlCommand("DELETE FROM pts_supplier; SELECT setval('public.pts_supplier_supplier_id_seq', 1, true);", connection);
                result = command.ExecuteNonQuery();
                connection.Close();
            }
            return result;
        }
    }
}
