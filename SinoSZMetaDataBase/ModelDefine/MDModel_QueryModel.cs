using System;
using System.Collections.Generic;
using System.Text;


namespace SinoSZMetaDataBase.ModelDefine
{
        /// <summary>
        /// 查询模型定义
        /// </summary>
        [Serializable]
        public class MDModel_QueryModel
        {
                /// <summary>
                /// 查询接口类型
                /// </summary>
                public string QueryInterface
                {
                        get { return queryInterface; }
                        set { queryInterface = value; }
                }
                private string queryInterface = "ORA_JSIS";


                /// <summary>
                /// 查询模型名称
                /// </summary>
                public string QueryModelName
                {
                        get { return queryModelName; }
                        set { queryModelName = value; }
                }
                private string queryModelName = "";

                /// <summary>
                /// 查询模型显示名称
                /// </summary>
                public string DisplayName
                {
                        get { return displayName; }
                        set { displayName = value; }
                }
                private string displayName = "";
                /// <summary>
                /// 命名空间名称
                /// </summary>
                public string NameSpaceName
                {
                        get { return nameSpaceName; }
                        set { nameSpaceName = value; }
                }
                private string nameSpaceName = "";

                /// <summary>
                /// 查询模型全称
                /// </summary>
                public string FullQueryModelName
                {
                        get { return string.Format("{0}.{1}", nameSpaceName, queryModelName); }
                }


                private MDModel_Table mainTable = null;
                private Dictionary<string, MDModel_Table> childTableDict = new Dictionary<string, MDModel_Table>();

                /// <summary>
                /// 主表定义
                /// </summary>
                public MDModel_Table MainTable
                {
                        get { return mainTable; }
                        set { mainTable = value; }
                }

                /// <summary>
                /// 子表字典,以TableName为字典键值
                /// </summary>
                public Dictionary<string, MDModel_Table> ChildTableDict
                {
                        get { return childTableDict; }
                        set { childTableDict = value; }
                }

               
        }
}
