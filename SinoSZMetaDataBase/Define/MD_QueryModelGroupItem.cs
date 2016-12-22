using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_QueryModelGroupItem : MD_QueryModel
        {
                /// <summary>
                /// 显示顺序
                /// </summary>
                public int ItemDisplayOrder
                {
                        get
                        {
                                throw new System.NotImplementedException();
                        }
                        set
                        {
                        }
                }

                /// <summary>
                /// 对应的查询主题
                /// </summary>
                public MD_QueryModelGroup QueryModelGroup
                {
                        get
                        {
                                throw new System.NotImplementedException();
                        }
                        set
                        {
                        }
                }

                /// <summary>
                /// 节点编号
                /// </summary>
                public string ItemDWDM
                {
                        get
                        {
                                throw new System.NotImplementedException();
                        }
                        set
                        {
                        }
                }

                /// <summary>
                /// ID
                /// </summary>
                public string ID
                {
                        get
                        {
                                throw new System.NotImplementedException();
                        }
                        set
                        {
                        }
                }
        }
}
