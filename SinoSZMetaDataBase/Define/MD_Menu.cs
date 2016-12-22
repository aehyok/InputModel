using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_Menu
        {
                private MD_Nodes _nodes = null;
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


                private string _menuID = "";
                public string MenuID
                {
                        get
                        {
                                return _menuID;
                        }
                        set
                        {
                                _menuID = value;
                        }
                }

                private string _menuName = "";
                public string MenuName
                {
                        get
                        {
                                return _menuName;
                        }
                        set
                        {
                                _menuName = value;
                        }
                }

                private string _menuType = "";
                public string MenuType
                {
                        get
                        {
                                return _menuType;
                        }
                        set
                        {
                                _menuType = value;
                        }
                }

                private string _menuParameter = "";
                public string MenuParameter
                {
                        get
                        {
                                return _menuParameter;
                        }
                        set
                        {
                                _menuParameter = value;
                        }
                }

                private int _displayOrder = 0;
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

                private string _fatherMenuID = "";
                public string FatherMenuID
                {
                        get
                        {
                                return _fatherMenuID;
                        }
                        set
                        {
                                _fatherMenuID = value;
                        }
                }

                private string _menuToolTip = "";
                public string MenuToolTip
                {
                        get
                        {
                                return _menuToolTip;
                        }
                        set
                        {
                                _menuToolTip = value;
                        }
                }

                private string _menuIcon = "";
                public string MenuIcon
                {
                        get
                        {
                                return _menuIcon;
                        }
                        set
                        {
                                _menuIcon = value;
                        }
                }

                private bool _showInToolBar = false;
                public bool ShowInToolBar
                {
                        get
                        {
                                return _showInToolBar;
                        }
                        set
                        {
                                _showInToolBar = value;
                        }
                }

                private string _nodeID = "";
                public string NodeID
                {
                        get
                        {
                                return _nodeID;
                        }
                        set
                        {
                                _nodeID = value;
                        }
                }

                public MD_Menu()
                {
                }

                public MD_Menu(string _mid, string _mname, string _mtype, string _mparam, int _order, 
                                string _fmid, string _mtooltip, string _micon, bool _showintoolbar, string _nodeid)
                {
                        this._menuID = _mid;
                        this._menuName = _mname;
                        this.MenuType = _mtype;
                        this.MenuParameter = _mparam;
                        this.DisplayOrder = _order;
                        this._fatherMenuID = _fmid;
                        this._menuToolTip = _mtooltip;
                        this._menuIcon = _micon;
                        this._showInToolBar = _showintoolbar;
                        this._nodeID = _nodeid;
                }

                public override string ToString()
                {
                        return MenuName;
                }
        }
}
