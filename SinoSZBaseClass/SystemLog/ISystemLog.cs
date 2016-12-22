using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SinoSZBaseClass.SystemLog
{
        /// <summary>
        /// 系统日志接口
        /// </summary>
        public interface ISystemLog
        {
                bool WriteLog(string _log,EventLogEntryType _logType);
        }
}
