using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    public class PrintItem
    {
        public string Item_Number { get; set; }
        public string Item_Name { get; set; }
        public string SupplierCD { get; set; }
        public string SupplierName { get; set; }
        public string Invoice { get; set; }
        public DateTime Delivery_Date { get; set; }
        public double Delivery_Qty { get; set; }
        //public string PONo { get; set; }
        public string OrderNo { get; set; }
        public int Label_Qty { get; set; }
        public BindingList<PrintItem> ListPrintItem { get; set; }

        public PrintItem()
        {
            ListPrintItem = new BindingList<PrintItem>();
        }
    }
}
