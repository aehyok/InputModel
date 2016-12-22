using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBaseClass.MenuType;
using SinoSZPluginFramework.ServerPlugin;
using SinoSZBaseClass.Misc;
using System.Configuration;
using SinoSZBaseClass.Authorize;

namespace SinoSZClientBase
{
        public class MenuConfig
        {
                public static ISinoMenu GetMenuInterface()
                {
                        string className, profilePath;

                        string dataBaseType = ConfigurationManager.AppSettings["DataBaseType"] as string;
                        switch (dataBaseType)
                        {
                                case "ORACLE":
                                        return null;

                                case "SQLSERVER":
                                        return null;

                                case "REMOTING":
                                        IServiceFactory _serviceFactory = (IServiceFactory)RemotingClientSvc.GetAppSvrObj(typeof(IServiceFactory));
                                        RemotingClientSvc.BindTicketToCallContext(SessionClass.CurrentTicket);
                                        ISinoMenu _ret = _serviceFactory.GetInterFace("MenuServerPlugin") as ISinoMenu;
                                        return _ret;

                        }

                        return null;
                }

               
        }
}
