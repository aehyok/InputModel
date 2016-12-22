using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.IO;
using System.Net;
using SinoSZBaseClass.SharpZipLib.GZip;


namespace SinoSZBaseClass.Misc
{
        #region CompressClientChannelSinkProvider
        public class CompressClientChannelSinkProvider : IClientChannelSinkProvider
        {
                private IClientChannelSinkProvider _next;
                private ICollection _providerData;
                private IDictionary _dict;

                public CompressClientChannelSinkProvider()
                {
                }

                public CompressClientChannelSinkProvider(IDictionary dict, ICollection providerData)
                {
                        _dict = dict;
                        _providerData = providerData;
                }

                public IClientChannelSink CreateSink(IChannelSender channel, string url, object remoteChannelData)
                {
                        IClientChannelSink _nextSink = null;
                        if (_next != null)
                        {
                                _nextSink = _next.CreateSink(channel, url, remoteChannelData);
                                if (_nextSink == null)
                                        return null;
                        }
                        return new CompressClientChannelSink(_nextSink);
                }

                public IClientChannelSinkProvider Next
                {
                        get { return _next; }
                        set { _next = value; }
                }
        }
        #endregion

        public class CompressClientChannelSink : IClientChannelSink
        {
                private IClientChannelSink _next;

                public CompressClientChannelSink(IClientChannelSink next)
                {
                        _next = next;
                }

                #region Implementation of IClientChannelSink
                public void ProcessMessage(IMessage msg, ITransportHeaders requestHeaders, Stream requestStream, out ITransportHeaders responseHeaders, out Stream responseStream)
                {
                        CompressSinkHelper.SetClientSupportCompressFlag(requestHeaders);
                        requestStream = CompressSinkHelper.CompressStream(requestHeaders, requestStream);
                        _next.ProcessMessage(msg, requestHeaders, requestStream, out responseHeaders, out responseStream);
                        responseStream = CompressSinkHelper.DecompressStream(responseHeaders, responseStream);
                }

                public void AsyncProcessRequest(IClientChannelSinkStack sinkStack, IMessage msg, ITransportHeaders headers, Stream stream)
                {
                        CompressSinkHelper.SetClientSupportCompressFlag(headers);
                        stream = CompressSinkHelper.CompressStream(headers, stream);
                        sinkStack.Push(this, null);
                        _next.AsyncProcessRequest(sinkStack, msg, headers, stream);
                }

                public void AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack, object state, ITransportHeaders headers, Stream stream)
                {
                        CompressSinkHelper.DecompressStream(headers, stream);
                        sinkStack.AsyncProcessResponse(headers, stream);
                }

                public Stream GetRequestStream(IMessage msg, ITransportHeaders headers)
                {
                        return null;
                }

                public IClientChannelSink NextChannelSink
                {
                        get { return _next; }
                }
                #endregion

