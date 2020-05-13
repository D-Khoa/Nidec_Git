using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCManagementSystem.Model
{
    public class m_asset
    {
        #region ALL FIELDS
        public int asset_id { get; set; }
        public string asset_cd { get; set; }
        public string asset_name { get; set; }
        public string asset_model { get; set; }
        public string asset_serial { get; set; }
        public string asset_supplier { get; set; }
        public string dept { get; set; }
        public string section { get; set; }
        public string line { get; set; }
        public string asset_invoice { get; set; }
        public string period { get; set; }
        public DateTime calibration_date { get; set; }
        public DateTime calibration_next_date { get; set; }
        public double price { get; set; }
        public string label_status { get; set; }
        public string registration_user_cd { get; set; }
        public DateTime registration_date_time { get; set; }
        public string inventory { get; set; }
        public BindingList<m_asset> listAsset { get; set; }
        public m_asset()
        {
            listAsset = new BindingList<m_asset>();
        }
        #endregion
        public m_asset GetAsset(int assetID)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            SQL.Open();
            query = "select * from m_asset where 1=1 ";
            query += "and asset_id = '" + assetID + "' ";
            query += "order by asset_id";
            //query = "SELECT asset_id, asset_cd, asset_name, asset_model, asset_serial, asset_supplier, dept, section, line, asset_invoice, period, calibration_date, calibration_next_date, price, label_status, inventory, registration_user_cd, registration_date_time";
            //query += " FROM m_asset where 1=1";
            //if (inAsset.asset_id > 0)
            //    query += "and asset_id = '" + inAsset.asset_id + "'";
            //if (!string.IsNullOrEmpty(inAsset.asset_cd))
            //    query += "and asset_cd = '" + inAsset.asset_cd + "'";
            //if (!string.IsNullOrEmpty(inAsset.asset_name))
            //    query += "and asset_name = '" + inAsset.asset_name + "'";
            IDataReader reader = SQL.Command(query).ExecuteReader();
            reader.Read();
            m_asset outAsset = new m_asset
            {
                asset_id = (int)reader["asset_id"],
                asset_cd = reader["asset_cd"].ToString(),
                asset_name = reader["asset_name"].ToString(),
                asset_model = reader["asset_model"].ToString(),
                asset_serial = reader["asset_serial"].ToString(),
                asset_supplier = reader["asset_supplier"].ToString(),
                dept = reader["dept"].ToString(),
                section = reader["section"].ToString(),
                line = reader["line"].ToString(),
                asset_invoice = reader["asset_invoice"].ToString(),
                period = reader["period"].ToString(),
                calibration_date = (DateTime)reader["calibration_date"],
                calibration_next_date = (DateTime)reader["calibration_next_date"],
                price = (double)reader["price"],
                label_status = reader["label_status"].ToString(),
                inventory = reader["inventory"].ToString(),
                registration_user_cd = reader["registration_user_cd"].ToString(),
                registration_date_time = (DateTime)reader["registration_date_time"]

            };
            reader.Close();
            query = string.Empty;
            SQL.Close();
            return outAsset;
        }
        private void GetListAsset()
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listAsset = new BindingList<m_asset>();
            SQL.Open();
            query = "SELECT asset_id, asset_cd, asset_name, asset_model, asset_serial, asset_supplier, dept, section, line, asset_invoice, period, calibration_date, calibration_next_date, price, label_status, inventory, registration_user_cd, registration_date_time where 1=1";
            query += "order by asset_id";
            //if (!string.IsNullOrEmpty(asset_code))
            //    query += "and asset_cd = '" + asset_code + "' ";
            //query += "order by asset_cd";
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            while (reader.Read())
            {
                m_asset outAsset = new m_asset
                {
                    asset_id = (int)reader["asset_id"],
                    asset_cd = reader["asset_cd"].ToString(),
                    asset_name = reader["asset_name"].ToString(),
                    asset_model = reader["asset_model"].ToString(),
                    asset_serial = reader["asset_serial"].ToString(),
                    asset_supplier = reader["asset_supplier"].ToString(),
                    dept = reader["dept"].ToString(),
                    section = reader["section"].ToString(),
                    line = reader["line"].ToString(),
                    asset_invoice = reader["asset_invoice"].ToString(),
                    period = reader["period"].ToString(),
                    calibration_date = (DateTime)reader["calibration_date"],
                    calibration_next_date = (DateTime)reader["calibration_next_date"],
                    price = (double)reader["price"],
                    label_status = reader["label_status"].ToString(),
                    inventory = reader["inventory"].ToString(),
                    registration_user_cd = reader["registration_user_cd"].ToString(),
                    registration_date_time = (DateTime)reader["registration_date_time"]
                };
                listAsset.Add(outAsset);
            }
            reader.Close();
            SQL.Close();
        }
        public int AddAsset(m_asset addmasset)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            SQL.Open();
            query = "INSERT INTO m_asset(asset_cd, asset_name, asset_model, asset_serial, asset_supplier, dept, section, line, asset_invoice, period, calibration_date, calibration_next_date, price, label_status, inventory, registration_user_cd)";
            query += " VALUES ('" + addmasset.asset_cd + "', '" + addmasset.asset_name + "','";
            query += addmasset.asset_model + "', '" + addmasset.asset_serial + "', '" + addmasset.asset_supplier + "', '" + addmasset.dept + "', '" + addmasset.section + "', '" + addmasset.line + "', '" + addmasset.asset_invoice + "', '" + addmasset.period + "', '" + addmasset.calibration_date + "', '" + addmasset.calibration_next_date + "', '" + addmasset.price + "', '" + addmasset.label_status + "','" + addmasset.inventory + "','";
            query += addmasset.registration_user_cd + "')";
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;

        }
        public int UpdateAsset(m_asset UpAsset)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            query = "UPDATE m_asset SET asset_cd = '" + UpAsset.asset_cd + "', asset_name = '" + UpAsset.asset_name;
            query += "', asset_model = '" + UpAsset.asset_model + "', asset_serial = '" + UpAsset.asset_serial + "', asset_supplier = '" + UpAsset.asset_supplier + "', dept = '" + UpAsset.dept + "', section = '" + UpAsset.section + "', line = '" + UpAsset.line + "', asset_invoice = '" + UpAsset.asset_invoice + "', asset_life = '" + UpAsset.period + "', calibration_date = '" + UpAsset.calibration_date + "', calibration_next_date = '" + UpAsset.calibration_next_date + "', price = '" + UpAsset.price + "', label_status = '" + UpAsset.label_status + "', inventory = '" + UpAsset.inventory + "', registration_user_cd = '" + UpAsset.registration_user_cd;
            query += "', registration_date_time = now() where asset_cd = '" + UpAsset.asset_cd + "'";
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }
        public int Delete()
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "DELETE FROM m_asset WHERE asset_id ='" + asset_id + "'";
            //Execute non query for read database
            int result = SQL.Command(query).ExecuteNonQuery();
            query = string.Empty;
            SQL.Close();
            return result;
        }
    }
}
