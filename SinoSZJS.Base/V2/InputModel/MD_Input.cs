using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
    /// <summary>
    /// added by lqm 2014.03.26录入模型
    /// </summary>
    [DataContract]
    public class MD_Input
    {
        /// <summary>
        /// 录入模型中查询模型分组所用的主键
        /// </summary>
        [DataMember]
        private string queryModelMainKey;

        /// <summary>
        /// 录入模型实体定义
        /// </summary>
        [DataMember]
        public MD_InputModel MD_Define { get; set; }

        /// <summary>
        /// 录入模型实体数据
        /// </summary>
        [DataMember]
        public MD_InputEntity MD_Data { get; set; }

        /// <summary>
        /// 录入模型实体主键
        /// </summary>
        [DataMember]
        public string MainKey { get; set; }

        /// <summary>
        /// added by lqm 20160114
        /// 所属案件Id
        /// </summary>
        [DataMember]
        public string Ajid { get; set; }

        /// <summary>
        /// 录入模型中查询模型分组所用的主键，如果未赋值，则取MainKey属性的值
        /// added by ph 20160202：强制措施会用到
        /// </summary>
        [DataMember]
        public string QueryModelMainKey
        {
            set { this.queryModelMainKey = value; }
            get
            {
                if (this.queryModelMainKey != null)
                    return this.queryModelMainKey;
                else
                    return this.MainKey;
            }
        }

        public MD_Input()
        {
            MD_Define = new MD_InputModel();
            MD_Data = new MD_InputEntity();
        }
    }
}
