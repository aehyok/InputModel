using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ChinaCustoms.Applications.HGFM.Entities.InForm
{
    [Serializable]
    [DataContract]
    [XmlRoot("ReviewGoodsBusiness")]    
    public class ReviewGoodsBusinessInfo
    {
        private Guid _id;
        /// <summary>
        /// 业务ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "Id")]        
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private Guid _goodsId;
        /// <summary>
        /// 商品ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "GoodsId")]        
        public Guid GoodsId
        {
            get { return _goodsId; }
            set { _goodsId = value; }
        }
        private string _oldGoodsName;
        /// <summary>
        /// 修改前商品名称
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "OldGoodsName")]        
        public string OldGoodsName
        {
            get { return _oldGoodsName; }
            set { _oldGoodsName = value; }
        }
        private string _oldGoodsModel;
        /// <summary>
        /// 修改前商品类型
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "OldGoodsModel")]        
        public string OldGoodsModel
        {
            get { return _oldGoodsModel; }
            set { _oldGoodsModel = value; }
        }
        private string _newGoodsName;
        /// <summary>
        /// 修改后商品名称
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "NewGoodsName")]        
        public string NewGoodsName
        {
            get { return _newGoodsName; }
            set { _newGoodsName = value; }
        }
        private string _newGoodsModel;
        /// <summary>
        /// 修改后商品类型
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "NewGoodsModel")]        
        public string NewGoodsModel
        {
            get { return _newGoodsModel; }
            set { _newGoodsModel = value; }
        }
        private DateTime _createTime;
        /// <summary>
        /// 申请时间
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "CreateTime")]        
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        private string _operId;
        /// <summary>
        /// 申请人ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "OperId")]        
        public string OperId
        {
            get { return _operId; }
            set { _operId = value; }
        }
        private string _operName;
        /// <summary>
        /// 申请人姓名
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "OperName")]        
        public string OperName
        {
            get { return _operName; }
            set { _operName = value; }
        }
        private string _operFullPath;
        /// <summary>
        /// 申请人部门全路径
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "OperFullPath")]        
        public string OperFullPath
        {
            get { return _operFullPath; }
            set { _operFullPath = value; }
        }
        private string _reviewUserId;
        /// <summary>
        /// 审批人ID
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "ReviewUserId")]        
        public string ReviewUserId
        {
            get { return _reviewUserId; }
            set { _reviewUserId = value; }
        }
        private string _reviewUserName;
        /// <summary>
        /// 审批人姓名
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "ReviewUserName")]        
        public string ReviewUserName
        {
            get { return _reviewUserName; }
            set { _reviewUserName = value; }
        }
        private string _reviewUserFullPath;
        /// <summary>
        /// 审批人部门全路径
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "ReviewUserFullPath")]        
        public string ReviewUserFullPath
        {
            get { return _reviewUserFullPath; }
            set { _reviewUserFullPath = value; }
        }
        private DateTime? _reviewTime;
        /// <summary>
        /// 审批时间
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "ReviewTime")]
        public DateTime? ReviewTime
        {
            get { return _reviewTime; }
            set { _reviewTime = value; }
        }
        private int _reviewState;
        /// <summary>
        /// 审批状态
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "ReviewState")]
        public int ReviewState
        {
            get { return _reviewState; }
            set { _reviewState = value; }
        }
        private string _reviewContent;
        /// <summary>
        /// 审批意见
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "ReviewContent")]
        public string ReviewContent
        {
            get { return _reviewContent; }
            set { _reviewContent = value; }
        }

        private string _reason;
        /// <summary>
        /// 修改原因
        /// </summary>
        [DataMember]
        [XmlElement(ElementName = "Reason")]
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

    }
}
