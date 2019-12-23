using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateNewProcessNSTV.Model;

namespace CreateNewProcessNSTV
{
    public partial class PushDataIntoServer : Form
    {
        GetData gData = new GetData();
        string date;
        string table, serno, lot, model, site, factory, line, process, inspect, inspectdata, judge;
        StringBuilder mutliprocess = new StringBuilder();
        StringBuilder multiinspect = new StringBuilder();
        DateTime inspectdate;

        public PushDataIntoServer()
        {
            InitializeComponent();
        }

        private void findfile(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, "*.csv"))
                    {
                        lsbAllFileCSV.Items.Add(f);
                    }
                    findfile(d);
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            findfile(@"\\192.168.145.7\nstvnoise$\FCT_NOISE");
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            try
            {
                string tempfolder = @"\\192.168.145.7\nstvnoise$\TEMP";
                string errorfolder = @"\\192.168.145.7\nstvnoise$\ERROR";
                List<string> errorlist = new List<string>();
                site = "NSTV";
                factory = "2B";
                line = "L01";
                process = "FCT";
                multiinspect.Clear();
                mutliprocess.Clear();
                foreach (string item in lsbAllFileCSV.Items)
                {
                    DataTable dt = new DataTable();
                    model = Path.GetFileName(item).Split('_')[1];
                    model = model.Replace('-', '_');
                    date = Path.GetFileName(item).Split('_')[2].Split('-')[0]
                         + Path.GetFileName(item).Split('_')[2].Split('-')[1];
                    table = model + date;
                    gData.CreateTable(table);
                    gData.CreateTableData(table);
                    CSVUtility.ConvertCSVtoDataTable(dt, item);
                    foreach (DataRow dr in dt.Rows)
                    {
                        inspectdate = DateTime.Parse(dr["Date"].ToString());
                        serno = inspectdate.ToString("HHmmss") + dr["Number"].ToString();
                        lot = inspectdate.ToString("yyyyMMdd");
                        judge = dr["Judge"].ToString() == "OK" ? "0" : "1";
                        mutliprocess.Append("('").Append(serno).Append("','").Append(lot).Append("','");
                        mutliprocess.Append(model).Append("','").Append(site).Append("','").Append(factory).Append("','");
                        mutliprocess.Append(line).Append("','").Append(process).Append("','");
                        mutliprocess.Append(inspectdate.ToString("yyyy-MM-dd HH:mm:ss")).Append("','").Append(judge);
                        mutliprocess.Append("','INITAL',''), ");
                        //gData.InsertTable(table, serno, lot, model, site, factory, line, process, inspectdate.ToString("yyyy-MM-dd HH:mm:ss"), judge, "INITAL", "");
                        foreach (DataColumn dc in dt.Columns)
                        {
                            inspect = dc.ColumnName.Replace(" ", string.Empty);
                            if (gData.CheckInspect(inspect))
                            {
                                inspectdata = dr[dc.ColumnName].ToString();
                                if (inspectdata == "-" || !isDouble(inspectdata))
                                    continue;
                                multiinspect.Append("('").Append(serno).Append("','").Append(lot).Append("','");
                                multiinspect.Append(inspectdate.ToString("yyyy-MM-dd HH:mm:ss")).Append("','");
                                multiinspect.Append(inspect).Append("','").Append(inspectdata).Append("','");
                                multiinspect.Append(judge).Append("'), ");
                                //gData.InsertTableData(table, serno, lot, inspectdate.ToString("yyyy-MM-dd HH:mm:ss"), inspect, inspectdata, judge);
                            }
                        }
                    }
                    multiinspect.Remove(multiinspect.Length - 2, 1);
                    mutliprocess.Remove(mutliprocess.Length - 2, 1);
                    if (!gData.InsertTableData(table, multiinspect.ToString()) && !gData.InsertTable(table, mutliprocess.ToString()))
                    {
                        if (!Directory.Exists(errorfolder))
                            Directory.CreateDirectory(errorfolder);
                        File.WriteAllLines(errorfolder + "\\" + Path.GetFileName(item), errorlist);
                    }
                    if (!Directory.Exists(tempfolder))
                        Directory.CreateDirectory(tempfolder);
                    File.Move(item, tempfolder + "\\" + Path.GetFileName(item));
                }
            }
            catch { }
        }

        private bool isDouble(string text)
        {
            try
            {
                double.Parse(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string item in lsbAllFileCSV.Items)
                {
                    model = Path.GetFileName(item).Split('_')[1];
                    model = model.Replace('-', '_');
                    date = Path.GetFileName(item).Split('_')[2].Split('-')[0]
                         + Path.GetFileName(item).Split('_')[2].Split('-')[1];
                    table = model + date;
                    gData.CreateTable(table);
                    gData.CreateTableData(table);
                }
            }
            catch { }
        }
    }
}
