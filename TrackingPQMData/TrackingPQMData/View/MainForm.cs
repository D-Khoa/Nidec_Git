using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        int counter, maxchoose = 6;
        double ctimer;
        string SelectModel, ModelTable, FromTime, ToTime;
        Task[] tasks = new Task[6];
        Stopwatch stopwatch = new Stopwatch();
        GetSQLData getSQLData = new GetSQLData();
        List<int> listProcessIndex = new List<int>();
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
            //Check node
            GetListProcessIndex();
            if (listProcessIndex.Count > maxchoose)
            {
                listProcessIndex.Remove(listProcessIndex[maxchoose]);
                e.Node.Checked = false;
            }
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
        /// <summary>
        /// Goto Chart tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenChart(object sender, EventArgs e)
        {
            grt_Main.SelectedTab = tab_Chart;
        }

        /// <summary>
        /// Return Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMainMenu(object sender, EventArgs e)
        {
            grt_Main.SelectedTab = tab_Main;
        }

        private void btnAOI1_Click(object sender, EventArgs e)
        {
            //dgvAOI1.DataSource = dtAOI1;
            dgvAOI1.DataSource = itemAOI1;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }

        private void btnAOI2_Click(object sender, EventArgs e)
        {
            //dgvAOI1.DataSource = dtAOI2;
            dgvAOI1.DataSource = itemAOI2;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }

        private void btnAOI3_Click(object sender, EventArgs e)
        {
            //dgvAOI1.DataSource = dtAOI3;
            dgvAOI1.DataSource = itemAOI3;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }

        private void btnAOI4_Click(object sender, EventArgs e)
        {
            //dgvAOI1.DataSource = dtAOI4;
            dgvAOI1.DataSource = itemAOI4;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }

        private void btnAOI5_Click(object sender, EventArgs e)
        {
            //dgvAOI1.DataSource = dtAOI5;
            dgvAOI1.DataSource = itemAOI5;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }

        private void btnAOI6_Click(object sender, EventArgs e)
        {
            //dgvAOI1.DataSource = dtAOI6;
            dgvAOI1.DataSource = itemAOI6;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }
        #endregion

        #region TRACKING DATA
        private void btnStart_Click(object sender, EventArgs e)
        {
            counter = (int)numTimer.Value;
            if (!bwTimer.IsBusy)
                bwTimer.RunWorkerAsync();
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            pnlSetting.Enabled = false;
            GetTableName();
            GetAllListInspect();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (bwTimer.IsBusy)
            {
                bwTimer.CancelAsync();
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                pnlSetting.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnStop.Enabled)
                e.Cancel = true;
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
                    return;
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
        }

        /// <summary>
        /// When complete counter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                //stopwatch.Restart();
                //t1 = Task.Run(() => GetDataAOI1());
                //t2 = Task.Run(() => GetDataAOI2());
                //t3 = Task.Run(() => GetDataAOI3());
                //t4 = Task.Run(() => GetDataAOI4());
                //t5 = Task.Run(() => GetDataAOI5());
                //t6 = Task.Run(() => GetDataAOI6());
                //await Task.WhenAll(t1, t2, t3, t4, t5, t6);
                tasks[0] = Task.Run(() => GetDataAOI1());
                tasks[1] = Task.Run(() => GetDataAOI2());
                tasks[2] = Task.Run(() => GetDataAOI3());
                tasks[3] = Task.Run(() => GetDataAOI4());
                tasks[4] = Task.Run(() => GetDataAOI5());
                tasks[5] = Task.Run(() => GetDataAOI6());
                Task.WaitAll(tasks);
                foreach (Task t in tasks) t.Dispose();
                #endregion
                DrawChart("AOI1", listInspect1, itemAOI1);
                DrawChart("AOI2", listInspect2, itemAOI2);
                DrawChart("AOI3", listInspect3, itemAOI3);
                DrawChart("AOI4", listInspect4, itemAOI4);
                DrawChart("AOI5", listInspect5, itemAOI5);
                DrawChart("AOI6", listInspect6, itemAOI6);
                stopwatch.Stop();
                ctimer = stopwatch.Elapsed.Milliseconds;
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
            if (listProcessIndex.Count > 1)
            {
                listInspect1 = new List<string>();
                listInspect1 = GetListInspectChoose(listProcessIndex[0]);
            }
            if (listProcessIndex.Count > 2)
            {
                listInspect2 = new List<string>();
                listInspect2 = GetListInspectChoose(listProcessIndex[1]);
            }
            if (listProcessIndex.Count > 3)
            {
                listInspect3 = new List<string>();
                listInspect3 = GetListInspectChoose(listProcessIndex[2]);
            }
            if (listProcessIndex.Count > 4)
            {
                listInspect4 = new List<string>();
                listInspect4 = GetListInspectChoose(listProcessIndex[3]);
            }
            if (listProcessIndex.Count > 5)
            {
                listInspect5 = new List<string>();
                listInspect5 = GetListInspectChoose(listProcessIndex[4]);
            }
            if (listProcessIndex.Count > 6)
            {
                listInspect1 = new List<string>();
                listInspect6 = GetListInspectChoose(listProcessIndex[5]);
            }
        }

        private void GetDataAOI1()
        {
            itemAOI1 = new BindingList<DataPointItem>();
            itemAOI1 = getSQLData.InspectPointList(listInspect1, ModelTable, FromTime, ToTime);
        }

        private void GetDataAOI2()
        {
            itemAOI2 = new BindingList<DataPointItem>();
            itemAOI2 = getSQLData.InspectPointList(listInspect2, ModelTable, FromTime, ToTime);
        }

        private void GetDataAOI3()
        {
            itemAOI3 = new BindingList<DataPointItem>();
            itemAOI3 = getSQLData.InspectPointList(listInspect3, ModelTable, FromTime, ToTime);
        }

        private void GetDataAOI4()
        {
            itemAOI4 = new BindingList<DataPointItem>();
            itemAOI4 = getSQLData.InspectPointList(listInspect4, ModelTable, FromTime, ToTime);
        }

        private void GetDataAOI5()
        {
            itemAOI5 = new BindingList<DataPointItem>();
            itemAOI5 = getSQLData.InspectPointList(listInspect5, ModelTable, FromTime, ToTime);
        }

        private void GetDataAOI6()
        {
            itemAOI6 = new BindingList<DataPointItem>();
            itemAOI6 = getSQLData.InspectPointList(listInspect6, ModelTable, FromTime, ToTime);
        }
        #endregion

        #region DRAW CHART
        private void DrawChart(string name, List<string> list, BindingList<DataPointItem> dtlist)
        {
            if (list.Count == 0)
            {
                return;
            }
            foreach (string inspect in list)
            {
                Chart datachart = new Chart();
                ChartArea area = new ChartArea();
                Title title = new Title("tlt" + inspect);
                title.Text = name + "-" + inspect;
                datachart.Name = name + inspect;
                datachart.Titles.Add(title);
                datachart.Size = new Size(flp_Chart.Width, 300);
                Series s1 = new Series
                {
                    Name = inspect,
                    Color = Color.Blue,
                    IsVisibleInLegend = false,
                    IsXValueIndexed = true,
                    ChartType = SeriesChartType.Point,
                };
                foreach (DataPointItem item in dtlist)
                {
                    if (item.inspect == inspect)
                        s1.Points.AddXY(item.inspectdate.ToString("yyyy-MM-dd HH:mm:ss"), item.inspectdata);
                }
                if (!grt_Main.TabPages["tab_Chart"].Controls["flp_Chart"].Controls.Contains(datachart))
                    grt_Main.TabPages["tab_Chart"].Controls["flp_Chart"].Controls.Add(datachart);
                datachart.Series.Clear();
                datachart.ChartAreas.Add(area);
                datachart.Series.Add(s1);
            }
        }

        private double findMin(BindingList<DataPointItem> dtlist)
        {
            int n = dtlist.Count;
            double min = dtlist[0].inspectdata;
            for (int i = 1; ; i++)
            {
                if (dtlist[i].inspectdata < min)
                    min = dtlist[i].inspectdata;
                if (i == n)
                    break;
            }
            return min;
        }

        private double findMax(BindingList<DataPointItem> dtlist)
        {
            int n = dtlist.Count;
            double max = dtlist[0].inspectdata;
            for (int i = 1; ; i++)
            {
                if (dtlist[i].inspectdata > max)
                    max = dtlist[i].inspectdata;
                if (i == n)
                {
                    break;
                }
            }
            return max;
        }
        #endregion
    }
}
