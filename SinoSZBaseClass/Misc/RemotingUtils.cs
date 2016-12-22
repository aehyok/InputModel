//	RemotingUtils
//
//	处理有关Remoting的基础问题
//
//	作者:		黄晓东(2003.10.27)
//	
//	描述:
//
//	设计思路:
//		本模块仅支持基于接口实现的Remoting Service. 并且固定使用接口名称作为Service的URI名称
//
//	版本特性:
//
//	遗留问题:

using System;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;

namespace SinoSZBaseClass.Misc
{
        /// <summary>
        /// Summary description for RemotingUtils.
        /// </summary>
        public class RemotingUtils
        {
                //	注册一个基于接口实现的Single Call Remoting Service
                //	入口参数：
                //		Type		interfaceType			接口类型
                //		Type		bizLogicClassType		实现该接口的业务逻辑类

                public static void RegisterSingleCallService(Type interfaceType, Type bizLogicClassType)
                {
#if DEBUG
                        Debug.Assert(bizLogicClassType.IsSubclassOf(typeof(MarshalByRefObject)), "Remoting服务类 " +
                                                        bizLogicClassType.ToString() + " 必须要从MarshalByRefObject继承");
                        Type[] interfaces = bizLogicClassType.GetInterfaces();
                        foreach (Type interfaceType2 in interfaces)
                        {
                                if (interfaceType2 == interfaceType)
                                        goto InterfaceFound;
                        }
                        Debug.Assert(false, "Remoting服务类 " + bizLogicClassType.ToString() + " 没有实现指定的接口 " + interfaceType.ToString());
                InterfaceFound:
#endif
                        RemotingConfiguration.RegisterWellKnownServiceType(bizLogicClassType, interfaceType.ToString(), WellKnownObjectMode.SingleCall);
                        RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                        RemotingConfiguration.CustomErrorsEnabled(false);
                }

                //	获得一个服务器端激活对象
                //	入口参数：
                //		Type		type						接口类型
                //		string		remotingSvcUriPrefix		Remoting Service URI的前缀(形如"tcp://localhost:8088/"), 一般配置在config文件中
                public static object GetObject(Type type, string remotingSvcUriPrefix)
                {
                        //CallContext.SetData("c111", "111111");
                        return Activator.GetObject(type, remotingSvcUriPrefix + type.ToString());
                }

                public static object GetObject(Type type, string remotingSvcUriPrefix, RemotingContextData _contextData)
                {
                        CallContext.SetData(_contextData.ChannelName, _contextData.ContextData);
                        return Activator.GetObject(type, remotingSvcUriPrefix + type.ToString());
                }
        }
}