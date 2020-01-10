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
        int counter, maxchoose = 6, wchart = 1300, hchart = 250;
        string SelectModel, ModelTable, FromTime, ToTime, setfile = @"C:\TrackingPQMData\setting.ini";
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

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            tsRes.Text = flp_Chart.Width + "x" + flp_Chart.Height;
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
                trvProcess.Visible = true;
            }
        }

        private void trvProcess_VisibleChanged(object sender, EventArgs e)
        {
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
            //Not run if no process checked
            if (listProcessIndex.Count == 0 || listProcessIndex == null)
            {
                MessageBox.Show("Please choose process and inspect before run!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Set counter
            counter = (int)numTimer.Value * 60;
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
            settinglist.Clear();
            settinglist.Add("Model=" + cmbModel.Text + Environment.NewLine);
            settinglist.Add("Counter=" + numTimer.Value.ToString() + Environment.NewLine);
            foreach (TreeNode root in trvProcess.Nodes)
            {
                if (root.Checked)
                {
                    settinglist.Add("Process=" + root.Text + Environment.NewLine);
                    foreach (TreeNode node in root.Nodes)
                    {
                        if (node.Checked) settinglist.Add("Inspect=" + node.Text + Environment.NewLine);
                    }
                }
            }
            if (!Directory.Exists(@"C:\TrackingPQMData\"))
                Directory.CreateDirectory(@"C:\TrackingPQMData\");
            //Save setting file
            if (File.Exists(setfile))
                File.Delete(setfile);
            using (FileStream fs = File.Create(setfile))
            {
                foreach (string line in settinglist)
                {
                    byte[] setdata = new UTF8Encoding(true).GetBytes(line);
                    fs.Write(setdata, 0, setdata.Length);
                }
                fs.Flush();
                fs.Close();
            }
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
            //if(e.ProgressPercentage == (int)numAutoScroll.Value)
            //{
            //    flp_Chart.VerticalScroll.Value = flp_Chart.VerticalScroll.Minimum;
            //    timerScroll.Enabled = true;
            //}
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
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    pnlButtonMain.Enabled = false;
                    pnlButtonChart.Enabled = false;
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
                    //Draw chart
                    DrawChart("AOI1", listInspect1, itemAOI1);
                    DrawChart("AOI2", listInspect2, itemAOI2);
                    DrawChart("AOI3", listInspect3, itemAOI3);
                    DrawChart("AOI4", listInspect4, itemAOI4);
                    DrawChart("AOI5", listInspect5, itemAOI5);
                    DrawChart("AOI6", listInspect6, itemAOI6);
                    flp_Chart.Refresh();
                    stopwatch.Stop();
                    pnlButtonMain.Enabled = true;
                    pnlButtonChart.Enabled = true;
                    ctimer = stopwatch.ElapsedMilliseconds;
                    tsStopwatch.Text = (ctimer / 1000).ToString("0.00") + " s";
                    this.Cursor = Cursors.Default;
                    bwTimer.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region ACTON GET DATA FROM AOI1 TO AOI6
        /// <summary>
        /// Get all list inspect of all process
        /// </summary>
        private void GetAllListInspect()
        {
            listInspect1.Clear();
            listInspect2.Clear();
            listInspect3.Clear();
            listInspect4.Clear();
            listInspect5.Clear();
            listInspect6.Clear();
            if (listProcessIndex.Count > 0)
            {
                listInspect1 = GetListInspectChoose(listProcessIndex[0]);
            }
            if (listProcessIndex.Count > 1)
            {
                listInspect2 = GetListInspectChoose(listProcessIndex[1]);
            }
            if (listProcessIndex.Count > 2)
            {
                listInspect3 = GetListInspectChoose(listProcessIndex[2]);
            }
            if (listProcessIndex.Count > 3)
            {
                listInspect4 = GetListInspectChoose(listProcessIndex[3]);
            }
            if (listProcessIndex.Count > 4)
            {
                listInspect5 = GetListInspectChoose(listProcessIndex[4]);
            }
            if (listProcessIndex.Count > 5)
            {
                listInspect6 = GetListInspectChoose(listProcessIndex[5]);
            }
        }

        private async Task GetDataAOI1()
        {
            if (listInspect1 == null)
                await Task.Delay(0);
            itemAOI1.Clear();
            itemAOI1 = await getSQLData.InspectPointList(listInspect1, ModelTable, FromTime, ToTime);
        }

        private async Task GetDataAOI2()
        {
            if (listInspect2 == null || listInspect2.Count == 0)
            {
                await Task.Delay(0);
                return;
            }
            itemAOI2.Clear();
            itemAOI2 = await getSQLData.InspectPointList(listInspect2, ModelTable, FromTime, ToTime);
        }

        private async Task GetDataAOI3()
        {
            if (listInspect3 == null || listInspect3.Count == 0)
            {
                await Task.Delay(0);
                return;
            }
            itemAOI3.Clear();
            itemAOI3 = await getSQLData.InspectPointList(listInspect3, ModelTable, FromTime, ToTime);
        }

        private async Task GetDataAOI4()
        {
            if (listInspect4 == null || listInspect4.Count == 0)
            {
                await Task.Delay(0);
                return;
            }
            itemAOI4.Clear();
            itemAOI4 = await getSQLData.InspectPointList(listInspect4, ModelTable, FromTime, ToTime);
        }

        private async Task GetDataAOI5()
        {
            if (listInspect5 == null || listInspect5.Count == 0)
            {
                await Task.Delay(0);
                return;
            }
            itemAOI5.Clear();
            itemAOI5 = await getSQLData.InspectPointList(listInspect5, ModelTable, FromTime, ToTime);
        }

        private async Task GetDataAOI6()
        {
            if (listInspect6 == null || listInspect6.Count == 0)
            {
                await Task.Delay(0);
                return;
            }
            itemAOI6.Clear();
            itemAOI6 = await getSQLData.InspectPointList(listInspect6, ModelTable, FromTime, ToTime);
        }
        #endregion

        #region DRAW CHART
        private void DrawChart(string name, List<string> list, BindingList<DataPointItem> dtlist)
        {
            //Exit if list empty
            if (list.Count == 0 || list == null)
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
                maxline.BorderColor = Color.Red;
                maxline.Text = "USL";
                maxline.TextLineAlignment = StringAlignment.Far;
                //Create LSL line
                StripLine minline = new StripLine();
                minline.Interval = 0;
                minline.IntervalOffset = minvalue;
                minline.BorderWidth = 1;
                minline.BorderColor = Color.Red;
                minline.Text = "LSL";
                minline.TextLineAlignment = StringAlignment.Far;
                //Create 80% USL line
                StripLine max80line = new StripLine();
                max80line.Interval = 0;
                max80line.IntervalOffset = maxvalue - value20;
                max80line.BorderWidth = 1;
                max80line.BorderColor = Color.Red;
                max80line.BorderDashStyle = ChartDashStyle.Dash;
                max80line.Text = "80% USL";
                max80line.TextLineAlignment = StringAlignment.Far;
                //Create 80% LSL line
                StripLine min80line = new StripLine();
                min80line.Interval = 0;
                min80line.IntervalOffset = minvalue + value20;
                min80line.BorderWidth = 1;
                min80line.BorderColor = Color.Red;
                min80line.BorderDashStyle = ChartDashStyle.Dash;
                min80line.Text = "80% LSL";
                min80line.TextLineAlignment = StringAlignment.Far;
                //Create a new chart area
                ChartArea area = new ChartArea();
                area.AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
                area.AxisX.Interval = 1;
                area.AxisX.IntervalType = DateTimeIntervalType.Hours;
                area.AxisX.IntervalType = DateTimeIntervalType.Hours;
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
                datachart.Size = new Size(wchart, hchart);
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
                datachart.ChartAreas.Clear();
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

        private void btnAutoScroll_Click(object sender, EventArgs e)
        {
            if (timerScroll.Enabled)
            {
                btnAutoScroll.Text = "Auto Scroll";
                timerScroll.Enabled = false;
                btnSpUp.Visible = false;
                btnSpDown.Visible = false;
            }
            else
            {
                btnAutoScroll.Text = "Stop Srcoll";
                //Scroll flow panel with timer
                flp_Chart.VerticalScroll.Value = flp_Chart.VerticalScroll.Minimum;
                timerScroll.Enabled = true;
                btnSpUp.Visible = true;
                btnSpDown.Visible = true;
            }
        }

        private void btnSpUp_Click(object sender, EventArgs e)
        {
            if (timerScroll.Interval > 10)
                timerScroll.Interval -= 10;
            else
                timerScroll.Interval = 5;
        }

        private void btnSpDown_Click(object sender, EventArgs e)
        {
            if (timerScroll.Interval < 10000)
                timerScroll.Interval += 10;
        }

        private void timerScroll_Tick(object sender, EventArgs e)
        {
            flp_Chart.VerticalScroll.Value++;
            if (flp_Chart.VerticalScroll.Value == flp_Chart.VerticalScroll.Maximum)
                timerScroll.Enabled = false;
        }
        #endregion
    }


}
