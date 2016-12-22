using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        public enum MDType_ViewTableRelation
        {
                /// <summary>
                /// 主表的一条记录对应本表一条(或没有)记录
                /// </summary>
                SingleChildRecord = 1,
                /// <summary>
                /// 主表的一条记录对应本表多条(或没有)记录
                /// </summary>
                MultiChildRecord = 0,
        }
}
