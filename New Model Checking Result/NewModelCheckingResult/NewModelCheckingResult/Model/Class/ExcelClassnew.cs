using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using NewModelCheckingResult.Model;
using System.Collections.Generic;

namespace NewModelCheckingResult
{
    public class ExcelClassnew
    {
        DataTable dt;
        private void defineDt(ref DataTable dt)
        {
            dt.Columns.Add("scdl_day", Type.GetType("System.String"));
            dt.Columns.Add("m", Type.GetType("System.Double"));
        }
        public void exportExcel(string model, string line, string user, string usl, string lsl, string process, string inspect, string sample, string descrip, DataGridView dgv, string dtpFrom, string dtpTo)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 2
            //Excel.Worksheet xlWorkSheet1; //sheet 1
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(@"D:\Database IPQC\Template.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                #region Sheet 2
                //dt = new DataTable();
                //defineDt(ref dt);
                ////Add data in Sheet 1
                //xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);  //add data sheet1 
                //xlWorkSheet1.Cells[2, 2] = line; //Line
                //xlWorkSheet1.Cells[5, 2] = user; //User
                //xlWorkSheet1.Cells[1, 3] = process; //Process
                //xlWorkSheet1.Cells[1, 11] = descrip; //Description
                //xlWorkSheet1.Cells[5, 6] = lsl; //LSL, USL
                //xlWorkSheet1.Cells[5, 5] = usl;


                //int x = 0;
                //string[] n = new string[dgv.Rows.Count];
                //for (int i = 0; i < dgv.Rows.Count-1; i++)
                //{
                //    if (dgv[1, i].Value.ToString() != dgv[1, i + 1].Value.ToString())
                //    {
                //        x = x + 1;

                //        n[i] = dgv[1, i].Value.ToString();
                //        xlWorkSheet1.Cells[10, x + 2] = n[i];
                //    }
                //}            
                //string sql = "select a.scdl_day, a.m from " +
                //             "(select '1' as place, date_trunc('day', lot) as scdl_day, lot, m1 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and lot >= '" + dtpFrom + "' and lot < '" + dtpTo + "' and qc_user like 'user%' union all " +
                //             "select '2' as place, date_trunc('day', lot) as scdl_day, lot, m2 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and lot >= '" + dtpFrom + "' and lot < '" + dtpTo + "' and qc_user like 'user%' union all " +
                //             "select '3' as place, date_trunc('day', lot) as scdl_day, lot, m3 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + dtpFrom + "' and lot < '" + dtpTo + "' and qc_user like 'user%' union all " +
                //             "select '4' as place, date_trunc('day', lot) as scdl_day, lot, m4 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + dtpFrom + "' and lot < '" + dtpTo + "' and qc_user like 'user%' union all " +
                //             "select '5' as place, date_trunc('day', lot) as scdl_day, lot, m5 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + dtpFrom + "' and lot < '" + dtpTo + "' and qc_user like 'user%') a " +
                //             "order by a.lot, a.place";
                //TfSQL tf = new TfSQL();
                //tf.sqlDataAdapterFillDatatable(sql, ref dt);
                //int dem =0;
                //for(int i =0; i <= dt.Rows.Count-2;i++)
                //{
                //    if (dt.Rows[i][0].ToString() != dt.Rows[i + 1][0].ToString())
                //    {
                //        dem = i;
                //        for (int j = 0; j <= dem-1; j++)
                //        {
                //            xlWorkSheet1.Cells[j + 11, i + 3] = dt.Rows[j][1];
                //        }
                //    }
                //    //else break;
                //}
                ////for (int i = 0; i <= xlWorkSheet1.Range["C10:AG10"].Count; i++)
                ////{
                ////    string from = xlWorkSheet1.Cells[10, i + 3].Value.ToString("yyyy/MM/dd");
                ////    string to;
                ////    if (i + 1 == xlWorkSheet1.Range["C10:AG10"].Count)
                ////    {
                ////        to = xlWorkSheet1.Cells[10, i + 3].Value.ToString("yyyy/MM/dd");
                ////    }
                ////    else
                ////    {
                ////        to = xlWorkSheet1.Cells[10, i + 4].Value.ToString("yyyy/MM/dd");
                ////    }
                ////    string sql = "select a.scdl_day, a.m from " +
                ////             "(select '1' as place, date_trunc('day', lot) as scdl_day, lot, m1 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and lot >= '" + from + "' and lot < '" + to + "' and qc_user like 'user%' union all " +
                ////             "select '2' as place, date_trunc('day', lot) as scdl_day, lot, m2 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and lot >= '" + from + "' and lot < '" + to + "' and qc_user like 'user%' union all " +
                ////             "select '3' as place, date_trunc('day', lot) as scdl_day, lot, m3 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + from + "' and lot < '" + to + "' and qc_user like 'user%' union all " +
                ////             "select '4' as place, date_trunc('day', lot) as scdl_day, lot, m4 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + from + "' and lot < '" + to + "' and qc_user like 'user%' union all " +
                ////             "select '5' as place, date_trunc('day', lot) as scdl_day, lot, m5 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + from + "' and lot < '" + to + "' and qc_user like 'user%') a " +
                ////             "order by a.lot, a.place";
                ////    TfSQL tf = new TfSQL();
                ////    tf.sqlDataAdapterFillDatatable(sql, ref dt);

                ////    xlWorkSheet1.Cells[i + 8, 3] = (double)dt.Rows[i - 3][1];

                ////}
                #endregion

                #region Sheet 1
                //Add data in Sheet 1
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1
                xlWorkSheet.Cells[7, 18] = line; //Line
                xlWorkSheet.Cells[4, 3] = model; //Model
                xlWorkSheet.Cells[7, 21] = user; //User
                xlWorkSheet.Cells[7, 3] = process; //Process
                xlWorkSheet.Cells[9, 3] = descrip; //Description
                xlWorkSheet.Cells[7, 12] = lsl; //LSL, USL
                xlWorkSheet.Cells[7, 13] = usl;
                xlWorkSheet.Cells[7, 26] = sample; //Sample

                //datagridw
                for (int i = 0; i <= dgv.Rows.Count - 1; i++) //dong
                {
                    for (int j = 0; j < 5; j++) //cot
                    {
                        DataGridViewCell cell = dgv[j + 6, i]; //cot roi dong
                        xlWorkSheet.Cells[j + 17, i + 3] = cell.Value; // dong roi cot
                    }
                }

                //ngay, gio, status
                for (int i = 0; i <= dgv.Rows.Count - 1; i++)
                {
                    //ngay là 14:3
                    DataGridViewCell cell = dgv[1, i]; //cot roi dong
                    xlWorkSheet.Cells[15, i + 3] = cell.Value; // dong roi cot 

                    //giờ là 15:3
                    xlWorkSheet.Cells[16, i + 3] = cell.Value; // dong roi cot 

                    //status
                    DataGridViewCell cell1 = dgv[5, i];
                    xlWorkSheet.Cells[14, i + 3] = cell1.Value;

                    //repair
                    DataGridViewCell cell2 = dgv[4, i];
                    xlWorkSheet.Cells[58, i + 3] = cell2.Value;
                }

                #endregion

                xlWorkBook.SaveAs("D:\\Database IPQC\\#" + line + "#" + descrip + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("Excel file created, you can find in the folder D:\\Database IPQC", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Workbooks.Open("D:\\Database IPQC\\#" + line + "#" + descrip + ".xlsx");
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process.");
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }

        public void exportExcelCheckCL(string model, string line, string user, string usl, string lsl, string process, string inspect, string sample, string descrip, DataGridView dgv, string dtpFrom, string dtpTo)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 2
            //Excel.Worksheet xlWorkSheet1; //sheet 1
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(@"D:\Database IPQC\Template-CheckUCL.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                #region Sheet 2
                //dt = new DataTable();
                //defineDt(ref dt);
                ////Add data in Sheet 1
                //xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);  //add data sheet1 
                //xlWorkSheet1.Cells[2, 2] = line; //Line
                //xlWorkSheet1.Cells[5, 2] = user; //User
                //xlWorkSheet1.Cells[1, 3] = process; //Process
                //xlWorkSheet1.Cells[1, 11] = descrip; //Description
                //xlWorkSheet1.Cells[5, 6] = lsl; //LSL, USL
                //xlWorkSheet1.Cells[5, 5] = usl;


                //int x = 0;
                //string[] n = new string[dgv.Rows.Count];
                //for (int i = 0; i < dgv.Rows.Count-1; i++)
                //{
                //    if (dgv[1, i].Value.ToString() != dgv[1, i + 1].Value.ToString())
                //    {
                //        x = x + 1;

                //        n[i] = dgv[1, i].Value.ToString();
                //        xlWorkSheet1.Cells[10, x + 2] = n[i];
                //    }
                //}            
                //string sql = "select a.scdl_day, a.m from " +
                //             "(select '1' as place, date_trunc('day', lot) as scdl_day, lot, m1 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and lot >= '" + dtpFrom + "' and lot < '" + dtpTo + "' and qc_user like 'user%' union all " +
                //             "select '2' as place, date_trunc('day', lot) as scdl_day, lot, m2 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and lot >= '" + dtpFrom + "' and lot < '" + dtpTo + "' and qc_user like 'user%' union all " +
                //             "select '3' as place, date_trunc('day', lot) as scdl_day, lot, m3 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + dtpFrom + "' and lot < '" + dtpTo + "' and qc_user like 'user%' union all " +
                //             "select '4' as place, date_trunc('day', lot) as scdl_day, lot, m4 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + dtpFrom + "' and lot < '" + dtpTo + "' and qc_user like 'user%' union all " +
                //             "select '5' as place, date_trunc('day', lot) as scdl_day, lot, m5 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + dtpFrom + "' and lot < '" + dtpTo + "' and qc_user like 'user%') a " +
                //             "order by a.lot, a.place";
                //TfSQL tf = new TfSQL();
                //tf.sqlDataAdapterFillDatatable(sql, ref dt);
                //int dem =0;
                //for(int i =0; i <= dt.Rows.Count-2;i++)
                //{
                //    if (dt.Rows[i][0].ToString() != dt.Rows[i + 1][0].ToString())
                //    {
                //        dem = i;
                //        for (int j = 0; j <= dem-1; j++)
                //        {
                //            xlWorkSheet1.Cells[j + 11, i + 3] = dt.Rows[j][1];
                //        }
                //    }
                //    //else break;
                //}
                ////for (int i = 0; i <= xlWorkSheet1.Range["C10:AG10"].Count; i++)
                ////{
                ////    string from = xlWorkSheet1.Cells[10, i + 3].Value.ToString("yyyy/MM/dd");
                ////    string to;
                ////    if (i + 1 == xlWorkSheet1.Range["C10:AG10"].Count)
                ////    {
                ////        to = xlWorkSheet1.Cells[10, i + 3].Value.ToString("yyyy/MM/dd");
                ////    }
                ////    else
                ////    {
                ////        to = xlWorkSheet1.Cells[10, i + 4].Value.ToString("yyyy/MM/dd");
                ////    }
                ////    string sql = "select a.scdl_day, a.m from " +
                ////             "(select '1' as place, date_trunc('day', lot) as scdl_day, lot, m1 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and lot >= '" + from + "' and lot < '" + to + "' and qc_user like 'user%' union all " +
                ////             "select '2' as place, date_trunc('day', lot) as scdl_day, lot, m2 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and lot >= '" + from + "' and lot < '" + to + "' and qc_user like 'user%' union all " +
                ////             "select '3' as place, date_trunc('day', lot) as scdl_day, lot, m3 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + from + "' and lot < '" + to + "' and qc_user like 'user%' union all " +
                ////             "select '4' as place, date_trunc('day', lot) as scdl_day, lot, m4 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + from + "' and lot < '" + to + "' and qc_user like 'user%' union all " +
                ////             "select '5' as place, date_trunc('day', lot) as scdl_day, lot, m5 as m from tbl_measure_history where inspect = '" + inspect + "' and line = '" + line + "' and  lot >= '" + from + "' and lot < '" + to + "' and qc_user like 'user%') a " +
                ////             "order by a.lot, a.place";
                ////    TfSQL tf = new TfSQL();
                ////    tf.sqlDataAdapterFillDatatable(sql, ref dt);

                ////    xlWorkSheet1.Cells[i + 8, 3] = (double)dt.Rows[i - 3][1];

                ////}
                #endregion

                #region Sheet 1
                //Add data in Sheet 1
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1
                xlWorkSheet.Cells[7, 18] = line; //Line
                xlWorkSheet.Cells[4, 3] = model; //Model
                xlWorkSheet.Cells[7, 21] = user; //User
                xlWorkSheet.Cells[7, 3] = process; //Process
                xlWorkSheet.Cells[9, 3] = descrip; //Description
                xlWorkSheet.Cells[7, 12] = lsl; //LSL, USL
                xlWorkSheet.Cells[7, 13] = usl;
                xlWorkSheet.Cells[7, 26] = sample; //Sample

                //datagridw
                for (int i = 0; i <= dgv.Rows.Count - 1; i++) //dong
                {
                    for (int j = 0; j < 5; j++) //cot
                    {
                        DataGridViewCell cell = dgv[j + 6, i]; //cot roi dong
                        xlWorkSheet.Cells[j + 17, i + 3] = cell.Value; // dong roi cot
                    }
                }

                //ngay, gio, status
                for (int i = 0; i <= dgv.Rows.Count - 1; i++)
                {
                    //ngay là 14:3
                    DataGridViewCell cell = dgv[1, i]; //cot roi dong
                    xlWorkSheet.Cells[15, i + 3] = cell.Value; // dong roi cot 

                    //giờ là 15:3
                    xlWorkSheet.Cells[16, i + 3] = cell.Value; // dong roi cot 

                    //status
                    DataGridViewCell cell1 = dgv[5, i];
                    xlWorkSheet.Cells[14, i + 3] = cell1.Value;

                    //repair
                    DataGridViewCell cell2 = dgv[4, i];
                    xlWorkSheet.Cells[58, i + 3] = cell2.Value;
                }

                #endregion

                xlWorkBook.SaveAs("D:\\Database IPQC\\#" + line + "#" + descrip + "#CheckCL.xlsx", Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("Excel file created, you can find in the folder D:\\Database IPQC", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Workbooks.Open("D:\\Database IPQC\\#" + line + "#" + descrip + "#CheckCL.xlsx");
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process.");
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }

        public void exportExcelIQC(tbl_part_box inBox, List<tbl_inspect_master> inMaster, List<tbl_inspect_data> inData)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet1;
            Excel.Worksheet xlWorkSheet2;
            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath + @"\Template\G2-QA-IQC-F074Rev01.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                #region ADD BOX INFO
                xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1
                xlWorkSheet1.Cells[3, 2] = inBox.part_name;
                xlWorkSheet1.Cells[4, 2] = inBox.part_number;
                xlWorkSheet1.Cells[5, 2] = inBox.model_cd;
                xlWorkSheet1.Cells[6, 2] = inBox.purpose_cmt;
                xlWorkSheet1.Cells[3, 15] = inBox.invoice;
                xlWorkSheet1.Cells[4, 15] = inBox.part_box_qty;
                xlWorkSheet1.Cells[5, 15] = inBox.part_box_lot;
                xlWorkSheet1.Cells[3, 20] = inBox.part_box_date.ToString("yyyy-MM-dd");
                xlWorkSheet1.Cells[4, 20] = inBox.vender_cd;
                xlWorkSheet1.Cells[5, 20] = inBox.incharge;
                xlWorkSheet1.Cells[6, 20] = inBox.incharge;
                xlWorkSheet1.Cells[8, 9] = "CP ITEMS (n = " + inBox.part_box_qty + ")";
                for (int i = 0; i < inMaster.Count; i++)
                {
                    if (i == 16) break;
                    xlWorkSheet1.Cells[9, 9 + i] = inMaster[i].inspect_cd;
                    xlWorkSheet1.Cells[10, 9 + i] = inMaster[i].inspect_tool;
                    xlWorkSheet1.Cells[11, 9 + i] = inMaster[i].inspect_spec;
                    xlWorkSheet1.Cells[12, 9 + i] = inMaster[i].tol_plus;
                    xlWorkSheet1.Cells[13, 9 + i] = inMaster[i].tol_minus;
                    int n = 0;
                    for (int j = 0; j < inData.Count; j++)
                    {
                        if (inData[j].inspect_id == inMaster[i].inspect_id)
                        {
                            n++;
                            if (inData[j].item_no == n)
                                xlWorkSheet1.Cells[15 + n, 9 + i] = inData[j].inspect_data;
                        }
                    }
                }
                if (inMaster.Count > 16)
                {
                    xlWorkSheet2 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2); //add data sheet2
                    xlWorkSheet2.Cells[3, 2] = inBox.part_name;
                    xlWorkSheet2.Cells[4, 2] = inBox.part_number;
                    xlWorkSheet2.Cells[5, 2] = inBox.model_cd;
                    xlWorkSheet2.Cells[6, 2] = inBox.purpose_cmt;
                    xlWorkSheet2.Cells[3, 9] = inBox.invoice;
                    xlWorkSheet2.Cells[4, 9] = inBox.part_box_qty;
                    xlWorkSheet2.Cells[5, 9] = inBox.part_box_lot;
                    xlWorkSheet2.Cells[3, 14] = inBox.part_box_date.ToString("yyyy-MM-dd");
                    xlWorkSheet2.Cells[4, 14] = inBox.vender_cd;
                    xlWorkSheet2.Cells[5, 14] = inBox.incharge;
                    xlWorkSheet2.Cells[6, 14] = inBox.incharge;
                    xlWorkSheet2.Cells[8, 2] = "CP ITEMS (n = " + inBox.part_box_qty + ")";
                    for (int i = 0; i < inMaster.Count - 16; i++)
                    {
                        xlWorkSheet2.Cells[9, 2 + i] = inMaster[i].inspect_cd;
                        xlWorkSheet2.Cells[10, 2 + i] = inMaster[i].inspect_tool;
                        xlWorkSheet2.Cells[11, 2 + i] = inMaster[i].inspect_spec;
                        xlWorkSheet2.Cells[12, 2 + i] = inMaster[i].tol_plus;
                        xlWorkSheet2.Cells[13, 2 + i] = inMaster[i].tol_minus;
                        int n = 0;
                        for (int j = 0; j < inData.Count; j++)
                        {
                            if (inData[j].inspect_id == inMaster[i].inspect_id)
                            {
                                n++;
                                if (inData[j].item_no == n)
                                    xlWorkSheet1.Cells[15 + n, 2 + i] = inData[j].inspect_data;
                            }
                        }
                    }
                }
                #endregion


                if (!Directory.Exists(@"C:\IQC_Excel")) Directory.CreateDirectory(@"C:\IQC_Excel");
                xlWorkBook.SaveAs(@"C:\IQC_Excel\" + inBox.part_box_cd + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("Excel file created, you can find in the folder C:\\IQC_Excel", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Workbooks.Open(@"C:\IQC_Excel\" + inBox.part_box_cd + ".xlsx");
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process.");
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}