                #region Implementation of IChannelSinkBase
                public IDictionary Properties
                {
                        get { return null; }
                }
                #endregion
        }

        #region CompressServerChannelSinkProvider
        public class CompressServerChannelSinkProvider : IServerChannelSinkProvider
        {
                ICollection _providerData;
                IDictionary _dict;
                IServerChannelSinkProvider _next;

                public CompressServerChannelSinkProvider()
                {
                }

                public CompressServerChannelSinkProvider(IDictionary dict, ICollection providerData)
                {
                        _dict = dict;
                        _providerData = providerData;
                }

                #region Implementation of IServerChannelSinkProvider
                public IServerChannelSinkProvider Next
                {
                        get { return _next; }
                        set { _next = value; }
                }

                public IServerChannelSink CreateSink(IChannelReceiver channel)
                {
                        IServerChannelSink nextSink = null;
                        if (_next != null)
                        {
                                nextSink = _next.CreateSink(channel);
                                //			if (nextSink == null) 
                                //				return null;
                        }
                        return new CompressServerChannelSink(nextSink);
                }

                public void GetChannelData(IChannelDataStore channelData)
                {
                }
                #endregion
        }
        #endregion

        public class CompressServerChannelSink : IServerChannelSink
        {
                IServerChannelSink _next;

                public CompressServerChannelSink()
                {
                }

                public CompressServerChannelSink(IServerChannelSink next)
                {
                        _next = next;
                }

                #region Implementation of IServerChannelSink
                public IServerChannelSink NextChannelSink
                {
                        get { return _next; }
                }

                public ServerProcessing ProcessMessage(IServerChannelSinkStack sinkStack, IMessage requestMsg, ITransportHeaders requestHeaders, Stream requestStream, out IMessage responseMsg, out  ITransportHeaders responseHeaders, out Stream responseStream)
                {
                        if (requestMsg != null)
                                return _next.ProcessMessage(sinkStack, requestMsg, requestHeaders, requestStream, out responseMsg, out responseHeaders, out responseStream);

                        try
                        {
                                IPAddress IPAddr = (IPAddress)requestHeaders[CommonTransportKeys.IPAddress];
                                //===================================
                                //Console.WriteLine(IPAddr.ToString());
                                //====================================
                                CallContext.SetData("ClientIP", IPAddr);
                                //IPHostEntry hostInfo = Dns.Resolve("");
                                //string _hs = requestHeaders[CommonTransportKeys.RequestUri].ToString() ;
                                //CallContext.SetData("ClientHost",_hs);
                        }
                        catch (Exception ex)
                        {
                                string errmsg = ex.Message;
                        }

                        requestStream = CompressSinkHelper.DecompressStream(requestHeaders, requestStream);
                        sinkStack.Push(this, null);
                        ServerProcessing processing = _next.ProcessMessage(sinkStack, null, requestHeaders, requestStream, out responseMsg, out responseHeaders, out responseStream);

                        //	这样写是否有效还未验证, ???
                        //			if (CompressSinkHelper.IsClientSupportCompress(requestHeaders))
                        //				CompressSinkHelper.SetClientSupportCompressFlag(responseHeaders);

                        switch (processing)
                        {
                                case ServerProcessing.Complete:
                                        sinkStack.Pop(this);
                                        if (CompressSinkHelper.IsClientSupportCompress(requestHeaders))
                                                responseStream = CompressSinkHelper.CompressStream(responseHeaders, responseStream);
                                        break;
                                case ServerProcessing.OneWay:
                                        sinkStack.Pop(this);
                                        break;
                                case ServerProcessing.Async:
                                        sinkStack.Store(this, null);
                                        break;
                        }
                        return processing;
                }

                public void AsyncProcessResponse(IServerResponseChannelSinkStack sinkStack, object state, IMessage msg, ITransportHeaders headers, Stream stream)
                {
                        try
                        {
                                IPAddress IPAddr = (IPAddress)headers[CommonTransportKeys.IPAddress];
                                //====================================
                                //Console.WriteLine(IPAddr.ToString());
                                //====================================
                                CallContext.SetData("ClientIP", IPAddr);
                                //IPHostEntry hostInfo = Dns.Resolve("");
                                //string _hs = headers[CommonTransportKeys.RequestUri].ToString() ;
                                //CallContext.SetData("ClientHost",_hs);
                        }
                        catch(Exception ex)
                        {
                                string errmsg = ex.Message;
                        }


                        //if (CompressSinkHelper.IsClientSupportCompress(headers))
                        stream = CompressSinkHelper.CompressStream(headers, stream);
                        sinkStack.AsyncProcessResponse(msg, headers, stream);
                }

                public Stream GetResponseStream(IServerResponseChannelSinkStack sinkStack, object state, IMessage msg, ITransportHeaders headers)
                {
                        return null;
                }
                #endregion

                #region Implementation of IChannelSinkBase
                public IDictionary Properties
                {
                        get { return null; }
                }
                #endregion
        }

        internal class CompressSinkHelper
        {
                private const int CompressBaseSize = 1024;						//	最小的压缩基数
                private const string ClientSupportCompressFlag = "ClientSupportCompress";		//	客户端是否支持压缩
                private const string CompressedFlag = "Compressed";					//	流是否已经压缩

                public static void SetClientSupportCompressFlag(ITransportHeaders header)
                {
                        header[CompressSinkHelper.ClientSupportCompressFlag] = Boolean.TrueString;
                }

                public static bool IsClientSupportCompress(ITransportHeaders header)
                {
                        object flag = header[CompressSinkHelper.ClientSupportCompressFlag];
                        if (flag == null)
                                return false;
                        return Boolean.Parse((string)flag);
                }

                public static Stream CompressStream(ITransportHeaders header, Stream stream)
                {
                        //	大于一定的大小才进行压缩
                        if (stream.Length >= CompressBaseSize)
                        {
                                header[CompressSinkHelper.CompressedFlag] = Boolean.TrueString;
                                return CompressHelper.CompressStream(stream);
                        }
                        else
                                return stream;
                }

                public static Stream DecompressStream(ITransportHeaders header, Stream stream)
                {
                        if (_IsStreamCompressed(header))
                                return CompressHelper.DecompressStream(stream);
                        else
                                return stream;
                }

                private static bool _IsStreamCompressed(ITransportHeaders header)
                {
                        object flag = header[CompressSinkHelper.CompressedFlag];
                        if (flag == null)
                                return false;
                        return Boolean.Parse((string)flag);
                }
        }

        internal class CompressHelper
        {
                const int _bufferSize = 4096;

                internal static Stream CompressStream(Stream stream)
                {
                        Stream output = new MemoryStream();
                        GZipOutputStream compressor = new GZipOutputStream(output);
                        byte[] buffer = new byte[_bufferSize];
                        int numBytes;
                        while ((numBytes = stream.Read(buffer, 0, _bufferSize)) > 0)
                                compressor.Write(buffer, 0, numBytes);
                        compressor.Finish();
                        output.Position = 0;
                        return output;
                }

                internal static Stream DecompressStream(Stream stream)
                {
                        Stream output = new MemoryStream();
                        GZipInputStream decompressor = new GZipInputStream(stream);
                        byte[] buffer = new byte[_bufferSize];
                        int numBytes;
                        while ((numBytes = decompressor.Read(buffer, 0, _bufferSize)) > 0)
                                output.Write(buffer, 0, numBytes);
                        decompressor.Close();
                        output.Position = 0;
                        return output;
                }
        }
}
