using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Lifetime;

namespace SinoSZBaseClass.Misc
{
        public delegate void TestHandler();

        public class SinoSZServerObject : MarshalByRefObject
        {

                private static int reNewValue = ConfigFile.RemoteRenewValue;
                public string ServerObjectName = "远程对象";           
                
                public override object InitializeLifetimeService()
                {

                        ILease lease = (ILease)base.InitializeLifetimeService();
                        if (LeaseState.Initial == lease.CurrentState)
                        {
                                
                                lease.InitialLeaseTime = TimeSpan.FromSeconds(reNewValue);
                                lease.SponsorshipTimeout = TimeSpan.FromSeconds(reNewValue +120);
                                lease.RenewOnCallTime = TimeSpan.FromSeconds(reNewValue);
                        }
                        return lease;
                }
        }
}
