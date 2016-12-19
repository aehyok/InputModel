using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
    /// <summary>
    /// 文书类型
    /// </summary>
    [DataContract]
    public class DocType
    {
        /// <summary>
        /// 文书类型id
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 文书名称
        /// </summary>
        [DataMember]
        public string DocTitle { get; set; }

        /// <summary>
        /// 文书分类Id
        /// </summary>
        [DataMember]
        public string SortId { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public string FlowId { get; set; }

        [DataMember]
        public string DocState { get; set; }

        /// <summary>
        /// 卷宗类别
        /// </summary>
        [DataMember]
        public string FileType { get; set; }

        /// <summary>
        /// 是否空白法律文书（等于1则为空白文书）
        /// </summary>
        [DataMember]
        public string IsBlankDoc { get; set; }

        public DocType() { }

        public DocType(string id, string docTitle, int displayOrder)
        {
            this.Id = id;
            this.DocTitle = docTitle;
            this.DisplayOrder = displayOrder;
        }
    }
}
