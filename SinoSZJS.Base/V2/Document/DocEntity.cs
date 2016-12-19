using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using SinoSZJS.Base.V2.InputModel;

namespace SinoSZJS.Base.V2.Document
{
    [DataContract]
    public class DocEntity
    {
        /// <summary>
        /// 文书ID
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 文书类型明细Id
        /// </summary>
        [DataMember]
        public string DocTypeDetailsId { get; set; }

        /// <summary>
        /// 文书字号
        /// </summary>
        [DataMember]
        public string DocCaseNo { get; set; }

        /// <summary>
        /// 实体ID
        /// </summary>
        [DataMember]
        public string Bzid { get; set; }


        /// <summary>
        /// 文书内容BLOB
        /// </summary>
        [DataMember]
        public byte[] DocContent { get; set; }

        /// <summary>
        /// 文书数据 存CLOB
        /// </summary>
        [DataMember]
        public string DocData { get; set; }

        /// <summary>
        /// 生成时间
        /// </summary>
        [DataMember]
        public DateTime DocCreateDate { get; set; }

        /// <summary>
        /// 处理ID
        /// </summary>
        [DataMember]
        public string Clid { get; set; }

        /// <summary>
        /// 经办人员
        /// </summary>
        [DataMember]
        public string DocCreateUser { get; set; }

        /// <summary>
        /// 单位ID
        /// </summary>
        [DataMember]
        public string Dwid { get; set; }

        /// <summary>
        /// 文书所配置的ActionId
        /// </summary>
        [DataMember]
        public string DocActionId { get; set; }

        /// <summary>
        /// 实体Id
        /// </summary>
        [DataMember]
        public string ModelId { get; set; }

        /// <summary>
        /// 文书数据字典
        /// </summary>
        [DataMember]
        public MD_InputEntity InputEntity { get; set; }


    }
}
