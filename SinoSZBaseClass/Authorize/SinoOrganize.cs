using System;

namespace SinoSZBaseClass.Authorize
{
	/// <summary>
	/// SinoOrganize 的摘要说明。
	/// 单位组织机构
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

		//是否可选
		public bool CanSeleceted
		{
			get { return canSelected; }
			set { canSelected = value; }
		}

		/// <summary>
		/// 显示顺序
		/// </summary>
		public int DisplayOrder
		{
			get { return displayOrder; }
			set { displayOrder = value; }
		}

		/// <summary>
		/// 单位ID码
		/// </summary>
		public decimal Code
		{
			get { return code; }
			set { code = value; }
		}
		/// <summary>
		/// 父单位ID码
		/// </summary>
		public decimal FatherCode
		{
			get { return fatherCode; }
			set { fatherCode = value; }
		}
		/// <summary>
		/// 单位名称
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		/// <summary>
		/// 单位全称
		/// </summary>
		public string FullName
		{
			get { return fullName; }
			set { fullName = value; }
		}
		/// <summary>
		/// 单位性质　(职能处室\隶属关处)
		/// </summary>
		public string Function
		{
			get { return function; }
			set { function = value; }
		}

		/// <summary>
		/// 单位代码
		/// </summary>
		public string DWDM
		{
			get { return dwdm; }
			set { dwdm = value; }
		}

		public SinoOrganize()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
