using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_TableColumn
        {
                internal MD_Table _table;
                internal string _tableID;
                internal string _columnID;
                internal string _columnName;
                internal bool _isNullable;
                internal string _columnType;
                internal int _precision;
                internal int _scale;
                internal int _length;
                internal string _refDMB="";
                internal string _dmbLevelFormat;
                internal int _secretLevel;
                internal string _displayTitle;
                internal int _displayOrder;
                internal string _displayFormat;
                internal int _displayLength = 1;
                internal int _displayHeight = 1;
                internal bool _canDisplay;
                internal int _colWidth = 1;
                internal string _dwdm;
                internal string _ctag;
                internal string _refWordTableName;
                internal MD_RefTable _refTable;

                public MD_TableColumn()
                {
                }

                public MD_TableColumn(string _tcid,string _tid,string _cname,bool _isnull,string _ctype,int _preci,
                        int _sca,int _len,string _refd,string _dmblevel,int _secretlevel,string _displaytitle,
                        string _displayformat,int _displaylength,int _displayheight,int _displayorder,bool _candisplay,
                        int _colwidth,string _dw,string _tag,string _refword)
                {
                        _columnID = _tcid;
                        _tableID = _tid;
                        _columnName = _cname;
                        _isNullable = _isnull;
                        _columnType = _ctype;
                        _precision = _preci;
                        _scale = _sca;
                        _length = _len;
                        _refDMB = _refd.ToUpper();
                        _dmbLevelFormat = _dmblevel;
                        _secretLevel = _secretlevel;
                        _displayTitle = _displaytitle.Substring(0,(_displaytitle.Length>50)?50:_displaytitle.Length);
                        _displayFormat = _displayformat;
                        _displayLength = _displaylength;
                        _displayHeight = _displayheight;
                        _displayOrder = _displayorder;
                        _canDisplay = _candisplay;
                        _colWidth = _colwidth;
                        _dwdm = _dw;
                        _ctag = _tag;
                        _refWordTableName = _refword;                       

                }

                /// <summary>
                /// 本字段所在的表
                /// </summary>
                public MD_Table Table
                {
                        get
                        {
                                return _table;
                        }
                        set
                        {
                                _table = value;
                        }
                }

                /// <summary>
                /// 本字段的ID
                /// </summary>
                public string ColumnID
                {
                        get
                        {
                                return _columnID;
                        }
                        set
                        {
                                _columnID = value;
                        }
                }

                /// <summary>
                /// 字段名称
                /// </summary>
                public string ColumnName
                {
                        get
                        {
                                return _columnName;
                        }
                        set
                        {
                                _columnName = value;
                        }
                }

                /// <summary>
                /// 字段宽度
                /// </summary>
                public int ColWidth
                {
                        get
                        {
                                return _colWidth;
                        }
                        set
                        {
                                _colWidth = value;
                        }
                }

                /// <summary>
                /// 字段包含的概念
                /// </summary>
                public string CTag
                {
                        get
                        {
                                return _ctag;
                        }
                        set
                        {
                                _ctag = value;
                        }
                }

                /// <summary>
                /// 显示格式
                /// </summary>
                public string DisplayFormat
                {
                        get
                        {
                                return _displayFormat;
                        }
                        set
                        {
                                _displayFormat = value;
                        }
                }

                /// <summary>
                /// 显示行高度
                /// </summary>
                public int DisplayHeight
                {
                        get
                        {
                                return _displayHeight;
                        }
                        set
                        {
                                _displayHeight = value;
                        }
                }

                /// <summary>
                /// 显示长度
                /// </summary>
                public int DisplayLength
                {
                        get
                        {
                                return _displayLength;
                        }
                        set
                        {
                                _displayLength = value;
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
                /// 代码表分级模式
                /// </summary>
                public string DMBLevelFormat
                {
                        get
                        {
                                return _dmbLevelFormat;
                        }
                        set
                        {
                                _dmbLevelFormat = value;
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
                /// 本字是否可以为空
                /// </summary>
                public bool IsNullable
                {
                        get
                        {
                                return _isNullable;
                        }
                        set
                        {
                                _isNullable = value;
                        }
                }

                /// <summary>
                /// 字段长度
                /// </summary>
                public int Length
                {
                        get
                        {
                                return _length;
                        }
                        set
                        {
                                _length = value;
                        }
                }

                public int Precision
                {
                        get
                        {
                                return _precision;
                        }
                        set
                        {
                                _precision = value;
                        }
                }

                /// <summary>
                /// 代码表名称
                /// </summary>
                public string RefDMB
                {
                        get
                        {
                                return _refDMB;
                        }
                        set
                        {
                                _refDMB = value.ToUpper();
                        }
                }

                /// <summary>
                /// 对应引用表名称
                /// </summary>
                public string RefWordTableName
                {
                        get
                        {
                                return _refWordTableName;
                        }
                        set
                        {
                                _refWordTableName = value;
                        }
                }

                public int Scale
                {
                        get
                        {
                                return _scale;
                        }
                        set
                        {
                                _scale = value;
                        }
                }

                /// <summary>
                /// 安全级别
                /// </summary>
                public int SecretLevel
                {
                        get
                        {
                                return _secretLevel ;
                        }
                        set
                        {
                                _secretLevel = value;
                        }
                }

                /// <summary>
                /// 字段类型
                /// </summary>
                public string ColumnType
                {
                        get
                        {
                                return _columnType;
                        }
                        set
                        {
                                _columnType = value;
                        }
                }

                /// <summary>
                /// 对应代码表定义
                /// </summary>
                internal MD_RefTable RefTable
                {
                        get
                        {
                                return _refTable;
                        }
                        set
                        {
                                _refTable = value;
                        }
                }

                /// <summary>
                /// 是否显示
                /// </summary>
                public bool CanDisplay
                {
                        get
                        {
                                return _canDisplay;
                        }
                        set
                        {
                                _canDisplay = value;
                        }
                }
        }
}
