
using System.Runtime.Serialization;
namespace SinoSZJS.Base.V2.EnumDefine
{
    [DataContract]
    public enum CaseFlag
    {
        /// <summary>
        /// 简单案件
        /// </summary>
        [EnumMember]
        XZAJ_JD = 0,
        /// <summary>
        /// 简易程序
        /// </summary>
        [EnumMember]
        XZAJ_JY = 1,
        /// <summary>
        /// 一般案件
        /// </summary>
        [EnumMember]
        XZAJ_YB = 2,
        /// <summary>
        /// 刑事案件
        /// </summary>
        [EnumMember]
        XSAJ = 3,
        /// <summary>
        /// 行政案件
        /// </summary>
        [EnumMember]
        XZAJ = 4
    }
}
