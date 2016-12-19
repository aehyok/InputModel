/****************************************************************************************************
 * Description:  入库单表头实体类
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
    [XmlRoot("IN_FORM_HEAD")]    
    public class InFormHeadInfo
    {
        public InFormHeadInfo()
        { }

        #region 属性
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "IN_FORM_ID")]        
        public Guid? INFormId
        {
            get { return _inFormId; }
            set { _inFormId = value; }
        }
        private Guid? _inFormId;

        /// <summary>
        /// 入库单号
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "IN_FORM_NO")]        
        public string InFormNo
        {
            get { return _inFormNo; }
            set { _inFormNo = value; }
        }
        private string _inFormNo;

        /// <summary>
        /// 所属海关(分关)
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CUS_CODE")]        
        public string CusCode
        {
            get { return _cusCode; }
            set { _cusCode = value; }
        }
        private string _cusCode;


        /// <summary>
        /// 所属海关(分关)名称
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CUS_NAME")]        
        public string CusName
        {
            get { return _cusName; }
            set { _cusName = value; }
        }
        private string _cusName;

        /// <summary>
        /// 当事人
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "PARTIES")]
        public string Parties
        {
            get { return _parties; }
            set { _parties = value; }
        }
        private string _parties;

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
        /// 经办单位
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "HANDING_UNITS")]
        public string HandingUnits
        {
            get { return _handingUnits; }
            set { _handingUnits = value; }
        }
        private string _handingUnits;

        /// <summary>
        /// 经办单位ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "HANDING_UNITS_ID")]
        public Guid? HandingUnitsId
        {
            get { return _handingUnitsId; }
            set { _handingUnitsId = value; }
        }
        private Guid? _handingUnitsId;

        /// <summary>
        /// 查扣单位
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "BUCKLE_UNITS")]
        public string BuckleUnits
        {
            get { return _buckleUnits; }
            set { _buckleUnits = value; }
        }
        private string _buckleUnits;

        /// <summary>
        /// 查扣单位ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "BUCKLE_UNITS_ID")]
        public Guid? BuckleUnitsId
        {
            get { return _buckleUnitsId; }
            set { _buckleUnitsId = value; }
        }
        private Guid? _buckleUnitsId;

        /// <summary>
        /// 移交单位
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "TRANSFER_UNITS")]
        public string TransferUnits
        {
            get { return _transferUnits; }
            set { _transferUnits = value; }
        }
        private string _transferUnits;

        /// <summary>
        /// 立案号
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CASE_NO")]
        public string CaseNo
        {
            get { return _caseNo; }
            set { _caseNo = value; }
        }
        private string _caseNo;

        /// <summary>
        /// 案件名称
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CASE_NAME")]
        public string CaseName
        {
            get { return _caseName; }
            set { _caseName = value; }
        }
        private string _caseName;

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
        /// 仓库原始单号
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "WAREHOUSE_OLD_NO")]
        public string WarehouseOldNo
        {
            get { return _warehouseOldNo; }
            set { _warehouseOldNo = value; }
        }
        private string _warehouseOldNo;

        /// <summary>
        /// 存放仓库ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "WAREHOUSE_ID")]
        public Guid? WarehouseId
        {
            get { return _warehouseId; }
            set { _warehouseId = value; }
        }
        private Guid? _warehouseId;

        /// <summary>
        /// 存放仓库编码
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "WAREHOUSE_CODE")]
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }
        private string _warehouseCode;

        /// <summary>
        /// 存放仓库名称
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "WAREHOUSE_NAME")]
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }
        private string _warehouseName;

        /// <summary>
        /// 制单时间
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CREATE_TIME")]
        public DateTime? CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        private DateTime? _createTime;

        /// <summary>
        /// 入库时间
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GRN_TIME")]
        public DateTime? GrnTime
        {
            get { return _grnTime; }
            set { _grnTime = value; }
        }
        private DateTime? _grnTime;

        /// <summary>
        /// 商品概况
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GOOD_DETAIL")]
        public string GoodDetail
        {
            get { return _goodDetail; }
            set { _goodDetail = value; }
        }
        private string _goodDetail;

        /// <summary>
        /// 货物性质ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GOOD_NATURE_ID")]
        public string GoodNatureId
        {
            get { return _goodNatureId; }
            set { _goodNatureId = value; }
        }
        private string _goodNatureId;

        /// <summary>
        /// 货物性质名称
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GOOD_NATURE")]
        public string GoodNature
        {
            get { return _goodNature; }
            set { _goodNature = value; }
        }
        private string _goodNature;

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
        /// 审核状态
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CHECK_STATE")]
        public int? CheckState
        {
            get { return _checkState; }
            set { _checkState = value; }
        }
        private int? _checkState;

        /// <summary>
        /// 审核人
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CHECK_USER")]
        public string CheckUser
        {
            get { return _checkUser; }
            set { _checkUser = value; }
        }
        private string _checkUser;

        /// <summary>
        /// 审核时间
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CHECK_TIME")]
        public DateTime? CheckTime
        {
            get { return _checkTime; }
            set { _checkTime = value; }
        }
        private DateTime? _checkTime;

        /// <summary>
        /// 操作时间
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "OPER_TIME")]
        public DateTime? OperTime
        {
            get { return _operTime; }
            set { _operTime = value; }
        }
        private DateTime? _operTime;

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
        /// 案件种类
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CASE_TYPE")]
        public Guid? CaseType
        {
            get { return _caseType; }
            set { _caseType = value; }
        }
        private Guid? _caseType;

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
        /// 案件状态
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CASE_STATUS")]
        public string CaseStatus
        {
            get { return _caseStatus; }
            set { _caseStatus = value; }
        }
        private string _caseStatus;

        /// <summary>
        /// 当前案值
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CASE_CURRENT_VALUE")]
        public decimal? CaseCurrentValue
        {
            get { return _caseCurrentValue; }
            set { _caseCurrentValue = value; }
        }
        private decimal? _caseCurrentValue;

        /// <summary>
        /// 当前办案单位
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CASE_CURRENT_UNIT")]
        public string CaseCurrentUnit
        {
            get { return _caseCurrentUnit; }
            set { _caseCurrentUnit = value; }
        }
        private string _caseCurrentUnit;

        /// <summary>
        /// 复核人
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "REVIEW_USER")]
        public string ReviewUser
        {
            get { return _reviewUser; }
            set { _reviewUser = value; }
        }
        private string _reviewUser;

        /// <summary>
        /// 复核时间
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "REVIEW_TIME")]
        public DateTime? ReviewTime
        {
            get { return _reviewTime; }
            set { _reviewTime = value; }
        }
        private DateTime? _reviewTime;

        /// <summary>
        /// 外部系统来源
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "SOURCE")]
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
        private string _source;

        /// <summary>
        /// 外部系统的ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "SOURCE_ID")]
        public string SourceId
        {
            get { return _sourceId; }
            set { _sourceId = value; }
        }
        private string _sourceId;

        private string _delegateUnit;
        /// <summary>
        /// 货主(委托单位)
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "DELEGATE_UNIT")]
        public string DelegateUnit
        {
            get { return _delegateUnit; }
            set { _delegateUnit = value; }
        }
        private string _handingPerSon;
        /// <summary>
        /// 经办人
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "HANDING_PERSON")]
        public string HandingPerson
        {
            get { return _handingPerSon; }
            set { _handingPerSon = value; }
        }

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inFormId">ID</param>
        /// <param name="inFormNo">入库单号</param>
        /// <param name="cusCode">所属海关(分关)</param>
        /// <param name="cusName">所属海关(分关)名称</param>
        /// <param name="parties">当事人</param>
        /// <param name="buckleNo">扣单号</param>
        /// <param name="handingUnits">经办单位</param>
        /// <param name="handingUnitsId">经办单位ID</param>
        /// <param name="buckleUnits">查扣单位</param>
        /// <param name="buckleUnitsId">查扣单位ID</param>
        /// <param name="transferUnits">移交单位</param>
        /// <param name="caseNo">案件编号</param>
        /// <param name="caseName">案件名称</param>
        /// <param name="legalDoc">法律文书</param>
        /// <param name="warehouseOldNo">仓库原始单号</param>
        /// <param name="warehouseId">存放仓库ID</param>
        /// <param name="warehouseCode">存放仓库编码</param>
        /// <param name="warehouseName">存放仓库名称</param>
        /// <param name="createTime">制单时间</param>
        /// <param name="grnTime">入库时间</param>
        /// <param name="goodDetail">商品概况</param>
        /// <param name="goodNatureId">货物性质ID</param>
        /// <param name="goodNature">货物性质名称</param>
        /// <param name="remark">备注</param>
        /// <param name="checkState">审核状态</param>
        /// <param name="checkUser">审核人</param>
        /// <param name="checkTime">审核时间</param>
        /// <param name="operTime">操作时间</param>
        /// <param name="operId">操作人的三统一身份ID</param>
        /// <param name="operName">操作人姓名</param>
        /// <param name="deleteFlag">是否删除</param>
        /// <param name="caseType">案件种类</param>
        /// <param name="caseTypeName">案件种类名称</param>
        public InFormHeadInfo(
                        Guid? inFormId,
                        string inFormNo,
                        string cusCode,
                        string cusName,
                        string parties,
                        string buckleNo,
                        string handingUnits,
                        Guid? handingUnitsId,
                        string buckleUnits,
                        Guid? buckleUnitsId,
                        string transferUnits,
                        string caseNo,
                        string caseName,
                        string legalDoc,
                        string warehouseOldNo,
                        Guid warehouseId,
                        string warehouseCode,
                        string warehouseName,
                        DateTime? createTime,
                        DateTime? grnTime,
                        string goodDetail,
                        string goodNature,
                        string goodNatureId,
                        string remark,
                        int? checkState,
                        string checkUser,
                        DateTime? checkTime,
                        DateTime? operTime,
                        string operId,
                        string operName,
                        bool deleteFlag,
                        Guid? caseType,
                        string caseTypeName,
                        string reviewUser,
                        DateTime? reviewTime,
                        string caseStatus,
                        decimal? caseCurrentValue,
                        string caseCurrentUnit,
                        string source,
                        string sourceId
                        )
        {
            this._inFormId = inFormId;
            this._inFormNo = inFormNo;
            this._cusCode = cusCode;
            this._cusName = cusName;
            this._parties = parties;
            this._buckleNo = buckleNo;
            this._handingUnits = handingUnits;
            this._handingUnitsId = handingUnitsId;
            this._buckleUnits = buckleUnits;
            this._buckleUnitsId = buckleUnitsId;
            this._transferUnits = transferUnits;
            this._caseNo = caseNo;
            this._caseName = caseName;
            this._legalDoc = legalDoc;
            this._warehouseOldNo = warehouseOldNo;
            this._warehouseId = warehouseId;
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._createTime = createTime;
            this._grnTime = grnTime;
            this._goodDetail = goodDetail;
            this._goodNature = goodNature;
            this._goodNatureId = goodNatureId;
            this._remark = remark;
            this._checkState = checkState;
            this._checkUser = checkUser;
            this._checkTime = checkTime;
            this._operTime = operTime;
            this._operId = operId;
            this._operName = operName;
            this._deleteFlag = deleteFlag;
            this._caseType = caseType;
            this._caseTypeName = caseTypeName;
            this._reviewUser=reviewUser;
            this._reviewTime=ReviewTime;
            this._caseCurrentUnit=caseCurrentUnit;
            this._caseCurrentValue=caseCurrentValue;
            this._caseStatus=caseStatus;
            this._source=source;
            this._sourceId=sourceId;
        }

    }
}

