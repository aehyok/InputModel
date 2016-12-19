using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Log
{
    [DataContract]
    public class SinoQueryLog
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string UserID { get; set; }
        /// <summary>
        /// 操作用户
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        [DataMember]
        public DateTime LogTime { get; set; }
        /// <summary>
        /// 查询日志内容
        /// </summary>
        [DataMember]
        public string QueryContent { get; set; }
        /// <summary>
        /// 查询耗时
        /// </summary>
        [DataMember]
        public decimal UsedTime { get; set; }
        /// <summary>
        /// 返回记录数
        /// </summary>
        [DataMember]
        public string RetCount { get; set; }
    }
}
