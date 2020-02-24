using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                                              Item_Number = columns[2].Trim(),
                                              Item_Name = columns[3].Trim(),
                                              PO_No = columns[4].Trim(),
                                              Order_No = columns[5].Trim(),
                                              Supplier_Code = columns[0].Trim(),
                                              Supplier_Name = columns[1].Trim(),
                                              Supplier_Invoice = columns[29].Trim(),
                                              Delivery_Date = DateTime.Parse(columns[9].Trim()),
                                              Delivery_Qty = !string.IsNullOrEmpty(columns[10].Trim()) ? double.Parse(columns[10].Trim()) : 0,
                                              Incharge = columns[15].Trim(),
                                          };
            listPremacItem = query.ToList();
            listPremacItem.Sort((a, b) => a.Item_Number.CompareTo(b.Item_Number));
        }
    }
}
