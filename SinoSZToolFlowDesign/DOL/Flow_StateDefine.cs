using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZToolFlowDesign.DOL
{
        [Serializable]
        public class Flow_StateDefine : ICloneable
        {
                private string id;
                private string name ;
                private string displayName ;
                private string description ;
                private string type ;
                private int order ;

                public int Order
                {
                        get { return order; }
                        set { order = value; }
                }

                public string ID
                {
                        get { return id; }
                        set { this.id = value; }
                }

                public string Name
                {
                        get { return name; }
                        set { name = value; }
                }

                public string DisplayName
                {
                        get { return displayName; }
                        set { displayName = value; }
                }

                public string Description
                {
                        get { return description; }
                        set { description = value; }
                }

                public string Type
                {
                        get { return type; }
                        set { type = value; }
                }

                
                public Flow_StateDefine(string _id, string _name, string _displayName, string _description, string _type,int _order)
                {
                        this.ID = _id;
                        this.Name = _name;
                        this.DisplayName = _displayName;
                        this.Description = _description;
                        this.Type = _type;
                        this.Order = _order;
                }



                #region ICloneable Members

                public object Clone()
                {
                        return new Flow_StateDefine(this.id, this.name, this.displayName, this.description, this.type, this.order);
                }

                #endregion
        }
}
