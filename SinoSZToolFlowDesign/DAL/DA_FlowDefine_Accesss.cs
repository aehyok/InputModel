using System;
using System.Collections.Generic;
using System.Text;
using SinoSZToolFlowDesign.Interface;
using System.Configuration;
using System.Data.OleDb;
using SinoSZToolFlowDesign.DOL;

namespace SinoSZToolFlowDesign.DAL
{
    public class DA_FlowDefine_Accesss : ICS_Flow
    {
        private string connectString = "";
        public DA_FlowDefine_Accesss()
        {
            connectString = ConfigurationManager.ConnectionStrings["MDBProfileConnString"].ConnectionString;
        }

        public DA_FlowDefine_Accesss(string _connectString)
        {
            connectString = _connectString;
        }


        #region ICS_Flow Members

        public bool SaveFlowProperties(SinoSZToolFlowDesign.DOL.Flow_BaseDefine flow_BaseDefine)
        {
            string _updateStr = "update  [FLOW_ENTITYTYPE]";
            _updateStr += " set [DESCRIPTION]=@DESCRIPTION,[FLOWNAME]=@FLOWNAME,[ROOTDWID]=@ROOTDWID ";
            _updateStr += " where [ID]=@ID";


            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_updateStr, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@DESCRIPTION", flow_BaseDefine.Description));
                    _cmd.Parameters.Add(new OleDbParameter("@FLOWNAME", flow_BaseDefine.FlowName));
                    _cmd.Parameters.Add(new OleDbParameter("@ROOTDWID", Double.Parse(flow_BaseDefine.RootDWID)));
                    _cmd.Parameters.Add(new OleDbParameter("@ID", flow_BaseDefine.ID));
                    _cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;

                }
                catch (Exception e)
                {
                    //写系统错误日志
                    throw e;
                    return false;
                }
            }
        }

        public bool SaveNewFlowProperties(SinoSZToolFlowDesign.DOL.Flow_BaseDefine flow_BaseDefine)
        {
            string _insertStr = "insert into [FLOW_ENTITYTYPE]";
            _insertStr += " ([ID],[FLOWNAME],[DESCRIPTION],[ROOTDWID]) values (@ID,@FLOWNAME,@DESCRIPTION,@ROOTDWID) ";
            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_insertStr, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@ID", flow_BaseDefine.ID));
                    _cmd.Parameters.Add(new OleDbParameter("@FLOWNAME", flow_BaseDefine.FlowName));
                    _cmd.Parameters.Add(new OleDbParameter("@DESCRIPTION", flow_BaseDefine.Description));
                    _cmd.Parameters.Add(new OleDbParameter("@ROOTDWID", Double.Parse(flow_BaseDefine.RootDWID)));
                    _cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    //写系统错误日志
                    throw e;
                    return false;
                }
            }
        }

        public SinoSZToolFlowDesign.DOL.Flow_BaseDefine GetFlowProperties(string _id)
        {
            Flow_BaseDefine _ret = null;
            string _sql = "select [ID],[FLOWNAME],[DESCRIPTION],[ROOTDWID] FROM [FLOW_ENTITYTYPE]  ";
            _sql += " where [ID] = @ID ";

            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_sql, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@ID", _id));

                    OleDbDataReader dr = _cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _ret = new Flow_BaseDefine(dr.IsDBNull(0) ? "" : dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "0" : dr.GetDecimal(3).ToString()
                        );
                    }
                    dr.Close();
                    cn.Close();
                    return _ret;
                }
                catch (Exception e)
                {
                    //写系统错误日志
                    throw e;
                    return null;
                }
            }
        }

        public SinoSZToolFlowDesign.DOL.Flow_BaseDefine GetFlowPropertiesByName(string _flowName)
        {
            Flow_BaseDefine _ret = null;
            string _sql = "select [ID],[FLOWNAME],[DESCRIPTION],[ROOTDWID] FROM [FLOW_ENTITYTYPE]  ";
            _sql += " where [FLOWNAME] = @FLOWNAME ";

            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_sql, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@FLOWNAME", _flowName));

                    OleDbDataReader dr = _cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        _ret = new Flow_BaseDefine(dr.IsDBNull(0) ? "" : dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "0" : dr.GetDecimal(3).ToString()
                        );
                    }
                    dr.Close();
                    cn.Close();
                    return _ret;
                }
                catch (Exception e)
                {
                    throw e;
                    //写系统错误日志
                    return null;
                }
            }
        }

        public List<SinoSZToolFlowDesign.DOL.Flow_BaseDefine> GetFlows()
        {
            List<Flow_BaseDefine> _ret = new List<Flow_BaseDefine>();

            string _sql = "select [ID],[FLOWNAME],[DESCRIPTION],[ROOTDWID] FROM [FLOW_ENTITYTYPE]";
            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_sql, cn);

                    OleDbDataReader dr = _cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Flow_BaseDefine _fd = new Flow_BaseDefine(dr.IsDBNull(0) ? "" : dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "0" : dr.GetDecimal(3).ToString()
                        );
                        _ret.Add(_fd);
                    }
                    dr.Close();
                    cn.Close();
                    return _ret;
                }
                catch (Exception e)
                {
                    //写系统错误日志
                    throw e;
                    return null;
                }
            }
        }



        public bool DeleteFlow(string _flowID)
        {
            string _sql = "Delete FROM [FLOW_ENTITYTYPE] where [ID]=@ID";


            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_sql, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@ID", _flowID));
                    _cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                    //写系统错误日志
                    return false;
                }
            }
        }

        public bool SaveFlowState(SinoSZToolFlowDesign.DOL.Flow_StateDefine flow_StateDefine)
        {
            string _updateStr = "update  [FLOW_ENTITYSTATUS]";
            _updateStr += " set [STATENAME]=@STATENAME,[STATEDISPLAYNAME]=@STATEDISPLAYNAME,[STATEDESCRIPT]=@STATEDESCRIPT,[STATETYPE]=@STATETYPE, ";
            _updateStr += " [DISPLAYORDER]=@DISPLAYORDER where [ID]=@ID";


            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {

                    OleDbCommand _cmd = new OleDbCommand(_updateStr, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@STATENAME", flow_StateDefine.Name));
                    _cmd.Parameters.Add(new OleDbParameter("@STATEDISPLAYNAME", flow_StateDefine.DisplayName));
                    _cmd.Parameters.Add(new OleDbParameter("@STATEDESCRIPT", flow_StateDefine.Description));
                    _cmd.Parameters.Add(new OleDbParameter("@STATETYPE", flow_StateDefine.Type));
                    _cmd.Parameters.Add(new OleDbParameter("@DISPLAYORDER", Convert.ToDouble(flow_StateDefine.Order)));
                    _cmd.Parameters.Add(new OleDbParameter("@ID", flow_StateDefine.ID));

                    _cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                    //写系统错误日志
                    return false;
                }
            }
        }

        public List<SinoSZToolFlowDesign.DOL.Flow_StateDefine> GetFlowStatusByFlow(SinoSZToolFlowDesign.DOL.Flow_BaseDefine flow_BaseDefine)
        {
            List<Flow_StateDefine> _ret = new List<Flow_StateDefine>();

            string _sql = "select [ID],[STATENAME],[STATEDISPLAYNAME],[STATEDESCRIPT],[STATETYPE],[DISPLAYORDER] ";
            _sql += " FROM [FLOW_ENTITYSTATUS] where [FLOWID] = @FLOWID";

            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_sql, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@FLOWID", flow_BaseDefine.ID));
                    OleDbDataReader dr = _cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Flow_StateDefine _fd = new Flow_StateDefine(dr.IsDBNull(0) ? "" : dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDecimal(5))
                        );
                        _ret.Add(_fd);
                    }
                    dr.Close();
                    cn.Close();
                    return _ret;
                }
                catch (Exception e)
                {
                    throw e;
                    //写系统错误日志
                    return null;
                }
            }
        }

        public bool SaveNewFlowState(SinoSZToolFlowDesign.DOL.Flow_BaseDefine flow_BaseDefine, SinoSZToolFlowDesign.DOL.Flow_StateDefine flow_StateDefine)
        {
            string _insertStr = "insert into [FLOW_ENTITYSTATUS]";
            _insertStr += " ([ID],[FLOWID],[STATENAME],[STATEDISPLAYNAME],[STATEDESCRIPT],[STATETYPE],[DISPLAYORDER]) ";
            _insertStr += " values (@ID,@FLOWID,@STATENAME,@STATEDISPLAYNAME,@STATEDESCRIPT,@STATETYPE,@DISPLAYORDER) ";



            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_insertStr, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@ID", flow_StateDefine.ID));
                    _cmd.Parameters.Add(new OleDbParameter("@FLOWID", flow_BaseDefine.ID));
                    _cmd.Parameters.Add(new OleDbParameter("@STATENAME", flow_StateDefine.Name));
                    _cmd.Parameters.Add(new OleDbParameter("@STATEDISPLAYNAME", flow_StateDefine.DisplayName));
                    _cmd.Parameters.Add(new OleDbParameter("@STATEDESCRIPT", flow_StateDefine.Description));
                    _cmd.Parameters.Add(new OleDbParameter("@STATETYPE", flow_StateDefine.Type));
                    _cmd.Parameters.Add(new OleDbParameter("@DISPLAYORDER", Convert.ToDouble(flow_StateDefine.Order)));
                    _cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                    //写系统错误日志
                    return false;
                }
            }
        }

        public bool DeleteFlowState(string flow_StateID)
        {
            string _sql = "Delete FROM [FLOW_ENTITYSTATUS] where [ID]=@ID";


            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_sql, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@ID", flow_StateID));
                    _cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                    //写系统错误日志
                    return false;
                }
            }
        }

        public List<SinoSZToolFlowDesign.DOL.Flow_StateActionDefine> GetFlowStatusAction(SinoSZToolFlowDesign.DOL.Flow_StateDefine flow_StateDefine)
        {
            List<Flow_StateActionDefine> _ret = new List<Flow_StateActionDefine>();

            string _sql = "select A.[ID],A.[ACTIONNAME],A.[ACTIONTITLE], ";
            _sql += "B.[ID],B.[STATENAME],B.[STATEDISPLAYNAME],B.[STATEDESCRIPT],B.[STATETYPE],B.[DISPLAYORDER], ";
            _sql += "A.[ACTIONTYPE],A.[USERTYPE],A.[DISPLAYORDER],A.[ACTIONPARAM] ";
            _sql += " FROM [FLOW_STATETRANSITION] A,[FLOW_ENTITYSTATUS] B where A.[STATEID] = @STATEID ";
            _sql += " and B.[ID] = A.[TARGETSTATEID] ";

            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_sql, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@STATEID", flow_StateDefine.ID));
                    OleDbDataReader dr = _cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Flow_StateDefine _endStateDefine = new Flow_StateDefine(dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? "" : dr.GetString(7),
                                dr.IsDBNull(8) ? 0 : Convert.ToInt32(dr.GetDecimal(8))
                        );

                        Flow_StateActionDefine _sa = new Flow_StateActionDefine(dr.IsDBNull(0) ? "" : dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                flow_StateDefine,
                                _endStateDefine,
                                dr.IsDBNull(9) ? "" : dr.GetString(9),
                                dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetDecimal(10)),
                                dr.IsDBNull(11) ? 0 : Convert.ToInt32(dr.GetDecimal(11)),
                                dr.IsDBNull(12) ? "" : dr.GetString(12)
                        );

                        _ret.Add(_sa);
                    }
                    dr.Close();
                    cn.Close();
                    return _ret;
                }
                catch (Exception e)
                {
                    throw e;
                    //写系统错误日志
                    return null;
                }
            }
        }

        public bool SaveStateAction(SinoSZToolFlowDesign.DOL.Flow_StateActionDefine flow_StateActionDefine)
        {
            string _updateStr = "update  [FLOW_STATETRANSITION]";
            _updateStr += " set [STATEID]=@STATEID,[ACTIONNAME]=@ACTIONNAME,[ACTIONTITLE]=@ACTIONTITLE,[TARGETSTATEID]=@TARGETSTATEID, ";
            _updateStr += " [ACTIONTYPE]=@ACTIONTYPE,[USERTYPE]=@USERTYPE,[DISPLAYORDER]=@DISPLAYORDER,[ACTIONPARAM]=@ACTIONPARAM ";
            _updateStr += "  where [ID]=@ID";

            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_updateStr, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@STATEID", flow_StateActionDefine.BeginState.ID));
                    _cmd.Parameters.Add(new OleDbParameter("@ACTIONNAME", flow_StateActionDefine.ActionName));
                    _cmd.Parameters.Add(new OleDbParameter("@ACTIONTITLE", flow_StateActionDefine.ActionTitle));
                    _cmd.Parameters.Add(new OleDbParameter("@TARGETSTATEID", flow_StateActionDefine.EndState.ID));
                    _cmd.Parameters.Add(new OleDbParameter("@ACTIONTYPE", flow_StateActionDefine.ActionType));
                    _cmd.Parameters.Add(new OleDbParameter("@USERTYPE", Convert.ToDouble(flow_StateActionDefine.UserType)));
                    _cmd.Parameters.Add(new OleDbParameter("@DISPLAYORDER", Convert.ToDouble(flow_StateActionDefine.DisplayOrder)));
                    _cmd.Parameters.Add(new OleDbParameter("@ACTIONPARAM", flow_StateActionDefine.ParamDefine));
                    _cmd.Parameters.Add(new OleDbParameter("@ID", flow_StateActionDefine.ActionID));
                    _cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                    //写系统错误日志
                    return false;
                }
            }
        }

        public bool SaveNewStateAction(SinoSZToolFlowDesign.DOL.Flow_StateActionDefine flow_StateActionDefine)
        {
            string _insertStr = "insert into [FLOW_STATETRANSITION]";
            _insertStr += " ([ID],[STATEID],[ACTIONNAME],[ACTIONTITLE],[TARGETSTATEID],[ACTIONTYPE],[USERTYPE],[DISPLAYORDER],[ACTIONPARAM]) ";
            _insertStr += " values (@ID,@STATEID,@ACTIONNAME,@ACTIONTITLE,@TARGETSTATEID,@ACTIONTYPE,@USERTYPE,@DISPLAYORDER,@ACTIONPARAM) ";



            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_insertStr, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@ID", flow_StateActionDefine.ActionID));
                    _cmd.Parameters.Add(new OleDbParameter("@STATEID", flow_StateActionDefine.BeginState.ID));
                    _cmd.Parameters.Add(new OleDbParameter("@ACTIONNAME", flow_StateActionDefine.ActionName));
                    _cmd.Parameters.Add(new OleDbParameter("@ACTIONTITLE", flow_StateActionDefine.ActionTitle));
                    _cmd.Parameters.Add(new OleDbParameter("@TARGETSTATEID", flow_StateActionDefine.EndState.ID));
                    _cmd.Parameters.Add(new OleDbParameter("@ACTIONTYPE", flow_StateActionDefine.ActionType));
                    _cmd.Parameters.Add(new OleDbParameter("@USERTYPE", Convert.ToDouble(flow_StateActionDefine.UserType)));
                    _cmd.Parameters.Add(new OleDbParameter("@DISPLAYORDER", Convert.ToDouble(flow_StateActionDefine.DisplayOrder)));
                    _cmd.Parameters.Add(new OleDbParameter("@ACTIONPARAM", flow_StateActionDefine.ParamDefine));
                    _cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                    //写系统错误日志
                    return false;
                }
            }
        }

        public bool DeleteStateAction(string _actionID)
        {
            string _sql = "Delete FROM [FLOW_STATETRANSITION] where [ID]=@ID";


            using (OleDbConnection cn = OpenConnection(connectString))
            {
                try
                {
                    OleDbCommand _cmd = new OleDbCommand(_sql, cn);
                    _cmd.Parameters.Add(new OleDbParameter("@ID", _actionID));
                    _cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                    //写系统错误日志
                    return false;
                }
            }
        }

        #endregion

        public static bool IsReady(string _cnString, ref string ErrorMsg)
        {
            ErrorMsg = "";
            using (OleDbConnection cn = new OleDbConnection(_cnString))
            {
                try
                {
                    cn.Open();
                    cn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    ErrorMsg = ex.Message;
                    return false;
                }
            }
        }

        private OleDbConnection OpenConnection(string connectString)
        {
            OleDbConnection _cn = new OleDbConnection(connectString);
            _cn.Open();
            return _cn;
        }
    }
}
