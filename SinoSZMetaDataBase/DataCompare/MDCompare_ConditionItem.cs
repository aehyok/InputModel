using System;
using System.Collections.Generic;
using System.Text;
using SinoSZMetaDataBase.QueryDefine;

namespace SinoSZMetaDataBase.DataCompare
{
	[Serializable]
	public class MDCompare_ConditionItem
	{
		private string _columnIndex = "";
		private MDQuery_ResultTableColumn _columnDefine = null;
		private string _operator = "";
		private string _compareField = "";

		public string ColumnIndex
		{
			get { return _columnIndex; }
			set { _columnIndex = value; }
		}

		public MDQuery_ResultTableColumn Column
		{
			get { return _columnDefine; }
			set { _columnDefine = value; }
		}

		public string Operator
		{
			get { return _operator; }
			set { _operator = value; }
		}

		public string CompareTagetField
		{
			get { return _compareField; }
			set { _compareField = value; }
		}
	}
}
