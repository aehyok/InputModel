using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.InputModel
{
	[Serializable]
	public class MD_InputModel_SaveTableColumn
	{
		private string id = "";
		private string srcColumn = "";
		private string desColumn = "";
		private string method = "";
		private string descript = "";

		public MD_InputModel_SaveTableColumn() { }
		public MD_InputModel_SaveTableColumn(string _id, string _srcCol, string _desCol, string _method, string _descript)
		{
			id = _id;
			SrcColumn = _srcCol;
			DesColumn = _desCol;
			method = _method;
			descript = _descript;
		}

		public string Descript
		{
			get { return descript; }
			set { descript = value; }
		}

		public string ID
		{
			get { return id; }
			set { id = value; }
		}
		public string SrcColumn
		{
			get { return srcColumn; }
			set { srcColumn = value.ToUpper(); }
		}
		public string DesColumn
		{
			get { return desColumn; }
			set { desColumn = value.ToUpper(); }
		}

		public string Method
		{
			get { return method; }
			set { method = value; }
		}
	}
}
