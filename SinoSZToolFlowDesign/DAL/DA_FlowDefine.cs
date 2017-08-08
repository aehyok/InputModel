using System;
using System.Collections.Generic;
using System.Text;
using SinoSZToolFlowDesign.Interface;
using SinoSZToolFlowDesign.DOL;
using System.Data;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZToolFlowDesign.DAL
{
        public class DA_FlowDefine : ICS_Flow
        {
                private string connectString = "";
                public DA_FlowDefine()
                {
                        connectString = SqlHelper.ConnectionStringProfile;
                }

                public DA_FlowDefine(string _connectString)
                {
                        connectString = _connectString;
                }

                public bool SaveFlowProperties(Flow_BaseDefine flow_BaseDefine)
                {
                        string _updateStr = "update  FLOW_ENTITYTYPE";
                        _updateStr += " set DESCRIPTION=@DESCRIPTION,FLOWNAME=@FLOWNAME,ROOTDWID=@ROOTDWID ";
                        _updateStr += " where ID=@ID";

                        SqlParameter[] _param2 = {                                         
                                        new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 1000),
                                        new SqlParameter("@FLOWNAME", SqlDbType.NVarChar, 100),
                                        new SqlParameter("@ROOTDWID",SqlDbType.Decimal),
                                        new SqlParameter("@ID", SqlDbType.NVarChar, 50)
                                 };
                        _param2[0].Value = flow_BaseDefine.Description;
                        _param2[1].Value = flow_BaseDefine.FlowName;
                        _param2[2].Value = decimal.Parse(flow_BaseDefine.RootDWID);
                        _param2[3].Value = flow_BaseDefine.ID;
                        try
                        {
                                SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, _updateStr, _param2);
                                return true;
                        }
                        catch (Exception e)
                        {
                                //写系统错误日志
                                return false;
                        }

                }

                public bool SaveNewFlowProperties(Flow_BaseDefine flow_BaseDefine)
                {
                        string _insertStr = "insert into FLOW_ENTITYTYPE";
                        _insertStr += " (ID,FLOWNAME,DESCRIPTION,ROOTDWID) values (@ID,@FLOWNAME,@DESCRIPTION,@ROOTDWID) ";


                        SqlParameter[] _param2 = {   
                                new SqlParameter("@ID", SqlDbType.NVarChar, 50),                                              
                                new SqlParameter("@FLOWNAME", SqlDbType.NVarChar, 100),
                                new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 1000),
                                new SqlParameter("@ROOTDWID",SqlDbType.Decimal)        
                                 };
                        _param2[0].Value = flow_BaseDefine.ID;
                        _param2[1].Value = flow_BaseDefine.FlowName;
                        _param2[2].Value = flow_BaseDefine.Description;
                        _param2[3].Value = decimal.Parse(flow_BaseDefine.RootDWID);
                        try
                        {
                                SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, _insertStr, _param2);
                                return true;
                        }
                        catch
                        {
                                //写系统错误日志
                                return false;
                        }
                }

                public Flow_BaseDefine GetFlowProperties(string _id)
                {
                        Flow_BaseDefine _ret = null;
                        string _sql = "select ID,FLOWNAME,DESCRIPTION,ROOTDWID FROM FLOW_ENTITYTYPE";
                        _sql += " where ID = @ID ";

                        SqlParameter[] _param = { new SqlParameter("@ID", SqlDbType.NVarChar, 50) };
                        _param[0].Value = _id;

                        try
                        {
                                SqlDataReader dr = SqlHelper.ExecuteReader(connectString, CommandType.Text, _sql, _param);

                                while (dr.Read())
                                {
                                        _ret = new Flow_BaseDefine(dr.IsDBNull(0) ? "" : dr.GetString(0),
                                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                                dr.IsDBNull(3) ? "0" : dr.GetDecimal(3).ToString()
                                        );
                                }
                                dr.Close();
                                return _ret;
                        }
                        catch (Exception e)
                        {
                                //写系统错误日志
                                return null;
                        }
                }

                public Flow_BaseDefine GetFlowPropertiesByName(string _flowName)
                {
                        Flow_BaseDefine _ret = null;
                        string _sql = "select ID,FLOWNAME,DESCRIPTION,ROOTDWID FROM FLOW_ENTITYTYPE";
                        _sql += " where FLOWNAME = @FLOWNAME ";

                        SqlParameter[] _param = { new SqlParameter("@FLOWNAME", SqlDbType.NVarChar, 100) };
                        _param[0].Value = _flowName;

                        try
                        {
                                SqlDataReader dr = SqlHelper.ExecuteReader(connectString, CommandType.Text, _sql, _param);

                                while (dr.Read())
                                {
                                        _ret = new Flow_BaseDefine(dr.IsDBNull(0) ? "" : dr.GetString(0),
                                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                                dr.IsDBNull(3) ? "0" : dr.GetDecimal(3).ToString()
                                        );
                                }
                                dr.Close();
                                return _ret;
                        }
                        catch (Exception e)
                        {
                                //写系统错误日志
                                return null;
                        }
                }

                /// <summary>
                /// 取所有的流程定义及属性
                /// </summary>
                /// <returns></returns>
                public List<Flow_BaseDefine> GetFlows()
                {
                        List<Flow_BaseDefine> _ret = new List<Flow_BaseDefine>();

                        string _sql = "select ID,FLOWNAME,DESCRIPTION,ROOTDWID FROM FLOW_ENTITYTYPE";

                        try
                        {
                                SqlDataReader dr = SqlHelper.ExecuteReader(connectString, CommandType.Text, _sql);

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
                                return _ret;
                        }
                        catch (Exception e)
                        {
                //写系统错误日志
                                 LogWriter.WriteSystemLog("GetFlows——" + e.Message,"ERROR");
                                return null;
                        }
                }


                /// <summary>
                /// 删除指定的流程
                /// </summary>
                /// <param name="_flowID"></param>
                /// <returns></returns>
                public bool DeleteFlow(string _flowID)
                {
                        string _sql = "Delete FROM FLOW_ENTITYTYPE where ID=@ID";

                        SqlParameter[] _param = { new SqlParameter("@ID", SqlDbType.NVarChar, 50) };
                        _param[0].Value = _flowID;

                        try
                        {
                                SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, _sql, _param);

                                return true;
                        }
                        catch (Exception e)
                        {
                                //写系统错误日志
                                return false;
                        }
                }

                /// <summary>
                /// 保存新状态
                /// </summary>
                /// <param name="flow_BaseDefine"></param>
                /// <param name="flow_StateDefine"></param>
                /// <returns></returns>
                public bool SaveNewFlowState(Flow_BaseDefine flow_BaseDefine, Flow_StateDefine flow_StateDefine)
                {
                        string _insertStr = "insert into FLOW_ENTITYSTATUS";
                        _insertStr += " (ID,FLOWID,STATENAME,STATEDISPLAYNAME,STATEDESCRIPT,STATETYPE,DISPLAYORDER) ";
                        _insertStr += " values (@ID,@FLOWID,@STATENAME,@STATEDISPLAYNAME,@STATEDESCRIPT,@STATETYPE,@DISPLAYORDER) ";


                        SqlParameter[] _param2 = {   
                                new SqlParameter("@ID", SqlDbType.NVarChar, 50),    
                                new SqlParameter("@FLOWID", SqlDbType.NVarChar, 50),                                         
                                new SqlParameter("@STATENAME", SqlDbType.NVarChar, 50),
                                new SqlParameter("@STATEDISPLAYNAME", SqlDbType.NVarChar, 100),
                                new SqlParameter("@STATEDESCRIPT", SqlDbType.NVarChar, 1000),
                                new SqlParameter("@STATETYPE", SqlDbType.NVarChar, 10),    
                                new SqlParameter("@DISPLAYORDER",SqlDbType.Decimal)    
                                 };
                        _param2[0].Value = flow_StateDefine.ID;
                        _param2[1].Value = flow_BaseDefine.ID;
                        _param2[2].Value = flow_StateDefine.Name;
                        _param2[3].Value = flow_StateDefine.DisplayName;
                        _param2[4].Value = flow_StateDefine.Description;
                        _param2[5].Value = flow_StateDefine.Type;
                        _param2[6].Value = Convert.ToDecimal(flow_StateDefine.Order);

                        try
                        {
                                SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, _insertStr, _param2);
                                return true;
                        }
                        catch
                        {
                                //写系统错误日志
                                return false;
                        }
                }

                public bool SaveFlowState(Flow_StateDefine flow_StateDefine)
                {
                        string _updateStr = "update  FLOW_ENTITYSTATUS";
                        _updateStr += " set STATENAME=@STATENAME,STATEDISPLAYNAME=@STATEDISPLAYNAME,STATEDESCRIPT=@STATEDESCRIPT,STATETYPE=@STATETYPE, ";
                        _updateStr += " DISPLAYORDER=@DISPLAYORDER where ID=@ID";

                        SqlParameter[] _param2 = {                                         
                                        new SqlParameter("@STATENAME", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@STATEDISPLAYNAME", SqlDbType.NVarChar, 100),
                                        new SqlParameter("@STATEDESCRIPT", SqlDbType.NVarChar, 1000),
                                        new SqlParameter("@STATETYPE", SqlDbType.NVarChar, 10),
                                        new SqlParameter("@DISPLAYORDER",SqlDbType.Decimal),
                                        new SqlParameter("@ID", SqlDbType.NVarChar, 50)
                                 };
                        _param2[0].Value = flow_StateDefine.Name;
                        _param2[1].Value = flow_StateDefine.DisplayName;
                        _param2[2].Value = flow_StateDefine.Description;
                        _param2[3].Value = flow_StateDefine.Type;
                        _param2[4].Value = Convert.ToDecimal(flow_StateDefine.Order);
                        _param2[5].Value = flow_StateDefine.ID;
                        try
                        {
                                SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, _updateStr, _param2);
                                return true;
                        }
                        catch (Exception e)
                        {
                                //写系统错误日志
                                return false;
                        }
                }


                public List<Flow_StateDefine> GetFlowStatusByFlow(Flow_BaseDefine flow_BaseDefine)
                {
                        List<Flow_StateDefine> _ret = new List<Flow_StateDefine>();

                        string _sql = "select ID,STATENAME,STATEDISPLAYNAME,STATEDESCRIPT,STATETYPE,DISPLAYORDER ";
                        _sql += " FROM FLOW_ENTITYSTATUS where FLOWID = @FLOWID";

                        SqlParameter[] _param = { new SqlParameter("@FLOWID", SqlDbType.NVarChar, 50) };
                        _param[0].Value = flow_BaseDefine.ID;
                        try
                        {
                                SqlDataReader dr = SqlHelper.ExecuteReader(connectString, CommandType.Text, _sql, _param);

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
                                return _ret;
                        }
                        catch (Exception e)
                        {
                                //写系统错误日志
                                return null;
                        }
                }

                /// <summary>
                /// 删除状态
                /// </summary>
                /// <param name="flow_StateID"></param>
                /// <returns></returns>
                public bool DeleteFlowState(string flow_StateID)
                {
                        string _sql = "Delete FROM FLOW_ENTITYSTATUS where ID=@ID";

                        SqlParameter[] _param = { new SqlParameter("@ID", SqlDbType.NVarChar, 50) };
                        _param[0].Value = flow_StateID;

                        try
                        {
                                SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, _sql, _param);

                                return true;
                        }
                        catch (Exception e)
                        {
                                //写系统错误日志
                                return false;
                        }
                }

                public List<Flow_StateActionDefine> GetFlowStatusAction(Flow_StateDefine flow_StateDefine)
                {
                        List<Flow_StateActionDefine> _ret = new List<Flow_StateActionDefine>();

                        string _sql = "select A.ID,A.ACTIONNAME,A.ACTIONTITLE, ";
                        _sql += "B.ID,B.STATENAME,B.STATEDISPLAYNAME,B.STATEDESCRIPT,B.STATETYPE,B.DISPLAYORDER, ";
                        _sql += "A.ACTIONTYPE,A.USERTYPE,A.DISPLAYORDER,A.ACTIONPARAM ";
                        _sql += " FROM FLOW_STATETRANSITION A,FLOW_ENTITYSTATUS B where A.STATEID = @STATEID ";
                        _sql += " and B.ID = A.TARGETSTATEID ";

                        SqlParameter[] _param = { new SqlParameter("@STATEID", SqlDbType.NVarChar, 50) };
                        _param[0].Value = flow_StateDefine.ID;
                        try
                        {
                                SqlDataReader dr = SqlHelper.ExecuteReader(connectString, CommandType.Text, _sql, _param);

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
                                return _ret;
                        }
                        catch (Exception e)
                        {
                                //写系统错误日志
                                return null;
                        }
                }


                /// <summary>
                /// 保存状态动作定义
                /// </summary>
                /// <param name="flow_StateActionDefine"></param>
                /// <returns></returns>
                public bool SaveStateAction(Flow_StateActionDefine flow_StateActionDefine)
                {
                        string _updateStr = "update  FLOW_STATETRANSITION";
                        _updateStr += " set STATEID=@STATEID,ACTIONNAME=@ACTIONNAME,ACTIONTITLE=@ACTIONTITLE,TARGETSTATEID=@TARGETSTATEID, ";
                        _updateStr += " ACTIONTYPE=@ACTIONTYPE,USERTYPE=@USERTYPE,DISPLAYORDER=@DISPLAYORDER,ACTIONPARAM=@ACTIONPARAM ";
                        _updateStr += "  where ID=:ID";

                        SqlParameter[] _param2 = {                                         
                                        new SqlParameter("@STATEID", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@ACTIONNAME", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@ACTIONTITLE", SqlDbType.NVarChar, 100),
                                        new SqlParameter("@TARGETSTATEID", SqlDbType.NVarChar, 50),     
                                        new SqlParameter("@ACTIONTYPE", SqlDbType.NVarChar, 50), 
                                        new SqlParameter("@USERTYPE", SqlDbType.Decimal), 
                                        new SqlParameter("@DISPLAYORDER", SqlDbType.Decimal), 
                                        new SqlParameter("@ACTIONPARAM", SqlDbType.NVarChar, 4000),    
                                        new SqlParameter("@ID", SqlDbType.NVarChar, 50)
                                 };
                        _param2[0].Value = flow_StateActionDefine.BeginState.ID;
                        _param2[1].Value = flow_StateActionDefine.ActionName;
                        _param2[2].Value = flow_StateActionDefine.ActionTitle;
                        _param2[3].Value = flow_StateActionDefine.EndState.ID;
                        _param2[4].Value = flow_StateActionDefine.ActionType;
                        _param2[5].Value = Convert.ToDecimal(flow_StateActionDefine.UserType);
                        _param2[6].Value = Convert.ToDecimal(flow_StateActionDefine.DisplayOrder);
                        _param2[7].Value = flow_StateActionDefine.ParamDefine;
                        _param2[8].Value = flow_StateActionDefine.ActionID;
                        try
                        {
                                SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, _updateStr, _param2);
                                return true;
                        }
                        catch (Exception e)
                        {
                                //写系统错误日志
                                return false;
                        }
                }

                /// <summary>
                /// 新建状态动作
                /// </summary>
                /// <param name="flow_StateActionDefine"></param>
                /// <returns></returns>
                public bool SaveNewStateAction(Flow_StateActionDefine flow_StateActionDefine)
                {
                        string _insertStr = "insert into FLOW_STATETRANSITION";
                        _insertStr += " (ID,STATEID,ACTIONNAME,ACTIONTITLE,TARGETSTATEID,ACTIONTYPE,USERTYPE,DISPLAYORDER,ACTIONPARAM) ";
                        _insertStr += " values (@ID,@STATEID,@ACTIONNAME,@ACTIONTITLE,@TARGETSTATEID,@ACTIONTYPE,@USERTYPE,@DISPLAYORDER,@ACTIONPARAM) ";


                        SqlParameter[] _param2 = {   
                                        new SqlParameter("@ID", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@STATEID", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@ACTIONNAME", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@ACTIONTITLE", SqlDbType.NVarChar, 100),
                                        new SqlParameter("@TARGETSTATEID", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@ACTIONTYPE", SqlDbType.NVarChar, 50) ,  
                                        new SqlParameter("@USERTYPE", SqlDbType.Decimal) ,
                                        new SqlParameter("@DISPLAYORDER", SqlDbType.Decimal),
                                        new SqlParameter("@ACTIONPARAM", SqlDbType.NVarChar,4000)          
                                 };
                        _param2[1].Value = flow_StateActionDefine.BeginState.ID;
                        _param2[2].Value = flow_StateActionDefine.ActionName;
                        _param2[3].Value = flow_StateActionDefine.ActionTitle;
                        _param2[4].Value = (flow_StateActionDefine.EndState == null) ? "" : flow_StateActionDefine.EndState.ID;
                        _param2[5].Value = flow_StateActionDefine.ActionType;
                        _param2[6].Value = Convert.ToDecimal(flow_StateActionDefine.UserType);
                        _param2[7].Value = Convert.ToDecimal(flow_StateActionDefine.DisplayOrder);
                        _param2[8].Value = flow_StateActionDefine.ParamDefine;
                        _param2[0].Value = flow_StateActionDefine.ActionID;

                        try
                        {
                                SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, _insertStr, _param2);
                                return true;
                        }
                        catch
                        {
                                //写系统错误日志
                                return false;
                        }
                }

                #region ICS_Flow Members


                public bool DeleteStateAction(string _actionID)
                {
                        string _sql = "Delete FROM FLOW_STATETRANSITION where ID=@ID";

                        SqlParameter[] _param = { new SqlParameter("@ID", SqlDbType.NVarChar, 50) };
                        _param[0].Value = _actionID;

                        try
                        {
                                SqlHelper.ExecuteNonQuery(connectString, CommandType.Text, _sql, _param);

                                return true;
                        }
                        catch (Exception e)
                        {
                                //写系统错误日志
                                return false;
                        }
                }

                #endregion
        }
}
