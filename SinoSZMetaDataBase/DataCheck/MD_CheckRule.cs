using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.DataCheck
{
        [Serializable]
        public class MD_CheckRule
        {
                private string _id = "";
                private string _queryModelName = "";
                private string _ruleName = "";
                private string _methodDefine = "";
                private string _dwdm = "";
                private bool _state = false;

                public MD_CheckRule() { }
                public MD_CheckRule(string _rid, string _qv, string _name, string _define, string _dw, bool _used)
                {
                        _id = _rid;
                        _queryModelName = _qv;
                        _ruleName = _name;
                        _methodDefine = _define;
                        _dwdm = _dw;
                        _state = _used;
                }

                public bool State
                {
                        get { return _state; }
                        set { _state = value; }
                }

                public string ID
                {
                        get { return _id; }
                        set { _id = value; }
                }

                public string QueryModelName
                {
                        get { return _queryModelName; }
                        set { _queryModelName = value; }
                }

                public string RuleName
                {
                        get { return _ruleName; }
                        set { _ruleName = value; }
                }

                public string MethodDefine
                {
                        get { return _methodDefine; }
                        set { _methodDefine = value; }
                }

                public string DWDM
                {
                        get { return _dwdm; }
                        set
                        {
                                _dwdm = value;
                        }
                }

        }
}
