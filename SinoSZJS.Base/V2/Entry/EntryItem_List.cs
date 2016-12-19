using System;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Entry
{
    [Serializable]
    public class EntryItem_List
    {
        protected string id = "";
        protected string entry_id = "";					//报关单编号
        protected string g_no = "";					//商品序号
        protected string code_ts = "";					//商品编码
        protected string g_name = "";					//商品名称
        protected string g_model = "";				//商品规格、型号
        protected string origin_country = "";			//产销国
        protected string trade_curr = "";				//成交币制
        protected decimal exchange_rate = 0;			//成交币制汇率
        protected decimal decl_price = 0;				//申报单价
        protected decimal decl_total = 0;				//申报总价
        protected string duty_mode = "";				//征减免税方式
        protected decimal g_qty = 0;					//申报数量
        protected string g_unit = "";					//申报计量单位
        protected string g_unit_title = "";				//申报计量单位显示名称
        protected decimal qty_1 = 0;					//第一（法定）数量
        protected string unit_1 = "";					//第一(法定)计量单位
        protected string unit_1_title = "";				//第一(法定)计量单位显示名称
        protected decimal trade_total = 0;				//成交总价
        protected decimal rmb_price = 0;				//统计人民币价
        protected decimal usd_price = 0;				//统计美元价
        protected decimal duty_value = 0;				//关税完税价
        protected bool selected = false;

        public EntryItem_List() { }
        [DataMember]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        /// <summary>
        /// 报关单编号
        /// </summary>
        /// 
        [DataMember]
        public string Entry_ID
        {
            get { return entry_id; }
            set { entry_id = value; }
        }
        /// <summary>
        /// 商品序号
        /// </summary>
        /// 
        [DataMember]
        public string G_NO
        {
            get { return g_no; }
            set { g_no = value; }
        }
        /// <summary>
        /// 商品编码
        /// </summary>
        /// 
        [DataMember]
        public string Code_Ts
        {
            get { return code_ts; }
            set { code_ts = value; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        /// 
        [DataMember]
        public string G_Name
        {
            get { return g_name; }
            set { g_name = value; }
        }
        /// <summary>
        /// 商品规格、型号
        /// </summary>
        /// 
        [DataMember]
        public string G_Model
        {
            get { return g_model; }
            set { g_model = value; }
        }
        /// <summary>
        /// 产销国
        /// </summary>
        /// 
        [DataMember]
        public string Origin_Country
        {
            get { return origin_country; }
            set { origin_country = value; }
        }

        /// <summary>
        /// 关税完税价
        /// </summary>
        /// 
        [DataMember]
        public decimal Duty_Value
        {
            get { return duty_value; }
            set { duty_value = value; }
        }
        /// <summary>
        /// 统计美元价
        /// </summary>
        /// 
        [DataMember]
        public decimal Usd_Price
        {
            get { return usd_price; }
            set { usd_price = value; }
        }

        /// <summary>
        /// 统计人民币价
        /// </summary>
        /// 
        [DataMember]
        public decimal Rmb_Price
        {
            get { return rmb_price; }
            set { rmb_price = value; }
        }
        /// <summary>
        /// 成交总价
        /// </summary>
        /// 
        [DataMember]
        public decimal Trade_Total
        {
            get { return trade_total; }
            set { trade_total = value; }
        }

        /// <summary>
        /// 第一(法定)计量单位
        /// </summary>
        /// 
        [DataMember]
        public string Unit_1
        {
            get { return unit_1; }
            set { unit_1 = value; }
        }

        /// <summary>
        /// 第一(法定)计量单位显示名称
        /// </summary>
        /// 
        [DataMember]
        public string Unit_1_Title
        {
            get { return unit_1_title; }
            set { unit_1_title = value; }
        }

        /// <summary>
        /// 第一（法定）数量
        /// </summary>
        /// 
        [DataMember]
        public decimal Qty_1
        {
            get { return qty_1; }
            set { qty_1 = value; }
        }

        /// <summary>
        /// 申报计量单位
        /// </summary>
        /// 
        [DataMember]
        public string G_Unit
        {
            get { return g_unit; }
            set { g_unit = value; }
        }


        /// <summary>
        /// 申报计量单位显示名称
        /// </summary>
        /// 
        [DataMember]
        public string G_Unit_Title
        {
            get { return g_unit_title; }
            set { g_unit_title = value; }
        }

        /// <summary>
        /// 申报数量
        /// </summary>
        /// 
        [DataMember]
        public decimal G_Qty
        {
            get { return g_qty; }
            set { g_qty = value; }
        }
        /// <summary>
        /// 征减免税方式
        /// </summary>
        /// 
        [DataMember]
        public string Duty_Mode
        {
            get { return duty_mode; }
            set { duty_mode = value; }
        }
        /// <summary>
        /// 申报总价
        /// </summary>
        /// 
        [DataMember]
        public decimal Decl_Total
        {
            get { return decl_total; }
            set { decl_total = value; }
        }
        /// <summary>
        /// 申报单价
        /// </summary>
        /// 
        [DataMember]
        public decimal Decl_Price
        {
            get { return decl_price; }
            set { decl_price = value; }
        }


        /// <summary>
        /// 成交币制汇率
        /// </summary>
        /// 
        [DataMember]
        public decimal Exchange_Rate
        {
            get { return exchange_rate; }
            set { exchange_rate = value; }
        }
        /// <summary>
        /// 成交币制
        /// </summary>
        /// 
        [DataMember]
        public string Trade_Curr
        {
            get { return trade_curr; }
            set { trade_curr = value; }
        }


    }
}
