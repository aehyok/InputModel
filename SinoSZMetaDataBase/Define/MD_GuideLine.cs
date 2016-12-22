using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_GuideLine
        {
                private MD_GuideLineGroup _guideLineGroup = null;
                private string _id = "";
                private string _guideLineName = "";
                private string _groupName = "";
                private string _guideLineMethod = "";
                private string _guideLineMeta = "";
                private string _fid = "";
                private string _guideLineQueryMethod = "";
                private string _detailMeta = "";
                private int _displayOrder = 0;
                private IList<MD_GuideLine> _childGuideLines = new List<MD_GuideLine>();
                private string _description = "";

                public string Description
                {
                        get { return _description; }
                        set { _description = value; }
                }




                public MD_GuideLine()
                {
                }

                public MD_GuideLine(string id, string glName, string groupName, string glMethod, string glMeta, string fid, string glQueryMethod,
                        string detailMeta, int order,string _des)
                {
                        _id = id;
                        _guideLineName = glName;
                        _groupName = groupName;
                        _guideLineMethod = glMethod ;
                        _guideLineMeta = glMeta + detailMeta;
                        _fid = fid;
                        _guideLineQueryMethod = glQueryMethod;
                        _detailMeta = detailMeta;
                        _displayOrder = order;
                        this._description = _des;
                }

                public IList<MD_GuideLine> ChildGuideLines
                {
                        get { return _childGuideLines; }
                        set { _childGuideLines = value; }
                }

                public MD_GuideLineGroup MD_GuideLineGroup
                {
                        get
                        {
                                return _guideLineGroup;
                        }
                        set
                        {
                                _guideLineGroup = value;
                        }
                }

                public string ID
                {
                        get
                        {
                                return _id;
                        }
                        set
                        {
                                _id = value;
                        }
                }

                public string GuideLineName
                {
                        get
                        {
                                return _guideLineName;
                        }
                        set
                        {
                                _guideLineName = value;
                        }
                }

                public string GroupName
                {
                        get
                        {
                                return _groupName;
                        }
                        set
                        {
                                _groupName = value;
                        }
                }

                public string GuideLineMethod
                {
                        get
                        {
                                return _guideLineMethod;
                        }
                        set
                        {
                                _guideLineMethod = value;
                        }
                }

                public string GuideLineMeta
                {
                        get
                        {
                                return _guideLineMeta;
                        }
                        set
                        {
                                _guideLineMeta = value;
                        }
                }

                public string FatherID
                {
                        get
                        {
                                return _fid;
                        }
                        set
                        {
                                _fid = value;
                        }
                }

                public string GuideLineQueryMethod
                {
                        get
                        {
                                return _guideLineQueryMethod;
                        }
                        set
                        {
                                _guideLineQueryMethod = value;
                        }
                }

                public string DetailMeta
                {
                        get
                        {
                                return _detailMeta;
                        }
                        set
                        {
                                _detailMeta = value;
                        }
                }

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

                public override string ToString()
                {
                        return _guideLineName;
                }

        }
}
