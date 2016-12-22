using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.InputModel
{
	[Serializable]
	public class MD_InputModel_ChildParam
	{
		private string paramName = "";
		private string paramType = "";
		private string paramValue = "";

		public MD_InputModel_ChildParam() { }
		public MD_InputModel_ChildParam(string _name, string _type, string _value)
		{
			paramName = _name;
			paramType = _type;
			paramValue = _value;
		}

		public string Name
		{
			get { return paramName; }
			set { paramName = value; }
		}

		public string DataType
		{
			get { return paramType; }
			set { paramType = value; }
		}

		public string Value
		{
			get { return paramValue; }
			set { paramValue = value; }
		}

	}
}
