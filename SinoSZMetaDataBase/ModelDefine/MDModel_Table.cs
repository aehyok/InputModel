using System;
using System.Collections.Generic;
using System.Text;
using SinoSZMetaDataBase.Define;

namespace SinoSZMetaDataBase.ModelDefine
{
        /// <summary>
        /// 查询模型中的表定义
        /// </summary>
        [Serializable]
        public class MDModel_Table : IComparable
        {
                /// <summary>
                /// 表中的字段
                /// </summary>
                public Dictionary<string, MDModel_Table_Column> ColumnDict
                {
                        get { return columnDict; }
                        set { columnDict = value; }
                }
                private Dictionary<string, MDModel_Table_Column> columnDict = new Dictionary<string, MDModel_Table_Column>();

               
                
                /// <summary>
                /// 表字段的别名字典,以字段的别名为字典键值
                /// </summary>
                public Dictionary<string, MDModel_Table_Column> AliasDict
                {
                        get { return aliasDict; }
                        set { aliasDict = value; }
                }
                private Dictionary<string, MDModel_Table_Column> aliasDict = new Dictionary<string, MDModel_Table_Column>();

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
                /// 表的基本定义
                /// </summary>
                public MD_ViewTable TableDefine
                {
                        get { return tableDefine; }
                        set
                        {
                                tableDefine = value;
                                this.displayOrder = tableDefine.DisplayOrder;
                                foreach (MD_ViewTableColumn _tc in tableDefine.Columns)
                                {
                                        if (_tc.CanDisplay)
                                        {
                                                MDModel_Table_Column _mtc = new MDModel_Table_Column(_tc);                                               
                                                _mtc.TableName = value.TableName;
                                                ColumnDict.Add(_mtc.ColumnName, _mtc);
                                                AliasDict.Add(_mtc.ColumnAlias, _mtc);
                                        }
                                }

                        }
                }
                private MD_ViewTable tableDefine = null;

                /// <summary>
                /// 取表名称
                /// </summary>
                public string TableName
                {
                        get
                        {
                                if (tableDefine == null)
                                        return "";
                                else
                                {
                                        return tableDefine.TableName;
                                }
                                
                        }
                }
                
                private string queryModelName = "";
                /// <summary>
                /// 查询模型名称
                /// </summary>
                public string QueryModelName
                {
                        get { return queryModelName; }
                        set { queryModelName = value; }
                }

                public MDModel_Table()
                {
                }

                public MDModel_Table(string _modelName,MD_ViewTable _table)
                {
                        TableDefine = _table;
                        QueryModelName = _modelName;
                }

                #region IComparable Members

                public int CompareTo(object obj)
                {
                        MDModel_Table _item = obj as MDModel_Table;
                        return this.DisplayOrder - _item.DisplayOrder;
                }

                #endregion
        }
}
