using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_GuideLineGroup
        {
                private MD_Nodes _nodes = null;
                private string _ssdw = "";
                private string _zbztmc = "";
                private string _zbztsm = "";
                private string _namespaceName = "";
                private int _lx = 0;
                private int _qxlx = 0;
                private IList<MD_GuideLine> _childGuideLines = new List<MD_GuideLine>();


                public MD_GuideLineGroup()
                {
                }

                
                public MD_GuideLineGroup(string _ztmc, string _ztsm, string _nsName, string ssdw, int lx, int qxlx)
                {
                        this._ssdw = ssdw;
                        this._zbztmc = _ztmc;
                        this._zbztsm = _ztsm;
                        this._namespaceName = _nsName;
                        this._lx = lx;
                        this._qxlx = qxlx;
                }

                public IList<MD_GuideLine> ChildGuideLines
                {
                        get { return _childGuideLines; }
                        set { _childGuideLines = value; }
                }

                public MD_Nodes MD_Nodes
                {
                        get
                        {
                                return _nodes;
                        }
                        set
                        {
                                _nodes = value;
                        }
                }

                public string SSDW
                {
                        get
                        {
                                return _ssdw;
                        }
                        set
                        {
                                _ssdw = value;
                        }
                }

                public string ZBZTMC
                {
                        get
                        {
                                return _zbztmc;
                        }
                        set
                        {
                                _zbztmc = value;
                        }
                }

                public string ZBZTSM
                {
                        get
                        {
                                return _zbztsm;
                        }
                        set
                        {
                                _zbztsm = value;
                        }
                }

                public int LX
                {
                        get
                        {
                                return _lx;
                        }
                        set
                        {
                                _lx = value;
                        }
                }

                public int QXLX
                {
                        get
                        {
                                return _qxlx;
                        }
                        set
                        {
                                _qxlx = value;
                        }
                }

                public string NamespaceName
                {
                        get
                        {
                                return _namespaceName;
                        }
                        set
                        {
                                _namespaceName = value;
                        }
                }

                public override string ToString()
                {
                        return this._zbztmc;
                }
        }

        
}
