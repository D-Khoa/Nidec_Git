using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PC_QRCodeSystem.Model
{
    public class PrintItem
    {
        #region ALL FIELDS
        public string Item_Number { get; set; }
        public string Item_Name { get; set; }
        public string SupplierCD { get; set; }
        public string SupplierName { get; set; }
        public string Invoice { get; set; }
        public DateTime Delivery_Date { get; set; }
        public double Delivery_Qty { get; set; }
        public string PONo { get; set; }
        public string OrderNo { get; set; }
        public int Label_Qty { get; set; }
        public BindingList<PrintItem> ListPrintItem { get; set; }
        public PrintItem()
        {
            ListPrintItem = new BindingList<PrintItem>();
        }
        #endregion

        #region PRINTER
        /// <summary>
        /// Check status of printer
        /// </summary>
        /// <param name="printer">Printer name</param>
        /// <returns>TRUE: OFFLINE, FALSE: ONLINE</returns>
        public bool CheckPrinterIsOffline(string printer)
        {
            ManagementObjectSearcher printerSearch = new ManagementObjectSearcher("Select Name, WorkOffline from Win32_Printer");
            foreach (ManagementBaseObject searchprint in printerSearch.Get())
            {
                if (searchprint["Name"].ToString() == printer)
                {
                    return (Boolean)searchprint["WorkOffline"];
                }
            }
            throw new Exception("Printer is not install");
        }

        /// <summary>
        /// Print pc stock items
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="printOneCoppy">true: print 1 label</param>
        /// <returns></returns>
        public bool PrintItems(List<PrintItem> Items, bool printOneCoppy)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (printOneCoppy)
                {
                    TfPrint.printBarCodeNew(Items[i].Item_Number, Items[i].Item_Name, Items[i].SupplierName, Items[i].Invoice,
                         Items[i].Delivery_Date.ToString("yyyy/MM/dd"), Items[i].Delivery_Qty.ToString(), Items[i].SupplierCD,
                         Items[i].PONo, Items[i].OrderNo);
                }
                else
                {
                    for (int j = 0; j < Items[i].Label_Qty; j++)
                    {
                        TfPrint.printBarCodeNew(Items[i].Item_Number, Items[i].Item_Name, Items[i].SupplierName, Items[i].Invoice,
                            Items[i].Delivery_Date.ToString("yyyy/MM/dd"), Items[i].Delivery_Qty.ToString(), Items[i].SupplierCD,
                            Items[i].PONo, Items[i].OrderNo);
                    }
                }
            }
            return true;
        }
        #endregion
    }
}
