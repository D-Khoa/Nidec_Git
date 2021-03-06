using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Security.Permissions;
using System.Collections;
using Npgsql;
using System.Runtime.InteropServices;

namespace BoxIdDb
{
    public partial class frmModule : Form
    {
        // The delegate variable to signal the occurrance of delegate event to the parent form "formBoxid"
        public delegate void RefreshEventHandler(object sender, EventArgs e);
        public event RefreshEventHandler RefreshEvent;
        static string conStringBoxidDb = @"Server=192.168.145.4;Port=5432;User Id=pqm;Password=dbuser;Database=boxidlddb; CommandTimeout=100; Timeout=100;";

        // The variable for degignate the shared floder to save text files for printing, 
        // which is to be printed by separate printing application
        string appconfig = System.Environment.CurrentDirectory + "\\info.ini";
        //string directory = @"Z:\(01)Motor\(00)Public\11-Suka-Sugawara\LD model\printer\print\";
        string directory = @"Z:\(01)Motor\(00)Public\11-Suka-Sugawara\LD model\printer\print\";
        // Other global variables
        bool formEditMode;
        string user;
        string config;
        string m_model;
        int okCount;
        bool inputBoxModeOriginal;
        string testerTableThisMonth;
        string testerTableLastMonth;
        DataTable dtOverall;
        DataTable dtReplace;
        public int limit1 = 0;
        int limit = 100;
        int limitld = 1100;
        int limitld4 = 3150;
        int limitlaa = 3000;
        int updateRowIndex;
        bool sound;
        string fltld4 = "process = 'LD4-LVT'";
        string fltld25 = "process = 'LD25_LVT'";
        string fltlaa = "process = 'LAA_LVT'";

        // Constructor
        public frmModule()
        {
            InitializeComponent();
        }

        // Load event
        private void frmModule_Load(object sender, EventArgs e)
        {
            // Store user name to the variable
            user = txtUser.Text;

            // Show box capacity in the text box
            if (!String.IsNullOrEmpty(txtBoxId.Text))
            {
                string[] mol = txtBoxId.Text.Split('-');
                string mdl = mol[0];
                switch (mdl)
                {
                    case "LD04":
                        limit = limitld4;
                        break;
                    case "LD25":
                        limit = limitld;
                        break;
                    case "LA10":
                    case "BMA60":
                    case "BMA-":
                        limit = limitlaa;
                        break;
                    default:
                        limit = 9999;
                        break;
                }
            }
            txtLimit.Text = limit.ToString();

            // Get the printing folder directory from the application setting file and store it to the variable
            //directory = @"Z:\(01)Motor\(00)Public\11-Suka-Sugawara\LD model\printer\print\";
            directory = @"Z:\(01)Motor\(00)Public\11-Suka-Sugawara\LD model\printer\print\";
            // Set this form's position on the screen
            this.Left = 350;
            this.Top = 30;

            // Generate datatbles to hold modules records
            dtOverall = new DataTable();
            defineAndReadDtOverall(ref dtOverall);
            updateDataGripViews(dtOverall, ref dgvProductSerial);
            dtReplace = new DataTable();
            defineAndReadDt(ref dtReplace);
        }

        // Sub procedure: Read ini file content
        private string readIni(string s, string k, string cfs)
        {
            StringBuilder retVal = new StringBuilder(255);
            string section = s;
            string key = k;
            string def = String.Empty;
            int size = 255;
            //get the value from the key in section
            int strref = GetPrivateProfileString(section, key, def, retVal, size, cfs);
            return retVal.ToString();
        }
        // Import Windows API
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        // Sub procedure: Transfer the parent from's information to this child form's objects
        public void updateControls(string boxId, DateTime printDate, string user, string serialNo, bool editMode)
        {
            txtBoxId.Text = boxId;
            dtpPrintDate.Value = printDate;
            txtUser.Text = user;
            txtProductSerial.Text = serialNo;

            txtProductSerial.Enabled = editMode;
            //btnRegisterBoxId.Enabled = !editMode;
            btnDeleteAll.Visible = editMode;
            //btnDeleteSelection.Visible = editMode;
            formEditMode = editMode;
            this.Text = editMode ? "Product Serial - Edit Mode" : "Product Serial - Browse Mode";
            btnRegisterBoxId.Text = editMode ? "Register Box ID" : "Register Again";
            btnPrint.Text = editMode ? "Print Box ID" : "Re_Print";

            if (user == "User_9")
            {
                btnChangeLimit.Visible = true;
                txtLimit.Visible = true;
            }
            if (!editMode && user == "User_9")
            {
                //btnChangeLimit.Enabled = false;
                ckbDeleteBox.Visible = true;
                if (ckbDeleteBox.Checked == true) btnDeleteBoxId.Visible = true;
            }
        }

