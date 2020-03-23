using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewModelCheckingResult.Model
{
    public class tbl_part_box
    {
        #region FIELDS
        public int part_box_id { get; set; }
        public string part_box_cd { get; set; }
        public string part_number { get; set; }
        public string part_name { get; set; }
        public string model_cd { get; set; }
        public string invoice { get; set; }
        public double part_box_qty { get; set; }
        public string part_box_lot { get; set; }
        public DateTime part_box_date { get; set; }
        public string vender_cd { get; set; }
        public string purpose_cmt { get; set; }
        public string incharge { get; set; }
        public List<tbl_part_box> listBox { get; set; }
        public tbl_part_box()
        {
            listBox = new List<tbl_part_box>();
        }
        #endregion

        /// <summary>
        /// Saearch item in table part box
        /// </summary>
        /// <param name="inItem">input info</param>
        /// <param name="checkDate">true: if check date</param>
        /// <returns>number of item</returns>
        public int Search(tbl_part_box inItem, bool checkDate)
        {
            listBox.Clear();
            PSQL SQL = new PSQL();
            string query = string.Empty;
            query = "SELECT part_box_id, part_box_cd, part_number, part_name, model_cd, invoice, part_box_qty, part_box_lot, part_box_date, ";
            query += "vender_cd, purpose_cmt FROM tbl_part_box WHERE 1=1 ";
            if (!string.IsNullOrEmpty(inItem.part_box_cd))
                query += "AND part_box_cd ='" + inItem.part_box_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.part_number))
                query += "AND part_number ='" + inItem.part_number + "' ";
            if (!string.IsNullOrEmpty(inItem.part_name))
                query += "AND part_name ='" + inItem.part_name + "' ";
            if (!string.IsNullOrEmpty(inItem.model_cd))
                query += "AND model_cd ='" + inItem.model_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.invoice))
                query += "AND invoice ='" + inItem.invoice + "' ";
            if (!string.IsNullOrEmpty(inItem.vender_cd))
                query += "AND vender_cd ='" + inItem.vender_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.purpose_cmt))
                query += "AND purpose_cmt ='" + inItem.purpose_cmt + "' ";
            if (checkDate)
                query += "AND part_box_date ='" + inItem.part_box_date + "' ";
            query += "ORDER BY part_box_cd, part_box_date";
            SQL.Open();
            IDataReader reader = SQL.Command(query).ExecuteReader();
            while (reader.Read())
            {
                tbl_part_box outItem = new tbl_part_box()
                {
                    part_box_id = (int)reader["part_box_id"],
                    part_box_cd = reader["part_box_cd"].ToString(),
                    part_number = reader["part_number"].ToString(),
                    part_name = reader["part_name"].ToString(),
                    model_cd = reader["model_cd"].ToString(),
                    invoice = reader["invoice"].ToString(),
                    part_box_qty = (double)reader["part_box_qty"],
                    part_box_lot = reader["part_box_lot"].ToString(),
                    part_box_date = (DateTime)reader["part_box_date"],
                    vender_cd = reader["vender_cd"].ToString(),
                    purpose_cmt = reader["purpose_cmt"].ToString(),
                    incharge = reader["incharge"].ToString()
                };
                listBox.Add(outItem);
            }
            SQL.Close();
            return listBox.Count;
        }

        public int Add(tbl_part_box inItem)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            SQL.Open();
            query = "INSERT INTO tbl_part_box(part_box_cd, part_number, part_name, model_cd, invoice, part_box_qty, part_box_lot, ";
            query += "part_box_date, vender_cd, purpose_cmt, incharge) ";
            query += "VALUES ('" + inItem.part_box_cd + "','" + inItem.part_number + "','" + inItem.part_name + "','" + inItem.model_cd + "','";
            query += inItem.invoice + "','" + inItem.part_box_qty + "','" + inItem.part_box_lot + "','" + inItem.part_box_date + "','" + inItem.vender_cd;
            query += "','" + inItem.purpose_cmt + "','" + inItem.incharge + "') ";
            int result = SQL.Command(query).ExecuteNonQuery();
            SQL.Close();
            return result;
        }

        public int UpdateInchargeQty(string boxid, string name, int qty)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            SQL.Open();
            query = "UPDATE tbl_part_box SET incharge='" + name + "', part_box_qty ='" + qty + "' WHERE part_box_cd ='" + boxid + "'";
            int result = SQL.Command(query).ExecuteNonQuery();
            SQL.Close();
            return result;
        }

        public int Delete(int boxid)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            SQL.Open();
            query = "DELETE FROM tbl_part_box WHERE part_box_id ='" + boxid + "' ";
            int result = SQL.Command(query).ExecuteNonQuery();
            SQL.Close();
            return result;
        }
    }
}
