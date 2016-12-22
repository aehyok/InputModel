using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.CooperationWorkBench
{
	public interface IProjectType
	{

		/// <summary>
		/// 取一个项目类型
		/// </summary>
		ProjectType GetProjectType();

		bool ClearPlan();

		bool CreatePlan();

		/// <summary>
		/// 取指定计划
		/// </summary>
		/// <param name="id">ID</param>
		ProjectPlan GetPlan(string id);

		/// <summary>
		/// 取全部计划列表
		/// </summary>
		List<ProjectPlan> GetAllPlan();
	}
}
