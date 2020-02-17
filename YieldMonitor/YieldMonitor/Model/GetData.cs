using System;
using System.Text;
using System.Collections.Generic;

namespace YieldMonitor.Model
{
    /// <summary>
    /// Class for get data from database
    /// </summary>
    public static class GetData
    {
        static TfSQL SQL = new TfSQL();
        //static SSQL SQL = new SSQL();
        static StringBuilder command = new StringBuilder();

        /// <summary>
        /// Get list model in modeltbl to combobox
        /// </summary>
        /// <param name="cmb"></param>
        public static void GetModelToCombobox(this System.Windows.Forms.ComboBox cmb)
        {
            command.Append("Select distinct model from modeltbl order by model");
            SQL.getComboBoxData(command.ToString(), ref cmb);
            command.Clear();
        }

        /// <summary>
        /// Get list process of model in processtbl
        /// </summary>
        /// <param name="list"></param>
        /// <param name="Model"></param>
        public static void GetProcessToList(ref List<string> list, string Model)
        {
            list = new List<string>();
            command.Append("select distinct process from processtbl where model = '" + Model + "' order by process");
            SQL.getListString(command.ToString(), ref list);
            command.Clear();
        }

        /// <summary>
        /// Get input of process in line
        /// </summary>
        /// <param name="Process"></param>
        /// <param name="Table"></param>
        /// <param name="DateFrom"></param>
        /// <param name="DateTo"></param>
        /// <returns></returns>
        public static double GetInput(string Process, string Table, DateTime DateFrom, DateTime DateTo)
        {
            command.Append("select count(*) as input from ").Append(Table);
            command.Append(" where process = '").Append(Process).Append("'");
            command.Append(" and inspectdate >= '").Append(DateFrom.ToString("yyyy-MM-dd HH:mm:ss")).Append("'");
            command.Append(" and inspectdate <= '").Append(DateTo.ToString("yyyy-MM-dd HH:mm:ss")).Append("'");
            double d = SQL.sqlExecuteScalarDouble(command.ToString());
            command.Clear();
            return d;
        }

        /// <summary>
        /// Get output of process in line
        /// </summary>
        /// <param name="Process"></param>
        /// <param name="Table"></param>
        /// <param name="DateFrom"></param>
        /// <param name="DateTo"></param>
        /// <returns></returns>
        public static double GetOutput(string Process, string Table, DateTime DateFrom, DateTime DateTo)
        {
            command.Append("select count(case when tjudge = '0' then 1 end) as output from ").Append(Table);
            command.Append(" where process = '").Append(Process).Append("'");
            command.Append(" and inspectdate >= '").Append(DateFrom.ToString("yyyy-MM-dd HH:mm:ss")).Append("'");
            command.Append(" and inspectdate <= '").Append(DateTo.ToString("yyyy-MM-dd HH:mm:ss")).Append("'");
            double d = SQL.sqlExecuteScalarDouble(command.ToString());
            command.Clear();
            return d;
        }
    }
}
