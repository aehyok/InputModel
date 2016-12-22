using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_GuideLineDetailDefine
        {
                public MD_GuideLineDetailDefine()
                {
                }

                public MD_GuideLineDetailDefine(string _fname, string _type, string _qid, string _qcs)
                {
                        _targetFieldName = _fname;
                        _queryDetailType = _type;
                        _detailMethodId = _qid;
                        _detailParameterMeta = _qcs;
                }

                private string _targetFieldName = "";
                public string TargetFieldName
                {
                        get
                        {
                                return _targetFieldName;
                        }
                        set
                        {
                                _targetFieldName = value;
                        }
                }

                private string _queryDetailType = "";
                public string QueryDetailType
                {
                        get
                        {
                                return _queryDetailType;
                        }
                        set
                        {
                                _queryDetailType = value;
                        }
                }

                private string _detailMethodId = "";
                public string DetailMethodID
                {
                        get
                        {
                                return _detailMethodId;
                        }
                        set
                        {
                                _detailMethodId = value;
                        }
                }

                private string _detailParameterMeta = "";
                public string DetailParameterMeta
                {
                        get
                        {
                                return _detailParameterMeta;
                        }
                        set
                        {
                                _detailParameterMeta = value;
                        }
                }
        }
}
