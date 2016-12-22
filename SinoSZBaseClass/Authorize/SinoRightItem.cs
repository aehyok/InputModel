using System;
using System.Collections;

namespace SinoSZBaseClass.Authorize
{
	/// <summary>
	/// SinoRightItem 指一个权限定义项的ID,名称及相关定义
	/// </summary>
	/// 
	[Serializable()]
	public class SinoRightItem {
                /// <summary>
                /// 权限ID
                /// </summary>
		public string RightID = "";		
                /// <summary>
                /// 父权限ID
                /// </summary>
		public string FatherRightID = "";	
                /// <summary>
                /// 权限名称
                /// </summary>
		public string RightName = "";		
                /// <summary>
                /// 权限描述
                /// </summary>
		public string RightDescript = "";	
                /// <summary>
                /// 权限类型　　　固定类型或动态类型
                /// </summary>
		public string RightType = "";
                /// <summary>
                /// 权限的META
                /// </summary>
                public string RightMeta = "";
                /// <summary>
                /// 对应的菜单ID
                /// </summary>
                public string MenuID = "";
                /// <summary>
                /// 权限可能的级别定义
                /// </summary>
		public ArrayList RightLevels = new ArrayList(); 

		public SinoRightItem() {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


	}

	/// <summary>
	/// 权限级别的定义
	/// </summary>
	[Serializable()]
	public class RightLevelName {
                /// <summary>
                /// 级别
                /// </summary>
		public decimal Index = 0;
                /// <summary>
                /// 级别显示
                /// </summary>
		public string DisplayText = "";
		public RightLevelName() {}
	}
}