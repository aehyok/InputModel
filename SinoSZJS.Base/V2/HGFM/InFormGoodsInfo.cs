/****************************************************************************************************
 * Description:  入库单物品实体类
 * Created By: 王平
 * Created Time: 2013-4-2
 * Modify Mark:
 * Modified By: 
 * Modify Description: 
 * *************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
namespace ChinaCustoms.Applications.HGFM.Entities.InForm
{
    [Serializable]
    [DataContract]
    [XmlRoot("IN_FORM_GOODS")]    
    public class InFormGoodsInfo
    {
        public InFormGoodsInfo()
        { }

        #region 属性
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "IN_FORM_GOODS_ID")]        
        public Guid INFormGoodsId
        {
            get { return _inFormGoodsId; }
            set { _inFormGoodsId = value; }
        }
        private Guid _inFormGoodsId;

        /// <summary>
        /// IN_FORM_ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "IN_FORM_ID")]        
        public Guid INFormId
        {
            get { return _inFormId; }
            set { _inFormId = value; }
        }
        private Guid _inFormId;

        /// <summary>
        /// 商品分类
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GOODS_TYPE")]        
        public string GoodsType
        {
            get { return _goodsType; }
            set { _goodsType = value; }
        }
        private string _goodsType;

        /// <summary>
        /// 商品分类名称
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GOODS_TYPE_NAME")]       
        public string GoodsTypeName
        {
            get { return _goodsTypeName; }
            set { _goodsTypeName = value; }
        }
        private string _goodsTypeName;

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GOODS_NAME")]        
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }
        private string _goodsName;

       
        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "QTY")]        
        public decimal Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        private decimal _qty;

        /// <summary>
        /// 第一数量
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "QTY_1")]        
        public decimal? Qty1
        {
            get { return _qty1; }
            set { _qty1 = value; }
        }
        private decimal? _qty1;

        /// <summary>
        /// 第二数量
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "QTY_2")]       
        public decimal? Qty2
        {
            get { return _qty2; }
            set { _qty2 = value; }
        }
        private decimal? _qty2;

        /// <summary>
        /// 第三数量
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "Qty_3")]       
        public decimal? Qty3
        {
            get { return _qty3; }
            set { _qty3 = value; }
        }
        private decimal? _qty3;

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "UNIT")]        
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        private string _unit;

        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "UNIT_NAME")]        
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }
        private string _unitName;

        /// <summary>
        /// 第一单位
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "UNIT_1")]        
        public string Unit1
        {
            get { return _unit1; }
            set { _unit1 = value; }
        }
        private string _unit1;

        /// <summary>
        /// 第二单位
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "UNIT_2")]        
        public string Unit2
        {
            get { return _unit2; }
            set { _unit2 = value; }
        }
        private string _unit2;

        /// <summary>
        /// 第三单位
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "UNIT_3")]        
        public string Unit3
        {
            get { return _unit3; }
            set { _unit3 = value; }
        }
        private string _unit3;

        /// <summary>
        /// 商品型号
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GOODS_MODEL")]        
        public string GoodsModel
        {
            get { return _goodsModel; }
            set { _goodsModel = value; }
        }
        private string _goodsModel;

        /// <summary>
        /// 商品到期日期
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "DUE_DATE")]        
        public DateTime? DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }
        private DateTime? _dueDate;

        /// <summary>
        /// 是否计算仓储费用
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "IS_COST")]        
        public string ISCost
        {
            get { return _isCost; }
            set { _isCost = value; }
        }
        private string _isCost;

        /// <summary>
        /// 新旧程度
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "NEW_OLD_DEGREE")]        
        public string NewOldDegree
        {
            get { return _newOldDegree; }
            set { _newOldDegree = value; }
        }
        private string _newOldDegree;

        /// <summary>
        /// 商品年代
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GOODS_YEARS")]        
        public string GoodsYears
        {
            get { return _goodsYears; }
            set { _goodsYears = value; }
        }
        private string _goodsYears;

        /// <summary>
        /// 文物级别
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CULTURAL_LEVEL")]        
        public string CulturalLevel
        {
            get { return _culturalLevel; }
            set { _culturalLevel = value; }
        }
        private string _culturalLevel;

        /// <summary>
        /// 操作时间
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "OPER_TIME")]        
        public DateTime OperTime
        {
            get { return _operTime; }
            set { _operTime = value; }
        }
        private DateTime _operTime;

        /// <summary>
        /// 操作人的三统一身份ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "OPER_ID")]        
        public string OperId
        {
            get { return _operId; }
            set { _operId = value; }
        }
        private string _operId;

        /// <summary>
        /// 操作人姓名
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "OPER_NAME")]        
        public string OperName
        {
            get { return _operName; }
            set { _operName = value; }
        }
        private string _operName;

        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "DELETE_FLAG")]        
        public bool DeleteFlag
        {
            get { return _deleteFlag; }
            set { _deleteFlag = value; }
        }
        private bool _deleteFlag;

        /// <summary>
        /// 扣单号
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "BUCKLE_NO")]        
        public string BuckleNo
        {
            get { return _buckleNo; }
            set { _buckleNo = value; }
        }
        private string _buckleNo;

        /// <summary>
        /// 法律文书
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "LEGAL_DOC")]        
        public string LegalDoc
        {
            get { return _legalDoc; }
            set { _legalDoc = value; }
        }
        private string _legalDoc;

        /// <summary>
        /// 案件种类
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CASE_TYPE")]        
        public Guid CaseType
        {
            get { return _caseType; }
            set { _caseType = value; }
        }
        private Guid _caseType;

        /// <summary>
        /// 案件种类名称
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CASE_TYPE_NAME")]        
        public string CaseTypeName
        {
            get { return _caseTypeName; }
            set { _caseTypeName = value; }
        }
        private string _caseTypeName;

        /// <summary>
        /// 外部系统的货物ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "SOURCE_GOODS_ID")]        
        public string SourceGoodsId
        {
            get { return _sourceGoodsId; }
            set { _sourceGoodsId = value; }
        }
        private string _sourceGoodsId;

        /// <summary>
        /// 非标准仓储费
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "COST_MONEY")]        
        public decimal? CostMoney
        {
            get { return _costMoney; }
            set { _costMoney = value; }
        }
        private decimal? _costMoney;

        private decimal? _newCostMoney;
        /// <summary>
        /// 待复核非标准仓储费
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "NEW_COST_MONEY")]        
        public decimal? NewCostMoney
        {
            get { return _newCostMoney; }
            set { _newCostMoney = value; }
        }


        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "REMARK")]        
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private string _remark;

        /// <summary>
        /// 车辆品牌
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CAR_BRAND")]       
        public string CarBrand
        {
            get { return _carBrand; }
            set { _carBrand = value; }
        }
        private string _carBrand;

        /// <summary>
        /// 车辆颜色
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CAR_COLOR")]        
        public string CarColor
        {
            get { return _carColor; }
            set { _carColor = value; }
        }
        private string _carColor;

        #region 预入库商品项会用到的字段
        /// <summary>
        /// 业务类型
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "BUSI_TYPE")]       
        public string BusiType
        {
            get { return _busiType; }
            set { _busiType = value; }
        }
        private string _busiType;



        private int? _goodNo;
        /// <summary>
        /// 商品编号
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GOOD_NO")]        
        public int? GoodNo
        {
            get { return _goodNo; }
            set { _goodNo = value; }
        }
        #endregion

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inFormGoodsId">ID</param>
        /// <param name="inFormId">IN_FORM_ID</param>
        /// <param name="goodsType">商品分类</param>
        /// <param name="goodsTypeName">商品分类名称</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="qty">数量</param>
        /// <param name="qty1">第一数量</param>
        /// <param name="qty2">第二数量</param>
        /// <param name="qty3">第三数量</param>
        /// <param name="unit">单位</param>
        /// <param name="unitName">单位名称</param>
        /// <param name="unit1">第一单位</param>
        /// <param name="unit2">第二单位</param>
        /// <param name="unit3">第三单位</param>
        /// <param name="goodsModel">商品型号</param>
        /// <param name="dueDate">商品到期日期</param>
        /// <param name="isCost">是否计算仓储费用</param>
        /// <param name="newOldDegree">新旧程度</param>
        /// <param name="goodsYears">商品年代</param>
        /// <param name="culturalLevel">文物级别</param>
        /// <param name="operTime">操作时间</param>
        /// <param name="operId">操作人的三统一身份ID</param>
        /// <param name="operName">操作人姓名</param>
        /// <param name="deleteFlag">是否删除</param>
        /// <param name="buckleNo">扣单号</param>
        /// <param name="legalDoc">法律文书</param>
        /// <param name="caseType">案件种类</param>
        /// <param name="caseTypeName">案件种类名称</param>
        /// <param name="costMoney">非标准仓储费</param>
        /// <param name="remark">备注</param>
        /// <param name="carBrand">车辆品牌</param>
        /// <param name="carColor">车辆颜色</param>
        /// <param name="sourceGoodsId">外部系统的货物ID</param>
        public InFormGoodsInfo(
                        Guid inFormGoodsId,
                        Guid inFormId,
                        string goodsType,
                        string goodsTypeName,
                        string goodsName,
                        bool isSensitive,
                        decimal qty,
                        decimal? qty1,
                        decimal? qty2,
                        decimal? qty3,
                        string unit,
                        string unitName,
                        string unit1,
                        string unit2,
                        string unit3,
                        string goodsModel,
                        DateTime dueDate,
                        string isCost,
                        string newOldDegree,
                        string goodsYears,
                        string culturalLevel,
                        DateTime operTime,
                        string operId,
                        string operName,
                        bool deleteFlag,
                        string buckleNo,
                        string legalDoc,
                        Guid caseType,
                        string caseTypeName,
                        decimal? costMoney,
                        string remark,
                        string carBrand,
                        string carColor,
                        string sourceGoodsId
                        )
        {
            this._inFormGoodsId = inFormGoodsId;
            this._inFormId = inFormId;
            this._goodsType = goodsType;
            this._goodsTypeName = goodsTypeName;
            this._goodsName = goodsName;
            this._qty = qty;
            this._qty1 = qty1;
            this._qty2 = qty2;
            this._qty3 = qty3;
            this._unit = unit;
            this._unitName = unitName;
            this._unit1 = unit1;
            this._unit2 = unit2;
            this._unit3 = unit3;
            this._goodsModel = goodsModel;
            this._dueDate = dueDate;
            this._isCost = isCost;
            this._newOldDegree = newOldDegree;
            this._goodsYears = goodsYears;
            this._culturalLevel = culturalLevel;
            this._operTime = operTime;
            this._operId = operId;
            this._operName = operName;
            this._deleteFlag = deleteFlag;
            this._buckleNo = buckleNo;
            this._legalDoc = legalDoc;
            this._caseType = caseType;
            this._caseTypeName = caseTypeName;
            this._remark = remark;
            this._carBrand = carBrand;
            this._carColor = carColor;
            this._sourceGoodsId = sourceGoodsId;
        }

    }
}

