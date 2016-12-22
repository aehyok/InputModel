using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.Excel
{
	public class ExcelColumnAlias
	{
		public string ColumnName = "";
		public string Alias = "";

		public override string ToString()
		{
			return ColumnName;
		}
	}
}
