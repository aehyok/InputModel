using System;
using System.Collections;
using System.Collections.Generic;

namespace SinoSZBaseClass.Authorize
{
        /// <summary>
        /// SinoPost 用户的岗位定义 
        /// </summary>
        [Serializable()]
        public class SinoPost
        {
                /// <summary>
                /// 此岗位的角色列表
                /// </summary>
                public List<SinoRole> Roles = new List<SinoRole>();
                /// <summary>
                /// 此岗位的权限列表
                /// </summary>               
                public Dictionary<string, UserRightItem> Rights = new Dictionary<string, UserRightItem>();
                /// <summary>
                /// 是否默认岗位
                /// </summary>
                public bool IsDefaultPost = false;
                /// <summary>
                /// 岗位ID
                /// </summary>
                public string PostID = "";
                /// <summary>
                /// 岗位名称
                /// </summary>
                public string PostName = "";
                /// <summary>
                /// 岗位所在的单位ID
                /// </summary>
                public string PostDwID = "";
                /// <summary>
                /// 岗位权限所在单位代码
                /// </summary>
                public string PostDWDM = "";
                /// <summary>
                /// 岗位所在的单位名称
                /// </summary>
                public string PostDWMC = "";
                /// <summary>
                /// 权限所在单位的GUID
                /// </summary>
                public string PostDWGUID = "";
                /// <summary>
                /// 安全级别
                /// </summary>
                public int SecretLevel = 0;
                /// <summary>
                /// 岗位描述
                /// </summary>
                public string PostDescript = "";

                public SinoPost()
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                }

                public SinoPost(string _gwmc, string _gwid, string _gwdwid, string _dwmc, string _dwdm, string _gwms, int _secretLevel, bool _sfmr)
                {
                        this.PostName = _gwmc;
                        this.PostID = _gwid;
                        this.PostDwID = _gwdwid;
                        this.PostDWMC = _dwmc;
                        this.PostDWDM = _dwdm;
                        this.PostDescript = _gwms;
                        this.IsDefaultPost = _sfmr;
                        this.SecretLevel = _secretLevel;
                }
        }
}
