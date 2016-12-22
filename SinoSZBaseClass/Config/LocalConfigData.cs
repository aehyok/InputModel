using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBaseClass.Misc;

namespace SinoSZBaseClass.Config
{
        public class LocalConfigData
        {
                public static ServerConfig InitServerConfig()
                {
                        ServerConfig _ret = new ServerConfig();
                        _ret.RootOrgID = ConfigFile.SytemDWRootID;
                        _ret.RemoteRenewValue = ConfigFile.RemoteRenewValue;
                        _ret.Client_ShowPendingAlert = ConfigFile.Client_ShowPendingAlert;
                        return _ret;
                }
        }
}
