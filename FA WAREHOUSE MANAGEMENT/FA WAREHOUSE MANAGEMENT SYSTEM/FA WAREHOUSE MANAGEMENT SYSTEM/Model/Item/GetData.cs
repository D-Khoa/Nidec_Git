using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace FA_WAREHOUSE_MANAGEMENT_SYSTEM.View
{
    /// <summary>
    /// Class contain all SQL query of project
    /// </summary>
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
            query.Append("select a.user_name, b.is_online from m_mes_user a left join m_login_password b ");
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
            query.Append("update m_login_password set last_login_time='").Append(DateTime.Now);
            query.Append("', is_online ='1' ");
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
            query.Append("update m_login_password set is_online ='0' ");
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


    }
}
