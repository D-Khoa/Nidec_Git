using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewModelCheckingResult.Model
{
    public class tbl_inspect_master
    {
        public int inspect_id { get; set; }
        public string inspect_cd { get; set; }
        public string inspec_name { get; set; }
        public string part_number { get; set; }
        public string inspect_tool { get; set; }
        public double inspect_spec { get; set; }
        public double tol_plus { get; set; }
        public double tol_minus { get; set; }
        public List<tbl_inspect_master> listMaster { get; set; }
        public tbl_inspect_master()
        {
            listMaster = new List<tbl_inspect_master>();
        }

        public int Search(tbl_inspect_master inItem)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            query = "SELECT inspect_id, inspect_cd, inspec_name, part_number, inspect_tool, inspect_spec, tol_plus, tol_minus FROM tbl_inspect_master WHERE 1=1 ";
            if (inItem.inspect_id > 0)
                query += "AND inspect_id='" + inItem.inspect_id + "' ";
            if (!string.IsNullOrEmpty(inItem.inspect_cd))
                query += "AND inspect_cd='" + inItem.inspect_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.part_number))
                query += "AND part_number='" + inItem.part_number + "' ";
            if (!string.IsNullOrEmpty(inItem.inspect_tool))
                query += "AND inspect_tool='" + inItem.inspect_tool + "' ";
            query += "ORDER BY part_number, inspect_cd";
            SQL.Open();
            IDataReader reader = SQL.Command(query).ExecuteReader();
            while (reader.Read())
            {
                tbl_inspect_master outItem = new tbl_inspect_master
                {
                    inspect_id = (int)reader["inspect_id"],
                    inspect_cd = reader["inspect_cd"].ToString(),
                    inspec_name = reader["inspec_name"].ToString(),
                    part_number = reader["part_number"].ToString(),
                    inspect_tool = reader["inspect_tool"].ToString(),
                    inspect_spec = (double)reader["inspect_spec"],
                    tol_plus = (double)reader["tol_plus"],
                    tol_minus = (double)reader["tol_minus"],
                };
                listMaster.Add(outItem);
            }
            SQL.Close();
            return listMaster.Count;
        }

        public List<string> GetTools()
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            List<string> list = new List<string>();
            query = "SELECT distinct inspect_tool FROM tbl_inspect_master";
            SQL.Open();
            IDataReader reader = SQL.Command(query).ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader["inspect_tool"].ToString());
            }
            SQL.Close();
            return list;
        }

        public int Add(tbl_inspect_master inItem)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            SQL.Open();
            query = "INSERT INTO tbl_inspect_master(inspect_cd, inspec_name, part_number, inspect_tool, inspect_spec, tol_plus, tol_minus) ";
            query += "VALUES ('" + inItem.inspect_cd + "','" + inItem.inspec_name + "','" + inItem.part_number + "','" + inItem.inspect_tool + "','";
            query += inItem.inspect_spec + "','" + inItem.tol_plus + "','" + inItem.tol_minus + "') ";
            int result = SQL.Command(query).ExecuteNonQuery();
            SQL.Close();
            return result;
        }

        public int Delete(int itemID)
        {
            PSQL SQL = new PSQL();
            string query = string.Empty;
            SQL.Open();
            query = "DELETE FROM tbl_inspect_master WHERE inspect_id ='" + itemID + "' ";
            int result = SQL.Command(query).ExecuteNonQuery();
            SQL.Close();
            return result;
        }
    }
}
