using System;
using System.Collections.Generic;
using System.Text;
using SinoSZMetaDataBase.EnumDefine;
using SinoSZMetaDataBase.Define;

namespace SinoSZMetaDataBase.ModelDefine
{
        /// <summary>
        /// 查询模型中的表字段定义
        /// </summary>
        [Serializable]
        public class MDModel_Table_Column : IComparable
        {
                
                //字段名称
                protected string columnName = "";
                /// <summary>
                /// 字段名称
                /// </summary>
                public string ColumnName
                {
                        get { return columnName; }
                        set { columnName = value; }
                }


                //字段别名
                protected string columnAlias = "";
                 /// <summary>
                /// 字段别名
                /// </summary>
                public string ColumnAlias
                {
                        get { return columnAlias; }
                        set { columnAlias = value; }
                }


                //字段显示名称
                protected string columnTitle = "";
                /// <summary>
                /// 字段标题
                /// </summary>
                public string ColumnTitle
                {
                        get { return columnTitle; }
                        set { columnTitle = value; }
                }


                //字段类型
                protected QueryColumnType columnType = QueryColumnType.TableColumn;
                  /// <summary>
                /// 字段类型
                /// </summary>
                public QueryColumnType ColumnType
                {
                        get { return columnType; }
                        set { columnType = value; }
                }


                //表字段基本定义(指如果是表字段,则其对应的元数据定义)
                protected MD_ViewTableColumn columnDefine = null;         
                /// <summary>
                /// 字段定义(指如果是表字段,则其对应的元数据定义)
                /// </summary>
                public MD_ViewTableColumn ColumnDefine
                {
                        get { return columnDefine; }
                        set
                        {
                                columnDefine = value;
                                this.columnTitle = value.DisplayTitle;
                                this.columnAlias = value.ColumnName;
                                this.columnName = value.ColumnName;
                                this.columnDataType = value._columnType;       
                                this.displayOrder = value.DisplayOrder;                                
                        }
                }

                //计算字段算法(指如果是计算字段或统计字段,其算法)
                protected string columnAlgorithm = "";              
                 /// <summary>
                /// 字段算法(指如果是计算字段或统计字段,其算法)
                /// </summary>
                public string ColumnAlgorithm
                {
                        get { return columnAlgorithm; }
                        set { columnAlgorithm = value; }
                }



                //字段所在的表名
                protected string tableName = "";
                /// <summary>
                /// 所在表的表名
                /// </summary>
                public string TableName
                {
                        get { return tableName; }
                        set { tableName = value; }
                }

                //字段所在的查询模型名称
                protected string queryModelName = "";
                /// <summary>
                /// 字段所在的查询模型名称
                /// </summary>
                public string QueryModelName
                {
                        get { return queryModelName; }
                        set { queryModelName = value; }
                }

                //显示顺序
                protected int displayOrder = 0;
                 /// <summary>
                /// 显示顺序
                /// </summary>
                public int DisplayOrder
                {
                        get { return displayOrder; }
                        set { displayOrder = value; }
                }


                //字段的数据类型
                protected string columnDataType = "VARCHAR";
                /// <summary>
                /// 字段的数据类型
                /// </summary>
                public string ColumnDataType
                {
                        get { return columnDataType; }
                        set { columnDataType = value; }
                }

                /// <summary>
                /// 字段的代码表
                /// </summary>
                public string ColumnRefDMB
                {
                        get { 
                                if (columnDefine == null)
                                        return "";
                                else 
                                        return columnDefine.RefDMB;
                        }
                }               

                


                public MDModel_Table_Column()
                {
                }

                public MDModel_Table_Column(MD_ViewTableColumn _tc)
                {
                        ColumnType = QueryColumnType.TableColumn;
                        this.ColumnDefine = _tc;
                }


                #region IComparable Members
                public int CompareTo(object obj)
                {
                        MDModel_Table_Column _item = obj as MDModel_Table_Column;
                        return this.displayOrder - _item.displayOrder;
                }
                #endregion
        }
}
