using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    public class GetData
    {
        PSQL SQL = new PSQL();
        StringBuilder query = new StringBuilder();

        public List<string> GetListUser()
        {
            List<string> list = new List<string>();
            query.Append("select distinct user_name from m_user order by user_name");
            SQL.getListString(query.ToString(), ref list);
            query.Clear();
            return list;
        }

        public bool CheckLogin(string username, string password)
        {
            DataTable dt = new DataTable();
            List<string> list = new List<string>();
            query.Append("select * from m_user where user_name = '").Append(username).Append("' ");
            query.Append("and user_pass ='").Append(password).Append("'");
            if (SQL.sqlExecuteReader(query.ToString(), ref dt))
            {
                query.Clear();
                UserData.username = username;
                UserData.dept = dt.Rows[0]["user_dept_cd"].ToString();
                UserData.rolename = dt.Rows[0]["user_role_cd"].ToString();
                UserData.logintime = DateTime.Now;
                query.Append("select permision_id from m_user_role where role_cd='").Append(UserData.rolename).Append("'");
                SQL.getListString(query.ToString(), ref list);
                UserData.role_permision = list;
                query.Clear();
                return true;
            }
            query.Clear();
            return false;
        }
    }
}
