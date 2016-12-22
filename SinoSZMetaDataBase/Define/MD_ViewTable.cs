using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        /// <summary>
        /// 元数据表定义
        /// </summary>
        [Serializable]
        public class MD_ViewTable
        {
                private IList<MD_ViewTable> _childTables;
                private int _displayOrder;
                private string _displayTitle;
                private MDType_DisplayType _displayType;
                private string _dwdm;
                private MD_ViewTable _fatherTable;
                private string _fatherTableID;
                private MD_QueryModel _queryModel;
                private string _relationString;
                private string _viewTableID;
                private MDType_ViewTableRelation _viewTableRelationType;
                private MDType_ViewTable _viewTableType;
                private int _priority;
                private string _viewID;
                private string _tableID;
                private MD_Table _table;
                private IList<MD_ViewTableColumn> _columns = null;
                /// <summary>
                /// 对应的查询模型
                /// </summary>
                public MD_QueryModel QueryModel
                {
                        get
                        {
                                return _queryModel;
                        }
                        set
                        {
                                _queryModel = value;
                                this._viewID = _queryModel.QueryModelID;
                        }
                }


                public MD_ViewTable()
                {

                }

                public MD_ViewTable(string _vtid, string _viewid, string _tid, string _ttype, string _relation, string _condi,
                        string _display, int _order, string _dw, string _fid, int _pri, int _dtype)
                {
                        this._viewTableID = _vtid;
                        this._viewID = _viewid;
                        this._tableID = _tid;
                        this._viewTableType = (_ttype == "M") ? MDType_ViewTable.MainTable : MDType_ViewTable.ChildTable;
                        this._relationString = _relation;
                        this._viewTableRelationType = (_condi == "1") ? MDType_ViewTableRelation.SingleChildRecord : MDType_ViewTableRelation.MultiChildRecord;
                        this._displayType = (_dtype > 0) ? MDType_DisplayType.FormType : MDType_DisplayType.GridType;
                        this._displayTitle = _display;
                        this._displayOrder = _order;
                        this._dwdm = _dw;
                        this._fatherTableID = _fid;
                        this._priority = _pri;
                }


                public MD_Table Table
                {
                        get { return _table; }
                        set { _table = value; }
                }

                /// <summary>
                /// 视图表ID
                /// </summary>
                public string ViewTableID
                {
                        get
                        {
                                return _viewTableID;
                        }
                        set
                        {
                                _viewTableID = value;
                        }
                }


                public string TableID
                {
                        get { return _tableID; }
                        set { _tableID = value; }
                }
                /// <summary>
                /// 视图表的类型(主表或子表)
                /// </summary>
                public MDType_ViewTable ViewTableType
                {
                        get
                        {
                                return _viewTableType;
                        }
                        set
                        {
                                _viewTableType = value;
                        }
                }

                /// <summary>
                /// 子表的显示方式
                /// </summary>
                public MDType_DisplayType DisplayType
                {
                        get { return _displayType; }
                        set { _displayType = value; }
                }
                /// <summary>
                /// 关系表达式
                /// </summary>
                public string RelationString
                {
                        get
                        {
                                return _relationString;
                        }
                        set
                        {
                                _relationString = value;
                        }
                }

                /// <summary>
                /// 与父表的关系类型
                /// </summary>
                public MDType_ViewTableRelation ViewTableRelationType
                {
                        get
                        {
                                return _viewTableRelationType;
                        }
                        set
                        {
                                _viewTableRelationType = value;
                        }
                }

                /// <summary>
                /// 显示名称
                /// </summary>
                public new string DisplayTitle
                {
                        get
                        {
                                return _displayTitle;
                        }
                        set
                        {
                                _displayTitle = value;
                        }
                }

                /// <summary>
                /// 显示顺序
                /// </summary>
                public int DisplayOrder
                {
                        get
                        {
                                return _displayOrder;
                        }
                        set
                        {
                                _displayOrder = value;
                        }
                }

                /// <summary>
                /// 节点编号
                /// </summary>
                public new string DWDM
                {
                        get
                        {
                                return _dwdm;
                        }
                        set
                        {
                                _dwdm = value;
                        }
                }

                /// <summary>
                /// 对应的父表
                /// </summary>
                public MD_ViewTable FatherTable
                {
                        get
                        {
                                return _fatherTable;
                        }
                        set
                        {
                                _fatherTable = value;
                        }
                }

                /// <summary>
                /// 子表列表
                /// </summary>
                public IList<MD_ViewTable> ChildTables
                {
                        get
                        {
                                return _childTables;
                        }
                        set
                        {
                                _childTables = value;
                        }
                }

                /// <summary>
                /// 查询优先权(数值越小则越高)
                /// </summary>
                public int Priority
                {
                        get
                        {
                                return _priority;
                        }
                        set
                        {
                                _priority = value;
                        }
                }
                public string NamespaceName
                {
                        get
                        {
                                return _table.NamespaceName;
                        }
                        set
                        {
                                _table.NamespaceName = value;
                        }
                }

                public string TableName
                {
                        get
                        {
                                return _table.TableName;
                        }
                        set
                        {
                                _table.TableName = value;
                        }
                }
                public override string ToString()
                {
                        return _displayTitle;
                }

                public IList<MD_ViewTableColumn> Columns
                {
                        get
                        {
                                return _columns;
                        }
                        set
                        {
                                _columns = value;
                        }
                }

                public string FatherTableID
                {
                        get { return _fatherTableID; }
                        set { _fatherTableID = value; }
                }



        }
}
