using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBaseClass.Misc;
using System.Diagnostics;

namespace SinoSZBaseClass.SystemLog
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
        }
}
