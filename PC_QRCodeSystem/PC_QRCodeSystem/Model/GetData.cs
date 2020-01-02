using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PC_QRCodeSystem.Model
{
    public class GetData
    {
        PSQL SQL = new PSQL();
        StringBuilder query = new StringBuilder();

        #region LOGIN & LOGOUT
        /// <summary>
        /// Get data user into a table
        /// </summary>
        /// <param name="usercode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataTable GetDataUserTable(string usercode, string password)
        {
            DataTable dt = new DataTable();
            EncryptDecrypt edcrypt = new EncryptDecrypt();
            query.Append("select a.user_name, a.is_online from m_mes_user a left join m_login_password b ");
            query.Append("on a.user_cd = b.user_cd where b.user_cd = '").Append(usercode).Append("' ");
            password = edcrypt.Encrypt(password);
            query.Append("and b.password ='").Append(password).Append("'");
            SQL.sqlExecuteReader(query.ToString(), ref dt);
            query.Clear();
            if (dt.Rows.Count == 0)
                throw new Exception("Wrong usercode or password! Please try again!");
            return dt;
        }

        /// <summary>
        /// Check login password and user old
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //public bool CheckLogin(string usercode, string password)
        //{
        //    DataTable dt = new DataTable();
        //    List<string> list = new List<string>();
        //    EncryptDecrypt edcrypt = new EncryptDecrypt();
        //    query.Append("select a.user_name, a.is_online from m_mes_user a left join m_login_password b ");
        //    query.Append("on a.user_cd = b.user_cd where b.user_cd = '").Append(usercode).Append("' ");
        //    password = edcrypt.Encrypt(password);
        //    query.Append("and b.password ='").Append(password).Append("'");
        //    if (SQL.sqlExecuteReader(query.ToString(), ref dt))
        //    {
        //        //Check online status and notice
        //        if ((bool)dt.Rows[0]["is_online"])
        //        {
        //            if (MessageBox.Show("The user is now online." + Environment.NewLine + "Are you want to re-login?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
        //                return false;
        //        }
        //        query.Clear();
        //        //Get name of user
        //        UserData.usercode = usercode;
        //        UserData.username = dt.Rows[0]["user_name"].ToString();
        //        //Get list role_cd of user
        //        query.Append("select role_cd from m_mes_user_role where user_cd='").Append(usercode).Append("'");
        //        SQL.getListString(query.ToString(), ref list);
        //        UserData.role_permision = list;
        //        query.Clear();
        //        //Get department of user
        //        query.Append("select dept_cd from m_user_location where user_location_cd like '%");
        //        query.Append(usercode).Append("%'");
        //        UserData.dept = SQL.sqlExecuteScalarString(query.ToString());
        //        query.Clear();
        //        //Get login time of user
        //        UserData.logintime = DateTime.Now;
        //        //Save login time and check user is online
        //        query.Append("update m_mes_user set last_login_time='").Append(DateTime.Now);
        //        query.Append("', is_online ='TRUE' ");
        //        query.Append("where user_cd='").Append(usercode).Append("'");
        //        SQL.sqlExecuteNonQuery(query.ToString());
        //        query.Clear();
        //        return true;
        //    }
        //    query.Clear();
        //    return false;
        //}

        /// <summary>
        /// Check online status of user
        /// </summary>
        /// <param name="usercode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckLogin(string usercode, string password)
        {
            return (bool)GetDataUserTable(usercode, password).Rows[0]["is_online"];
        }

        /// <summary>
        /// Login and get data of user
        /// </summary>
        /// <param name="usercode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string usercode, string password)
        {
            List<string> list = new List<string>();
            //Get data of user
            DataTable dt = GetDataUserTable(usercode, password);
            //Get name of user
            UserData.usercode = usercode;
            UserData.username = dt.Rows[0]["user_name"].ToString();
            //Get list role_cd of user
            query.Append("select role_cd from m_mes_user_role where user_cd='").Append(usercode).Append("'");
            SQL.getListString(query.ToString(), ref list);
            UserData.role_permision = list;
            query.Clear();
            //Get department of user
            query.Append("select dept_cd from m_user_location where user_location_cd like '%");
            query.Append(usercode).Append("%'");
            UserData.dept = SQL.sqlExecuteScalarString(query.ToString());
            query.Clear();
            //Get login time of user
            UserData.logintime = DateTime.Now;
            //Save login time and check user is online
            query.Append("update m_mes_user set last_login_time='").Append(DateTime.Now);
            query.Append("', is_online ='TRUE' ");
            query.Append("where user_cd='").Append(usercode).Append("'");
            SQL.sqlExecuteNonQuery(query.ToString());
            query.Clear();
            return true;
        }

        /// <summary>
        /// Logout and update online status of user
        /// </summary>
        public void LogOut()
        {
            //Set user is offline
            query.Append("update m_mes_user set is_online ='FALSE' ");
            query.Append("where user_cd='").Append(UserData.usercode).Append("'");
            SQL.sqlExecuteNonQuery(query.ToString());
            query.Clear();
        }

        /// <summary>
        /// Change password for user
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Bolean</returns>
        public bool ChangePassword(string password)
        {
            EncryptDecrypt edcrypt = new EncryptDecrypt();
            password = edcrypt.Encrypt(password);
            query.Append("update m_login_password set password='").Append(password);
            query.Append("' where user_cd ='").Append(UserData.usercode).Append("'");
            if (SQL.sqlExecuteNonQuery(query.ToString()))
            {
                query.Clear();
                return true;
            }
            query.Clear();
            return false;
        }
        #endregion

        #region UNIT MANAGER
        /// <summary>
        /// Get unit qty of each item
        /// </summary>
        /// <param name="item_cd"></param>
        /// <returns></returns>
        public double GetUnitQty(string item_cd)
        {
            double qty;
            query.Append("select unit_qty from m_pc_item where item_cd='").Append(item_cd).Append("'");
            qty = SQL.sqlExecuteScalarDouble(query.ToString());
            query.Clear();
            return qty;
        }

        /// <summary>
        /// Get all unit item into a list
        /// </summary>
        /// <param name="list_unit_item"></param>
        /// <returns></returns>
        public bool GetAllUnitItem(ref System.ComponentModel.BindingList<UnitItem> list_unit_item)
        {
            DataTable dt = new DataTable();
            query.Append("Select * from m_pc_item order by item_cd");
            SQL.sqlExecuteReader(query.ToString(), ref dt);
            query.Clear();
            if (dt.Rows.Count == 0)
                return false;
            foreach (DataRow dr in dt.Rows)
            {
                list_unit_item.Add(new UnitItem
                {
                    Item_Number = dr["item_cd"].ToString(),
                    Item_Name = dr["item_name"].ToString(),
                    Unit_Qty = (double)dr["unit_qty"],
                    Unit_Type = dr["unit_cd"].ToString()
                });
            }
            return true;
        }

        /// <summary>
        /// Add an unit item into database
        /// </summary>
        /// <param name="item_no"></param>
        /// <param name="item_name"></param>
        /// <param name="unit_qty"></param>
        /// <param name="unit_type"></param>
        /// <returns></returns>
        public bool AddUnitItem(UnitItem item)
        {
            bool check;
            query.Append("INSERT INTO m_pc_item(item_cd, item_name, unit_qty, unit_cd) ");
            query.Append("VALUES ('").Append(item.Item_Number).Append("','").Append(item.Item_Name).Append("','");
            query.Append(item.Unit_Qty.ToString()).Append("','").Append(item.Unit_Type).Append("')");
            check = SQL.sqlExecuteNonQuery(query.ToString());
            query.Clear();
            return check;
        }

        /// <summary>
        /// Add list unit item into database
        /// </summary>
        /// <param name="list_item"></param>
        /// <returns></returns>
        public int AddUnitItem(string list_item)
        {
            int n = 0;
            query.Append("INSERT INTO m_pc_item(item_cd, item_name, unit_qty, unit_cd) VALUES ").Append(list_item);
            n = SQL.sqlExecuteNonQueryInt(query.ToString());
            query.Clear();
            return n;
        }

        /// <summary>
        /// Update an unit item
        /// </summary>
        /// <param name="item_no"></param>
        /// <param name="item_name"></param>
        /// <param name="unit_qty"></param>
        /// <param name="unit_type"></param>
        /// <param name="old_item_no"></param>
        /// <returns></returns>
        public bool UpdateUnitItem(string item_no, string item_name, string unit_qty, string unit_type, string old_item_no)
        {
            bool check;
            query.Append("UPDATE m_pc_item SET ");
            if (!string.IsNullOrEmpty(item_no))
                query.Append("item_cd ='").Append(item_no).Append("', ");
            if (!string.IsNullOrEmpty(item_name))
                query.Append("item_name ='").Append(item_name).Append("', ");
            if (!string.IsNullOrEmpty(unit_qty))
                query.Append("unit_qty ='").Append(unit_qty).Append("', ");
            if (!string.IsNullOrEmpty(unit_type))
                query.Append("unit_cd ='").Append(unit_type).Append("' ");
            query.Append("WHERE item_cd ='").Append(old_item_no).Append("'");
            check = SQL.sqlExecuteNonQuery(query.ToString());
            query.Clear();
            return check;
        }

        /// <summary>
        /// Delete an unit item
        /// </summary>
        /// <param name="item_cd"></param>
        /// <returns></returns>
        public bool DeleteUnitItem(string item_cd)
        {
            bool check;
            query.Append("DELETE FROM m_pc_item WHERE item_cd ='").Append(item_cd).Append("'");
            check = SQL.sqlExecuteNonQuery(query.ToString());
            query.Clear();
            return check;
        }
        #endregion

        #region STOCKIN DATA INTO DATABASE
        /// <summary>
        /// Input stock list item into database
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int InputStock(List<StockInItem> items)
        {
            int n = 0;
            string cmd = string.Empty;
            foreach (StockInItem item in items)
            {
                cmd += "('" + item.Packing_Code + "','" + item.Item_Number + "','" + item.Supplier_Name + "','"
                    + item.PO_No + "','" + item.Supplier_Invoice + "','" + item.Delivery_Qty + "','" + item.StockIn_Date
                    + "','" + item.Stock_Qty + "','" + item.Incharge + "','" + item.Registrator_Date + "'),";
            }
            cmd = cmd.Remove(cmd.Length - 1, 1);
            query.Append("INSERT INTO t_pc_stock(packing_cd, item_cd, supplier, po_no, invoice, delivery_qty, ");
            query.Append("stock_in_date, stock_qty, user_name, registrator_date) VALUES ").Append(cmd);
            n = SQL.sqlExecuteNonQueryInt(query.ToString());
            query.Clear();
            return n;
        }

        /// <summary>
        /// Input binding list items into database
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int InputStock(System.ComponentModel.BindingList<StockInItem> items)
        {
            int n = 0;
            string cmd = string.Empty;
            foreach (StockInItem item in items)
            {
                cmd += "('" + item.Packing_Code + "','" + item.Item_Number + "','" + item.Supplier_Name + "','"
                    + item.PO_No + "','" + item.Supplier_Invoice + "','" + item.Delivery_Qty + "','" + item.StockIn_Date
                    + "','" + item.Stock_Qty + "','" + item.Incharge + "','" + item.Registrator_Date + "'),";
            }
            cmd = cmd.Remove(cmd.Length - 1, 1);
            query.Append("INSERT INTO t_pc_stock(packing_cd, item_cd, supplier, po_no, invoice, delivery_qty, ");
            query.Append("stock_in_date, stock_qty, user_name, registrator_date) VALUES ").Append(cmd);
            n = SQL.sqlExecuteNonQueryInt(query.ToString());
            query.Clear();
            return n;
        }
        #endregion
    }
}
