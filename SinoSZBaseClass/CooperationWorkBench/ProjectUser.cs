using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBaseClass.Authorize;

namespace SinoSZBaseClass.CooperationWorkBench
{
	[Serializable]
	public class ProjectExecutor
	{
		/// <summary>
		/// 用户显示姓名
		/// </summary>
		protected string userName;
		/// <summary>
		/// 用户ID
		/// </summary>
		protected string uesrID;
		/// <summary>
		/// 岗位ID
		/// </summary>
		protected string postID;
		/// <summary>
		/// 岗位所在单位ID
		/// </summary>
		protected string postDwID;
		/// <summary>
		/// 岗位所在单位名称
		/// </summary>
		protected string postDWName;
		/// <summary>
		/// 用户登录名
		/// </summary>
		protected string loginName;
		protected Enum_ExecutorType executorType;

		public string UserID
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public string UserName
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public string LoginName
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public string PostID
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public string PostDwID
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public string PostDwName
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public Enum_ExecutorType Enum_ExecutorType
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		internal IProjectExecutor IProjectExecutor
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public virtual SinoUser GetSinoUser()
		{
			throw new System.NotImplementedException();
		}

		public virtual List<ProjectPlan> GetExecutePlans()
		{
			throw new System.NotImplementedException();
		}

		public virtual List<ProjectPlan> GetFinishedPlans()
		{
			throw new System.NotImplementedException();
		}

		public virtual List<ProjectToDo> GetUserToDoList()
		{
			throw new System.NotImplementedException();
		}

		public virtual List<ProjectToDo> GetPostToDoList()
		{
			throw new System.NotImplementedException();
		}

		public virtual List<ProjectToDo> GetUserPostToDoList()
		{
			throw new System.NotImplementedException();
		}
	}
}
