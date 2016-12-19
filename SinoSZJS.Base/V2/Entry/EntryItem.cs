using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Entry
{
	[Serializable]
	public class EntryItem
	{
		protected string id = "";
		protected string entry_id = "";				//报关单编号
		protected string pre_entry_id = "";			//预录入号码
		protected string i_e_flag = "";				//进出口标志
		protected string i_e_port = "";				//进出口岸代码
		protected string i_e_date = "";				//进出口日期
		protected string d_date = "";				//申报日期
		protected string destination_port = "";		//指运港(抵运港)
		protected string traf_name = "";			//运输工具名称
		protected string voyage_no = "";			//运输工具航次(班)号
		protected string traf_mode = "";			//运输方式代码
		protected string bill_no = "";				//提运单号码
		protected string trade_country = "";		//贸易国别（起/抵运地）
		protected string trade_mode = "";			//监管方式
		protected string cut_mode = "";			//征免性质分类
		protected decimal container_no = 0;		//集装箱标准箱数
		protected decimal pack_no = 0;			//件数
		protected decimal gross_wt = 0;			//毛重
		protected decimal net_wt = 0;				//净重
		protected string manal_no = "";			//手册号码
		protected string license_no = "";			//许可证编号
		protected string decl_port = "";			//申报口岸代码
		protected string co_owner = "";			//经营单位性质
		protected string edi_id = "";				//申报方式标志
		protected string declare_no = "";			//报关员代码
		protected string entry_type = "";			//报关单类型

		protected List<EntryItem_Company> companys = new List<EntryItem_Company>();
		protected List<EntryItem_List> goods = new List<EntryItem_List>();
		protected List<EntryItem_Certificate> certificates = new List<EntryItem_Certificate>();
		protected List<EntryItem_RSK_INSTR> rsk_INSTRList = new List<EntryItem_RSK_INSTR>();

         [DataMember]
        public List<EntryItem_Company> Companys
		{
			get { return companys; }
			set { companys = value; }
		}
		/// <summary>
		/// 手册号码
		/// </summary>
        [DataMember]
		public string Manal_No
		{
			get { return manal_no; }
			set { manal_no = value; }
		}
		/// <summary>
		/// 许可证编号
		/// </summary>
         [DataMember]
        public string License_No
		{
			get { return license_no; }
			set { license_no = value; }
		}
         [DataMember]
		public List<EntryItem_List> Goods
		{
			get { return goods; }
			set { goods = value; }
		}
         [DataMember]
		public List<EntryItem_RSK_INSTR> RSK_INSTRList
		{
			get { return rsk_INSTRList; }
			set { rsk_INSTRList = value; }
		}
         [DataMember]
		public List<EntryItem_Certificate> Certificates
		{
			get { return certificates; }
			set { certificates = value; }
		}
         [DataMember]
		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <summary>
		/// 报关单类型
		/// </summary>
         [DataMember]
        public string Entry_Type
		{
			get { return entry_type; }
			set { entry_type = value; }
		}
		/// <summary>
		/// 报关员代码
		/// </summary>
         [DataMember]
        public string Declare_No
		{
			get { return declare_no; }
			set { declare_no = value; }
		}
		/// <summary>
		/// 申报方式标志
		/// </summary>
         [DataMember]
        public string Edi_Id
		{
			get { return edi_id; }
			set { edi_id = value; }
		}
		/// <summary>
		/// 经营单位性质
		/// </summary>
         [DataMember]
        public string Co_Owner
		{
			get { return co_owner; }
			set { co_owner = value; }
		}

		/// <summary>
		/// 申报口岸代码
		/// </summary>
         [DataMember]
        public string Decl_Port
		{
			get { return decl_port; }
			set { decl_port = value; }
		}

		/// <summary>
		/// 净重
		/// </summary>
         [DataMember]
        public decimal Net_Wt
		{
			get { return net_wt; }
			set { net_wt = value; }
		}
		/// <summary>
		/// 毛重
		/// </summary>
         [DataMember]
        public decimal Gross_Wt
		{
			get { return gross_wt; }
			set { gross_wt = value; }
		}
		/// <summary>
		/// 件数
		/// </summary>
         [DataMember]
        public decimal Pack_No
		{
			get { return pack_no; }
			set { pack_no = value; }
		}
		/// <summary>
		/// 集装箱标准箱数
		/// </summary>
         [DataMember]
        public decimal Container_No
		{
			get { return container_no; }
			set { container_no = value; }
		}

		/// <summary>
		/// 征免性质分类
		/// </summary>
         [DataMember]
        public string Cut_Mode
		{
			get { return cut_mode; }
			set { cut_mode = value; }
		}

		/// <summary>
		/// 监管方式
		/// </summary>
         [DataMember]
        public string Trade_Mode
		{
			get { return trade_mode; }
			set { trade_mode = value; }
		}
		/// <summary>
		/// 贸易国别（起/抵运地）
		/// </summary>
         [DataMember]
        public string Trade_Country
		{
			get { return trade_country; }
			set { trade_country = value; }
		}

		/// <summary>
		/// 提运单号码
		/// </summary>
         [DataMember]
        public string Bill_No
		{
			get { return bill_no; }
			set { bill_no = value; }
		}
		/// <summary>
		/// 运输方式代码
		/// </summary>
         [DataMember]
        public string Traf_Mode
		{
			get { return traf_mode; }
			set { traf_mode = value; }
		}
		/// <summary>
		/// 运输工具航次(班)号
		/// </summary>
         [DataMember]
        public string Voyage_No
		{
			get { return voyage_no; }
			set { voyage_no = value; }
		}
		/// <summary>
		/// 运输工具名称
		/// </summary>
         [DataMember]
        public string Traf_Name
		{
			get { return traf_name; }
			set { traf_name = value; }
		}

		/// <summary>
		/// 指运港(抵运港)
		/// </summary>
         [DataMember]
        public string Destination_Port
		{
			get { return destination_port; }
			set { destination_port = value; }
		}

		/// <summary>
		/// 申报日期
		/// </summary>
         [DataMember]
        public string D_Date
		{
			get { return d_date; }
			set { d_date = value; }
		}

		/// <summary>
		/// 进出口日期
		/// </summary>
         [DataMember]
        public string I_E_Date
		{
			get { return i_e_date; }
			set { i_e_date = value; }
		}

		/// <summary>
		/// 进出口岸代码
		/// </summary>
         [DataMember]
        public string I_E_Port
		{
			get { return i_e_port; }
			set { i_e_port = value; }
		}

		/// <summary>
		/// 进出口标志
		/// </summary>
         [DataMember]
        public string I_E_Flag
		{
			get { return i_e_flag; }
			set { i_e_flag = value; }
		}

		/// <summary>
		/// 预录入号码
		/// </summary>
         [DataMember]
        public string Pre_Entry_Id
		{
			get { return pre_entry_id; }
			set { pre_entry_id = value; }
		}

		/// <summary>
		/// 报关单编号
		/// </summary>
         [DataMember]
        public string EntryID
		{
			get { return entry_id; }
			set { entry_id = value; }
		}

		public EntryItem() { }
	}
}
