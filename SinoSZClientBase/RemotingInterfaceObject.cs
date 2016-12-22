using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBaseClass.Misc;
using SinoSZPluginFramework.ServerPlugin;
using System.Runtime.Remoting.Lifetime;
using SinoSZBaseClass.Authorize;

namespace SinoSZClientBase
{
        /// <summary>
        /// 远程接口对象基类
        /// 提供对提供生存期管理，提供对连接状态的管理，当disconnect时，则提供一个新的实例。
        /// </summary>
        public class RemotingInterfaceObject
        {
                /// <summary>
                /// 接口名称
                /// </summary>
                protected string InterfaceName = "";
                /// <summary>
                /// 远程对象
                /// </summary>
                protected object remoteObject = null;
                /// <summary>
                /// 发起者
                /// </summary>
                protected SinoSZClientSponsor sponsor = null;

                /// <summary>
                /// 远程对象
                /// </summary>
                virtual public object RemoteObject
                {
                        get
                        {
                                if (remoteObject != null)
                                {

                                        try
                                        {
                                                MarshalByRefObject _mo = remoteObject as MarshalByRefObject;
                                                ILease lease = (ILease)_mo.GetLifetimeService();
                                                if (lease.CurrentState == LeaseState.Active)
                                                {

                                                        return remoteObject;
                                                }

                                        }
                                        catch
                                        {
                                                CreateObject();
                                                return remoteObject;
                                        }
                                }

                                CreateObject();
                                return remoteObject;
                        }
                }

                /// <summary>
                /// 构建远程接口
                /// </summary>
                /// <param name="_interfaceName">远程接口名称</param>
                public RemotingInterfaceObject(string _interfaceName)
                {
                        InterfaceName = _interfaceName;
                        CreateObject();
                }

                /// <summary>
                /// 撤销远程接口
                /// </summary>
                virtual public void Dispose()
                {
                        if (remoteObject != null)
                        {
                                try
                                {
                                        MarshalByRefObject _mo = remoteObject as MarshalByRefObject;
                                        ILease lease = (ILease)_mo.GetLifetimeService();
                                        lease.Unregister(sponsor);
                                }
                                catch(Exception e)
                                {
                                        string errmsg = e.Message;
                                }                                
                        }
                }

                /// <summary>
                /// 通过Remoting 接口创建远程接口对象
                /// </summary>
                virtual protected void CreateObject()
                {
                        IServiceFactory _serviceFactory = (IServiceFactory)RemotingClientSvc.GetAppSvrObj(typeof(IServiceFactory));
                        RemotingClientSvc.BindTicketToCallContext(SessionClass.CurrentTicket);
                        MarshalByRefObject _ret = _serviceFactory.GetInterFace(InterfaceName) as MarshalByRefObject;

                        ILease clease = (ILease)_ret.GetLifetimeService();
                        sponsor = new SinoSZClientSponsor();
                        clease.Register(sponsor);//为自己注册生存期租约主办方     
                        remoteObject = _ret;
                }


        }
}
