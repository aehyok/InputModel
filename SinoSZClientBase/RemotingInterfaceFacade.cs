using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework.ServerPlugin;
using SinoSZBaseClass.Misc;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting;
using SinoSZBaseClass.Authorize;

namespace SinoSZClientBase
{
        /// <summary>
        /// Remoting远程接口对象管理类
        /// 用于保持唯一的远程接口对象，提供生存期管理，提供对连接状态的管理，当disconnect时，则提供一个新的实例。
        /// </summary>
        public class RemotingInterfaceFacade
        {
                private static Dictionary<string, object> serverObjectLib = new Dictionary<string, object>();
                private static Dictionary<string, SinoSZClientSponsor> sponsorLib = new Dictionary<string, SinoSZClientSponsor>();

                /// <summary>
                /// 取一个远程对象接口
                /// </summary>
                /// <param name="_interfaceName"></param>
                /// <returns></returns>
                public static object GetRemotingInterface(string _interfaceName)
                {
                        if (serverObjectLib.ContainsKey(_interfaceName))
                        {
                                object _icsObject = serverObjectLib[_interfaceName];
                                try
                                {
                                        MarshalByRefObject _mo = _icsObject as MarshalByRefObject;
                                        ILease lease = (ILease)_mo.GetLifetimeService();
                                        if (lease.CurrentState == LeaseState.Active)
                                        {

                                                return _icsObject;
                                        }

                                }
                                catch(Exception e)
                                {
                                        string errmsg = e.Message;
                                }
                                sponsorLib.Remove(_interfaceName);
                                serverObjectLib.Remove(_interfaceName);
                        }
                        
                        IServiceFactory _serviceFactory = (IServiceFactory)RemotingClientSvc.GetAppSvrObj(typeof(IServiceFactory));
                        RemotingClientSvc.BindTicketToCallContext(SessionClass.CurrentTicket);
                        MarshalByRefObject _ret = _serviceFactory.GetInterFace(_interfaceName) as MarshalByRefObject;

                        ILease clease = (ILease)_ret.GetLifetimeService();
                        SinoSZClientSponsor _sp = new SinoSZClientSponsor();
                        clease.Register(_sp);//为自己注册生存期租约主办方     
                        sponsorLib.Add(_interfaceName, _sp);
                        serverObjectLib.Add(_interfaceName, _ret);
                        return _ret;
                }

                /// <summary>
                /// 注销远程对象接口
                /// </summary>
                /// <param name="_interfaceName"></param>
                /// <returns></returns>
                public static void DiscardRemotingInterface(string _interfaceName)
                {
                        if (serverObjectLib.ContainsKey(_interfaceName))
                        {
                                object _icsObject = serverObjectLib[_interfaceName];
                                try
                                {
                                        MarshalByRefObject _mo = _icsObject as MarshalByRefObject;
                                        ILease lease = (ILease)_mo.GetLifetimeService();
                                        lease.Unregister(sponsorLib[_interfaceName]);                                        
                                }
                                catch(Exception e)
                                {
                                        string errmsg = e.Message;
                                }
                                sponsorLib.Remove(_interfaceName);
                                serverObjectLib.Remove(_interfaceName);
                        }                      
                }


        }
}
