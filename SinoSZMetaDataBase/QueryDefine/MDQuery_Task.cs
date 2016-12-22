using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.QueryDefine
{
        [Serializable]
        public class MDQuery_Task
        {
                private string taskID = "";
                private string taskName = "";
                private DateTime requestTime = DateTime.MinValue;
                private DateTime outTime = DateTime.MinValue;
                private int priority = 0;
                private int taskState = 0;
                private DateTime? finishedTime = null;
                private string requestUserID = "";
                private string requestUserName = "";
                private string requestPostID = "";
                private string requestPostName = "";
                private string requestPostDWName = "";
                private string requestPostDWID = "";
                private DateTime clearTime = DateTime.MinValue;
                private bool resultLocked = false;
                private string taskType = "";

                public MDQuery_Task(string _tid, string _tname, DateTime _requestTime, DateTime _outTime, int _priority, int _taskState,
                        DateTime? _finishedTime, string _userid, string _userName, string _postid, string _postName, string _postDwName,
                        bool _lock,DateTime _clearTime, string _taskType)
                {
                        taskID = _tid;
                        taskName = _tname;
                        requestTime = _requestTime;
                        outTime = _outTime;
                        priority = _priority;
                        taskState = _taskState;
                        finishedTime = _finishedTime;
                        requestUserID = _userid;
                        requestUserName = _userName;
                        requestPostID = _postid;
                        requestPostName = _postName;
                        requestPostDWName = _postDwName;
                        clearTime = _clearTime;
                        taskType = _taskType;
                        resultLocked = _lock;
                }

                public bool ResultLocked
                {
                        get { return resultLocked; }
                        set { resultLocked = value; }
                }

                public string TaskType
                {
                        get { return taskType; }
                        set { taskType = value; }
                }

                public DateTime ClearTime
                {
                        get { return clearTime; }
                        set { clearTime = value; }
                }

                public string RequestPostID
                {
                        get { return requestPostID; }
                        set { requestPostID = value; }
                }

                public string RequestPostDwName
                {
                        get { return requestPostDWName; }
                        set { requestPostDWName = value; }
                }
                public string RequestPostDWID
                {
                        get { return requestPostDWID; }
                        set { requestPostDWID = value; }
                }


                public string RequestPostName
                {
                        get { return requestPostID; }
                        set { requestPostID = value; }
                }

                public int TaskState
                {
                        get { return taskState; }
                        set { taskState = value; }
                }

                public DateTime? FinishedTime
                {
                        get { return finishedTime; }
                        set { finishedTime = value; }
                }

                public string RequestUserID
                {
                        get { return requestUserID; }
                        set { requestUserID = value; }
                }

                public string RequestUserName
                {
                        get { return requestUserName; }
                        set { requestUserName = value; }
                }
                public string TaskID
                {
                        get { return taskID; }
                        set { taskID = value; }
                }

                public string TaskName
                {
                        get { return taskName; }
                        set { taskName = value; }
                }

                public DateTime RequestTime
                {
                        get { return requestTime; }
                        set { requestTime = value; }
                }

                public DateTime OutTime
                {
                        get { return outTime; }
                        set { outTime = value; }
                }

                public int Priority
                {
                        get { return priority; }
                        set { priority = value; }
                }

                public string PostName
                {
                        get { return string.Format("{0}[{1}]", requestPostName, RequestPostDwName); }
                        set
                        {
                        }
                }
        }
}
