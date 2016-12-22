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
                /// ���ֶ����ڵı�
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
                /// ���ֶε�ID
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
                /// �ֶ�����
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
                /// �ֶο��
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
                /// �ֶΰ����ĸ���
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
                /// ��ʾ��ʽ
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
                /// ��ʾ�и߶�
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
                /// ��ʾ����
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
                /// ��ʾ˳��
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
                /// ��ʾ����
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
                /// �����ּ�ģʽ
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
                /// �ڵ���
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
                /// �����Ƿ����Ϊ��
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
                /// �ֶγ���
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
                /// ���������
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
                /// ��Ӧ���ñ�����
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
                /// ��ȫ����
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
                /// �ֶ�����
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
                /// ��Ӧ�������
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
                /// �Ƿ���ʾ
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