        // Sub procedure: Get module recors from database and set them into this form's datatable
        private void defineAndReadDtOverall(ref DataTable dt)
        {
            string boxId = txtBoxId.Text;

            dt.Columns.Add("id", Type.GetType("System.String"));
            dt.Columns.Add("serialno", Type.GetType("System.String"));
            dt.Columns.Add("model", Type.GetType("System.String"));
            dt.Columns.Add("lot", Type.GetType("System.String"));
            dt.Columns.Add("line", Type.GetType("System.String"));
            dt.Columns.Add("config", Type.GetType("System.String"));
            dt.Columns.Add("process", Type.GetType("System.String"));
            dt.Columns.Add("linepass", Type.GetType("System.String"));
            dt.Columns.Add("testtime", Type.GetType("System.DateTime"));

            if (!formEditMode)
            {
                string sql = "select id, serialno, lot, line, config, process, linepass, testtime, model " +
                    "FROM product_serial WHERE boxid='" + boxId + "' order by serialno";
                ShSQL tf = new ShSQL();
                tf.sqlDataAdapterFillDatatable(sql, ref dt);
            }
        }

        // Sub procedure: Update datagridviews
        private void updateDataGripViews(DataTable dt1, ref DataGridView dgv1)
        {
            // Store the ENABLED status to the variable, then make the text boxs disenabled
            inputBoxModeOriginal = txtProductSerial.Enabled;
            txtProductSerial.Enabled = true;

            // Bind datatable to the datagridview
            updateDataGripViewsSub(dt1, ref dgv1);

            // Mark the records with the test result FAIL or missing
            colorViewForFailAndBlank(ref dgv1);

            // Mark config with duplicate or character length error
            colorMixedConfig(dt1, ref dgv1);

            // Mark the records with duplicate product serial or the serial with not enough character length
            colorViewForDuplicateSerial(ref dgv1);

            // Show row number to the row header
            for (int i = 0; i < dgv1.Rows.Count; i++)
                dgv1.Rows[i].HeaderCell.Value = (i + 1).ToString();

            // Adjust the width of the row header
            dgv1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            // Show the bottom of the datagridview
            if (dgv1.Rows.Count >= 1)
                dgv1.FirstDisplayedScrollingRowIndex = dgv1.Rows.Count - 1;

            // Set the text box back to the original state
            txtProductSerial.Enabled = inputBoxModeOriginal;

            // Store the OK record count to the variable and show in the text box
            okCount = getOkCount(dt1);
            txtOkCount.Text = okCount.ToString();

            // If the OK record count has already reached to the capacity, disenable the scan text box
            if (okCount == limit)
                txtProductSerial.Enabled = false;
            else
                txtProductSerial.Enabled = true;

            // If the OK record coutn has already reached to the capacity, enable the register button
            if (okCount == limit && dgv1.Rows.Count == limit)
                btnRegisterBoxId.Enabled = true;
            else
                btnRegisterBoxId.Enabled = false;

        }

        // Sub procedure: Count the without-duplicate OK records
        private int getOkCount(DataTable dt)
        {
            if (dt.Rows.Count <= 0) return 0;
            DataTable distinct = dt.DefaultView.ToTable(true, new string[] { "serialno", "linepass" });
            //DataRow[] dr = distinct.Select("linepass = 'PASS' and noise = 'SPEC IN'");
            DataRow[] dr = distinct.Select("linepass = 'PASS'");
            int dist = dr.Length;
            return dist;
        }

        // Sub procedure: Bind main datatable to the datagridview and make summary datatables
        private void updateDataGripViewsSub(DataTable dt1, ref DataGridView dgv1)
        {
            dgv1.DataSource = dt1;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            string[] criteriaLine = { "1", "2", "3", "4", "Total" };
            makeDatatableSummary(dt1, ref dgvLine, criteriaLine, "line");

            string[] criteriaConfig = { "01", "02", "1C", "1D", "Total" };
            makeDatatableSummary(dt1, ref dgvConfig, criteriaConfig, "config");

            string[] criteriaPassFail = { "PASS", "FAIL", "No Data", "Total" };
            makeDatatableSummary(dt1, ref dgvPassFail, criteriaPassFail, "linepass");

            string[] criteriaDateCode = getLotArray(dt1);
            makeDatatableSummary(dt1, ref dgvDateCode, criteriaDateCode, "lot");
        }

