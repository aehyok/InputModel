using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        /// <summary>
        /// 概念组
        /// </summary>
        [Serializable]
        public class MD_ConceptGroup
        {
                private string name = "";             　    //概念组名称
                private string description = "";            //描述
                private string dwdm = "";                   //节点代码,指系统所安装的服务器所在的单位编码,可用于区分节点
                private int displayOrder = 0;               //显示顺序
                private List<MD_ConceptItem> items = new List<MD_ConceptItem>();

                public MD_ConceptGroup() { }
                public MD_ConceptGroup(string _name, string _des, string _dwdm, int _order)
                {
                        name = _name;
                        description = _des;
                        dwdm = _dwdm;
                        displayOrder = _order;
                }
                /// <summary>
                /// 概念组名称
                /// </summary>
                public string Name
                {
                        get { return name; }
                        set { name = value; }
                }
                /// <summary>
                /// 组描述
                /// </summary>
                public string Description
                {
                        get { return description; }
                        set { description = value; }
                }
                /// <summary>
                /// 此概念属于的节点代码
                /// </summary>
                public string DWDM
                {
                        get { return dwdm; }
                        set { dwdm = value; }
                }
                /// <summary>
                /// 显示顺序
                /// </summary>
                public int DisplayOrder
                {
                        get { return displayOrder; }
                        set { displayOrder = value; }
                }

                /// <summary>
                /// 组中包含的概念
                /// </summary>
                public List<MD_ConceptItem> Items
                {
                        get { return items; }
                        set { items = value; }
                }

                public override string ToString()
                {
                        return string.Format("{0}",Name,description);
                }
        }
}
