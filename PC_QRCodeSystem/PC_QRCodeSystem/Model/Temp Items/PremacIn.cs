using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PC_QRCodeSystem.Model
{
    public class PremacIn
    {
        #region ALL FIELDS
        public string Item_Number { get; set; }
        public string Item_Name { get; set; }
        public string Supplier_Code { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Invoice { get; set; }
        public string PO_No { get; set; }
        public double Delivery_Qty { get; set; }
        public DateTime Delivery_Date { get; set; }
        public string Order_No { get; set; }
        public string Incharge { get; set; }
        public List<PremacIn> listPremacItem;
        public PremacIn()
        {
            listPremacItem = new List<PremacIn>();
        }
        #endregion

        /// <summary>
        /// Get list PREMAC 6-4-9 from txt file
        /// </summary>
        /// <param name="premacfile">path of PREMAC file</param>
        /// <returns></returns>
        public void GetListPremacItem(string premacfile)
        {
            string[] csvlines = File.ReadAllLines(premacfile);
            IEnumerable<PremacIn> query = from csvline in csvlines
                                          where (!csvline.Contains("(CPFXE049)") && !csvline.Contains("SupplierCD"))
                                          let columns = csvline.Split('?')
                                          select new PremacIn
                                          {
                                              Item_Number = Regex.Replace(columns[2], " {2,}", " ").Trim(),
                                              Item_Name = Regex.Replace(columns[3], " {2,}", " ").Trim(),
                                              PO_No = Regex.Replace(columns[4], " {2,}", " ").Trim(),
                                              Order_No = Regex.Replace(columns[5], " {2,}", " ").Trim(),
                                              Supplier_Code = Regex.Replace(columns[0], " {2,}", " ").Trim(),
                                              Supplier_Name = Regex.Replace(columns[1], " {2,}", " ").Trim(),
                                              Supplier_Invoice = Regex.Replace(columns[29], " {2,}", " ").Trim(),
                                              Delivery_Date = DateTime.Parse(Regex.Replace(columns[9], " {2,}", " ").Trim()),
                                              Delivery_Qty = !string.IsNullOrEmpty(Regex.Replace(columns[10], " {2,}", " ").Trim()) ? double.Parse(Regex.Replace(columns[10], " {2,}", " ").Trim()) : 0,
                                              Incharge = Regex.Replace(columns[15], " {2,}", " ").Trim(),
                                          };
            listPremacItem = query.ToList();
            listPremacItem.Sort((a, b) => a.Item_Number.CompareTo(b.Item_Number));
        }
    }
}
