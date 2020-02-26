﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                              type_id =int.Parse( columns[2].Trim()),
                                              item_cd = columns[0].Trim(),
                                              item_name = columns[3].Trim(),
                                              item_location = columns[40].Trim(),
                                              item_unit = columns[14].Trim(),
                                              lot_size = double.Parse(columns[17].Trim()),
                                              wh_qty = double.Parse(columns[35].Trim()),
                                              wip_qty = double.Parse(columns[36].Trim()),
                                              repair_qty= double.Parse(columns[37].Trim()),                               
                                          };
            listItems = query.ToList();
            listItems.Sort((a, b) => a.type_id.CompareTo(b.type_id));
        }
        public int AddItem(pts_item inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "INSERT INTO pts_item(type_id, item_cd, item_name, item_location, item_unit, lot_size, wh_qty, wip_qty, repair_qty, registration_user_cd) ";
            query += "VALUES ('" + inItem.type_id + "','" + inItem.item_cd + "','" + inItem.item_name + "','";
            query += inItem.item_location + "','" + inItem.item_unit + "','" + inItem.lot_size + "','"+inItem.wh_qty+ "', '" + inItem.wip_qty + "','" +inItem.repair_qty + "','";
            query += inItem.registration_user_cd + "')";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            return result;
        }
    }

}