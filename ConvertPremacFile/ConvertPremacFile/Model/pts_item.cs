using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Npgsql;
using PostgreSQLCopyHelper;

namespace ConvertPremacFile.Model
{
    public class pts_item
    {
        public int item_id { get; set; }
        public int type_id { get; set; }
        public string item_cd { get; set; }
        public string item_name { get; set; }
        public string item_location { get; set; }
        public string item_unit { get; set; }
        public double lot_size { get; set; }
        public double wh_qty { get; set; }
        public double wip_qty { get; set; }
        public double repair_qty { get; set; }
        public string registration_user_cd { get; set; }
        public DateTime registration_date_time { get; set; }
        public List<pts_item> listItems;
        public pts_item()
        {
            listItems = new List<pts_item>();
        }
        public void GetListItems(string premacitem)
        {
            string[] csvlines = File.ReadAllLines(premacitem);
            IEnumerable<pts_item> query = from csvline in csvlines
                                          where (!csvline.Contains("(CPBE0012)") && !csvline.Contains("Item Number"))
                                          let columns = csvline.Split('?')
                                          select new pts_item
                                          {
                                              type_id = int.Parse(Regex.Replace(columns[2], " {2,}", " ").Trim()),
                                              item_cd = Regex.Replace(columns[0], " {2,}", " ").Trim(),
                                              item_name = Regex.Replace(columns[1], " {2,}", " ").Trim(),
                                              item_location = Regex.Replace(columns[40], " {2,}", " ").Trim(),
                                              item_unit = Regex.Replace(columns[14], " {2,}", " ").Trim(),
                                              lot_size = double.Parse(Regex.Replace(columns[17], " {2,}", " ").Trim()),
                                              wh_qty = double.Parse(Regex.Replace(columns[35], " {2,}", " ").Trim()),
                                              wip_qty = double.Parse(Regex.Replace(columns[36], " {2,}", " ").Trim()),
                                              repair_qty = double.Parse(Regex.Replace(columns[37], " {2,}", " ").Trim()),
                                              registration_user_cd = "admin"
                                          };
            listItems = query.ToList();
            listItems.Sort((a, b) => a.type_id.CompareTo(b.type_id));
        }
        public void WriteToDB(IEnumerable<pts_item> listPremacitem)
        {
            PostgreSQLCopyHelper<pts_item> coppyHelper = new PostgreSQLCopyHelper<pts_item>("pts_item")
                                                              .MapInteger("type_id", x => x.type_id)
                                                              .MapVarchar("item_cd", x => x.item_cd)
                                                              .MapText("item_name", x => x.item_name)
                                                              .MapVarchar("item_location", x => x.item_location)
                                                              .MapVarchar("item_unit", x => x.item_unit)
                                                              .MapDouble("lot_size", x => x.lot_size)
                                                              .MapDouble("wh_qty", x => x.wh_qty)
                                                              .MapDouble("wip_qty", x => x.wip_qty)
                                                              .MapDouble("repair_qty", x => x.repair_qty)
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
                command = new NpgsqlCommand("DELETE FROM pts_item", connection);
                result = command.ExecuteNonQuery();
                connection.Close();
            }
            return result;
        }
    }

}
