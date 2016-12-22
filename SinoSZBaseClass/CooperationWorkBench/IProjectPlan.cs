using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.CooperationWorkBench
{
	public interface IProjectPlan
	{
		/// <summary>
		/// 创建预警事件记录
		/// </summary>
		bool CreateWarningEvent();

		/// <summary>
		/// 创建超期事件记录
		/// </summary>
		bool CreateOverEvent();

		/// <summary>
		/// 清除预警事件记录
		/// </summary>
		bool ClearWarningEvent();

		/// <summary>
		/// 清除超期事件记录
		/// </summary>
		bool ClearOverEvent();

		/// <summary>
		/// 创建待办事件记录
		/// </summary>
		bool CreateToDoEvent();

		/// <summary>
		/// 清除待办事件记录
		/// </summary>
		bool ClearToDoEvent();
	}
}
