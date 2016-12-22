using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_GuideLineFieldName
        {
                private string _fieldName = "";
                private string _displayTitle = "";
                private int _displayOrder = 0;
                private int _displayWidth = 100;
                private string  _textAlign = "LEFT";
                private string _displayFormat = "";
                private bool _canHide = false;
                public MD_GuideLineFieldName()
                {
                }

                public MD_GuideLineFieldName(string _fname, string _title, int _order, int _width, string _align,string _format,bool _hide)
                {
                        _fieldName = _fname;
                        _displayTitle = _title;
                        _displayOrder = _order;
                        _displayWidth = _width;
                        _textAlign = _align;
                        _displayFormat = _format;
                        _canHide = _hide;
                }

                /// <summary>
                /// 本字段是否可隐藏
                /// </summary>
                public bool CanHide
                {
                        get { return _canHide; }
                        set { _canHide = value; }
                }

                /// <summary>
                /// 显示格式
                /// </summary>
                public string DisplayFormat
                {
                        get { return _displayFormat; }
                        set { _displayFormat = value; }
                }

                /// <summary>
                /// 字段名称
                /// </summary>
                public string FieldName
                {
                        get
                        {
                                return _fieldName;
                        }
                        set
                        {
                                _fieldName = value;
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
                /// 显示宽度
                /// </summary>
                public int DisplayWidth
                {
                        get
                        {
                                return _displayWidth;
                        }
                        set
                        {
                                _displayWidth = value;
                        }
                }

                /// <summary>
                /// 是否居中
                /// </summary>
                public string TextAlign
                {
                        get
                        {
                                return _textAlign;
                        }
                        set
                        {
                                _textAlign = value;
                        }
                }
        }
}
