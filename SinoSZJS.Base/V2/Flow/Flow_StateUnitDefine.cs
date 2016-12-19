using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
    [DataContract]
    public class Flow_StateUnitDefine
    {
        /// <summary>
        /// GUID
        /// </summary>
        [DataMember]
        public string Id { set; get; }

        /// <summary>
        /// 单位ID
        /// </summary>
        [DataMember]
        public string UnitId { set; get; }

        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        public string UnitName { set; get; }

        /// <summary>
        /// 状态ID
        /// </summary>
        [DataMember]
        public string StateId { set; get; }

        /// <summary>
        /// 数据参数
        /// </summary>
        [DataMember]
        public string DataShowMeta { set; get; }

        /// <summary>
        /// 类型（1操作，2显示）
        /// </summary>
        [DataMember]
        public string Type { set; get; }

        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string StateName { set; get; }

        /// <summary>
        /// 状态显示名称
        /// </summary>
        [DataMember]
        public string DisplayName { get; set; }

        public Flow_StateUnitDefine(string id, string unitid, string stateid, string datameta, string type, string unitname, string displayName)
        {
            this.Id = id;
            this.UnitId = unitid;
            this.StateId = stateid;
            this.DataShowMeta = datameta;
            this.Type = type;
            this.UnitName = unitname;
            this.DisplayName = displayName;
        }

        public Flow_StateUnitDefine()
        { }
    }
}
