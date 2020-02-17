using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingPQMData.Controller
{
    public class DataPointItem
    {
        public string serno { get; set; }
        public DateTime inspectdate { get; set; }
        public string inspect { get; set; }
        public double inspectdata { get; set; }
        public string judge { get; set; }
    }
}
