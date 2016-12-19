using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.CS.BizMetaDataManager.DAL;
using SinoSZJS.DataAccess;
using SinoSZJS.DataAccess.Sql;
using System.Data.SqlClient;

namespace SinoSZToolInputModelDefine
{
	public class ImportInputModelController
	{
		protected Dictionary<decimal, decimal> IDDict = new Dictionary<decimal, decimal>();
		protected DataSet ImportSourceDataSet = null;
		protected MD_Namespace CurrentNs = null;
		public  string ModelName = "";
		public ImportInputModelController(string FileName, MD_Namespace _ns)
		{
			ImportSourceDataSet = new DataSet();
			ImportSourceDataSet.ReadXml(FileName);
			CurrentNs = _ns;

		}


		public void Import()
		{
			OraMetaDataFactroy _of = new OraMetaDataFactroy();
			IDDict = new Dictionary<decimal, decimal>();

			//MD_INPUTVIEW 命名空间转换及ID转换
			DataTable TB_IV = ImportSourceDataSet.Tables["MD_INPUTVIEW"];
			foreach (DataRow _dr in TB_IV.Rows)
			{
				ModelName = _dr["IV_NAME"].ToString();
				_dr["NAMESPACE"] = CurrentNs.NameSpace;
				decimal _newid = decimal.Parse(_of.GetNewID());
				decimal _oldid = (decimal)_dr["IV_ID"];
				_dr["IV_ID"] = _newid;
				IDDict.Add(_oldid, _newid);
			}

			//其它各表的ID值转换
			

			DataTable TB_INPUTGROUP = ImportSourceDataSet.Tables["MD_INPUTGROUP"];
			foreach (DataRow _dr in TB_INPUTGROUP.Rows)
			{
				decimal _newid = decimal.Parse(_of.GetNewID());
				decimal _oldid = (decimal)_dr["IVG_ID"];
				_dr["IVG_ID"] = _newid;
				IDDict.Add(_oldid, _newid);
				_dr["IV_ID"] = IDDict[(decimal)_dr["IV_ID"]];
			}

			DataTable TB_INPUTVIEWCOLUMN = ImportSourceDataSet.Tables["MD_INPUTVIEWCOLUMN"];
			foreach (DataRow _dr in TB_INPUTVIEWCOLUMN.Rows)
			{
				decimal _newid = decimal.Parse(_of.GetNewID());
				decimal _oldid = (decimal)_dr["IVC_ID"];
				_dr["IVC_ID"] = _newid;
				IDDict.Add(_oldid, _newid);
				_dr["IV_ID"] = IDDict[(decimal)_dr["IV_ID"]];
				decimal _ivgid = (decimal)_dr["IVG_ID"];
				if (_ivgid != 0)
				{
					_dr["IVG_ID"] = IDDict[(decimal)_dr["IVG_ID"]];
				}

			}

			DataTable TB_INPUTTABLE = ImportSourceDataSet.Tables["MD_INPUTTABLE"];
			foreach (DataRow _dr in TB_INPUTTABLE.Rows)
			{
				decimal _newid = decimal.Parse(_of.GetNewID());
				decimal _oldid = (decimal)_dr["ID"];
				_dr["ID"] = _newid;
				IDDict.Add(_oldid, _newid);
				_dr["IV_ID"] = IDDict[(decimal)_dr["IV_ID"]];
			}


			DataTable TB_INPUTVIEWCHILD = ImportSourceDataSet.Tables["MD_INPUTVIEWCHILD"];
			foreach (DataRow _dr in TB_INPUTVIEWCHILD.Rows)
			{
				decimal _newid = decimal.Parse(_of.GetNewID());
				decimal _oldid = (decimal)_dr["ID"];
				_dr["ID"] = _newid;
				IDDict.Add(_oldid, _newid);
				_dr["IV_ID"] = IDDict[(decimal)_dr["IV_ID"]];
			}

			DataTable TB_INPUTTABLECOLUMN = ImportSourceDataSet.Tables["MD_INPUTTABLECOLUMN"];
			foreach (DataRow _dr in TB_INPUTTABLECOLUMN.Rows)
			{
				decimal _newid = decimal.Parse(_of.GetNewID());
				decimal _oldid = (decimal)_dr["ID"];
				_dr["ID"] = _newid;
				IDDict.Add(_oldid, _newid);
				_dr["IVT_ID"] = IDDict[(decimal)_dr["IVT_ID"]];
			}

			//写入数据库
			using (SqlConnection cn = DBHelper.OpenConnection())
			{
				SqlTransaction _txn = cn.BeginTransaction();
				try
				{
					SqlCommand _cmd = new SqlCommand("select * from md_inputview ", cn);
					SqlDataAdapter _oda = new SqlDataAdapter(_cmd);
					SqlCommandBuilder builder = new SqlCommandBuilder(_oda);
					_oda.Update(ResetState(TB_IV));
					
					_cmd = new SqlCommand("select * from md_inputgroup ", cn);
					_oda = new SqlDataAdapter(_cmd);
					builder = new SqlCommandBuilder(_oda);
					_oda.Update(ResetState(TB_INPUTGROUP));

					_cmd = new SqlCommand("select * from md_inputtable  ", cn);
					_oda = new SqlDataAdapter(_cmd);
					builder = new SqlCommandBuilder(_oda);
					_oda.Update(ResetState(TB_INPUTTABLE));

					_cmd = new SqlCommand("select * from md_inputtablecolumn", cn);
					_oda = new SqlDataAdapter(_cmd);
					builder = new SqlCommandBuilder(_oda);
					_oda.Update(ResetState(TB_INPUTTABLECOLUMN));

					_cmd = new SqlCommand("select * from md_inputviewchild  ", cn);
					_oda = new SqlDataAdapter(_cmd);
					builder = new SqlCommandBuilder(_oda);
					_oda.Update(ResetState(TB_INPUTVIEWCHILD));

					_cmd = new SqlCommand("select * from md_inputviewcolumn ", cn);
					_oda = new SqlDataAdapter(_cmd);
					builder = new SqlCommandBuilder(_oda);
					_oda.Update(ResetState(TB_INPUTVIEWCOLUMN));


					_txn.Commit();

				}
				catch (Exception e)
				{
					_txn.Rollback();
					//OralceLogWriter.WriteSystemLog(string.Format("在导入录入模型时出错，错误信息:{0}", e.Message), "ERROR");
					throw e;
				}
			}
		}

		private DataTable ResetState(DataTable _table)
		{
			DataTable _dt = _table.Copy();
			_dt.AcceptChanges();
			foreach (DataRow _dr in _dt.Rows)
			{
				_dr.SetAdded();
			}
			return _dt;
		}
	}
}
