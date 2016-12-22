using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBaseClass.Authorize;
using SinoSZBaseClass.Misc;
using SinoSZPluginFramework.ServerPlugin;
using System.Configuration;
using System.Reflection;

namespace SinoSZClientBase
{
        public class LoginConfig
        {
                public static IAuthorize GetAuthorizeInterface()
                {
                        string className, profilePath;

                        string dataBaseType = ConfigurationManager.AppSettings["DataBaseType"] as string;
                        switch (dataBaseType)
                        {
                                case "ORACLE":
                                        className = "SinoSZAuthorizeDC.OraAuthorizeFactroy";
                                        profilePath = "SinoSZAuthorizeDC";
                                        return (IAuthorize)Assembly.Load(profilePath).CreateInstance(className);
                                        

                                case "SQLSERVER":
                                        return null;

                                case "REMOTING":
                                        IServiceFactory _serviceFactory = (IServiceFactory)RemotingClientSvc.GetAppSvrObj(typeof(IServiceFactory));
                                        RemotingClientSvc.BindTicketToCallContext(SessionClass.CurrentTicket);
                                        IAuthorize _ret = _serviceFactory.GetInterFace("AuthorizeServerPlugin") as IAuthorize;
                                        return _ret;

                        }

                        return null;
                }
        }
}
