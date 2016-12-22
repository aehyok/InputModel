using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.CooperationWorkBench
{
	public interface IProjectType
	{

		/// <summary>
		/// ȡһ����Ŀ����
		/// </summary>
		ProjectType GetProjectType();

		bool ClearPlan();

		bool CreatePlan();

		/// <summary>
		/// ȡָ���ƻ�
		/// </summary>
		/// <param name="id">ID</param>
		ProjectPlan GetPlan(string id);

		/// <summary>
		/// ȡȫ���ƻ��б�
		/// </summary>
		List<ProjectPlan> GetAllPlan();
	}
}
