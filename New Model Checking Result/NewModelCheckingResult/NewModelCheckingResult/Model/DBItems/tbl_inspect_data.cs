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
        public int item_no { get; set; }
        public int inspect_id { get; set; }
        public double inspect_data { get; set; }
        public string judge { get; set; }
        public DateTime inspect_date { get; set; }
        public string incharge { get; set; }
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
                            incharge character varying(30) NOT NULL,
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

        public int Search(string boxCD)
        {
            listData.Clear();
            PSQL SQL = new PSQL();
            string query = string.Empty;
            string[] box = boxCD.Split('#');
            string month = box[2].Remove(6, 2);
            string tablename = "tbl_inspect_data" + month;
            if (!CheckTblExist(tablename)) return 0;
            query = "SELECT part_box_cd, item_no, inspect_id, inspect_data, judge, inspect_date, incharge FROM " + tablename + " WHERE 1=1 ";
            query += "AND part_box_cd ='" + boxCD + "' ORDER BY part_box_cd, inspect_date";
            SQL.Open();
            IDataReader reader = SQL.Command(query).ExecuteReader();
            while (reader.Read())
            {
                tbl_inspect_data outItem = new tbl_inspect_data
                {
                    part_box_cd = reader["part_box_cd"].ToString(),
                    item_no = (int)reader["item_no"],
                    inspect_id = (int)reader["inspect_id"],
                    inspect_data = (double)reader["inspect_data"],
                    judge = reader["judge"].ToString(),
                    inspect_date = (DateTime)reader["inspect_date"],
                    incharge = reader["incharge"].ToString(),
                };
                listData.Add(outItem);
            }
            SQL.Close();
            return listData.Count;
        }

        public int GetMax(string boxCD)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            string[] box = boxCD.Split('#');
            string month = box[2].Remove(6, 2);
            string tablename = "tbl_inspect_data" + month;
            if (!CheckTblExist(tablename)) return 0;
            query = "SELECT MAX(item_no) FROM " + tablename + " WHERE part_box_cd ='" + boxCD + "' ";
            SQL.Open();
            object result = SQL.Command(query).ExecuteScalar();
            SQL.Close();
            if (result != DBNull.Value) return (int)result;
            else return 0;
        }

        public int AddMultiData(List<tbl_inspect_data> inList)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            string[] box = inList[0].part_box_cd.Split('#');
            string month = box[2].Remove(6, 2);
            string tablename = "tbl_inspect_data" + month;
            if (!CheckTblExist(tablename)) return 0;
            query = "INSERT INTO " + tablename + "(part_box_cd, item_no, inspect_id, inspect_data, judge, inspect_date, incharge) VALUES";
            for (int i = 0; i < inList.Count; i++)
            {
                query += "('" + inList[i].part_box_cd + "','" + inList[i].item_no + "','" + inList[i].inspect_id + "','" + inList[i].inspect_data + "','";
                query += inList[i].judge + "','" + inList[i].inspect_date + "','" + inList[i].incharge + "')";
            }
            SQL.Open();
            int result = (int)SQL.Command(query).ExecuteNonQuery();
            SQL.Close();
            return result;
        }
    }
}
