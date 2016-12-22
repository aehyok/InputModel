using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_Table
        {
                private string _tid = "";
                private string _namespaceName = "";
                private MD_Namespace _namespace;
                private string _tableName = "";
                private string _tableType = "";
                private string _description = "";
                private string _displayTitle = "";
                private string _mainKey = "";
                private string _dwdm = "";
                private string _secretFun = "";
                private string _extSecret = "";
                private IList<MD_TableColumn> _columns = null;
                private MD_TableColumn _mainKeyColumn;


                public MD_Table()
                {
                }

                public MD_Table(string _id, string _ns, string _tname, string _ttype, string _des, string _title, string _mkey,
                        string _dw, string _sfun, string _extfun)
                {
                        _tid = _id;
                        _namespaceName = _ns;
                        _tableName = _tname;
                        _tableType = _ttype;
                        _description = _des;
                        _displayTitle = _title;
                        _mainKey = _mkey;
                        _dwdm = _dw;
                        _secretFun = _sfun;
                        _extSecret = _extfun;
                }

                public virtual string NamespaceName
                {
                        get { return _namespaceName; }
                        set { _namespaceName = value; }
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

                /// <summary>
                /// 表的ID
                /// </summary>
                public string TID
                {
                        get
                        {
                                return _tid;
                        }
                        set
                        {
                                _tid = value;
                        }
                }

                /// <summary>
                /// 表名称
                /// </summary>
                public virtual string TableName
                {
                        get
                        {
                                return _tableName;
                        }
                        set
                        {
                                _tableName = value;
                        }
                }

                /// <summary>
                /// 表类型
                /// </summary>
                public string TableType
                {
                        get
                        {
                                return _tableType;
                        }
                        set
                        {
                                _tableType = value;
                        }
                }

                /// <summary>
                /// 表的描述
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
                /// 表的显示名称
                /// </summary>
                public virtual string DisplayTitle
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
                /// 表的主键字段名称
                /// </summary>
                public string MainKey
                {
                        get
                        {
                                return _mainKey;
                        }
                        set
                        {
                                _mainKey = value;
                        }
                }

                /// <summary>
                /// 节点编号
                /// </summary>
                public string DWDM
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
                /// 安全函数
                /// </summary>
                public string SecretFun
                {
                        get
                        {
                                return _secretFun;
                        }
                        set
                        {
                                _secretFun = value;
                        }
                }

                /// <summary>
                /// 扩展安全函数
                /// </summary>
                public string ExtSecret
                {
                        get
                        {
                                return _extSecret;
                        }
                        set
                        {
                                _extSecret = value;
                        }
                }

                /// <summary>
                /// 本表的字段列表
                /// </summary>
                public IList<MD_TableColumn> Columns
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

                /// <summary>
                /// 本表的主键字段
                /// </summary>
                public MD_TableColumn MainKeyColumn
                {
                        get
                        {
                                return _mainKeyColumn;
                        }
                        set
                        {
                                _mainKeyColumn = value;
                        }
                }

                public override string ToString()
                {
                        return _displayTitle;
                }
        }
}
