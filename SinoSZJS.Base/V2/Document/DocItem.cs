using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
	[DataContract]
	/// <summary>
	/// 文书事项实体
	/// </summary>
	public class DocItem
	{
		[DataMember]
		public string ID { set; get; }
		
		/// <summary>
		/// 事项说明
		/// </summary>
        [DataMember]
		public string SXSM { set; get; }
		
		/// <summary>
		/// 实体id
		/// </summary>
        [DataMember]
        public string BZID { set; get; }
		
		/// <summary>
		/// 生成时间
		/// </summary>
        [DataMember]
        public DateTime SCSJ { set; get; }
		
		/// <summary>
		/// 事项状态
		/// </summary>
        [DataMember]
        public string SXZT { set; get; }
        
        /// <summary>
        /// 动作id
        /// </summary>
        [DataMember]
        public string ActionID { set; get; }
		
		/// <summary>
		/// 定义事项
		/// </summary>
        [DataMember]
        public List<DocItemDetail> DYSX { set; get; }
	}
}
