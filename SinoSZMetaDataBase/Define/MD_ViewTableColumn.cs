using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_ViewTableColumn : MD_TableColumn
        {
                private bool _canModify;
                private bool _canShowAsCondition;
                private bool _canShowAsResult;
                private bool _defaultResult;
                private string _dwdm;
                private bool _isFixQueryItem;
                private MD_ViewTable _viewTable;
                private string _viewTableColumnID;
                private int _priority;

                public MD_ViewTableColumn(string _vtcid, string _vtid, string _tcid, bool _cancondi, bool _canres, bool _defaultshow,
                        bool _isfixitem, bool _canmodify, string _dw, int _prio)
                {
                        _viewTableColumnID = _vtcid;
                        _viewTable = new MD_ViewTable();
                        _viewTable.ViewTableID = _vtid;
                        _columnID = _tcid;
                        _canShowAsCondition = _cancondi;
                        _canShowAsResult = _canres;
                        _defaultResult = _defaultshow;
                        _isFixQueryItem = _isfixitem;
                        _canModify = _canmodify;
                        _dwdm = _dw;
                        _priority = _prio;
                }


                public MD_ViewTableColumn(string _tcid, string _tid, string _cname, bool _isnull, string _ctype, int _preci,
                        int _sca, int _len, string _refd, string _dmblevel, int _secretlevel, string _displaytitle,
                        string _displayformat, int _displaylength, int _displayheight, int _displayorder, bool _candisplay,
                        int _colwidth, string _dw, string _tag, string _refword, string _vtcid, bool _cancondi, bool _canres,
                        bool _defaultshow, bool _isfixitem, bool _canmodify, int _prio)
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
                        _displayTitle = _displaytitle;
                        _displayFormat = _displayformat;
                        _displayLength = _displaylength;
                        _displayHeight = _displayheight;
                        _displayOrder = _displayorder;
                        _canDisplay = _candisplay;
                        _colWidth = _colwidth;
                        _dwdm = _dw;
                        _ctag = _tag;
                        _refWordTableName = _refword;
                        _viewTableColumnID = _vtcid;
                        _canModify = _canmodify;
                        _canShowAsCondition = _cancondi;
                        _canShowAsResult = _canres;
                        _defaultResult = _defaultshow;
                        _isFixQueryItem = _isfixitem;
                        _priority = _prio;


                }


                /// <summary>
                /// ȡ��Ӧ�ı�ID
                /// </summary>
                public string TID
                {
                        get { return _tableID; }
                }

                /// <summary>
                /// ���ֶ����ڵ���ͼ��
                /// </summary>
                public MD_ViewTable ViewTable
                {
                        get
                        {
                                return _viewTable;
                        }
                        set
                        {
                                _viewTable = value;
                        }
                }

                /// <summary>
                /// ���ֶε�ID
                /// </summary>
                public string ViewTableColumnID
                {
                        get
                        {
                                return _viewTableColumnID;
                        }
                        set
                        {
                                _viewTableColumnID = value;
                        }
                }

                /// <summary>
                /// �Ƿ����Ϊ��ѯ������ʾ
                /// </summary>
                public bool CanShowAsCondition
                {
                        get
                        {
                                return _canShowAsCondition;
                        }
                        set
                        {
                                _canShowAsCondition = value;
                        }
                }

                /// <summary>
                /// �Ƿ����Ϊ��ѯ�����ʾ
                /// </summary>
                public bool CanShowAsResult
                {
                        get
                        {
                                return _canShowAsResult;
                        }
                        set
                        {
                                _canShowAsResult = value;
                        }
                }

                /// <summary>
                /// �Ƿ�ΪĬ�Ͻ����
                /// </summary>
                public bool DefaultResult
                {
                        get
                        {
                                return _defaultResult;
                        }
                        set
                        {
                                _defaultResult = value;
                        }
                }

                /// <summary>
                /// �Ƿ�Ϊ�̶���ѯ�ֶ�
                /// </summary>
                public bool IsFixQueryItem
                {
                        get
                        {
                                return _isFixQueryItem;
                        }
                        set
                        {
                                _isFixQueryItem = value;
                        }
                }

                /// <summary>
                /// �Ƿ�����޸ģ�ֻ����������͵�VIEW��
                /// </summary>
                public bool CanModify
                {
                        get
                        {
                                return _canModify;
                        }
                        set
                        {
                                _canModify = value;
                        }
                }

                /// <summary>
                /// �ڵ���
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
                /// ��ʾ˳��
                /// </summary>
                public int DisplayOrder
                {
                        get
                        {
                                return this._displayOrder;
                        }
                        set
                        {
                                this._displayOrder = value;
                        }
                }

                /// <summary>
                /// ��ѯ����Ȩ(��ֵԽС��Խ��)
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
        }
}
