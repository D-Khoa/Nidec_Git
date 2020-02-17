using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_PQM_Data_NSTV.Model
{
    public class DataItem
    {
        public string serno { get; set; }
        public string lot { get; set; }
        public string model { get; set; }
        public string site { get; set; }
        public string factory { get; set; }
        public string line { get; set; }
        public string process { get; set; }
        public string inspect { get; set; }
        public DateTime inspectdate { get; set; }
        public double inspectdata { get; set; }
        public string judge { get; set; }
        public string status { get; set; }
        public string remark { get; set; }
        public List<DataItem> listItems { get; set; }

        public List<DataItem> GetListItemsFromCSV(string path)
        {
            int c = 0;
            string[] row = null;
            string[] col = null;
            string[] col1 = null;
            //Read file
            using (StreamReader rd = new StreamReader(path, false))
            {
                while (!rd.EndOfStream)
                {
                    //Read a line
                    string line = rd.ReadLine();
                    //Get col of first line
                    if (c == 0) col1 = line.Split(',');
                    //Get col of second line
                    else if (c == 1)
                    {
                        col = line.Split(',');
                        for (int i = 0; i < col.Length; i++)
                        {
                            //If a col in first lin null then it equal before col
                            if (string.IsNullOrEmpty(col1[i])) col1[i] = col1[i - 1];
                            //Combian first col and second col
                            col[i] = col1[i].Replace(" ", "") + "|" + col[i];
                        }
                    }
                    else
                    {
                        row = line.Split(',');
                        DataItem item = new DataItem
                        {

                        };
                    }
                    c++;
                }
            }
        }
    }
}
