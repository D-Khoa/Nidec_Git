using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PC_QRCodeSystem.Model
{
    public class GetData
    {
        PSQL SQL = new PSQL();
        StringBuilder query = new StringBuilder();

        #region LOGIN
        /// <summary>
        /// Check login password and user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckLogin(string usercode, string password)
        {
            DataTable dt = new DataTable();
            List<string> list = new List<string>();
            EncryptDecrypt edcrypt = new EncryptDecrypt();
            query.Append("select a.user_name, a.is_online from m_mes_user a left join m_login_password b ");
            query.Append("on a.user_cd = b.user_cd where b.user_cd = '").Append(usercode).Append("' ");
            password = edcrypt.Encrypt(password);
            query.Append("and b.password ='").Append(password).Append("'");
            if (SQL.sqlExecuteReader(query.ToString(), ref dt))
            {
                //Check online status and notice
                if ((bool)dt.Rows[0]["is_online"])
                {
                    if (MessageBox.Show("The user is now online." + Environment.NewLine + "Are you want to re-login?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return false;
                }
                query.Clear();
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
                SQL.sqlExecuteNonQuery(query.ToString(), false);
                query.Clear();
                return true;
            }
            query.Clear();
            return false;
        }

        public void LogOut()
        {
            //Set user is offline
            query.Append("update m_mes_user set is_online ='FALSE' ");
            query.Append("where user_cd='").Append(UserData.usercode).Append("'");
            SQL.sqlExecuteNonQuery(query.ToString(), false);
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
            if (SQL.sqlExecuteNonQuery(query.ToString(), false))
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
        /// Add an unit item into database
        /// </summary>
        /// <param name="item_no"></param>
        /// <param name="item_name"></param>
        /// <param name="unit_qty"></param>
        /// <param name="unit_type"></param>
        /// <returns></returns>
        public bool AddUnitItem(string item_no, string item_name, string unit_qty, string unit_type)
        {
            bool check;
            query.Append("INSERT INTO m_pc_item(item_cd, item_name, unit_qty, unit_cd) ");
            query.Append("VALUES ('").Append(item_no).Append("','").Append(item_name).Append("','");
            query.Append(unit_qty).Append("','").Append(unit_type).Append("')");
            check = SQL.sqlExecuteNonQuery(query.ToString(), false);
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
            n = SQL.sqlExecuteNonQueryInt(query.ToString(), false);
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
            query.Append("WHERE item_no ='").Append(old_item_no).Append("'");
            check = SQL.sqlExecuteNonQuery(query.ToString(), false);
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
            check = SQL.sqlExecuteNonQuery(query.ToString(), false);
            query.Clear();
            return check;
        }

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
        #endregion

        /// <summary>
        /// Input stock item into database
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool InputStock(List<StockInItem> items)
        {
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
            if (SQL.sqlExecuteNonQueryInt(query.ToString(), false) > 0)
            {
                query.Clear();
                return true;
            }
            else
            {
                query.Clear();
                return false;
            }
        }
    }
}
