using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.FunctionRegister
{
    /// <summary>
    /// added by lqm 2012/11/7  功能注册中的Url参数
    /// </summary>
    [DataContract]
    public class IFrameParam
    {
        /// <summary>
        /// iframe的名字，默认为"FrameID"
        /// </summary>
        [DataMember]
        public string IframeName { set; get; }
        /// <summary>
        /// Url链接字符串
        /// </summary>
        [DataMember]
        public string UrlString { set; get; }

        public IFrameParam()
        {
            this.IframeName = "FrameID";
        }
    }
}
