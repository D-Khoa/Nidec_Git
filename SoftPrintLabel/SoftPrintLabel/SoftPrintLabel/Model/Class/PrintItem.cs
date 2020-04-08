using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPrintLabel.Model
{
    public class PrintItem
    {
        public string Asset_No { get; set; }
        public string Asset_Name { get; set; }
        public string Model { get; set; }
        public string Ser { get; set; }
        public string Inv { get; set; }
        public List<PrintItem> listprintitem;
        public PrintItem()
        {
            listprintitem = new List<PrintItem>();
        }
        public void Getlistitem(string printitem)
        {
            //string[] excellines  = File.ReadAllLines(printitem);
            //IEnumerable<PrintItem> query = from excelline in excellines
            //                               where (!excelline.Contains("(TTB)") && !excellines.Contains ("Asset No"))
            //                               let columns = excelline.Split('')
        }
    }
}
