using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SinoSZJS.Base.Misc;
using System.IO;
using System.Threading;
using System.Diagnostics;
using SinoSZJS.DataAccess;
using Microsoft.Office.Interop.Excel;


namespace SinoSZJS.CS.BizReport
{
        public class ProcessExcelReport
        {
                // Private data
		private static int tempIndex = 0;
		private static Application pExcelApp = null;
		private static int UseCount =0;
		private volatile static bool isBusy = false;
		private static DateTime  beforeTime = DateTime.Now;
		private static DateTime  afterTime = DateTime.Now;
		private Application m_oExcelApp;
		private Workbooks m_oBooks;
		private _Workbook m_oBook;
		private _Worksheet m_oSheet;
		private Sheets oSheets;
		private Range oCells;
		private object m_oMissing;
		private string m_sReportTemplate;
		private int m_nReportIndex;
		private string m_sDataTemplate;
		private string m_sExportFormat;
		private string m_sOutputCache;

		private int BaseRow = 1;
		private int BaseCol = 1;
		// Set properties
		public string ReportTemplate {
			get { return m_sReportTemplate; }
			set { m_sReportTemplate = value; }
		}

		public string DataTemplate {
			get { return m_sDataTemplate; }
			set { m_sDataTemplate = value; }
		}

		public int ReportIndex {
			get { return m_nReportIndex; }
			set { m_nReportIndex = value; }
		}

		public string ExportFormat {
			get { return m_sExportFormat; }
			set { m_sExportFormat = value; }
		}

		public string OutputCache {
			get { return m_sOutputCache; }
			set { m_sOutputCache = value; }
		}

		public static string Report_WebAppAddress = "";

                public ProcessExcelReport()
                {
			m_oExcelApp = null;
			m_oBooks = null;
			m_oBook = null;
			m_oSheet = null;
			m_oMissing = System.Reflection.Missing.Value;
			ReportIndex = 1;
		}

		private void FillReportData(System.Data.DataTable _rData, DataSet _hmcData) {
			Range m_oRange = null;
			Range m_oRange2 = null;


			try {
				//	2.行遍历,填写行名称
				int linenum = BaseRow;

				string oldLineType = "";
				System.Data.DataTable _rownameDt = _hmcData.Tables["ROW_DEFINE"];
				foreach (DataRow _dr in _rownameDt.Rows) {
					if (!_dr.IsNull("HBSFZ")) {
						string _fl = _dr["HBSFZ"].ToString();
						int _thishx = int.Parse(_dr["HX"].ToString()) + BaseRow;
						if (_thishx > linenum + 1) linenum = _thishx - 1;

						if (oldLineType == _fl) {
							//复制一行
							m_oRange = (Range) m_oSheet.Rows[linenum - 1, m_oMissing];
							m_oRange.Insert(XlDirection.xlDown, m_oMissing);
							m_oRange2 = (Range) m_oSheet.Rows[linenum - 1, m_oMissing];
							m_oRange.Copy(m_oRange2);

							//System.Runtime.InteropServices.Marshal.ReleaseComObject (m_oRange);
							//System.Runtime.InteropServices.Marshal.ReleaseComObject(m_oRange2);
						}
						else {
							oldLineType = _fl;
						}

						PutValueToCell(linenum, BaseCol, _dr["HMC"]);
					}
					linenum++;
				}

				//　2.行遍历，填写数据
				linenum = BaseRow;
				System.Data.DataTable _colnameDt = _hmcData.Tables["COL_DEFINE"];
				int _colCount = _colnameDt.Rows.Count;
				foreach (DataRow _rowdr in _rData.Rows) {
					for (int colnum = 0; colnum < _colCount; colnum++) {
						int _thishx = int.Parse(_rowdr["HX"].ToString()) + BaseRow;
						string _lx = string.Format("L{0}", colnum + 1);
						PutValueToCell(_thishx - 1, colnum + BaseCol + 1, _rowdr[_lx]);
					}
					linenum++;

				}
			}
			finally {
				if (m_oRange != null) {
					int _ret = System.Runtime.InteropServices.Marshal.ReleaseComObject(m_oRange);
                                        OralceLogWriter.WriteSystemLog(string.Format("执行关闭m_oRange！ret = {0}", _ret), "INFO");
				}

				if (m_oRange2 != null) {
					int _ret = System.Runtime.InteropServices.Marshal.ReleaseComObject(m_oRange2);
					OralceLogWriter.WriteSystemLog(string.Format("执行关闭m_oRange2！ret = {0}", _ret), "INFO");
				}

				GC.Collect();
				//				GC.WaitForPendingFinalizers();
				//				GC.Collect();
				//				GC.WaitForPendingFinalizers();
			}
		}

