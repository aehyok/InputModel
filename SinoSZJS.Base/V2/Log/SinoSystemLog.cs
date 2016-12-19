using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Log
{
    /// <summary>
    /// 系统日志实体类
    /// </summary>
    [DataContract]
    public class SinoSystemLog
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 日志类型
        /// </summary>
        [DataMember]
        public string LogType { get; set; }

        /// <summary>
        /// 日志消息内容
        /// </summary>
        [DataMember]
        public string LogMessage { get; set; }

        /// <summary>
        /// 记录日志时间
        /// </summary>
        [DataMember]
        public DateTime LogTime { get; set; }
    }
}
