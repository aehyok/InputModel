using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Configuration;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Collections;
using System.Net;
using SinoSZBaseClass.Authorize;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters;

namespace SinoSZBaseClass.Misc
{
        public class RemotingClientSvc
        {
                static RemotingClientSvc()
                {
                        //	目前放弃使用标准的config来初始化Remoting，换用appSettings代替
                        //      RemotingConfiguration.Configure(Utils.CfgFullPath);		
                        //      IClientChannelSinkProvider firstProvider	= new BinaryClientFormatterSinkProvider();

                        BinaryClientFormatterSinkProvider firstProvider = new BinaryClientFormatterSinkProvider();
                        BinaryServerFormatterSinkProvider ServerProvider = new BinaryServerFormatterSinkProvider();
                        ServerProvider.TypeFilterLevel = TypeFilterLevel.Full;

                        if (ConfigFile.ICS_Compress)
                                firstProvider.Next = new CompressClientChannelSinkProvider();


                        if (ConfigFile.ICS_Channel == Config_IcsChannel.Tcp)
                        {

                                IDictionary props = new Hashtable();
                                props["name"] = "IClient2Server_TCP";
                                props["port"] = 0;
                                TcpChannel channel = new TcpChannel(props, firstProvider, ServerProvider);
                                ChannelServices.RegisterChannel(channel, false);

                                //TcpChannel channel = new TcpChannel(0);
                                //ChannelServices.RegisterChannel(channel, false);
                        }
                        else
                        {

                                if (!ConfigFile.ICS_HttpProxy_Enable)
                                {
                                        IDictionary props = new Hashtable();
                                        props["name"] = "IClient2Server_HTTP";
                                        props["port"] = 0;
                                        HttpChannel hchannel = new HttpChannel(props,firstProvider,ServerProvider);
                                        ChannelServices.RegisterChannel(hchannel, false);
                                }
                                else
                                {
                                        IDictionary props = new Hashtable();
                                        props["name"] = "IClient2Server_HTTP";
                                        props["proxyName"] = ConfigFile.ICS_HttpProxy_Addr;
                                        props["proxyPort"] = ConfigFile.ICS_HttpProxy_Port;
                                        if (ConfigFile.ICS_HttpProxy_NeedAccount)
                                        {
                                                NetworkCredential credential;
                                                if (ConfigFile.ICS_HttpProxy_Domain == string.Empty)
                                                        credential = new NetworkCredential(ConfigFile.ICS_HttpProxy_UserName, ConfigFile.ICS_HttpProxy_Password);
                                                else
                                                        credential = new NetworkCredential(ConfigFile.ICS_HttpProxy_UserName, ConfigFile.ICS_HttpProxy_Password, ConfigFile.ICS_HttpProxy_Domain);
                                                props["credentials"] = credential;
                                        }
                                        HttpClientChannel cltChannel = new HttpClientChannel(props, firstProvider);
                                        ChannelServices.RegisterChannel(cltChannel, false);
                                }

                        }


                }


                //	获得一个AppServer服务器提供的远程对象
                //	入口参数：
                //		Type		interfaceType			接口类型
                public static object GetAppSvrObj(Type interfaceType)
                {
                        //	目前发现有时候如果服务器端抛出异常，客户端截获后, 当前线程的CallContext会丢失
                        //	由于目前目前程序是将用户当前身份放在CallContext中的, 所以导致问题
                        //	因此，在下面的代码中添加一行，每次GetAppSvrObj的时候强制将当前用户身份设置到CallContext中
                        //	此方案要求每次用户调用remoteObj之前都必须调用GetAppSvrObj，而不能GetAppSvrObj之后长期使用
			RemotingUserCTX.SetCurUser(SessionClass.CurrentSinoUser);

                        if (ConfigFile.ICS_Channel == Config_IcsChannel.Tcp)
                                return RemotingUtils.GetObject(interfaceType, ConfigFile.ICS_UriPrefix_TCP);
                        else
                                return RemotingUtils.GetObject(interfaceType, ConfigFile.ICS_UriPrefix_HTTP);
                }

                //	获得一个AppServer服务器提供的远程对象
                //	入口参数：
                //		Type		interfaceType			接口类型
                public static object GetAppSvrObj(Type interfaceType, RemotingContextData _contextData)
                {
                        //	目前发现有时候如果服务器端抛出异常，客户端截获后, 当前线程的CallContext会丢失
                        //	由于目前目前程序是将用户当前身份放在CallContext中的, 所以导致问题
                        //	因此，在下面的代码中添加一行，每次GetAppSvrObj的时候强制将当前用户身份设置到CallContext中
                        //	此方案要求每次用户调用remoteObj之前都必须调用GetAppSvrObj，而不能GetAppSvrObj之后长期使用
			RemotingUserCTX.SetCurUser(SessionClass.CurrentSinoUser);

                        if (ConfigFile.ICS_Channel == Config_IcsChannel.Tcp)
                                return RemotingUtils.GetObject(interfaceType, ConfigFile.ICS_UriPrefix_TCP, _contextData);
                        else
                                return RemotingUtils.GetObject(interfaceType, ConfigFile.ICS_UriPrefix_HTTP, _contextData);
                }

                //	获得一个AppServer服务器提供的远程服务的URI
                //	入口参数：
                //		Type		interfaceType			接口类型
                public static string GetAppSvrUri(Type interfaceType)
                {
                        if (ConfigFile.ICS_Channel == Config_IcsChannel.Tcp)
                                return ConfigFile.ICS_UriPrefix_TCP + interfaceType.ToString();
                        else
                                return ConfigFile.ICS_UriPrefix_HTTP + interfaceType.ToString();
                }

                public static void BindTicketToCallContext(SinoSZTicketInfo _ticketInfo)
                {
                        CallContext.SetData("UserIdentity", _ticketInfo);
                }
        }
}
