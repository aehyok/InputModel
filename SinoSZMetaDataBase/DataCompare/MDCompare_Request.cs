using System;
using System.Collections.Generic;
using System.Text;
using SinoSZMetaDataBase.QueryDefine;
using System.Data;

namespace SinoSZMetaDataBase.DataCompare
{
	[Serializable]
	public class MDCompare_Request : MDQuery_Request
	{
		public DataTable ExcelData = null;
		public Dictionary<string, string> ColumnDictionary = new Dictionary<string, string>();
		public string CompareConditionExpression = "";
		public Dictionary<string, MDCompare_ConditionItem> CompareItems = new Dictionary<string, MDCompare_ConditionItem>();
	}
}
