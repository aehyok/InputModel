using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SinoSZJS.Base.V2.SystemLog
{
	/// <summary>
	/// 系统日志接口
	/// </summary>
	public interface ISystemLog
	{
		bool WriteLog(string _log, EventLogEntryType _logType);
		bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID);
	}
}
