using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.SystemLog
{
        public class DataBaseSystemLog :ISystemLog
        {
                private ISystemLog _dbLogwriter = null;
                
                #region ISystemLog Members

                public bool WriteLog(string _log, System.Diagnostics.EventLogEntryType _logType)
                {
                        if (_dbLogwriter != null)
                        {
                                return _dbLogwriter.WriteLog(_log, _logType);
                        }
                        return false;
                }

                public ISystemLog DBLogWriter
                {
                        get
                        {
                                return _dbLogwriter;
                        }
                        set
                        {
                                _dbLogwriter = value;
                        }
                }

                #endregion
        }
}
