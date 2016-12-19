
namespace SinoSZJS.Base.V2.Flow
{
    public class ErrorEntity
    {
        private string errorType = string.Empty;
        /// <summary>
        /// 错误类型，0为错误，1为警告
        /// </summary>
        public string ErrorType
        {
            set { errorType = value; }
            get { return errorType; }
        }

        private string errorMessage = string.Empty;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage
        {
            set { errorMessage = value; }
            get { return errorMessage; }
        }
    }
}
