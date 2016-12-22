using System;
using System.Collections.Generic;
using System.Text;
using SinoSZMetaDataBase.Define;

namespace SinoSZMetaDataBase.QueryDefine
{
        /// <summary>
        /// 需检索的字段
        /// </summary>
        [Serializable]
        public class MDSearch_Column
        {
                private string modelName = "";
                private string tableName = "";
                private string tableTitle = "";
                private string columnTitle = "";
                private string columnName = "";
                private string tableKeyColumn = "";
                private MD_QueryModel queryModel = null;

                public MDSearch_Column() { }

                public MDSearch_Column(string _modelName, string _tableName, string _tableTitle,string _columnName, string _columnTitle,string _tableKey)
                {
                        modelName = _modelName;
                        tableName = _tableName;
                        columnName = _columnName;
                        tableKeyColumn = _tableKey;
                        tableTitle = _tableTitle;
                        columnTitle = _columnTitle;
                }

                /// <summary>
                /// 查询模型
                /// </summary>
                public MD_QueryModel QueryModel
                {
                        get { return queryModel; }
                        set { queryModel = value; }
                }

                /// <summary>
                /// 表的主键字段
                /// </summary>
                public string TableKeyColumn
                {
                        get { return tableKeyColumn; }
                        set { tableKeyColumn = value; }
                }
                /// <summary>
                /// 查询模型名称
                /// </summary>
                public string ModelName
                {
                        get { return modelName; }
                        set { modelName = value; }
                }

                /// <summary>
                /// 表名称
                /// </summary>
                public string TableName
                {
                        get { return tableName; }
                        set { tableName = value; }
                }

                public string TableTitle
                {
                        get { return tableTitle; }
                        set { tableTitle = value; }
                }


                public string ColumnTitle
                {
                        get { return columnTitle; }
                        set { columnTitle = value; }
                }

                /// <summary>
                /// 字段名称
                /// </summary>
                public string ColumnName
                {
                        get { return columnName; }
                        set { columnName = value; }
                }
        }
}
