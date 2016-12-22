using System;
using System.Collections;
using System.Collections.Generic;

namespace SinoSZBaseClass.Authorize
{
	/// <summary>
	/// 角色定义
	/// </summary>
	[Serializable()]
	public class SinoRole {
                /// <summary>
                /// 角色具有权限集合
                /// </summary>
                public List<SinoRightItem> UserRights = new List<SinoRightItem>(); 

                /// <summary>
                /// 角色ID
                /// </summary>
		public string RoleID = ""; 
                /// <summary>
                /// 角色名
                /// </summary>
		public string RoleName = ""; 
                /// <summary>
                /// 角色描述
                /// </summary>
		public string Descript = ""; 
                /// <summary>
                /// 角色类型　　　如果为空表示全系统通用角色，如果为DWID则表示此单位自定角色
                /// </summary>
		public string RoleDwid = ""; //

		public SinoRole() {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
}