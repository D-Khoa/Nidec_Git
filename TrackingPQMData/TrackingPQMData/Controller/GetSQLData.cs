using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingPQMData.Model;

namespace TrackingPQMData.Controller
{
    public class GetSQLData
    {
        PSQL SQL = new PSQL();
        StringBuilder Query = new StringBuilder();

        #region GET MODEL, PROCESS AND INSPECT
        /// <summary>
        /// Get list model name
        /// </summary>
        /// <returns></returns>
        public List<string> GetModelList()
        {
            List<string> list = new List<string>();
            Query.Append("select * from modeltbl order by model");
            SQL.getListString(Query.ToString(), ref list);
            Query.Clear();
            return list;
        }

        /// <summary>
        /// Get list process with model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<string> GetProcessList(string model)
        {
            List<string> list = new List<string>();
            Query.Append("Select process from processtbl where model ='").Append(model);
            Query.Append("' order by process");
            SQL.getListString(Query.ToString(), ref list);
            Query.Clear();
            return list;
        }

        /// <summary>
        /// Get list inspect with model and process
        /// </summary>
        /// <param name="model"></param>
        /// <param name="process"></param>
        /// <returns></returns>
        public List<string> GetInspectList(string model, string process)
        {
            List<string> list = new List<string>();
            Query.Append("Select inspect from procinsplink where model ='").Append(model);
            Query.Append("' and process ='").Append(process);
            Query.Append("' order by inspect");
            SQL.getListString(Query.ToString(), ref list);
            Query.Clear();
            return list;
        }
        #endregion

        /// <summary>
        /// Get data of process into datatable
        /// </summary>
        /// <param name="list">list inspect</param>
        /// <param name="table">table of model</param>
        /// <param name="begin">begin time</param>
        /// <param name="end">end time</param>
        /// <returns></returns>
        public DataTable ProcessDatatable(List<string> list, string table, string begin, string end)
        {
            try
            {
                if (list.Count == 0)
                    return null;
                DataTable dt = new DataTable();
                string inspects = "";
                foreach (string text in list)
                {
                    inspects += "'" + text + "',";
                }
                inspects = inspects.Remove(inspects.Length - 1);
                Query.Clear();
                Query.Append("select * from ").Append(table).Append(" where inspectdate >= '").Append(begin);
                Query.Append("' and inspectdate <= '").Append(end).Append("' and inspect in (").Append(inspects);
                Query.Append(") order by inspect, inspectdate");
                SQL.sqlDataAdapterFillDatatable(Query.ToString(), ref dt);
                Query.Clear();
                //dt = DataLinQ.Pivot(dt, dt.Columns["inspect"], dt.Columns["inspectdata"]);
                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
