using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChinaCustoms.Applications.HGFM.Entities.Common
{
    [Serializable]    
    public class GoodDealResultInfo
    {
       
        private string _dealUnit;
        /// <summary>
        /// 处置单位
        /// </summary>
               public string DealUnit
        {
            get { return _dealUnit; }
            set { _dealUnit = value; }
        }
        private string _dealWay;
        /// <summary>
        /// 处置方式只能有一个。
        /// </summary>        
        public string DealWay
        {
            get { return _dealWay; }
            set { _dealWay = value; }
        }

        private Guid _vouListID;
        /// <summary>
        /// 主键标识
        /// </summary>        
        public Guid VouListID
        {
            get { return _vouListID; }
            set { _vouListID = value; }
        }

        private Guid _disposeID;
        /// <summary>
        /// 文书审核的ID
        /// </summary>
                public Guid DisposeID
        {
            get { return _disposeID; }
            set { _disposeID = value; }
        }

        private Guid _goodsID;
        /// <summary>
        /// 商品的ID
        /// </summary>       
        public Guid GoodsID
        {
            get { return _goodsID; }
            set { _goodsID = value; }
        }

        private string _goodsName;
        /// <summary>
        /// 商品名称
        /// </summary>       
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        private Guid _inFormID;
        /// <summary>
        /// 入库ID
        /// </summary>       
        public Guid InFormID
        {
            get { return _inFormID; }
            set { _inFormID = value; }
        }

        private string _inFormNo;
        /// <summary>
        /// 入库单号
        /// </summary>        
        public string InFormNo
        {
            get { return _inFormNo; }
            set { _inFormNo = value; }
        }

        private Guid _vouID;
        /// <summary>
        /// 凭证ID
        /// </summary>        
        public Guid VouID
        {
            get { return _vouID; }
            set { _vouID = value; }
        }

        private string _vouNo;
        /// <summary>
        /// 凭证单号
        /// </summary>        
        public string VouNo
        {
            get { return _vouNo; }
            set { _vouNo = value; }
        }

        private decimal _goodsQty;
        /// <summary>
        /// 商品的数量(重量)
        /// </summary>        
        public decimal GoodsQty
        {
            get { return _goodsQty; }
            set { _goodsQty = value; }
        }

        private decimal _reservePrice;
        /// <summary>
        /// 保留价
        /// </summary>        
        public decimal ReservePrice
        {
            get { return _reservePrice; }
            set { _reservePrice = value; }
        }

        private decimal _evaluatePrice;
        /// <summary>
        /// 评估价
        /// </summary>        
        public decimal EvaluatePrice
        {
            get { return _evaluatePrice; }
            set { _evaluatePrice = value; }
        }

        private bool _deleteFlag;
        /// <summary>
        /// 是否删除
        /// </summary>
                public bool DeleteFlag
        {
            get { return _deleteFlag; }
            set { _deleteFlag = value; }
        }

        private decimal _dealPrice;
        /// <summary>
        /// 成交价
        /// </summary>       
        public decimal DealPrice
        {
            get { return _dealPrice; }
            set { _dealPrice = value; }
        }

        private DateTime _operTime;
        /// <summary>
        /// 生成凭证时间
        /// </summary>        
        public DateTime OperTime
        {
            get { return _operTime; }
            set { _operTime = value; }
        }

        private string _operID;
        /// <summary>
        /// 用户ID
        /// </summary>        
        public string OperID
        {
            get { return _operID; }
            set { _operID = value; }
        }

        private string _operName;
        /// <summary>
        /// 用户名
        /// </summary>        
        public string OperName
        {
            get { return _operName; }
            set { _operName = value; }
        }
        private string _note;
        /// <summary>
        /// 备注
        /// </summary>        
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        private int _status;
        /// <summary>
        /// 状态  0:处置中,1:处置完成,2:出库成功,3:出库失败
        /// </summary>        
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int? _disStatus;
        /// <summary>
        /// 状态  0：未成交；1：已成交，未出库；2：已办理出库，待变价款审核；3：变价款已审核，待生成出库清单
        /// </summary>        
        public int? DisStatus
        {
            get { return _disStatus; }
            set { _disStatus = value; }
        }
    }
}
