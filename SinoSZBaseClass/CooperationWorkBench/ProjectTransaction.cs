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
		/// 项目类型
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
		/// 创建计划
		/// </summary>
		public bool CreatePlan()
		{
			if (IProjectType == null) return false;
			return IProjectType.CreatePlan();
		}

		/// <summary>
		/// 取指定计划
		/// </summary>
		public ProjectPlan GetPlan(string ID)
		{
			if (IProjectType == null) return null;
			return IProjectType.GetPlan(ID);
		}

		/// <summary>
		/// 清除计划
		/// </summary>
		public bool ClearPlan()
		{
			if (IProjectType == null) return false;
			return IProjectType.ClearPlan();
		}

		/// <summary>
		/// 取计划列表
		/// </summary>
		public List<ProjectPlan> GetAllPlan()
		{
			if (IProjectType == null) return null;
			return IProjectType.GetAllPlan();
		}
	}
}
