using System.Collections.Generic;
using System.Data;

namespace PC_QRCodeSystem.Model
{
    public class pre_user
    {
        #region FIELDS
        public string user_cd { get; set; }
        public string user_name { get; set; }
        public List<pre_user> listUser { get; set; }
        public pre_user()
        {
            listUser = new List<pre_user>();
        }
        #endregion

        public pre_user GetUser(string user_code)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT user_cd, user_name FROM pre_user WHERE 1=1";
            if (!string.IsNullOrEmpty(user_code))
                query += "AND user_cd ='" + user_code + "'";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            reader.Read();
            //Get an item
            pre_user outItem = new pre_user
            {
                user_cd = reader["user_cd"].ToString(),
                user_name = reader["user_name"].ToString(),
            };
            reader.Close();
            //Close SQL connection
            SQL.Close();
            return outItem;
        }

        public void GetAllUser()
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listUser = new List<pre_user>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT user_cd, user_name FROM pre_user";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pre_user outItem = new pre_user
                {
                    user_cd = reader["user_cd"].ToString(),
                    user_name = reader["user_name"].ToString(),
                };
                listUser.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }
    }
}
