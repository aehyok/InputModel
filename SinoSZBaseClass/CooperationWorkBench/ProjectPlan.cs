using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.CooperationWorkBench
{
	public class ProjectPlan
	{
		/// <summary>
		/// �ƻ���ʼʱ��
		/// </summary>
		protected DateTime startTime;
		/// <summary>
		/// �ƻ�����ʱ��
		/// </summary>
		protected System.DateTime endTime;
		/// <summary>
		/// ִ����
		/// </summary>
		protected System.DateTime finisedTime;
		protected IProjectPlan ics_ProjectPlan;
		/// <summary>
		/// ��Ӧ������ID
		/// </summary>
		protected string PTID;

		/// <summary>
		/// �ƻ���ʼʱ��
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
		/// �ƻ�����ʱ��
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
		/// �ƻ����ʱ��
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
		/// ����Ԥ���¼���¼
		/// </summary>
		public bool CreateWarningEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.CreateWarningEvent();
			return false;
		}

		/// <summary>
		/// ���������¼���¼
		/// </summary>
		public bool CreateOverEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.CreateOverEvent();
			return false;
		}

		/// <summary>
		/// ���Ԥ���¼���¼
		/// </summary>
		public bool ClearWarningEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.ClearWarningEvent();
			return false;
		}

		/// <summary>
		/// ��������¼���¼
		/// </summary>
		public bool ClearOverEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.ClearOverEvent();
			return false;
		}

		/// <summary>
		/// ���������¼���¼
		/// </summary>
		public bool CreateToDoEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.CreateToDoEvent();
			return false;
		}

		/// <summary>
		/// ��������¼���¼
		/// </summary>
		public bool ClearToDoEvent()
		{
			if (IProjectPlan != null) return IProjectPlan.ClearToDoEvent();
			return false;
		}

		/// <summary>
		/// ȡִ�����б�
		/// </summary>
		public List<ProjectExecutor> GetExecutor()
		{
			return null;
		}
	}
}
