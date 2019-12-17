﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.PQMDataViewerCbm;


namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class PQMDataViewerForm : FormCommonNCVP
    {
        #region Variables
        //CONNECT TO PQM DB
        public string connection = Properties.Settings.Default.PQM_CONNECTION_STRING;

        PQMDataViewerVo Vo = new PQMDataViewerVo();
        List<string> temp = new List<string>();

        //THREAD GET TABLE IN BACKGROUND
        Thread GetTable;
        #endregion

        #region Setup and load form (LOAD COMBOBOX MODEL)
        public PQMDataViewerForm()
        {
            InitializeComponent();
            Vo.JoinedTable = new DataTable();
            Vo.InspectList = new System.Text.StringBuilder();
            Vo.SernoList = new System.Text.StringBuilder();
            Vo.SernoDBList = new List<string>();
            Vo.ThreadComplete = false;
            Vo.CheckLot = false;
        }
        //****************************************************************************************************************//
        //                                            LOAD COMBOBOX MODEL                                                 //
        //****************************************************************************************************************//
        private void PQMDataViewerForm_Load(object sender, EventArgs e)
        {
            dtDatef.SetDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00));
            dtDatet.SetDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 00));
            ValueObjectList<PQMDataViewerVo> model = (ValueObjectList<PQMDataViewerVo>)DefaultCbmInvoker
                                                   .Invoke(new GetModelPQMCbm(), new PQMDataViewerVo(), connection);
            cmbModel.DisplayMember = "Model";
            cmbModel.DataSource = model.GetList();
            cmbModel.Text = null;
        }
        #endregion

        #region LOAD INSPECT TREEVIEW
        //****************************************************************************************************************//
        //                                            LOAD INSPECT TREEVIEW                                               //
        //****************************************************************************************************************//
        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            trInspect.Nodes.Clear();
            Vo.Model = cmbModel.Text;
            ValueObjectList<PQMDataViewerVo> process = (ValueObjectList<PQMDataViewerVo>)DefaultCbmInvoker
                .Invoke(new GetProcessPQMCbm(), new PQMDataViewerVo() { Model = cmbModel.Text }, connection);
            foreach (PQMDataViewerVo root in process.GetList())
            {
                TreeNode Root = new TreeNode(root.Process);
                trInspect.Nodes.Add(Root);
                GetNodes(Root);
            }
        }

        private void GetNodes(TreeNode root)
        {
            ValueObjectList<PQMDataViewerVo> inspect = (ValueObjectList<PQMDataViewerVo>)DefaultCbmInvoker
                .Invoke(new GetInspectPQMCbm(), new PQMDataViewerVo() { Process = root.Text }, connection);
            foreach (PQMDataViewerVo node in inspect.GetList())
            {
                root.Nodes.Add(node.Inspect);
            }
        }

        private void trInspect_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckedNode(e.Node, e.Node.Checked);
        }

        private void CheckedNode(TreeNode Root, bool Rootchecked)
        {
            foreach (TreeNode node in Root.Nodes)
            {
                if (node.Checked != Rootchecked) node.Checked = Rootchecked;
                if (Root.Nodes.Count > 0) CheckedNode(node, node.Checked);
            }
        }
        #endregion

        #region LOAD INSPECT LIST FOR SQL COMMAND
        //****************************************************************************************************************//
        //                                            LOAD INSPECT LIST                                                   //
        //****************************************************************************************************************//
        private void SelectedNode(TreeNodeCollection Root)
        {
            foreach (TreeNode node in Root)
            {
                if (node.Checked)
                    temp.Add(node.Text);
                if (node.Nodes.Count > 0)
                    SelectedNode(node.Nodes);
            }
        }

        private void GetInslist()
        {
            temp = temp.Distinct().ToList();
            foreach (string i in temp)
            {
                if (temp.IndexOf(i) == 0)
                    Vo.InspectList.Append("'" + i + "'");
                else
                    Vo.InspectList.Append(",'" + i + "'");
            }
        }
        #endregion

        #region LOAD SERIAL NUMBER LIST FOR SQL COMMAND
        //****************************************************************************************************************//
        //                                    LOAD SERIAL NO FROM TEXTBOX TO LIST                                         //
        //****************************************************************************************************************//
        private void GetSernoList()
        {
            if (txtBarcode.Lines.Length > 0)
            {
                Vo.SernoList.Append("'" + txtBarcode.Lines[0] + "'");
                foreach (string s in txtBarcode.Lines)
                    Vo.SernoList.Append(",'" + s + "'");
                tsSernoRows.Text = txtBarcode.Lines.Count().ToString() + " rows";
            }
        }
        #endregion

        #region LOAD SERIAL NUMBER FROM CSV FILE TO LIST
        //****************************************************************************************************************//
        //                                     LOAD SERIAL NO FROM CSV TO LIST                                            //
        //****************************************************************************************************************//
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            ofCSV = new OpenFileDialog();
            ofCSV.Title = "LOAD SERIAL NUMBER FROM CSV FILE";
            ofCSV.Filter = "csv file(*.csv)|*.csv|text file(*.txt)|*.txt|All file(*.*)|*.*";
            if (ofCSV.ShowDialog() == DialogResult.OK)
            {
                txtURL.Text = ofCSV.FileName;
                Vo.OpenPath = txtURL.Text;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vo.OpenPath.Length > 0)
                {
                    List<string> listserno = new List<string>();
                    string s_trim = "";
                    Vo.OpenPath.ReadCSVtoList(ref listserno);
                    Vo.SernoList.Append("'" + listserno[0] + "'");
                    listserno.RemoveAt(0);
                    foreach (string s in listserno)
                    {
                        s_trim = s.Trim('\n');
                        Vo.SernoList.Append(",'" + s_trim + "'");
                    }
                    tsSernoRows.Text = listserno.Count().ToString() + " rows";
                }
                else Vo.SernoList.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose serial number file before load this!");
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region GET DATA FROM SQL TO DATATABLE
        //****************************************************************************************************************//
        //                                            GET DATA TO TABLE                                                   //
        //****************************************************************************************************************//
        private void GetTableName()
        {
            string name = "";
            Vo.SernoDBList.Clear();
            for (int i = dtDatef.GetDateTime().Month; i <= dtDatet.GetDateTime().Month; i++)
            {
                name = Vo.Model + dtDatef.GetDateTime().Year.ToString("0000") + i.ToString("00");
                Vo.SernoDBList.Add(name);
            }
            Vo.DateTimeFrom = dtDatef.GetDateTime();
            Vo.DateTimeTo = dtDatet.GetDateTime();
        }

        private void GetDataToTable()
        {
            try
            {
                GetTableName();
                GetSernoList();
                GetInslist();
                Vo.SernoDataTable = new DataTable();
                Vo.InspectDataTable = new DataTable();
                PQMDataViewerVo inspectable = (PQMDataViewerVo)DefaultCbmInvoker
                    .Invoke(new GetInspectDataTablePQMCbm(), new PQMDataViewerVo()
                    {
                        PQMConnectionString = Vo.PQMConnectionString,
                        SernoDBList = Vo.SernoDBList,
                        InspectList = Vo.InspectList,
                        SernoList = Vo.SernoList,
                        DateTimeFrom = Vo.DateTimeFrom,
                        DateTimeTo = Vo.DateTimeTo,
                        CheckLot = Vo.CheckLot
                    }
                    , connection);
                PQMDataViewerVo sernotable = (PQMDataViewerVo)DefaultCbmInvoker
                    .Invoke(new GetSernoDataTablePQMCbm(), new PQMDataViewerVo()
                    {
                        PQMConnectionString = Vo.PQMConnectionString,
                        SernoDBList = Vo.SernoDBList,
                        SernoList = Vo.SernoList,
                        DateTimeFrom = Vo.DateTimeFrom,
                        DateTimeTo = Vo.DateTimeTo,
                        CheckLot = Vo.CheckLot
                    }
                    , connection);
                Vo.InspectDataTable = inspectable.InspectDataTable;
                Vo.SernoDataTable = sernotable.SernoDataTable;
                DataTable pivot = new DataTable();
                pivot = LinQ_Class.Pivot(Vo.InspectDataTable, Vo.InspectDataTable.Columns["inspect"]
                        , Vo.InspectDataTable.Columns["inspectdata"]);
                Vo.JoinedTable = LinQ_Class.Joined(Vo.SernoDataTable, pivot);
                pivot.Clear();
                Vo.ThreadComplete = true;
                GetTable.Abort();
            }
            catch (Framework.SystemException ex)
            {
                MessageBox.Show("Please select model and inspect before search data!");
                //MessageBox.Show(ex.GetMessageData().ToString());
            }
        }
        #endregion

        #region BUTTON CLICK TO SEARCH DATA
        //****************************************************************************************************************//
        //                                            SEARCH DATA                                                         //
        //****************************************************************************************************************//
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RenewData();
                timer1.Enabled = true;
                //CREATE THREAD TO RUN IN BACKGROUND
                GetTable = new Thread(GetDataToTable);
                GetTable.Start();
                GetTable.IsBackground = true;
                tsProcessing.Text = "processing...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NoInspect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int c = Vo.Timer_Counter;
            Vo.Timer_Counter++;
            tsTime.Text = (c / 100).ToString() + "," + ((c % 100) / 10).ToString() + " s";
            if (Vo.ThreadComplete)
            {
                Vo.ThreadComplete = false;
                dgvdt.DataSource = Vo.JoinedTable;
                tsProcessing.Text = dgvdt.Rows.Count.ToString() + " Rows";
                timer1.Enabled = false;
            }
        }
        #endregion

        #region EXPORT DATA TO CSV FILE
        //*****************************************************************************************************************//
        //                                         EXPORT DATA TO CSV FILE                                                 //
        //*****************************************************************************************************************//
        private void btnCSV_Click(object sender, EventArgs e)
        {
            try
            {
                RenewData();
                timer2.Enabled = true;
                //CREATE THREAD TO RUN IN BACKGROUND
                GetTable = new Thread(GetDataToTable);
                GetTable.Start();
                GetTable.IsBackground = true;
                tsProcessing.Text = "processing...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NoInspect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int c = Vo.Timer_Counter;
            Vo.Timer_Counter++;
            tsTime.Text = (c / 100).ToString() + "," + ((c % 100) / 10).ToString() + " s";
            if (Vo.ThreadComplete)
            {
                Vo.ThreadComplete = false;
                tsProcessing.Text = Vo.JoinedTable.Rows.Count + " Rows";
                sfSaveCSV = new SaveFileDialog();
                sfSaveCSV.RestoreDirectory = true;
                sfSaveCSV.Title = "Save file...";
                sfSaveCSV.Filter = "csv file(*.csv)|*.csv|text file(*.txt)|*.txt|All file(*.*)|*.*";
                if (sfSaveCSV.ShowDialog() == DialogResult.OK)
                {
                    Vo.SavePath = sfSaveCSV.FileName;
                    Vo.JoinedTable.ToCSV(Vo.SavePath);
                }
                timer2.Enabled = false;
            }
        }
        #endregion

        #region RENEW DATA
        //*****************************************************************************************************************//
        //                                                  RENEW DATA                                                     //
        //*****************************************************************************************************************//
        private void RenewData()
        {
            if (btnByLot.Checked)
                Vo.CheckLot = true;
            else
                Vo.CheckLot = false;
            Vo.ThreadComplete = false;
            Vo.Timer_Counter = 0;
            Vo.InspectList.Clear();
            Vo.JoinedTable = new DataTable();
            Vo.JoinedTable.Clear();
            dgvdt.Refresh();
            temp.Clear();
            SelectedNode(trInspect.Nodes);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Lines.Length > 0)
            {
                txtBarcode.Clear();
                Vo.SernoList.Clear();
            }
            if (txtURL.Text.Length > 0)
            {
                txtURL.Clear();
                Vo.SernoList.Clear();
            }
            tsSernoRows.Text = Vo.SernoList.Length.ToString() + " rows";
            MessageBox.Show("Clear all serial number list!");
        }
        #endregion
    }
}