using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.CooperationWorkBench
{
	public class ProjectTransaction
	{
		protected string id;
		protected IProjectType ics_ProjectType;
		protected ProjectType projectType ;
		/// <summary>
		/// ��Ŀ����
		/// </summary>
		public ProjectType ProjectType
		{
			get
			{
				return projectType;
			}
			set
			{
				projectType = value;
			}
		}

		public string ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		protected IProjectType IProjectType
		{
			get
			{
				return ics_ProjectType;
			}
			set
			{
				ics_ProjectType = value;
			}
		}


		#region IProjectType Members

		public ProjectType GetProjectType()
		{
			if (IProjectType == null) return null;
			return IProjectType.GetProjectType();
		}

		#endregion

		/// <summary>
		/// �����ƻ�
		/// </summary>
		public bool CreatePlan()
		{
			if (IProjectType == null) return false;
			return IProjectType.CreatePlan();
		}

		/// <summary>
		/// ȡָ���ƻ�
		/// </summary>
		public ProjectPlan GetPlan(string ID)
		{
			if (IProjectType == null) return null;
			return IProjectType.GetPlan(ID);
		}

		/// <summary>
		/// ����ƻ�
		/// </summary>
		public bool ClearPlan()
		{
			if (IProjectType == null) return false;
			return IProjectType.ClearPlan();
		}

		/// <summary>
		/// ȡ�ƻ��б�
		/// </summary>
		public List<ProjectPlan> GetAllPlan()
		{
			if (IProjectType == null) return null;
			return IProjectType.GetAllPlan();
		}
	}
}
