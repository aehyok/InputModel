using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.QueryModel
{
	[DataContract]
	public class MD_GuideLine_ParamSetting
	{
		[DataMember]
		public string ParamMeta { get; set; }
		[DataMember]
		public string DWID { get; set; }
		[DataMember]
		public string GuideLineID { get; set; }
		[DataMember]
		public string CSID { get; set; }

		public MD_GuideLine_ParamSetting() { }
		public MD_GuideLine_ParamSetting(string csid, string zbid, string dwid, string cs)
		{
			CSID = csid;
			GuideLineID = zbid;
			DWID = dwid;
			ParamMeta = cs;
		}
	}


}