        // Sub procedure: Make the summary datatables and bind them to the summary datagridviews
        public void makeDatatableSummary(DataTable dt0, ref DataGridView dgv, string[] criteria, string header)
        {
            DataTable dt1 = new DataTable();
            DataRow dr = dt1.NewRow();
            Int32 count;
            Int32 total = 0;
            string condition;

            for (int i = 0; i < criteria.Length; i++)
            {
                dt1.Columns.Add(criteria[i], typeof(Int32));
                condition = header + " = '" + criteria[i] + "'";
                count = dt0.Select(condition).Length;
                total += count;
                dr[criteria[i]] = (i != criteria.Length - 1 ? count : total);
                if (criteria[i] == "Total" && header == "linepass")
                {
                    dr[criteria[i]] = dgvProductSerial.Rows.Count;
                    dr[criteria[i - 1]] = dgvProductSerial.Rows.Count - total;
                }
            }
            dt1.Rows.Add(dr);

            dgv.Columns.Clear();
            dgv.DataSource = dt1;
            dgv.AllowUserToAddRows = false; // remove the null line
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // Sub procedure: Make lot summary
        private string[] getLotArray(DataTable dt0)
        {
            DataTable dt1 = dt0.Copy();
            DataView dv = dt1.DefaultView;
            dv.Sort = "lot";
            DataTable dt2 = dv.ToTable(true, "lot");
            string[] array = new string[dt2.Rows.Count + 1];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                array[i] = dt2.Rows[i]["lot"].ToString();
            }
            array[dt2.Rows.Count] = "Total";
            return array;
        }

