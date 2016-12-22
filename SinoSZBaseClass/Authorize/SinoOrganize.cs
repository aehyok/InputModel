using System;

namespace SinoSZBaseClass.Authorize
{
	/// <summary>
	/// SinoOrganize ��ժҪ˵����
	/// ��λ��֯����
	/// 2006-11-4
	/// </summary>        
	[Serializable]
	public class SinoOrganize
	{
		private decimal code = -1;
		private decimal fatherCode = -1;
		private string name = "";
		private string fullName = "";
		private string function = "";
		private string dwdm = "";
		private int displayOrder = 0;
		private bool canSelected = true;

		//�Ƿ��ѡ
		public bool CanSeleceted
		{
			get { return canSelected; }
			set { canSelected = value; }
		}

		/// <summary>
		/// ��ʾ˳��
		/// </summary>
		public int DisplayOrder
		{
			get { return displayOrder; }
			set { displayOrder = value; }
		}

		/// <summary>
		/// ��λID��
		/// </summary>
		public decimal Code
		{
			get { return code; }
			set { code = value; }
		}
		/// <summary>
		/// ����λID��
		/// </summary>
		public decimal FatherCode
		{
			get { return fatherCode; }
			set { fatherCode = value; }
		}
		/// <summary>
		/// ��λ����
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		/// <summary>
		/// ��λȫ��
		/// </summary>
		public string FullName
		{
			get { return fullName; }
			set { fullName = value; }
		}
		/// <summary>
		/// ��λ���ʡ�(ְ�ܴ���\�����ش�)
		/// </summary>
		public string Function
		{
			get { return function; }
			set { function = value; }
		}

		/// <summary>
		/// ��λ����
		/// </summary>
		public string DWDM
		{
			get { return dwdm; }
			set { dwdm = value; }
		}

		public SinoOrganize()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public SinoOrganize(decimal _code, decimal _fatherCode, string _dwdm, string _name, string _fullName, string _function, int _order)
		{
			this.code = _code;
			this.dwdm = _dwdm;
			this.fatherCode = _fatherCode;
			this.name = _name;
			this.fullName = _fullName;
			this.function = _function;
			this.displayOrder = _order;
		}

		public SinoOrganize(decimal _code, decimal _fatherCode, string _dwdm, string _name, string _fullName, string _function, int _order, bool _canSelected)
		{
			this.code = _code;
			this.dwdm = _dwdm;
			this.fatherCode = _fatherCode;
			this.name = _name;
			this.fullName = _fullName;
			this.function = _function;
			this.displayOrder = _order;
			this.canSelected = _canSelected;
		}
	}
}
