using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.CooperationWorkBench
{
	public class ProjectType
	{
		protected string projectName;
		protected ProjectType fatherProject;
		protected string id;
		protected string descript;

		/// <summary>
		/// 项目类型
		/// </summary>
		public string ProjectedName
		{
			get
			{
				return projectName;
			}
			set
			{
				ProjectedName = value;
			}
		}

		/// <summary>
		/// 父类型
		/// </summary>
		public ProjectType FatherProject
		{
			get
			{
				return this.fatherProject;
			}
			set
			{
				this.fatherProject = value;
			}
		}

		/// <summary>
		/// ID
		/// </summary>
		public string ID
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}

		/// <summary>
		/// 描述
		/// </summary>
		public string Descript
		{
			get
			{
				return this.descript;
			}
			set
			{
				this.descript = value;
			}
		}
	}
}
