﻿using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Authorize
{
	[DataContract]
	public class UserRightFlag
	{
		[DataMember]
		public string RightId { get; set; }
		[DataMember]
		public string FatherRightId { get; set; }
		[DataMember]
		public string RightName { get; set; }
		[DataMember]
		public bool IsOwn { get; set; }
		[DataMember]
		public int DisplayOrder { get; set; }
		/// <summary>
		/// added by lqm 2012-12-17
		/// </summary>
		[DataMember]
		public string QxMeta { set; get; }

		/// <summary>
		/// 权限类型
		/// </summary>
		[DataMember]
		public string QxType { set; get; }

	}
}
