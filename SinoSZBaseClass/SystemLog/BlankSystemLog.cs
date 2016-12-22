using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.SystemLog
{
        public class BlankSystemLog : ISystemLog
        {

                #region ISystemLog Members

                public bool WriteLog(string _log, System.Diagnostics.EventLogEntryType _logType)
                {
                        return true;
                }

                #endregion
        }
}
