using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.InputModel
{
	[Serializable]
	public class MD_InputModel_Child
	{
		private string id = "";
		private string inputModelName = "";
		private string childModelName = "";
		private MD_InputModel childModelDefine = null;
		private List<MD_InputModel_ChildParam> paramList = new List<MD_InputModel_ChildParam>();
		private int displayOrder = 0;

		public MD_InputModel_Child() { }
		public MD_InputModel_Child(string _id, string _modelName, string _childName, int _order)
		{
			id = _id;
			inputModelName = _modelName;
			childModelName = _childName;
			displayOrder = _order;
		}

		public int DisplayOrder
		{
			get { return displayOrder; }
			set { displayOrder = value; }
		}

		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		public MD_InputModel ChildModel
		{
			get { return childModelDefine; }
			set { childModelDefine = value; }
		}

		public List<MD_InputModel_ChildParam> Parameters
		{
			get { return paramList; }
			set { paramList = value; }
		}

		public string InputModelName
		{
			get { return inputModelName; }
			set { inputModelName = value; }
		}

		public string ChildModelName
		{
			get { return childModelName; }
			set
			{
				childModelName = value;
			}
		}

		public override string ToString()
		{
			return ChildModelName;
		}
	}
}
