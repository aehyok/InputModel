using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_ConceptItem
        {
                private string cTag = "";                     //标签名
                private string description = "";            //描述
                private string groupName = "";          //概念组名称
                private string cRule = "";                     //规则
                private string dwdm = "";                   //节点代码,指系统所安装的服务器所在的单位编码,可用于区分节点
                private int displayOrder = 0;               //显示顺序

                public MD_ConceptItem() { }

                public MD_ConceptItem(string _ctag, string _des, string _groupname, string _crule, string _dwdm, int _order)
                {
                        this.cTag = _ctag;
                        this.description = _des;
                        this.groupName = _groupname;
                        this.cRule = _crule;
                        this.dwdm = _dwdm;
                        this.displayOrder = _order;
                }
                /// <summary>
                /// 描述
                /// </summary>
                public string Description
                {
                        get { return description; }
                        set { description = value; }
                }

                /// <summary>
                /// 组名称
                /// </summary>
                public string GroupName
                {
                        get { return groupName; }
                        set { groupName = value; }
                }

                /// <summary>
                /// 规则
                /// </summary>
                public string CRule
                {
                        get { return cRule;}
                        set { cRule = value;
                        }

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
                /// 概念标签　
                /// </summary>
                public string CTag
                {
                        get { return cTag; }
                        set { cTag = value; }
                }

                /// <summary>
                /// 此概念属于的节点代码
                /// </summary>
                public string DWDM
                {
                        get { return dwdm; }
                        set { dwdm = value; }
                }

                public override string ToString()
                {
                        return string.Format("{0}", cTag, description);
                }
        }
}
