using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZToolFlowDesign.DOL
{
        /// <summary>
        /// 流程基本属性定义
        /// </summary>
        [Serializable]
        public class Flow_BaseDefine
        {
                private string id;
                private string flowName;
                private string description;
                private string rootDWID;

                public string RootDWID
                {
                        get { return rootDWID; }
                        set { rootDWID = value; }
                }


                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }

                public string FlowName
                {
                        get { return flowName; }
                        set { flowName = value; }
                }

                public string Description
                {
                        get
                        {
                                return description;
                        }
                        set { description = value; }
                }

           

                public Flow_BaseDefine(string _id, string _name, string _description, string _rootdwid)
                {
                        this.ID = _id;
                        this.FlowName = _name;
                        this.Description = _description;
                        this.RootDWID = _rootdwid;
                }

        }
}
