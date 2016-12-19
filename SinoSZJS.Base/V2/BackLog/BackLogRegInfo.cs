using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.BackLog
{
    //todo:aehyok 添加注释
	/// <summary>
	/// 分组待办实体
	/// </summary>
	[DataContract]
	public class BackLogRegInfo
	{
		[DataMember]
		public string Id { set; get; }
		[DataMember]
		public string AppName { set; get; }
		[DataMember]
		public string Title { set; get; }
		[DataMember]
		public string CountUrl { set; get; }
		[DataMember]
		public string ImgUrl { set; get; }
		[DataMember]
		public string Type { set; get; }
		[DataMember]
		public string LinkUrl { set; get; }
	}
}
