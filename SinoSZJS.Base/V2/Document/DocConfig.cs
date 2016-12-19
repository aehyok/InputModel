using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
    /// <summary>
    /// 文书配置表信息
    /// </summary>
    [DataContract]
    public class DocConfig
    {
        /// <summary>
        /// GUID
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 文书类型Id
        /// </summary>
        [DataMember]
        public string DocTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string DocTitle { get; set; }

        /// <summary>
        /// 单位Id
        /// </summary>
        [DataMember]
        public string UnitId { get; set; }

        /// <summary>
        /// 流程Id
        /// </summary>
        [DataMember]
        public string FlowId { get; set; }

        /// <summary>
        /// 签章字号
        /// </summary>
        [DataMember]
        public string SignPath { get; set; }

        /// <summary>
        /// 文书字号开头文字设置
        /// </summary>
        [DataMember]
        public string DocNoKey { get; set; }

        /// <summary>
        /// 签章方式 0不签章，1直接签章，2审批签章，3拟稿转换签章
        /// </summary>
        [DataMember]
        public string SignWay { get; set; }

        /// <summary>
        /// 是否当前取当前单位
        /// </summary>
        [DataMember]
        public string SignCurrent { get; set; }

        /// <summary>
        /// added by lqm 20151119
        /// 备注，暂时主要为了解决告知单和决定书文书字号 根据违规和走私
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// added by lqm 20160108
        /// 针对每一份文书都可以设置一个文书的流水号
        /// </summary>
        [DataMember]
        public string DocConfigLsh { get; set; }

        /// <summary>
        /// added by lqm 20160111
        /// 针对行政案件违规和走私案件区别文书字号以及起始值设置
        /// </summary>
        [DataMember]
        public string DocConfigLsh2 { get; set; }
    }
}
