using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace SinoSZJS.Base.WCF
{
    public class WCFUtils
    {
        public static RemoteEndpointMessageProperty GetCurrentWCFClientEndpoint()
        {
            //提供方法执行的上下文环境
            OperationContext context = OperationContext.Current;
            //获取传进的消息属性
            MessageProperties properties = context.IncomingMessageProperties;
            //获取消息发送的远程终结点IP和端口
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            return endpoint;
        }

    }
}
