//	RemotingUtils
//
//	�����й�Remoting�Ļ�������
//
//	����:		������(2003.10.27)
//	
//	����:
//
//	���˼·:
//		��ģ���֧�ֻ��ڽӿ�ʵ�ֵ�Remoting Service. ���ҹ̶�ʹ�ýӿ�������ΪService��URI����
//
//	�汾����:
//
//	��������:

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
                //	ע��һ�����ڽӿ�ʵ�ֵ�Single Call Remoting Service
                //	��ڲ�����
                //		Type		interfaceType			�ӿ�����
                //		Type		bizLogicClassType		ʵ�ָýӿڵ�ҵ���߼���

                public static void RegisterSingleCallService(Type interfaceType, Type bizLogicClassType)
                {
#if DEBUG
                        Debug.Assert(bizLogicClassType.IsSubclassOf(typeof(MarshalByRefObject)), "Remoting������ " +
                                                        bizLogicClassType.ToString() + " ����Ҫ��MarshalByRefObject�̳�");
                        Type[] interfaces = bizLogicClassType.GetInterfaces();
                        foreach (Type interfaceType2 in interfaces)
                        {
                                if (interfaceType2 == interfaceType)
                                        goto InterfaceFound;
                        }
                        Debug.Assert(false, "Remoting������ " + bizLogicClassType.ToString() + " û��ʵ��ָ���Ľӿ� " + interfaceType.ToString());
                InterfaceFound:
#endif
                        RemotingConfiguration.RegisterWellKnownServiceType(bizLogicClassType, interfaceType.ToString(), WellKnownObjectMode.SingleCall);
                        RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                        RemotingConfiguration.CustomErrorsEnabled(false);
                }

                //	���һ���������˼������
                //	��ڲ�����
                //		Type		type						�ӿ�����
                //		string		remotingSvcUriPrefix		Remoting Service URI��ǰ׺(����"tcp://localhost:8088/"), һ��������config�ļ���
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