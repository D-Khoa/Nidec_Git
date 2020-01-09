using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TrackingPQMData.Controller;
using TrackingPQMData.Model;

namespace TrackingPQMData.View
{
    public partial class MainForm : FormCommon
    {
        #region VARIABLE
        double ctimer;
        int counter, maxchoose = 6;
        string SelectModel, ModelTable, FromTime, ToTime, setfile = "setting.ini";
        Task[] tasks = new Task[6];
        GetSQLData getSQLData = new GetSQLData();
        List<int> listProcessIndex = new List<int>();
        List<string> settinglist = new List<string>();
        List<string> listProcess = new List<string>();
        List<string> listInspect = new List<string>();
        List<string> listInspect1 = new List<string>();
        List<string> listInspect2 = new List<string>();
        List<string> listInspect3 = new List<string>();
        List<string> listInspect4 = new List<string>();
        List<string> listInspect5 = new List<string>();
        List<string> listInspect6 = new List<string>();
        BindingList<DataPointItem> itemAOI1 = new BindingList<DataPointItem>();
        BindingList<DataPointItem> itemAOI2 = new BindingList<DataPointItem>();
        BindingList<DataPointItem> itemAOI3 = new BindingList<DataPointItem>();
        BindingList<DataPointItem> itemAOI4 = new BindingList<DataPointItem>();
        BindingList<DataPointItem> itemAOI5 = new BindingList<DataPointItem>();
        BindingList<DataPointItem> itemAOI6 = new BindingList<DataPointItem>();
        #endregion

        public MainForm()
        {
            InitializeComponent();
            grt_Main.ItemSize = new Size(0, 1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Get list model into combobox
            cmbModel.DataSource = getSQLData.GetModelList();
            cmbModel.DisplayMember = "model";
            cmbModel.Text = null;
            //Load setting file
            if (File.Exists(setfile))
            {
                foreach (string line in File.ReadLines(setfile))
                {
                    if (line.Contains("Model")) cmbModel.Text = line.Split('=')[1];
                    if (line.Contains("Counter")) numTimer.Value = decimal.Parse(line.Split('=')[1]);
                    if (line.Contains("Process")) settinglist.Add(line.Split('=')[1]);
                    if (line.Contains("Inspect")) listInspect.Add(line.Split('=')[1]);
                }
            }
        }

        #region UPDATE MODEL, PROCESS AND INSPECT
        private void cmbModel_TextChanged(object sender, EventArgs e)
        {
            //Check combobox model is null?
            if (cmbModel.Text != null)
            {
                //Change select model
                SelectModel = cmbModel.Text;
                trvProcess.Nodes.Clear();
                TreeViewAddRoot();
            }
            //Check process
            if (settinglist.Count > 0)
            {
                foreach (TreeNode root in trvProcess.Nodes)
                {
                    if (settinglist.Contains(root.Text)) root.Checked = true;
                    foreach (TreeNode node in root.Nodes)
                        if (listInspect.Contains(node.Text)) node.Checked = true;
                }
                settinglist.Clear();
            }
        }

        /// <summary>
        /// Add root(process) into treeview
        /// </summary>
        private void TreeViewAddRoot()
        {
            //Get list process of select model
            listProcess = getSQLData.GetProcessList(SelectModel);
            //Add list process into treeview
            foreach (string process in listProcess)
            {
                TreeNode root = new TreeNode(process);
                trvProcess.Nodes.Add(root);
                TreeViewAddNode(root);
            }
        }

        /// <summary>
        /// Add node(inspect) into treeview
        /// </summary>
        /// <param name="root"></param>
        private void TreeViewAddNode(TreeNode root)
        {
            //Get list inspect of process
            listInspect = getSQLData.GetInspectList(SelectModel, root.Text);
            //Add list inspect into root
            foreach (string inspect in listInspect)
            {
                TreeNode node = new TreeNode(inspect);
                root.Nodes.Add(node);
            }
        }

        private void trvProcess_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //Get index of nodes is checked
            GetListProcessIndex();
            //If number of checked node > max nodes
            if (listProcessIndex.Count > maxchoose)
            {
                listProcessIndex.Remove(listProcessIndex[maxchoose]);
                e.Node.Checked = false;
            }
            //Check node and child node
            CheckNode(e.Node, e.Node.Checked);
        }

