﻿using System;
using System.Collections.Generic;
using System.Data;

namespace PC_QRCodeSystem.Model
{
    public class pts_stockout_log
    {
        #region ALL FIELDS
        public int stockout_id { get; set; }
        public int process_id { get; set; }
        public int stock_id { get; set; }
        public int issue_cd { get; set; }
        public DateTime stockout_date { get; set; }
        public string stockout_user_cd { get; set; }
        public double stockout_qty { get; set; }
        public double real_qty { get; set; }
        public string received_user_cd { get; set; }
        public string comment { get; set; }
        public string remark { get; set; }
        List<pts_stockout_log> listStockOutItem { get; set; }
        #endregion

        public pts_stockout_log()
        {
            listStockOutItem = new List<pts_stockout_log>();
        }

        /// <summary>
        /// Search list stock out item
        /// </summary>
        /// <param name="inItem">process_id, stock_id, issue_cd = 0 if search without this parameter</param>
        public void Search(pts_stockout_log inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT stockout_id, process_id, stock_id, issue_cd, stockout_date, stockout_user_cd, stockout_qty, real_qty, ";
            query += "received_user_cd, comment, remark FROM pts_stockout_log WHERE 1=1 ";
            if (inItem.process_id > 0)
                query += "AND process_id ='" + inItem.process_id + "' ";
            if (inItem.stock_id > 0)
                query += "AND stock_id ='" + inItem.stock_id + "' ";
            if (inItem.issue_cd > 0)
                query += "AND issue_cd ='" + inItem.issue_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.stockout_user_cd))
                query += "AND stockout_user_cd ='" + inItem.stockout_user_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.received_user_cd))
                query += "AND received_user_cd ='" + inItem.received_user_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.remark))
                query += "AND remark ='" + inItem.remark + "' ";
            query += "ORDER BY stockout_id";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            //Clear query
            query = string.Empty;
            //Read data into list
            while (reader.Read())
            {
                pts_stockout_log outItem = new pts_stockout_log
                {
                    stockout_id = (int)reader["stockout_id"],
                    process_id = (int)reader["process_id"],
                    stock_id = (int)reader["stock_id"],
                    issue_cd = (int)reader["issue_cd"],
                    stockout_date = (DateTime)reader["stockout_date"],
                    stockout_user_cd = reader["stockout_user_cd"].ToString(),
                    stockout_qty = (double)reader["stockout_qty"],
                    real_qty = (double)reader["real_qty"],
                    received_user_cd = reader["received_user_cd"].ToString(),
                    comment = reader["comment"].ToString(),
                    remark = reader["remark"].ToString(),
                };
                listStockOutItem.Add(outItem);
            }
            //Close reader and connection
            reader.Close();
            SQL.Close();
        }

        /// <summary>
        /// Search list stock out item with date
        /// </summary>
        /// <param name="fromDate">From stock out date</param>
        /// <param name="toDate">To stock out date</param>
        public void Search(DateTime fromDate, DateTime toDate)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT stockout_id, process_id, stock_id, issue_cd, stockout_date, stockout_user_cd, stockout_qty, real_qty, ";
            query += "received_user_cd, comment, remark FROM pts_stockout_log WHERE 1=1 ";
            query += "AND stockout_date >='" + fromDate.ToString("yyyy-MM-dd") + "' ";
            query += "AND stockout_date <='" + toDate.ToString("yyyy-MM-dd") + "' ";
            query += "ORDER BY stockout_id";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            //Clear query
            query = string.Empty;
            //Read data into list
            while (reader.Read())
            {
                pts_stockout_log outItem = new pts_stockout_log
                {
                    stockout_id = (int)reader["stockout_id"],
                    process_id = (int)reader["process_id"],
                    stock_id = (int)reader["stock_id"],
                    issue_cd = (int)reader["issue_cd"],
                    stockout_date = (DateTime)reader["stockout_date"],
                    stockout_user_cd = reader["stockout_user_cd"].ToString(),
                    stockout_qty = (double)reader["stockout_qty"],
                    real_qty = (double)reader["real_qty"],
                    received_user_cd = reader["received_user_cd"].ToString(),
                    comment = reader["comment"].ToString(),
                    remark = reader["remark"].ToString(),
                };
                listStockOutItem.Add(outItem);
            }
            //Close reader and connection
            reader.Close();
            SQL.Close();
        }

        /// <summary>
        /// Add an stock out log
        /// </summary>
        /// <param name="inItem">Input item</param>
        /// <returns>Number of item is added</returns>
        public int AddItem(pts_stockout_log inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "INSERT INTO pts_stockout_log(process_id, stock_id, issue_cd, stockout_date, stockout_user_cd, ";
            query += "stockout_qty, real_qty, received_user_cd, comment, remark) VALUES ";
            query += "('" + inItem.process_id + "','" + inItem.stock_id + "','" + inItem.issue_cd + "','" + inItem.stockout_date + "','";
            query += inItem.stockout_user_cd + "','" + inItem.stockout_qty + "','" + inItem.real_qty + "','" + inItem.received_user_cd;
            query += "','" + inItem.comment + "','" + inItem.remark + "')";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="inItem">Input item</param>
        /// <returns>Number item is deleted</returns>
        public int DeleteItem(pts_stockout_log inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "DELETE FROM pts_stockout_log WHERE stockout_id ='" + inItem.stockout_id + "'";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }
    }
}
