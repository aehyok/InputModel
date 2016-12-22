using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.CooperationWorkBench
{
	public interface IProjectPlan
	{
		/// <summary>
		/// ����Ԥ���¼���¼
		/// </summary>
		bool CreateWarningEvent();

		/// <summary>
		/// ���������¼���¼
		/// </summary>
		bool CreateOverEvent();

		/// <summary>
		/// ���Ԥ���¼���¼
		/// </summary>
		bool ClearWarningEvent();

		/// <summary>
		/// ��������¼���¼
		/// </summary>
		bool ClearOverEvent();

		/// <summary>
		/// ���������¼���¼
		/// </summary>
		bool CreateToDoEvent();

		/// <summary>
		/// ��������¼���¼
		/// </summary>
		bool ClearToDoEvent();
	}
}
