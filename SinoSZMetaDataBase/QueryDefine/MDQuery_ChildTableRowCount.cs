using System;
using System.Collections.Generic;
using System.Text;
using SinoSZMetaDataBase.ModelDefine;

namespace SinoSZMetaDataBase.QueryDefine
{
        /// <summary>
        /// 子表记录数
        /// </summary>
        [Serializable]
        public class MDQuery_ChildTableRowCount
        {
                private string tableName = "";
                private int rowCount = 0;
                /// <summary>
                /// 子表名
                /// </summary>
                public string TableName
                {
                        get { return tableName; }
                        set { tableName = value; }
                }
                /// <summary>
                /// 记录数
                /// </summary>
                public int RowCount
                {
                        get { return rowCount; }
                        set { rowCount = value; }
                }

                public MDQuery_ChildTableRowCount() { }

                public MDQuery_ChildTableRowCount(string _tName, int _count)
                {
                        tableName = _tName;
                        rowCount = _count;
                }

        }
}
