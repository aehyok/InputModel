using System;
using System.Data;

namespace SinoSZBaseClass.Authorize
{
        /// <summary>
        /// RightItem 的摘要说明。
        /// 用户（或角色）所具备的单个权限项及级别范围　　　　　　　
        /// </summary>
        [Serializable()]
        public class UserRightItem
        {
                public SinoRightItem Right = null;//权限项
                public decimal Level = 0;//级别范围

                public UserRightItem()
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                }



        }

}
