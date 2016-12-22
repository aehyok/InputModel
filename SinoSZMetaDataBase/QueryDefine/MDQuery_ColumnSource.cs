﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.QueryDefine
{
        /// <summary>
        /// 查询结果字段对应的元数据定义来源
        /// </summary>
        [Serializable]
        public class MDQuery_ColumnSource
        {
                /// <summary>
                /// 查询模型名称
                /// </summary>
                public string QueryModelName = "";
                /// <summary>
                /// 表名称
                /// </summary>
                public string TableName = "";
                /// <summary>
                /// 字段名称
                /// </summary>
                public string ColumnName = "";

                public MDQuery_ColumnSource() { }
                /// <summary>
                /// 构造方法
                /// </summary>
                /// <param name="_qvName">查询模型名称</param>
                /// <param name="_tname">表名称</param>
                /// <param name="_cname">字段名称</param>
                public MDQuery_ColumnSource(string _qvName, string _tname, string _cname)
                {
                        QueryModelName = _qvName;
                        TableName = _tname;
                        ColumnName = _cname;
                }
        }
}
