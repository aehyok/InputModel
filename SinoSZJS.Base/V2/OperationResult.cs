using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

//added by lqm 20150926 
namespace SinoSZJS.Base.V2
{
    /// <summary>
    /// 操作结果信息返回
    /// </summary>
    [DataContract]
    public class OperationResult
    {
        /// <summary>
        /// 返回消息字符串
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// 操作是否成功（true为成功，fasle为失败）
        /// </summary>
        [DataMember]
        public bool Success { get; set; }
    }
}
