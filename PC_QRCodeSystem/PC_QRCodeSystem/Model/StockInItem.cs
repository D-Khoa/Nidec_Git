using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    public class StockInItem
    {
        public int Packing_ID { get; set; }
        public string Packing_Code { get; set; }
        public string Item_Number { get; set; }
        public string Item_Name { get; set; }
        //public double unit_qty { get; set; }
        //public int unit_cd { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Invoice { get; set; }
        public string PO_No { get; set; }
        public double Delivery_Qty { get; set; }
        //public DateTime stock_out_date { get; set; }
        public DateTime StockIn_Date { get; set; }
        public double Stock_Qty { get; set; }
        public string Incharge { get; set; }
        public DateTime Registrator_Date { get; set; }

        public List<StockInItem> GetStockInItem(List<PremacIn> listpreitem)
        {
            GetData gData = new GetData();
            List<StockInItem> list = new List<StockInItem>();
            double unit = 1;
            int qty = 1;
            double qtymod = 0;
            foreach (PremacIn item in listpreitem)
            {
                unit = gData.GetUnitQty(item.Item_Number);
                if (unit == 0) unit = 1;
                qty = (int)(item.Delivery_Qty / unit);
                for (int i = 0; i < qty; i++)
                {
                    list.Add(new StockInItem
                    {
                        Packing_Code = item.Item_Number + i.ToString(),
                        Item_Number = item.Item_Number,
                        Item_Name = item.Item_Name,
                        Supplier_Name = item.Supplier_Name,
                        Supplier_Invoice = item.Supplier_Invoice,
                        PO_No = item.PO_No,
                        Delivery_Qty = unit,
                        StockIn_Date = item.Delivery_Date,
                        Stock_Qty = unit,
                        Incharge = UserData.username,
                        Registrator_Date = DateTime.Now,
                    });
                }
                if (qty * unit < item.Delivery_Qty)
                {
                    qtymod = item.Delivery_Qty - (qty * unit);
                    list.Add(new StockInItem
                    {
                        Packing_Code = item.Item_Number + "-" + qty.ToString(),
                        Item_Number = item.Item_Number,
                        Item_Name = item.Item_Name,
                        Supplier_Name = item.Supplier_Name,
                        Supplier_Invoice = item.Supplier_Invoice,
                        PO_No = item.PO_No,
                        Delivery_Qty = qtymod,
                        StockIn_Date = item.Delivery_Date,
                        Stock_Qty = qtymod,
                        Incharge = UserData.username,
                        Registrator_Date = DateTime.Now,
                    });
                }
            }
            return list;
        }
    }
}
