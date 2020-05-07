using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    public class OutputItem
    {
        #region ALL FIELDS
        public int issue_cd { get; set; }
        public string destination_cd { get; set; }
        public string item_number { get; set; }
        //public string item_name { get; set; }
        //public string supplier_cd { get; set; }
        //public string supplier_name { get; set; }
        public string supplier_invoice { get; set; }
        public double delivery_qty { get; set; }
        public DateTime delivery_date { get; set; }
        public string order_number { get; set; }
        public string incharge { get; set; }
        public List<string> errorColumns;
        public List<OutputItem> listOutputItem;
        public OutputItem()
        {
            errorColumns = new List<string>();
            listOutputItem = new List<OutputItem>();
        }
        #endregion

        #region QUERY
        public string AddLenData(string datastring, int leng)
        {
            int datalen = datastring.Length;
            if (datalen < leng)
            {
                for (int i = 0; i < (leng - datalen); i++)
                {
                    datastring += " ";
                }
            }
            return datastring;
        }

        public void ExportCSV(List<OutputItem> inList)
        {
            var properties = inList[0].GetType().GetProperties();
            string foldername = SettingItem.outputFolder + @"\StockOut";
            string bkfoldername = SettingItem.backupFolder + @"\BKStockOut";
            if (!Directory.Exists(foldername)) Directory.CreateDirectory(foldername);
            if (!Directory.Exists(bkfoldername)) Directory.CreateDirectory(bkfoldername);
            string filename = @"\stockout_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            using (StreamWriter sw = new StreamWriter(foldername + filename))
            {
                string line = string.Empty;
                //Write columns
                line = string.Join("?", properties.Select(x => x.Name));
                sw.WriteLine(line);
                for (int i = 0; i < inList.Count; i++)
                {
                    //var propretiesValue = inList[i].GetType().GetProperties();
                    //line = string.Join("?", (from x in propretiesValue
                    //                         select x.Name == "delivery_date" ?
                    //                         ((DateTime)x.GetValue(inList[i], null)).ToString("yyyy-MM-dd")
                    //                         : x.GetValue(inList[i], null)));
                    line = AddLenData(inList[i].issue_cd.ToString(), 30);
                    line += "?" + AddLenData(inList[i].destination_cd.ToString(), 30);
                    line += "?" + AddLenData(inList[i].item_number.ToString(), 30);
                    line += "?" + AddLenData(inList[i].supplier_invoice.ToString(), 30);
                    line += "?" + AddLenData(inList[i].delivery_qty.ToString(), 30);
                    line += "?" + AddLenData(inList[i].delivery_date.ToString("yyyy-MM-dd"), 30);
                    line += "?" + AddLenData(inList[i].order_number.ToString(), 30);
                    line += "?" + AddLenData(inList[i].incharge.ToString(), 30);
                    sw.WriteLine(line);
                }
                sw.Flush();
                sw.Close();
            }
            File.Copy(foldername + filename, bkfoldername + filename);
        }

        public void ExportCSV(List<OutputItem> inList, string filename)
        {
            var properties = inList[0].GetType().GetProperties();
            using (StreamWriter sw = new StreamWriter(filename))
            {
                string line = string.Empty;
                //Write columns
                line = string.Join("?", properties.Select(x => x.Name));
                sw.WriteLine(line);
                for (int i = 0; i < inList.Count; i++)
                {
                    var propretiesValue = inList[i].GetType().GetProperties();
                    line = string.Join("?", (from x in propretiesValue
                                             select x.Name == "delivery_date" ?
                                             ((DateTime)x.GetValue(inList[i], null)).ToString("yyyy-MM-dd")
                                             : x.GetValue(inList[i], null)));
                    sw.WriteLine(line);
                }
                sw.Flush();
                sw.Close();
            }
        }

        public void ImportCSV(string errorfile)
        {
            string[] csvlines = File.ReadAllLines(errorfile);
            IEnumerable<OutputItem> query = from csvline in csvlines
                                            where (!csvline.Contains("issue_cd"))
                                            let columns = csvline.Split('?')
                                            select new OutputItem
                                            {
                                                issue_cd = int.Parse(Regex.Replace(columns[0], " {2,}", " ").Trim()),
                                                destination_cd = Regex.Replace(columns[1], " {2,}", " ").Trim(),
                                                item_number = Regex.Replace(columns[2], " {2,}", " ").Trim(),
                                                supplier_invoice = Regex.Replace(columns[3], " {2,}", " ").Trim(),
                                                delivery_qty = double.Parse(Regex.Replace(columns[4], " {2,}", " ").Trim()),
                                                delivery_date = DateTime.Parse(Regex.Replace(columns[5], " {2,}", " ").Trim()),
                                                order_number = Regex.Replace(columns[6], " {2,}", " ").Trim(),
                                                incharge = Regex.Replace(columns[7], " {2,}", " ").Trim(),
                                                errorColumns = Regex.Replace(columns[8], " {2,}", " ").Trim().Split(',').ToList(),
                                            };
            listOutputItem.AddRange(query.ToList());
            listOutputItem.Sort((a, b) => a.item_number.CompareTo(b.item_number));
        }
        #endregion
    }
}
