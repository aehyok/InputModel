using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SinoSZJS.Base.V2.SystemLog
{
	public class SystemLogWriter
	{
		private static ISystemLog _ics_SystemLog = null;
		public static ISystemLog ICS_SystemLog
		{
			get
			{
				return _ics_SystemLog;
			}
			set
			{
				_ics_SystemLog = value;
			}

		}

		public static bool WriteLog(string _msg, EventLogEntryType _type)
		{
			if (_ics_SystemLog != null) return _ics_SystemLog.WriteLog(_msg, _type);
			return true;
		}

		static public bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
		{
			if (_ics_SystemLog != null) return _ics_SystemLog.WriteUserLog(_yhid, _czlx, _cxnr, _resulttype, _ipaddr, _hostName, _systemID);
			return true;
		}

	}
}
