using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PC_QRCodeSystem.Model
{
    /// <summary>
    /// SUPPLIER IN PRODUCTION TRACEBILITY SYSTEM
    /// </summary>
    public class pts_supplier
    {
        #region FIELDS OF SUPPLIER
        public int supplier_id { get; set; }
        public string supplier_cd { get; set; }
        public string supplier_name { get; set; }
        public string registration_user_cd { get; set; }
        public DateTime registration_date_time { get; set; }
        public List<pts_supplier> listSupplier { get; set; }
        StringBuilder query = new StringBuilder();
        #endregion

        /// <summary>
        /// Get supplier name with supplier code
        /// </summary>
        /// <param name="supplier_code">Supplier code</param>
        /// <returns></returns>
        public string GetSupplierName(string supplier_code)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "select supplier_name from pts_supplier where supplier_cd ='" + supplier_code + "'";
            //Execute reader for read database
            string result = SQL.Command(query).ExecuteScalar().ToString();
            query = string.Empty;
            //Close SQL connection
            SQL.Close();
            return result;
        }

        /// <summary>
        /// Get list supplier from database with supplier code
        /// </summary>
        /// <param name="supplier_code">string.empty if get all supplier in database</param>
        public void GetListSupplier(string supplier_code)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listSupplier = new List<pts_supplier>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "select * from pts_supplier where 1=1 ";
            if (!string.IsNullOrEmpty(supplier_code))
                query += "and supplier_cd = '" + supplier_code + "' ";
            query += "order by supplier_cd";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                //Get an item
                pts_supplier outItem = new pts_supplier
                {
                    supplier_id = (int)reader["supplier_id"],
                    supplier_cd = reader["supplier_cd"].ToString(),
                    supplier_name = reader["supplier_name"].ToString(),
                    registration_date_time = (DateTime)reader["registration_date_time"],
                    registration_user_cd = reader["registration_user_cd"].ToString()
                };
                //Add item into list
                listSupplier.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }

        public int AddSupplier(pts_supplier addptssupplier)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "INSERT INTO pts_supplier(supplier_cd, supplier_name, registration_user_cd)";
            query += "VALUES ('" + addptssupplier.supplier_cd + "','" + addptssupplier.supplier_name + "','";
            query += addptssupplier.registration_user_cd + "')";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            return result;
        }

        public int UpdateSuplier(pts_supplier UpSupplier)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "UPDATE pts_supplier SET supplier_cd='" + UpSupplier.supplier_cd + "', supplier_name='" + UpSupplier.supplier_name + "',registration_user_cd ='" + UpSupplier.registration_user_cd;
            query += "', registration_date_time = now() where supplier_cd ='" + UpSupplier.supplier_cd + "'";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            return result;
        }

        public int Delete(int id)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "DELETE FROM pts_supplier WHERE supplier_id ='" + id + "'";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            return result;

        }
    }
}
