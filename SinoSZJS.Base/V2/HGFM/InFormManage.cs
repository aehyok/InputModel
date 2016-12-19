using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChinaCustoms.Applications.HGFM.Entities.InForm;

namespace ChinaCustoms.Applications.HGFM.Entities.Common
{
    public class InFormManage
    {

        public InFormHeadInfo InFormHead { get; set; }
        public List<InFormGoodsInfo> InFormGoodsList { get; set; }

        public InFormManage()
        {
            InFormHead = new InFormHeadInfo();
            InFormGoodsList = new List<InFormGoodsInfo>();
        }
    }
}
