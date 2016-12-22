using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBizAuthorize;
using SinoSZBaseClass.Misc;
using System.Configuration;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZAuthorizeDC.OraSignOn
{
    public class C_SignOnQDHBService : C_SignOnBase
    {
        #region 服务地址
        public static string serviceUrl = "";
        public static string ServiceURL
        {
            get
            {
                if (serviceUrl == "")
                {
                    try
                    {
                        serviceUrl = ConfigurationSettings.AppSettings["SecurityCheckURL"];
                    }
                    catch
                    {
                        serviceUrl = "http://10.77.8.205/hbopenservice/HBUserService.asmx";
                    }
                }

                return serviceUrl;
            }
        }
        #endregion

        override public bool Check(string _name, string _pass, string _type)
        {
            //1.读取数据库中的用户信息，验证密码
            QDHBUserService.HBUserService _wsobj = new QDHBUserService.HBUserService();
            _wsobj.Url = ServiceURL;
            _wsobj.Timeout = 60000;
            bool _ret = false;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    return _wsobj.authentication(_name, _pass);
                }
                catch (Exception ex)
                {
                    LogWriter.WriteSystemLog(string.Format("使用QDHBSerivce验证时出错，{0}", ex.Message), "ERROR");
                }

            }
            return _ret;
        }
    }
}
