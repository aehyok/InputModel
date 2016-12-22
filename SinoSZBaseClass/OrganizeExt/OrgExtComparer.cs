using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.OrganizeExt
{
	public class OrgExtComparer : IComparer<OrgExtInfo>
	{
		#region IComparer<OrgExtInfo> Members

		public int Compare(OrgExtInfo x, OrgExtInfo y)
		{
			object _xorder = x.GetValue("DISPLAYORDER");
			if (_xorder == null) return 0;
			object _yorder = y.GetValue("DISPLAYORDER");
			if (_yorder == null) return 1;
			decimal _x = (decimal)_xorder;
			decimal _y = (decimal)_yorder;
			decimal _ret = _x - _y;
			if (_ret == 0) return 0;
			return (_ret > 0) ? 1 : -1;
		}

		#endregion
	}
}
