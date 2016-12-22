using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.CooperationWorkBench
{
	public class ProjectToDo
	{
		protected string planID;
		protected ProjectExecutor projectExecutor;
		protected DateTime createTime;
		protected Enum_ToDoStatus status;
		private DateTime finishedTime;

		public ProjectPlan ProjectPlan
		{
			get
			{
				return GetProjectPlan(planID);
			}
			set
			{
			}
		}

		internal ProjectExecutor ProjectExecutor
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public Enum_ToDoStatus Status
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public object FinishedTime
		{
			get
			{
				if (Status == Enum_ToDoStatus.Finished) return this.finishedTime;
				return null;
			}
			set
			{
				this.finishedTime = (DateTime) value;
				Status = Enum_ToDoStatus.Finished;
			}
		}

		internal IProjectToDo IProjectToDo
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public bool FinishToDo()
		{
			throw new System.NotImplementedException();
		}

		public ProjectPlan GetProjectPlan(string _planID)
		{
			throw new System.NotImplementedException();
		}
	}
}
