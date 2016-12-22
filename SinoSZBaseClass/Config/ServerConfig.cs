using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.Config
{
        [Serializable]
        public class ServerConfig
        {
                public int RemoteRenewValue = 20;
                public string RootOrgID = "";
                public bool Client_ShowPendingAlert = false;
        }
}
