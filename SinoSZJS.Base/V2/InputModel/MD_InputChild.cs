using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
    /// <summary>
    /// added by lqm 2014.03.31 录入模型子模型
    /// </summary>
    [DataContract]
    public class MD_InputChild
    {
        /// <summary>
        /// 录入模型实体定义
        /// </summary>
        [DataMember]
        public MD_InputModel MD_ChildDefine { get; set; }

        /// <summary>
        /// 录入模型实体数据
        /// </summary>
        [DataMember]
        public MD_InputEntity MD_ChildData { get; set; }

        /// <summary>
        /// 录入模型实体主键
        /// </summary>
        [DataMember]
        public string MainKey { get; set; }

        /// <summary>
        /// 子模型列表选择模式（单选框，还是多选框）
        /// </summary>
        [DataMember]
        public int SelectMode { get; set; }

        /// <summary>
        /// 修改按钮是否显示(等于True则不显示)
        /// </summary>
        [DataMember]
        public bool IsHideUpdateButton { get; set; }

        /// <summary>
        /// 添加按钮是否显示（等于True则不显示）
        /// </summary>
        [DataMember]
        public bool IsHideAddButton { get; set; }

        /// <summary>
        /// 删除按钮是否显示（等于True则不显示）
        /// </summary>
        [DataMember]
        public bool IsHideDeleteButton { get; set; }

        /// <summary>
        /// 有子模型就会有Tab页（Tab控件的Name）
        /// </summary>
        [DataMember]
        public string MainTabName { get; set; }

        /// <summary>
        /// added by lqm 20160127 子模型注册中的案件Id传递问题
        /// </summary>
        [DataMember]
        public string Ajid { get; set; }
    }
}
