using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        /// <summary>
        /// 命名空间元数据定义
        /// </summary>
        /// 
        [Serializable]
        public class MD_Namespace
        {
                private string _namespace;              //命名空间名
                private string _description;            //描述
                private string _displayTitle;           //显示名称
                private string _owner;                  //数据在数据库中的名称(此项已无用,保留是为了兼容从前的版本)
                private string _menuPosition;           //菜单所在的位置(此项已无用,保留是为了兼容从前的版本)
                private int _displayOrder;              //显示顺序
                private string _dwdm;                   //节点代码,指系统所安装的服务器所在的单位编码,可用于区分节点
                private string _concepts;               //本空间所含的概念组(此项已无用,保留是为了兼容从前的版本)
                private IList<MD_Table> _tableList = new List<MD_Table>();
                private IList<MD_QueryModel> _queryModelList = new List<MD_QueryModel>();     //本空间所含表的集合  
                private IList<MD_RefTable> _refTableList = new List<MD_RefTable>();     
                private MD_Nodes _node;

                /// <summary>
                /// 命名空间名
                /// </summary>
                public string NameSpace
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
                /// 数据在数据库中的名称(此项已无用,保留是为了兼容从前的版本)
                /// </summary>
                public string Owner
                {
                        get
                        {
                                return _owner;
                        }
                        set
                        {
                                _owner = value;
                        }
                }

                /// <summary>
                /// 菜单所在的位置(此项已无用,保留是为了兼容从前的版本)
                /// </summary>
                public string MenuPosition
                {
                        get
                        {
                                return _menuPosition;
                        }
                        set
                        {
                                _menuPosition = value;
                        }
                }

                /// <summary>
                /// 节点代码,指系统所安装的服务器所在的单位编码,可用于区分节点
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
                /// 本空间所含的概念组(此项已无用,保留是为了兼容从前的版本)
                /// </summary>
                public string Concepts
                {
                        get
                        {
                                return _concepts;
                        }
                        set
                        {
                                _concepts = value;
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
                /// 命名空间中的表
                /// </summary>
                public IList<MD_Table> TableList
                {
                        get
                        {
                                return _tableList;
                        }
                        set
                        {
                                _tableList = value;
                        }
                }

                /// <summary>
                /// 命名空间的查询模型
                /// </summary>
                public IList<MD_QueryModel> QueryModelList
                {
                        get
                        {
                                return _queryModelList;
                        }
                        set
                        {
                                _queryModelList = value;
                        }
                }


                public IList<MD_RefTable> RefTableList
                {
                        get { return _refTableList; }
                        set { _refTableList = value; }
                }

                /// <summary>
                /// 命名空间所在节点
                /// </summary>
                public MD_Nodes Nodes
                {
                        get
                        {
                                return _node;
                        }
                        set
                        {
                                _node = value;
                        }
                }

                public MD_Namespace(string _namespacename,string _des,string _menupos,string _display,string _ow,int _disorder,string _dw,
                          string _con)
                {
                        this._namespace = _namespacename;
                        this._description = _des;
                        this._displayOrder = _disorder;
                        this._displayTitle = _display;
                        this._dwdm = _dw;
                        this._menuPosition = _menupos;
                        this._owner = _ow;
                        this._concepts = _con;
                }

                public override string ToString()
                {
                        return string.Format("命名空间[{0}]",this.DisplayTitle);
                }


                        
        }
}
