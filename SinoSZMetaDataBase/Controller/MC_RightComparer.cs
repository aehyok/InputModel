using System;
using System.Collections.Generic;
using System.Text;
using SinoSZMetaDataBase.Define;

namespace SinoSZMetaDataBase.Controller
{
        public class MC_RightComparer : IComparer<MD_RightDefine>
        {                
                public int Compare(MD_RightDefine x, MD_RightDefine y)
                {
                        return x.DisplayOrder - y.DisplayOrder;

                }

        }

}
