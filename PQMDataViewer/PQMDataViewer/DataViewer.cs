using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PQMDataViewer.Class;
using Npgsql;

namespace PQMDataViewer
{
    public partial class DataViewer : Form
    {
        private string SQLConnectString = @"Server=192.168.145.12;Port=5432;UserId=pqm;Password=dbuser;Database=pqmdb;";

        #region FORM EVENT
        public DataViewer()
        {
            InitializeComponent();
        }

        private async void DataViewer_Load(object sender, EventArgs e)
        {
            await GetModel();
        }
        #endregion

        #region BUTTONS EVENT
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region FIELDS EVENT
        private async void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetLine(cmbModel.Text);
            await GetProcess(cmbModel.Text);
        }

        private async void cmbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetInspect(cmbModel.Text, cmbProcess.Text);
        }
        #endregion

        #region SUBS EVENT
        #region ADD FIELDS DATA
        private async Task GetModel()
        {
            PostgresDatabase database = new PostgresDatabase();
            string sSQL = "select distinct model from procinsplink order by model asc";
            await database.ExecuteReaderAsync(SQLConnectString, sSQL)
                          .ContinueWith(t => this.Invoke((Action)(() => { ModelResult(t.Result); })));
        }

        private async Task GetLine(string inModel)
        {
            PostgresDatabase database = new PostgresDatabase();
            string sSQL = "select distinct line from processtbl where model = @model order by line asc";
            var modelpara = new NpgsqlParameter("@model", inModel);
            await database.ExecuteReaderAsync(SQLConnectString, sSQL, modelpara)
                          .ContinueWith(t => this.Invoke((Action)(() => { LineResult(t.Result); })));
        }

        private async Task GetProcess(string inModel)
        {
            PostgresDatabase database = new PostgresDatabase();
            string sSQL = "select distinct process from processtbl where model = @model order by process asc";
            var modelpara = new NpgsqlParameter("@model", inModel);
            await database.ExecuteReaderAsync(SQLConnectString, sSQL, modelpara)
                          .ContinueWith(t => this.Invoke((Action)(() => { ProcessResult(t.Result); })));
        }

        private async Task GetInspect(string inModel, string inProcess)
        {
            PostgresDatabase database = new PostgresDatabase();
            string sSQL = "select distinct inspect from procinsplink where model = @model and process = @process order by inspect asc";
            var modelpara = new NpgsqlParameter("@model", inModel);
            var processpara = new NpgsqlParameter("@process", inProcess);
            await database.ExecuteReaderAsync(SQLConnectString, sSQL, modelpara, processpara)
                          .ContinueWith(t => this.Invoke((Action)(() => { InspectResult(t.Result); })));
        }

        private void ModelResult(PostgresDatabase.PGDatabaseResult dbResult)
        {
            if (dbResult.Success)
            {
                cmbModel.DataSource = dbResult.Data;
                cmbModel.DisplayMember = "model";
            }
            else
            {
                MessageBox.Show(dbResult.Result);
            }
        }

        private void LineResult(PostgresDatabase.PGDatabaseResult dbResult)
        {
            if (dbResult.Success)
            {
                cmbLine.DataSource = dbResult.Data;
                cmbLine.DisplayMember = "line";
            }
            else
            {
                MessageBox.Show(dbResult.Result);
            }
        }

        private void ProcessResult(PostgresDatabase.PGDatabaseResult dbResult)
        {
            if (dbResult.Success)
            {
                cmbProcess.DataSource = dbResult.Data;
                cmbProcess.DisplayMember = "process";
            }
            else
            {
                MessageBox.Show(dbResult.Result);
            }
        }

        private void InspectResult(PostgresDatabase.PGDatabaseResult dbResult)
        {
            if (dbResult.Success)
            {
                clInspect.Items.AddRange(dbResult.Data.ToArray());
            }
            else
            {
                MessageBox.Show(dbResult.Result);
            }
        }
        #endregion

        private void UpdateGrid(bool isSearch)
        {
            if (isSearch)
            {

            }
        }

        private string DefineTableName()
        {
            if (cbCheckDate.Checked)
            {
                string table = string.Empty;
                DateTime date = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;
                while(date < toDate)
                {
                    date = date.AddMonths(1);
                    table = cmbModel.Text + date.ToString("yyyyMM") + ",";
                }
                table = table.Remove(table.Length - 1);
                return table;
            }
            else
                return cmbModel.Text + DateTime.Now.ToString("yyyyMM");
        }

        private string SerialString()
        {
            string serno = string.Empty;
            foreach(string line in txtbarcode.Lines)
            {
                serno += "'" + line + "',";
            }
            serno = serno.Remove(serno.Length - 1);
            return serno;
        }

        private async Task GetSernoTable()
        {
            PostgresDatabase database = new PostgresDatabase();
            string table = DefineTableName();
            string sSQL = "select * from " + table +" where 1=1 ";
            if (cbLine.Checked) sSQL += "and line ='" + cmbLine.Text + "' ";
            if (cbProcess.Checked) sSQL += "and process ='" + cmbProcess.Text + "' ";
            if (!string.IsNullOrEmpty(txtbarcode.Text))
            {
                string serno = SerialString();
                if (rbLot.Checked) sSQL += "and lot =" + serno + " ";
                if (rbSerial.Checked) sSQL += "and serno =" + serno + " ";
            }
            DataSet results1 = await database.GetDatasetAsync(SQLConnectString, sSQL);

            sSQL = "select * from " + table + "data where 1=1 ";
            if (!string.IsNullOrEmpty(txtbarcode.Text))
            {
                string serno = SerialString();
                if (rbLot.Checked) sSQL += "and lot =" + serno + " ";
                if (rbSerial.Checked) sSQL += "and serno =" + serno + " ";
            }
            DataSet results2 = await database.GetDatasetAsync(SQLConnectString, sSQL);
        }
        #endregion
    }
}
