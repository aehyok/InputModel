using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChinaCustoms.Applications.HGFM.ReleaseModule.Entities
{
    public class RealQueryInfo
    {
        /// <summary>
        /// 返回结果,“Success”为成功或“Fail”为失败
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 内容，存放实时查询结果集的xml字符串
        /// </summary>
        public string DataContent { get; set; }
        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionMessage { get; set; }
    }

}
