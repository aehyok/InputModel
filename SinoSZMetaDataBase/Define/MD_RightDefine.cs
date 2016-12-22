using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        /// <summary>
        /// 权限定义
        /// </summary>
        [Serializable]
        public class MD_RightDefine
        {
                /// <summary>
                /// 权限ID
                /// </summary>
                public string RightID = "";
                /// <summary>
                /// 父权限ID
                /// </summary>
                public string FatherRightID = "";
                /// <summary>
                /// 权限名称
                /// </summary>
                public string RightName = "";
                /// <summary>
                /// 权限描述
                /// </summary>
                public string RightDescript = "";
                /// <summary>
                /// 权限类型
                /// </summary>
                public string RightType = "";
                /// <summary>
                /// 权限的META
                /// </summary>
                public string RightMeta = "";
                /// <summary>
                /// 显示序号
                /// </summary>
                public int DisplayOrder = 0;
                /// <summary>
                /// 对应的菜单ID
                /// </summary>
                public string MenuID = "";

                public MD_RightDefine() { }
                public MD_RightDefine(string _id, string _fid, string _rname, string _des, string _type, string _meta, int _order, string _menuid)
                {
                        RightID = _id;
                        FatherRightID = (_fid=="-1")?"":_fid;
                        RightName = _rname;
                        RightType = _type;
                        RightDescript = _des;
                        RightMeta = _meta;
                        DisplayOrder = _order;
                        MenuID = _menuid;
                }
        }
}
