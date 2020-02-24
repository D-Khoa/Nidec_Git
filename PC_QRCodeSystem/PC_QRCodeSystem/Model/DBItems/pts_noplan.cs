using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    public class pts_noplan
    {
        #region ALL FIELDS
        public int noplan_id { get; set; }
        public string noplan_cd { get; set; }
        public string destination_cd { get; set; }
        public string item_cd { get; set; }
        public double noplan_qty { get; set; }
        public string noplan_usercd { get; set; }
        public DateTime noplan_date { get; set; }
        public BindingList<pts_noplan> listNoPlan;
        public pts_noplan()
        {
            listNoPlan = new BindingList<pts_noplan>();
        }
        #endregion

        #region QUERY
        public int AddItem(pts_noplan inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "INSERT INTO pts_noplan(noplan_cd, destination_cd, item_cd, noplan_qty, noplan_usercd, noplan_date) VALUES ";
            query += "('" + inItem.noplan_cd + "','" + inItem.destination_cd + "','" + inItem.item_cd + "','";
            query += inItem.noplan_qty + "','" + inItem.noplan_usercd + "','" + inItem.noplan_date + "')";
            //Execute non query SQL
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }

        public int AddMultiItem(List<pts_noplan> inList)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "INSERT INTO pts_noplan(noplan_cd, destination_cd, item_cd, noplan_qty, noplan_usercd, noplan_date) VALUES ";
            foreach (pts_noplan inItem in inList)
            {
                query += "('" + inItem.noplan_cd + "','" + inItem.destination_cd + "','" + inItem.item_cd + "','";
                query += inItem.noplan_qty + "','" + inItem.noplan_usercd + "','" + inItem.noplan_date + "'),";
            }
            query = query.Remove(query.Length - 1);
            //Execute non query SQL
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }
        #endregion

    }
}
