using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_PQM_Data_NSTV.Model
{
    public class QueryCenter
    {
        PSQL SQL = new PSQL();
        string Query = string.Empty;

        /// <summary>
        /// Create table and table data of model with month
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="date">Month and Year (yyyyMM)</param>
        /// <returns></returns>
        public bool CreateNewTable(string model, string date)
        {
            string table = model + date;
            Query = @"CREATE TABLE " + table
                  + @"(
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
                        CONSTRAINT " + table + @"_pkey PRIMARY KEY (serno, lot, model, site, factory, line, process, inspectdate)
                      ) WITH (OIDS=FALSE);
                      ALTER TABLE " + table + @" OWNER TO pqm_ad;
                      CREATE INDEX " + table + @"_p02 ON " + table + @"
                        USING btree(model, site, factory, line, process, inspectdate, serno, lot);
                      CREATE INDEX " + table + @"_p03 ON " + table + @"
                        USING btree (inspectdate, model, site, factory, line, process, serno, lot);";
            if (!SQL.sqlExecuteNonQuery(Query)) return false;
            Query = string.Empty;
            Query = @"CREATE TABLE " + table + "data"
                  + @"(
                        serno character varying(50) NOT NULL,
                        lot character varying(50) NOT NULL,
                        inspectdate timestamp with time zone NOT NULL,
                        inspect character varying(32) NOT NULL,
                        inspectdata double precision,
                        judge character(1),
                        CONSTRAINT " + table + @"data_pkey PRIMARY KEY (serno, lot, inspectdate, inspect)
                      ) WITH (OIDS=FALSE);
                      ALTER TABLE " + table + @"data OWNER TO pqm_ad;";
            if (!SQL.sqlExecuteNonQuery(Query)) return false;
            return true;
        }
    }
}
