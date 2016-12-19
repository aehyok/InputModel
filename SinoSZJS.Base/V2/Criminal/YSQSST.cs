
namespace SinoSZJS.Base.V2.Criminal
{
    /// <summary>
    /// 移送起诉实体
    /// </summary>
    public class YSQSST
    {
        /// <summary>
        /// 实体id
        /// </summary>
        public string STID { set; get; }

        /// <summary>
        /// 实体名称
        /// </summary>
        public string STMC { set; get; }

        /// <summary>
        /// 实体类型
        /// </summary>
        public string STLX { set; get; }

        public override string ToString()
        {
            return STMC;
        }
    }
}
