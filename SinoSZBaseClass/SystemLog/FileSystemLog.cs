using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SinoSZBaseClass.SystemLog
{
        public class FileSystemLog : ISystemLog
        {
                private string logFileName = "SystemLog.log";

                public FileSystemLog() { }
                public FileSystemLog(string _fname)
                {
                        logFileName = _fname;
                }

                #region ISystemLog Members


                public bool WriteLog(string _log, System.Diagnostics.EventLogEntryType _logType)
                {
                        StreamWriter _fs;
                        if (File.Exists(logFileName))
                        {
                                _fs = File.AppendText(logFileName);
                        }
                        else
                        {
                                _fs = File.CreateText(logFileName);
                        }
                        _fs.WriteLine(string.Format("[{2}] {0}:{1}", _logType.ToString(), _log,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                        _fs.Close();
                        return true;
                }

                #endregion
        }
}
