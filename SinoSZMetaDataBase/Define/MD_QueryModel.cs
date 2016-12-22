using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_QueryModel
        {
                private MD_ViewTable _mainTable;
                private IList<MD_ViewTable> _childTables;
                private IList<MD_View2ViewGroup> view2viewGroup;
                private string _namespaceName;
                private MD_Namespace _namespace;
                private string _mainTableName;
                private string _queryModelName;
                private string _description;
                private string _displayTitle;
                private string _dwdm;
                private bool _isFixQuery = false;
                private bool _isRelationQuery = false;
                private bool _isDataAuditing = false;
                private int _displayOrder = 0;
                private string _queryModelID;
                private string _queryInterface = "ORA_JSIS";
                public MD_QueryModel()
                {
                }

                public MD_QueryModel(string _qid, string _ns, string _qName, string _des, string _title, string _dw, bool _isFix, bool _isRelation,
                        bool _isda, int _order, string _interface)
                {
                        _queryModelID = _qid;
                        _namespaceName = _ns;
                        _queryModelName = _qName;
                        _description = _des;
                        _displayTitle = _title;
                        _dwdm = _dw;
                        _isFixQuery = _isFix;
                        _isRelationQuery = _isRelation;
                        _isDataAuditing = _isda;
                        _displayOrder = _order;
                        _queryInterface = _interface;
                }

                /// <summary>
                /// 本模型使用的查询接口
                /// </summary>
                public string QueryInterface
                {
                        get
                        {
                                return _queryInterface;
                        }
                        set
                        {
                                _queryInterface = value;
                        }
                }

                /// <summary>
                /// 命名空间
                /// </summary>
                public MD_Namespace Namespace
                {
                        get
                        {
                                return _namespace;
                        }
                        set
                        {
                                _namespace = value;
                        }
                }

                public string NamespaceName
                {
                        get { return _namespaceName; }
                        set { _namespaceName = value; }
                }

                public string FullName
                {
                        get { return string.Format("{0}.{1}", _namespaceName, _queryModelName); }
                }

                /// <summary>
                /// 主表
                /// </summary>
                public MD_ViewTable MainTable
                {
                        get
                        {
                                return _mainTable;
                        }
                        set
                        {
                                _mainTable = value;
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

                public IList<MD_View2ViewGroup> View2ViewGroup
                {
                        get { return view2viewGroup; }
                        set { view2viewGroup = value; }
                }

                /// <summary>
                /// 查询模型名称
                /// </summary>
                public string QueryModelName
                {
                        get
                        {
                                return _queryModelName;
                        }
                        set
                        {
                                _queryModelName = value;
                        }
                }

                /// <summary>
                /// 描述
                /// </summary>
                public string Description
                {
                        get
                        {
                                return _description;
                        }
                        set
                        {
                                _description = value;
                        }
                }

                /// <summary>
                /// 显示名称
                /// </summary>
                public string DisplayTitle
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
                /// 节点编号
                /// </summary>
                public String DWDM
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
                /// 是否固定查询
                /// </summary>
                public bool IsFixQuery
                {
                        get
                        {
                                return _isFixQuery;
                        }
                        set
                        {
                                _isFixQuery = value;
                        }
                }

                /// <summary>
                /// 是否关联查询
                /// </summary>
                public bool IsRelationQuery
                {
                        get
                        {
                                return _isRelationQuery;
                        }
                        set
                        {
                                _isRelationQuery = value;
                        }
                }

                /// <summary>
                /// 是否数据审核
                /// </summary>
                public bool IsDataAuditing
                {
                        get
                        {
                                return _isDataAuditing;
                        }
                        set
                        {
                                _isDataAuditing = value;
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
                /// 查询模型ID
                /// </summary>
                public string QueryModelID
                {
                        get
                        {
                                return _queryModelID;
                        }
                        set
                        {
                                _queryModelID = value;
                        }
                }

                public override string ToString()
                {
                        return _displayTitle;
                }
        }
}
