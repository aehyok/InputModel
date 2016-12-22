using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Lifetime;
using SinoSZBaseClass.Authorize;

namespace SinoSZBaseClass.Misc
{
        public class SinoSZClientSponsor : MarshalByRefObject,ISponsor
        {
                private int RenewValue = 20;
                #region ISponsor Members
                public SinoSZClientSponsor()
                {
                        RenewValue = SessionClass.RemoteRenewValue;
                }

                public SinoSZClientSponsor(int _renewValue)
                {
                        RenewValue = _renewValue;
                }

                public TimeSpan Renewal(ILease lease)
                {
                        //Console.WriteLine("远程对象租期续约{0}秒!", RenewValue);
                        return TimeSpan.FromSeconds(RenewValue);
                }

                #endregion

        }
}
