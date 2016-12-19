using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SinoSZJS.Base.V2.MetaData.QueryModel
{
    /// <summary>
    /// 固定查询检索结果实体类
    /// </summary>
    [DataContract]
    public class QuerySearchResult
    {
        /// <summary>
        /// 查询模型数据
        /// </summary>
        [DataMember]
        public DataSet Data{ set; get; }
        
        /// <summary>
        /// 查询模型定义
        /// </summary>
        [DataMember]
        public MDModel_QueryModel Model { set; get; }

        /// <summary>
        /// 查询模型条件
        /// </summary>
        [DataMember]
        public List<MDQuery_ConditionItem> Conditions { set; get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public QuerySearchResult()
        {
            Data=new DataSet();
            Model=new MDModel_QueryModel();
            Conditions=new List<MDQuery_ConditionItem>();
        }
    }
}