		public void FillHyperLinks(string _bbid, System.Data.DataTable _mxData, System.Data.DataTable _cellData, DataSet _hmcData) {
			int lfw = _hmcData.Tables["COL_DEFINE"].Rows.Count;
			int hfw = _hmcData.Tables["ROW_DEFINE"].Rows.Count;

			string _url = Report_WebAppAddress + "/Dialog/ShowReportDetial.aspx";

			//处理行列表
			foreach (DataRow _dr in _mxData.Rows) {
				int hx = int.Parse(_dr["HX"].ToString());
				int lx = int.Parse(_dr["LX"].ToString());
				if (hx > 0 && hx <= hfw && lx > 0 && lx <= lfw) {
					string _url2 = string.Format(@"{0}?HLX={1},{2}&REPORTID={3}", _url, hx, lx, _bbid);
					Microsoft.Office.Interop.Excel.Hyperlink _link = (Microsoft.Office.Interop.Excel.Hyperlink) m_oSheet.Hyperlinks.Add(m_oSheet.Cells[hx + BaseRow - 1, lx + BaseCol], _url2, m_oMissing, m_oMissing, m_oMissing);
					//System.Runtime.InteropServices.Marshal.ReleaseComObject (_link);
				}
			}

			//处理特别CELL表
			foreach (DataRow _dr in _cellData.Rows) {
				int _rownum = int.Parse(_dr["RPHX"].ToString());
				int _colnum = int.Parse(_dr["RPLX"].ToString());

				int _linkrownum = int.Parse(_dr["BBHX"].ToString());
				int _linkcolnum = int.Parse(_dr["BBLX"].ToString());

				string sfmx = _dr.IsNull("HASMX")? "0" : _dr["HASMX"].ToString();
				if (sfmx == "1") {
					string _url2 = string.Format(@"{0}?HLX={1},{2}&REPORTID={3}", _url, _linkrownum, _linkcolnum, _bbid);
					m_oSheet.Hyperlinks.Add(m_oSheet.Cells[_rownum, _colnum], _url2, m_oMissing, m_oMissing, m_oMissing);
				}

			}

		}

		public bool CreateReportFiles(string _bbid, System.Data.DataTable _rData, System.Data.DataTable _cellData, System.Data.DataTable _mxData, DataSet _hmcData, out string execelFile, out string htmFile, out string sMessage) {
			execelFile = "";
			htmFile = "";
			sMessage = "";
			string sDeleteFile = null;
			try {
				DataRow _dr = _hmcData.Tables["REPORT_DEFINE"].Rows[0];
				string _rdMeta = _dr["BBMETA"].ToString();
				string _brow = StrUtils.GetMetaByName("基准行", _rdMeta);
                                string _bcol = StrUtils.GetMetaByName("基准列", _rdMeta);

				if (_brow != "") BaseRow = int.Parse(_brow);
				if (_bcol != "") BaseCol = int.Parse(_bcol);

				// Get temporary file name
				execelFile = Utils.ExeDir + string.Format(@"OutputCache\{0}_{1}.xls", DateTime.Now.ToString("yyyyMMddhhmmss"), tempIndex ++);


				File.Copy(m_sReportTemplate, execelFile, true);
				m_sReportTemplate = execelFile;

				// Get valid report tempate
				OpenReportTempalte();

				//填数据
				FillReportData(_rData, _hmcData);

				//填CELL数据
				FillSpecialCessData(_cellData);

				//保存EXCEL文件
				m_oBook.Save();

				FillHyperLinks(_bbid, _mxData, _cellData, _hmcData);

				//保存为HTML文件
				// get file name with out path
				FileInfo oFInfo = new FileInfo(execelFile);
				htmFile = oFInfo.Name.Replace(".xls", ".mht");
				string sReportFileLocal = m_sOutputCache + Path.DirectorySeparatorChar.ToString() + htmFile;
				htmFile = sReportFileLocal;
				// Delete if html file already exists
				oFInfo = new FileInfo(sReportFileLocal);
				if (oFInfo.Exists)
					File.Delete(sReportFileLocal);

				// Export to HTML format
				m_oBook.SaveAs(sReportFileLocal, XlFileFormat.xlWebArchive, m_oMissing, m_oMissing, m_oMissing, m_oMissing,
				               XlSaveAsAccessMode.xlNoChange, m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing);


				// Done
				m_oBook.Save();
				return true;
			}
			catch (Exception exp) {
				sMessage = exp.Message;
				string _eStr = string.Format(" 系统在依据报表模板生成报表时发生错误！\n  Error Message:{0}", exp.Message);
				OralceLogWriter.WriteSystemLog(_eStr, "ERROR");
				return false;
			}
			finally {
				CloseReportTemplate();
				if (sDeleteFile != null)
					File.Delete(sDeleteFile);

			}


		}

