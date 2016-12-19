using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2.Config
{
	[Serializable]
	public class GB_vehicleList
	{
		private string vehicleCustomCode;
		private string foreignNo;
		private string domesticNo;
		private string corpName;
		private string foreignCorp;
		private string quotaCode;
		private string vehicleRic;
		private string statusName;
		private string vehicleMaster;
		private string representative;
		private string warrantorTel;
		private string warrantor;
		private string warrantMode;
		private string isExternal;
		private string isExternalNow;
		private DateTime validityEndDate;
		private string brandCode;
		private string specification;
		private string sortName;
		private string colorCode;
		private string undercarriageNo;
		private string usageName;
		private string engineNo;
		private string deadWeight;
		private string tonnage;
		private string steeringWheel;
		private string oilBox;
		private string startUsingYyyymm;
		private string frontTyre;
		private string backTyre;
		private string standbyTyre;
		private string creator;
		private DateTime createDate;
		private string modifier;
		private DateTime modifyDate;
		private string auditUser;
		private DateTime auditDate;




		/// <summary>
		/// 车辆海关编号
		/// </summary>
		public string VehicleCustomCode { get { return vehicleCustomCode; } set { vehicleCustomCode = value; } }

		/// <summary>
		/// 境外车牌
		/// </summary>
		public string ForeignNo { get { return foreignNo; } set { foreignNo = value; } }

		/// <summary>
		/// 境内车牌
		/// </summary>
		public string DomesticNo { get { return domesticNo; } set { domesticNo = value; } }
		/// <summary>
		/// 内承单位
		/// </summary>
		public string CorpName { get { return corpName; } set { corpName = value; } }
		/// <summary>
		/// 外商商号
		/// </summary>
		public string ForeignCorp { get { return foreignCorp; } set { foreignCorp = value; } }

		/// <summary>
		/// 指标号
		/// </summary>
		public string QuotaCode { get { return quotaCode; } set { quotaCode = value; } }
		/// <summary>
		/// 电子车牌号
		/// </summary>
		public string VehicleRic { get { return vehicleRic; } set { vehicleRic = value; } }

		/// <summary>
		/// 状态
		/// </summary>
		public string StatusName { get { return statusName; } set { statusName = value; } }


		/// <summary>
		/// 车主名称
		/// </summary>
		public string VehicleMaster { get { return vehicleMaster; } set { vehicleMaster = value; } }

		/// <summary>
		/// 内承法人
		/// </summary>
		public string Representative { get { return representative; } set { representative = value; } }
		/// <summary>
		/// 电话
		/// </summary>
		public string WarrantorTel { get { return warrantorTel; } set { warrantorTel = value; } }
		/// <summary>
		/// 担保人
		/// </summary>
		public string Warrantor { get { return warrantor; } set { warrantor = value; } }

		/// <summary>
		/// 担保方式
		/// </summary>
		public string WarrantMode { get { return warrantMode; } set { warrantMode = value; } }

		/// <summary>
		/// 入籍地
		/// </summary>
		public string IsExternal { get { return isExternal; } set { isExternal = value; } }
		/// <summary>
		/// 当前在境内或境外
		/// </summary>
		public string IsExternalNow { get { return isExternalNow; } set { isExternalNow = value; } }

		/// <summary>
		/// 有效期
		/// </summary>
		public DateTime ValidityEndDate { get { return validityEndDate; } set { validityEndDate = value; } }
		/// <summary>
		/// 品牌
		/// </summary>
		public string BrandCode { get { return brandCode; } set { brandCode = value; } }

		/// <summary>
		/// 规格型号
		/// </summary>
		public string Specification { get { return specification; } set { specification = value; } }

		/// <summary>
		/// 分类
		/// </summary>
		public string SortName { get { return sortName; } set { sortName = value; } }

		/// <summary>
		/// 颜色
		/// </summary>
		public string ColorCode { get { return colorCode; } set { colorCode = value; } }

		/// <summary>
		/// 车架号
		/// </summary>
		public string UndercarriageNo { get { return undercarriageNo; } set { undercarriageNo = value; } }

		/// <summary>
		/// 用途
		/// </summary>
		public string UsageName { get { return usageName; } set { usageName = value; } }

		/// <summary>
		/// 发动机号
		/// </summary>
		public string EngineNo { get { return engineNo; } set { engineNo = value; } }
		/// <summary>
		/// 车辆自重_吨
		/// </summary>
		public string DeadWeight { get { return deadWeight; } set { deadWeight = value; } }

		/// <summary>
		/// 吨位_座
		/// </summary>
		public string Tonnage { get { return tonnage; } set { tonnage = value; } }

		/// <summary>
		/// 方向盘
		/// </summary>
		public string SteeringWheel { get { return steeringWheel; } set { steeringWheel = value; } }
		/// <summary>
		/// 油缸容量_升
		/// </summary>
		public string OilBox { get { return oilBox; } set { oilBox = value; } }

		/// <summary>
		/// 启用年份
		/// </summary>
		public string StartUsingYyyymm { get { return startUsingYyyymm; } set { startUsingYyyymm = value; } }
		/// <summary>
		/// 前轮胎
		/// </summary>
		public string FrontTyre { get { return frontTyre; } set { frontTyre = value; } }
		/// <summary>
		/// 后轮胎
		/// </summary>
		public string BackTyre { get { return backTyre; } set { backTyre = value; } }
		/// <summary>
		/// 备胎
		/// </summary>
		public string StandbyTyre { get { return standbyTyre; } set { standbyTyre = value; } }
		/// <summary>
		/// 创建人
		/// </summary>
		public string Creator { get { return creator; } set { creator = value; } }

		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime CreateDate { get { return createDate; } set { createDate = value; } }
		/// <summary>
		/// 修改人
		/// </summary>
		public string Modifier { get { return modifier; } set { modifier = value; } }
		/// <summary>
		/// 修改日期
		/// </summary>
		public DateTime ModifyDate { get { return modifyDate; } set { modifyDate = value; } }
		/// <summary>
		/// 审核人
		/// </summary>
		public string AuditUser { get { return auditUser; } set { auditUser = value; } }
		/// <summary>
		/// 审核日期
		/// </summary>
		public DateTime AuditDate { get { return auditDate; } set { auditDate = value; } }



	}
}
