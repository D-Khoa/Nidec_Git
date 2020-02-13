using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    public class pts_plan
    {
        #region ALL FIELDS
        public int plan_id { get; set; }
        public string destination_cd { get; set; }
        public string set_number { get; set; }
        public DateTime plan_date { get; set; }
        public double plan_qty { get; set; }
        public string plan_usercd { get; set; }
        public DateTime delivery_date { get; set; }
        public string comment { get; set; }
        public BindingList<pts_plan> listPlan { get; set; }
        public pts_plan()
        {
            listPlan = new BindingList<pts_plan>();
        }
        #endregion

        #region QUERY DATA
        /// <summary>
        /// Search list plan of PC
        /// </summary>
        /// <param name="inItem">input search info plan</param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="checkState">0: no check date, 1: check plan date, 2: check delivery date</param>
        public void Search(pts_plan inItem, DateTime fromDate, DateTime toDate, int checkState)
        {
            //SQL library
            PSQL SQL = new PSQL();
            string query = string.Empty;
            //Open SQL connection
            SQL.Open();
            //SQL query string
            query = "SELECT plan_id, destination_cd, set_number, plan_date, plan_usercd, plan_qty, delivery_date, comment ";
            query += "FROM pts_plan WHERE 1=1 ";
            if (inItem.plan_id > 0)
                query += "AND plan_id ='" + inItem.plan_id + "' ";
            if (!string.IsNullOrEmpty(inItem.destination_cd))
                query += "AND destination_cd ='" + inItem.destination_cd + "' ";
            if (!string.IsNullOrEmpty(inItem.set_number))
                query += "AND set_number like '" + inItem.set_number.Remove(inItem.set_number.Length - 1) + "%' ";
            if (!string.IsNullOrEmpty(inItem.plan_usercd))
                query += "AND plan_usercd ='" + inItem.plan_usercd + "' ";
            switch (checkState)
            {
                case 1:
                    query += "AND plan_date >='" + fromDate.ToString("yyyy-MM-dd") + "' ";
                    query += "AND plan_date <='" + toDate.ToString("yyyy-MM-dd") + "' ";
                    break;
                case 2:
                    query += "AND delivery_date >='" + fromDate.ToString("yyyy-MM-dd") + "' ";
                    query += "AND delivery_date <='" + toDate.ToString("yyyy-MM-dd") + "' ";
                    break;
            }
            query += "ORDER BY plan_id";
            //Execute reader for read database
            IDataReader reader = SQL.Command(query).ExecuteReader();
            query = string.Empty;
            //Get an item
            while(reader.Read())
            {
                pts_plan outItem = new pts_plan
                {
                    plan_id = (int)reader["plan_id"],
                    destination_cd = reader["destination_cd"].ToString(),
                    set_number = reader["set_number"].ToString(),
                    plan_date = (DateTime)reader["plan_date"],
                    plan_usercd = reader["plan_usercd"].ToString(),
                    plan_qty = (double)reader["plan_qty"],
                    delivery_date = (DateTime)reader["delivery_date"],
                    comment = reader["comment"].ToString(),
                };
                listPlan.Add(outItem);
            }
            reader.Close();
            SQL.Close();
        }

        public int Add(pts_plan inItem)
        #endregion
    }
}
