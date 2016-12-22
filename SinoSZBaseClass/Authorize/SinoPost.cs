using System;
using System.Collections;
using System.Collections.Generic;

namespace SinoSZBaseClass.Authorize
{
        /// <summary>
        /// SinoPost �û��ĸ�λ���� 
        /// </summary>
        [Serializable()]
        public class SinoPost
        {
                /// <summary>
                /// �˸�λ�Ľ�ɫ�б�
                /// </summary>
                public List<SinoRole> Roles = new List<SinoRole>();
                /// <summary>
                /// �˸�λ��Ȩ���б�
                /// </summary>               
                public Dictionary<string, UserRightItem> Rights = new Dictionary<string, UserRightItem>();
                /// <summary>
                /// �Ƿ�Ĭ�ϸ�λ
                /// </summary>
                public bool IsDefaultPost = false;
                /// <summary>
                /// ��λID
                /// </summary>
                public string PostID = "";
                /// <summary>
                /// ��λ����
                /// </summary>
                public string PostName = "";
                /// <summary>
                /// ��λ���ڵĵ�λID
                /// </summary>
                public string PostDwID = "";
                /// <summary>
                /// ��λȨ�����ڵ�λ����
                /// </summary>
                public string PostDWDM = "";
                /// <summary>
                /// ��λ���ڵĵ�λ����
                /// </summary>
                public string PostDWMC = "";
                /// <summary>
                /// Ȩ�����ڵ�λ��GUID
                /// </summary>
                public string PostDWGUID = "";
                /// <summary>
                /// ��ȫ����
                /// </summary>
                public int SecretLevel = 0;
                /// <summary>
                /// ��λ����
                /// </summary>
                public string PostDescript = "";

                public SinoPost()
                {
                        //
                        // TODO: �ڴ˴���ӹ��캯���߼�
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
