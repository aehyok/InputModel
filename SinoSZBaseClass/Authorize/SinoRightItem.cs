using System;
using System.Collections;

namespace SinoSZBaseClass.Authorize
{
	/// <summary>
	/// SinoRightItem ָһ��Ȩ�޶������ID,���Ƽ���ض���
	/// </summary>
	/// 
	[Serializable()]
	public class SinoRightItem {
                /// <summary>
                /// Ȩ��ID
                /// </summary>
		public string RightID = "";		
                /// <summary>
                /// ��Ȩ��ID
                /// </summary>
		public string FatherRightID = "";	
                /// <summary>
                /// Ȩ������
                /// </summary>
		public string RightName = "";		
                /// <summary>
                /// Ȩ������
                /// </summary>
		public string RightDescript = "";	
                /// <summary>
                /// Ȩ�����͡������̶����ͻ�̬����
                /// </summary>
		public string RightType = "";
                /// <summary>
                /// Ȩ�޵�META
                /// </summary>
                public string RightMeta = "";
                /// <summary>
                /// ��Ӧ�Ĳ˵�ID
                /// </summary>
                public string MenuID = "";
                /// <summary>
                /// Ȩ�޿��ܵļ�����
                /// </summary>
		public ArrayList RightLevels = new ArrayList(); 

		public SinoRightItem() {
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}


	}

	/// <summary>
	/// Ȩ�޼���Ķ���
	/// </summary>
	[Serializable()]
	public class RightLevelName {
                /// <summary>
                /// ����
                /// </summary>
		public decimal Index = 0;
                /// <summary>
                /// ������ʾ
                /// </summary>
		public string DisplayText = "";
		public RightLevelName() {}
	}
}