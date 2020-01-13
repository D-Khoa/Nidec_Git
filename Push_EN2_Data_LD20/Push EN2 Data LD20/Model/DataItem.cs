using System;
using System.Collections.Generic;
using System.Data;
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
        #endregion

        public List<DataItem> GetDataItems(DataTable dt)
        {
            List<DataItem> list = new List<DataItem>();
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
                list.Add(item);
            }
            return list;
        }
    }
}
