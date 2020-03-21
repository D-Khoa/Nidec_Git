using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewModelCheckingResult.Model
{
    /// <summary>
    /// tbl_inspect_data object
    /// </summary>
    public class tbl_inspect_data
    {
        #region FIELDS
        public string part_box_cd { get; set; }
        public string item_no { get; set; }
        public int inspect_id { get; set; }
        public string inspect_data { get; set; }
        public string judge { get; set; }
        public DateTime inspect_date { get; set; }
        public List<tbl_inspect_data> listData { get; set; }
        public tbl_inspect_data()
        {
            listData = new List<tbl_inspect_data>();
        }
        #endregion

        #region TABLE DATABASE
        /// <summary>
        /// Create new month table if it not exist
        /// </summary>
        /// <param name="inDate">input date</param>
        /// <returns>true: if table created</returns>
        public bool CreateMonthTable(DateTime inDate)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            string tbl = "tbl_inspect_data" + inDate.ToString("yyyyMM");
            if (CheckTblExist(tbl)) return true;
            else
            {
                query = "CREATE TABLE " + tbl;
                query += @"(part_box_cd character varying(50) NOT NULL,
                            item_no integer NOT NULL DEFAULT 0,
                            inspect_id integer NOT NULL,
                            inspect_data double precision NOT NULL DEFAULT 0::double precision,
                            judge character varying(1) NOT NULL,
                            inspect_date timestamp without time zone NOT NULL DEFAULT now(),
                            CONSTRAINT tbl_inspect_data202003_pk PRIMARY KEY(part_box_cd, item_no, inspect_id, inspect_date));";
                SQL.Open();
                int result = SQL.Command(query).ExecuteNonQuery();
                SQL.Close();
                if (result > 0) return true;
                else return false;
            }
        }

        /// <summary>
        /// Check table
        /// </summary>
        /// <param name="tblName">table name</param>
        /// <returns>true: if table is exist</returns>
        public bool CheckTblExist(string tblName)
        {
            try
            {
                PSQL SQL = new PSQL();
                string query = string.Empty;
                query = "SELECT 1 FROM " + tblName;
                SQL.Open();
                SQL.Command(query).ExecuteScalar();
                SQL.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public int Search(string boxCD, DateTime indate)
        {
            listData.Clear();
            PSQL SQL = new PSQL();
            string query = string.Empty;
            string tablename = "tbl_inspect_data" + indate.ToString("yyyyMM");
            if (!CheckTblExist(tablename)) return 0;
            query = "SELECT part_box_cd, item_no, inspect_id, inspect_data, judge, inspect_date FROM " + tablename + " WHERE 1=1 ";
            query += "AND part_box_cd ='" + boxCD + "' ORDER BY part_box_cd, inspect_date";
            SQL.Open();
            IDataReader reader = SQL.Command(query).ExecuteReader();
            while (reader.Read())
            {
                tbl_inspect_data outItem = new tbl_inspect_data
                {
                    part_box_cd = reader["part_box_cd"].ToString(),
                    item_no = reader["item_no"].ToString(),
                    inspect_id = (int)reader["inspect_id"],
                    inspect_data = reader["inspect_data"].ToString(),
                    judge = reader["judge"].ToString(),
                    inspect_date = (DateTime)reader["inspect_date"],
                };
                listData.Add(outItem);
            }
            SQL.Close();
            return listData.Count;
        }
    }
}
