using System;
using System.Collections;
using System.Collections.Generic;

namespace SinoSZBaseClass.Authorize
{
        /// <summary>
        /// SinoUser 用户定义。
        /// 用户定义项
        /// </summary>
        [Serializable()]
        public class SinoUser
        {
                /// <summary>
                /// 用户具有角色集
                /// </summary>
                public List<SinoRole> Roles = new List<SinoRole>();
                /// <summary>
                /// 用户当前具有的权限集
                /// </summary>
                public Dictionary<string, UserRightItem> CurrentRights
                {
                        get
                        {
                                if (this.currentPost == null)
                                {
                                        return new Dictionary<string, UserRightItem>();
                                }
                                else
                                {
                                        return this.currentPost.Rights;
                                }
                        }
                }
                /// <summary>
                /// 用户具有岗位集
                /// </summary>
                public List<SinoPost> Posts = new List<SinoPost>();
                /// <summary>
                /// 用户默认岗位
                /// </summary>
                private SinoPost defalutPost = null;
                /// <summary>
                /// 用户当前使用的岗位
                /// </summary>
                private SinoPost currentPost = null;
                /// <summary>
                /// 系统编号
                /// </summary>
                public string SystemID = "";
                /// <summary>
                /// 用户类型    值为：1:“海关用户”　或	2:“缉私局用户”
                /// </summary>
                public int UserType = 2;
                /// <summary>
                /// 用户登录名
                /// </summary>
                public string LoginName = "";
                /// <summary>
                /// 用户ID
                /// </summary>		
                public string UserID = "";
                /// <summary>
                /// 用户名称
                /// </summary>
                public string UserName = "";
                //用户的GUID
                public string UserGUID = "";
                /// <summary>
                /// 用户的海关关号
                /// </summary>
                public string UserHGGH = "";
                /// <summary>
                /// 单位ID
                /// </summary>
                public string DwID = "";
                /// <summary>
                /// 单位名称
                /// </summary>
                public string DwName = "";
                /// <summary>
                /// 单位代码
                /// </summary>
                public string Dwdm = "";
                /// <summary>
                /// 单位的GUID
                /// </summary>
                public string DwGUID = "";

                /// <summary>
                /// 权限层级,值为:海关总署级、直属海关级、隶属海关级
                /// </summary>
                public string QxszJB = "";
                /// <summary>
                /// 权限所在单位代码
                /// </summary>		
                public string QxszDWDM
                {
                        get
                        {
                                if (this.currentPost == null)
                                {
                                        return "";
                                }
                                else
                                {
                                        return this.currentPost.PostDWDM;
                                }
                        }
                }
                /// <summary>
                /// 权限所在单位代码
                /// </summary>
                public string QxszDWID
                {
                        get
                        {
                                if (this.currentPost == null)
                                {
                                        return "";
                                }
                                else
                                {
                                        return this.currentPost.PostDwID;
                                }
                        }
                }
                /// <summary>
                /// 权限所在单位名称
                /// </summary>
                public string QxszDWMC
                {
                        get
                        {
                                if (this.currentPost == null)
                                {
                                        return "";
                                }
                                else
                                {
                                        return this.currentPost.PostDWMC;
                                }
                        }
                }
                /// <summary>
                /// 权限所在单位的GUID
                /// </summary>
                public string QxszDWGUID
                {
                        get
                        {
                                if (this.currentPost == null)
                                {
                                        return "";
                                }
                                else
                                {
                                        return this.currentPost.PostDWGUID;
                                }
                        }
                }
                /// <summary>
                /// 用户分局单位ID
                /// </summary>
                public string User_FJID = "";
                /// <summary>
                /// 用户直属局ID
                /// </summary>
                public string User_ZSJID = "";
                /// <summary>
                /// 用户是否广东分署
                /// </summary>
                public bool IsGDFSUser = false;
                /// <summary>
                /// 安全级别
                /// </summary>
                public int SecretLevel = 0;
                /// <summary>
                /// 用户加密票据
                /// </summary>
                public string EncryptedTicket = "";
                /// <summary>
                /// 用户使用的IP地址
                /// </summary>
                public string IPAddress = "";
                /// <summary>
                /// 用户使用的主机名
                /// </summary>
                public string HostName = "";
                /// <summary>
                /// 用户是否验证通过
                /// </summary>
                public bool IsSignOn = false;

                /// <summary>
                /// 用户默认岗位
                /// </summary>
                public SinoPost DefaultPost
                {
                        get
                        {
                                return defalutPost;
                        }
                        set
                        {
                                defalutPost = value;
                        }
                }
                /// <summary>
                /// 用户当前使用的岗位
                /// </summary>
                public SinoPost CurrentPost
                {
                        get
                        {
                                return currentPost;
                        }
                        set
                        {
                                currentPost = value;
                        }
                }

                public SinoUser()
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                }


        }
}