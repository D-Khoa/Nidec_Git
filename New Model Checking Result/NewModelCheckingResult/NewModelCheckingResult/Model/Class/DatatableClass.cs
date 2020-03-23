using System.Linq;
using System.Data;
using System.Collections.Generic;
using System;

namespace NewModelCheckingResult.Model
{
    public static class DatatableClass
    {
        public static DataTable Pivot(DataTable dt, DataColumn pivotColumn, DataColumn pivotValue)
        {
            // find primary key columns 
            //(i.e. everything but pivot column and pivot value)
            DataTable temp = dt.Copy();
            temp.Columns.Remove(pivotColumn.ColumnName);
            temp.Columns.Remove(pivotValue.ColumnName);
            string[] pkColumnNames = temp.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToArray();

            // prep results table
            DataTable result = temp.DefaultView.ToTable(true, pkColumnNames).Copy();
            result.PrimaryKey = result.Columns.Cast<DataColumn>().ToArray();
            dt.AsEnumerable()
                .Select(r => r[pivotColumn.ColumnName].ToString())
                .Distinct().ToList()
                .ForEach(c => result.Columns.Add(c, pivotColumn.DataType));

            // load it
            foreach (DataRow row in dt.Rows)
            {
                // find row to update
                DataRow aggRow = result.Rows.Find(
                    pkColumnNames
                        .Select(c => row[c])
                        .ToArray());
                // the aggregate used here is LATEST 
                // adjust the next line if you want (SUM, MAX, etc...)
                aggRow[row[pivotColumn.ColumnName].ToString()] = row[pivotValue.ColumnName];
            }

            return result;
        }

        public static DataTable Joined(DataTable dt1, DataTable dt2)
        {
            var result = from a in dt1.AsEnumerable()
                         join b in dt2.AsEnumerable()
                         on new { x = a["serno"], y = a["inspectdate"] }
                         equals new { x = b["serno"], y = b["inspectdate"] }
                         select new
                         {
                             a,
                             b
                         };
            DataTable dtjoined = new DataTable();
            foreach (DataColumn col in dt1.Columns)
                dtjoined.Columns.Add(col.ColumnName);
            foreach (DataColumn col in dt2.Columns)
            {
                if (!dtjoined.Columns.Contains(col.ColumnName))
                    dtjoined.Columns.Add(col.ColumnName);
            }
            foreach (var row in result)
            {
                var newrow = dtjoined.NewRow();
                int n = row.b.ItemArray.Count();
                object[] a = new object[n - 2];
                for (int i = 0; i < n - 2; i++)
                {
                    a[i] = row.b.ItemArray[i + 2];
                }
                newrow.ItemArray = (row.a.ItemArray.Concat(a)).ToArray();
                dtjoined.Rows.Add(newrow);
            }
            return dtjoined;
        }

        public static DataTable CreateDatatableFromClass<T>(this IEnumerable<T> inList)
        {
            DataTable dt = new DataTable();
            Type type = typeof(T);
            var properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType != typeof(List<T>))
                    dt.Columns.Add(properties[i].Name);
            }
            foreach (object o in inList)
            {
                DataRow dr = dt.NewRow();
                properties = o.GetType().GetProperties();
                dr.ItemArray = properties.Where(x => x.PropertyType != typeof(List<T>)).Select(x => x.GetValue(o)).ToArray();
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
