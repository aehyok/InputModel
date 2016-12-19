using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Log
{
    [DataContract]
    public class SinoUserLog
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember]
        public string UserID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]        
        public string UserName { get; set; }
        /// <summary>
        /// 日志时间
        /// </summary>
        [DataMember]
        public DateTime LogTime { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        [DataMember]
        public string LogType { get; set; }
        /// <summary>
        /// 日志消息
        /// </summary>
        [DataMember]
        public string LogMessage { get; set; }
        [DataMember]
        public string FromIP { get; set; }
        [DataMember]
        public string FromHost { get; set; }
        [DataMember]
        public string PostID { set; get; }
        [DataMember]
        public string PostName { set; get; }
    }
}
