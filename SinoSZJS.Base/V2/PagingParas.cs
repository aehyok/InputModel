using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2
{
    public class PagingParas
    {
        public string GridViewName { set; get; }
        /// <summary>
        /// 每页的记录数
        /// </summary>
        public decimal PageSize { set; get; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public decimal RecordCount { set; get; }
        /// <summary>
        /// 页数
        /// </summary>
        public decimal PageCount { set; get; }
        /// <summary>
        /// 页码
        /// </summary>
        public decimal PageIndex { set; get; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortBy { set; get; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public string SortDirection { set; get; }
        public PagingParas()
        {
            PageIndex = 1;
            PageSize = 15;
        }
    }
}
