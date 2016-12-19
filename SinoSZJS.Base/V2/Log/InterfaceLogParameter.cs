using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Log
{
    [DataContract]
    public class InterfaceLogParameter
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 内容关键字
        /// </summary>
        [DataMember]
        public string KeyWord { get; set; }
        [DataMember]
        public bool OnlyError { get; set; }
    }
}