        /// <summary>
        /// Check node follow root checked
        /// </summary>
        /// <param name="root"></param>
        /// <param name="check"></param>
        private void CheckNode(TreeNode root, bool check)
        {
            foreach (TreeNode node in root.Nodes)
            {
                node.Checked = check;
                if (node.Nodes.Count > 0)
                    CheckNode(node, node.Checked);
            }
        }

        /// <summary>
        /// Get process index in treeview
        /// </summary>
        private void GetListProcessIndex()
        {
            listProcessIndex.Clear();
            listProcessIndex = trvProcess.Nodes.OfType<TreeNode>()
                                                .Where(x => x.Checked)
                                                .Select(x => x.Index).ToList();
        }

        /// <summary>
        /// Get inspect choose list
        /// </summary>
        /// <param name="process"></param>
        private List<string> GetListInspectChoose(int process)
        {
            return trvProcess.Nodes[process].Nodes.OfType<TreeNode>()
                                                  .Where(x => x.Checked)
                                                  .Select(x => x.Text).ToList();
        }

        /// <summary>
        /// Get name of data table and time begin, time end
        /// </summary>
        private void GetTableName()
        {
            ModelTable = SelectModel + dtpDate.Value.ToString("yyyyMM") + "data";
            FromTime = dtpDate.Value.ToString("yyyy-MM-dd") + " " + dtpBegin.Value.ToString("HH:mm");
            ToTime = dtpDate.Value.ToString("yyyy-MM-dd") + " " + dtpEnd.Value.ToString("HH:mm");
        }
        #endregion

        #region CHANGE TAB
        private void OpenChart(object sender, EventArgs e)
        {
            DrawChart("AOI1", listInspect1, itemAOI1);
            DrawChart("AOI2", listInspect2, itemAOI2);
            DrawChart("AOI3", listInspect3, itemAOI3);
            DrawChart("AOI4", listInspect4, itemAOI4);
            DrawChart("AOI5", listInspect5, itemAOI5);
            DrawChart("AOI6", listInspect6, itemAOI6);
            //Select Chart tab
            grt_Main.SelectedTab = tab_Chart;
        }

        private void OpenMainMenu(object sender, EventArgs e)
        {
            //Go back main tab
            grt_Main.SelectedTab = tab_Main;
        }

        #region GO DATA TAB WITH BUTTON DATA
        private void btnAOI1_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = itemAOI1;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
            dgvAOI1.Refresh();
        }

