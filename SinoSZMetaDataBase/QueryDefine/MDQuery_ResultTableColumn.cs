using System;
using System.Collections.Generic;
using System.Text;
using SinoSZMetaDataBase.ModelDefine;
using SinoSZMetaDataBase.EnumDefine;

namespace SinoSZMetaDataBase.QueryDefine
{
        /// <summary>
        /// 查询请求中的字段定义
        /// </summary>
        [Serializable]
        public class MDQuery_ResultTableColumn
        {
                #region 属性
                /// <summary>
                /// 字段类型
                /// </summary>
                public QueryColumnType ColumnType
                {
                        get { return columnType; }
                        set { columnType = value; }
                }
                private QueryColumnType columnType = QueryColumnType.TableColumn;

                /// <summary>
                /// 字段算法(指如果是计算字段或统计字段,其算法)
                /// </summary>
                public string ColumnAlgorithm
                {
                        get { return columnAlgorithm; }
                        set { columnAlgorithm = value; }
                }
                private string columnAlgorithm = "";

                /// <summary>
                /// 字段名称
                /// </summary>
                public string ColumnName
                {
                        get { return columnName; }
                        set { columnName = value; }
                }
                private string columnName = "";

                /// <summary>
                /// 字段别名
                /// </summary>
                public string ColumnAlias
                {
                        get { return columnAlias; }
                        set { columnAlias = value; }
                }
                private string columnAlias = "";

                /// <summary>
                /// 字段显示名称
                /// </summary>
                public string ColumnTitle
                {
                        get { return columnTitle; }
                        set { columnTitle = value; }
                }
                private string columnTitle = "";


                /// <summary>
                /// 所在表的表名
                /// </summary>
                public string TableName
                {
                        get { return this.Source.TableName; }
                        set { this.Source.TableName = value; }
                }

                /// <summary>
                /// 所在查询模型名称
                /// </summary>
                private string QueryModelName
                {
                        get { return this.Source.QueryModelName; }
                        set { this.Source.QueryModelName = value; }
                }
                /// <summary>
                /// 显示顺序
                /// </summary>
                public int DisplayOrder
                {
                        get { return displayOrder; }
                        set { displayOrder = value; }
                }
                private int displayOrder = 0;

                /// <summary>
                /// 字段的数据类型
                /// </summary>
                public string ColumnDataType
                {
                        get { return columnDataType; }
                        set { columnDataType = value; }
                }

                private int columnLength = 1;
                /// <summary>
                /// 字段长度
                /// </summary>
                public int ColumnLength
                {
                        get { return columnLength; }
                        set { columnLength = value; }
                }

                private string columnDataType = "VARCHAR";

                private string displayFormat = "";
                /// <summary>
                /// 显示格式
                /// </summary>
                public string DisplayFormat
                {
                        get { return displayFormat; }
                        set { displayFormat = value; }
                }

                private int displayLength = 120;
                /// <summary>
                /// 列表显示的长度　(单位:px)
                /// </summary>
                public int DisplayLength
                {
                        get { return displayLength; }
                        set { displayLength = value; }
                }

               private  string refDMB = "";
                /// <summary>
                /// 代码表
                /// </summary>
                public string RefDMB
                {
                        get { return refDMB; }
                        set { refDMB = value; }
                }
                private string refWord = "";
                /// <summary>
                /// 引用表
                /// </summary>
                public string RefWord
                {
                        get { return refWord; }
                        set { refWord = value; }
                }


                private MDQuery_ColumnSource source = null;
                /// <summary>
                /// 对应的查询模型字段来源
                /// </summary>
                public MDQuery_ColumnSource Source
                {
                        get { return source; }
                        set { source = value; }
                }

                #endregion

                public MDQuery_ResultTableColumn()
                {
                }

                public MDQuery_ResultTableColumn(MDModel_Table_Column _columnDefine)
                {
                        this.ColumnAlgorithm = _columnDefine.ColumnAlgorithm;
                        this.ColumnAlias = _columnDefine.ColumnAlias;
                        this.ColumnDataType = _columnDefine.ColumnDataType;
                        this.columnLength = _columnDefine.ColumnDefine.Length;
                        this.refDMB = _columnDefine.ColumnDefine.RefDMB;
                        this.ColumnName = _columnDefine.ColumnName;
                        this.ColumnTitle = _columnDefine.ColumnTitle;
                        this.ColumnType = _columnDefine.ColumnType;
                        this.DisplayOrder = _columnDefine.DisplayOrder;
                        this.DisplayFormat = _columnDefine.ColumnDefine.DisplayFormat;
                        this.DisplayLength = (_columnDefine.ColumnDefine.ColWidth > 10) ? _columnDefine.ColumnDefine.ColWidth : 80;
                        this.Source = new MDQuery_ColumnSource(_columnDefine.QueryModelName, _columnDefine.TableName, _columnDefine.ColumnName);
                }



                #region IComparable Members

                public int CompareTo(object obj)
                {
                        MDQuery_ResultTableColumn _item = obj as MDQuery_ResultTableColumn;
                        return this.DisplayOrder - _item.DisplayOrder;
                }

                #endregion
        }
}
