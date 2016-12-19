using System;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Entry
{
	[Serializable]
	public class EntryItem_Certificate
	{
		protected string id = "";
		protected string entry_id = "";		//报关单编号
		protected string docu_code = "";	//单证代码
		protected string docu_code_DisplayTitle = "";   //单证名称
		protected string cert_code = "";	//单证编号
		protected bool selected = false;

         [DataMember]
		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <summary>
		/// 单证名称
		/// </summary>
         [DataMember]
        public string Docu_Code_DisplayTitle
		{
			get { return docu_code_DisplayTitle; }
			set { docu_code_DisplayTitle = value; }
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
		/// 报关单号
		/// </summary>
         [DataMember]
        public string Entry_ID
		{
			get { return entry_id; }
			set { entry_id = value; }
		}

		/// <summary>
		/// 单证代码
		/// </summary>
         [DataMember]
        public string Docu_Code
		{
			get { return docu_code; }
			set { docu_code = value; }
		}

		/// <summary>
		/// 单证编号
		/// </summary>
         [DataMember]
        public string Cert_Code
		{
			get { return cert_code; }
			set { cert_code = value; }
		}

		public EntryItem_Certificate() { }
		public EntryItem_Certificate(string _id, string _entryid, string _docuCode, string _certCode)
		{
			id = _id;
			entry_id = _entryid;
			docu_code = _docuCode;
			cert_code = _certCode;
		}


	}
}
