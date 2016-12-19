using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2.Config
{
	[Serializable]
	public class GB_vehicleIOList
	{
		private string ioId;
		private string vehicleCustomCode;
		private string foreignNo;
		private string domesticNo;
		private string channelName;
		private string portCode;
		private DateTime validityEndDate;
		private string driverCustomCode;
		private string driverName;
		private string sortName;
		private string brandCode;
		private string colorCode;
		private string ioType;
		private DateTime ioDate;

		/// <summary>
		/// 进出境编号
		/// </summary>
		public string IoId { get { return ioId; } set { ioId = value; } }

		/// <summa车辆海关编号ry>
		/// 
		/// </summary>
		public string VehicleCustomCode { get { return vehicleCustomCode; } set { vehicleCustomCode = value; } }

		/// <summary>
		/// foreignNo	境外车牌
		/// </summary>
		public string ForeignNo { get { return foreignNo; } set { foreignNo = value; } }

		/// <summary>
		/// 境内车牌
		/// </summary>
		public string DomesticNo { get { return domesticNo; } set { domesticNo = value; } }

		/// <summary>
		/// 通道编号
		/// </summary>
		public string ChannelName { get { return channelName; } set { channelName = value; } }

		/// <summary>
		/// 口岸
		/// </summary>
		public string PortCode { get { return portCode; } set { portCode = value; } }

		/// <summary>
		/// 有效期
		/// </summary>
		public DateTime ValidityEndDate { get { return validityEndDate; } set { validityEndDate = value; } }

		/// <summary>
		/// 司机编号
		/// </summary>
		public string DriverCustomCode { get { return driverCustomCode; } set { driverCustomCode = value; } }

		/// <summary>
		/// 司机姓名
		/// </summary>
		public string DriverName { get { return driverName; } set { driverName = value; } }

		/// <summary>
		/// 车辆分类
		/// </summary>
		public string SortName { get { return sortName; } set { sortName = value; } }

		/// <summary>
		/// 品牌
		/// </summary>
		public string BrandCode { get { return brandCode; } set { brandCode = value; } }

		/// <summary>
		/// 颜色
		/// </summary>
		public string ColorCode { get { return colorCode; } set { colorCode = value; } }

		/// <summary>
		/// 出入境
		/// </summary>
		public string IoType { get { return ioType; } set { ioType = value; } }

		/// <summary>
		/// 过境时间
		/// </summary>
		public DateTime IoDate { get { return ioDate; } set { ioDate = value; } }


	}
}
