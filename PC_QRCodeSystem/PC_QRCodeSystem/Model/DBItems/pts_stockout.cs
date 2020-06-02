using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;

namespace PC_QRCodeSystem.Model
{
    /// <summary>
    ///STOCK ITEM IN PRODUCTION TRACEBILITY SYSTEM
    /// </summary>
    public class pts_stockout
    {
        #region ALL FIELDS
        public int stockout_id { get; set; }
        public string packing_cd { get; set; }
        public string item_cd { get; set; }
        public string item_name { get; set; }
        public string supplier_name { get; set; }
        public string invoice { get; set; }
        public DateTime stockout_date { get; set; }
        public double stockout_qty { get; set; }
        public string remark { get; set; }
        public string registration_user_cd { get; set; }
        public DateTime registration_date_time { get; set; }
        public BindingList<pts_stockout> listStockItems { get; set; }
        public pts_stockout()
        {
            listStockItems = new BindingList<pts_stockout>();
        }
        #endregion

        #region QUERY
        /// <summary>
        /// Get an stock item
        /// </summary>
        /// <param name="inItem">input info stock item search</param>
        /// <param name="checkDate">check stock in date</param>
        /// <returns></returns>
        public pts_stockout GetItem(pts_stockout inItem, bool checkDate)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT stockout_id, packing_cd, item_cd, item_name, supplier_name, invoice, stockout_date, ";
            query += "stockout_qty, remark, registration_user_cd, registration_date_time FROM pts_stockout WHERE 1=1 ";
            if (!string.IsNullOrEmpty(inItem.packing_cd))
                query += "AND packing_cd ='" + inItem.packing_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.item_cd))
                query += "AND item_cd ='" + inItem.item_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.item_name))
                query += "AND item_name ='" + inItem.item_name + "' ";
            if (!string.IsNullOrEmpty(inItem.supplier_name))
                query += "AND supplier_name ='" + inItem.supplier_name + "' ";
            if (!string.IsNullOrEmpty(inItem.invoice))
                query += "AND invoice ='" + inItem.invoice + "' ";
            if (checkDate)
            {
                query += "AND stockout_date = '" + inItem.stockout_date.ToString("yyyy-MM-dd") + "' ";
            }
            query += "ORDER BY stock_id";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            reader.Read();
            pts_stockout outItem = new pts_stockout
            {
                stockout_id = (int)reader["stockout_id"],
                packing_cd = reader["packing_cd"].ToString(),
                item_cd = reader["item_cd"].ToString(),
                item_name = reader["item_name"].ToString(),
                supplier_name = reader["supplier_name"].ToString(),
                invoice = reader["invoice"].ToString(),
                stockout_date = (DateTime)reader["stockout_date"],
                stockout_qty = (double)reader["stockout_qty"],
                remark = invoice = reader["remark"].ToString(),
                registration_user_cd = reader["registration_user_cd"].ToString(),
                registration_date_time = (DateTime)reader["registration_date_time"],
            };
            reader.Close();
            query = string.Empty;
            //Close connection
            SQL.Close();
            return outItem;
        }

        /// <summary>
        /// Search list stock
        /// </summary>
        /// <param name="inItem">input info stock search</param>
        /// <returns></returns>
        public bool SearchItem(pts_stockout inItem)
        {
            try
            {
                //SQL library
                PSQL SQL = new PSQL();
                string query = string.Empty;
                listStockItems = new BindingList<pts_stockout>();
                //Open SQL connection
                SQL.Open();
                //SQL query string
                query = "SELECT stockout_id, packing_cd, item_cd, item_name, supplier_name, invoice, stockout_date, ";
                query += "stockout_qty, remark, registration_user_cd, registration_date_time FROM pts_stockout WHERE 1=1 ";
                if (!string.IsNullOrEmpty(inItem.packing_cd))
                    query += "AND packing_cd ='" + inItem.packing_cd + "' ";
                if (!string.IsNullOrEmpty(inItem.item_cd))
                    query += "AND item_cd ='" + inItem.item_cd + "' ";
                if (!string.IsNullOrEmpty(inItem.item_name))
                    query += "AND item_name ='" + inItem.item_name + "' ";
                if (!string.IsNullOrEmpty(inItem.supplier_name))
                    query += "AND supplier_name ='" + inItem.supplier_name + "' ";
                if (!string.IsNullOrEmpty(inItem.invoice))
                    query += "AND invoice ='" + inItem.invoice + "' ";
                query += "ORDER BY item_cd, packing_cd";
                //Execute reader for read database
                IDataReader reader = SQL.Command(query).ExecuteReader();
                while (reader.Read())
                {
                    pts_stockout outItem = new pts_stockout
                    {
                        stockout_id = (int)reader["stockout_id"],
                        packing_cd = reader["packing_cd"].ToString(),
                        item_cd = reader["item_cd"].ToString(),
                        item_name = reader["item_name"].ToString(),
                        supplier_name = reader["supplier_name"].ToString(),
                        invoice = reader["invoice"].ToString(),
                        stockout_date = (DateTime)reader["stockout_date"],
                        stockout_qty = (double)reader["stockout_qty"],
                        remark = invoice = reader["remark"].ToString(),
                        registration_user_cd = reader["registration_user_cd"].ToString(),
                        registration_date_time = (DateTime)reader["registration_date_time"],
                    };
                    listStockItems.Add(outItem);
                }
                reader.Close();
                query = string.Empty;
                //Close connection
                SQL.Close();
                if (listStockItems.Count > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SearchItem(pts_stockout inItem, bool searchQty)
        {
            try
            {
                //SQL library
                PSQL SQL = new PSQL();
                string query = string.Empty;
                listStockItems = new BindingList<pts_stockout>();
                //Open SQL connection
                SQL.Open();
                //SQL query string
                query = "SELECT stockout_id, packing_cd, item_cd, item_name, supplier_name, invoice, stockout_date, ";
                query += "stockout_qty, remark, registration_user_cd, registration_date_time FROM pts_stockout WHERE 1=1 ";
                if (!string.IsNullOrEmpty(inItem.packing_cd))
                    query += "AND packing_cd ='" + inItem.packing_cd + "' ";
                if (!string.IsNullOrEmpty(inItem.item_cd))
                    query += "AND item_cd ='" + inItem.item_cd + "' ";
                if (!string.IsNullOrEmpty(inItem.item_name))
                    query += "AND item_name ='" + inItem.item_name + "' ";
                if (!string.IsNullOrEmpty(inItem.supplier_name))
                    query += "AND supplier_name ='" + inItem.supplier_name + "' ";
                if (!string.IsNullOrEmpty(inItem.invoice))
                    query += "AND invoice ='" + inItem.invoice + "' ";
                query += "ORDER BY item_cd, packing_cd";
                //Execute reader for read database
                IDataReader reader = SQL.Command(query).ExecuteReader();
                while (reader.Read())
                {
                    pts_stockout outItem = new pts_stockout
                    {
                        stockout_id = (int)reader["stockout_id"],
                        packing_cd = reader["packing_cd"].ToString(),
                        item_cd = reader["item_cd"].ToString(),
                        item_name = reader["item_name"].ToString(),
                        supplier_name = reader["supplier_name"].ToString(),
                        invoice = reader["invoice"].ToString(),
                        stockout_date = (DateTime)reader["stockout_date"],
                        stockout_qty = (double)reader["stockout_qty"],
                        remark = invoice = reader["remark"].ToString(),
                        registration_user_cd = reader["registration_user_cd"].ToString(),
                        registration_date_time = (DateTime)reader["registration_date_time"],
                    };
                    listStockItems.Add(outItem);
                }
                reader.Close();
                query = string.Empty;
                //Close connection
                SQL.Close();
                if (listStockItems.Count > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Search list stock
        /// </summary>
        /// <param name="inItem">input info stock search</param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="checkDate">check stock in date</param>
        public bool SearchItem(pts_stockout inItem, DateTime fromDate, DateTime toDate, bool checkDate)
        {
            try
            {
                //SQL library
                PSQL SQL = new PSQL();
                string query = string.Empty;
                listStockItems = new BindingList<pts_stockout>();
                //Open SQL connection
                SQL.Open();
                //SQL query string
                query = "SELECT stockout_id, packing_cd, item_cd, item_name, supplier_name, invoice, stockout_date, ";
                query += "stockout_qty, remark, registration_user_cd, registration_date_time FROM pts_stockout WHERE 1=1 ";
                if (!string.IsNullOrEmpty(inItem.packing_cd))
                    query += "AND packing_cd ='" + inItem.packing_cd + "' ";
                if (!string.IsNullOrEmpty(inItem.item_cd))
                    query += "AND item_cd ='" + inItem.item_cd + "' ";
                if (!string.IsNullOrEmpty(inItem.item_name))
                    query += "AND item_name ='" + inItem.item_name + "' ";
                if (!string.IsNullOrEmpty(inItem.supplier_name))
                    query += "AND supplier_name ='" + inItem.supplier_name + "' ";
                if (!string.IsNullOrEmpty(inItem.invoice))
                    query += "AND invoice ='" + inItem.invoice + "' ";
                if (checkDate)
                {
                    query += "AND stockout_date >= '" + fromDate.ToString("yyyy-MM-dd") + "' ";
                    query += "AND stockout_date <= '" + toDate.ToString("yyyy-MM-dd") + "' ";
                }
                query += "ORDER BY item_cd, packing_cd";
                //Execute reader for read database
                IDataReader reader = SQL.Command(query).ExecuteReader();
                while (reader.Read())
                {
                    pts_stockout outItem = new pts_stockout
                    {
                        stockout_id = (int)reader["stockout_id"],
                        packing_cd = reader["packing_cd"].ToString(),
                        item_cd = reader["item_cd"].ToString(),
                        item_name = reader["item_name"].ToString(),
                        supplier_name = reader["supplier_name"].ToString(),
                        invoice = reader["invoice"].ToString(),
                        stockout_date = (DateTime)reader["stockout_date"],
                        stockout_qty = (double)reader["stockout_qty"],
                        remark = invoice = reader["remark"].ToString(),
                        registration_user_cd = reader["registration_user_cd"].ToString(),
                        registration_date_time = (DateTime)reader["registration_date_time"],
                    };
                    listStockItems.Add(outItem);
                }
                reader.Close();
                query = string.Empty;
                //Close connection
                SQL.Close();
                if (listStockItems.Count > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add new stock item
        /// </summary>
        /// <param name="inItem">input stock item</param>
        /// <returns></returns>
        public int AddItem(pts_stockout inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "INSERT INTO pts_stockout(packing_cd, item_cd, item_name, supplier_name, invoice, stockout_date,";
            query += "stockout_qty, remark, registration_user_cd) VALUES ";
            query += "('" + inItem.packing_cd + "','" + inItem.item_cd + "','" + inItem.item_name + "','" + inItem.supplier_name;
            query += "','" + inItem.invoice + "','" + inItem.stockout_date + "','";
            query += inItem.stockout_qty + "','" + inItem.remark + "','";
            query += inItem.registration_user_cd + "')";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }

        public int AddMultiItem(List<pts_stockout> listItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "INSERT INTO pts_stockout(packing_cd, item_cd, item_name, supplier_name, invoice, stockout_date,";
            query += "stockout_qty, remark, registration_user_cd) VALUES ";
            foreach (pts_stockout inItem in listItem)
            {
                query += "('" + inItem.packing_cd + "','" + inItem.item_cd + "','" + inItem.item_name + "','" + inItem.supplier_name;
                query += "','" + inItem.invoice + "','" + inItem.stockout_date + "','";
                query += inItem.stockout_qty + "','" + inItem.remark + "','";
                query += inItem.registration_user_cd + "'),";
            }
            query = query.Remove(query.Length - 1);

            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }

        /// <summary>
        /// Update stock item
        /// </summary>
        /// <param name="inItem">stock item after change</param>
        /// <returns></returns>
        public int UpdateItem(pts_stockout inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "UPDATE pts_stockout SET packing_cd ='" + inItem.packing_cd + "', item_cd ='" + inItem.item_cd + "', item_name ='";
            query += inItem.item_name + "', supplier_name ='" + inItem.supplier_name + "', invoice ='" + inItem.invoice;
            query += "', stockout_date ='" + inItem.stockout_date + "', stockout_qty ='" + inItem.stockout_qty;
            query += "', remark ='" + inItem.remark + "', registration_user_cd ='";
            query += inItem.registration_user_cd + "' WHERE stockout_id ='" + inItem.stockout_id + "'";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }

        public int UpdateMultiItem(List<pts_stockout> inList)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            int result = 0;
            //SQL query string
            foreach (pts_stockout inItem in inList)
            {
                query = "UPDATE pts_stockout SET packing_cd ='" + inItem.packing_cd + "', item_cd ='" + inItem.item_cd + "', item_name ='";
                query += inItem.item_name + "', supplier_name ='" + inItem.supplier_name + "', invoice ='" + inItem.invoice;
                query += "', stockout_date ='" + inItem.stockout_date + "', stockout_qty ='" + inItem.stockout_qty;
                query += "', remark ='" + inItem.remark + "', registration_user_cd ='";
                query += inItem.registration_user_cd + "' WHERE stockout_id ='" + inItem.stockout_id + "'";
                //Execute non query for read database
                result += SQL.Command(query).ExecuteNonQuery();
                query = string.Empty;
            }
            SQL.Close();
            return result;
        }
        /// <summary>
        /// Delete current stock item
        /// </summary>
        /// <returns></returns>
        public int DeleteItem()
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "DELETE FROM pts_stockout WHERE stockout_id ='" + stockout_id + "'";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }
        #endregion

        #region IN/OUT
        /// <summary>
        /// Export list stock item into CSV file
        /// </summary>
        /// <param name="inList">input list item</param>
        /// <param name="fileName">file path</param>
        public void ExportToCSV(List<pts_stockout> inList, string fileName)
        {
            var properties = inList[0].GetType().GetProperties();
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                string line = string.Empty;
                //Write columns
                line = string.Join("?", properties.Select(x => x.Name));
                sw.WriteLine(line);
                for (int i = 0; i < inList.Count; i++)
                {
                    var propretiesValue = inList[i].GetType().GetProperties();
                    line = string.Join("?", propretiesValue.Select(x => x.GetValue(inList[i], null)));
                    sw.WriteLine(line);
                }
                sw.Flush();
                sw.Close();
            }
        }
        #endregion
    }
}
