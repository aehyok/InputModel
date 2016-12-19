using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2.Goods
{
    /// <summary>
    /// 单据信息
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// 单据Id
        /// </summary>
        public string DOCID { get; set; }

        /// <summary>
        /// 案件编号
        /// </summary>
        public string AJBH { get; set; }

        /// <summary>
        /// 案件名称
        /// </summary>
        public string AJMC { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime DJSJ { get; set; }
    }
}
