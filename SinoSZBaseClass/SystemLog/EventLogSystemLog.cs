using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SinoSZBaseClass.SystemLog
{
        public class EventLogSystemLog : ISystemLog
        {
                private string LogName = "ZHTJLog";

                public EventLogSystemLog() { }

                public EventLogSystemLog(string _logName)
                {
                        LogName = _logName;
                }

                #region ISystemLog Members

                public bool WriteLog(string _log, System.Diagnostics.EventLogEntryType _logType)
                {
                        try
                        {
                                //日志写入操作系统的EventLog
                                if (!EventLog.SourceExists(LogName))
                                {
                                        EventLog.CreateEventSource(LogName, LogName);
                                }
                                EventLog myLog = new EventLog(LogName);
                                myLog.Source = LogName;
                                myLog.WriteEntry(_log, _logType);
                             
                                return true;
                        }
                        catch (Exception e)
                        {
                                throw e;
                        }
                        
                }

                #endregion
        }
}
