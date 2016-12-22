using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.QueryDefine
{
        /// <summary>
        /// 查询结果表
        /// </summary>
        [Serializable]
        public class MDQuery_ResultTable
        {               
                private string tableName = "";
                private string displayTitle = "";
                private Dictionary<string, MDQuery_ResultTableColumn> columnsDict = new Dictionary<string, MDQuery_ResultTableColumn>();
                private Dictionary<string, MDQuery_ResultTableColumn> aliasDict = new Dictionary<string, MDQuery_ResultTableColumn>();

                /// <summary>
                /// 表的显示名称
                /// </summary>
                public string DisplayTitle
                {
                        get { return displayTitle; }
                        set { displayTitle = value; }
                }

                /// <summary>
                /// 结果表名
                /// </summary>
                public string TableName
                {
                        get { return tableName; }
                        set { tableName = value; }
                }

                /// <summary>
                /// 字段字典,以ColumnName为字典键值
                /// </summary>
                public Dictionary<string, MDQuery_ResultTableColumn> ColumnsDict
                {
                        get { return columnsDict; }
                        set { columnsDict = value; }
                }

                /// <summary>
                /// 字段字典,以字段别名为字典键值
                /// </summary>
                public Dictionary<string, MDQuery_ResultTableColumn> AliasDict
                {
                        get { return aliasDict; }
                        set { aliasDict = value; }
                }
        }
}
