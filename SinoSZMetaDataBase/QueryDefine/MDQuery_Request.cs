using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.QueryDefine
{
        /// <summary>
        /// 查询请求数据包
        /// </summary>
        [Serializable]
        public class MDQuery_Request
        {
                public string QueryModelName = "";
                public string ConditionExpressions = "";
                public Dictionary<string, MDQuery_ConditionItem> ConditionItems = new Dictionary<string, MDQuery_ConditionItem>();
                public MDQuery_ResultTable MainResultTable = null;
                public Dictionary<string, MDQuery_ResultTable> ChildResultTables = new Dictionary<string,MDQuery_ResultTable>();
        }
}
