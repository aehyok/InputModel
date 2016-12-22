using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.MenuType
{
        /// <summary>
        /// 菜单项定义
        /// </summary>
        [Serializable]
        public class SinoMenuItem : IComparable
        {
                private string menuID = "";
                
                /// <summary>
                /// 菜单ID
                /// </summary>
                public string MenuID
                {
                        get { return menuID; }
                        set { menuID = value; }
                }
                private string menuTitle = "";
                /// <summary>
                /// 菜单显示标题
                /// </summary>
                public string MenuTitle
                {
                        get { return menuTitle; }
                        set { menuTitle = value; }
                }

                private int displayOrder = 0;
                /// <summary>
                /// 菜单显示顺序
                /// </summary>
                public int DisplayOrder
                {
                        get { return displayOrder; }
                        set { displayOrder = value; }
                }

                private string fatherID = "";
                /// <summary>
                /// 父菜单ID
                /// </summary>
                public string FatherID
                {
                        get { return fatherID; }
                        set { fatherID = value; }
                }

                
                private string iconName = "";
                /// <summary>
                /// 菜单图标
                /// </summary>
                public string IconName
                {
                        get { return iconName; }
                        set { iconName = value; }
                }
                
                private string menuType = "";
                /// <summary>
                /// 菜单类型
                /// </summary>
                public string MenuType
                {
                        get { return menuType; }
                        set { menuType = value; }
                }
                private string menuParameter = "";
                /// <summary>
                /// 菜单参数名称
                /// </summary>
                public string MenuParameter
                {
                        get { return menuParameter; }
                        set { menuParameter = value; }
                }

                private bool canUse = false;
                /// <summary>
                /// 本菜单是否可用
                /// </summary>
                public bool CanUse
                {
                        get { return canUse; }
                        set { canUse = value; }
                }

                private int level = 0;
                /// <summary>
                /// 级别
                /// </summary>
                public int Level
                {
                        get { return level; }
                        set { level = value; }
                }

                private string iconIndex = "";
                /// <summary>
                /// 图标号
                /// </summary>
                public string IconIndex
                {
                        get { return iconIndex; }
                        set { iconIndex = value; }
                }

                public SinoMenuItem()
                {
                }

                public SinoMenuItem(string _mid, string _mname, string _mtype, string _mparam, int _order, string _fid, bool _canuse, int _level, string _iconIndex,string _iconName)
                {
                        menuID = _mid;
                        menuTitle = _mname;
                        menuType = _mtype;
                        menuParameter = _mparam;
                        displayOrder = _order;
                        fatherID = _fid;
                        canUse = _canuse;
                        level = _level;
                        iconIndex = _iconIndex;
                        iconName = _iconName;
                }

                #region IComparable Members

                public int CompareTo(object obj)
                {
                        SinoMenuItem _item = obj as SinoMenuItem;
                        return this.displayOrder - _item.displayOrder;
                }

                #endregion
        }
}
