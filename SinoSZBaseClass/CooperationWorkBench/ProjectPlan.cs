using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.CooperationWorkBench
{
	public class ProjectPlan
	{
		/// <summary>
		/// 计划开始时间
		/// </summary>
		protected DateTime startTime;
		/// <summary>
		/// 计划结束时间
		/// </summary>
		protected System.DateTime endTime;
		/// <summary>
		/// 执行人
		/// </summary>
		protected System.DateTime finisedTime;
		protected IProjectPlan ics_ProjectPlan;
		/// <summary>
		/// 对应用任务ID
		/// </summary>
		protected string PTID;

		/// <summary>
		/// 计划开始时间
		/// </summary>
		public object StartTime
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		/// <summary>
		/// 计划结束时间
		/// </summary>
		public object EndTime
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		/// <summary>
		/// 计划完成时间
		/// </summary>
		public object FinishedTime
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public IProjectPlan IProjectPlan
		{
			get
			{
				return ics_ProjectPlan;
			}
			set
			{
				ics_ProjectPlan = value;
			}
		}

		public ProjectTransaction ProjectTransaction
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		/// <summary>
		/// 创建预警事件记录
		/// </summary>
		public bool CreateWarningEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.CreateWarningEvent();
			return false;
		}

		/// <summary>
		/// 创建超期事件记录
		/// </summary>
		public bool CreateOverEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.CreateOverEvent();
			return false;
		}

		/// <summary>
		/// 清除预警事件记录
		/// </summary>
		public bool ClearWarningEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.ClearWarningEvent();
			return false;
		}

		/// <summary>
		/// 清除超期事件记录
		/// </summary>
		public bool ClearOverEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.ClearOverEvent();
			return false;
		}

		/// <summary>
		/// 创建待办事件记录
		/// </summary>
		public bool CreateToDoEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.CreateToDoEvent();
			return false;
		}

		/// <summary>
		/// 清除待办事件记录
		/// </summary>
		public bool ClearToDoEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.ClearToDoEvent();
			return false;
		}

		/// <summary>
		/// 取执行人列表
		/// </summary>
		public List<ProjectExecutor> GetExecutor()
		{
			return null;
		}
	}
}
