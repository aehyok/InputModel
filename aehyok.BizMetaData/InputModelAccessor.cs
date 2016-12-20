using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.MetaData.Define;
using System.Data.SqlClient;
using System.Data;
using SinoSZJS.DataAccess.Sql;
using aehyok.Dapper;
using SinoSZJS.Base.InputModel;
using SinoSZJS.Base.Misc;

namespace aehyok.BizMetaData
{
    public class InputModelAccessor
    {
        private const string SQL_GetInputModelOfNamespace = @"select IV_ID,NAMESPACE,IV_NAME,DESCRIPTION,DISPLAYNAME,DISPLAYORDER,IV_CS,TID,DELRULE,DWDM,INTEGRATEDAPP,RESTYPE
                                                                 from MD_INPUTVIEW where NAMESPACE = @NAMESPACE order by DISPLAYORDER";
        /// <summary>
        /// 通过命名空间获取录入模型列表
        /// </summary>
        /// <param name="_namespace"></param>
        /// <returns></returns>
        public static IList<MD_InputModel> GetInputModelOfNamespace(string _namespace)
        {
            IList<MD_InputModel> _ret = new List<MD_InputModel>();

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlCommand _cmd = new SqlCommand(SQL_GetInputModelOfNamespace, cn);
                _cmd.Parameters.Add("@NAMESPACE", _namespace);

                SqlDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    MD_InputModel _model = new MD_InputModel(
                                    _dr.IsDBNull(0) ? "" : _dr.GetDouble(0).ToString(),
                                    _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                    _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                    _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                                    _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                                    _dr.IsDBNull(5) ? (int)0 : Convert.ToInt32(_dr.GetDouble(5)),
                                    _dr.IsDBNull(6) ? "" : _dr.GetString(6),
                                    _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                                    _dr.IsDBNull(9) ? "" : _dr.GetString(9),
                                    _dr.IsDBNull(10) ? "" : _dr.GetString(10),
                                    _dr.IsDBNull(11) ? "" : _dr.GetString(11)
                    );
                    _ret.Add(_model);
                }
                _dr.Close();

                foreach (MD_InputModel _model in _ret)
                {
                    string _tname = StrUtils.GetMetaByName2("TABLE", _model.Param);
                    string _orderField = StrUtils.GetMetaByName2("ORDER", _model.Param);
                    string _modelType = StrUtils.GetMetaByName2("TYPE", _model.Param);
                    string _paramType = StrUtils.GetMetaByName2("PARAMTYPE", _model.Param);
                    _model.ModelType = (_modelType == "") ? "GRID" : _modelType.ToUpper();
                    _model.ParamterType = (_paramType == "") ? "OTHER" : _paramType.ToUpper();
                    _model.InitGuideLine = StrUtils.GetMetaByName2("INITZB", _model.Param);
                    _model.GetDataGuideLine = StrUtils.GetMetaByName2("GETZB", _model.Param);
                    _model.GetNewRecordGuideLine = StrUtils.GetMetaByName2("NEWZB", _model.Param);
                    _model.OrderField = _orderField;
                    _model.TableName = _tname;
                    _model.Groups = GetInputColumnGroups(_model, cn);
                    _model.WriteTableNames = GetWriteDesTableOfInputModel(_model);
                    _model.ChildInputModel = GetChildInputModel(_model);

                }
                cn.Close();
            }

