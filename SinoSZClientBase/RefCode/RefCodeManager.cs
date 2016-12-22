using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework.ServerPlugin;
using SinoSZBaseClass.Misc;
using SinoSZBaseClass.Authorize;
using System.Configuration;
using System.Reflection;

namespace SinoSZBaseClass.RefCode
{
        public static class RefCodeManager
        {
                private static ICS_RefCode _iRefCode = null;
                public static ICS_RefCode IRefCode
                {
                        get
                        {
                                _iRefCode = GetDataConfig();
                                return _iRefCode;
                        }

                        set
                        {
                                _iRefCode = value;
                        }
                }

                private static ICS_RefCode GetDataConfig()
                {
                        string className, profilePath;

                        string dataBaseType = ConfigurationManager.AppSettings["DataBaseType"] as string;
                        switch (dataBaseType)
                        {
                                case "ORACLE":
                                        className = "SinoSZRefTableDC.OraRefTableFactory";
                                        profilePath = "SinoSZRefTableDC";
                                        return (ICS_RefCode)Assembly.Load(profilePath).CreateInstance(className);

                                case "SQLSERVER":
                                        className = "SinoSZRefTableDC.SqlRefTableFactory";
                                        profilePath = "SinoSZRefTableDC";
                                        return (ICS_RefCode)Assembly.Load(profilePath).CreateInstance(className);

                                case "REMOTING":
                                        IServiceFactory _serviceFactory = (IServiceFactory)RemotingClientSvc.GetAppSvrObj(typeof(IServiceFactory));
                                        RemotingClientSvc.BindTicketToCallContext(SessionClass.CurrentTicket);
                                        ICS_RefCode _ret = _serviceFactory.GetInterFace("RefTableServerPlugin") as ICS_RefCode;
                                        return _ret;
                        }

                        return null;
                }

                private static RefCodeTableSet _refTableCache = new RefCodeTableSet();

                public static RefCodeTable GetRefTable(string _tanme)
                {
                        if (_tanme == "") return null;
                        if (!_refTableCache.RefTables.ContainsKey(_tanme))
                        {
                                //加载代码表
                                RefCodeTable _rtable = new RefCodeTable();
                                _rtable.Properties = IRefCode.GetRefCodePropertie(_tanme);

                                _refTableCache.RefTables.Add(_tanme, _rtable);
                        }
                        return _refTableCache.RefTables[_tanme];

                }

                private static void LoadCode(ref RefCodeTable _rtable)
                {
                        if (_rtable.Properties.LevelDownloadMode == 1)
                        {
                                //一次性下载全部代码
                                _rtable.CodeData = IRefCode.GetFullRefCodeData(_rtable.Name);
                        }
                        else
                        {
                                //分级下载代码
                        }
                }



                public static List<RefCodeData> GetChildLevelRecords(RefCodeTable _rct, string _fatherCode)
                {
                        List<RefCodeData> _ret = new List<RefCodeData>();
                        foreach (RefCodeData _data in _rct.CodeData)
                        {
                                if (_data.FatherCode == _fatherCode)
                                {
                                        _ret.Add(_data);
                                }
                        }

                        return _ret;
                }

                public static bool GetAllRecords(RefCodeTable _rct)
                {
                        LoadCode(ref _rct);
                        return true;
                }

                public static List<RefCodeData> GetLevelDownChildRecords(RefCodeTable _rct, string _fatherCode)
                {
                        if (_rct.LevelCodeData.ContainsKey(_fatherCode))
                        {
                                return _rct.LevelCodeData[_fatherCode];
                        }
                        else
                        {
                                List<RefCodeData> _getChildData = IRefCode.GetChildRefCodeData(_rct.Name, _fatherCode);
                                _rct.LevelCodeData.Add(_fatherCode, _getChildData);
                                return _getChildData;
                        }
                }

                public static object GetFullDisplay(RefCodeData _codeItem)
                {
                        return string.Format("[{0}] {1}", _codeItem.Code, _codeItem.DisplayTitle);
                }
        }
}
