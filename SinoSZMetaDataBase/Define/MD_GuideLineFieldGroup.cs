using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_GuideLineFieldGroup
        {
                private string _groupName = "";
                private string _displayTitle = "";
                private string _textAlign = "";
                private int _displayOrder = 0;
                private bool _canHide = false;
                private string _defaultStatus = "SHOW";
                private List<MD_GuideLineFieldName> _fields = new List<MD_GuideLineFieldName>();

                public MD_GuideLineFieldGroup() { }

                public MD_GuideLineFieldGroup(string _name, string _title, string _align, int _order, bool _hide, string _status)
                {
                        _groupName = _name;
                        _displayTitle = _title;
                        _textAlign = _align;
                        _displayOrder = _order;
                        _canHide = _hide;
                        _defaultStatus = _status;
                }

                /// <summary>
                /// 字段组下包含的显示字段列表
                /// </summary>
                public List<MD_GuideLineFieldName> Fields
                {
                        get { return _fields; }
                        set { _fields = value; }
                }
                /// <summary>
                /// 字段组名称
                /// </summary>
                public string GroupName
                {
                        get { return _groupName; }
                        set { _groupName = value; }
                }

                /// <summary>
                /// 显示标题
                /// </summary>
                public string DisplayTitle
                {
                        get { return _displayTitle; }
                        set { _displayTitle = value; }
                }

                /// <summary>
                /// 字段对齐
                /// </summary>
                public string TextAlign
                {
                        get { return _textAlign; }
                        set { _textAlign = value; }
                }

                /// <summary>
                /// 显示顺序
                /// </summary>
                public int DisplayOrder
                {
                        get { return _displayOrder; }
                        set { _displayOrder = value; }
                }

                /// <summary>
                /// 是否可隐藏
                /// </summary>
                public bool CanHide
                {
                        get { return _canHide; }
                        set { _canHide = value; }
                }

                /// <summary>
                /// 默认状态　　HIDE:隐藏　SHOW:显示
                /// </summary>
                public string DefaultStatus
                {
                        get { return _defaultStatus; }
                        set { _defaultStatus = value; }
                }


        }
}
