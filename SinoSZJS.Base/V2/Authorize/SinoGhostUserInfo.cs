using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2.Authorize
{
    public class SinoGhostUserInfo : SinoUserBaseInfo
    {
        public SinoUserBaseInfo RealUser { get; set; }
        public SinoUserBaseInfo SimulateUser { get; set; }

        public override string LoginName
        {
            get { return SimulateUser.LoginName; }
            set { SimulateUser.LoginName = value; }
        }


    }
}
