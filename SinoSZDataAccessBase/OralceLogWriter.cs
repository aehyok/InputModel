using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SinoSZDataAccessBase
{
        /// <summary>
        /// 系统日志记录器
        /// </summary>
        public class OralceLogWriter
        {
                /// <summary>
                /// 写系统日志
                /// </summary>
                /// <param name="_msg">系统日志信息</param>
                /// <param name="_type">类型　　INFO:信息　ERROR:错误</param>
                /// <returns></returns>
                static public bool WriteSystemLog(string _msg, string _type)
                {
                        string _ins = "insert into XT_SYSTEMLOG ";
                        _ins += " (ID,CZSJ,LOGTYPE,LOGTEXT) values ";
                        _ins += " (:ID,sysdate,:LOGTYPE,:LOGTEXT) ";
                        if (_msg.Length > 2000) _msg = _msg.Substring(0, 2000);
                        using (OracleConnection cn = new OracleConnection(OracleHelper.ConnectionStringProfile))
                        {
                                cn.Open();
                                OracleCommand comm = new OracleCommand(_ins, cn);
                                comm.Parameters.Add(":ID", Guid.NewGuid().ToString());
                                comm.Parameters.Add(":LOGTYPE", _type);
                                comm.Parameters.Add(":LOGTEXT", _msg);
                                comm.ExecuteScalar();
                                cn.Close();
                        }
                        return true;
                }

                /// <summary>
                /// 写用户操作日志
                /// </summary>
                /// <param name="_yhid">用户ID</param>
                /// <param name="_czlx">操作类型</param>
                /// <param name="_cxnr">日志内容</param>
                /// <param name="_resulttype">操作结果类型　0.未知　1.成功　　2.失败　</param>
                /// <param name="_ipaddr">客户端IP地址</param>
                /// <param name="_hostName">客户端主机名称</param>
                /// <param name="_systemID">记录日志的系统ID</param>
                /// <returns></returns>
                static public bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
                {
                        string _sqlStr = "insert into XT_USERLOG (ID,YHID,CZSJ,CZLX,CZXXNR,FROMIP,SYSTEMID,RESULTTYPE,FROMHOST) values ";
                        _sqlStr += " (:ID,:YHID,sysdate,:CZLX,:CZXXNR,:FROMIP,:SYSTEMID,:RESULTTYPE,:FROMHOST)";
                        if (_cxnr.Length > 3700) _cxnr = _cxnr.Substring(0, 3700);
                        using (OracleConnection cn = new OracleConnection(OracleHelper.ConnectionStringProfile))
                        {
                                cn.Open();
                                OracleCommand comm = new OracleCommand(_sqlStr, cn);
                                comm.Parameters.Add(":ID", Guid.NewGuid().ToString());
                                comm.Parameters.Add(":YHID", _yhid);
                                comm.Parameters.Add(":CZLX", _czlx);
                                comm.Parameters.Add(":CZXXNR", _cxnr);
                                comm.Parameters.Add(":FROMIP", _ipaddr);
                                comm.Parameters.Add(":SYSTEMID", _systemID);
                                comm.Parameters.Add(":RESULTTYPE", _resulttype);
                                comm.Parameters.Add(":FROMHOST", _hostName);
                                comm.ExecuteScalar();
                                cn.Close();
                        }
                        return true;
                }
        }


}
