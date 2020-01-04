using System;
using System.Collections.Generic;
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
    }
}
