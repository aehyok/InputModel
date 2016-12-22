using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_Nodes
        {
                private string nodeName = "";
                private string dwdm = "";
                private string displayTitle = "";
                private string nodeid = "";
                private string descript = "";
                private IList<MD_Namespace> _namespaces = new List<MD_Namespace>();

                /// <summary>
                /// 包含的命名空间
                /// </summary>
                public IList<MD_Namespace> NameSpaces
                {
                        get { return _namespaces; }
                        set { _namespaces = value; }
                }

                /// <summary>
                /// 节点名称
                /// </summary>
                public string NodeName
                {
                        get
                        {
                                return nodeName;
                        }
                        set
                        {
                                nodeName = value;
                        }
                }

                /// <summary>
                /// 节点编码
                /// </summary>
                public string DWDM
                {
                        get
                        {
                                return dwdm;
                        }
                        set
                        {
                                dwdm = value;
                        }
                }

                /// <summary>
                /// 显示名称
                /// </summary>
                public string DisplayTitle
                {
                        get
                        {
                                return displayTitle;
                        }
                        set
                        {
                                displayTitle = value;
                        }
                }

                /// <summary>
                /// 描述
                /// </summary>
                public string Descript
                {
                        get
                        {
                                return descript;
                        }

                        set
                        {
                                descript = value;
                        }
                }

                /// <summary>
                /// 节点ID
                /// </summary>
                public string ID
                {
                        get { return this.nodeid; }
                        set { this.nodeid = value; }
                }

                public MD_Nodes()
                {
                }

                public MD_Nodes(string _nodename, string _displayTitle, string _dwdm)
                {
                        this.nodeName = _nodename;
                        this.displayTitle = _displayTitle;
                        this.dwdm = _dwdm;
                }

                public MD_Nodes(string _id, string _nodename,string _displayTitle,string _descript,string _dwdm)
                {
                        this.nodeid = _id;
                        this.NodeName = _nodename;
                        this.displayTitle = _displayTitle;
                        this.dwdm = _dwdm;
                        this.descript = _descript;
                }

                public override string ToString()
                {
                        return DisplayTitle;
                }
        }
}
