using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SinoSZMetaDataBase.InputModel
{
	/// <summary>
	/// 录入模型
	/// </summary>
	[Serializable]
	public class MD_InputModel
	{
		private List<Assembly> ruleAssemblys = new List<Assembly>();
		private string id = "";
		private string nameSpace = "";
		private string modelName = "";
		private string modelType = "GRID";
		private string descript = "";
		private string displayName = "";
		private int displayOrder = 0;
		private string param = "";
		private string deleteRule = "";
		private string dwdm = "";
		private string initGuideLine = "";
		private string getBlankDataGuideLine = "";
		private string getNewRecordGuideLine = "";
		private string tableName = "";
		private string orderField = "";
		private string paramType = "OTHER";
		private bool isMixInputModel = false;
		private List<MD_InputModel_SaveTable> writeTableNames = new List<MD_InputModel_SaveTable>();

		private List<MD_InputModel_Column> columns = new List<MD_InputModel_Column>();
		private List<MD_InputModel_ColumnGroup> groups = new List<MD_InputModel_ColumnGroup>();
		private List<MD_InputModel_Child> childInputModels = new List<MD_InputModel_Child>();
		public MD_InputModel() { }
		public MD_InputModel(string _id, string _ns, string _name, string _descript, string _displayName, int _order, string _param, string _delRule, string _dwdm)
		{
			id = _id;
			nameSpace = _ns;
			modelName = _name;
			descript = _descript;
			displayName = _displayName;
			displayOrder = _order;
			param = _param;
			deleteRule = _delRule;
			dwdm = _dwdm;

		}

		public List<Assembly> RuleAssemblys
		{
			get
			{
				return ruleAssemblys;
			}
			set { ruleAssemblys = value; }
		}

		public string ModelType
		{
			get { return modelType; }
			set
			{
				modelType = value;
				isMixInputModel = (ModelType == "MIX");
			}
		}

		public string ParamType
		{
			get { return paramType; }
			set { paramType = value; }
		}
		public List<MD_InputModel_Child> ChildInputModel
		{
			get { return childInputModels; }
			set { childInputModels = value; }
		}

		public bool IsMixModel
		{
			get { return isMixInputModel; }
			set { isMixInputModel = value; }
		}

		public string InitGuideLine
		{
			get { return initGuideLine; }
			set { initGuideLine = value; }
		}

		public string GetBlankDataGuideLine
		{
			get { return getBlankDataGuideLine; }
			set { getBlankDataGuideLine = value; }
		}

		public string GetNewRecordGuideLine
		{
			get { return getNewRecordGuideLine; }
			set { getNewRecordGuideLine = value; }
		}
		/// <summary>
		/// 表名称
		/// </summary>
		public string TableName
		{
			get
			{
				return tableName;
			}
			set
			{
				tableName = value;
			}
		}

		public List<MD_InputModel_SaveTable> WriteTableNames
		{
			get { return writeTableNames; }
			set { writeTableNames = value; }
		}

		/// <summary>
		/// 排序顺序
		/// </summary>
		public string OrderField
		{
			get { return orderField; }
			set { orderField = value; }
		}

		public List<MD_InputModel_Column> Columns
		{
			get { return columns; }
			set { columns = value; }
		}

		public List<MD_InputModel_ColumnGroup> Groups
		{
			get { return groups; }
			set { groups = value; }
		}

		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		public string DisplayName
		{
			get { return displayName; }
			set { displayName = value; }
		}

		public int DisplayOrder
		{
			get { return displayOrder; }
			set { displayOrder = value; }
		}

		public string DWDM
		{
			get { return dwdm; }
			set { dwdm = value; }
		}

		public string DeleteRule
		{
			get { return deleteRule; }
			set { deleteRule = value; }
		}

		public string Param
		{
			get { return param; }
			set { param = value; }
		}

		public string NameSpace
		{
			get { return nameSpace; }
			set { nameSpace = value; }
		}

		public string ModelName
		{
			get { return modelName; }
			set { modelName = value; }
		}

		public string Descript
		{
			get { return descript; }
			set { descript = value; }
		}

		public string ModelFullName
		{
			get
			{
				return string.Format("{0}.{1}", nameSpace, modelName);
			}
		}

		public override string ToString()
		{
			return DisplayName;
		}

	}
}
