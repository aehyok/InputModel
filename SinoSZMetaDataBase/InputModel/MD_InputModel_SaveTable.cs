using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.InputModel
{
	[Serializable]
	public class MD_InputModel_SaveTable
	{
		private string id = "";
		private string tableName = "";
		private string tableTitle = "";
		private bool isLock = true;
		private int displayOrder = 0;
		private string inputModelID = "";
		private List<MD_InputModel_SaveTableColumn> columns = new List<MD_InputModel_SaveTableColumn>();

		public MD_InputModel_SaveTable() { }
		public MD_InputModel_SaveTable(string _id, string _tname, string _title, bool _isLock, string _modelID, int _order)
		{
			id = _id;
			tableName = _tname;
			tableTitle = _title;
			isLock = _isLock;
			displayOrder = _order;
			inputModelID = _modelID;
		}

		public List<MD_InputModel_SaveTableColumn> Columns
		{
			get { return columns; }
			set { columns = value; }
		}


		public string InputModelID
		{
			get { return inputModelID; }
			set { inputModelID = value; }
		}


		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		public bool IsLock
		{
			get { return isLock; }
			set { isLock = value; }
		}

		public int DisplayOrder
		{
			get { return displayOrder; }
			set { displayOrder = value; }
		}

		public string TableName
		{
			get { return tableName; }
			set { tableName = value; }
		}

		public string TableTitle
		{
			get { return tableTitle; }
			set { tableTitle = value; }
		}

		public override string ToString()
		{
			return string.Format("{0} [{1}]", tableTitle, tableName);
		}
	}
}
