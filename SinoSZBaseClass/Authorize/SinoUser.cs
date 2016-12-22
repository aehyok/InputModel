using System;
using System.Collections;
using System.Collections.Generic;

namespace SinoSZBaseClass.Authorize
{
        /// <summary>
        /// SinoUser �û����塣
        /// �û�������
        /// </summary>
        [Serializable()]
        public class SinoUser
        {
                /// <summary>
                /// �û����н�ɫ��
                /// </summary>
                public List<SinoRole> Roles = new List<SinoRole>();
                /// <summary>
                /// �û���ǰ���е�Ȩ�޼�
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
                /// �û����и�λ��
                /// </summary>
                public List<SinoPost> Posts = new List<SinoPost>();
                /// <summary>
                /// �û�Ĭ�ϸ�λ
                /// </summary>
                private SinoPost defalutPost = null;
                /// <summary>
                /// �û���ǰʹ�õĸ�λ
                /// </summary>
                private SinoPost currentPost = null;
                /// <summary>
                /// ϵͳ���
                /// </summary>
                public string SystemID = "";
                /// <summary>
                /// �û�����    ֵΪ��1:�������û�������	2:����˽���û���
                /// </summary>
                public int UserType = 2;
                /// <summary>
                /// �û���¼��
                /// </summary>
                public string LoginName = "";
                /// <summary>
                /// �û�ID
                /// </summary>		
                public string UserID = "";
                /// <summary>
                /// �û�����
                /// </summary>
                public string UserName = "";
                //�û���GUID
                public string UserGUID = "";
                /// <summary>
                /// �û��ĺ��عغ�
                /// </summary>
                public string UserHGGH = "";
                /// <summary>
                /// ��λID
                /// </summary>
                public string DwID = "";
                /// <summary>
                /// ��λ����
                /// </summary>
                public string DwName = "";
                /// <summary>
                /// ��λ����
                /// </summary>
                public string Dwdm = "";
                /// <summary>
                /// ��λ��GUID
                /// </summary>
                public string DwGUID = "";

                /// <summary>
                /// Ȩ�޲㼶,ֵΪ:�������𼶡�ֱ�����ؼ����������ؼ�
                /// </summary>
                public string QxszJB = "";
                /// <summary>
                /// Ȩ�����ڵ�λ����
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
                /// Ȩ�����ڵ�λ����
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
                /// Ȩ�����ڵ�λ����
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
                /// Ȩ�����ڵ�λ��GUID
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
                /// �û��־ֵ�λID
                /// </summary>
                public string User_FJID = "";
                /// <summary>
                /// �û�ֱ����ID
                /// </summary>
                public string User_ZSJID = "";
                /// <summary>
                /// �û��Ƿ�㶫����
                /// </summary>
                public bool IsGDFSUser = false;
                /// <summary>
                /// ��ȫ����
                /// </summary>
                public int SecretLevel = 0;
                /// <summary>
                /// �û�����Ʊ��
                /// </summary>
                public string EncryptedTicket = "";
                /// <summary>
                /// �û�ʹ�õ�IP��ַ
                /// </summary>
                public string IPAddress = "";
                /// <summary>
                /// �û�ʹ�õ�������
                /// </summary>
                public string HostName = "";
                /// <summary>
                /// �û��Ƿ���֤ͨ��
                /// </summary>
                public bool IsSignOn = false;

                /// <summary>
                /// �û�Ĭ�ϸ�λ
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
                /// �û���ǰʹ�õĸ�λ
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
                        // TODO: �ڴ˴���ӹ��캯���߼�
                        //
                }


        }
}