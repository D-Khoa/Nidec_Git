using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace PC_QRCodeSystem.Model
{
    /// <summary>
    /// LOG OF ITEM REQUEST IN PRODUCTION TRACEBILITY SYSTEM
    /// </summary>
    public class pts_request_log
    {
        #region FIELDS OF REQUEST
        public int request_id { get; set; }
        public string item_cd { get; set; }
        public string model_cd { get; set; }
        public string destination_cd { get; set; }
        public DateTime use_date { get; set; }
        public DateTime request_date { get; set; }
        public double request_qty { get; set; }
        public string request_usercd { get; set; }
        public bool m_confirm { get; set; }
        public bool gm_confirm { get; set; }
        public double available_qty { get; set; }
        public string approve_usercd { get; set; }
        public bool pc_m_cofirm { get; set; }
        public string comment { get; set; }
        public BindingList<pts_request_log> listRequestItem { get; set; }
        #endregion

        /// <summary>
        /// Search list request
        /// </summary>
        /// <param name="inItem">input search info</param>
        /// <param name="confirm1">check m_confirm</param>
        /// <param name="confirm2">check gm_confirm</param>
        /// <param name="approved">check pc_approved</param>
        public void Search(pts_request_log inItem, bool confirm1, bool confirm2, bool approved)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listRequestItem = new BindingList<pts_request_log>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT request_id, item_cd, model_cd, destination_cd, use_date, request_date, request_qty, request_usercd, ";
            query += "m_confirm, gm_confirm, available_qty, approve_usercd, pc_m_cofirm, comment FROM pts_request_log WHERE 1=1 ";
            if (!string.IsNullOrEmpty(inItem.item_cd))
                query += "and item_cd ='" + inItem.item_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.model_cd))
                query += "and model_cd ='" + inItem.model_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.destination_cd))
                query += "and destination_cd ='" + inItem.destination_cd + "' ";
            if (confirm1)
                query += "and m_confirm ='" + inItem.m_confirm + "' ";
            if (confirm2)
                query += "and gm_confirm ='" + inItem.gm_confirm + "' ";
            if (approved)
                query += "and pc_m_cofirm ='" + inItem.pc_m_cofirm + "' ";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pts_request_log outItem = new pts_request_log
                {
                    request_id = (int)reader["request_id"],
                    item_cd = reader["item_cd"].ToString(),
                    model_cd = reader["model_cd"].ToString(),
                    destination_cd = reader["destination_cd"].ToString(),
                    use_date = (DateTime)reader["use_date"],
                    request_date = (DateTime)reader["request_date"],
                    request_qty = (double)reader["request_qty"],
                    request_usercd = reader["request_usercd"].ToString(),
                    m_confirm = (bool)reader["m_confirm"],
                    gm_confirm = (bool)reader["gm_confirm"],
                    available_qty = (double)reader["available_qty"],
                    approve_usercd = reader["approve_usercd"].ToString(),
                    pc_m_cofirm = (bool)reader["pc_m_cofirm"],
                    comment = reader["comment"].ToString(),
                };
                //Add item into list
                listRequestItem.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }

        /// <summary>
        /// Add new request
        /// </summary>
        /// <param name="inItem">input request info</param>
        /// <returns></returns>
        public int Add(pts_request_log inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "INSERT INTO pts_request_log(item_cd, model_cd, destination_cd, use_date, request_date, request_qty, ";
            query += "request_usercd, m_comfirm, gm_confirm, available_qty, approve_usercd, pc_m_cofirm, comment) ";
            query += "VALUES('" + inItem.item_cd + "','" + inItem.model_cd + "','" + inItem.destination_cd + "','" + inItem.use_date;
            query += "','" + inItem.request_date + "','" + inItem.request_qty + "','" + inItem.request_usercd + "','" + inItem.m_confirm;
            query += "','" + inItem.gm_confirm + "','" + inItem.available_qty + "','" + inItem.approve_usercd + "','" + inItem.pc_m_cofirm;
            query += "','" + inItem.comment + "')";
            //Execute non query for insert database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            //Close SQL connection
            SQL.Close();
            return result;
        }

        /// <summary>
        /// Update when manager confirm
        /// </summary>
        /// <param name="inItem">only use m_confirm and comment</param>
        /// <returns></returns>
        public int MConfirm(pts_request_log inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "UPDATE pts_request_log SET m_comfirm ='" + inItem.m_confirm + "', comment ='" + inItem.comment;
            query += "' WHERE request_id ='" + inItem.request_id + "'";
            //Execute non query for insert database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            //Close SQL connection
            SQL.Close();
            return result;
        }

        /// <summary>
        /// Update when GM confirm
        /// </summary>
        /// <param name="inItem">only use gm_confirm and comment</param>
        /// <returns></returns>
        public int GMConfirm(pts_request_log inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "UPDATE pts_request_log SET gm_comfirm ='" + inItem.gm_confirm + "', comment ='" + inItem.comment;
            query += "' WHERE request_id ='" + inItem.request_id + "'";
            //Execute non query for insert database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            //Close SQL connection
            SQL.Close();
            return result;
        }

        /// <summary>
        /// Update when PC manager approved
        /// </summary>
        /// <param name="inItem">only use pc_m_confirm and comment</param>
        /// <returns></returns>
        public int PC_MConfirm(pts_request_log inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "UPDATE pts_request_log SET pc_m_cofirm ='" + inItem.pc_m_cofirm + "', comment ='" + inItem.comment;
            query += "' WHERE request_id ='" + inItem.request_id + "'";
            //Execute non query for insert database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            //Close SQL connection
            SQL.Close();
            return result;
        }

        /// <summary>
        /// Delete ON THIS REQUEST
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "DELETE FROM pts_request_log WHERE request_id ='" + request_id + "'";
            //Execute non query for insert database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            //Close SQL connection
            SQL.Close();
            return result;
        }
    }
}
