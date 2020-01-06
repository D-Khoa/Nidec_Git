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
using TrackingPQMData.Controller;

namespace TrackingPQMData.View
{
    public partial class MainForm : FormCommon
    {
        #region VARIABLE
        int counter, ctimer, maxchoose = 6;
        string SelectModel, ModelTable, FromTime, ToTime;
        GetSQLData getSQLData = new GetSQLData();
        List<int> listProcessIndex = new List<int>();
        List<string> listProcess = new List<string>();
        List<string> listInspect = new List<string>();
        DataTable dtAOI1 = new DataTable();
        DataTable dtAOI2 = new DataTable();
        DataTable dtAOI3 = new DataTable();
        DataTable dtAOI4 = new DataTable();
        DataTable dtAOI5 = new DataTable();
        DataTable dtAOI6 = new DataTable();
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
        #endregion

        /// <summary>
        /// Get name of data table and time begin, time end
        /// </summary>
        private void GetTableName()
        {
            ModelTable = SelectModel + dtpDate.Value.ToString("yyyyMM") + "data";
            FromTime = dtpDate.Value.ToString("yyyy-MM-dd") + " " + dtpBegin.Value.ToString("HH:mm");
            ToTime = dtpDate.Value.ToString("yyyy-MM-dd") + " " + dtpEnd.Value.ToString("HH:mm");
        }

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
            dgvAOI1.DataSource = dtAOI1;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }

        private void btnAOI2_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = dtAOI2;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }

        private void btnAOI3_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = dtAOI3;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }

        private void btnAOI4_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = dtAOI4;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }

        private void btnAOI5_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = dtAOI5;
            grt_Main.SelectedTab = tab_AOI;
            tsDataRows.Text = dgvAOI1.Rows.Count.ToString();
        }

        private void btnAOI6_Click(object sender, EventArgs e)
        {
            dgvAOI1.DataSource = dtAOI6;
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
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (bwTimer.IsBusy)
                bwTimer.CancelAsync();
        }

        /// <summary>
        /// Count Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = counter; i > 0; i--)
            {
                //Report timer
                bwTimer.ReportProgress(i);
                //If cancel
                if (bwTimer.CancellationPending)
                {
                    e.Cancel = true;
                    bwTimer.ReportProgress(counter);
                }
                Thread.Sleep(1000);
            }
            bwTimer.ReportProgress(0);
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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                GetTableName();
                var t1 = Task.Run(() => GetDataAOI1());
                var t2 = Task.Run(() => GetDataAOI2());
                var t3 = Task.Run(() => GetDataAOI3());
                var t4 = Task.Run(() => GetDataAOI4());
                var t5 = Task.Run(() => GetDataAOI5());
                var t6 = Task.Run(() => GetDataAOI6());

                Task.WaitAll(t1, t2, t3, t4, t5, t6);
                #endregion
                stopwatch.Stop();
                tsStopwatch.Text = stopwatch.Elapsed.Seconds.ToString() + " s";
                bwTimer.RunWorkerAsync();
                this.Cursor = Cursors.Default;
            }
        }

        private void timerGetData_Tick(object sender, EventArgs e)
        {
            ctimer++;
            tsTimerCounter.Text = ctimer + " s";
        }
        #endregion

        #region GET DATA AOI INTO DATATABLE
        private void GetDataAOI1()
        {
            dtAOI1 = new DataTable();
            List<string> list = new List<string>();
            list = GetListInspectChoose(listProcessIndex[0]);
            dtAOI1 = getSQLData.ProcessDatatable(list, ModelTable, FromTime, ToTime);
        }

        private void GetDataAOI2()
        {
            dtAOI2 = new DataTable();
            List<string> list = new List<string>();
            list = GetListInspectChoose(listProcessIndex[1]);
            dtAOI2 = getSQLData.ProcessDatatable(list, ModelTable, FromTime, ToTime);
        }

        private void GetDataAOI3()
        {
            dtAOI3 = new DataTable();
            List<string> list = new List<string>();
            list = GetListInspectChoose(listProcessIndex[2]);
            dtAOI3 = getSQLData.ProcessDatatable(list, ModelTable, FromTime, ToTime);
        }

        private void GetDataAOI4()
        {
            dtAOI4 = new DataTable();
            List<string> list = new List<string>();
            list = GetListInspectChoose(listProcessIndex[3]);
            dtAOI4 = getSQLData.ProcessDatatable(list, ModelTable, FromTime, ToTime);
        }

        private void GetDataAOI5()
        {
            dtAOI5 = new DataTable();
            List<string> list = new List<string>();
            list = GetListInspectChoose(listProcessIndex[4]);
            dtAOI5 = getSQLData.ProcessDatatable(list, ModelTable, FromTime, ToTime);
        }

        private void GetDataAOI6()
        {
            dtAOI6 = new DataTable();
            List<string> list = new List<string>();
            list = GetListInspectChoose(listProcessIndex[5]);
            dtAOI6 = getSQLData.ProcessDatatable(list, ModelTable, FromTime, ToTime);
        }
        #endregion
    }
}
