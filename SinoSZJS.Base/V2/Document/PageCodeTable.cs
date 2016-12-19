using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2.Document
{
    public class PageCodeTable
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public decimal DisplayOrder { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 上级代码
        /// </summary>
        public string FatherCode { get; set; }

        /// <summary>
        /// 代码表名称
        /// </summary>
        public string TableName { get; set; }
    
       
    }
}
