using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.RefCode
{
        [Serializable]
        public class RefCodeData
        {
                private string code = "";
                private string diplayTitle = "";
                private string pyzt = "";
                private int order = 0;
                private bool isEffective = true;
                private string note = "";
                private string fatherCode = "";
                private bool canShow = true;
                private bool canInput = true;
                private bool isLeaves = true;
                private bool haveChilds = false;

                public RefCodeData(string _code, string _title, string _pyzt, int _order, bool _isEffective, string _note,
                                        string _fcode, bool _canShow, bool _canInput, bool _isLeaves)
                {
                        code = _code;
                        diplayTitle = _title;
                        pyzt = _pyzt;
                        order = _order;
                        isEffective = _isEffective;
                        note = _note;
                        fatherCode = _fcode;
                        canShow = _canShow;
                        canInput = _canInput;
                        isLeaves = _isLeaves;                        
                }

                private List<RefCodeData> _childData = new List<RefCodeData>();

                public List<RefCodeData> ChildData
                {
                        get { return _childData;}
                        set { _childData = value;}
                }

                public bool HaveChilds
                {
                        get { return haveChilds;}
                        set { haveChilds = value;}
                }

                public string Note
                {
                        get { return note;}
                        set { note = value;}
                }

                public string FatherCode
                {
                        get { return fatherCode;}
                        set { fatherCode = value;}
                }

                public bool CanShow
                {
                        get { return canShow;}
                        set { canShow = value;}
                }

                public bool CanInput
                {
                        get { return canInput;}
                        set { canInput = value;}
                }

                public bool IsLeaves
                {
                        get { return isLeaves;}
                        set { isLeaves = value;}
                }

                public string Code
                {
                        get { return code; }
                        set { code = value; }
                }

                public string DisplayTitle
                {
                        get { return diplayTitle;}
                        set { diplayTitle = value;}
                }

                public string PYZT
                {
                        get { return pyzt; }
                        set { pyzt = value; }
                }

                public int Order
                {
                        get { return order; }
                        set { order = value; }
                }

                public bool IsEffective
                {
                        get { return isEffective; }
                        set { isEffective = value; }
                }
             
        }
}