		//填充特殊格
		private void FillSpecialCessData(System.Data.DataTable _celldata) {
			//	１.遍历CELLDATA表
			foreach (DataRow _dr in _celldata.Rows) {
				int _rownum = int.Parse(_dr["RPHX"].ToString());
				int _colnum = int.Parse(_dr["RPLX"].ToString());

				if (_dr["ZLX"].ToString() == "C") {
					//字符型
					PutValueToCell(_rownum, _colnum, _dr["Z_C"]);
				}
				else {
					//数值型
					PutValueToCell(_rownum, _colnum, _dr["Z_N"]);
				}
			}

		}

		private void PutValueToCell(int _rownum, int _colnum, object _value) {
			if (_value == DBNull.Value) {
				Range m_oRange2 = (Range) m_oSheet.Cells[_rownum, _colnum];

				if (m_oRange2.Formula.ToString().Length < 1) {
					m_oSheet.Cells[_rownum, _colnum] = "-";
				}
			}
			else {
				m_oSheet.Cells[_rownum, _colnum] = _value;
			}

		}


		public bool GetTestReport(out string sReportFile, out string sMessage) {
			sReportFile = null;
			sMessage = "";
			string sDeleteFile = null;
			try {
				// Get temporary file name
				sReportFile = Path.GetTempFileName();
				File.Copy(m_sReportTemplate, sReportFile, true);
				m_sReportTemplate = sReportFile;

				// Get valid report tempate
				OpenReportTempalte();

				// Get employee data
				DataSet oRptData = new DataSet();
				oRptData.ReadXml(m_sDataTemplate);

				// Write employee data to spreadsheet (Excel)
				int nRow = 2;
				foreach (DataRow oRow in oRptData.Tables["Group"].Rows) {
					m_oSheet.Cells[nRow, 1] = oRow["Name"];
					m_oSheet.Cells[nRow, 2] = oRow["TestA"];
					m_oSheet.Cells[nRow, 3] = oRow["TestB"];
					m_oSheet.Cells[nRow, 4] = oRow["TestC"];

					nRow++;
				}

				// Save data to temorary (sReportFile)
				if (m_sExportFormat.ToUpper().CompareTo("HTML") == 0) {
					// get file name with out path
					FileInfo oFInfo = new FileInfo(sReportFile);

					// set delete file to orginal file
					sDeleteFile = sReportFile;
					sReportFile = oFInfo.Name.Replace(".", "") + "_Export.htm";
					string sReportFileLocal = m_sOutputCache + Path.DirectorySeparatorChar.ToString() + sReportFile;

					// Delete if html file already exists
					oFInfo = new FileInfo(sReportFileLocal);
					if (oFInfo.Exists)
						File.Delete(sReportFileLocal);

					// Export to HTML format
					m_oBook.SaveAs(sReportFileLocal, XlFileFormat.xlHtml, m_oMissing, m_oMissing, m_oMissing, m_oMissing,
					               XlSaveAsAccessMode.xlNoChange, m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing);

				}
				else
					m_oBook.Save();
				CloseReportTemplate();
				// Done
				return true;
			}
			catch (Exception exp) {
				sMessage = exp.Message;
				return false;
			}
			finally {
				CloseReportTemplate();
				if (sDeleteFile != null)
					File.Delete(sDeleteFile);
			}
		}