            return _ret;
        }

        private const string SQL_GetWriteDesTableOfInputModel = @"select  ID,TABLENAME,TABLETITLE,ISLOCK,DISPLAYORDER,SAVEMODE
                                                                    from MD_INPUTTABLE where IV_ID = @IVID order by DISPLAYORDER";
        private static List<MD_InputModel_SaveTable> GetWriteDesTableOfInputModel(MD_InputModel _model)
        {
            List<MD_InputModel_SaveTable> _ret = new List<MD_InputModel_SaveTable>();
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlCommand _cmd = new SqlCommand(SQL_GetWriteDesTableOfInputModel, cn);
                _cmd.Parameters.Add("@IVID", _model.ID);
                SqlDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    MD_InputModel_SaveTable _tb = new MD_InputModel_SaveTable(
                                    _dr.IsDBNull(0) ? "" : _dr.GetDouble(0).ToString(),
                                    _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                    _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                    _dr.IsDBNull(3) ? true : (_dr.GetDouble(3) > 0),
                                    _model.ID,
                                    _dr.IsDBNull(4) ? 0 : Convert.ToInt32(_dr.GetDouble(4)),
                                    _dr.IsDBNull(5) ? "" : _dr.GetString(5)
                    );
                    GetInputModelSaveTableColumn(_tb);
                    _ret.Add(_tb);

                }
                _dr.Close();
            }
            return _ret;
        }

        private const string SQL_GetInputModelSaveTableColumn = @"select ID,SRCCOL,DESCOL,METHOD,DESDES from MD_INPUTTABLECOLUMN where IVT_ID=@TID";
        private static void GetInputModelSaveTableColumn(MD_InputModel_SaveTable _tb)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlCommand _cmd = new SqlCommand(SQL_GetInputModelSaveTableColumn, cn);
                _cmd.Parameters.Add("@TID", decimal.Parse(_tb.ID));
                SqlDataReader _dr = _cmd.ExecuteReader();
                if (_tb.Columns == null) _tb.Columns = new List<MD_InputModel_SaveTableColumn>();
                while (_dr.Read())
                {
                    MD_InputModel_SaveTableColumn _col = new MD_InputModel_SaveTableColumn(
                                    _dr.IsDBNull(0) ? "" : _dr.GetDouble(0).ToString(),
                                    _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                    _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                    _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                                     _dr.IsDBNull(4) ? "" : _dr.GetString(4)
                    );
                    _tb.Columns.Add(_col);
                }
                _dr.Close();
            }

        }

        private const string SQL_GetInputColumnGroups = @"select  IVG_ID,IV_ID,DISPLAYTITLE,DISPLAYORDER,GROUPTYPE,APPREGURL,GROUPCS
                                                            from md_inputgroup where IV_ID = @IVID order by DISPLAYORDER";
        private static List<MD_InputModel_ColumnGroup> GetInputColumnGroups(MD_InputModel _model, SqlConnection cn)
        {
            List<MD_InputModel_ColumnGroup> _ret = new List<MD_InputModel_ColumnGroup>();
            StringBuilder _sb = new StringBuilder();
            SqlCommand _cmd = new SqlCommand(SQL_GetInputColumnGroups, cn);
            _cmd.Parameters.Add("@IVID", _model.ID);
            SqlDataReader _dr = _cmd.ExecuteReader();
            while (_dr.Read())
            {
                MD_InputModel_ColumnGroup _g = new MD_InputModel_ColumnGroup(
                                _dr.IsDBNull(0) ? "" : _dr.GetDouble(0).ToString(),
                                _model.ID,
                                _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                _dr.IsDBNull(3) ? 0 : Convert.ToInt32(_dr.GetDouble(3))
                );
                _g.GroupType = _dr.IsDBNull(4) ? "DEFAULT" : _dr.GetString(4).ToUpper();
                _g.AppRegUrl = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                _g.GroupParam = _dr.IsDBNull(6) ? "" : _dr.GetString(6);
                _ret.Add(_g);

            }
            _dr.Close();
            return _ret;
        }

        private const string SQL_GetInputModel = @"select IV_ID,NAMESPACE,IV_NAME,DESCRIPTION,DISPLAYNAME,DISPLAYORDER,IV_CS,TID,DELRULE,DWDM,INTEGRATEDAPP,RESTYPE
                                                    from MD_INPUTVIEW where NAMESPACE = @NAMESPACE and IV_NAME=@IVNAME order by DISPLAYORDER";
        public static MD_InputModel GetInputModel(string _namespace, string ModelName)
        {
            MD_InputModel _model = null;
            StringBuilder _sb = new StringBuilder();
            _sb.Append("");
            _sb.Append(" ");

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlCommand _cmd = new SqlCommand(SQL_GetInputModel, cn);
                _cmd.Parameters.Add("@NAMESPACE", _namespace);
                _cmd.Parameters.Add("@IVNAME", ModelName);

                SqlDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    _model = new MD_InputModel(
                                    _dr.IsDBNull(0) ? "" : _dr.GetDouble(0).ToString(),
                                    _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                    _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                    _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                                    _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                                    _dr.IsDBNull(5) ? (int)0 : Convert.ToInt32(_dr.GetDouble(5)),
                                    _dr.IsDBNull(6) ? "" : _dr.GetString(6),
                                    _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                                    _dr.IsDBNull(9) ? "" : _dr.GetString(9),
                                    _dr.IsDBNull(10) ? "" : _dr.GetString(10),
                                    _dr.IsDBNull(11) ? "" : _dr.GetString(11)
                    );

                    string _tname = StrUtils.GetMetaByName2("TABLE", _model.Param);
                    string _orderField = StrUtils.GetMetaByName2("ORDER", _model.Param);
                    string _modelType = StrUtils.GetMetaByName2("TYPE", _model.Param);
                    string _paramType = StrUtils.GetMetaByName2("PARAMTYPE", _model.Param);
                    _model.ModelType = (_modelType == "") ? "GRID" : _modelType.ToUpper();
                    _model.ParamterType = (_paramType == "") ? "OTHER" : _paramType.ToUpper();
                    _model.InitGuideLine = StrUtils.GetMetaByName2("INITZB", _model.Param);
                    _model.GetDataGuideLine = StrUtils.GetMetaByName2("GETZB", _model.Param);
                    _model.GetNewRecordGuideLine = StrUtils.GetMetaByName2("NEWZB", _model.Param);
                    _model.OrderField = _orderField;
                    _model.TableName = _tname;
                    _model.WriteTableNames = GetWriteDesTableOfInputModel(_model);
                    _model.ChildInputModel = GetChildInputModel(_model);
                }
                _dr.Close();
                cn.Close();
            }

            return _model;
        }

        private const string SQL_GetChildInputModel = @"select  t.ID,t.IV_ID,t.CIV_ID,t.PARAM, iv.NAMESPACE CNS ,iv.IV_NAME CIVNAME,t. DISPLAYORDER,t.SHOWCONDITION,t.SELECTMODE
                                                        from MD_INPUTVIEWCHILD t,MD_INPUTVIEW iv  where t.IV_ID = @IVID and t.CIV_ID =iv.IV_ID 
                                                        order by t.DISPLAYORDER";
        public static List<MD_InputModel_Child> GetChildInputModel(MD_InputModel _model)
        {
            List<MD_InputModel_Child> _ret = new List<MD_InputModel_Child>();
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlCommand _cmd = new SqlCommand(SQL_GetChildInputModel, cn);
                _cmd.Parameters.Add("@IVID", _model.ID);
                SqlDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    string _cns = _dr.IsDBNull(4) ? "" : _dr.GetString(4);
                    string _cname = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                    string _paramstring = _dr.IsDBNull(3) ? "" : _dr.GetString(3);
                    MD_InputModel_Child _child = new MD_InputModel_Child(
                                    _dr.IsDBNull(0) ? "" : _dr.GetDouble(0).ToString(),
                                    string.Format("{0}.{1}", _model.NameSpace, _model.ModelName),
                                    string.Format("{0}.{1}", _cns, _cname),
                                    _dr.IsDBNull(6) ? 0 : Convert.ToInt32(_dr.GetDouble(6))
                    );
                    _child.ShowCondition = _dr.IsDBNull(7) ? "" : _dr.GetString(7);
                    _child.SelectMode = _dr.IsDBNull(8) ? 0 : Convert.ToInt16(_dr.GetDouble(8));
                    _child.ChildModel = GetInputModel(_cns, _cname);
                    if (_child.Parameters == null) _child.Parameters = new List<MD_InputModel_ChildParam>();
                    foreach (string _pstr in StrUtils.GetMetasByName2("PARAM", _paramstring))
                    {
                        string[] _s = _pstr.Split(':');
                        MD_InputModel_ChildParam _p = new MD_InputModel_ChildParam(_s[0], _s[1], _s[2]);
                        _child.Parameters.Add(_p);
                    }

                    _ret.Add(_child);

                }
                _dr.Close();
            }
            return _ret;
        }

        private const string SQL_SaveInputModel = @"update MD_INPUTVIEW
                                                    set IV_NAME=@IV_NAME,DESCRIPTION=@DESCRIPTION,
                                                    DISPLAYNAME=@DISPLAYNAME,DISPLAYORDER=@DISPLAYORDER,IV_CS=@IV_CS,
                                                    DELRULE=@DELRULE,DWDM=@DWDM,INTEGRATEDAPP=@INTEGRATEDAPP,RESTYPE=@RESTYPE,
                                                    BEFOREWRITE=@BEFOREWRITE,AFTERWRITE=@AFTERWRITE
                                                    where IV_ID =@IV_ID ";
        public static bool SaveInputModel(MD_InputModel SaveModel)
        {
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand _cmd = new SqlCommand(SQL_SaveInputModel, cn);
                    _cmd.Parameters.Add("@IV_NAME", SaveModel.ModelName);
                    _cmd.Parameters.Add("@DESCRIPTION", SaveModel.Descript);
                    _cmd.Parameters.Add("@DISPLAYNAME", SaveModel.DisplayName);
                    _cmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(SaveModel.DisplayOrder));
                    StringBuilder _cs = new StringBuilder();
                    _cs.Append(string.Format("<TABLE>{0}</TABLE>", SaveModel.TableName));
                    _cs.Append(string.Format("<ORDER>{0}</ORDER>", SaveModel.OrderField));
                    _cs.Append(string.Format("<TYPE>{0}</TYPE>", SaveModel.ModelType));
                    _cs.Append(string.Format("<PARAMTYPE>{0}</PARAMTYPE>", SaveModel.ParamterType));
                    _cs.Append(string.Format("<INITZB>{0}</INITZB>", SaveModel.InitGuideLine));
                    _cs.Append(string.Format("<GETZB>{0}</GETZB>", SaveModel.GetDataGuideLine));
                    _cs.Append(string.Format("<NEWZB>{0}</NEWZB>", SaveModel.GetNewRecordGuideLine));
                    _cmd.Parameters.Add("@IV_CS", _cs.ToString());
                    _cmd.Parameters.Add("@DELRULE", SaveModel.DeleteRule);
                    _cmd.Parameters.Add("@DWDM", SaveModel.DWDM);
                    _cmd.Parameters.Add("@INTEGRATEDAPP", SaveModel.IntegretedApplication);
                    _cmd.Parameters.Add("@RESTYPE", SaveModel.ResourceType);
                    _cmd.Parameters.Add("@BEFOREWRITE", SaveModel.BeforeWrite);
                    _cmd.Parameters.Add("@AFTERWRITE", SaveModel.AfterWrite);
                    _cmd.Parameters.Add("@IV_ID", SaveModel.ID);
                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private const string SQL_SaveNewInputModel = @"INSERT INTO MD_INPUTVIEW
                                                        (IV_ID,NAMESPACE,IV_NAME,DESCRIPTION,
                                                        DISPLAYNAME,DISPLAYORDER,IV_CS,TID,
                                                        DELRULE,DWDM ) values 
                                                        (@IV_ID,@NAMESPACE,@IV_NAME,@DESCRIPTION,
                                                        @DISPLAYNAME,@DISPLAYORDER,@IV_CS,null,
                                                        @DELRULE,@DWDM ) ";
        public static bool SaveNewInputModel(string _namespace, MD_InputModel SaveModel)
        {
            try
            {

                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand _cmd = new SqlCommand(SQL_SaveNewInputModel, cn);
                    _cmd.Parameters.Add("@IV_ID", SequenceAccessor.GetNewId());
                    _cmd.Parameters.Add("@NAMESPACE", _namespace);
                    _cmd.Parameters.Add("@IV_NAME", SaveModel.ModelName);
                    _cmd.Parameters.Add("@DESCRIPTION", SaveModel.Descript);

                    _cmd.Parameters.Add("@DISPLAYNAME", SaveModel.DisplayName);
                    _cmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(SaveModel.DisplayOrder));

                    StringBuilder _cs = new StringBuilder();
                    _cs.Append(string.Format("<TABLE>{0}</TABLE>", SaveModel.TableName));
                    _cs.Append(string.Format("<ORDER>{0}</ORDER>", SaveModel.OrderField));
                    _cs.Append(string.Format("<TYPE>{0}</TYPE>", SaveModel.ModelType));
                    _cs.Append(string.Format("<PARAMTYPE>{0}</PARAMTYPE>", SaveModel.ParamterType));
                    _cs.Append(string.Format("<INITZB>{0}</INITZB>", SaveModel.InitGuideLine));
                    _cs.Append(string.Format("<GETZB>{0}</GETZB>", SaveModel.GetDataGuideLine));
                    _cs.Append(string.Format("<NEWZB>{0}</NEWZB>", SaveModel.GetNewRecordGuideLine));

                    _cmd.Parameters.Add("@IV_CS", _cs.ToString());
                    _cmd.Parameters.Add("@DELRULE", SaveModel.DeleteRule);
                    _cmd.Parameters.Add("@DWDM", SaveModel.DWDM);
                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                LogWriter.WriteSystemLog(e.Message, "ERROR");
                return false;
            }
        }

        public static bool DelInputModel(string InputModelID)
        {
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand _cmd = new SqlCommand("delete MD_INPUTVIEW  where IV_ID=@IV_ID", cn);
                    _cmd.Parameters.Add("@IV_ID", decimal.Parse(InputModelID));

                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        private const string SQL_InputModel_MoveColumnToGroup = @"update MD_INPUTVIEWCOLUMN set IVG_ID=@IVGID where IVC_ID=@IVCID ";
        public static bool InputModel_MoveColumnToGroup(MD_InputModel_Column _col, MD_InputModel_ColumnGroup InputModelColumnGroup)
        {
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand _cmd = new SqlCommand(SQL_InputModel_MoveColumnToGroup, cn);
                    _cmd.Parameters.Add("@IVGID", decimal.Parse(InputModelColumnGroup.GroupID));
                    _cmd.Parameters.Add("@IVCID", decimal.Parse(_col.ColumnID));

                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        private const string SQL_DelInputModelColumnGroup_ups = @"update MD_INPUTVIEWCOLUMN set IVG_ID=0 where IV_ID=@IVID and IVG_ID=@IVGID";
        private const string SQL_DelInputModelColumnGroup_del = @"delete md_inputgroup where IVG_ID=@IVID";
        public static bool DelInputModelColumnGroup(string InputModelID, string GroupID)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_DelInputModelColumnGroup_ups, cn, _txn);
                    _cmd.Parameters.Add("@IVID", decimal.Parse(InputModelID));
                    _cmd.Parameters.Add("@IVGID", decimal.Parse(GroupID));
                    _cmd.ExecuteNonQuery();


                    _cmd = new SqlCommand(SQL_DelInputModelColumnGroup_del, cn, _txn);
                    _cmd.Parameters.Add("@IVID", decimal.Parse(GroupID));
                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }

        private const string SQL_AddNewInputModelGroup = @"INSERT INTO MD_INPUTGROUP
                                                            (IVG_ID,IV_ID,DISPLAYTITLE,DISPLAYORDER,GROUPTYPE,APPREGURL,GROUPCS) values
                                                            (@IVG_ID,@IV_ID,@DISPLAYTITLE,@DISPLAYORDER,@GROUPTYPE,@APPREGURL,@GROUPCS)";
        public static bool AddNewInputModelGroup(MD_InputModel_ColumnGroup Group)
        {
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand _cmd = new SqlCommand(SQL_AddNewInputModelGroup, cn);
                    _cmd.Parameters.Add("@IVG_ID", Group.GroupID);
                    _cmd.Parameters.Add("@IV_ID", Group.ModelID);
                    _cmd.Parameters.Add("@DISPLAYTITLE", Group.DisplayTitle);
                    _cmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(Group.DisplayOrder));
                    _cmd.Parameters.Add("@GROUPTYPE", string.Empty);
                    _cmd.Parameters.Add("@APPREGURL", string.Empty);
                    _cmd.Parameters.Add("@GROUPCS", string.Empty);
                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                LogWriter.WriteSystemLog(string.Format("插入录入模型的分组[{0}]记录时出错！{1}", Group.GroupID, e.Message), "ERROR");
                return false;
            }
        }

        private const string SQL_SaveInputModelColumnGroup = @"update  MD_INPUTGROUP set  DISPLAYTITLE=@DISPLAYTITLE,GROUPTYPE=@GROUPTYPE,APPREGURL=@APPREGURL,GROUPCS=@GROUPCS,
                                                                        DISPLAYORDER=@DISPLAYORDER where IVG_ID=@IVG_ID ";
        private const string SQL_SaveInputModelColumnGroup_ups = @"update MD_INPUTVIEWCOLUMN 
                                    set DWDM=@DWDM,INPUTDEFAULT=@INPUTDEFAULT,INPUTRULE=@INPUTRULE,CANEDITRULE=@CANEDITRULE ,
                                    CANDISPLAY=@CANDISPLAY,COLUMNNAME=@COLUMNNAME,COLUMNORDER=@COLUMNORDER,COLUMNTYPE=@COLUMNTYPE ,
                                    READONLY=@READONLY,DISPLAYNAME=@DISPLAYNAME,ISCOMPUTE=@ISCOMPUTE,COLUMNWIDTH=@COLUMNWIDTH,
                                    COLUMNHEIGHT=@COLUMNHEIGHT,TEXTALIGNMENT=@TEXTALIGNMENT,EDITFORMAT=@EDITFORMAT,DISPLAYFORMAT=@DISPLAYFORMAT,
                                    REQUIRED=@REQUIRED,TOOLTIP=@TOOLTIP,DATACHANGEDEVENT=@DATACHANGEDEVENT,MAXLENGTH=@MAXLENGTH,DEFAULTSHOW=@DEFAULTSHOW 
                                     where IVC_ID=@IVC_ID";
        public static bool SaveInputModelColumnGroup(MD_InputModel_ColumnGroup Group)
        {
            SqlCommand _cmd;

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {

                    if (Group.GroupID != "0")
                    {
                        _cmd = new SqlCommand(SQL_SaveInputModelColumnGroup, cn, _txn);
                        _cmd.Parameters.Add("@DISPLAYTITLE", Group.DisplayTitle);
                        _cmd.Parameters.Add("@GROUPTYPE", Group.GroupType);
                        _cmd.Parameters.Add("@APPREGURL", Group.AppRegUrl);
                        _cmd.Parameters.Add("@GROUPCS", Group.GroupParam);
                        _cmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(Group.DisplayOrder));

                        _cmd.Parameters.Add("@IVG_ID", decimal.Parse(Group.GroupID));
                        _cmd.ExecuteNonQuery();
                    }


                    foreach (MD_InputModel_Column _col in Group.Columns)
                    {
                        _cmd = new SqlCommand(SQL_SaveInputModelColumnGroup_ups, cn, _txn);
                        _cmd.Parameters.Add("@DWDM", _col.DWDM);
                        _cmd.Parameters.Add("@INPUTDEFAULT", _col.DefaultValue);
                        _cmd.Parameters.Add("@INPUTRULE", _col.InputRule);
                        _cmd.Parameters.Add("@CANEDITRULE", _col.CanEditRule);

                        _cmd.Parameters.Add("@CANDISPLAY", (_col.CanDisplay) ? "Y" : "N");
                        _cmd.Parameters.Add("@COLUMNNAME", _col.ColumnName);
                        _cmd.Parameters.Add("@COLUMNORDER", Convert.ToInt32(_col.DisplayOrder));
                        _cmd.Parameters.Add("@COLUMNTYPE", _col.ColumnType);

                        _cmd.Parameters.Add("@READONLY", (_col.ReadOnly) ? (decimal)1 : (decimal)0);
                        _cmd.Parameters.Add("@DISPLAYNAME", _col.DisplayName);
                        _cmd.Parameters.Add("@ISCOMPUTE", (_col.IsCompute) ? (decimal)1 : (decimal)0);
                        _cmd.Parameters.Add("@COLUMNWIDTH", Convert.ToInt32(_col.Width));

                        _cmd.Parameters.Add("@COLUMNHEIGHT", Convert.ToInt32(_col.LineHeight));
                        _cmd.Parameters.Add("@TEXTALIGNMENT", Convert.ToInt32(_col.TextAlign));
                        _cmd.Parameters.Add("@EDITFORMAT", _col.EditFormat);
                        _cmd.Parameters.Add("@DISPLAYFORMAT", _col.DisplayFormat);

                        _cmd.Parameters.Add("@REQUIRED", (_col.Required) ? (decimal)1 : (decimal)0);
                        _cmd.Parameters.Add("@TOOLTIP", _col.ToolTipText);
                        _cmd.Parameters.Add("@DATACHANGEDEVENT", _col.DataChangedEvent);
                        _cmd.Parameters.Add("@MAXLENGTH", Convert.ToDecimal(_col.MaxInputLength));
                        _cmd.Parameters.Add("@DEFAULTSHOW", _col.DefaultShow ? (decimal)1 : (decimal)0);

                        _cmd.Parameters.Add("@IVC_ID", decimal.Parse(_col.ColumnID));
                        _cmd.ExecuteNonQuery();

                    }
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }

        private const string SQL_FindInputModelColumnByName = @"select count(*) from  md_inputviewcolumn
                                                                where IV_ID=@IVID AND COLUMNNAME=@CNAME  ";
        public static bool FindInputModelColumnByName(string InputModelID, string ColumnName)
        {
            decimal _ret = 0;
            try
            {

                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand _cmd = new SqlCommand(SQL_FindInputModelColumnByName, cn);
                    _cmd.Parameters.Add("@IV_ID", decimal.Parse(InputModelID));
                    _cmd.Parameters.Add("@CNAME", ColumnName);
                    _ret = (decimal)_cmd.ExecuteScalar();
                }
                return _ret > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        private const string SQL_AddNewInputModelColumn = @"INSERT INTO md_inputviewcolumn
                                                            (IVC_ID,IV_ID,TCID,COLUMNNAME,
                                                            CANDISPLAY,COLUMNORDER,COLUMNTYPE,READONLY,
                                                            DISPLAYNAME,ISCOMPUTE,COLUMNWIDTH,COLUMNHEIGHT,
                                                            TEXTALIGNMENT,IVG_ID ) values
                                                             (@IVC_ID,@IV_ID,0,@COLUMNNAME,
                                                             'Y',0,'VARCHAR',0,
                                                             @DISPLAYNAME,0,1,1,
                                                            0,@IVG_ID ) ";
        public static bool AddNewInputModelColumn(string InputModelID, string GroupID, string ColumnName)
        {
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand _cmd = new SqlCommand(SQL_AddNewInputModelColumn, cn);
                    _cmd.Parameters.Add("@IVC_ID", decimal.Parse(SequenceAccessor.GetNewId()));
                    _cmd.Parameters.Add("@IV_ID", decimal.Parse(InputModelID));
                    _cmd.Parameters.Add("@COLUMNNAME", ColumnName);
                    _cmd.Parameters.Add("@DISPLAYNAME", ColumnName);
                    _cmd.Parameters.Add("@IVG_ID", decimal.Parse(GroupID));
                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private const string SQL_DelInputModelColumn = @"DELETE  FROM md_inputviewcolumn WHERE IVC_ID=@IVC_ID";
        public static bool DelInputModelColumn(string ColumnID)
        {
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand _cmd = new SqlCommand(SQL_DelInputModelColumn, cn);
                    _cmd.Parameters.Add("@IVC_ID", decimal.Parse(ColumnID));

                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        private const string SQL_AddNewInputModelSavedTable = @"insert into  md_inputtable
                                                                (ID,TABLENAME,IV_ID,ISLOCK,TABLETITLE,DISPLAYORDER) values 
                                                                (@ID,@TABLENAME,@IV_ID,1,@TABLETITLE,0)     ";
        public static bool AddNewInputModelSavedTable(string InputModelID, string TableName)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {

                    SqlCommand _cmd = new SqlCommand(SQL_AddNewInputModelSavedTable, cn, _txn);
                    _cmd.Parameters.Add("@ID", decimal.Parse(SequenceAccessor.GetNewId()));
                    _cmd.Parameters.Add("@TABLENAME", TableName);
                    _cmd.Parameters.Add("@IV_ID", decimal.Parse(InputModelID));
                    _cmd.Parameters.Add("@TABLETITLE", TableName);

                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }

        public static bool DelInputModelSavedTable(string TableID)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {
                    SqlCommand _delCmd = new SqlCommand("delete from md_inputtablecolumn where IVT_ID=@ID", cn);
                    _delCmd.Parameters.Add("@ID", decimal.Parse(TableID));
                    _delCmd.ExecuteNonQuery();

                    SqlCommand _cmd = new SqlCommand("delete from  md_inputtable where id=@ID", cn);
                    _cmd.Parameters.Add("@ID", decimal.Parse(TableID));
                    _cmd.ExecuteNonQuery();

                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }

        private const string SQL_SaveInputModelSaveTable = @"update MD_INPUTTABLE
                                                                    set TABLETITLE=:TABLETITLE,DISPLAYORDER=:DISPLAYORDER,ISLOCK=:ISLOCK,SAVEMODE=:SAVEMODE
                                                                    where ID=@ID ";
        private const string SQL_SaveInputModelSaveTable_ins = @"insert into MD_INPUTTABLECOLUMN
                                                            (ID,IVT_ID,DESCOL,SRCCOL,METHOD,DESDES) values
                                                            (@ID,@IVT_ID,@DESCOL,@SRCCOL,@METHOD,@DESDES)  ";
        public static bool SaveInputModelSaveTable(MD_InputModel_SaveTable _newTable)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {
                    SqlCommand _upCmd = new SqlCommand(SQL_SaveInputModelSaveTable, cn);
                    _upCmd.Parameters.Add("@TABLETITLE", _newTable.TableTitle);
                    _upCmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(_newTable.DisplayOrder));
                    _upCmd.Parameters.Add("@ISLOCK", _newTable.IsLock ? (decimal)1 : (decimal)0);
                    _upCmd.Parameters.Add("@SAVEMODE", _newTable.SaveMode);
                    _upCmd.Parameters.Add("@ID", decimal.Parse(_newTable.ID));
                    _upCmd.ExecuteNonQuery();


                    SqlCommand _cmd = new SqlCommand("delete from  MD_INPUTTABLECOLUMN where IVT_ID=@ID", cn);
                    _cmd.Parameters.Add("@ID", decimal.Parse(_newTable.ID));
                    _cmd.ExecuteNonQuery();

                    foreach (MD_InputModel_SaveTableColumn _col in _newTable.Columns)
                    {
                        SqlCommand _insCmd = new SqlCommand(SQL_SaveInputModelSaveTable_ins, cn);
                        _insCmd.Parameters.Add("@ID", decimal.Parse(_col.ID));
                        _insCmd.Parameters.Add("@IVT_ID", decimal.Parse(_newTable.ID));
                        _insCmd.Parameters.Add("@DESCOL", _col.DesColumn);
                        _insCmd.Parameters.Add("@SRCCOL", _col.SrcColumn);
                        _insCmd.Parameters.Add("@METHOD", _col.Method);
                        _insCmd.Parameters.Add("@DESDES", _col.Descript);
                        _insCmd.ExecuteNonQuery();

                    }
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }

        public static bool AddInputModelTableColumn(string TableName, string AddFieldName, string DataType)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {
                    string _sql = string.Format("Alter Table {0} add {1} {2} ", TableName, AddFieldName, DataType);
                    SqlHelper.ExecuteNonQuery(cn, CommandType.Text, _sql);
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }

        public static bool DelInputModelTableColumn(string TableName, string DelFieldName)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {
                    string _sql = string.Format("Alter Table {0} drop column {1} ", TableName, DelFieldName);
                    SqlHelper.ExecuteNonQuery(cn, CommandType.Text, _sql);
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }

        private const string SQL_GetDBPrimayKeyList = @"SELECT TABLE_NAME,COLUMN_NAME,COLUMN_POSITION  FROM XTV_PK_COLUMNS T
                                                        WHERE T.TABLE_NAME=UPPER(@TNAME) )";
        public static List<string> GetDBPrimayKeyList(string TableName)
        {
            List<string> _ret = new List<string>();

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {

                try
                {
                    SqlParameter[] _param = {
                                        new SqlParameter("@NAME", SqlDbType.NVarChar)};
                    _param[0].Value = TableName;
                    using (SqlDataReader _dr = SqlHelper.ExecuteReader(cn, CommandType.Text, SQL_GetDBPrimayKeyList, _param))
                    {
                        while (_dr.Read())
                        {
                            string _cname = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                            _ret.Add(_cname);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogWriter.WriteSystemLog(string.Format("在取数据表的主键时发生错误，错误信息：{0}", e.Message), "ERROR");
                    return _ret;
                }
            }
            return _ret;
        }

        public static bool AddChildInputModel(string MainModelID, string ChildModelID)
        {
            string _sql = "insert into md_inputviewchild (id,iv_id,civ_id,param,displayorder) values (sequences_meta.nextval,@IV_ID,@CIV_ID,'',0)";
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(_sql, cn);
                    _cmd.Parameters.Add("@IV_ID", decimal.Parse(MainModelID));
                    _cmd.Parameters.Add("@CIV_ID", decimal.Parse(ChildModelID));
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public static bool SaveInputModelChildDefine(MD_InputModel_Child InputModelChild)
        {
            string _sql = "update md_inputviewchild  set param=@PARAM ,displayorder=@DISPLAYORDER,SHOWCONDITION=@SHOWCONDITION,SELECTMODE=@SELECTMODE where ID=@ID";
            string _pstr = "";
            foreach (MD_InputModel_ChildParam _p in InputModelChild.Parameters)
            {
                _pstr += string.Format("<PARAM>{0}:{1}:{2}</PARAM>", _p.Name, _p.DataType, _p.Value);
            }

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(_sql, cn);
                    _cmd.Parameters.Add("@PARAM", _pstr);
                    _cmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(InputModelChild.DisplayOrder));
                    _cmd.Parameters.Add("@SHOWCONDITION", InputModelChild.ShowCondition);
                    _cmd.Parameters.Add("@SELECTMODE", Convert.ToDecimal(InputModelChild.SelectMode));
                    _cmd.Parameters.Add("@ID", decimal.Parse(InputModelChild.ID));
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
