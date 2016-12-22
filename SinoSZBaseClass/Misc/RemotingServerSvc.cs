using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

namespace SinoSZBaseClass.Misc
{
        public class RemotingServerSvc
        {
                public static void Init()
                {
                        RemotingConfiguration.Configure(Utils.AppConfigFullPath);
                        //BinaryServerFormatterSinkProvider firstProvider = new BinaryServerFormatterSinkProvider();
                        //firstProvider.TypeFilterLevel = TypeFilterLevel.Full;

                        IServerChannelSinkProvider firstProvider = new CompressServerChannelSinkProvider();
                        BinaryServerFormatterSinkProvider sProvider = new BinaryServerFormatterSinkProvider();
                        sProvider.TypeFilterLevel = TypeFilterLevel.Full;                        
                        firstProvider.Next = sProvider;

                        TcpServerChannel tcpSvrChannel = new TcpServerChannel("IClient2Server_TCP", ConfigFile.ICS_TcpSvcPort, firstProvider);
                        HttpServerChannel httpSvrChannel = new HttpServerChannel("IClient2Server_HTTP", ConfigFile.ICS_HttpSvcPort, firstProvider);
                        ChannelServices.RegisterChannel(tcpSvrChannel);
                        ChannelServices.RegisterChannel(httpSvrChannel);
                        
                }

                //	注册一个基于接口实现的Single Call Remoting Service, 为Client服务
                //	入口参数：
                //		Type		interfaceType			接口类型
                //		Type		bizLogicClassType		实现该接口的业务逻辑类
                public static void RegisterService(Type interfaceType, Type bizLogicClassType)
                {
                        RemotingUtils.RegisterSingleCallService(interfaceType, bizLogicClassType);
                }
        }
}
