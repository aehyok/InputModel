using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_RefTable
        {
                private MD_Namespace _namespace;
                private string _namespaceName;
                private string _refTableName;
                private string _levelFormat;
                private string _description;
                private string _dwdm;
                private MDType_RefDownloadMode _refDownloadMode = MDType_RefDownloadMode.FullDownload;
                private MDType_RefParamMode _refParamMode = MDType_RefParamMode.Normal;
                private bool _hideCode = false;

                private string _rtid;
                public MD_RefTable()
                {
                }

                public MD_RefTable(string _id, string _ns, string _refName, string _format, string _des, string _dw, int _downMode, int _paramMode, bool _hide)
                {
                        _rtid = _id;
                        _namespaceName = _ns;
                        _refTableName = _refName;
                        _levelFormat = _format;
                        _description = _des;
                        _dwdm = _dw;
                        _hideCode = _hide;
                        _refDownloadMode = (_downMode > 1) ? MDType_RefDownloadMode.LevelDownload : MDType_RefDownloadMode.FullDownload;
                        _refParamMode = (_paramMode > 1) ? MDType_RefParamMode.UserParam : MDType_RefParamMode.Normal;
                }

                public bool HideCode
                {
                        get
                        {
                                return _hideCode;
                        }
                        set
                        {
                                _hideCode = value;
                        }
                }

                public string NamespaceName
                {
                        get { return _namespaceName; }
                        set { _namespaceName = value; }
                }


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


                public string RefTableID
                {
                        get { return _rtid; }
                        set { _rtid = value; }
                }

                public string RefTableName
                {
                        get
                        {
                                return _refTableName;
                        }
                        set
                        {
                                _refTableName = value;
                        }
                }

                /// <summary>
                /// 分级格式
                /// </summary>
                public string LevelFormat
                {
                        get
                        {
                                return _levelFormat;
                        }
                        set
                        {
                                _levelFormat = value;
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

                public MDType_RefDownloadMode RefDownloadMode
                {
                        get
                        {
                                return _refDownloadMode;
                        }
                        set
                        {
                                _refDownloadMode = value;
                        }
                }

                public MDType_RefParamMode RefParamMode
                {
                        get
                        {
                                return _refParamMode;
                        }
                        set
                        {
                                _refParamMode = value;
                        }
                }

                public override string ToString()
                {
                        return (_description == "") ? _refTableName : _description;
                }
        }
}