		public void OpenReportTempalte() {
			if (m_oExcelApp != null)
				CloseReportTemplate();

			// Create an instance of Microsoft Excel, make it visible,
			// and open Book1.xls.
			//m_oExcelApp = new Excel.ApplicationClass();
			m_oExcelApp = GetExcelApplication();
			m_oBooks = m_oExcelApp.Workbooks;
			//m_oExcelApp.AskToUpdateLinks = false;

			// IMPORTANT: IF YOU ARE USING EXCEL Version >= 10.0 Use function 
			// prototype in "EXCEL VERSION 10.0" section. 
			// For Excel Version 9.0 use default "EXCEL VERSION = 9.0". 
			// This application is not tested with versions lower than Excel 9.0
			// Or greater than 10.0

			// EXCEL VERSION 10.0
			m_oBook = m_oBooks.Open(m_sReportTemplate, m_oMissing, m_oMissing,
			                        m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing,
			                        m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing);
			// END EXCEL VERSION 10.0

			// EXCEL VERSION 9.0
			//m_oBook = m_oBooks.Open(m_sReportTemplate, m_oMissing, m_oMissing,
			//	m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing, 
			//	m_oMissing, m_oMissing, m_oMissing, m_oMissing,m_oMissing,m_oMissing);
			// END EXCEL VERSION 9.0
			m_oSheet = (_Worksheet) m_oBook.Worksheets[m_nReportIndex];
		}

		private static Application GetExcelApplication() {
			int times =0;
			while (isBusy && times<6000) {
				Thread.Sleep(100);
				times ++;
			};
			isBusy = true;
			if (times>5999) {
				OralceLogWriter.WriteSystemLog("Excel 程序忙！",  "ERROR");
				return null;
			}

			if (UseCount >10) {
				ClearExcelApp();
				KillExcelThread();
				UseCount =0;
			}
			UseCount ++;
			if (pExcelApp == null) {
				beforeTime = DateTime.Now;
				pExcelApp = new Application();
				pExcelApp.Visible = false;
				pExcelApp.DisplayAlerts = false;
				afterTime = DateTime.Now;
			}
			
			return pExcelApp;
		}

		private static void KillExcelThread() {
			Process[] myProcesses;
			DateTime startTime;
			myProcesses = Process.GetProcessesByName("Excel");

			//得不到Excel进程ID，暂时只能判断进程启动时间
			foreach(Process myProcess in myProcesses) {
				startTime = myProcess.StartTime;

				if(startTime > beforeTime && startTime < afterTime) {
					myProcess.Kill();
				}
			}

		}

		private void CloseReportTemplate() {
			int _ret = -1;
			try {
				if (m_oBook != null)
					m_oBook.Close(true, m_sReportTemplate, m_oMissing);
				
				if (m_oExcelApp != null) {
					OralceLogWriter.WriteSystemLog(string.Format("执行关闭m_oExcelApp！ret = {0}", _ret), "INFO");
				}
				m_oExcelApp = null;
				m_oBooks = null;
				m_oBook = null;
                                oSheets = null;
				m_oSheet = null;
				oCells = null;
				
				OralceLogWriter.WriteSystemLog("完成关闭EXCEL进程！", "INFO");
				GC.Collect();
				isBusy = false;
				//				GC.WaitForPendingFinalizers();
				//				GC.Collect();
				//				GC.WaitForPendingFinalizers();

			}
			catch (Exception e) {
				OralceLogWriter.WriteSystemLog(string.Format("关闭EXCEL进程时出错！{0}", e.Message), "ERROR");
			}
			finally {
				GC.Collect();
				//				GC.WaitForPendingFinalizers();
				//				GC.Collect();
				//				GC.WaitForPendingFinalizers();

			}
		}

		public static void ClearExcelApp() {
			int _ret = -1;
			try {
				
				if (pExcelApp != null) {
					pExcelApp.Quit();
					ReleaseAllRef(pExcelApp);
					//_ret = System.Runtime.InteropServices.Marshal.ReleaseComObject(m_oExcelApp);
					OralceLogWriter.WriteSystemLog(string.Format("执行关闭m_oExcelApp！ret = {0}", _ret), "INFO");
					int generation = System.GC.GetGeneration(pExcelApp); 
					
				}
				pExcelApp = null;
				OralceLogWriter.WriteSystemLog("完成关闭EXCEL进程！", "INFO");
				GC.Collect();
				//				GC.WaitForPendingFinalizers();
				//				GC.Collect();
				//				GC.WaitForPendingFinalizers();

			}
			catch (Exception e) {
				OralceLogWriter.WriteSystemLog(string.Format("关闭EXCEL进程时出错！{0}", e.Message), "ERROR");
			}
			finally {
				GC.Collect();
				//				GC.WaitForPendingFinalizers();
				//				GC.Collect();
				//				GC.WaitForPendingFinalizers();

			}
		}

		private static void ReleaseAllRef(Object obj) {
			try {
				while (System.Runtime.InteropServices.Marshal.ReleaseComObject(obj) > 1) ;
			}

			finally {
				obj = null;
			}

		}

        }
}
