using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Threading.Tasks;

namespace ConvertAndSendData.Model
{
    public static class GetDataNSTV
    {
        static string serverfolder = @"\\192.168.145.7\nstvnoise$\FCT_NOISE\";
        public static void GetModelNSTV(this System.Windows.Forms.ComboBox cmb)
        {
            string[] paths = Directory.GetDirectories(serverfolder);
            foreach (string path in paths)
            {
                cmb.Items.Add(Path.GetFileName(path));
            }
        }
        public static void GetNoNSTV(this List<string> No, string Model)
        {
            string modelfolder = serverfolder + @"\" + Model + @"\";
            string[] paths = Directory.GetDirectories(modelfolder);
            foreach (string path in paths)
            {
                No.Add(Path.GetFileName(path));
            }

        }
        public static int GetInputNoiseNSTV(string No, DataTable table)
        {
            return table.Rows.Count;
        }
    }
}
