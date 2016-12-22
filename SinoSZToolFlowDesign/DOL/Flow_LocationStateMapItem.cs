using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZToolFlowDesign.DOL
{
        /// <summary>
        /// 位置与状态对应项
        /// </summary>
        [Serializable]
        public class Flow_LocationStateMapItem
        {
                private string id ;
                private Flow_StateDefine state ;
                private Flow_Location location ;
                private decimal type ;                       
                private string showMeta ;

                /// <summary>
                /// 主键
                /// </summary>
                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }

                /// <summary>
                /// 状态定义
                /// </summary>
                public Flow_StateDefine State
                {
                        get { return state; }
                        set { state = value; }
                }

                /// <summary>
                /// 位置定义
                /// </summary>
                public Flow_Location Location
                {
                        get { return location; }
                        set { location = value; }
                }
                public decimal Type
                {
                        get { return type; }
                        set { type = value; }
                }
                /// <summary>
                /// 类型　　1:操作　　2:显示
                /// </summary>
                public string ShowMeta
                {
                        get { return showMeta; }
                        set { showMeta = value; }
                }

             

                public Flow_LocationStateMapItem(string _id, Flow_StateDefine _state, Flow_Location _location, decimal _type, string _meta)
                {
                        id = _id;
                        state = _state;
                        location = _location;
                        type = _type;
                        showMeta = _meta;
                }

        }
}
