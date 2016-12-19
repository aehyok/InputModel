using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2.Goods
{
    public class Goods
    {
        public Goods()
        {
        }

        /// <summary>
        /// .Ctor
        /// </summary>
        public Goods(string goodsName, float amount, string units, string feature, string standard)
        {
            GOODSNAME = goodsName;
            AMOUNT = amount;
            UNITS = units;
            FRETURE = feature;
            STANDARD = standard;
        }

        /// <summary>
        /// 物品名称
        /// </summary>
        public string GOODSNAME { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public float AMOUNT { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string UNITS { get; set; }

        /// <summary>
        /// 特征
        /// </summary>
        public string FRETURE { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string STANDARD { get; set; }

        /// <summary>
        /// 物品编码
        /// </summary>
        public string GOODSCODE { get; set; }

    }
}
