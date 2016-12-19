using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
    /// <summary>
    /// 流程实体类型定义
    /// </summary>
	[DataContract]
	public class Flow_EntityType
	{
        /// <summary>
        /// 根单位Id
        /// </summary>
		[DataMember]
		public string RootDwid { get; set; }

        /// <summary>
        /// 流程Id
        /// </summary>
		[DataMember]
		public string Id { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
		[DataMember]
		public string FlowName { get; set; }

        /// <summary>
        /// 流程描述
        /// </summary>
		[DataMember]
		public string Description { get; set; }

		public Flow_EntityType() { }

        public Flow_EntityType(string id, string flowName, string description, string rootDwid)
		{
			this.Id = id;
            this.FlowName = flowName;
			this.Description = description;
            this.RootDwid = rootDwid;
		}
	}
}
