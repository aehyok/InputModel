using System;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Entry
{
	[Serializable]
	public class EntryItem_Company
	{
		protected string id = "";
		protected string companyType = "";
		protected string companyCode = "";
		protected string companyName = "";
		protected bool selected = false;
         [DataMember]
		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <summary>
		/// 是否选择
		/// </summary>
         [DataMember]
        public bool Selected
		{
			get { return selected; }
			set { selected = value; }
		}

		/// <summary>
		/// 企业类型：经营单位、货主单位、申报单位
		/// </summary>
         [DataMember]
        public string CompanyType
		{
			get { return companyType; }
			set { companyType = value; }
		}

		/// <summary>
		/// 企业代码
		/// </summary>
         [DataMember]
        public string CompanyCode
		{
			get { return companyCode; }
			set { companyCode = value; }
		}
		/// <summary>
		/// 企业名称
		/// </summary>
         [DataMember]
        public string CompanyName
		{
			get { return companyName; }
			set { companyName = value; }
		}

		public EntryItem_Company() { }
		public EntryItem_Company(string _id, string _type, string _code, string _name)
		{
			id = _id;
			companyType = _type;
			companyCode = _code;
			companyName = _name;
		}
	}
}
