using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Push_EN2_Data_LD20
{
    public class SQLQuery
    {
        PSQL SQL = new PSQL();
        string Query = string.Empty;

        public int InsertProcessItem(string table, DataItem item)
        {
            Query = "INSERT INTO " + table;
            Query += "(serno, lot, model, site, factory, line, process, inspectdate, tjudge, tstatus, remark) ";
            Query += "VALUES('" + item.serno + "','" + item.lot + "','" + item.model + "','" + item.site + "','";
            Query += item.factory + "','" + item.line + "','" + item.process + "','" + item.inspectdate + "','";
            Query += item.tjugde + "','" + item.status + "','" + item.remark + "')";
            return SQL.sqlExecuteNonQueryInt(Query);
        }

        public int InsertInspectItem(string table, DataItem item)
        {
            if (string.IsNullOrEmpty(item.jugde))
                item.jugde = item.tjugde;
            Query = "INSERT INTO " + table + "data";
            Query += "(serno, lot, inspectdate, inspect, inspectdata, judge) ";
            Query += "VALUES('" + item.serno + "','" + item.lot + "','" + item.inspectdate + "','";
            Query += item.inspect + "','" + item.inspectdata + "','" + item.jugde + "')";
            return SQL.sqlExecuteNonQueryInt(Query);
        }

        public int InsertInspectItem(string table, DataItem item, string name, double usl, double lsl)
        {
            if (item.inspect == name)
            {
                if (item.RDC > lsl && item.RDC < usl)
                    item.jugde = "0";
                else
                    item.jugde = "1";
            }
            if (string.IsNullOrEmpty(item.jugde))
                item.jugde = item.tjugde;
            Query = "INSERT INTO " + table + "data";
            Query += "(serno, lot, inspectdate, inspect, inspectdata, judge) ";
            Query += "VALUES('" + item.serno + "','" + item.lot + "','" + item.inspectdate + "','";
            Query += item.inspect + "','" + item.inspectdata + "','" + item.jugde + "')";
            return SQL.sqlExecuteNonQueryInt(Query);
        }

    }
}