        private void btnAOI2_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = itemAOI2;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
            dgvAOI1.Refresh();
        }

        private void btnAOI3_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = itemAOI3;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
            dgvAOI1.Refresh();
        }

        private void btnAOI4_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = itemAOI4;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
            dgvAOI1.Refresh();
        }

        private void btnAOI5_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = itemAOI5;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
            dgvAOI1.Refresh();
        }

        private void btnAOI6_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = itemAOI6;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
            dgvAOI1.Refresh();
        }
        #endregion
        #endregion

        #region TRACKING DATA
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Set counter
            counter = (int)numTimer.Value;
            //When couting, not allow edit setting
            if (!bwTimer.IsBusy)
            {
                bwTimer.RunWorkerAsync();
                btnStop.Enabled = true;
                btnStop2.Enabled = true;
                btnStart.Enabled = false;
                btnStart2.Enabled = false;
                pnlSetting.Enabled = false;
                GetTableName();
                GetAllListInspect();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //Stop count and alow edit setting
            if (bwTimer.IsBusy)
            {
                bwTimer.CancelAsync();
                btnStart.Enabled = true;
                btnStart2.Enabled = true;
                btnStop.Enabled = false;
                btnStop2.Enabled = false;
                pnlSetting.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //When counting, not allow close form
            if (btnStop.Enabled || btnStop2.Enabled)
            {
                e.Cancel = true;
                return;
            }
            //Save setting file
            if (!File.Exists(setfile))
                File.Create(setfile);
            settinglist.Clear();
            settinglist.Add("Model=" + cmbModel.Text);
            settinglist.Add("Counter=" + numTimer.Value.ToString());
            foreach (TreeNode root in trvProcess.Nodes)
            {
                if (root.Checked)
                {
                    settinglist.Add("Process=" + root.Text);
                    foreach (TreeNode node in root.Nodes)
                    {
                        if (node.Checked) settinglist.Add("Inspect=" + node.Text);
                    }
                }
            }
            File.WriteAllLines(setfile, settinglist);
        }

        /// <summary>
        /// Count Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = counter; i >= 0; i--)
            {
                //Report timer
                bwTimer.ReportProgress(i);
                //If cancel
                if (bwTimer.CancellationPending)
                {
                    e.Cancel = true;
                    bwTimer.ReportProgress(counter);
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Show counter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwTimer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsTimerCounter.Text = e.ProgressPercentage.ToString();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        /// When complete counter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void bwTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                tsTimerCounter.Text = "Stop";
            }
            else if (e.Error != null)
            {
                tsTimerCounter.Text = e.Error.Message;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                #region TASK START
                ctimer = 0;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                tasks[0] = GetDataAOI1();
                tasks[1] = GetDataAOI2();
                tasks[2] = GetDataAOI3();
                tasks[3] = GetDataAOI4();
                tasks[4] = GetDataAOI5();
                tasks[5] = GetDataAOI6();
                await Task.WhenAll(tasks);
                foreach (Task t in tasks) t.Dispose();
                #endregion
                stopwatch.Stop();
                ctimer = stopwatch.ElapsedMilliseconds;
                tsStopwatch.Text = (ctimer / 1000).ToString("0.00") + " s";
                this.Cursor = Cursors.Default;
                bwTimer.RunWorkerAsync();
            }
        }
        #endregion

        #region ACTON GET DATA FROM AOI1 TO AOI6
        /// <summary>
        /// Get all list inspect of all process
        /// </summary>
        private void GetAllListInspect()
        {
            if (listProcessIndex.Count > 0)
            {
                listInspect1.Clear();
                listInspect1 = GetListInspectChoose(listProcessIndex[0]);
            }
            if (listProcessIndex.Count > 1)
            {
                listInspect2.Clear();
                listInspect2 = GetListInspectChoose(listProcessIndex[1]);
            }
            if (listProcessIndex.Count > 2)
            {
                listInspect3.Clear();
                listInspect3 = GetListInspectChoose(listProcessIndex[2]);
            }
            if (listProcessIndex.Count > 3)
            {
                listInspect4.Clear();
                listInspect4 = GetListInspectChoose(listProcessIndex[3]);
            }
            if (listProcessIndex.Count > 4)
            {
                listInspect5.Clear();
                listInspect5 = GetListInspectChoose(listProcessIndex[4]);
            }
            if (listProcessIndex.Count > 5)
            {
                listInspect6.Clear();
                listInspect6 = GetListInspectChoose(listProcessIndex[5]);
            }
        }

        private async Task GetDataAOI1()
        {
            itemAOI1.Clear();
            itemAOI1 = await getSQLData.InspectPointList(listInspect1, ModelTable, FromTime, ToTime);
        }

        private async Task GetDataAOI2()
        {
            itemAOI2.Clear();
            itemAOI2 = await getSQLData.InspectPointList(listInspect2, ModelTable, FromTime, ToTime);
        }

        private async Task GetDataAOI3()
        {
            itemAOI3.Clear();
            itemAOI3 = await getSQLData.InspectPointList(listInspect3, ModelTable, FromTime, ToTime);
        }

        private async Task GetDataAOI4()
        {
            itemAOI4.Clear();
            itemAOI4 = await getSQLData.InspectPointList(listInspect4, ModelTable, FromTime, ToTime);
        }

        private async Task GetDataAOI5()
        {
            itemAOI5.Clear();
            itemAOI5 = await getSQLData.InspectPointList(listInspect5, ModelTable, FromTime, ToTime);
        }

        private async Task GetDataAOI6()
        {
            itemAOI6.Clear();
            itemAOI6 = await getSQLData.InspectPointList(listInspect6, ModelTable, FromTime, ToTime);
        }
        #endregion

        #region DRAW CHART
        private void DrawChart(string name, List<string> list, BindingList<DataPointItem> dtlist)
        {
            //Exit if list empty
            if (list.Count == 0)
            {
                return;
            }
            //With each member in list
            foreach (string inspect in list)
            {
                double minvalue = findMin(dtlist, inspect);
                double maxvalue = findMax(dtlist, inspect);
                double value20 = (maxvalue - minvalue) * 0.2;
                //Create a new chart
                Chart datachart = new Chart();
                //Create USL line
                StripLine maxline = new StripLine();
                maxline.Interval = 0;
                maxline.IntervalOffset = maxvalue;
                maxline.BorderWidth = 1;
                maxline.Text = "USL";
                maxline.TextLineAlignment = StringAlignment.Far;
                maxline.BorderColor = Color.Red;
                //Create LSL line
                StripLine minline = new StripLine();
                minline.Interval = 0;
                minline.IntervalOffset = minvalue;
                minline.BorderWidth = 1;
                minline.Text = "LSL";
                minline.TextLineAlignment = StringAlignment.Far;
                minline.BorderColor = Color.Red;
                //Create 80% USL line
                StripLine max80line = new StripLine();
                max80line.Interval = 0;
                max80line.IntervalOffset = maxvalue - value20;
                max80line.BorderDashStyle = ChartDashStyle.Dash;
                max80line.BorderWidth = 1;
                max80line.Text = "80% USL";
                max80line.TextLineAlignment = StringAlignment.Far;
                max80line.BorderColor = Color.Red;
                //Create 80% LSL line
                StripLine min80line = new StripLine();
                min80line.Interval = 0;
                min80line.IntervalOffset = minvalue + value20;
                min80line.BorderDashStyle = ChartDashStyle.Dash;
                min80line.BorderWidth = 1;
                min80line.Text = "80% LSL";
                min80line.TextLineAlignment = StringAlignment.Far;
                min80line.BorderColor = Color.Red;
                //Create a new chart area
                ChartArea area = new ChartArea();
                area.AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
                area.AxisX.Interval = 1;
                area.AxisX.IntervalType = DateTimeIntervalType.Auto;
                area.AxisY.Minimum = minvalue - value20;
                area.AxisY.Maximum = maxvalue + value20;
                area.AxisY.StripLines.Add(maxline);
                area.AxisY.StripLines.Add(minline);
                area.AxisY.StripLines.Add(max80line);
                area.AxisY.StripLines.Add(min80line);
                //Create a new title
                Title title = new Title("tlt" + inspect);
                title.Text = name + "-" + inspect;
                datachart.Name = name + inspect;
                datachart.Titles.Add(title);
                datachart.Size = new Size(1200, 200);
                //Create a new series
                Series s1 = new Series
                {
                    Name = inspect,
                    Color = Color.Blue,
                    IsVisibleInLegend = false,
                    IsXValueIndexed = true,
                    ChartType = SeriesChartType.Point,
                    XValueType = ChartValueType.DateTime
                };
                foreach (DataPointItem item in dtlist)
                {
                    if (item.inspect == inspect)
                    {
                        s1.Points.AddXY(item.inspectdate.ToOADate(), item.inspectdata);
                    }
                }

                if (!grt_Main.TabPages["tab_Chart"].Controls["flp_Chart"].Controls.Contains(datachart))
                    grt_Main.TabPages["tab_Chart"].Controls["flp_Chart"].Controls.Add(datachart);
                datachart.Series.Clear();
                datachart.ChartAreas.Add(area);
                datachart.Series.Add(s1);
            }
        }

        /// <summary>
        /// Find LSL of inspect
        /// </summary>
        /// <param name="dtlist"></param>
        /// <param name="inspect"></param>
        /// <returns></returns>
        private double findMin(BindingList<DataPointItem> dtlist, string inspect)
        {
            int n = dtlist.Count;
            double min = 100;
            for (int i = 0; i < n; i++)
            {
                if (dtlist[i].inspect == inspect && dtlist[i].inspectdata < min)
                    min = dtlist[i].inspectdata;
            }
            return min;
        }

        /// <summary>
        /// Find USL of inspect
        /// </summary>
        /// <param name="dtlist"></param>
        /// <param name="inspect"></param>
        /// <returns></returns>
        private double findMax(BindingList<DataPointItem> dtlist, string inspect)
        {
            int n = dtlist.Count;
            double max = 0;
            for (int i = 0; i < n; i++)
            {
                if (dtlist[i].inspect == inspect && dtlist[i].inspectdata > max)
                    max = dtlist[i].inspectdata;
            }
            return max;
        }
        #endregion
    }


}
