using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        /// <summary>
        /// 指标查询参数
        /// </summary>
        [Serializable]
        public class MD_GuideLineParameter
        {
                private string _parameterName = "";
                private string _displayTitle = "";
                private string _parameterType = "";
                private int _displayOrder = 0;
                private int _inputWidth = 200;
                private string _defaultValue = "";
                private string _refTableName = "";
                private bool _includeChildren = false;
                private string _secelctAllCode = "";

                /// <summary>
                /// 全部的代码
                /// </summary>
                public string SelecteAllCode
                {
                        get { return _secelctAllCode; }
                        set { _secelctAllCode = value; }
                }

                /// <summary>
                /// 是否可以选"全部"
                /// </summary>
                public bool CanSelectAll
                {
                        get
                        {
                                return (_secelctAllCode != "");
                        }
                }

                /// <summary>
                /// 当为代码表时,查询代码是否要求包含下级
                /// </summary>
                public bool IncludeChildren
                {
                        get { return _includeChildren; }
                        set { _includeChildren = value; }
                }


                /// <summary>
                /// 代码表名称
                /// </summary>
                public string RefTableName
                {
                        get { return _refTableName; }
                        set { _refTableName = value; }
                }
                /// <summary>
                /// 默认参数值
                /// </summary>
                public string DefaultValue
                {
                        get { return _defaultValue; }
                        set { _defaultValue = value; }
                }

                /// <summary>
                /// 参数名称
                /// </summary>
                public string ParameterName
                {
                        get { return _parameterName; }
                        set { _parameterName = value; }
                }

                /// <summary>
                /// 显示名称
                /// </summary>
                public string DisplayTitle
                {
                        get { return _displayTitle; }
                        set { _displayTitle = value; }
                }

                /// <summary>
                /// 录入框长度
                /// </summary>
                public int InputWidth
                {
                        get { return _inputWidth; }
                        set { _inputWidth = value; }
                }
                /// <summary>
                /// 参数显示顺序
                /// </summary>
                public int DisplayOrder
                {
                        get { return _displayOrder; }
                        set { _displayOrder = value; }
                }

                /// <summary>
                /// 参数类型
                /// </summary>
                public string ParameterType
                {
                        get { return _parameterType; }
                        set { _parameterType = value; }
                }


                public MD_GuideLineParameter()
                {
                }

                public MD_GuideLineParameter(string pname, string title, string ptype, int order, int inputWidth,string refTable,bool includeChildren,string selectAllCode)
                {
                        _parameterName = pname;
                        _displayTitle = title;
                        _parameterType = ptype;
                        _displayOrder = order;
                        _inputWidth = inputWidth;
                        _refTableName = refTable;
                        _includeChildren = includeChildren;
                        _secelctAllCode = selectAllCode;
                }

                public MD_GuideLineParameter(string pname, string title, string ptype, int order, string defaultValue, int inputWidth, string refTable, bool includeChildren,string selectAllCode)
                {
                        _parameterName = pname;
                        _displayTitle = title;
                        _parameterType = ptype;
                        _displayOrder = order;
                        _defaultValue = defaultValue;
                        _inputWidth = inputWidth;
                        _refTableName = refTable;
                        _includeChildren = includeChildren;
                        _secelctAllCode = selectAllCode;
                }


        }
}
