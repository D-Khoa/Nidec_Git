using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Npgsql;
using PostgreSQLCopyHelper;

namespace ConvertPremacFile.Model
{
    public class pre_user
    {
        public string user_cd { get; set; }
        public string user_name { get; set; }
        public List<pre_user> listUser { get; set; }
        public pre_user()
        {
            listUser = new List<pre_user>();
        }

        public void GetListItems(string premacitem)
        {
            string[] csvlines = File.ReadAllLines(premacitem);
            IEnumerable<pre_user> query = from csvline in csvlines
                                          where (!csvline.Contains("Security Level"))
                                          let columns = csvline.Replace("\"", "").Split('?')
                                          select new pre_user
                                          {
                                              user_cd = Regex.Replace(columns[1], " {2,}", " ").Trim(),
                                              user_name = Regex.Replace(columns[2], " {2,}", " ").Trim(),
                                          };
            listUser = query.ToList();
            listUser.Sort((a, b) => a.user_cd.CompareTo(b.user_cd));
        }

        public void WriteToDB(IEnumerable<pre_user> listPremacitem)
        {
            PostgreSQLCopyHelper<pre_user> coppyHelper = new PostgreSQLCopyHelper<pre_user>("pre_user")
                                                              .MapVarchar("user_cd", x => x.user_cd)
                                                              .MapText("user_name", x => x.user_name);
            using (NpgsqlConnection connection = new NpgsqlConnection(Properties.Settings.Default.CONNECTSTRING_MES))
            {
                connection.Open();
                coppyHelper.SaveAll(connection, listPremacitem);
                connection.Close();
            }
        }

        public int DeleteFromDB()
        {
            int result;
            NpgsqlCommand command;
            using (NpgsqlConnection connection = new NpgsqlConnection(Properties.Settings.Default.CONNECTSTRING_MES))
            {
                connection.Open();
                command = new NpgsqlCommand("DELETE FROM pre_user", connection);
                result = command.ExecuteNonQuery();
                connection.Close();
            }
            return result;
        }
    }
}
