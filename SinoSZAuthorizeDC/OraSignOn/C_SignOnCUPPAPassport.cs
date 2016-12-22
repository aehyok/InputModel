using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBizAuthorize;
using SinoSZDataAccessBase;
using System.Configuration;
using System.IO;
using SinoSZAuthorizeDC.Cuppa;
using Oracle.DataAccess.Client;

namespace SinoSZAuthorizeDC.OraSignOn
{
    public class C_SignOnCUPPAPassport : C_SignOnBase
    {
        private static string CUPPA_Check_Type = "windows";
        public static bool DebugMode = false;
        public static string CUPPA_Check_DebugDataPath = "";
        public static bool CUPPA_Check_WriteLog = false;
        public static Dictionary<string, string> AuthTypeLib = null;
        static C_SignOnCUPPAPassport()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            string _type = ConfigurationManager.AppSettings["CUPPA_Check_Type"];
            if (_type == string.Empty || _type == null)
            {
                CUPPA_Check_Type = "windows";
            }
            else
            {
                CUPPA_Check_Type = _type;
            }

            string _debugMode = ConfigurationManager.AppSettings["CUPPA_Check_Mode"];
            if (_debugMode != null && _debugMode.ToUpper() == "DEBUG")
            {
                DebugMode = true;
            }

            string _debugDataPath = ConfigurationManager.AppSettings["CUPPA_Check_DebugDataPath"];
            if (_debugDataPath == string.Empty || _debugDataPath == null)
            {
                CUPPA_Check_DebugDataPath = @"d:\temp\debugdata\";
            }
            else
            {
                CUPPA_Check_DebugDataPath = _debugDataPath;
            }

            string _writelog = ConfigurationManager.AppSettings["CUPPA_Check_WriteLog"];
            if (_writelog == null || _writelog == string.Empty)
            {
                CUPPA_Check_WriteLog = false;
            }
            else
            {
                _writelog = _writelog.ToUpper();
                CUPPA_Check_WriteLog = ((_writelog == "YES") || (_writelog == "Y"));
            }
            if (CUPPA_Check_WriteLog) WriteCUPPALog(string.Format("使用日志状态：{0}    CUPPA_Check_WriteLog={1}", CUPPA_Check_WriteLog, _writelog));
        }

        /// <summary>
        /// 验证口令
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_pass"></param>
        /// <returns></returns>
        override public bool Check(string _name, string _pass, string _type)
        {
            //1.通过三统一接口验证密码
            try
            {
                if (DebugMode)
                {
                    return (_name == _pass);
                }
                else
                {
                    string _authType = GetAuthType(_type);
                    OguReaderClient _orc = new OguReaderClient();
                    bool _ret = _orc.CheckPwd(_name, _authType, _pass);
                    if (CUPPA_Check_WriteLog) WriteCUPPALog(string.Format("采用三统一平台验证口令返回{0},! name={1}, CUPPA_Check_Type={2}, pass={3}",
  _ret, _name, _authType, _pass));
                    return _ret;
                }
            }
            catch (Exception e1)
            {
                string _error = string.Format("采用三统一平台验证口令出错:{0}\n Name={1} Pass={2}", e1.Message, _name, _pass);
                OralceLogWriter.WriteSystemLog(_error, "ERROR");
                if (CUPPA_Check_WriteLog) WriteCUPPALog(_error);
                return false;
            }
        }

        public static string GetAuthType(string _type)
        {
            if (AuthTypeLib == null) GetAuthTypeLib();
            if (AuthTypeLib.ContainsKey(_type))
            {
                return AuthTypeLib[_type];
            }
            else
            {
                return "hrcode";
            }          

        }

        private static string SQL_GetCSB = @"select CSDATA from zhtj_csb where CSNAME=:CSNAME";
        private static string GetCSB(string _csname)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetCSB, cn);
                _cmd.Parameters.Add(":CSNAME", _csname);
                object _ret = _cmd.ExecuteScalar();
                if (_ret == null) return "";
                return _ret.ToString();
            }
        }

        private static void GetAuthTypeLib()
        {
            AuthTypeLib = new Dictionary<string, string>();
            AuthTypeLib.Add("海关员工号", GetCSB("CUPAA_TYPE_海关员工号"));
            AuthTypeLib.Add("普通表单", GetCSB("CUPAA_TYPE_普通表单"));
            AuthTypeLib.Add("域认证", GetCSB("CUPAA_TYPE_域认证"));
            AuthTypeLib.Add("运行网域认证", GetCSB("CUPAA_TYPE_运行网域认证"));
            AuthTypeLib.Add("域和表单组合认证", GetCSB("CUPAA_TYPE_域和表单组合认证"));

        }

        public static void WriteCUPPALog(string _logstring)
        {
            StreamWriter _fs;
            string logFileName = CUPPA_Check_DebugDataPath + "CUPPA_LOG.txt";

            if (File.Exists(logFileName))
            {
                _fs = File.AppendText(logFileName);
            }
            else
            {
                _fs = File.CreateText(logFileName);
            }
            _fs.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _logstring));
            _fs.Close();
        }

        /// <summary>
        /// 修改口令
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_oldpass"></param>
        /// <param name="_newpass"></param>
        /// <returns></returns>
        override public int ChangePassword(string _name, string _oldpass, string _newpass,string _type)
        {
            return -1;
        }

        /// <summary>
        /// 重置口令
        /// </summary>
        /// <param name="_uname"></param>
        /// <param name="_pass"></param>
        /// <returns></returns>
        override public int ResetPass(string _uname, string _pass)
        {
            return -1;
        }
    }
}
