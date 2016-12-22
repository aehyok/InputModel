using System;
using System.Collections;
using System.Collections.Generic;

namespace SinoSZBaseClass.Authorize
{
	/// <summary>
	/// ��ɫ����
	/// </summary>
	[Serializable()]
	public class SinoRole {
                /// <summary>
                /// ��ɫ����Ȩ�޼���
                /// </summary>
                public List<SinoRightItem> UserRights = new List<SinoRightItem>(); 

                /// <summary>
                /// ��ɫID
                /// </summary>
		public string RoleID = ""; 
                /// <summary>
                /// ��ɫ��
                /// </summary>
		public string RoleName = ""; 
                /// <summary>
                /// ��ɫ����
                /// </summary>
		public string Descript = ""; 
                /// <summary>
                /// ��ɫ���͡��������Ϊ�ձ�ʾȫϵͳͨ�ý�ɫ�����ΪDWID���ʾ�˵�λ�Զ���ɫ
                /// </summary>
		public string RoleDwid = ""; //

		public SinoRole() {
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
	}
}