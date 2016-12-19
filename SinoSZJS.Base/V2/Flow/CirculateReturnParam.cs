
namespace SinoSZJS.Base.V2.Flow
{
    public class CirculateReturnParam
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        private string _errorMessage = string.Empty;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage
        {
            set { _errorMessage = value; }

            get { return _errorMessage; }
        }

        /// <summary>
        /// 动作流转后的状态序号
        /// </summary>
        public string NextStateOrder { set; get; }

        /// <summary>
        /// 实体id
        /// </summary>
        public string bzid { set; get; }


        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}
