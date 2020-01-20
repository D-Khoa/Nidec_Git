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
        public string request_user_cd { get; set; }
        public bool m_confirm { get; set; }
        public bool gm_confirm { get; set; }
        public double available_qty { get; set; }
        public string approve_user_cd { get; set; }
        public bool pc_m_cofirm { get; set; }
        public bool pc_pm_confirm { get; set; }
        public string comment { get; set; }
        public string registration_user_cd { get; set; }
        public DateTime registration_date_time { get; set; }
        public BindingList<pts_request_log> listRequestItem { get; set; }
        #endregion

        /// <summary>
        /// Get list request log from database
        /// </summary>
        /// <param name="inItem">item code, model code, destination code, request user code, approve user code</param>
        public void GetListRequestItem(pts_request_log inItem)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            listRequestItem = new BindingList<pts_request_log>();
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT request_id, item_cd, model_cd, destination_cd, use_date, request_date, request_qty, request_user_cd, ";
            query += "m_comfirm, gm_confirm, available_qty, approve_user_cd, pc_m_cofirm, pc_pm_confirm, comment, ";
            query += "registration_user_cd, registration_date FROM pts_request_log WHERE 1=1 ";
            if (string.IsNullOrEmpty(inItem.item_cd))
                query += "and item_cd = '" + inItem.item_cd + "' ";
            if (string.IsNullOrEmpty(inItem.model_cd))
                query += "and model_cd = '" + inItem.model_cd + "' ";
            if (string.IsNullOrEmpty(inItem.destination_cd))
                query += "and destination_cd = '" + inItem.destination_cd + "' ";
            if (string.IsNullOrEmpty(inItem.request_user_cd))
                query += "and request_user_cd = '" + inItem.request_user_cd + "' ";
            if (string.IsNullOrEmpty(inItem.approve_user_cd))
                query += "and approve_user_cd = '" + inItem.approve_user_cd + "' ";
            query += "order by request_id";
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
                    request_user_cd = reader["request_user_cd"].ToString(),
                    m_confirm = (bool)reader["m_confirm"],
                    gm_confirm = (bool)reader["gm_confirm"],
                    available_qty = (double)reader["available_qty"],
                    approve_user_cd = reader["approve_user_cd"].ToString(),
                    pc_m_cofirm = (bool)reader["pc_m_cofirm"],
                    pc_pm_confirm = (bool)reader["pc_pm_confirm"],
                    comment = reader["comment"].ToString(),
                    registration_user_cd = UserData.usercode,
                    registration_date_time = (DateTime)reader["log_reg_date"]
                };
                //Add item into list
                listRequestItem.Add(outItem);
            }
            reader.Close();
            //Close SQL connection
            SQL.Close();
        }
    }
}
