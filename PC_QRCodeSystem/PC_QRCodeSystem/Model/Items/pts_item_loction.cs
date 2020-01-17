using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    /// <summary>
    /// ITEM LOCATION IN PRODUCTION TRACEBILITY SYSTEM
    /// </summary>
    public class pts_item_loction
    {
        #region FIELDS OF ITEM LOCATION
        public string item_location_no { get; set; }
        public string item_location_name { get; set; }
        public string registration_user_cd { get; set; }
        public DateTime registration_date_time { get; set; }
        public List<pts_item_loction> listItemLocation { get; set; }
        #endregion

        public void GetListItemLocation(string location_cd)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listItemLocation = new List<pts_item_loction>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "select * from pts_item_loction where 1=1 ";
            if (string.IsNullOrEmpty(location_cd))
                query += "and item_location_no = '" + location_cd + "' ";
            query += "order by item_location_no";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pts_item_loction outItem = new pts_item_loction
                {
                    item_location_no = reader["item_location_no"].ToString(),
                    item_location_name = reader["item_location_name"].ToString(),
                    registration_date_time = (DateTime)reader["registration_date_time"],
                    registration_user_cd = reader["registration_user_cd"].ToString()
                };
                //Add item into list
                listItemLocation.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }
    }
}
