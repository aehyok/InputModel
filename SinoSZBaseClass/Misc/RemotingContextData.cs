using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.Misc
{
        public class RemotingContextData
        {
                private string _channelName = "";
                private object _contextData = null;

                public RemotingContextData()
                {
                }

                public RemotingContextData(string _cname, object _data)
                {
                        _channelName = _cname;
                        _contextData = _data;
                }

                public string ChannelName
                {
                        get { return _channelName; }
                        set { _channelName = value; }
                }

                public object ContextData
                {
                        get { return _contextData; }
                        set { _contextData = value; }
                }
        }
}
