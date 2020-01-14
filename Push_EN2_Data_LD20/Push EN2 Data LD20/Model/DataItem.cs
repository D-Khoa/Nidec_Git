using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Push_EN2_Data_LD20
{
    public class DataItem
    {
        #region INSPECT
        public double RDC { get; set; }
        public double SDGRMSMI { get; set; }
        public double SDGRMSMA { get; set; }
        public double SDF0 { get; set; }
        public double SDCURGF0 { get; set; }
        public double SDCURMIN { get; set; }
        public double SDCURMAX { get; set; }
        public double SDCURFO { get; set; }
        public double SGRMSAVE { get; set; }
        public double SGOPAVE { get; set; }
        public double SGPPAVE { get; set; }
        public double SCURAVE { get; set; }
        public double SCURMAX { get; set; }
        public double SRTPCTG1 { get; set; }
        public double SRTPCTG2 { get; set; }
        public double SRTPCTG { get; set; }
        public double SBTPCTG1 { get; set; }
        public double SBTPCTG2 { get; set; }
        public double SBTPCTG { get; set; }
        public double STHD { get; set; }
        public double STNOISE { get; set; }
        public double SDECAY { get; set; }
        public double SDTIME { get; set; }
        #endregion

        #region PQM DATA
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
        public string jugde { get; set; }
        public string tjugde { get; set; }
        public string status { get; set; }
        public string remark { get; set; }
        List<DataItem> listDataItems { get; set; }
        #endregion

        public List<DataItem> GetDataItems(DataTable dt)
        {
            listDataItems = new List<DataItem>();
            foreach (DataRow dr in dt.Rows)
            {
                DataItem item = new DataItem
                {
                    serno = dr["System|Bercode"].ToString(),
                    model = dr["System|Model"].ToString(),
                    lot = dr["System|Lot"].ToString(),
                    site = "TTB",
                    factory = "LD20",
                    line = "1",
                    process = "EN1",
                    status = "",
                    remark = "",
                    inspectdate = (DateTime)dr["System|Date"],
                    jugde = string.Empty,
                    tjugde = dr["System|Jugde"].ToString(),

                    RDC = (double)dr["ReDC|Resistance[ohm]"],

                    SDGRMSMI = (double)dr["SweepDown|Grms(min)[G]"],
                    SDGRMSMA = (double)dr["SweepDown|Grms(max)[G]"],
                    SDF0 = (double)dr["SweepDown|F0(G)[Hz]"],
                    SDCURGF0 = (double)dr["SweepDown|Current(gF0)[Hz]"],
                    SDCURMIN = (double)dr["SweepDown|Current(min)[mA]"],
                    SDCURMAX = (double)dr["SweepDown|Current(max)[mA]"],
                    SDCURFO = (double)dr["SweepDown|F0(Current)[Hz]"],

                    SGRMSAVE = (double)dr["Single|Grms(ave)[G]"],
                    SGOPAVE = (double)dr["Single|G0p(ave)[G]"],
                    SGPPAVE = (double)dr["Single|Gpp(ave)[G]"],
                    SCURAVE = (double)dr["Single|Current(ave)[mA]"],
                    SCURMAX = (double)dr["Single|Current(max)[mA]"],
                    SRTPCTG1 = (double)dr["Single|RiseTime(PctG1)[ms]"],
                    SRTPCTG2 = (double)dr["Single|RiseTime(PctG2)[ms]"],
                    SRTPCTG = (double)dr["Single|RiseTime(SpecG)[ms]"],
                    SBTPCTG1 = (double)dr["Single|BrakeTime(PctG1)[ms]"],
                    SBTPCTG2 = (double)dr["Single|BrakeTime(PctG2)[ms]"],
                    SBTPCTG = (double)dr["Single|BrakeTime(SpecG)[ms]"],
                    STHD = (double)dr["Single|THD[pct]"],
                    STNOISE = (double)dr["Single|TouchNoise[pct]"],
                    SDECAY = (double)dr["Single|DecayRate[dB/s]"],
                    SDTIME = (double)dr["Single|DropTime[ms]"],
                };
                listDataItems.Add(item);
            }
            return listDataItems;
        }

        public List<DataItem> GetItemsFromCSV(string path)
        {
            int c = 0;
            string[] dr = null;
            string[] col = null;
            string[] col1 = null;
            listDataItems = new List<DataItem>();
            StreamReader rd = new StreamReader(path, false);
            while (!rd.EndOfStream)
            {
                string line = rd.ReadLine();
                #region GET COLUMNS
                if (c == 0)
                {
                    col1 = line.Split(',');
                }
                else if (c == 1)
                {
                    col = line.Split(',');
                    for (int i = 0; i < col.Length; i++)
                    {
                        if (string.IsNullOrEmpty(col1[i]))
                            col1[i] = col1[i - 1];
                        col[i] = col1[i].Replace(" ", "") + "|" + col[i];
                    }
                }
                #endregion
                #region ADD A ITEM
                else
                {
                    dr = line.Split(',');
                    DataItem item = new DataItem
                    {
                        serno = dr[Array.IndexOf(col, "System|Bercode")].ToString(),
                        model = dr[Array.IndexOf(col, "System|Model")].ToString(),
                        lot = dr[Array.IndexOf(col, "System|Lot")].ToString(),
                        site = "TTB",
                        factory = "LD20",
                        line = "1",
                        process = "EN1",
                        status = "",
                        remark = "",
                        inspectdate = DateTime.Parse(dr[Array.IndexOf(col, "System|Date")]),
                        jugde = string.Empty,
                        tjugde = dr[Array.IndexOf(col, "System|Judge")].ToString(),

                        RDC = double.Parse(dr[Array.IndexOf(col, "ReDC|Resistance[ohm]")]),

                        SDGRMSMI = double.Parse(dr[Array.IndexOf(col, "SweepDown|Grms(min)[G]")]),
                        SDGRMSMA = double.Parse(dr[Array.IndexOf(col, "SweepDown|Grms(max)[G]")]),
                        SDF0 = double.Parse(dr[Array.IndexOf(col, "SweepDown|F0(G)[Hz]")]),
                        SDCURGF0 = double.Parse(dr[Array.IndexOf(col, "SweepDown|Current(gF0)[Hz]")]),
                        SDCURMIN = double.Parse(dr[Array.IndexOf(col, "SweepDown|Current(min)[mA]")]),
                        SDCURMAX = double.Parse(dr[Array.IndexOf(col, "SweepDown|Current(max)[mA]")]),
                        SDCURFO = double.Parse(dr[Array.IndexOf(col, "SweepDown|F0(Current)[Hz]")]),

                        SGRMSAVE = double.Parse(dr[Array.IndexOf(col, "Single|Grms(ave)[G]")]),
                        SGOPAVE = double.Parse(dr[Array.IndexOf(col, "Single|G0p(ave)[G]")]),
                        SGPPAVE = double.Parse(dr[Array.IndexOf(col, "Single|Gpp(ave)[G]")]),
                        SCURAVE = double.Parse(dr[Array.IndexOf(col, "Single|Current(ave)[mA]")]),
                        SCURMAX = double.Parse(dr[Array.IndexOf(col, "Single|Current(max)[mA]")]),
                        SRTPCTG1 = double.Parse(dr[Array.IndexOf(col, "Single|RiseTime(PctG1)[ms]")]),
                        SRTPCTG2 = double.Parse(dr[Array.IndexOf(col, "Single|RiseTime(PctG2)[ms]")]),
                        SRTPCTG = double.Parse(dr[Array.IndexOf(col, "Single|RiseTime(SpecG)[ms]")]),
                        SBTPCTG1 = double.Parse(dr[Array.IndexOf(col, "Single|BrakeTime(PctG1)[ms]")]),
                        SBTPCTG2 = double.Parse(dr[Array.IndexOf(col, "Single|BrakeTime(PctG2)[ms]")]),
                        SBTPCTG = double.Parse(dr[Array.IndexOf(col, "Single|BrakeTime(SpecG)[ms]")]),
                        STHD = double.Parse(dr[Array.IndexOf(col, "Single|THD[pct]")]),
                        STNOISE = double.Parse(dr[Array.IndexOf(col, "Single|TouchNoise[pct]")]),
                        SDECAY = double.Parse(dr[Array.IndexOf(col, "Single|DecayRate[dB/s]")]),
                        SDTIME = double.Parse(dr[Array.IndexOf(col, "Single|DropTime[ms]")]),
                    };
                    listDataItems.Add(item);
                }
                #endregion
                c++;
            }
            rd.Close();
            return listDataItems;
        }

        public void ItemsExportToCSV(List<DataItem> datalist, string folderpath)
        {
            string filename = string.Empty;
            List<string> lines = new List<string>();
            foreach (DataItem item in datalist)
            {
                lines.Add(getLineItem(item, nameof(RDC), item.RDC));
                lines.Add(getLineItem(item, nameof(SDGRMSMI), item.SDGRMSMI));
                lines.Add(getLineItem(item, nameof(SDGRMSMA), item.SDGRMSMA));
                lines.Add(getLineItem(item, nameof(SDF0), item.SDF0));
                lines.Add(getLineItem(item, nameof(SDCURGF0), item.SDCURGF0));
                lines.Add(getLineItem(item, nameof(SDCURMIN), item.SDCURMIN));
                lines.Add(getLineItem(item, nameof(SDCURMAX), item.SDCURMAX));
                lines.Add(getLineItem(item, nameof(SDCURFO), item.SDCURFO));
                lines.Add(getLineItem(item, nameof(SGRMSAVE), item.SGRMSAVE));
                lines.Add(getLineItem(item, nameof(SGOPAVE), item.SGOPAVE));
                lines.Add(getLineItem(item, nameof(SGPPAVE), item.SGPPAVE));
                lines.Add(getLineItem(item, nameof(SCURAVE), item.SCURAVE));
                lines.Add(getLineItem(item, nameof(SCURMAX), item.SCURMAX));
                lines.Add(getLineItem(item, nameof(SRTPCTG1), item.SRTPCTG1));
                lines.Add(getLineItem(item, nameof(SRTPCTG2), item.SRTPCTG2));
                lines.Add(getLineItem(item, nameof(SRTPCTG), item.SRTPCTG));
                lines.Add(getLineItem(item, nameof(SBTPCTG1), item.SBTPCTG1));
                lines.Add(getLineItem(item, nameof(SBTPCTG2), item.SBTPCTG2));
                lines.Add(getLineItem(item, nameof(SBTPCTG), item.SBTPCTG));
                lines.Add(getLineItem(item, nameof(STHD), item.STHD));
                lines.Add(getLineItem(item, nameof(STNOISE), item.STNOISE));
                lines.Add(getLineItem(item, nameof(SDECAY), item.SDECAY));
                lines.Add(getLineItem(item, nameof(SDTIME), item.SDTIME));
                filename = folderpath + item.serno + item.inspectdate.ToString("yyyyMMddHHmmss") + ".csv";
                if (File.Exists(filename)) File.Delete(filename);
                using (FileStream myfile = File.Create(filename))
                {
                    byte[] data = lines.SelectMany(x => Encoding.UTF8.GetBytes(x)).ToArray();
                    foreach (byte d in data)
                        myfile.WriteByte(d);
                }
            }
        }

        private string getLineItem(DataItem item, string inspectname, double inspectvalue)
        {
            item.inspect = inspectname;
            item.inspectdata = inspectvalue;
            string line = string.Empty;
            line = item.serno + "|";
            line += item.lot + "|";
            line += item.model + "|";
            line += item.site + "|";
            line += item.factory + "|";
            line += item.line + "|";
            line += item.process + "|";
            line += item.inspect + "|";
            line += item.inspectdate.ToString("yyyy-MM-dd") + "|";
            line += item.inspectdate.ToString("HH:mm:ss") + "|";
            line += item.inspectdata + "|";
            line += item.jugde + "|";
            line += item.status + "|";
            line += item.remark + Environment.NewLine;
            return line;
        }
    }
}
