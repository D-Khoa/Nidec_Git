using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateNewProcessNSTV.Model
{
    public class GetData
    {
        TfSQL SQL = new TfSQL();
        public static void GetModelCombobox(ref System.Windows.Forms.ComboBox cmb, string server)
        {
            cmb.DataSource = Directory.GetFiles(server);
            cmb.Text = null;
        }

        public static void GetProcessCSV(ref string[] process, ref string[] inspect, string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                process = sr.ReadLine().Split(',');
                inspect = sr.ReadLine().Split(',');
                sr.Close();
            }
        }

        public bool InsertProcessDB(string model, string site, string factory, string line, string process, string procname, string stopmark, DateTime systemdate)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.Append("INSERT INTO m_processtbl(model, site, factory, line, process, procname, stopmark, systemdate) VALUES('");
            cmd.Append(model).Append("','").Append(site).Append("','").Append(factory).Append("','").Append(line).Append("','").Append(process).Append("','").Append(procname).Append("','").Append(stopmark).Append("','").Append(systemdate.ToString("yyyy-MM-dd")).Append("')");
            return SQL.sqlExecuteNonQuery(cmd.ToString(), false);
        }

        public bool InsertInspectDB(string model, string site, string factory, string line, string process, string inspect, string inspectname, DateTime systemdate)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.Append("INSERT INTO m_procinsplink(model, site, factory, line, process, inspect, inspectname, systemdate)VALUES('");
            cmd.Append(model).Append("','").Append(site).Append("','").Append(factory).Append("','").Append(line).Append("','").Append(process).Append("','").Append(inspect).Append("','").Append(inspectname).Append("','").Append(systemdate.ToString("yyyy-MM-dd")).Append("')");
            return SQL.sqlExecuteNonQuery(cmd.ToString(), false);
        }

        public bool CreateTable(string table)
        {
            try
            {
                string cmd = @" CREATE TABLE " + table + @"(
                        serno character varying(50) NOT NULL,
                        lot character varying(50) NOT NULL,
                        model character varying(20) NOT NULL,
                        site character varying(6) NOT NULL,
                        factory character varying(4) NOT NULL,
                        line character varying(3) NOT NULL,
                        process character varying(10) NOT NULL,
                        inspectdate timestamp with time zone NOT NULL,
                        tjudge character(1),
                        tstatus character varying(16) NOT NULL,
                        remark character varying(16),
                        CONSTRAINT " + table + @"_pkey 
                        PRIMARY KEY (serno, lot, model, site, factory, line, process, inspectdate))
                        WITH ( OIDS=FALSE);
                        ALTER TABLE " + table + @" OWNER TO pqm;
                        CREATE INDEX " + table + @"_p02
                        ON " + table + @" USING btree(model, site, factory, line, process, inspectdate, serno, lot);
                        CREATE INDEX " + table + @"_p03
                        ON " + table + @" USING btree(inspectdate, model, site, factory, line, process, serno, lot);";
                return SQL.sqlExecuteNonQuery(cmd, false);
            }
            catch
            {
                return false;
            }
        }

        public bool CreateTableData(string table)
        {
            try
            {
                string cmd = @"CREATE TABLE " + table + @"data(
                          serno character varying(50) NOT NULL,
                          lot character varying(50) NOT NULL,
                          inspectdate timestamp with time zone NOT NULL,
                          inspect character varying(32) NOT NULL,
                          inspectdata double precision,
                          judge character(1),
                          CONSTRAINT " + table + @"data_pkey PRIMARY KEY (serno, lot, inspectdate, inspect))
                          WITH (OIDS=FALSE);
                          ALTER TABLE " + table + "data OWNER TO pqm;";
                return SQL.sqlExecuteNonQuery(cmd, false);
            }
            catch
            {
                return false;
            }
        }

        public bool InsertTable(string table, string serno, string lot, string model, string site, string factory, string line, string process, string inspectdate, string tjudge, string tstatus, string remark)
        {
            string cmd = "select process from m_processtbl where process = '" + process + "'";
            if (!string.IsNullOrEmpty(SQL.sqlExecuteScalarString(cmd)))
                cmd = @"INSERT INTO " + table + @"(serno, lot, model, site, factory, line, process, inspectdate, 
            tjudge, tstatus, remark) VALUES ('" + serno + "','" + lot + "','" + model + "','" + site + "','" + factory + "','" + line + "','" + process + "','" + inspectdate + "','" + tjudge + "','" + tstatus + "','" + remark + "')";
            return SQL.sqlExecuteNonQuery(cmd, false);
        }

        public bool InsertTable(string table, string multiprocess)
        {
            if (string.IsNullOrEmpty(multiprocess))
                return false;
            string cmd = @"INSERT INTO " + table + @"(serno, lot, model, site, factory, line, process, inspectdate, 
            tjudge, tstatus, remark) VALUES " + multiprocess;
            return SQL.sqlExecuteNonQuery(cmd, false);
        }

        public bool CheckInspect(string inspect)
        {
            string cmd = "select inspect from m_procinsplink where inspect='" + inspect + "'";
            return !string.IsNullOrEmpty(SQL.sqlExecuteScalarString(cmd));
        }

        public bool InsertTableData(string table, string serno, string lot, string inspectdate, string inspect, string inspectdata, string judge)
        {
            string cmd = "select inspect from m_procinsplink where inspect='" + inspect + "'";
            if (!string.IsNullOrEmpty(SQL.sqlExecuteScalarString(cmd)))
            {
                cmd = @"INSERT INTO " + table + @"data(serno, lot, inspectdate, inspect, inspectdata, judge)
         VALUES('" + serno + "','" + lot + "','" + inspectdate + "','" + inspect + "','" + inspectdata + "','" + judge + "')";
            }
            return SQL.sqlExecuteNonQuery(cmd, false);
        }

        public bool InsertTableData(string table, string multiinspect)
        {
            if (string.IsNullOrEmpty(multiinspect))
                return false;
            string cmd = @"INSERT INTO " + table + @"data(serno, lot, inspectdate, inspect, inspectdata, judge) VALUES " + multiinspect;
            return SQL.sqlExecuteNonQuery(cmd, false);
        }
    }
}
