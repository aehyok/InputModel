using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZJS.Base.V2.ChartEnity
{
    public class ChartInfo
    {
        /// <summary>
        /// Chart的名称，默认值为“CustomChart”
        /// </summary>
        public string ChartName { get; set; }
        /// <summary>
        /// 获取或设置数据字段的名称域
        /// </summary>
        public string ArgumentDataMember { set; get; }
        /// <summary>
        /// 获取或设置数据字段的数据值域
        /// </summary>
        public string ValueDataMember { set; get; }
        /// <summary>
        /// 获取或设置系列字段的名称域
        /// </summary>
        public string SeriesDataMember { set; get; }
        /// <summary>
        /// 是否显示值，默认值false
        /// </summary>
        public bool IsShowValues { set; get; }

        /// <summary>
        /// 图标的宽度,默认为500
        /// </summary>
        public int CustomWidth { set; get; }

        /// <summary>
        /// 图标的高度,默认为280
        /// </summary>
        public int CustomHeight { set; get; }

        /// <summary>
        /// 图标Y坐标轴的最大值，默认为50
        /// </summary>
        public int MaxValue_Y { set; get; }

        /// <summary>
        /// 动作名称
        /// </summary>
        public string Action { set; get; }
        /// <summary>
        /// 控制器名称
        /// </summary>
        public string Controller { set; get; }

        private DataTable resultTable = new DataTable();
        /// <summary>
        /// 结果集
        /// </summary>
        public DataTable ResultTable
        {
            set { resultTable = value; }
            get { return resultTable; }
        }

        public ChartInfo()
        {
            ChartName = "CustomChart";
            CustomWidth = 500;
            CustomHeight = 280;
            MaxValue_Y = 50;
            IsShowValues = false;
        }
    }
}
