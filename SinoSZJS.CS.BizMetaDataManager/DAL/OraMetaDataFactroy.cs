using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.SystemLog;
using System.Diagnostics;
using SinoSZJS.DataAccess;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.InputModel;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.EnumDefine;
using SinoSZJS.Base.IMetaData;
using SinoSZJS.DataAccess.Sql;
using System.Data.SqlClient;
using aehyok.BizMetaData;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
    public class OraMetaDataFactroy : IMetaDataFactroy
    {

        #region IMetaDataFactroy Members
        private const string SQL_GetQueryModelByName = @"select VIEWID,NAMESPACE,VIEWNAME,DESCRIPTION,DISPLAYNAME,DWDM,IS_GDCX,IS_GLCX,IS_SJSH,DISPLAYORDER,ICSTYPE,EXTMETA
                                                        from MD_VIEW where VIEWNAME = @VIEWNAME order by DISPLAYORDER";
        public MD_QueryModel GetQueryModelByName(string modelName)
        {
            string[] _ms = modelName.Split('.');
            if (_ms.Length > 1)
            {
                return GetQueryModelByName(_ms[1], _ms[0]);
            }
            else
            {
                MD_QueryModel modelInfo = null;
                StringBuilder _sb = new StringBuilder();

                SqlParameter[] _param = {
                                                                new SqlParameter("@VIEWNAME",SqlDbType.NVarChar,50)
                                };

                _param[0].Value = modelName;

                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetQueryModelByName, _param);

                IList<MD_QueryModel> nodeItems = new List<MD_QueryModel>();

                while (dr.Read())
                {
                    modelInfo = new MD_QueryModel(dr.GetDouble(0).ToString(), dr.GetString(1), dr.GetString(2),
                                    dr.IsDBNull(3) ? "" : dr.GetString(3), dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5),
                                    dr.IsDBNull(6) ? false : dr.GetDouble(6) > 0, dr.IsDBNull(7) ? false : dr.GetDouble(7) > 0,
                                    dr.IsDBNull(8) ? false : dr.GetDouble(8) > 0, dr.IsDBNull(9) ? 0 : Convert.ToInt32(dr.GetDouble(9)),
                                    dr.IsDBNull(10) ? "ORA_JSIS" : dr.GetString(10));

                    modelInfo.EXTMeta = dr.IsDBNull(11) ? "" : dr.GetString(11);
                }
                dr.Close();

                return modelInfo;
            }
        }

        private const string SQL_GetQueryModelByName2 = @"select VIEWID,NAMESPACE,VIEWNAME,DESCRIPTION,DISPLAYNAME,DWDM,IS_GDCX,IS_GLCX,IS_SJSH,DISPLAYORDER,ICSTYPE,EXTMETA
                                                            from MD_VIEW where NAMESPACE = @NAMESPACE and VIEWNAME = @VIEWNAME order by DISPLAYORDER";
        public MD_QueryModel GetQueryModelByName(string modelName, string nameSpace)
        {
            MD_QueryModel modelInfo = null;
            StringBuilder _sb = new StringBuilder();

            SqlParameter[] _param = {
                                new SqlParameter("@NAMESPACE", SqlDbType.NVarChar, 50),
                                new SqlParameter("@VIEWNAME",SqlDbType.NVarChar,50)
                        };
            _param[0].Value = nameSpace;
            _param[1].Value = modelName;
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(cn, CommandType.Text, SQL_GetQueryModelByName2, _param))
                {
                    IList<MD_QueryModel> nodeItems = new List<MD_QueryModel>();

                    while (dr.Read())
                    {
                        modelInfo = new MD_QueryModel(dr.GetDouble(0).ToString(), dr.GetString(1), dr.GetString(2),
                                        dr.IsDBNull(3) ? "" : dr.GetString(3), dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5),
                                        dr.IsDBNull(6) ? false : dr.GetDouble(6) > 0, dr.IsDBNull(7) ? false : dr.GetDouble(7) > 0,
                                        dr.IsDBNull(8) ? false : dr.GetDouble(8) > 0, dr.IsDBNull(9) ? 0 : Convert.ToInt32(dr.GetDouble(9)),
                                        dr.IsDBNull(10) ? "ORA_JSIS" : dr.GetString(10));

                        modelInfo.EXTMeta = dr.IsDBNull(11) ? "" : dr.GetString(11);
                    }
                    dr.Close();
                }
            }
            return modelInfo;
        }

        public MD_QueryModelGroup GetQueryModelGroup(string queryModelGroupID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MD_QueryModelGroup GetQueryModelGroup(string queryModelGroupID, string nameSpace)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MD_RefTable GetRefTable(string refTableName)
        {
            MD_RefTable _ret = null;
            SqlParameter[] _param;
            string[] _ctNames = refTableName.Split('.');

            StringBuilder _sb = new StringBuilder();
            _sb.Append("select RTID,NAMESPACE,REFTABLENAME,REFTABLELEVELFORMAT,DESCRIPTION,DWDM,DOWNLOADMODE,REFTABLEMODE,HIDECODE ");
            _sb.Append(" from md_reftablelist where REFTABLENAME =@TNAME");
            if (_ctNames.Length > 1)
            {
                _sb.Append(" and NAMESPACE=@NAMESPACE ");

                _param = new SqlParameter[] {
                                                new SqlParameter("@TNAME",SqlDbType.NVarChar,50),
                                                new SqlParameter("@NAMESPACE",SqlDbType.NVarChar,50) };
                _param[0].Value = _ctNames[1];
                _param[1].Value = _ctNames[0];
            }
            else
            {
                _param = new SqlParameter[] {
                                                new SqlParameter("@TNAME",SqlDbType.NVarChar,50)};
                _param[0].Value = _ctNames[0];
            }


            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            while (dr.Read())
            {
                _ret = new MD_RefTable(dr.GetDouble(0).ToString(), dr.GetString(1), dr.GetString(2),
                                   dr.IsDBNull(3) ? "" : dr.GetString(3), dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5),
                                   dr.IsDBNull(6) ? 0 : Convert.ToInt32(dr.GetDouble(6)),
                                   dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetDouble(7)),
                                   dr.IsDBNull(8) ? false : (dr.GetDouble(8) > 0));

            }
            dr.Close();

            return _ret;
        }

        public MD_RefTable GetRefTable(string refTableName, string nameSpace)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MD_QueryModel GetQueryModelByID(string modelID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MD_QueryModel GetQueryModelByID(string modelID, string nameSpace)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion


        #region IMetaDataFactroy Members

        #endregion

        #region aehyok.BizMetaData
        public IList<MD_Nodes> GetNodeList()
        {
            return NodeAccessor.GetNodeList();
        }

        public IList<MD_Namespace> GetNameSpaceAtNode(string _nodeDWDM)
        {
            return NameSpaceAccessor.GetNameSpace(_nodeDWDM);
        }

        public bool SaveNodes(MD_Nodes _nodes)
        {
            NodeAccessor.SaveNodes(_nodes);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool SaveNameSapce(MD_Namespace _ns)
        {
            NameSpaceAccessor.UpdateNameSapce(_ns);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool SaveNewNodes(MD_Nodes _nodes)
        {
            NodeAccessor.AddNewNode(_nodes);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool DelNodes(string _nodeID)
        {
            NodeAccessor.DelelteNode(_nodeID);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool DelNamespace(MD_Namespace _ns)
        {
            NameSpaceAccessor.DelelteNamespace(_ns);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool SaveNewNameSapce(MD_Namespace _ns)
        {
            NameSpaceAccessor.AddNewNameSapce(_ns);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }
        #endregion


        #region IMetaDataFactroy Members


        public IList<DB_TableMeta> GetDBTableList()
        {
            string cmdStr = "select TC.table_name TNAME,TC.comments COMMENTS,tc.table_type TYPE,tc.OWNER from ALL_TAB_COMMENTS TC where OWNER ='ZHTJ' or OWNER='JSODS'";
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                IList<DB_TableMeta> tableList = new List<DB_TableMeta>();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(cn, CommandType.Text, cmdStr))
                {

                    while (dr.Read())
                    {
                        string _tanme = dr.GetString(0);
                        string _owner = dr.GetString(3);
                        string _comment = dr.IsDBNull(1) ? "" : dr.GetString(1);
                        string _type = dr.GetString(2);

                        DB_TableMeta nodeInfo = new DB_TableMeta();
                        nodeInfo.TableName = string.Format("{0}.{1}", _owner, _tanme);
                        nodeInfo.TableComment = _comment;
                        nodeInfo.TableType = _type;
                        tableList.Add(nodeInfo);
                    }
                    dr.Close();
                }
                return tableList;
            }

        }

        public IList<DB_TableMeta> GetDBTableListOfDMB()
        {
            string cmdStr = "select TC.table_name TNAME,TC.comments COMMENTS,tc.table_type TYPE,tc.OWNER from ALL_TAB_COMMENTS TC where (OWNER='JSODS') ";
            cmdStr += " and TABLE_NAME LIKE 'DM%' ";
            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, cmdStr);

            IList<DB_TableMeta> tableList = new List<DB_TableMeta>();

            while (dr.Read())
            {
                string _tanme = dr.GetString(0);
                string _owner = dr.GetString(3);
                string _comment = dr.IsDBNull(1) ? "" : dr.GetString(1);
                string _type = dr.GetString(2);

                DB_TableMeta nodeInfo = new DB_TableMeta();
                nodeInfo.TableName = string.Format("{0}.{1}", _owner, _tanme);
                nodeInfo.TableComment = _comment;
                nodeInfo.TableType = _type;
                tableList.Add(nodeInfo);
            }
            dr.Close();
            return tableList;
        }

        #endregion

        #region IMetaDataFactroy Members

        public bool SaveNewTable(DB_TableMeta _tm, MD_Namespace _ns)
        {
            string InsertStr = "insert into MD_TABLE (TID,NAMESPACE,TABLENAME,TABLETYPE,DESCRIPTION,DISPLAYNAME,DWDM) VALUES ";
            InsertStr += "( sequences_meta.nextval,@NAMESPACE,@TABLENAME,@TABLETYPE,@DESCRIPTION,@DISPLAYNAME,@DWDM)";

            SqlParameter[] _param = {
                                new SqlParameter("@NAMESPACE", SqlDbType.NVarChar, 50),
                                new SqlParameter("@TABLENAME", SqlDbType.NVarChar, 50),
                                new SqlParameter("@TABLETYPE", SqlDbType.NVarChar, 50),
                                new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 100),
                                new SqlParameter("@DISPLAYNAME", SqlDbType.NVarChar, 100),
                                new SqlParameter("@DWDM", SqlDbType.NVarChar, 12)
                        };
            _param[0].Value = _ns.NameSpace;
            _param[1].Value = _tm.TableName;
            _param[2].Value = _tm.TableType;
            _param[3].Value = _tm.TableComment;
            _param[4].Value = _tm.TableName;
            _param[5].Value = _ns.DWDM;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, InsertStr, _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_GetTablesAtNamespace = @"select TID,NAMESPACE,TABLENAME,TABLETYPE,DESCRIPTION,DISPLAYNAME,MAINKEY,DWDM,
                                                            SECRETFUN,EXTSECRET,RESTYPE from MD_TABLE where NAMESPACE = @NAMESPACE order by DISPLAYNAME";
        public IList<MD_Table> GetTablesAtNamespace(string NsName)
        {
            SqlParameter[] _param = {
                                new SqlParameter("@NAMESPACE", SqlDbType.NVarChar, 50),
                        };
            _param[0].Value = NsName;

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetTablesAtNamespace, _param);

            IList<MD_Table> nodeItems = new List<MD_Table>();

            while (dr.Read())
            {
                MD_Table nodeInfo = new MD_Table(dr.GetDouble(0).ToString(), dr.GetString(1), dr.GetString(2), dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5), dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? "" : dr.GetString(7), dr.IsDBNull(8) ? "" : dr.GetString(8), dr.IsDBNull(9) ? "" : dr.GetString(9),
                                dr.IsDBNull(10) ? "" : dr.GetString(10));
                nodeItems.Add(nodeInfo);
            }
            dr.Close();

            return nodeItems;
        }
        public IList<MD_Table> GetTablesAtNamespace(MD_Namespace _ns)
        {
            return GetTablesAtNamespace(_ns.NameSpace);
        }

        private const string SQL_GetTableByTableID = @"select TID,NAMESPACE,TABLENAME,TABLETYPE,DESCRIPTION,DISPLAYNAME,MAINKEY,DWDM,
                                                         SECRETFUN,EXTSECRET,RESTYPE from MD_TABLE where TID=@TID";
        public MD_Table GetTableByTableID(string _tid)
        {
            MD_Table _ret = null;

            SqlParameter[] _param = {
                                new SqlParameter("@TID", OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_tid);

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetTableByTableID, _param);



            while (dr.Read())
            {
                _ret = new MD_Table(dr.GetDouble(0).ToString(), dr.GetString(1), dr.GetString(2), dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5), dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? "" : dr.GetString(7), dr.IsDBNull(8) ? "" : dr.GetString(8), dr.IsDBNull(9) ? "" : dr.GetString(9),
                                dr.IsDBNull(10) ? "" : dr.GetString(10));

            }
            dr.Close();

            return _ret;
        }

        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_GetQueryModelAtNamespace = @"select VIEWID,NAMESPACE,VIEWNAME,DESCRIPTION,DISPLAYNAME,DWDM,IS_GDCX,IS_GLCX,IS_SJSH,DISPLAYORDER,ICSTYPE,EXTMETA
                                                                from MD_VIEW where NAMESPACE = @NAMESPACE order by DISPLAYORDER";
        public IList<MD_QueryModel> GetQueryModelAtNamespace(string NsName)
        {
            SqlParameter[] _param = {
                                new SqlParameter("@NAMESPACE", SqlDbType.NVarChar, 50),
                        };
            _param[0].Value = NsName;

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetQueryModelAtNamespace, _param);

            IList<MD_QueryModel> nodeItems = new List<MD_QueryModel>();

            while (dr.Read())
            {
                MD_QueryModel nodeInfo = new MD_QueryModel(dr.GetDouble(0).ToString(), dr.GetString(1), dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3), dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(6) ? false : dr.GetDouble(6) > 0, dr.IsDBNull(7) ? false : dr.GetDouble(7) > 0,
                                dr.IsDBNull(8) ? false : dr.GetDouble(8) > 0, dr.IsDBNull(9) ? 0 : Convert.ToInt32(dr.GetDouble(9)),
                                dr.IsDBNull(10) ? "ORA_JSIS" : dr.GetString(10));
                nodeInfo.EXTMeta = dr.IsDBNull(11) ? "" : dr.GetString(11);
                nodeItems.Add(nodeInfo);

            }
            dr.Close();

            return nodeItems;
        }
        public IList<MD_QueryModel> GetQueryModelAtNamespace(MD_Namespace _ns)
        {
            return GetQueryModelAtNamespace(_ns.NameSpace);
        }

        #endregion

        #region IMetaDataFactroy Members

        public IList<MD_RefTable> GetRefTableAtNamespace(MD_Namespace _ns)
        {
            return GetRefTableAtNamespace(_ns.NameSpace);
        }
        public IList<MD_RefTable> GetRefTableAtNamespace(string _ns)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("select RTID,NAMESPACE,REFTABLENAME,REFTABLELEVELFORMAT,DESCRIPTION,DWDM,DOWNLOADMODE,REFTABLEMODE ,HIDECODE");
            _sb.Append(" from MD_REFTABLELIST where NAMESPACE = @NAMESPACE order by REFTABLENAME");

            SqlParameter[] _param = {
                                new SqlParameter("@NAMESPACE", SqlDbType.NVarChar, 50),
                        };
            _param[0].Value = _ns;

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            IList<MD_RefTable> nodeItems = new List<MD_RefTable>();

            while (dr.Read())
            {
                MD_RefTable nodeInfo = new MD_RefTable(dr.GetDouble(0).ToString(), dr.GetString(1), dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3), dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(6) ? 0 : Convert.ToInt32(dr.GetDouble(6)),
                                dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetDouble(7)),
                                dr.IsDBNull(8) ? false : (dr.GetDouble(8) > 0));
                nodeItems.Add(nodeInfo);

            }
            dr.Close();

            return nodeItems;
        }



        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_GetColumnOfTable = @"select TCID,TID,COLUMNNAME,ISNULLABLE,TYPE,PRECISION,SCALE,LENGTH,REFDMB,
                                                        DMBLEVELFORMAT,SECRETLEVEL,DISPLAYTITLE,DISPLAYFORMAT,DISPLAYLENGTH,DISPLAYHEIGHT,
                                                        DISPLAYORDER,CANDISPLAY,COLWIDTH, DWDM,CTAG,REFWORDTB
                                                         from MD_TABLECOLUMN where TCID = @TCID order by DISPLAYORDER";
        public MD_TableColumn GetColumnOfTable(string _tcid)
        {
            MD_TableColumn nodeInfo = null;
            SqlParameter[] _param = {
                                new SqlParameter("@TCID", OracleDbType.Decimal),
                        };
            _param[0].Value = decimal.Parse(_tcid);

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetColumnOfTable, _param);
            while (dr.Read())
            {
                nodeInfo = new MD_TableColumn(
                               dr.GetDouble(0).ToString(), dr.GetDouble(1).ToString(), dr.GetString(2),
                               dr.IsDBNull(3) ? true : ((dr.GetString(3) == "Y") ? true : false),
                               dr.GetString(4),
                               dr.IsDBNull(5) ? 1 : Convert.ToInt32(dr.GetDouble(5)),
                               dr.IsDBNull(6) ? 1 : Convert.ToInt32(dr.GetDouble(6)),
                               dr.IsDBNull(7) ? 1 : Convert.ToInt32(dr.GetDouble(7)),
                               dr.IsDBNull(8) ? "" : dr.GetString(8),
                               dr.IsDBNull(9) ? "" : dr.GetString(9),
                               dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetDouble(10)),
                               dr.IsDBNull(11) ? "" : dr.GetString(11),
                               dr.IsDBNull(12) ? "" : dr.GetString(12),
                               dr.IsDBNull(13) ? 0 : Convert.ToInt32(dr.GetDouble(13)),
                               dr.IsDBNull(14) ? 0 : Convert.ToInt32(dr.GetDouble(14)),
                               dr.IsDBNull(15) ? 0 : Convert.ToInt32(dr.GetDouble(15)),
                               dr.IsDBNull(16) ? false : dr.GetDouble(16) > 0,
                               dr.IsDBNull(17) ? 0 : Convert.ToInt32(dr.GetDouble(17)),
                               dr.IsDBNull(18) ? "" : dr.GetString(18),
                               dr.IsDBNull(19) ? "" : dr.GetString(19),
                               dr.IsDBNull(20) ? "" : dr.GetString(20)
                               );
            }
            dr.Close();
            return nodeInfo;
        }

        public IList<MD_TableColumn> GetColumnsOfTable(string _tid)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("select TCID,TID,COLUMNNAME,");
            _sb.Append(" ISNULLABLE,TYPE,PRECISION,");
            _sb.Append(" SCALE,LENGTH,REFDMB,");
            _sb.Append(" DMBLEVELFORMAT,SECRETLEVEL,DISPLAYTITLE,");
            _sb.Append(" DISPLAYFORMAT,DISPLAYLENGTH,DISPLAYHEIGHT,");
            _sb.Append(" DISPLAYORDER,CANDISPLAY,COLWIDTH,");
            _sb.Append(" DWDM,CTAG,REFWORDTB");
            _sb.Append(" from MD_TABLECOLUMN where TID = @TID order by DISPLAYORDER");

            SqlParameter[] _param = {
                                new SqlParameter("@TID", OracleDbType.Decimal),
                        };
            _param[0].Value = decimal.Parse(_tid);

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            IList<MD_TableColumn> nodeItems = new List<MD_TableColumn>();

            while (dr.Read())
            {
                MD_TableColumn nodeInfo = new MD_TableColumn(
                                dr.GetDouble(0).ToString(), dr.GetDouble(1).ToString(), dr.GetString(2),
                                dr.IsDBNull(3) ? true : ((dr.GetString(3) == "Y") ? true : false),
                                dr.GetString(4),
                                dr.IsDBNull(5) ? 1 : Convert.ToInt32(dr.GetDouble(5)),
                                dr.IsDBNull(6) ? 1 : Convert.ToInt32(dr.GetDouble(6)),
                                dr.IsDBNull(7) ? 1 : Convert.ToInt32(dr.GetDouble(7)),
                                dr.IsDBNull(8) ? "" : dr.GetString(8),
                                dr.IsDBNull(9) ? "" : dr.GetString(9),
                                dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetDouble(10)),
                                dr.IsDBNull(11) ? "" : dr.GetString(11),
                                dr.IsDBNull(12) ? "" : dr.GetString(12),
                                dr.IsDBNull(13) ? 0 : Convert.ToInt32(dr.GetDouble(13)),
                                dr.IsDBNull(14) ? 0 : Convert.ToInt32(dr.GetDouble(14)),
                                dr.IsDBNull(15) ? 0 : Convert.ToInt32(dr.GetDouble(15)),
                                dr.IsDBNull(16) ? false : dr.GetDouble(16) > 0,
                                dr.IsDBNull(17) ? 0 : Convert.ToInt32(dr.GetDouble(17)),
                                dr.IsDBNull(18) ? "" : dr.GetString(18),
                                dr.IsDBNull(19) ? "" : dr.GetString(19),
                                dr.IsDBNull(20) ? "" : dr.GetString(20)
                                );
                nodeItems.Add(nodeInfo);
            }
            dr.Close();

            return nodeItems;
        }

        #endregion

        #region IMetaDataFactroy Members

        public MD_ViewTable GetMainTableOfQueryModel(MD_QueryModel _qm)
        {
            return GetMainTableOfQueryModel(_qm.QueryModelID);
        }

        private const string SQL_GetMainTableOfQueryModel = @"select vt.VTID,vt.VIEWID,vt.TID,
                                                                vt.TABLETYPE,vt.TABLERELATION,vt.CANCONDITION,
                                                                vt.DISPLAYNAME,vt.DISPLAYORDER,vt.DWDM,
                                                                vt.FATHERID,vt.PRIORITY,vt.DISPLAYTYPE,vt.INTEGRATEDAPP,v.namespace
                                                                from MD_VIEWTABLE vt
                                                                join MD_VIEW V on  v.viewid=vt.viewid
                                                                where vt.VIEWID = @VID and vt.TABLETYPE = 'M' order by vt.DISPLAYORDER";
        public MD_ViewTable GetMainTableOfQueryModel(string QueryModelID)
        {
            MD_ViewTable _vt = null;

            SqlParameter[] _param = {
                                new SqlParameter("@VID", OracleDbType.Decimal),
                        };
            _param[0].Value = decimal.Parse(QueryModelID);

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetMainTableOfQueryModel, _param);

            while (dr.Read())
            {
                _vt = new MD_ViewTable(dr.GetDouble(0).ToString(),
                                dr.GetDouble(1).ToString(),
                                dr.GetDouble(2).ToString(),
                                dr.IsDBNull(3) ? "M" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetDouble(7)),
                                dr.IsDBNull(8) ? "" : dr.GetString(8),
                                dr.IsDBNull(9) ? "" : dr.GetDouble(9).ToString(),
                                dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetDouble(10)),
                                dr.IsDBNull(11) ? 0 : Convert.ToInt32(dr.GetDouble(11)),
                                dr.IsDBNull(12) ? "" : dr.GetString(12)

                                );
                _vt.NamespaceName = dr.IsDBNull(13) ? "" : dr.GetString(13);
            }
            dr.Close();
            if (_vt != null)
            {
                _vt.Table = GetTableByTableID(_vt.TableID);
                _vt.TableName = _vt.Table.TableName;
                _vt.Columns = GetColumnsOfViewTable(_vt);
            }
            return _vt;
        }

        private const string SQL_GetColumnsOfViewTable = @"select VTC.VTCID,VTC.VTID,VTC.TCID,VTC.CANCONDITIONSHOW,VTC.CANRESULTSHOW,VTC.DEFAULTSHOW,VTC.FIXQUERYITEM,VTC.CANMODIFY,
                                                           VTC.dwdm,VTC.PRIORITY,VTC.DISPLAYORDER VTCORDER from MD_VIEWTABLECOLUMN VTC where VTC.VTID = @VTID ";
        private IList<MD_ViewTableColumn> GetColumnsOfViewTable(MD_ViewTable _vt)
        {
            IList<MD_ViewTableColumn> nodeItems = new List<MD_ViewTableColumn>();
            MD_ViewTableColumn nodeInfo;
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlCommand _cmd = new SqlCommand(SQL_GetColumnsOfViewTable, cn);
                _cmd.Parameters.Add("@VTID", _vt.ViewTableID);
                SqlDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    nodeInfo = new MD_ViewTableColumn(
                       _dr.IsDBNull(0) ? "" : _dr.GetDouble(0).ToString(),
                       _dr.IsDBNull(1) ? "" : _dr.GetDouble(1).ToString(),
                       _dr.IsDBNull(2) ? "" : _dr.GetDouble(2).ToString(),
                       _dr.IsDBNull(3) ? false : _dr.GetDouble(3) > 0,
                       _dr.IsDBNull(4) ? false : _dr.GetDouble(4) > 0,
                       _dr.IsDBNull(5) ? false : _dr.GetDouble(5) > 0,
                       _dr.IsDBNull(6) ? false : _dr.GetDouble(6) > 0,
                       _dr.IsDBNull(7) ? false : _dr.GetDouble(7) > 0,
                       _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                       _dr.IsDBNull(9) ? 0 : Convert.ToInt32(_dr.GetDouble(9)),
                       _dr.IsDBNull(10) ? 0 : Convert.ToInt32(_dr.GetDouble(10))
                       );
                    nodeInfo.TableColumn = GetColumnOfTable(nodeInfo.ColumnID);
                    nodeInfo.TID = _vt.TableID;
                    nodeInfo.TableName = _vt.TableName;
                    nodeItems.Add(nodeInfo);
                }
                _dr.Close();


            }
            #region 旧的方法，已经废弃
            /*
                        StringBuilder _sb = new StringBuilder();
                        _sb.Append("select TC.TCID,TC.TID,TC.COLUMNNAME,");
                        _sb.Append(" TC.ISNULLABLE,TC.TYPE,TC.PRECISION,");
                        _sb.Append(" TC.SCALE,TC.LENGTH,TC.REFDMB,");
                        _sb.Append(" TC.DMBLEVELFORMAT,TC.SECRETLEVEL,TC.DISPLAYTITLE,");
                        _sb.Append(" TC.DISPLAYFORMAT,TC.DISPLAYLENGTH,TC.DISPLAYHEIGHT,");
                        _sb.Append(" TC.DISPLAYORDER,TC.CANDISPLAY,TC.COLWIDTH,");
                        _sb.Append(" TC.DWDM,TC.CTAG,TC.REFWORDTB,");
                        _sb.Append(" VTC.VTCID,VTC.CANCONDITIONSHOW,VTC.CANRESULTSHOW,");
                        _sb.Append(" VTC.DEFAULTSHOW,VTC.FIXQUERYITEM,VTC.CANMODIFY, ");
                        _sb.Append(" VTC.PRIORITY,VTC.DISPLAYORDER VTCORDER");
                        _sb.Append(" from MD_TABLECOLUMN TC,MD_VIEWTABLECOLUMN VTC where VTC.VTID = :VTID ");
                        _sb.Append(" and TC.TCID = VTC.TCID order by VTC.DISPLAYORDER,tc.displayorder");

                        SqlParameter[] _param = {
                                new SqlParameter(":VTID", OracleDbType.Decimal),
                        };
                        _param[0].Value = decimal.Parse(_vtid);

                        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

                        IList<MD_ViewTableColumn> nodeItems = new List<MD_ViewTableColumn>();

                        while (dr.Read())
                        {
                                decimal _dorder = (dr.IsDBNull(28) || (dr.GetDouble(28) == 0)) ?
                                                (dr.IsDBNull(15) ? (decimal)0 : dr.GetDouble(15)) : dr.GetDouble(28);
                                //此处要做大的修改！分两步，先取ViewTableColumn的数据，再取TableColumn的数据

                                MD_ViewTableColumn nodeInfo = new MD_ViewTableColumn(
                                                dr.GetDouble(0).ToString(), dr.GetDouble(1).ToString(), dr.GetString(2),
                                                dr.IsDBNull(3) ? true : ((dr.GetString(3) == "Y") ? true : false),
                                                dr.GetString(4),
                                                dr.IsDBNull(5) ? 1 : Convert.ToInt32(dr.GetDouble(5).Value),
                                                dr.IsDBNull(6) ? 1 : Convert.ToInt32(dr.GetDouble(6).Value),
                                                dr.IsDBNull(7) ? 1 : Convert.ToInt32(dr.GetDouble(7).Value),
                                                dr.IsDBNull(8) ? "" : dr.GetString(8),
                                                dr.IsDBNull(9) ? "" : dr.GetString(9),
                                                dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetDouble(10).Value),
                                                dr.IsDBNull(11) ? "" : dr.GetString(11),
                                                dr.IsDBNull(12) ? "" : dr.GetString(12),
                                                dr.IsDBNull(13) ? 0 : Convert.ToInt32(dr.GetDouble(13).Value),
                                                dr.IsDBNull(14) ? 0 : Convert.ToInt32(dr.GetDouble(14).Value),
                                                Convert.ToInt32(_dorder),
                                                dr.IsDBNull(16) ? false : dr.GetDouble(16).Value > 0,
                                                dr.IsDBNull(17) ? 0 : Convert.ToInt32(dr.GetDouble(17).Value),
                                                dr.IsDBNull(18) ? "" : dr.GetString(18),
                                                dr.IsDBNull(19) ? "" : dr.GetString(19),
                                                dr.IsDBNull(20) ? "" : dr.GetString(20),
                                                dr.GetDouble(21).ToString(),
                                                dr.IsDBNull(22) ? false : dr.GetDouble(22).Value > 0,
                                                dr.IsDBNull(23) ? false : dr.GetDouble(23).Value > 0,
                                                dr.IsDBNull(24) ? false : dr.GetDouble(24).Value > 0,
                                                dr.IsDBNull(25) ? false : dr.GetDouble(25).Value > 0,
                                                dr.IsDBNull(26) ? false : dr.GetDouble(26).Value > 0,
                                                dr.IsDBNull(27) ? 0 : Convert.ToInt32(dr.GetDouble(27).Value)
                                                );
                                nodeItems.Add(nodeInfo);

                        }
                        dr.Close();
                    */
            #endregion


            return nodeItems;
        }


        public bool AddMainTableToQueryModel(string _queryModelID, MD_Table _selectedTable)
        {
            string InsertStr = "insert into MD_VIEWTABLE (VTID,VIEWID,TID,TABLETYPE,CANCONDITION,DISPLAYNAME,DWDM) VALUES ";
            InsertStr += "( sequences_meta.nextval,@VIEWID,@TID,'M',1,@DISPLAYNAME,@DWDM)";

            SqlParameter[] _param = {
                                new SqlParameter("@VIEWID", OracleDbType.Decimal),
                                new SqlParameter("@TID", OracleDbType.Decimal),
                                new SqlParameter("@DISPLAYNAME", SqlDbType.NVarChar,100),
                                new SqlParameter("@DWDM", SqlDbType.NVarChar,12),
                        };
            _param[0].Value = decimal.Parse(_queryModelID);
            _param[1].Value = decimal.Parse(_selectedTable.TID);
            _param[2].Value = _selectedTable.DisplayTitle;
            _param[3].Value = _selectedTable.DWDM;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, InsertStr, _param);
            return true;
        }

        public bool AddChildTableToQueryModel(string _queryModelID, string _mainTableID, MD_Table _selectedTable)
        {
            string InsertStr = "insert into MD_VIEWTABLE (VTID,VIEWID,TID,TABLETYPE,CANCONDITION,DISPLAYNAME,DWDM,FATHERID) VALUES";
            InsertStr += " (sequences_meta.nextval,@VIEWID,@TID,'F',1,@DISPLAYNAME,@DWDM,@FATHERID)";
            SqlParameter[] _param = {
                                new SqlParameter("@VIEWID", OracleDbType.Decimal),
                                new SqlParameter("@TID", OracleDbType.Decimal),
                                new SqlParameter("@DISPLAYNAME", SqlDbType.NVarChar,100),
                                new SqlParameter("@DWDM", SqlDbType.NVarChar,12),
                                new SqlParameter("@FATHERID",OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_queryModelID);
            _param[1].Value = decimal.Parse(_selectedTable.TID);
            _param[2].Value = _selectedTable.DisplayTitle;
            _param[3].Value = _selectedTable.DWDM;
            _param[4].Value = decimal.Parse(_mainTableID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, InsertStr, _param);
            return true;


        }

        #endregion

        #region IMetaDataFactroy Members




        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_GetDBColumnsOfTable = @"select col.column_name,COMM.COMMENTS,col.data_type,col.nullable,col.DATA_LENGTH,col.DATA_PRECISION 
                                                           from ALL_TAB_COLUMNS col,ALL_COL_COMMENTS comm where col.OWNER=@OWNER AND col.table_name = @TABLENAME
                                                           and col.table_name = comm.table_name and col.column_name = comm.column_name and col.owner = comm.owner";
        public IList<DB_ColumnMeta> GetDBColumnsOfTable(string _tableName)
        {
            string[] _names = _tableName.Split('.');

            SqlParameter[] _param = {
                                new SqlParameter("@OWNER", SqlDbType.NVarChar),
                                new SqlParameter("@TABLENAME",SqlDbType.NVarChar)
                        };

            if (_names.Length < 2)
            {
                _param[0].Value = GetConnectionUser();
                _param[1].Value = _names[0];
            }
            else
            {
                _param[0].Value = _names[0];
                _param[1].Value = _names[1];
            }
            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetDBColumnsOfTable, _param);

            IList<DB_ColumnMeta> nodeItems = new List<DB_ColumnMeta>();

            while (dr.Read())
            {
                DB_ColumnMeta nodeInfo = new DB_ColumnMeta();

                nodeInfo.ColumnName = dr.IsDBNull(0) ? "" : dr.GetString(0);
                nodeInfo.Comments = dr.IsDBNull(1) ? "" : dr.GetString(1);
                nodeInfo.DataType = dr.IsDBNull(2) ? "" : dr.GetString(2);
                nodeInfo.Nullable = dr.IsDBNull(3) ? true : ((dr.GetString(3) == "Y") ? true : false);
                nodeInfo.DataLength = dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetDouble(4));
                nodeInfo.DataPrecision = dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDouble(5));

                nodeItems.Add(nodeInfo);
            }
            dr.Close();

            return nodeItems;

        }

        private string GetConnectionUser()
        {
            string[] _ss = SqlHelper.ConnectionStringProfile.Split(';');
            foreach (string _s in _ss)
            {
                string[] _cs = _s.Split('=');
                if (_cs[0].ToUpper() == "USER ID" && _cs.Length > 1)
                {
                    return _cs[1];
                }
            }
            return "ZHTJ";
        }
        #endregion

        #region IMetaDataFactroy Members


        public string GetNewID()
        {
            return SequenceAccessor.GetNewId();
        }

        #endregion
        #region IMetaDataFactroy Members

        private const string SQL_SaveTableDefine = @"update MD_TABLE SET NAMESPACE=@NAMESPACE,TABLENAME = @TABLENAME,TABLETYPE = @TABLETYPE,
                                                        DESCRIPTION = @DESCRIPTION,DISPLAYNAME = @DISPLAYNAME,DWDM = @DWDM,MAINKEY=:MAINKEY, 
                                                        SECRETFUN=@SECRETFUN,EXTSECRET=@EXTSECRET,RESTYPE=@RESTYPE
                                                        WHERE TID = @TID ";
        public bool SaveTableDefine(MD_Table _table)
        {
            OracleString[] _TCIDActions = null;
            //保存表定义信息
            SqlParameter[] _param = {
                                new SqlParameter("@NAMESPACE", SqlDbType.NVarChar, 50),
                                new SqlParameter("@TABLENAME", SqlDbType.NVarChar, 50),
                                new SqlParameter("@TABLETYPE", SqlDbType.NVarChar, 50),
                                new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 100),
                                new SqlParameter("@DISPLAYNAME", SqlDbType.NVarChar, 100),
                                new SqlParameter("@DWDM", SqlDbType.NVarChar, 12),
                                new SqlParameter("@MAINKEY",SqlDbType.NVarChar,50),
                                new SqlParameter("@SECRETFUN",SqlDbType.NVarChar,50),
                                new SqlParameter("@EXTSECRET",SqlDbType.NVarChar,1000),
                                new SqlParameter("@RESTYPE",SqlDbType.NVarChar,100),
                                new SqlParameter("@TID",OracleDbType.Decimal)
                        };
            _param[0].Value = _table.NamespaceName;
            _param[1].Value = _table.TableName;
            _param[2].Value = _table.TableType;
            _param[3].Value = _table.Description;
            _param[4].Value = _table.DisplayTitle;
            _param[5].Value = _table.DWDM;
            _param[6].Value = _table.MainKey;
            _param[7].Value = _table.SecretFun;
            _param[8].Value = _table.ExtSecret;
            _param[9].Value = (_table.ResourceType == null) ? "" : string.Join(",", _table.ResourceType);
            _param[10].Value = Convert.ToDecimal(_table.TID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveTableDefine, _param);

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                //取所有TCID的状态,如果不需要的TCID,则删除
                SqlCommand cmd = new SqlCommand("begin ZHTJ_META.CheckTCID(:1, :2, :3); end;", cn);
                SqlParameter Param1 = cmd.Parameters.Add(new SqlParameter(":1", OracleDbType.Decimal));
                SqlParameter Param2 = cmd.Parameters.Add(new SqlParameter(":2", OracleDbType.Decimal));
                SqlParameter Param3 = cmd.Parameters.Add(new SqlParameter(":3", SqlDbType.NVarChar, 10));

                Param1.Direction = ParameterDirection.Input;
                Param2.Direction = ParameterDirection.Input;
                Param3.Direction = ParameterDirection.Output;

                // Specify that we are binding PL/SQL Associative Array                           
                //Param2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                //Param3.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                Param1.Value = Convert.ToDecimal(_table.TID);
                decimal[] _tcItems = new decimal[_table.Columns.Count];
                int[] p2_bindSizes = new int[_table.Columns.Count];
                int[] p3_bindSizes = new int[_table.Columns.Count];
                for (int i = 0; i < _table.Columns.Count; i++)
                {
                    _tcItems[i] = decimal.Parse(_table.Columns[i].ColumnID);
                    p2_bindSizes[i] = 10;
                    p3_bindSizes[i] = 10;
                }

                Param2.Value = _tcItems;
                Param3.Value = null;

                Param2.Size = _table.Columns.Count;
                Param3.Size = _table.Columns.Count;

                //Param2.ArrayBindSize = p2_bindSizes;
                //Param3.ArrayBindSize = p3_bindSizes;
                cmd.ExecuteNonQuery();

                _TCIDActions = Param3.Value as OracleString[];

            }

            for (int i = 0; i < _table.Columns.Count; i++)
            {
                switch (_TCIDActions[i].ToString())
                {
                    case "UPDATE":
                        UpdateColumnDefine(_table, _table.Columns[i]);
                        break;
                    case "INSERT":
                        InsertColumnDefine(_table, _table.Columns[i]);
                        break;
                }
            }
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        private const string SQL_ImportTableDefine = @"insert into MD_TABLE
                                                       (NAMESPACE,TABLENAME,TABLETYPE,DESCRIPTION,
                                                        DISPLAYNAME,DWDM,MAINKEY,SECRETFUN,
                                                        EXTSECRET,TID ) VALUES
                                                        (@NAMESPACE,@TABLENAME,@TABLETYPE,@DESCRIPTION,
                                                        @DISPLAYNAME,@DWDM,@MAINKEY,@SECRETFUN, 
                                                        @EXTSECRET,@TID )";
        public bool ImportTableDefine(MD_Table _table)
        {
            try
            {
                OracleString[] _TCIDActions = null;
                //保存表定义信息

                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlTransaction _txn = cn.BeginTransaction();
                    SqlCommand _cmdInsert = new SqlCommand(SQL_ImportTableDefine, cn);
                    _cmdInsert.Parameters.Add("@NAMESPACE", _table.NamespaceName);
                    _cmdInsert.Parameters.Add("@TABLENAME", _table.TableName);
                    _cmdInsert.Parameters.Add("@TABLETYPE", _table.TableType);
                    _cmdInsert.Parameters.Add("@DESCRIPTION", _table.Description);
                    _cmdInsert.Parameters.Add("@DISPLAYNAME", _table.DisplayTitle);
                    _cmdInsert.Parameters.Add("@DWDM", _table.DWDM);
                    _cmdInsert.Parameters.Add("@MAINKEY", _table.MainKey);
                    _cmdInsert.Parameters.Add("@SECRETFUN", _table.SecretFun);
                    _cmdInsert.Parameters.Add("@EXTSECRET", _table.ExtSecret);
                    _cmdInsert.Parameters.Add("@TID", Convert.ToDecimal(_table.TID));
                    _cmdInsert.ExecuteNonQuery();
                    _txn.Commit();

                    _txn = cn.BeginTransaction();
                    //取所有TCID的状态,如果不需要的TCID,则删除
                    SqlCommand cmd = new SqlCommand("begin ZHTJ_META.CheckTCID(@1, @2, @3); end;", cn);
                    SqlParameter Param1 = cmd.Parameters.Add(new SqlParameter("@1", OracleDbType.Decimal));
                    SqlParameter Param2 = cmd.Parameters.Add(new SqlParameter("@2", OracleDbType.Decimal));
                    SqlParameter Param3 = cmd.Parameters.Add(new SqlParameter("@3", SqlDbType.NVarChar, 10));

                    Param1.Direction = ParameterDirection.Input;
                    Param2.Direction = ParameterDirection.Input;
                    Param3.Direction = ParameterDirection.Output;

                    // Specify that we are binding PL/SQL Associative Array                           
                    //Param2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //Param3.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    Param1.Value = Convert.ToDecimal(_table.TID);
                    decimal[] _tcItems = new decimal[_table.Columns.Count];
                    int[] p2_bindSizes = new int[_table.Columns.Count];
                    int[] p3_bindSizes = new int[_table.Columns.Count];
                    for (int i = 0; i < _table.Columns.Count; i++)
                    {
                        _tcItems[i] = decimal.Parse(_table.Columns[i].ColumnID);
                        p2_bindSizes[i] = 10;
                        p3_bindSizes[i] = 10;
                    }

                    Param2.Value = _tcItems;
                    Param3.Value = null;

                    Param2.Size = _table.Columns.Count;
                    Param3.Size = _table.Columns.Count;

                    //Param2.ArrayBindSize = p2_bindSizes;
                    //Param3.ArrayBindSize = p3_bindSizes;
                    cmd.ExecuteNonQuery();

                    _TCIDActions = Param3.Value as OracleString[];
                    _txn.Commit();

                }

                for (int i = 0; i < _table.Columns.Count; i++)
                {
                    switch (_TCIDActions[i].ToString())
                    {
                        case "UPDATE":
                            UpdateColumnDefine(_table, _table.Columns[i]);
                            break;
                        case "INSERT":
                            InsertColumnDefine(_table, _table.Columns[i]);
                            break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogWriter.WriteSystemLog(string.Format("导入表{0}的元数据失败!错误信息：{1}", _table.TableName, ex.Message), "ERROR");
                return false;
            }
        }


        private void UpdateColumnDefine(MD_Table _table, MD_TableColumn _tc)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" update MD_TABLECOLUMN  set TID=@TID,COLUMNNAME=@COLUMNNAME,");
            _sb.Append(" ISNULLABLE=@ISNULLABLE,TYPE=@TYPE,PRECISION=@PRECISION,SCALE=@SCALE,");
            _sb.Append(" LENGTH=@LENGTH,REFDMB=@REFDMB,DMBLEVELFORMAT=@DMBLEVELFORMAT,SECRETLEVEL=@SECRETLEVEL,");
            _sb.Append(" DISPLAYTITLE=@DISPLAYTITLE,DISPLAYFORMAT=@DISPLAYFORMAT,DISPLAYLENGTH=@DISPLAYLENGTH,DISPLAYHEIGHT=@DISPLAYHEIGHT,");
            _sb.Append(" DISPLAYORDER=@DISPLAYORDER,CANDISPLAY=@CANDISPLAY,COLWIDTH=@COLWIDTH,DWDM=@DWDM,");
            _sb.Append(" CTAG=@CTAG,REFWORDTB=@REFWORD ");
            _sb.Append(" WHERE TCID=@TCID");

            SqlParameter[] _param3 = {
                                        new SqlParameter("@TID", OracleDbType.Decimal),
                                        new SqlParameter("@COLUMNNAME", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@ISNULLABLE", SqlDbType.NVarChar, 100),
                                        new SqlParameter("@TYPE", SqlDbType.NVarChar, 20),
                                        new SqlParameter("@PRECISION", OracleDbType.Decimal),
                                        new SqlParameter("@SCALE",OracleDbType.Decimal),
                                        new SqlParameter("@LENGTH",OracleDbType.Decimal),
                                        new SqlParameter("@REFDMB",SqlDbType.NVarChar,50),
                                        new SqlParameter("@DMBLEVELFORMAT",SqlDbType.NVarChar,20),
                                        new SqlParameter("@SECRETLEVEL", OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYTITLE", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@DISPLAYFORMAT", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@DISPLAYLENGTH", OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYHEIGHT", OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYORDER", OracleDbType.Decimal),
                                        new SqlParameter("@CANDISPLAY",OracleDbType.Decimal),
                                        new SqlParameter("@COLWIDTH",OracleDbType.Decimal),
                                        new SqlParameter("@DWDM",SqlDbType.NVarChar,20),
                                        new SqlParameter("@CTAG",SqlDbType.NVarChar,500),
                                        new SqlParameter("@REFWORDTB",SqlDbType.NVarChar,50),
                                        new SqlParameter("@TCID", OracleDbType.Decimal)
                                };

            _param3[0].Value = Convert.ToDecimal(_table.TID);
            _param3[1].Value = _tc.ColumnName;
            _param3[2].Value = _tc.IsNullable ? "Y" : "N";
            _param3[3].Value = _tc.ColumnType;
            _param3[4].Value = Convert.ToDecimal(_tc.Precision);
            _param3[5].Value = Convert.ToDecimal(_tc.Scale);
            _param3[6].Value = Convert.ToDecimal(_tc.Length);
            _param3[7].Value = _tc.RefDMB;
            _param3[8].Value = _tc.DMBLevelFormat;

            _param3[9].Value = Convert.ToDecimal(_tc.SecretLevel);
            _param3[10].Value = _tc.DisplayTitle;
            _param3[11].Value = _tc.DisplayFormat;
            _param3[12].Value = Convert.ToDecimal(_tc.DisplayLength);
            _param3[13].Value = Convert.ToDecimal(_tc.DisplayHeight);
            _param3[14].Value = Convert.ToDecimal(_tc.DisplayOrder);
            _param3[15].Value = _tc.CanDisplay ? 1 : 0;
            _param3[16].Value = Convert.ToDecimal(_tc.ColWidth);
            _param3[17].Value = _tc.DWDM;
            _param3[18].Value = _tc.CTag;
            _param3[19].Value = _tc.RefWordTableName;
            _param3[20].Value = Convert.ToDecimal(_tc.ColumnID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param3);
            OraMetaDataQueryFactroy.ModelLib.Clear();
        }

        private void InsertColumnDefine(MD_Table _table, MD_TableColumn _tc)
        {
            StringBuilder _sb_insert = new StringBuilder();
            _sb_insert.Append(" insert into MD_TABLECOLUMN (TCID,TID,COLUMNNAME,");
            _sb_insert.Append(" ISNULLABLE,TYPE,PRECISION,SCALE,");
            _sb_insert.Append(" LENGTH,REFDMB,DMBLEVELFORMAT,SECRETLEVEL,");
            _sb_insert.Append(" DISPLAYTITLE,DISPLAYFORMAT,DISPLAYLENGTH,DISPLAYHEIGHT,");
            _sb_insert.Append(" DISPLAYORDER,CANDISPLAY,COLWIDTH,DWDM,");
            _sb_insert.Append(" CTAG,REFWORDTB ) values ");
            _sb_insert.Append(" (@TCID,@TID,@COLUMNNAME,");
            _sb_insert.Append(" @ISNULLABLE,@TYPE,@PRECISION,@SCALE,");
            _sb_insert.Append(" @LENGTH,@REFDMB,@DMBLEVELFORMAT,@SECRETLEVEL,");
            _sb_insert.Append(" @DISPLAYTITLE,@DISPLAYFORMAT,@DISPLAYLENGTH,@DISPLAYHEIGHT,");
            _sb_insert.Append(" @DISPLAYORDER,@CANDISPLAY,@COLWIDTH,@DWDM,");
            _sb_insert.Append(" @CTAG,@REFWORDTB)  ");

            SqlParameter[] _param3 = {
                                        new SqlParameter("@TCID", OracleDbType.Decimal),
                                        new SqlParameter("@TID", OracleDbType.Decimal),
                                        new SqlParameter("@COLUMNNAME", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@ISNULLABLE", SqlDbType.NVarChar, 100),
                                        new SqlParameter("@TYPE", SqlDbType.NVarChar, 20),
                                        new SqlParameter("@PRECISION", OracleDbType.Decimal),
                                        new SqlParameter("@SCALE",OracleDbType.Decimal),
                                        new SqlParameter("@LENGTH",OracleDbType.Decimal),
                                        new SqlParameter("@REFDMB",SqlDbType.NVarChar,50),
                                        new SqlParameter("@DMBLEVELFORMAT",SqlDbType.NVarChar,20),
                                        new SqlParameter("@SECRETLEVEL", OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYTITLE", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@DISPLAYFORMAT", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@DISPLAYLENGTH", OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYHEIGHT", OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYORDER", OracleDbType.Decimal),
                                        new SqlParameter("@CANDISPLAY",OracleDbType.Decimal),
                                        new SqlParameter("@COLWIDTH",OracleDbType.Decimal),
                                        new SqlParameter("@DWDM",SqlDbType.NVarChar,20),
                                        new SqlParameter("@CTAG",SqlDbType.NVarChar,500),
                                        new SqlParameter("@REFWORDTB",SqlDbType.NVarChar,50)
                        };
            _param3[0].Value = Convert.ToDecimal(_tc.ColumnID);
            _param3[1].Value = Convert.ToDecimal(_table.TID);
            _param3[2].Value = _tc.ColumnName;
            _param3[3].Value = _tc.IsNullable ? "Y" : "N";
            _param3[4].Value = _tc.ColumnType;
            _param3[5].Value = Convert.ToDecimal(_tc.Precision);
            _param3[6].Value = Convert.ToDecimal(_tc.Scale);
            _param3[7].Value = Convert.ToDecimal(_tc.Length);
            _param3[8].Value = _tc.RefDMB;
            _param3[9].Value = _tc.DMBLevelFormat;

            _param3[10].Value = Convert.ToDecimal(_tc.SecretLevel);
            _param3[11].Value = _tc.DisplayTitle;
            _param3[12].Value = _tc.DisplayFormat;
            _param3[13].Value = Convert.ToDecimal(_tc.DisplayLength);
            _param3[14].Value = Convert.ToDecimal(_tc.DisplayHeight);
            _param3[15].Value = Convert.ToDecimal(_tc.DisplayOrder);
            _param3[16].Value = _tc.CanDisplay ? 1 : 0;
            _param3[17].Value = Convert.ToDecimal(_tc.ColWidth);
            _param3[18].Value = _tc.DWDM;
            _param3[19].Value = _tc.CTag;
            _param3[20].Value = _tc.RefWordTableName;


            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb_insert.ToString(), _param3);

            OraMetaDataQueryFactroy.ModelLib.Clear();
        }


        #endregion

        #region IMetaDataFactroy Members

        public bool SaveNewQueryModel(MD_QueryModel _queryModel)
        {
            //保存查询模型定义信息
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" insert into MD_VIEW (");
            _sb.Append(" VIEWID,VIEWNAME,DESCRIPTION,DISPLAYNAME, ");
            _sb.Append(" DWDM,IS_GDCX,IS_GLCX,IS_SJSH,");
            _sb.Append(" DISPLAYORDER,NAMESPACE,EXTMETA )");
            _sb.Append(" values ( ");
            _sb.Append("  sequences_meta.nextval,@VIEWNAME,@DESCRIPTION,@DISPLAYNAME, ");
            _sb.Append(" @DWDM,@IS_GDCX,@IS_GLCX,@IS_SJSH,");
            _sb.Append(" @DISPLAYORDER,@NAMESPACE,@EXTMETA)");

            SqlParameter[] _param = {                                
                                new SqlParameter("@VIEWNAME", SqlDbType.NVarChar, 50),
                                new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 100),
                                new SqlParameter("@DISPLAYNAME", SqlDbType.NVarChar, 100),
                                new SqlParameter("@DWDM", SqlDbType.NVarChar, 12),
                                new SqlParameter("@IS_GDCX", OracleDbType.Decimal),
                                new SqlParameter("@IS_GLCX",OracleDbType.Decimal),
                                new SqlParameter("@IS_SJSH",OracleDbType.Decimal),
                                new SqlParameter("@DISPLAYORDER",OracleDbType.Decimal),
                                new SqlParameter("@NAMESPACE",SqlDbType.NVarChar,50),
                                 new SqlParameter("@EXTMETA",SqlDbType.NVarChar,4000)
                        };

            _param[0].Value = _queryModel.QueryModelName;
            _param[1].Value = _queryModel.Description;
            _param[2].Value = _queryModel.DisplayTitle;
            _param[3].Value = _queryModel.DWDM;
            _param[4].Value = _queryModel.IsFixQuery ? (decimal)1 : (decimal)0;
            _param[5].Value = _queryModel.IsRelationQuery ? (decimal)1 : (decimal)0;
            _param[6].Value = _queryModel.IsDataAuditing ? (decimal)1 : (decimal)0;
            _param[7].Value = Convert.ToDecimal(_queryModel.DisplayOrder);
            _param[8].Value = _queryModel.NamespaceName;
            _param[9].Value = _queryModel.EXTMeta;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            OraMetaDataQueryFactroy.ModelLib.Clear();

            return true;

        }


        public bool SaveQueryModel(MD_QueryModel _queryModel)
        {
            //保存查询模型定义信息
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" update MD_VIEW SET VIEWNAME =@VIEWNAME,DESCRIPTION = @DESCRIPTION,");
            _sb.Append(" DISPLAYNAME =@DISPLAYNAME,DWDM =@DWDM,IS_GDCX = @IS_GDCX,IS_GLCX=@IS_GLCX, ");
            _sb.Append(" IS_SJSH=@IS_SJSH,DISPLAYORDER=@DISPLAYORDER,ICSTYPE=@ICSTYPE,EXTMETA=@EXTMETA ");
            _sb.Append(" WHERE VIEWID = @VIEWID ");
            SqlParameter[] _param = {                                
                                new SqlParameter("@VIEWNAME", SqlDbType.NVarChar, 50),
                                new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 100),
                                new SqlParameter("@DISPLAYNAME", SqlDbType.NVarChar, 100),
                                new SqlParameter("@DWDM", SqlDbType.NVarChar, 12),
                                new SqlParameter("@IS_GDCX", OracleDbType.Decimal),
                                new SqlParameter("@IS_GLCX",OracleDbType.Decimal),
                                new SqlParameter("@IS_SJSH",OracleDbType.Decimal),
                                new SqlParameter("@DISPLAYORDER",OracleDbType.Decimal),
                                new SqlParameter("@ICSTYPE", SqlDbType.NVarChar, 20),
                                new SqlParameter("@EXTMETA", SqlDbType.NVarChar, 4000),
                                new SqlParameter("@VIEWID",OracleDbType.Decimal)
                        };

            _param[0].Value = _queryModel.QueryModelName;
            _param[1].Value = _queryModel.Description;
            _param[2].Value = _queryModel.DisplayTitle;
            _param[3].Value = _queryModel.DWDM;
            _param[4].Value = _queryModel.IsFixQuery ? 1 : 0;
            _param[5].Value = _queryModel.IsRelationQuery ? 1 : 0;
            _param[6].Value = _queryModel.IsDataAuditing ? 1 : 0;
            _param[7].Value = Convert.ToDecimal(_queryModel.DisplayOrder);
            _param[8].Value = _queryModel.QueryInterface;
            _param[9].Value = _queryModel.EXTMeta;
            _param[10].Value = Convert.ToDecimal(_queryModel.QueryModelID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool ImportQueryModelDefine(MD_QueryModel _qv)
        {
            return QueryModelAccessor.ImportQueryModelDefine(_qv);
        }


        #endregion

        #region IMetaDataFactroy Members


        private const string SQL_SaveViewMainTable_Update = @" update MD_VIEWTABLE SET DISPLAYNAME=@DISPLAYNAME,INTEGRATEDAPP=@INTEGRATEDAPP
                                                                WHERE VTID = @VTID";
        private const string SQL_SaveViewMainTable_Delete = @"delete from MD_VIEWTABLECOLUMN where VTID=@VTID";
        private const string SQL_SaveViewMainTable_Insert = @"insert into MD_VIEWTABLECOLUMN (VTCID,VTID,TCID,
                                                                    CANCONDITIONSHOW,CANRESULTSHOW,DEFAULTSHOW,
                                                                    DWDM,FIXQUERYITEM,CANMODIFY,PRIORITY,DISPLAYORDER)
                                                                    VALUES (@VTCID,@VTID,@TCID,
                                                                    @CANCONDITIONSHOW,@CANRESULTSHOW,@DEFAULTSHOW,
                                                                    @DWDM,@FIXQUERYITEM,@CANMODIFY,@PRIORITY,@DISPLAYORDER)";
        /// <summary>
        /// 保存主表定义信息
        /// </summary>
        /// <param name="_viewtable"></param>
        /// <returns></returns>
        public bool SaveViewMainTable(MD_ViewTable _viewtable)
        {
            SqlParameter[] _param = {            
                                new SqlParameter("@DISPLAYNAME",SqlDbType.NVarChar,100),
                                new SqlParameter("@INTEGRATEDAPP",SqlDbType.NVarChar,1000),
                                new SqlParameter("@VTID",OracleDbType.Decimal)
                        };
            _param[0].Value = _viewtable.DisplayTitle;
            _param[1].Value = _viewtable.IntegratedApp;
            _param[2].Value = Convert.ToDecimal(_viewtable.ViewTableID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewMainTable_Update, _param);

            //清除所有字段定义
            SqlParameter[] _param2 = {
                               new SqlParameter("@VTID",OracleDbType.Decimal)
                        };
            _param2[0].Value = Convert.ToDecimal(_viewtable.ViewTableID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewMainTable_Delete, _param2);


            //保存字段定义信息
            foreach (MD_ViewTableColumn _tc in _viewtable.Columns)
            {
                SqlParameter[] _param3 = {
                                        new SqlParameter("@VTCID", OracleDbType.Decimal),
                                        new SqlParameter("@VTID", OracleDbType.Decimal),
                                        new SqlParameter("@TCID", OracleDbType.Decimal),
                                        new SqlParameter("@CANCONDITIONSHOW", OracleDbType.Decimal),
                                        new SqlParameter("@CANRESULTSHOW", OracleDbType.Decimal),
                                        new SqlParameter("@DEFAULTSHOW", OracleDbType.Decimal),
                                        new SqlParameter("@DWDM",SqlDbType.NVarChar,12),
                                        new SqlParameter("@FIXQUERYITEM",OracleDbType.Decimal),
                                        new SqlParameter("@CANMODIFY",OracleDbType.Decimal),
                                        new SqlParameter("@PRIORITY",OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYORDER",OracleDbType.Decimal)
                                };
                _param3[0].Value = Convert.ToDecimal(_tc.ViewTableColumnID);
                _param3[1].Value = Convert.ToDecimal(_viewtable.ViewTableID);
                _param3[2].Value = Convert.ToDecimal(_tc.ColumnID);
                _param3[3].Value = _tc.CanShowAsCondition ? 1 : 0;
                _param3[4].Value = _tc.CanShowAsResult ? 1 : 0;
                _param3[5].Value = _tc.DefaultResult ? 1 : 0;
                _param3[6].Value = _tc.DWDM;
                _param3[7].Value = _tc.IsFixQueryItem ? 1 : 0;
                _param3[8].Value = _tc.CanModify ? 1 : 0;
                _param3[9].Value = Convert.ToDecimal(_tc.Priority);
                _param3[10].Value = Convert.ToDecimal(_tc.DisplayOrder);
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewMainTable_Insert, _param3);
            }
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }



        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_GetChildTableOfQueryModel = @"select VTID,VIEWID,TID,TABLETYPE,TABLERELATION,CANCONDITION,DISPLAYNAME,DISPLAYORDER,DWDM,
                                                                FATHERID,PRIORITY,DISPLAYTYPE,INTEGRATEDAPP from MD_VIEWTABLE where VIEWID = @VID and TABLETYPE = 'F' order by DISPLAYORDER";
        public IList<MD_ViewTable> GetChildTableOfQueryModel(string QueryModelID)
        {
            IList<MD_ViewTable> _ret = new List<MD_ViewTable>();

            SqlParameter[] _param = {
                                new SqlParameter("@VID", OracleDbType.Decimal),
                        };
            _param[0].Value = decimal.Parse(QueryModelID);

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetChildTableOfQueryModel, _param);

            while (dr.Read())
            {
                MD_ViewTable _vt = new MD_ViewTable(dr.GetDouble(0).ToString(),
                                dr.GetDouble(1).ToString(),
                                dr.GetDouble(2).ToString(),
                                dr.IsDBNull(3) ? "M" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetDouble(7)),
                                dr.IsDBNull(8) ? "" : dr.GetString(8),
                                dr.IsDBNull(9) ? "" : dr.GetDouble(9).ToString(),
                                dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetDouble(10)),
                                 dr.IsDBNull(11) ? 0 : Convert.ToInt32(dr.GetDouble(11)),
                                 dr.IsDBNull(12) ? "" : dr.GetString(12)
                                );
                _vt.Table = GetTableByTableID(_vt.TableID);
                _vt.TableName = _vt.Table.TableName;
                _vt.Columns = GetColumnsOfViewTable(_vt);
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }

        public IList<MD_ViewTable> GetChildTableOfQueryModel(MD_QueryModel _qm)
        {
            return GetChildTableOfQueryModel(_qm.QueryModelID);
        }

        #endregion

        #region IMetaDataFactroy Members


        private const string SQL_SaveViewChildTable_Update = @"update MD_VIEWTABLE SET DISPLAYNAME=@DISPLAYNAME,TABLERELATION=@TABLERELATION,CANCONDITION=@CANCONDITION,
                                                                DISPLAYORDER=@DISPLAYORDER,DISPLAYTYPE=@DISPLAYTYPE,INTEGRATEDAPP=@INTEGRATEDAPP WHERE VTID = @VTID";
        private const string SQL_SaveViewChildTable_Insert = @"insert into MD_VIEWTABLECOLUMN (VTCID,VTID,TCID,
                                                                CANCONDITIONSHOW,CANRESULTSHOW,DEFAULTSHOW,
                                                                DWDM,FIXQUERYITEM,CANMODIFY,PRIORITY,DISPLAYORDER)
                                                                VALUES (@VTCID,@VTID,@TCID,
                                                                @CANCONDITIONSHOW,@CANRESULTSHOW,@DEFAULTSHOW,
                                                                @DWDM,@FIXQUERYITEM,@CANMODIFY,@PRIORITY,@DISPLAYORDER)";
        private const string SQL_SaveViewChildTable_Delete = @"delete from MD_VIEWTABLECOLUMN where VTID=@VTID";

        public bool SaveViewChildTable(MD_ViewTable _viewtable)
        {
            SqlParameter[] _param = {            
                                new SqlParameter("@DISPLAYNAME",SqlDbType.NVarChar,100),
                                new SqlParameter("@TABLERELATION",SqlDbType.NVarChar,300),
                                new SqlParameter("@CANCONDITION",SqlDbType.NVarChar,10),
                                new SqlParameter("@DISPLAYORDER",OracleDbType.Decimal),
                                new SqlParameter("@DISPLAYTYPE",OracleDbType.Decimal),
                                new SqlParameter("@INTEGRATEDAPP",SqlDbType.NVarChar,1000),
                                new SqlParameter("@VTID",OracleDbType.Decimal)
                        };
            _param[0].Value = _viewtable.DisplayTitle;
            _param[1].Value = _viewtable.RelationString;
            _param[2].Value = (_viewtable.ViewTableRelationType == MDType_ViewTableRelation.SingleChildRecord) ? 1 : 0;
            _param[3].Value = Convert.ToDecimal(_viewtable.DisplayOrder);
            _param[4].Value = (_viewtable.DisplayType == MDType_DisplayType.GridType) ? (decimal)0 : (decimal)1;
            _param[5].Value = _viewtable.IntegratedApp;
            _param[6].Value = Convert.ToDecimal(_viewtable.ViewTableID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewChildTable_Update, _param);

            //清除所有字段定义
            SqlParameter[] _param2 = {
                               new SqlParameter("@VTID",OracleDbType.Decimal)
                        };
            _param2[0].Value = Convert.ToDecimal(_viewtable.ViewTableID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewChildTable_Delete, _param2);


            //保存字段定义信息
            foreach (MD_ViewTableColumn _tc in _viewtable.Columns)
            {
                SqlParameter[] _param3 = {
                                        new SqlParameter("@VTCID", OracleDbType.Decimal),
                                        new SqlParameter("@VTID", OracleDbType.Decimal),
                                        new SqlParameter("@TCID", OracleDbType.Decimal),
                                        new SqlParameter("@CANCONDITIONSHOW", OracleDbType.Decimal),
                                        new SqlParameter("@CANRESULTSHOW", OracleDbType.Decimal),
                                        new SqlParameter("@DEFAULTSHOW", OracleDbType.Decimal),
                                        new SqlParameter("@DWDM",SqlDbType.NVarChar,12),
                                        new SqlParameter("@FIXQUERYITEM",OracleDbType.Decimal),
                                        new SqlParameter("@CANMODIFY",OracleDbType.Decimal),
                                        new SqlParameter("@PRIORITY",OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYORDER",OracleDbType.Decimal)
                                };
                _param3[0].Value = Convert.ToDecimal(_tc.ViewTableColumnID);
                _param3[1].Value = Convert.ToDecimal(_viewtable.ViewTableID);
                _param3[2].Value = Convert.ToDecimal(_tc.ColumnID);
                _param3[3].Value = _tc.CanShowAsCondition ? 1 : 0;
                _param3[4].Value = _tc.CanShowAsResult ? 1 : 0;
                _param3[5].Value = _tc.DefaultResult ? 1 : 0;
                _param3[6].Value = _tc.DWDM;
                _param3[7].Value = _tc.IsFixQueryItem ? 1 : 0;
                _param3[8].Value = _tc.CanModify ? 1 : 0;
                _param3[9].Value = Convert.ToDecimal(_tc.Priority);
                _param3[10].Value = Convert.ToDecimal(_tc.DisplayOrder);
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewChildTable_Insert, _param3);
            }
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }


        public bool IsExistChildTable(string _viewTableID)
        {
            string _sql = "select count(*) from MD_VIEWTABLE WHERE FATHERID =@FID";
            SqlParameter[] _param = {            
                                new SqlParameter(":FID",OracleDbType.Decimal)                                
                        };
            _param[0].Value = decimal.Parse(_viewTableID);
            decimal _count = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return (_count > 0);
        }

        public bool DelViewTable(string _viewTableID)
        {
            string _del = "delete MD_VIEWTABLECOLUMN WHERE VTID= @VTID";
            string _del2 = "delete MD_VIEWTABLE WHERE VTID =@VTID ";
            SqlParameter[] _param = {            
                                new SqlParameter("@VTID",OracleDbType.Decimal)                                
                        };
            _param[0].Value = decimal.Parse(_viewTableID);

            SqlParameter[] _param2 = {            
                                new SqlParameter("@VTID",OracleDbType.Decimal)                                
                        };
            _param2[0].Value = decimal.Parse(_viewTableID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _del, _param);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _del2, _param2);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool IsExistChildOfView(string _queryModelID)
        {
            string _querystr = "select count(*) from MD_VIEWTABLE WHERE VIEWID =@VIEWID ";
            SqlParameter[] _param = {            
                                new SqlParameter("@VIEWID",OracleDbType.Decimal)                                
                        };
            _param[0].Value = decimal.Parse(_queryModelID);

            decimal _count = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _querystr, _param);
            return (_count > 0);
        }

        public bool DelViewMeta(string QueryModelID)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction txn = cn.BeginTransaction();
                try
                {
                    SqlCommand _cmd = new SqlCommand(DelView_View2View, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(DelView_View2ViewGroup, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(DelView_InGroup, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(DelView_View, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();


                    txn.Commit();
                }
                catch (Exception ex)
                {
                    string _errStr = string.Format("删除查询模型及其子对象定义时发生错误! QueryModelID={0} \n\r ErrorMsg:{1}  ",
                                    QueryModelID, ex.Message);
                    LogWriter.WriteSystemLog(_errStr, "ERROR");
                    txn.Rollback();
                    return false;
                }
            }
            return true;
        }

        private const string DelView_ViewTableColumn = @"delete from MD_VIEWTABLECOLUMN vtc where vtc.vtid in  (
														select vt.VTID from MD_VIEWTABLE vt where vt.VIEWID=@VIEWID) ";
        private const string DelView_ViewTable = "delete from MD_VIEWTABLE vt where vt.VIEWID=@VIEWID ";
        private const string DelView_View = "delete from MD_VIEW where VIEWID=@VIEWID";
        private const string DelView_InGroup = "delete from MD_VIEWGROUPITEM where VIEWID=@VIEWID";
        private const string DelView_View2ViewGroup = "delete from MD_VIEW2VIEWGROUP where VIEWID=@VIEWID";
        private const string DelView_View2View = "delete from MD_VIEW2VIEW where VIEWID=@VIEWID";
        private const string DelView_View2Guideline = "delete from md_view2gl where VIEWID=@VIEWID";
        private const string DelView_View2Application = "delete from md_view2app where viewid=@VIEWID";
        public bool DelViewAndChildren(string QueryModelID)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction txn = cn.BeginTransaction();
                try
                {

                    SqlCommand _cmd = new SqlCommand(DelView_ViewTableColumn, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(DelView_ViewTable, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(DelView_View2View, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(DelView_View2ViewGroup, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(DelView_InGroup, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(DelView_View, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(DelView_View2Guideline, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(DelView_View2Application, cn);
                    _cmd.Parameters.Add("@VIEWID", QueryModelID);
                    _cmd.ExecuteNonQuery();

                    txn.Commit();
                }
                catch (Exception ex)
                {
                    string _errStr = string.Format("删除查询模型及其子对象定义时发生错误! QueryModelID={0} \n\r ErrorMsg:{1}  ",
                                    QueryModelID, ex.Message);
                    LogWriter.WriteSystemLog(_errStr, "ERROR");
                    txn.Rollback();
                    return false;
                }
            }
            return true;
        }

        public bool IsExistViewUsedTable(string _tableID)
        {
            string _querystr = "select count(*) from MD_VIEWTABLE WHERE TID=@TID ";
            SqlParameter[] _param = {            
                                new SqlParameter("@TID",OracleDbType.Decimal)                                
                        };
            _param[0].Value = decimal.Parse(_tableID);

            decimal _count = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _querystr, _param);
            return (_count > 0);
        }

        public bool DelTableMeta(string _tableID)
        {
            string _del2 = "delete MD_TABLECOLUMN where TID=@TID ";
            string _del = "delete MD_TABLE where TID =@TID";
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction txn = cn.BeginTransaction();
                try
                {
                    SqlCommand _cmd = new SqlCommand(_del2, cn);
                    _cmd.Parameters.Add("@TID", decimal.Parse(_tableID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new SqlCommand(_del, cn);
                    _cmd.Parameters.Add("@TID", decimal.Parse(_tableID));
                    _cmd.ExecuteNonQuery();

                    txn.Commit();
                    OraMetaDataQueryFactroy.ModelLib.Clear();
                }
                catch (Exception ex)
                {
                    string _errStr = string.Format("删除表定义时发生错误! TableID={0} \n\r ErrorMsg:{1}  ",
                                    _tableID, ex.Message);
                    //LogWriter.WriteSystemLog(_errStr, "ERROR");
                    txn.Rollback();
                    return false;
                }
            }
            return true;
        }

        public bool SaveNewRefTable(DB_TableMeta _tm, MD_Namespace _namespace)
        {
            StringBuilder _insertStr = new StringBuilder();
            _insertStr.Append(" Insert into md_reftablelist ");
            _insertStr.Append(" (RTID,NAMESPACE,REFTABLENAME,REFTABLELEVELFORMAT,");
            _insertStr.Append(" DESCRIPTION,DOWNLOADMODE,REFTABLEMODE,DWDM ) ");
            _insertStr.Append(" values ");
            _insertStr.Append(" (sequences_meta.nextval,@NAMESPACE,@REFTABLENAME,'',");
            _insertStr.Append(" @DESCRIPTION,1,1,:DWDM ) ");

            SqlParameter[] _param = {            
                                new SqlParameter("@NAMESPACE",SqlDbType.NVarChar,50),
                                new SqlParameter("@REFTABLENAME",SqlDbType.NVarChar,50),
                                new SqlParameter("@DESCRIPTION",SqlDbType.NVarChar,100),
                                new SqlParameter("@DWDM",SqlDbType.NVarChar,12)                                                         
                        };
            string[] _tnames = _tm.TableName.Split('.');

            _param[0].Value = _namespace.NameSpace;
            _param[1].Value = _tnames[_tnames.Length - 1];
            _param[2].Value = (_tm.TableComment == "") ? _tm.TableName : _tm.TableComment;
            _param[3].Value = _namespace.DWDM;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _insertStr.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }
        public DataTable Get_RefTableColumn(MD_RefTable _refTable)
        {
            return Get_RefTableColumn(_refTable.RefTableName);
        }
        public DataTable Get_RefTableColumn(string _refTableName)
        {
            DataTable _metadata = new DataTable("RefTable");
            string cmdStr = string.Format("select * from JSODS.{0} ", _refTableName);
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                _metadata = SqlHelper.FillDataTable(cn, CommandType.Text, cmdStr);
                _metadata.TableName = "RefTable";
                _metadata.CaseSensitive = true;
                cn.Close();
            }
            return _metadata;
        }

        public bool SaveRefTable(MD_RefTable _refTable, DataTable _refData)
        {
            StringBuilder _updateStr = new StringBuilder();
            _updateStr.Append(" update md_reftablelist set ");
            _updateStr.Append(" REFTABLELEVELFORMAT=@LEVELFORMAT,DESCRIPTION=@DES,DOWNLOADMODE=@DOWNLOAD,");
            _updateStr.Append(" REFTABLEMODE=@REFMODE,HIDECODE=@HIDECODE where RTID=@RTID");
            SqlParameter[] _param = {            
                                new SqlParameter("@LEVELFORMAT",SqlDbType.NVarChar,20),
                                new SqlParameter("@DES",SqlDbType.NVarChar,100),
                                new SqlParameter("@DOWNLOAD",OracleDbType.Decimal),
                                new SqlParameter("@REFMODE",OracleDbType.Decimal),
                                 new SqlParameter("@HIDECODE",OracleDbType.Decimal), 
                                new SqlParameter("@RTID",OracleDbType.Decimal)                               
                        };
            _param[0].Value = _refTable.LevelFormat;
            _param[1].Value = _refTable.Description;
            _param[2].Value = Convert.ToDecimal((int)_refTable.RefDownloadMode);
            _param[3].Value = Convert.ToDecimal((int)_refTable.RefParamMode);
            _param[4].Value = _refTable.HideCode ? (decimal)1 : (decimal)0;
            _param[5].Value = decimal.Parse(_refTable.RefTableID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _updateStr.ToString(), _param);

            if (_refData != null && _refData.Rows.Count > 0)
            {
                string _cmdStr = string.Format("select * from JSODS.{0}", _refTable.RefTableName);
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlTransaction txn = cn.BeginTransaction();
                    SqlHelper.UpdateData(cn, _cmdStr, _refData);
                    txn.Commit();
                    cn.Close();
                    return true;
                }
            }
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool ImportRefTableDefine(MD_RefTable _rt)
        {
            StringBuilder _insertStr = new StringBuilder();
            _insertStr.Append(" Insert into md_reftablelist ");
            _insertStr.Append(" (RTID,NAMESPACE,REFTABLENAME,REFTABLELEVELFORMAT,");
            _insertStr.Append(" DESCRIPTION,DOWNLOADMODE,REFTABLEMODE,DWDM,HIDECODE ) ");
            _insertStr.Append(" values ");
            _insertStr.Append(" (@RTID,@NAMESPACE,@REFTABLENAME,@REFTABLELEVELFORMAT,");
            _insertStr.Append(" @DESCRIPTION,@DOWNLOADMODE,@REFTABLEMODE,@DWDM,@HIDECODE ) ");

            SqlParameter[] _param = {          
                                new SqlParameter("@RTID",OracleDbType.Decimal),
                                new SqlParameter("@NAMESPACE",SqlDbType.NVarChar,50),
                                new SqlParameter("@REFTABLENAME",SqlDbType.NVarChar,50),
                                new SqlParameter("@REFTABLELEVELFORMAT",SqlDbType.NVarChar,20),
                                new SqlParameter("@DESCRIPTION",SqlDbType.NVarChar,100),
                                new SqlParameter("@DOWNLOADMODE",OracleDbType.Decimal),
                                new SqlParameter("@REFTABLEMODE",OracleDbType.Decimal),
                                new SqlParameter("@DWDM",SqlDbType.NVarChar,12)    ,
                                 new SqlParameter("@HIDECODE",OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_rt.RefTableID);
            _param[1].Value = _rt.NamespaceName;
            _param[2].Value = _rt.RefTableName;
            _param[3].Value = _rt.LevelFormat;
            _param[4].Value = _rt.Description;
            _param[5].Value = Convert.ToDecimal((int)_rt.RefDownloadMode);
            _param[6].Value = Convert.ToDecimal((int)_rt.RefParamMode);
            _param[7].Value = _rt.DWDM;
            _param[8].Value = _rt.HideCode ? (decimal)1 : (decimal)0;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _insertStr.ToString(), _param);
            return true;
        }

        private const string SQL_GetMenuDefineOfNode = @"select ID,MENUNAME,MENUTYPE,MENUCS,
                                                           DISPLAYORDER,FATHERID,MENUTOOLTIP,MENUICON,
                                                           SHOWTOOLBAR,SYSTEMID,ICONNAME
                                                           from MD_MAINMENU where SYSTEMID=@SYSTEMID AND FATHERID=0
                                                           order by DISPLAYORDER asc";
        public IList<MD_Menu> GetMenuDefineOfNode(string _nodeCode)
        {
            IList<MD_Menu> _ret = new List<MD_Menu>();

            SqlParameter[] _param = {            
                                new SqlParameter("@SYSTEMID",SqlDbType.NVarChar,12)
                        };
            _param[0].Value = _nodeCode;

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetMenuDefineOfNode, _param);

            while (dr.Read())
            {
                MD_Menu _vt = new MD_Menu();
                _vt.MenuID = dr.GetDouble(0).ToString();
                _vt.MenuName = dr.GetString(1);
                _vt.MenuType = dr.IsDBNull(2) ? "" : dr.GetString(2);
                _vt.MenuParameter = dr.IsDBNull(3) ? "" : dr.GetString(3);
                _vt.DisplayOrder = dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetDouble(4));
                _vt.FatherMenuID = dr.GetDouble(5).ToString();
                _vt.MenuToolTip = dr.IsDBNull(6) ? "" : dr.GetString(6);
                _vt.MenuIcon = dr.IsDBNull(10) ? "" : dr.GetString(10);
                _vt.ShowInToolBar = dr.IsDBNull(8) ? false : (dr.GetString(8) == "Y");
                _vt.SystemID = dr.IsDBNull(9) ? "" : dr.GetString(9);
                _vt.IconName = dr.IsDBNull(10) ? "" : dr.GetString(10);
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }


        private const string SQL_GetSubMenuDefine = @"select ID,MENUNAME,MENUTYPE,MENUCS,
                                                        DISPLAYORDER,FATHERID,MENUTOOLTIP,MENUICON,
                                                        SHOWTOOLBAR,SYSTEMID, ICONNAME
                                                        from MD_MAINMENU where FATHERID=@FID
                                                        order by DISPLAYORDER asc";
        public IList<MD_Menu> GetSubMenuDefine(string _fmenuID)
        {
            IList<MD_Menu> _ret = new List<MD_Menu>();
            SqlParameter[] _param = {            
                                new SqlParameter("@FID",OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_fmenuID);
            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetSubMenuDefine, _param);
            while (dr.Read())
            {
                MD_Menu _vt = new MD_Menu();
                _vt.MenuID = dr.GetDouble(0).ToString();
                _vt.MenuName = dr.GetString(1);
                _vt.MenuType = dr.IsDBNull(2) ? "" : dr.GetString(2);
                _vt.MenuParameter = dr.IsDBNull(3) ? "" : dr.GetString(3);
                _vt.DisplayOrder = dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetDouble(4));
                _vt.FatherMenuID = dr.GetDouble(5).ToString();
                _vt.MenuToolTip = dr.IsDBNull(6) ? "" : dr.GetString(6);
                _vt.MenuIcon = dr.IsDBNull(10) ? "" : dr.GetString(10);
                _vt.ShowInToolBar = dr.IsDBNull(8) ? false : (dr.GetString(8) == "Y");
                _vt.SystemID = dr.GetString(9);
                _vt.IconName = dr.IsDBNull(10) ? "" : dr.GetString(10);

                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }

        public bool SaveMenuDefine(MD_Menu _menu)
        {
            StringBuilder _updateStr = new StringBuilder();
            _updateStr.Append(" update MD_MAINMENU set ");
            _updateStr.Append(" MENUNAME=@MENUNAME,MENUTYPE=@MENUTYPE,MENUCS=@MENUCS,");
            _updateStr.Append(" DISPLAYORDER=@DISPLAYORDER,MENUTOOLTIP=@MENUTOOLTIP,MENUICON=-1, ICONNAME=@ICONNAME,");
            _updateStr.Append(" SHOWTOOLBAR=@SHOWTOOLBAR ");
            _updateStr.Append(" where ID=@ID");
            SqlParameter[] _param = {            
                                new SqlParameter("@MENUNAME",SqlDbType.NVarChar,100),
                                new SqlParameter("@MENUTYPE",SqlDbType.NVarChar,100),
                                new SqlParameter("@MENUCS",SqlDbType.NVarChar,1000),
                                new SqlParameter("@DISPLAYORDER",OracleDbType.Decimal),
                                new SqlParameter("@MENUTOOLTIP",SqlDbType.NVarChar,1000),
                                new SqlParameter("@ICONNAME",SqlDbType.NVarChar),
                                new SqlParameter("@SHOWTOOLBAR",SqlDbType.NVarChar,10),
                                new SqlParameter("@ID",OracleDbType.Decimal)                               
                        };
            _param[0].Value = _menu.MenuName;
            _param[1].Value = _menu.MenuType;
            _param[2].Value = _menu.MenuParameter;
            _param[3].Value = Convert.ToDecimal((int)_menu.DisplayOrder);
            _param[4].Value = _menu.MenuToolTip;
            _param[5].Value = _menu.MenuIcon;
            _param[6].Value = _menu.ShowInToolBar ? "Y" : "N";
            _param[7].Value = decimal.Parse(_menu.MenuID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _updateStr.ToString(), _param);
            return true;
        }

        private const string SQL_AddSystemMenu = @"insert into  MD_MAINMENU
                                                    (ID,MENUNAME,MENUTYPE,MENUCS,DISPLAYORDER,
                                                    FATHERID,MENUTOOLTIP,MENUICON,SHOWTOOLBAR,SYSTEMID )
                                                    VALUES
                                                    (sequences_meta.nextval,'MENU','','',0, 
                                                     0,'',-1,'N',@SYSTEMID )";
        public bool AddSystemMenu(string _nodeCode)
        {

            SqlParameter[] _param = {                                           
                                new SqlParameter("@SYSTEMID",SqlDbType.NVarChar,12)                               
                        };

            _param[0].Value = _nodeCode;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_AddSystemMenu, _param);
            return true;
        }

        private const string SQL_AddSystemSubMenu = @"insert into  MD_MAINMENU
                                                        (ID,MENUNAME,MENUTYPE,MENUCS,DISPLAYORDER,
                                                        FATHERID,MENUTOOLTIP,MENUICON,SHOWTOOLBAR,SYSTEMID )
                                                        VALUES
                                                        (sequences_meta.nextval,'MENU','','',0, 
                                                          @FID,'',-1,'N',@SYSTEMID )   ";
        public bool AddSystemSubMenu(string _fatherMenuID, string SystemID)
        {
            SqlParameter[] _param = {            
                                new SqlParameter("@FID",OracleDbType.Decimal),
                                new SqlParameter("@SYSTEMID",SqlDbType.NVarChar,12)                               
                        };

            _param[0].Value = decimal.Parse(_fatherMenuID);
            _param[1].Value = SystemID;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_AddSystemSubMenu, _param);
            return true;
        }


        public bool DelSystemMenu(string _menuid)
        {
            //判断是否有子菜单
            string _select = "select count(ID) from md_mainmenu where fatherid=@FID";
            SqlParameter[] _param2 = { 
                                new SqlParameter("@FID",OracleDbType.Decimal)
                        };
            _param2[0].Value = decimal.Parse(_menuid);
            decimal _countnum = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _select, _param2);
            if (_countnum > 0) return false;
            //删除
            StringBuilder _delStr = new StringBuilder();
            _delStr.Append(" delete from MD_MAINMENU ");
            _delStr.Append(" where id = @MID ");

            SqlParameter[] _param = { 
                                new SqlParameter(":MID",OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_menuid);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _delStr.ToString(), _param);
            return true;
        }

        public IList<MD_GuideLineGroup> GetGuideLineGroup(string _nodeCode, string _guideLineGroupType)
        {
            IList<MD_GuideLineGroup> _ret = new List<MD_GuideLineGroup>();

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ZBZTMC,ZBZTSM,LX,QXLX,NAMESPACE,SSDW ");
            _sql.Append(" from TJ_ZBZTMCDYB where SSDW=:DWDM and LX=@LX");
            SqlParameter[] _param = {
                                new SqlParameter("@DWDM",SqlDbType.NVarChar,12),
                                new SqlParameter("@LX",OracleDbType.Decimal)
                        };
            _param[0].Value = _nodeCode;
            _param[1].Value = decimal.Parse(_guideLineGroupType);


            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);

            while (dr.Read())
            {
                MD_GuideLineGroup _vt = new MD_GuideLineGroup(
                                dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(2) ? 0 : Convert.ToInt32(dr.GetDouble(2)),
                                dr.IsDBNull(3) ? 0 : Convert.ToInt32(dr.GetDouble(3))
                                );
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;

        }

        public bool SaveGuideLineGroupDefine(MD_GuideLineGroup _GuideLineGroup)
        {
            StringBuilder _updateStr = new StringBuilder();
            _updateStr.Append(" update TJ_ZBZTMCDYB set ");
            _updateStr.Append(" ZBZTSM=@ZBZTSM,LX=@LX,");
            _updateStr.Append(" QXLX=@QXLX,NAMESPACE=@NAMESPACE ");
            _updateStr.Append(" where ZBZTMC=@ZBZTMC");
            SqlParameter[] _param = {            
                                new SqlParameter("@ZBZTSM",SqlDbType.NVarChar,200),
                                new SqlParameter("@LX",OracleDbType.Decimal),
                                new SqlParameter("@QXLX",OracleDbType.Decimal),
                                new SqlParameter("@NAMESPACE",SqlDbType.NVarChar,50),
                                new SqlParameter("@ZBZTMC",SqlDbType.NVarChar,200)                                                           
                        };

            _param[0].Value = _GuideLineGroup.ZBZTSM;
            _param[1].Value = Convert.ToDecimal(_GuideLineGroup.LX);
            _param[2].Value = Convert.ToDecimal(_GuideLineGroup.QXLX);
            _param[3].Value = _GuideLineGroup.NamespaceName;
            _param[4].Value = _GuideLineGroup.ZBZTMC;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _updateStr.ToString(), _param);
            return true;
        }

        public IList<MD_GuideLine> GetGuideLineOfGroup(string _groupName)
        {
            IList<MD_GuideLine> _ret = new List<MD_GuideLine>();

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ID,ZBMC,ZBZT,ZBSF, ZBMETA,FID,ZBCXSF,JSMX_ZBMETA,XSXH,ZBSM ");
            _sql.Append(" from TJ_ZDYZBDYB where ZBZT=@ZBZT and FID=1 order by XSXH ASC");
            SqlParameter[] _param = {
                                new SqlParameter("@ZBZT",SqlDbType.NVarChar,200)
                               
                        };
            _param[0].Value = _groupName;

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);

            while (dr.Read())
            {
                MD_GuideLine _vt = new MD_GuideLine(
                                dr.GetDouble(0).ToString(),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "0" : dr.GetDouble(5).ToString(),
                                dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? "" : dr.GetString(7),
                                dr.IsDBNull(8) ? 0 : Convert.ToInt32(dr.GetDouble(8)),
                                 dr.IsDBNull(9) ? "" : dr.GetString(9)
                                );
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }

        public IList<MD_GuideLine> GetChildGuideLines(string _fatherGuildLineID)
        {
            IList<MD_GuideLine> _ret = new List<MD_GuideLine>();

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ID,ZBMC,ZBZT,ZBSF, ZBMETA,FID,ZBCXSF,JSMX_ZBMETA,XSXH,ZBSM ");
            _sql.Append(" from TJ_ZDYZBDYB where FID=@FID ORDER BY XSXH ASC ");
            SqlParameter[] _param = {
                                new SqlParameter(":FID",OracleDbType.Decimal)
                               
                        };
            _param[0].Value = decimal.Parse(_fatherGuildLineID);

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);

            while (dr.Read())
            {
                MD_GuideLine _vt = new MD_GuideLine(
                                dr.GetDouble(0).ToString(),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "0" : dr.GetDouble(5).ToString(),
                                dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? "" : dr.GetString(7),
                                dr.IsDBNull(8) ? 0 : Convert.ToInt32(dr.GetDouble(8)),
                                 dr.IsDBNull(9) ? "" : dr.GetString(9)
                                );
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }

        public bool DelGuideLineGroup(string _guideLineGroupName)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("delete tj_zbztmcdyb   ");
            _sb.Append(" where ZBZTMC=@ZBZTMC ");
            SqlParameter[] _param = {
                                 new SqlParameter("@ZBZTMC", SqlDbType.NVarChar, 100)   
                        };
            _param[0].Value = _guideLineGroupName;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        public bool IsExistChildOfGuideLineGroup(string _groupName)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select count(id) ");
            _sql.Append(" from TJ_ZDYZBDYB where ZBZT=@ZBZT and FID=1");
            SqlParameter[] _param = {
                                new SqlParameter("@ZBZT",SqlDbType.NVarChar,200)                               
                        };
            _param[0].Value = _groupName;

            decimal _count = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);
            return (_count > 0);
        }

        public bool IsExistGuideLineGroupName(string _guideLineGroupName)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select count(ZBZTMC) ");
            _sql.Append(" from tj_zbztmcdyb ");
            _sql.Append(" where ZBZTMC=@ZBZTMC ");
            SqlParameter[] _param = {
                                 new SqlParameter("@ZBZTMC", SqlDbType.NVarChar, 100)   
                        };
            _param[0].Value = _guideLineGroupName;

            decimal _count = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);
            return (_count > 0);
        }


        public bool SaveNewGuideLineGroupDefine(MD_GuideLineGroup _guideLineGroup)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("INSERT INTO TJ_ZBZTMCDYB   ");
            _sb.Append(" (ZBZTMC,ZBZTSM,LX,QXLX,NAMESPACE,SSDW) VALUES ");
            _sb.Append(" (@ZBZTMC,@ZBZTSM,@LX,@QXLX,@NAMESPACE,@SSDW) ");
            SqlParameter[] _param = {
                                 new SqlParameter("@ZBZTMC", SqlDbType.NVarChar, 200),
                                 new SqlParameter("@ZBZTSM", SqlDbType.NVarChar, 200),
                                 new SqlParameter("@LX", OracleDbType.Decimal),
                                 new SqlParameter("@QXLX", OracleDbType.Decimal),
                                 new SqlParameter("@NAMESPACE", SqlDbType.NVarChar, 50),
                                 new SqlParameter("@SSDW", SqlDbType.NVarChar, 12)

                        };
            _param[0].Value = _guideLineGroup.ZBZTMC;
            _param[1].Value = _guideLineGroup.ZBZTSM;
            _param[2].Value = Convert.ToDecimal(_guideLineGroup.LX);
            _param[3].Value = Convert.ToDecimal(_guideLineGroup.QXLX);
            _param[4].Value = _guideLineGroup.NamespaceName;
            _param[5].Value = _guideLineGroup.SSDW;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        public bool SaveNewGuideLine(string _guideLineName, decimal _fid, string _guideLineGroupName)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("INSERT INTO TJ_ZDYZBDYB   ");
            _sb.Append(" (ID,ZBMC,ZBZT,FID,XSXH) VALUES ");
            _sb.Append(" (sequences_meta.nextval,@ZBMC,@ZBZT,@FID,0) ");
            SqlParameter[] _param = {
                                 new SqlParameter("@ZBMC", SqlDbType.NVarChar, 200),
                                 new SqlParameter("@ZBZT", SqlDbType.NVarChar, 200),
                                 new SqlParameter("@FID", OracleDbType.Decimal)                                

                        };
            _param[0].Value = _guideLineName;
            _param[1].Value = _guideLineGroupName;
            _param[2].Value = _fid;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }


        public bool IsExistGuideLineID(string _guideLineID)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select count(ID) ");
            _sql.Append(" from TJ_ZDYZBDYB ");
            _sql.Append(" where ID=@ID ");
            SqlParameter[] _param = {
                                 new SqlParameter("@ID", OracleDbType.Decimal)   
                        };
            _param[0].Value = decimal.Parse(_guideLineID);

            decimal _count = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);
            return (_count > 0);

        }


        public bool IsExistChildOfGuideLine(string _guideLineID)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select count(ID) ");
            _sql.Append(" from TJ_ZDYZBDYB ");
            _sql.Append(" where FID=@FID ");
            SqlParameter[] _param = {
                                 new SqlParameter("@FID", OracleDbType.Decimal)   
                        };
            _param[0].Value = decimal.Parse(_guideLineID);

            decimal _count = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);
            return (_count > 0);
        }

        public bool DelGuideLine(string _guideLineID)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" delete from tj_zdyzbdyb where id in   ");
            _sb.Append(" (select t.id from tj_zdyzbdyb t  ");
            _sb.Append("    START WITH   id =@ID  CONNECT BY PRIOR  id=fid )");
            SqlParameter[] _param = {
                                 new SqlParameter("@ID", OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_guideLineID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        public bool SaveGuideLine(MD_GuideLine _guideLine)
        {
            string _metaStr1 = "";
            string _metaStr2 = "";
            StringBuilder _sb = new StringBuilder();
            _sb.Append("update TJ_ZDYZBDYB   ");
            _sb.Append(" set ZBMC=@ZBMC,ZBSF=@ZBSF,ZBMETA=@ZBMETA,XSXH=@XSXH,JSMX_ZBMETA=@JSMXMETA ,ZBSM=@ZBSM");
            _sb.Append(" where ID=@ID ");
            SqlParameter[] _param = {
                                new SqlParameter("@ZBMC", SqlDbType.NVarChar,200),
                                new SqlParameter("@ZBSF", SqlDbType.NVarChar,4000),
                                new SqlParameter("@ZBMETA", SqlDbType.NVarChar,4000),
                                new SqlParameter("@XSXH", OracleDbType.Decimal),
                                new SqlParameter("@JSMXMETA",SqlDbType.NVarChar,4000),
                                new SqlParameter("@ZBSM",SqlDbType.NVarChar,4000),
                                new SqlParameter("@ID", OracleDbType.Decimal)
                        };

            SplitMetaString(_guideLine.GuideLineMeta, ref _metaStr1, ref _metaStr2);
            //if (_guideLine.GuideLineMeta.Length > 3700)
            //{
            //        _metaStr1 = _guideLine.GuideLineMeta.Substring(0, 3700);
            //        _metaStr2 = _guideLine.GuideLineMeta.Substring(3700);
            //}
            //else
            //{
            //        _metaStr1 = _guideLine.GuideLineMeta;
            //        _metaStr2 = "";
            //}

            _param[0].Value = _guideLine.GuideLineName;
            _param[1].Value = _guideLine.GuideLineMethod;
            _param[2].Value = _metaStr1;
            _param[3].Value = Convert.ToDecimal(_guideLine.DisplayOrder);
            _param[4].Value = _metaStr2;
            _param[5].Value = _guideLine.Description;
            _param[6].Value = decimal.Parse(_guideLine.ID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        private void SplitMetaString(string fullString, ref string _metaStr1, ref string _metaStr2)
        {

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand("ZHTJ_COMM.SplitString", cn);
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("strInput", fullString);
                    _cmd.Parameters.Add("nLen", (decimal)3900);
                   // _cmd.Parameters.Add(new SqlParameter("str1", SqlDbType.NVarChar, 4000, "", ParameterDirection.Output));
                    //_cmd.Parameters.Add(new SqlParameter("str2", SqlDbType.NVarChar, 4000, "", ParameterDirection.Output));
                    _cmd.ExecuteScalar();

                    _metaStr1 = _cmd.Parameters[2].Value.ToString();
                    _metaStr2 = _cmd.Parameters[3].Value.ToString();

                    cn.Close();
                }
                catch (Exception ex)
                {
                    string _errmsg = string.Format("执行ZHTJ_COMM.SplitString出错,错误信息为:{0}!",
                               ex.Message);

                    LogWriter.WriteSystemLog(_errmsg, "ERROR");
                    throw ex;
                }
            }
            return;
        }

        public bool SaveNewGuideLine(MD_GuideLine _guideLine)
        {
            string _metaStr1 = "";
            string _metaStr2 = "";
            StringBuilder _sb = new StringBuilder();
            _sb.Append("INSERT INTO TJ_ZDYZBDYB   ");
            _sb.Append(" (ID,ZBMC,ZBZT,FID,XSXH,ZBMETA,ZBSF,JSMX_ZBMETA) VALUES ");
            _sb.Append(" (@ID,@ZBMC,@ZBZT,@FID,@XSXH,@ZBMETA,@ZBSF,@JSMXMETA) ");
            SqlParameter[] _param = {
                                 new SqlParameter("@ID",OracleDbType.Decimal),
                                 new SqlParameter("@ZBMC", SqlDbType.NVarChar, 200),
                                 new SqlParameter("@ZBZT", SqlDbType.NVarChar, 200),
                                 new SqlParameter("@FID", OracleDbType.Decimal),
                                new SqlParameter("@XSXH",OracleDbType.Decimal),
                                new SqlParameter("@ZBMETA",SqlDbType.NVarChar,4000), 
                                new SqlParameter("@ZBSF",SqlDbType.NVarChar,4000),
                                new SqlParameter("@JSMXMETA",SqlDbType.NVarChar,4000)
                        };
            SplitMetaString(_guideLine.GuideLineMeta, ref _metaStr1, ref _metaStr2);
            //if (_guideLine.GuideLineMeta.Length > 3700)
            //{
            //        _metaStr1 = _guideLine.GuideLineMeta.Substring(0, 3700);
            //        _metaStr2 = _guideLine.GuideLineMeta.Substring(3700);
            //}
            //else
            //{
            //        _metaStr1 = _guideLine.GuideLineMeta;
            //        _metaStr2 = "";
            //}
            _param[0].Value = decimal.Parse(_guideLine.ID);
            _param[1].Value = _guideLine.GuideLineName;
            _param[2].Value = _guideLine.GroupName;
            _param[3].Value = decimal.Parse(_guideLine.FatherID);
            _param[4].Value = Convert.ToDecimal(_guideLine.DisplayOrder);
            _param[5].Value = _metaStr1;
            _param[6].Value = _guideLine.GuideLineMethod;
            _param[7].Value = _metaStr2;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }


        public IList<MD_ConceptGroup> GetConceptGroups()
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetConceptList();
        }

        public List<MD_ConceptItem> GetSubConceptTagDefine(string _groupName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetSubConceptTag(_groupName);
        }

        public bool SaveConceptGroup(MD_ConceptGroup _ConceptGroup)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("update md_conceptgroup ");
            _sb.Append(" set groupdes=@DESCRIPT,displayorder=@DISPLAYORDER ");
            _sb.Append(" where groupname=@GROUPNAME ");
            SqlParameter[] _param = {
                                new SqlParameter("@DESCRIPT", SqlDbType.NVarChar),
                                new SqlParameter("@DISPLAYORDER", OracleDbType.Decimal),
                                new SqlParameter("@GROUPNAME", SqlDbType.NVarChar)
                        };
            _param[0].Value = _ConceptGroup.Description;
            _param[1].Value = Convert.ToDecimal(_ConceptGroup.DisplayOrder);
            _param[2].Value = _ConceptGroup.Name;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool IsExistConceptGroup(string _groupName)
        {
            string _sql = "select count(*) from md_conceptgroup WHERE groupname =@GROUPNAME";
            SqlParameter[] _param = {            
                                new SqlParameter("@GROUPNAME",SqlDbType.NVarChar)                                
                        };
            _param[0].Value = _groupName;

            decimal _count = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return (_count > 0);
        }

        public bool AddNewConceptGroup(string _groupName)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("insert into  md_conceptgroup ");
            _sb.Append(" (GROUPNAME,GROUPDES,DWDM,DISPLAYORDER )");
            _sb.Append(" VALUES (@GROUPNAME,'','',0) ");
            SqlParameter[] _param = {                            
                                new SqlParameter("@GROUPNAME", SqlDbType.NVarChar)
                        };
            _param[0].Value = _groupName;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        public bool DelConcpetGroup(string _groupName)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("delete from  md_conceptgroup ");
            _sb.Append(" where GROUPNAME=@GROUPNAME ");
            SqlParameter[] _param = {                            
                                new SqlParameter("@GROUPNAME", SqlDbType.NVarChar)
                        };
            _param[0].Value = _groupName;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool IsExistChildOfConceptGroup(string _groupName)
        {
            string _sql = "select count(*) from md_concept WHERE groupname =@GROUPNAME";
            SqlParameter[] _param = {            
                                new SqlParameter("@GROUPNAME",SqlDbType.NVarChar)                                
                        };
            _param[0].Value = _groupName;

            decimal _count = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return (_count > 0);
        }

        public bool IsExistConceptTag(string _TagName)
        {
            string _sql = "select count(*) from md_concept WHERE CTAG =@CTAG";
            SqlParameter[] _param = {            
                                new SqlParameter("@CTAG",SqlDbType.NVarChar)                                
                        };
            _param[0].Value = _TagName;

            decimal _count = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return (_count > 0);
        }

        public bool AddNewConceptTag(string _TagName, string _description, string _groupName)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("insert into  md_concept ");
            _sb.Append(" (CTAG,DESCRIPT,GROUPNAME,DWDM,DISPLAYORDER )");
            _sb.Append(" VALUES (@CTAG,@DESCRIPT,@GROUPNAME,'',0) ");
            SqlParameter[] _param = {                            
                                new SqlParameter("@CTAG", SqlDbType.NVarChar),
                                new SqlParameter("@DESCRIPT", SqlDbType.NVarChar),
                                new SqlParameter("@GROUPNAME", SqlDbType.NVarChar)
                        };
            _param[0].Value = _TagName;
            _param[1].Value = _description;
            _param[2].Value = _groupName;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        public bool SaveConceptTag(MD_ConceptItem _ConceptItem)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("update md_concept ");
            _sb.Append(" set DESCRIPT=@DESCRIPT,displayorder=@DISPLAYORDER ");
            _sb.Append(" where CTAG=@CTAG ");
            SqlParameter[] _param = {
                                new SqlParameter("@DESCRIPT", SqlDbType.NVarChar),
                                new SqlParameter("@DISPLAYORDER", OracleDbType.Decimal),
                                new SqlParameter("@CTAG", SqlDbType.NVarChar)
                        };
            _param[0].Value = _ConceptItem.Description;
            _param[1].Value = Convert.ToDecimal(_ConceptItem.DisplayOrder);
            _param[2].Value = _ConceptItem.CTag;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool DelConceptTag(string _CTag)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("delete from md_concept ");
            _sb.Append(" where CTAG=@CTAG ");
            SqlParameter[] _param = {                            
                                new SqlParameter("@CTAG", SqlDbType.NVarChar)
                        };
            _param[0].Value = _CTag;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public MD_GuideLine GetGuideLineDefine(string _guideLineID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            List<MD_GuideLine> _glist = _of.GetRootGuideLineList(_guideLineID);
            if (_glist.Count > 0) return _glist[0];
            return null;
        }

        public List<MD_RightDefine> GetRightData()
        {
            List<MD_RightDefine> _ret = new List<MD_RightDefine>();

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select QXID,QXMC,QXMS,QXLX,QXMETA,XH,MENUID,SJQXID ");
            _sql.Append(" from qx_qxdyb order by xh");

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString());

            while (dr.Read())
            {
                MD_RightDefine _rd = new MD_RightDefine(dr.IsDBNull(0) ? "" : dr.GetDouble(0).ToString(),
                                dr.IsDBNull(7) ? "" : dr.GetDouble(7).ToString(),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDouble(5)),
                                dr.IsDBNull(6) ? "" : dr.GetDouble(6).ToString()
                                );
                _ret.Add(_rd);
            }
            dr.Close();
            return _ret;
        }

        private const string SQL_GetRightData = @"select QXID,QXMC,QXMS,QXLX,QXMETA,XH,MENUID,SJQXID
										from qx_qxdyb 
										where menuid in
										(select m.id from md_mainmenu m where m.systemid=@SYSTEMID) 
										order by xh	";
        public List<MD_RightDefine> GetRightData(string SystemID)
        {
            List<MD_RightDefine> _ret = new List<MD_RightDefine>();
            SqlParameter[] _param = {                            
                                new SqlParameter("@SYSTEMID", SqlDbType.NVarChar)
                        };
            _param[0].Value = SystemID;

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetRightData, _param);
            while (dr.Read())
            {
                MD_RightDefine _rd = new MD_RightDefine(dr.IsDBNull(0) ? "" : dr.GetDouble(0).ToString(),
                                dr.IsDBNull(7) ? "" : dr.GetDouble(7).ToString(),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDouble(5)),
                                dr.IsDBNull(6) ? "" : dr.GetDouble(6).ToString()
                                );
                _ret.Add(_rd);
            }
            dr.Close();
            return _ret;
        }

        private const string SQL_SetFlag = @"update qx_qxdyb set xh=-1 where QXLX<>'固定菜单'";
        private const string SQL_ClearRightsOfNoUse = "delete from qx_qxdyb where QXLX<>'固定菜单' and xh<0";
        private const string SQL_GetAppRights = @"select t.qxid,t.qxmc,t.qxms,'功能注册菜单',t.sjqxid,t.qxmeta,t.xh,t.qxid / 1000 menuid ,
                                                    (select count(qxid) from qx_qxdyb qx where qx.qxid=t.qxid) gs from md_appqxdyb t";

        private const string SQL_InsertAppRights = @"insert into qx_qxdyb (qxid,qxmc,qxms,qxlx,sjqxid,qxmeta,xh,menuid)
                                                            values (@QXID,@QXMC,@QXMS,@QXLX,@SJQXID,@QXMETA,@XH,@MENUID)";
        private const string SQL_UpdateAppRights = @"update qx_qxdyb set qxmc=@QXMC,qxms=@QXMS,qxlx=@QXLX,sjqxid=@SJQXID,qxmeta=@QXMETA,xh=@XH,menuid=@MENUID 
                                                             where qxid=@QXID";
        public bool SaveRightDefine(List<MD_RightDefine> _rightList)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction txn = cn.BeginTransaction();
                try
                {
                    #region 设置清除标志

                    SqlCommand _setFlagCmd = new SqlCommand(SQL_SetFlag, cn);
                    _setFlagCmd.ExecuteNonQuery();
                    #endregion

                    foreach (MD_RightDefine _rd in _rightList)
                    {
                        bool _isExist = FindRightByID(_rd, cn);
                        if (_isExist)
                        {
                            //使用UPDATE
                            UpdateRightDefine(_rd, cn);
                        }
                        else
                        {
                            //使用INSERT
                            InsertRightDefine(_rd, cn);
                        }
                    }
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    cn.Close();
                    throw new Exception(string.Format("更新菜单项限项时发出错误：{0}", ex.Message));
                }

                try
                {
                    #region 取功能注册中定义的权限项并更新
                    SqlCommand _getRightCmd = new SqlCommand(SQL_GetAppRights, cn);
                    SqlDataReader _dr = _getRightCmd.ExecuteReader();
                    while (_dr.Read())
                    {
                        decimal qxid = _dr.IsDBNull(0) ? (decimal)-1 : (decimal)_dr.GetDouble(0);
                        string qxmc = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                        string qxms = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                        string qxlx = "功能注册菜单";
                        decimal sjqxid = _dr.IsDBNull(4) ? (decimal)-1 : (decimal)_dr.GetDouble(4);
                        string qxmeta = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                        decimal xh = _dr.IsDBNull(6) ? (decimal)0 : (decimal)_dr.GetDouble(6);
                        decimal menuid = _dr.IsDBNull(7) ? (decimal)-1 : (decimal)_dr.GetDouble(7);
                        decimal gs = _dr.IsDBNull(8) ? (decimal)0 : (decimal)_dr.GetDouble(8);

                        if (gs > 0)
                        {
                            #region 更新权限定义记录
                            SqlCommand _updateAppRight = new SqlCommand(SQL_UpdateAppRights, cn);
                            _updateAppRight.Parameters.Add("@QXMC", qxmc);
                            _updateAppRight.Parameters.Add("@QXMS", qxms);
                            _updateAppRight.Parameters.Add("@QXLX", qxlx);
                            _updateAppRight.Parameters.Add("@SJQXID", sjqxid);
                            _updateAppRight.Parameters.Add("@QXMETA", qxmeta);
                            _updateAppRight.Parameters.Add("@XH", xh);
                            _updateAppRight.Parameters.Add("@MENUID", menuid);
                            _updateAppRight.Parameters.Add("@QXID", qxid);
                            _updateAppRight.ExecuteNonQuery();
                            #endregion
                        }
                        else
                        {
                            #region 插入新权限定义记录
                            SqlCommand _insAppRight = new SqlCommand(SQL_InsertAppRights, cn);
                            _insAppRight.Parameters.Add("@QXID", qxid);
                            _insAppRight.Parameters.Add("@QXMC", qxmc);
                            _insAppRight.Parameters.Add("@QXMS", qxms);
                            _insAppRight.Parameters.Add("@QXLX", qxlx);
                            _insAppRight.Parameters.Add("@SJQXID", sjqxid);
                            _insAppRight.Parameters.Add("@QXMETA", qxmeta);
                            _insAppRight.Parameters.Add("@XH", xh);
                            _insAppRight.Parameters.Add("@MENUID", menuid);
                            _insAppRight.ExecuteNonQuery();
                            #endregion
                        }
                    }
                    _dr.Close();

                    #endregion

                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    cn.Close();
                    throw new Exception(string.Format("插入功能注册中定义的权限项时发出错误：{0}", ex.Message));
                }

                try
                {
                    #region 清除要删除的无用记录
                    SqlCommand _delCmd = new SqlCommand(SQL_ClearRightsOfNoUse, cn);
                    _delCmd.ExecuteNonQuery();
                    #endregion
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    cn.Close();
                    throw new Exception(string.Format("清除非固定菜单的多余记录时发出错误：{0}", ex.Message));
                }


                txn.Commit();
                cn.Close();
                return true;
            }

        }

        private bool FindRightByID(MD_RightDefine _rd, SqlConnection cn)
        {
            string _sql = "select count(QXID) from qx_qxdyb where QXID=@QXID";
            SqlCommand _cmd = new SqlCommand(_sql, cn);
            _cmd.Parameters.Add("@QXID", decimal.Parse(_rd.RightID));
            decimal _ret = (decimal)_cmd.ExecuteScalar();
            return _ret > 0;
        }

        private const string SQL_UpdateRightDefine = @"update  qx_qxdyb
                                                       set QXMC=@QXMC,QXMS=@QXMS,QXLX=@QXLX,QXMETA=@QXMETA,
                                                         XH=@XH,MENUID=@MENUID,SJQXID=@SJQXID
                                                        WHERE QXID=@QXID ";
        private void UpdateRightDefine(MD_RightDefine _rd, SqlConnection cn)
        {
            //添加新权限表内容           
            SqlCommand _cmd = new SqlCommand(SQL_UpdateRightDefine, cn);
            _cmd.Parameters.Add("@QXMC", _rd.RightName);
            _cmd.Parameters.Add("@QXMS", _rd.RightDescript);
            _cmd.Parameters.Add("@QXLX", _rd.RightType);
            _cmd.Parameters.Add("@QXMETA", _rd.RightMeta);
            _cmd.Parameters.Add("@XH", Convert.ToDecimal(_rd.DisplayOrder));
            _cmd.Parameters.Add("@MENUID", decimal.Parse(_rd.MenuID));
            _cmd.Parameters.Add("@SJQXID", (_rd.FatherRightID == "") ? (decimal)-1 : decimal.Parse(_rd.FatherRightID));
            _cmd.Parameters.Add("@QXID", decimal.Parse(_rd.RightID));
            _cmd.ExecuteNonQuery();
        }

        private const string SQL_InsertRightDefine = @"insert into qx_qxdyb
                                                        (QXID,QXMC,QXMS,QXLX,QXMETA,XH,MENUID,SJQXID) values 
                                                        (@QXID,@QXMC,@QXMS,@QXLX,@QXMETA,@XH,@MENUID,@SJQXID)";
        private void InsertRightDefine(MD_RightDefine _rd, SqlConnection cn)
        {
            //添加新权限表内容

            SqlCommand _cmd = new SqlCommand(SQL_InsertRightDefine, cn);
            _cmd.Parameters.Add("@QXID", decimal.Parse(_rd.RightID));
            _cmd.Parameters.Add("@QXMC", _rd.RightName);
            _cmd.Parameters.Add("@QXMS", _rd.RightDescript);
            _cmd.Parameters.Add("@QXLX", _rd.RightType);
            _cmd.Parameters.Add("@QXMETA", _rd.RightMeta);
            _cmd.Parameters.Add("@XH", Convert.ToDecimal(_rd.DisplayOrder));
            _cmd.Parameters.Add("@MENUID", decimal.Parse(_rd.MenuID));
            _cmd.Parameters.Add("@SJQXID", (_rd.FatherRightID == "") ? (decimal)-1 : decimal.Parse(_rd.FatherRightID));
            _cmd.ExecuteNonQuery();
        }



        public string AddTableRelationView(string _tableID, string _modelName)
        {
            //查找是否已经有此关联定义
            string _isExistSql = "select count(id) from MD_TABLE2VIEW where TID=@TID and VIEWNAME=@VIEWNAME ";
            SqlParameter[] _isParam = {                            
                                new SqlParameter("@TID", OracleDbType.Decimal),
                                new SqlParameter("@VIEWNAME",SqlDbType.NVarChar,1000)
                        };
            _isParam[0].Value = decimal.Parse(_tableID);
            _isParam[1].Value = _modelName;

            decimal _isResult = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, _isExistSql, _isParam);
            if (_isResult > 0)
            {
                return string.Format("此表对应查询模型[{0}]的关联定义已经存在!", _modelName);
            }

            //添加关联定义
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" insert into MD_TABLE2VIEW (ID,TID,VIEWNAME,CONDITIONSTR) ");
            _sb.Append(" values (@ID,@TID,@VIEWNAME,'') ");
            SqlParameter[] _Param = {                            
                                new SqlParameter("@ID", Guid.NewGuid().ToString()),
                                new SqlParameter("@TID",decimal.Parse(_tableID)),
                                new SqlParameter("@VIEWNAME",_modelName)
                        };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _Param);
            return "";
        }

        private const string SQL_GetAllQueryModelNames = @"select NAMESPACE,VIEWNAME from MD_VIEW ";
        public List<string> GetAllQueryModelNames()
        {
            List<string> _ret = new List<string>();
            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetAllQueryModelNames);

            while (dr.Read())
            {
                _ret.Add(string.Format("{0}.{1}",
                                dr.IsDBNull(0) ? "" : dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetString(1)
                )
                );
            }
            dr.Close();
            return _ret;
        }

        private const string SQL_GetTable2ViewList = @"select ID,TID,VIEWNAME,CONDITIONSTR,CONFINE from MD_TABLE2VIEW where TID=@TID";
        public List<MD_Table2View> GetTable2ViewList(string _tid)
        {
            List<MD_Table2View> _ret = new List<MD_Table2View>();
            SqlParameter[] _Param = { new SqlParameter("@TID", decimal.Parse(_tid)) };
            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetTable2ViewList, _Param);

            while (dr.Read())
            {
                MD_Table2View _t2v = new MD_Table2View(
                                dr.IsDBNull(0) ? "" : dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetDouble(1).ToString(),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4));
                _ret.Add(_t2v);
            }
            dr.Close();
            return _ret;
        }

        private const string SQL_GetView2GuideLineList = @"select ID,VIEWID,TARGETGL,TARGETCS,DISPLAYORDER,DISPLAYTITLE from MD_VIEW2GL where VIEWID=@VID order by DISPLAYORDER";
        public IList<MD_View_GuideLine> GetView2GuideLineList(string QueryModelID)
        {
            List<MD_View_GuideLine> _ret = new List<MD_View_GuideLine>();
            SqlParameter[] _Param = { new SqlParameter("@VID", QueryModelID) };
            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_GetView2GuideLineList, _Param);
            while (dr.Read())
            {
                MD_View_GuideLine _mvg = new MD_View_GuideLine();
                _mvg.ID = dr.IsDBNull(0) ? "" : dr.GetString(0);
                _mvg.ViewID = dr.IsDBNull(1) ? "" : dr.GetString(1);
                _mvg.TargetGuideLineID = dr.IsDBNull(2) ? "" : dr.GetString(2);
                _mvg.RelationParam = dr.IsDBNull(3) ? "" : dr.GetString(3);
                _mvg.DisplayOrder = dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetDouble(4));
                _mvg.DisplayTitle = dr.IsDBNull(5) ? "" : dr.GetString(5);
                _ret.Add(_mvg);
            }
            dr.Close();
            return _ret;
        }

        public bool SaveQueryModel_UserDefine(string _queryModelID, string _display, string _descript)
        {
            try
            {
                string _ups = "update MD_VIEW set displayname=@DISPLAYNAME, DESCRIPTION=@DESCRIPTION ";
                _ups += " where VIEWID=@VIEWID ";
                SqlParameter[] _params = {                            
                                        new SqlParameter("@DISPLAYNAME", SqlDbType.NVarChar,100),
                                        new SqlParameter("@DESCRIPTION",SqlDbType.NVarChar,100),
                                        new SqlParameter("@VIEWID",OracleDbType.Decimal)
                                 };
                _params[0].Value = _display;
                _params[1].Value = _descript;
                _params[2].Value = decimal.Parse(_queryModelID);

                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _ups, _params);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool SaveViewTable_UserDefine(string _viewTableID, string _displayString, MDType_DisplayType _displayType, List<MD_ViewTableColumn> TableColumnDefine)
        {
            #region 更新MD_VIEWTABLE表
            string _ups = "update md_viewtable set DISPLAYNAME=@DISPLAYNAME,DISPLAYTYPE=@DISPLAYTYPE where VTID=@VTID";
            SqlParameter[] _param = {
                                new SqlParameter("@DISPLAYNAME", SqlDbType.NVarChar),
                                new SqlParameter("@DISPLAYTYPE",OracleDbType.Decimal),
                               new SqlParameter("@VTID",OracleDbType.Decimal)
                        };
            _param[0].Value = _displayString;
            _param[1].Value = (_displayType == MDType_DisplayType.FormType) ? (decimal)1 : (decimal)0;
            _param[2].Value = decimal.Parse(_viewTableID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _ups, _param);

            #endregion

            #region 更新MD_TABLECOLUMN表
            string _up = "update md_tablecolumn set DISPLAYTITLE=@DISPLAYTITLE,DISPLAYLENGTH=@DISPLAYLENGTH,DISPLAYHEIGHT=@DISPLAYHEIGHT,DISPLAYORDER=@DISPLAYORDER,colwidth=@DISPLAYWIDTH ";
            _up += " WHERE TCID=@TCID ";
            foreach (MD_ViewTableColumn _tc in TableColumnDefine)
            {
                SqlParameter[] _param4 = {
                                        new SqlParameter("@DISPLAYTITLE", SqlDbType.NVarChar,50),
                                        new SqlParameter("@DISPLAYLENGTH", OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYHEIGHT", OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYORDER", OracleDbType.Decimal),  
                                        new SqlParameter("@DISPLAYWIDTH",OracleDbType.Decimal),
                                        new SqlParameter("@TCID",OracleDbType.Decimal)
                                };
                _param4[0].Value = _tc.TableColumn.DisplayTitle;
                _param4[1].Value = Convert.ToDecimal(_tc.TableColumn.DisplayLength);
                _param4[2].Value = Convert.ToDecimal(_tc.TableColumn.DisplayHeight);
                _param4[3].Value = Convert.ToDecimal(_tc.DisplayOrder);
                _param4[4].Value = Convert.ToDecimal(_tc.TableColumn.ColWidth);
                _param4[5].Value = decimal.Parse(_tc.ColumnID);
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _up, _param4);
            }
            #endregion


            #region 更新MD_VIEWTABLECOLUMN表
            //清除所有字段定义
            string _del = "delete from MD_VIEWTABLECOLUMN where VTID=@VTID";
            SqlParameter[] _param2 = {
                               new SqlParameter("@VTID",OracleDbType.Decimal)
                        };
            _param2[0].Value = Convert.ToDecimal(_viewTableID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _del, _param2);

            StringBuilder _sb = new StringBuilder();
            _sb.Append(" insert into MD_VIEWTABLECOLUMN (VTCID,VTID,TCID,");
            _sb.Append(" CANCONDITIONSHOW,CANRESULTSHOW,DEFAULTSHOW,");
            _sb.Append(" DWDM,FIXQUERYITEM,CANMODIFY,PRIORITY,DISPLAYORDER) ");
            _sb.Append(" VALUES (@VTCID,@VTID,@TCID,");
            _sb.Append("@CANCONDITIONSHOW,@CANRESULTSHOW,@DEFAULTSHOW,");
            _sb.Append(" @DWDM,@FIXQUERYITEM,@CANMODIFY,@PRIORITY,@DISPLAYORDER) ");
            //保存字段定义信息
            foreach (MD_ViewTableColumn _tc in TableColumnDefine)
            {
                SqlParameter[] _param3 = {
                                        new SqlParameter("@VTCID", OracleDbType.Decimal),
                                        new SqlParameter("@VTID", OracleDbType.Decimal),
                                        new SqlParameter("@TCID", OracleDbType.Decimal),
                                        new SqlParameter("@CANCONDITIONSHOW", OracleDbType.Decimal),
                                        new SqlParameter("@CANRESULTSHOW", OracleDbType.Decimal),
                                        new SqlParameter("@DEFAULTSHOW", OracleDbType.Decimal),
                                        new SqlParameter("@DWDM",SqlDbType.NVarChar,12),
                                        new SqlParameter("@FIXQUERYITEM",OracleDbType.Decimal),
                                        new SqlParameter("@CANMODIFY",OracleDbType.Decimal),
                                        new SqlParameter("@PRIORITY",OracleDbType.Decimal),
                                        new SqlParameter("@DISPLAYORDER",OracleDbType.Decimal)
                                };
                _param3[0].Value = Convert.ToDecimal(_tc.ViewTableColumnID);
                _param3[1].Value = Convert.ToDecimal(_viewTableID);
                _param3[2].Value = Convert.ToDecimal(_tc.ColumnID);
                _param3[3].Value = _tc.CanShowAsCondition ? 1 : 0;
                _param3[4].Value = _tc.CanShowAsResult ? 1 : 0;
                _param3[5].Value = _tc.DefaultResult ? 1 : 0;
                _param3[6].Value = _tc.DWDM;
                _param3[7].Value = _tc.IsFixQueryItem ? 1 : 0;
                _param3[8].Value = _tc.CanModify ? 1 : 0;
                _param3[9].Value = Convert.ToDecimal(_tc.Priority);
                _param3[10].Value = Convert.ToDecimal(_tc.DisplayOrder);
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param3);
            }
            #endregion

            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }


        public void SaveViewTableOrder_UserDefine(Dictionary<string, int> ChildTableOrder)
        {
            string _ups = "update md_viewtable set DISPLAYORDER=@DISPLAYORDER where VTID=@VTID";

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction txn = cn.BeginTransaction();
                try
                {
                    foreach (string _s in ChildTableOrder.Keys)
                    {
                        SqlCommand _cmd = new SqlCommand(_ups, cn);
                        _cmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(ChildTableOrder[_s]));
                        _cmd.Parameters.Add("@VTID", decimal.Parse(_s));
                        _cmd.ExecuteNonQuery();
                    }
                    txn.Commit();
                }
                catch (Exception e)
                {
                    txn.Rollback();
                    string _errmsg = string.Format("执行保存查询模型子表的顺序数据时出错,错误信息为:{0}!",
                             e.Message);
                    LogWriter.WriteSystemLog(_errmsg, "ERROR");
                }
                cn.Close();
            }
            return;
        }

        private const string SQL_GetInputModelOfNamespace = @"select IV_ID,NAMESPACE,IV_NAME,DESCRIPTION,DISPLAYNAME,DISPLAYORDER,IV_CS,TID,DELRULE,DWDM,INTEGRATEDAPP,RESTYPE
                                                                 from MD_INPUTVIEW where NAMESPACE = @NAMESPACE order by DISPLAYORDER";
        public IList<MD_InputModel> GetInputModelOfNamespace(string _namespace)
        {
            return InputModelAccessor.GetInputModelOfNamespace(_namespace);
        }

        private const string SQL_GetInputModel = @"select IV_ID,NAMESPACE,IV_NAME,DESCRIPTION,DISPLAYNAME,DISPLAYORDER,IV_CS,TID,DELRULE,DWDM,INTEGRATEDAPP,RESTYPE
                                                    from MD_INPUTVIEW where NAMESPACE = @NAMESPACE and IV_NAME=@IVNAME order by DISPLAYORDER";
        public MD_InputModel GetInputModel(string _namespace, string ModelName)
        {
            return InputModelAccessor.GetInputModel(_namespace, ModelName);
        }

        public List<MD_InputModel_Child> GetChildInputModel(MD_InputModel _model)
        {
            return InputModelAccessor.GetChildInputModel(_model);
        }

        public bool SaveInputModel(MD_InputModel SaveModel)
        {
            return InputModelAccessor.SaveInputModel(SaveModel);
        }

        public bool SaveNewInputModel(string _namespace, MD_InputModel SaveModel)
        {
            return InputModelAccessor.SaveNewInputModel(_namespace, SaveModel);
        }

        public bool DelInputModel(string InputModelID)
        {
            return InputModelAccessor.DelInputModel(InputModelID);
        }

        private const string SQL_InputModel_MoveColumnToGroup = @"update MD_INPUTVIEWCOLUMN set IVG_ID=@IVGID where IVC_ID=@IVCID ";
        public bool InputModel_MoveColumnToGroup(MD_InputModel_Column _col, MD_InputModel_ColumnGroup InputModelColumnGroup)
        {
            return InputModelAccessor.InputModel_MoveColumnToGroup(_col, InputModelColumnGroup);
        }

        public bool DelInputModelColumnGroup(string InputModelID, string GroupID)
        {
            return InputModelAccessor.DelInputModelColumnGroup(InputModelID, GroupID);
        }

        private const string SQL_AddNewInputModelGroup = @"INSERT INTO MD_INPUTGROUP
                                                            (IVG_ID,IV_ID,DISPLAYTITLE,DISPLAYORDER,GROUPTYPE,APPREGURL,GROUPCS) values
                                                            (@IVG_ID,@IV_ID,@DISPLAYTITLE,@DISPLAYORDER,@GROUPTYPE,@APPREGURL,@GROUPCS)";
        public bool AddNewInputModelGroup(MD_InputModel_ColumnGroup Group)
        {
            return InputModelAccessor.AddNewInputModelGroup(Group);
        }

        public bool SaveInputModelColumnGroup(MD_InputModel_ColumnGroup Group)
        {
            return InputModelAccessor.SaveInputModelColumnGroup(Group);
        }

        public bool FindInputModelColumnByName(string InputModelID, string ColumnName)
        {
            return InputModelAccessor.FindInputModelColumnByName(InputModelID, ColumnName);
        }

        public bool AddNewInputModelColumn(string InputModelID, string GroupID, string ColumnName)
        {
            return InputModelAccessor.AddNewInputModelColumn(InputModelID, GroupID, ColumnName);
        }

        public bool OracleTableExist(string TableName)
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool DelInputModelColumn(string ColumnID)
        {
            return InputModelAccessor.DelInputModelColumn(ColumnID);
        }

        public bool AddNewInputModelSavedTable(string InputModelID, string TableName)
        {
            return InputModelAccessor.AddNewInputModelSavedTable(InputModelID, TableName);
        }

        public bool DelInputModelSavedTable(string TableID)
        {
            return InputModelAccessor.DelInputModelSavedTable(TableID);
        }

        public bool SaveInputModelSaveTable(MD_InputModel_SaveTable _newTable)
        {
            return InputModelAccessor.SaveInputModelSaveTable(_newTable);
        }

        public bool AddInputModelTableColumn(string TableName, string AddFieldName, string DataType)
        {
            return InputModelAccessor.AddInputModelTableColumn(TableName, AddFieldName, DataType);
        }

        public bool DelInputModelTableColumn(string TableName, string DelFieldName)
        {
            return InputModelAccessor.DelInputModelTableColumn(TableName, DelFieldName);
        }

        public List<string> GetDBPrimayKeyList(string TableName)
        {
            return InputModelAccessor.GetDBPrimayKeyList(TableName);
        }

        public bool AddChildInputModel(string MainModelID, string ChildModelID)
        {
            return InputModelAccessor.AddChildInputModel(MainModelID, ChildModelID);
        }

        public bool SaveInputModelChildDefine(MD_InputModel_Child InputModelChild)
        {
            return InputModelAccessor.SaveInputModelChildDefine(InputModelChild);
        }

        private const string SQL_DelRefTable = @"delete from md_reftablelist  where RTID=@RTID";
        public bool DelRefTable(string RefTableID)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_DelRefTable, cn);
                    _cmd.Parameters.Add("@RTID", decimal.Parse(RefTableID));
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        #endregion



        /// <summary>
        /// 取录入模型定义数据
        /// </summary>
        /// <param name="InputModelID"></param>
        /// <returns></returns>
        public DataSet GetInputModelDefineData(string InputModelID)
        {
            return InputModelAccessor.GetInputModelDefineData(InputModelID);
        }

        public bool DelInputModelChild(string ChildModelID)
        {
            return InputModelAccessor.DelInputModelChild(ChildModelID);
        }

        public bool IsExistID(string _oldid, string _tname, string _colname)
        {
            return InputModelAccessor.IsExistID(_oldid, _tname, _colname);
        }

        public List<MD_View2ViewGroup> GetView2ViewGroupOfQueryModel(string ViewID)
        {
            return QueryModelAccessor.GetView2ViewGroupOfQueryModel(ViewID);
        }

        public string AddView2ViewGroup(string ViewID)
        {
            return QueryModelAccessor.AddView2ViewGroup(ViewID);
        }

        public bool SaveView2ViewGroup(MD_View2ViewGroup View2ViewGroup)
        {
            return QueryModelAccessor.SaveView2ViewGroup(View2ViewGroup);
        }

        public List<MD_View2View> GetView2ViewList(string GroupID, string ViewID)
        {
            return QueryModelAccessor.GetView2ViewList(GroupID, ViewID);
        }

        public string DelView2ViewGroup(string GroupID)
        {
            return QueryModelAccessor.DelView2ViewGroup(GroupID);
        }

        public string AddView2View(string ViewID, string GroupID)
        {
            return QueryModelAccessor.AddView2View(ViewID, GroupID);
        }

        public bool SaveView2View(MD_View2View View2View)
        {
            return QueryModelAccessor.SaveView2View(View2View);
        }

        public string CMD_DelView2View(string v2vid)
        {
            return QueryModelAccessor.CMD_DelView2View(v2vid);
        }

        public List<MD_QueryModel_ExRight> GetQueryModelExRights(string QueryModelID, string FatherID)
        {
            return QueryModelAccessor.GetQueryModelExRights(QueryModelID, FatherID);
        }

        public bool AddNewViewExRight(string RightValue, string RightTitle, string ViewID, MD_QueryModel_ExRight FatherRight)
        {
            return QueryModelAccessor.AddNewViewExRight(RightValue, RightValue, ViewID, FatherRight);
        }

        public bool SaveQueryModelExRight(MD_QueryModel_ExRight ExRight)
        {
            return QueryModelAccessor.SaveQueryModelExRight(ExRight);
        }

        public string CMD_DelViewExRight(MD_QueryModel_ExRight ExRight)
        {
            return QueryModelAccessor.CMD_DelViewExRight(ExRight);
        }

        public bool SaveView2GL(string V2GID, string VIEWID, string GuideLineID, string Params, int DisplayOrder, string DisplayTitle)
        {
            return QueryModelAccessor.SaveView2GL(V2GID, VIEWID, GuideLineID, Params, DisplayOrder, DisplayTitle);
        }

        public string CMD_DelView2GL(MD_View_GuideLine View2GL)
        {
            return QueryModelAccessor.CMD_DelView2GL(View2GL);
        }

        public List<MD_View2App> GetView2ApplicationList(string QueryModelID)
        {
            return QueryModelAccessor.GetView2ApplicationList(QueryModelID);
        }

        public bool SaveView2App(string V2AID, MD_View2App View2AppData)
        {
            return QueryModelAccessor.SaveView2App(V2AID, View2AppData);
        }

        public string CMD_DelView2App(string V2AID)
        {
            return QueryModelAccessor.CMD_DelView2App(V2AID);
        }

        public string CMD_ClearView2App(string QueryModelID)
        {
            return QueryModelAccessor.CMD_ClearView2App(QueryModelID);
        }
    }
}