        // Sub procedure: Mark the test results with FAIL or missing test records
        private void colorViewForFailAndBlank(ref DataGridView dgv)
        {
            int rowCount = dgv.BindingContext[dgv.DataSource, dgv.DataMember].Count;

            for (int i = 0; i < rowCount; ++i)
            {
                if (dgv["linepass", i].Value.ToString() == "FAIL" || dgv["linepass", i].Value.ToString() == String.Empty)
                {
                    dgv["process", i].Style.BackColor = Color.Red;
                    dgv["linepass", i].Style.BackColor = Color.Red;
                    dgv["testtime", i].Style.BackColor = Color.Red;
                    soundAlarm();
                }
                else
                {
                    dgv["process", i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    dgv["linepass", i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    dgv["testtime", i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
        }

        // Sub procesure: Mark product serials with duplicate or character length error
        private void colorViewForDuplicateSerial(ref DataGridView dgv)
        {
            DataTable dt = ((DataTable)dgv.DataSource).Copy();
            if (dt.Rows.Count <= 0) return;

            for (int i = 0; i < dtOverall.Rows.Count; i++)
            {
                string serial = dgv[1, i].Value.ToString();
                DataRow[] dr = dt.Select("serialno = '" + serial + "'");
                if (dr.Length >= 2 || dgv[1, i].Value.ToString().Length > 10)
                {
                    dgv[1, i].Style.BackColor = Color.Red;
                    soundAlarm();
                }
                else
                {
                    dgv[0, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
        }

        // Sub procesure: Mark config with duplicate or character length error
        private void colorMixedConfig(DataTable dt, ref DataGridView dgv)
        {
            if (dt.Rows.Count <= 0) return;

            DataTable distinct = dt.DefaultView.ToTable(true, new string[] { "model" });

            if (distinct.Rows.Count == 1)
                m_model = distinct.Rows[0]["model"].ToString();

            if (distinct.Rows.Count >= 2)
            {
                string A = distinct.Rows[0]["model"].ToString();
                string B = distinct.Rows[1]["model"].ToString();
                int a = distinct.Select("model = '" + A + "'").Length;
                int b = distinct.Select("model = '" + B + "'").Length;

                // 件数の多いコンフィグを、この箱のメインモデルとする
                m_model = a > b ? A : B;

                // 件数の少ないほうのメインモデル文字を取得し、セル番地を特定してマークする
                string C = a < b ? A : B;
                int c = -1;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["model"].ToString() == C) { c = i; }
                }

                if (c != -1)
                {
                    dgv["model", c].Style.BackColor = Color.Red;
                    soundAlarm();
                }
                else
                {
                    dgv.Columns["model"].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
        }

        // Event when a module is scanned 
        private void txtProductSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Disenalbe the textbox to block scanning
                txtProductSerial.Enabled = false;

                string serLong = txtProductSerial.Text;
                string serShort = serLong;
                DateTime tbDate = DateTime.Today;
                A:
                string filterkey = decideReferenceTable(serShort, tbDate);
                if (serLong != String.Empty)
                {
                    // Get the tester data from current month's table and store it in datatable
                    string sql = "SELECT serno, process, tjudge, inspectdate" +
                        " FROM " + testerTableThisMonth +
                        " WHERE serno = '" + serShort + "'";
                    DataTable dt1 = new DataTable();
                    ShSQL tf = new ShSQL();
                    tf.sqlDataAdapterFillDatatableFromTesterDb(sql, ref dt1);

                    System.Diagnostics.Debug.Print(sql);

                    // Get the tester data from last month's table and store it in the same datatable
                    sql = "SELECT serno, process, tjudge, inspectdate" +
                        " FROM " + testerTableLastMonth +
                        " WHERE serno = '" + serShort + "'";
                    tf.sqlDataAdapterFillDatatableFromTesterDb(sql, ref dt1);
                    if (dt1.Rows.Count <= 0)
                    {
                        tbDate = tbDate.AddMonths(-1);
                        goto A;
                    }
                    System.Diagnostics.Debug.Print(sql);

                    string filterLine = string.Empty;
                    if (filterkey == "LD4") { filterLine = fltld4; }
                    else if (filterkey == "LA10" || filterkey == "BMA60"|| filterkey == "BMA-") { filterLine = fltlaa; }
                    else { filterLine = fltld25; }

                    DataView dv = new DataView(dt1);
                    dv.RowFilter = filterLine;
                    dv.Sort = "tjudge, inspectdate desc";
                    System.Diagnostics.Debug.Print(System.Environment.NewLine + "In-Line:");
                    printDataView(dv);
                    DataTable dt2 = dv.ToTable();

                    //�@インライン
                    // 一時テーブルへの登録準備
                    string lot = string.Empty;
                    string line = string.Empty;
                    string config = VBStrings.Mid(serShort, 1, 2);
                    string model = string.Empty;
                    if (VBStrings.Mid(serLong, 1, 2) == "1C" || VBStrings.Mid(serLong, 1, 2) == "1D")
                    { model = "LD04"; }
                    else if (serLong.Length == 8)
                        //model = "LA10";
                        model = "BMA60";
                    else
                    { model = "LD25"; }

                    if (model == "BMA60")
                    {
                        line = "1";
                        lot = VBStrings.Mid(serShort, 1, 4);
                    }
                    else
                    {
                        line = VBStrings.Mid(serShort, 7, 1);
                        lot = VBStrings.Mid(serShort, 3, 4);
                    }



                    // Even when no tester data is found, the module have to appear in the datagridview
                    DataRow newrow = dtOverall.NewRow();
                    newrow["serialno"] = serLong;
                    newrow["model"] = model;
                    newrow["lot"] = lot;
                    newrow["line"] = line;
                    newrow["config"] = config;

                    // If tester data exists, show it in the datagridview
                    if (dt2.Rows.Count != 0)
                    {
                        string process = dt2.Rows[0][1].ToString();
                        string linepass = String.Empty;
                        string buff = dt2.Rows[0][2].ToString();
                        if (buff == "0") linepass = "PASS";
                        else if (buff == "1") linepass = "FAIL";
                        else linepass = "ERROR";
                        DateTime testtime = (DateTime)dt2.Rows[0][3];
                        newrow["process"] = process;
                        newrow["linepass"] = linepass;
                        newrow["testtime"] = testtime;
                    }

                    // Add the row to the datatable
                    dtOverall.Rows.Add(newrow);

                    //Set limit
                    if (dtOverall.Rows.Count >= 1)
                    {
                        string m = dtOverall.Rows[0]["model"].ToString();
                        switch (m)
                        {
                            case "LD04":
                                limit = limitld4;
                                break;
                            case "LD25":
                                limit = limitld;
                                break;
                            case "LA10":
                            case "BMA60":
                            case "BMA-":
                                limit = limitlaa;
                                break;
                            default:
                                limit = 9999;
                                break;
                        }

                        txtLimit.Text = limit.ToString();
                        // ＵＳＥＲ９がＬＩＭＩＴを設定した場合は、それに従う
                        if (limit1 != 0) limit = limit1;
                    }

                    // データグリットビューの更新
                    updateDataGripViews(dtOverall, ref dgvProductSerial);
                }

                // For the operator to continue scanning, enable the scan text box and select the text in the box
                if (okCount >= limit)
                {
                    txtProductSerial.Enabled = false;
                }
                else
                {
                    txtProductSerial.Enabled = true;
                    txtProductSerial.Focus();
                    txtProductSerial.SelectAll();
                }
            }
        }

        // Select datatable
        private string decideReferenceTable(string serno, DateTime tabledate)
        {
            string tablekey = string.Empty;
            string filterkey = string.Empty;
            if (VBStrings.Mid(serno, 1, 2) == "1C" || VBStrings.Mid(serno, 1, 2) == "1D")
            { tablekey = "ld4"; filterkey = "LD4"; }
            else if (serno.Length == 8)
            { tablekey = "laa10_003"; filterkey = "LA10"; }
            else
            { tablekey = "ld25"; filterkey = "LD25"; }// エラー対策
            testerTableThisMonth = tablekey + tabledate.ToString("yyyyMM");
            //testerTableLastMonth = tablekey + ((VBStrings.Right(DateTime.Today.ToString("yyyyMM"), 2) != "01") ?
            //    (long.Parse(DateTime.Today.ToString("yyyyMM")) - 1).ToString() : (long.Parse(DateTime.Today.ToString("yyyy")) - 1).ToString() + "12");
            testerTableLastMonth = tablekey + tabledate.AddMonths(-1).ToString("yyyyMM");
            return filterkey;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string boxId = txtBoxId.Text;
            if (!formEditMode)
            {
                if (okCount == limit && dgvProductSerial.Rows.Count == limit)
                {
                    config = dtOverall.Rows[0]["config"].ToString();
                    printBarcode(directory, boxId, config, m_model, dgvDateCode, ref dgvDateCode2, ref txtBoxIdPrint);
                }
            }
            else
            {
                string boxIdNew = getNewBoxId();
                if (okCount == limit && dgvProductSerial.Rows.Count == limit)
                {
                    // Print barcode
                    printBarcode(directory, boxIdNew, config, m_model, dgvDateCode, ref dgvDateCode2, ref txtBoxIdPrint);

                    // Clear the datatable
                    dtOverall.Clear();

                    txtBoxId.Text = boxIdNew;
                    if (boxIdNew.Contains("BMA60"))
                        dtpPrintDate.Value = DateTime.ParseExact(VBStrings.Mid(boxIdNew, 7, 6), "yyMMdd", CultureInfo.InvariantCulture);
                    else
                        dtpPrintDate.Value = DateTime.ParseExact(VBStrings.Mid(boxIdNew, 6, 6), "yyMMdd", CultureInfo.InvariantCulture);
                }
            }
        }
        // Issue new box id, register product serials, and save text file for barcode printing
        private void btnRegisterBoxId_Click(object sender, EventArgs e)
        {
            btnRegisterBoxId.Enabled = false;
            btnDeleteSelection.Enabled = false;
            btnDeleteAll.Enabled = false;
            btnCancel.Enabled = false;

            string boxId = txtBoxId.Text;

            // If this form' mode is not for EDIT, this botton works for RE-PRINTING barcode lable
            if (btnRegisterBoxId.Text == "Register Again")
            {
                DataTable dt_c = dtOverall.Copy();
                dt_c.Columns.Add("boxid", Type.GetType("System.String"));
                for (int i = 0; i < dt_c.Rows.Count; i++)
                {
                    dt_c.Rows[i]["boxid"] = txtBoxId.Text;
                }
                ShSQL sh = new ShSQL();
                bool res = sh.sqlMultipleInsert(dt_c);
                btnCancel.Enabled = true;
                MessageBox.Show("The box id " + txtBoxId.Text + " and " + Environment.NewLine +
                    "its product serials were registered.", "Process Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check if the product serials had already registered in the database table
            string checkResult = checkDataTableWithRealTable(dtOverall);

            if (checkResult != String.Empty)
            {
                MessageBox.Show("The following serials are already registered with box id:" + Environment.NewLine +
                    checkResult + Environment.NewLine + "Please check and delete.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                btnRegisterBoxId.Enabled = true;
                btnDeleteSelection.Enabled = true;
                btnDeleteAll.Enabled = true;
                btnCancel.Enabled = true;
                return;
            }

            // Issue new box id
            string boxIdNew;
            if (btnRegisterBoxId.Text == "Register Box ID")
            {
                boxIdNew = getNewBoxId();
            }
            else boxIdNew = boxId;

            // As the first step, add new box id information to the product serial datatable
            DataTable dt = dtOverall.Copy();
            dt.Columns.Add("boxid", Type.GetType("System.String"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["boxid"] = boxIdNew;
            }
            // As the second step, register datatables' each record into database table
            ShSQL tf = new ShSQL();
            bool res1 = tf.sqlMultipleInsertOverall(dt);
            bool res2 = false;

            if ((VBStrings.Left(boxIdNew, 4) == "LA10" || VBStrings.Left(boxIdNew, 5) == "BMA60") && txtOkCount.Text == "3000") { res2 = true; }
            if (res1 & res2)
            {
                if (okCount == limit && dgvProductSerial.Rows.Count == limit)
                {
                    // Print barcode
                    printBarcode(directory, boxIdNew, config, m_model, dgvDateCode, ref dgvDateCode2, ref txtBoxIdPrint);

                    // Clear the datatable
                    dtOverall.Clear();

                    txtBoxId.Text = boxIdNew;
                    if (boxIdNew.Contains("BMA60"))
                        dtpPrintDate.Value = DateTime.ParseExact(VBStrings.Mid(boxIdNew, 7, 6), "yyMMdd", CultureInfo.InvariantCulture);
                    else
                        dtpPrintDate.Value = DateTime.ParseExact(VBStrings.Mid(boxIdNew, 6, 6), "yyMMdd", CultureInfo.InvariantCulture);
                }
                // Generate delegate event to update parant form frmBoxid's datagridview (box id list)
                this.RefreshEvent(this, new EventArgs());

                this.Focus();
                MessageBox.Show("The box id " + boxIdNew + " and " + Environment.NewLine +
                    "its product serials were registered.", "Process Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxId.Text = String.Empty;
                txtProductSerial.Text = String.Empty;
                updateDataGripViews(dtOverall, ref dgvProductSerial);
                btnRegisterBoxId.Enabled = false;
                btnPrint.Enabled = false;
                btnDeleteSelection.Enabled = false;
                btnDeleteAll.Enabled = false;
                btnCancel.Enabled = true;
            }
            else
            {
                MessageBox.Show("Box id and product serials were registered without print the label.", "Process Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //btnRegisterBoxId.Enabled = true;
                btnDeleteSelection.Enabled = true;
                btnDeleteAll.Enabled = true;
                btnCancel.Enabled = true;
            }

        }

        // Sub procedure: Check if datatable's product serial is included in the database table
        // (actually, database itself blocks the duplicate, so this process is not needed)
        private string checkDataTableWithRealTable(DataTable dt1)
        {
            string result = String.Empty;

            string sql = "select serial_short, boxid " +
                 "FROM product_serial_printdate WHERE testtime BETWEEN '" + System.DateTime.Today.AddDays(-7) + "' AND '" + System.DateTime.Today.AddDays(1) + "'";

            DataTable dt2 = new DataTable();
            ShSQL tf = new ShSQL();
            tf.sqlDataAdapterFillDatatable(sql, ref dt2);

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string serial = VBStrings.Left(dt1.Rows[i]["serialno"].ToString(), 17);
                DataRow[] dr = dt2.Select("serial_short = '" + serial + "'");
                if (dr.Length >= 1)
                {
                    string boxid = dr[0]["boxId"].ToString();
                    result += (i + 1 + ": " + serial + " / " + boxid + Environment.NewLine);
                }
            }

            if (result == String.Empty)
            {
                return String.Empty;
            }
            else
            {
                return result;
            }
        }

        // Sub procedure: Issue new box id
        private string getNewBoxId()
        {
            m_model = dtOverall.Rows[0]["model"].ToString();
            string sql = "select MAX(boxid) FROM box_id where boxid like '" + m_model + "%'";
            System.Diagnostics.Debug.Print(sql);
            ShSQL yn = new ShSQL();
            string boxIdOld = yn.sqlExecuteScalarString(sql);

            DateTime dateOld = new DateTime(0);
            long numberOld = 0;
            string boxIdNew;

            if (boxIdOld != string.Empty)
            {
                if (boxIdOld.Contains("BMA60"))
                    dateOld = DateTime.ParseExact(VBStrings.Mid(boxIdOld, 7, 6), "yyMMdd", CultureInfo.InvariantCulture);
                else
                    dateOld = DateTime.ParseExact(VBStrings.Mid(boxIdOld, 6, 6), "yyMMdd", CultureInfo.InvariantCulture);
                numberOld = long.Parse(VBStrings.Right(boxIdOld, 3));
            }

            if (dateOld != DateTime.Today)
            {
                boxIdNew = m_model + "-" + DateTime.Today.ToString("yyMMdd") + "001";
            }
            else
            {
                boxIdNew = m_model + "-" + DateTime.Today.ToString("yyMMdd") + (numberOld + 1).ToString("000");
            }

            sql = "INSERT INTO box_id(" +
                "boxid," +
                "suser," +
                "printdate) " +
                "VALUES(" +
                "'" + boxIdNew + "'," +
                "'" + user + "'," +
                "'" + DateTime.Now.ToString() + "')";
            System.Diagnostics.Debug.Print(sql);
            yn.sqlExecuteNonQuery(sql, false);
            return boxIdNew;
        }

        // Sub procedure: Print barcode, by generating a text file in shared folder and let another application print it
        private void printBarcode(string dir, string id, string config, string m_model, DataGridView dgv1, ref DataGridView dgv2, ref TextBox txt)
        {
            ShPrint tf = new ShPrint();
            tf.createBoxidFiles(dir, id, config, m_model, dgv1, ref dgv2, ref txt);
        }

        public string check;
        // Delete records on datagridview selected by the user
        private void btnDeleteSelection_Click(object sender, EventArgs e)
        {
            if (dgvProductSerial.Columns.GetColumnCount(DataGridViewElementStates.Selected) >= 2)
            {
                MessageBox.Show("Please select range with only one columns.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }
            ShSQL sh = new ShSQL();

            if (dgvProductSerial.CurrentRow.Cells["id"].Value.ToString() != "")
            {
                check = sh.sqlExecuteScalarString("select count(*) from product_serial where serialno = '" + dgvProductSerial.CurrentRow.Cells["serialno"].Value.ToString() + "' and id = '" + dgvProductSerial.CurrentRow.Cells["id"].Value.ToString() + "'");
            }
            DialogResult result = MessageBox.Show("Do you really want to delete the selected rows?",
                "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                if (check != "0")
                {
                    sh.sqlExecuteScalarString("delete from product_serial where id = '" + dgvProductSerial.CurrentRow.Cells[0].Value.ToString() + "'");
                }
                foreach (DataGridViewCell cell in dgvProductSerial.SelectedCells)
                {
                    int i = cell.RowIndex;
                    dtOverall.Rows[i].Delete();
                }
                dtOverall.AcceptChanges();
                updateDataGripViews(dtOverall, ref dgvProductSerial);
                txtProductSerial.Focus();
            }
        }

        // Delete all records on datagridview, by the user's click on the delete all button
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            int rowCount = dgvProductSerial.Rows.Count;
            if (rowCount != 0)
            {
                DialogResult result = MessageBox.Show("Do you really want to delete all the record?",
                    "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    dtOverall.Clear();
                    dtOverall.AcceptChanges();
                    updateDataGripViews(dtOverall, ref dgvProductSerial);
                    txtProductSerial.Focus();
                }
            }
        }

        // Change the capacity of the box (only for the super user)
        private void btnChangeLimit_Click(object sender, EventArgs e)
        {
            // Open frmCapacity with delegate event
            bool bl = ShGeneral.checkOpenFormExists("frmCapacity");
            if (bl)
            {
                MessageBox.Show("Please close or complete another form.", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            else
            {
                frmCapacity f4 = new frmCapacity();
                // When the delegate event is triggered by child, update this form's datagridview
                f4.RefreshEvent += delegate (object sndr, EventArgs excp)
                {
                    limit = f4.getLimit();
                    txtLimit.Text = limit.ToString();
                    updateDataGripViews(dtOverall, ref dgvProductSerial);
                    this.Focus();
                };

                f4.updateControls(limit.ToString());
                f4.Show();
            }
        }

        private void defineAndReadDt(ref DataTable dt)
        {
            dt.Columns.Add("serialno", Type.GetType("System.String"));
            dt.Columns.Add("model", Type.GetType("System.String"));
            dt.Columns.Add("lot", Type.GetType("System.String"));
            dt.Columns.Add("line", Type.GetType("System.String"));
            dt.Columns.Add("config", Type.GetType("System.String"));
            dt.Columns.Add("process", Type.GetType("System.String"));
            dt.Columns.Add("linepass", Type.GetType("System.String"));
            dt.Columns.Add("testtime", Type.GetType("System.DateTime"));
        }

        // シリアル付帯情報を取得する
        private void setSerialInfoAndTesterResult(string serLong)
        {
            DateTime tbdate = DateTime.Today;
            B:
            string filterkey = decideReferenceTable(serLong, tbdate);
            if (serLong != String.Empty)
            {
                // Get the tester data from current month's table and store it in datatable
                string sql = "SELECT serno, process, tjudge, inspectdate" +
                    " FROM " + testerTableThisMonth +
                    " WHERE serno = '" + serLong + "'";
                DataTable dt1 = new DataTable();
                ShSQL tf = new ShSQL();
                tf.sqlDataAdapterFillDatatableFromTesterDb(sql, ref dt1);

                System.Diagnostics.Debug.Print(sql);

                // Get the tester data from last month's table and store it in the same datatable
                sql = "SELECT serno, process, tjudge, inspectdate" +
                    " FROM " + testerTableLastMonth +
                    " WHERE serno = '" + serLong + "'";
                tf.sqlDataAdapterFillDatatableFromTesterDb(sql, ref dt1);
                if (dt1.Rows.Count <= 0)
                {
                    tbdate = tbdate.AddMonths(-1);
                    goto B;
                }
                System.Diagnostics.Debug.Print(sql);

                string filterLine = string.Empty;
                if (filterkey == "LD4") { filterLine = fltld4; }
                else { filterLine = fltld25; }

                DataView dv = new DataView(dt1);
                dv.RowFilter = filterLine;
                dv.Sort = "tjudge, inspectdate desc";
                System.Diagnostics.Debug.Print(System.Environment.NewLine + "In-Line:");
                printDataView(dv);
                DataTable dt2 = dv.ToTable();

                string lot = VBStrings.Mid(serLong, 3, 4);
                string line = VBStrings.Mid(serLong, 7, 1);
                string config = VBStrings.Mid(serLong, 1, 2);
                string model = string.Empty;
                if (VBStrings.Mid(serLong, 1, 2) == "1C" || VBStrings.Mid(serLong, 1, 2) == "1D")
                { model = "LD04"; }
                else
                { model = "LD25"; }

                // Even when no tester data is found, the module have to appear in the datagridview
                DataRow newr = dtReplace.NewRow();
                newr["serialno"] = serLong;
                newr["model"] = model;
                newr["lot"] = lot;
                newr["line"] = line;
                newr["config"] = config;

                // If tester data exists, show it in the datagridview
                if (dt2.Rows.Count != 0)
                {
                    string process = dt2.Rows[0][1].ToString();
                    string linepass = String.Empty;
                    string buff = dt2.Rows[0][2].ToString();
                    if (buff == "0") linepass = "PASS";
                    else if (buff == "1") linepass = "FAIL";
                    else linepass = "ERROR";
                    DateTime testtime = (DateTime)dt2.Rows[0][3];
                    newr["process"] = process;
                    newr["linepass"] = linepass;
                    newr["testtime"] = testtime;
                }

                dtReplace.Rows.Add(newr);
            }
        }

        // Delete box is and its product module data(done by only the user user)
        private void btnDeleteBoxId_Click(object sender, EventArgs e)
        {
            // Ask 2 times to the user for check
            DialogResult result1 = MessageBox.Show("Do you really delete this box id's all the serial data?",
                "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result1 == DialogResult.Yes)
            {
                DialogResult result2 = MessageBox.Show("Are you really sure? Please select NO if you are not sure.",
                    "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result2 == DialogResult.Yes)
                {
                    string boxid = txtBoxId.Text;
                    string sql = "delete from product_serial where boxid = '" + boxid + "'";
                    string sql1 = "delete from box_id where boxid = '" + boxid + "'";
                    ShSQL tf = new ShSQL();
                    tf.sqlExecuteNonQuery(sql, true);
                    tf.sqlExecuteNonQuery(sql1, true);

                    dtOverall.Clear();
                    // Update datagridviw
                    updateDataGripViews(dtOverall, ref dgvProductSerial);
                }
            }
        }

        // Sub procedure: Read product serial records from database to datatable
        private void readDatatable(ref DataTable dt)
        {
            string boxId = txtBoxId.Text;
            string sql = "select serialno, lot, line, process, linepass, testtime " +
                "FROM product_serial WHERE boxid='" + boxId + "'";
            ShSQL tf = new ShSQL();
            tf.sqlDataAdapterFillDatatable(sql, ref dt);
        }

        // When cancel button is clicked, let the user check if it is OK that the records are deleted in add mode.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // When frmCapacity is remaining open, let the user close it
            string formName = "frmCapacity";
            bool bl = false;
            foreach (Form buff in Application.OpenForms)
            {
                if (buff.Name == formName) { bl = true; }
            }
            if (bl)
            {
                MessageBox.Show("You need to close another form before canceling.", "Notice",
                  MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                return;
            }

            // When frmModuleReplace is remaining open, let the user close it
            formName = "frmModuleReplace";
            bl = false;
            foreach (Form buff in Application.OpenForms)
            {
                if (buff.Name == formName) { bl = true; }
            }
            if (bl)
            {
                MessageBox.Show("You need to close another form before canceling..", "Notice",
                  MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                return;
            }

            // If there is no record in the datatable or the form is opened as for view, let the user close the form
            if (dtOverall.Rows.Count == 0 || !formEditMode)
            {
                Application.OpenForms["frmBoxid"].Focus();
                Close();
                return;
            }

            // Show alarm that all the temporary records in datatable will be completely deleted
            DialogResult result = MessageBox.Show("The current serial data has not been saved." + System.Environment.NewLine +
                "Do you rally cancel?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                dtOverall.Clear();
                updateDataGripViews(dtOverall, ref dgvProductSerial);
                MessageBox.Show("The temporary serial numbers are deleted.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                Application.OpenForms["frmBoxid"].Focus();
                Close();
            }
            else
            {
                return;
            }
        }


        // Do not allow user to close this form by right top close button or by Alt+F4 shor cut
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_SYSCOMMAND = 0x112;
        //    const long SC_CLOSE = 0xF060L;
        //    if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE) { return; }
        //    base.WndProc(ref m);
        //}

        // Play the MP3 file for alarming users
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern int mciSendString(String command,
           StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        private string aliasName = "MediaFile";

        private void soundAlarm()
        {
            string fileName = @"Z:\(01)Motor\(00)Public\11-Suka-Sugawara\LD model\printer\warning.mp3";
            string cmd;

            if (sound)
            {
                cmd = "stop " + aliasName;
                mciSendString(cmd, null, 0, IntPtr.Zero);
                cmd = "close " + aliasName;
                mciSendString(cmd, null, 0, IntPtr.Zero);
                sound = false;
            }

            cmd = "open \"" + fileName + "\" type mpegvideo alias " + aliasName;
            if (mciSendString(cmd, null, 0, IntPtr.Zero) != 0) return;
            cmd = "play " + aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
            sound = true;
        }

        // Sub procedure: Check the records in dataview for debug
        private void printDataView(DataView dv)
        {
            foreach (DataRowView drv in dv)
            {
                System.Diagnostics.Debug.Print(drv["process"].ToString() + ": " +
                    drv["tjudge"].ToString() + ": " + drv["inspectdate"].ToString());
            }
        }

        private void btnReplaceSerial_Click(object sender, EventArgs e)
        {
            btnRegisterBoxId.Enabled = false;
            new frmReplace(txtBoxId.Text).ShowDialog();
        }

        private void ckbDeleteBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbDeleteBox.Checked) btnDeleteBoxId.Visible = false;
            else btnDeleteBoxId.Visible = true;
        }
    }
}