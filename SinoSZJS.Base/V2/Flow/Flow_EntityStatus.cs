using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
    /// <summary>
    /// 流程状态实体类
    /// </summary>
	[DataContract]
	public class Flow_EntityStatus
	{
        /// <summary>
        /// 所属流程Id
        /// </summary>
		[DataMember]
		public string FlowId { get; set; }

        /// <summary>
        /// 状态顺序
        /// </summary>
		[DataMember]
		public decimal Order { get; set; }

        /// <summary>
        /// 动作Id
        /// </summary>
		[DataMember]
		public string Id { get; set; }

        /// <summary>
        /// 动作名
        /// </summary>
		[DataMember]
		public string Name { get; set; }

        /// <summary>
        /// 动作显示名
        /// </summary>
		[DataMember]
		public string DisplayName { get; set; }

        /// <summary>
        /// 动作描述
        /// </summary>
		[DataMember]
		public string Description { get; set; }

        /// <summary>
        /// 动作类型
        /// </summary>
		[DataMember]
		public string Type { get; set; }

		public Flow_EntityStatus() { }
        public Flow_EntityStatus(string id, string actionName, string displayName, string description, string type, string flowId, decimal displayOrder)
		{
			this.FlowId = flowId;
			this.Id = id;
            this.Name = actionName;
			this.DisplayName = displayName;
			this.Description = description;
			this.Type = type;
            this.Order = displayOrder;
		}





	}
}
