using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        public class MD_GLFieldName_Comparer : IComparer<MD_GuideLineFieldName>
        {
                #region IComparer<MD_GuideLineFieldName> Members

                public int Compare(MD_GuideLineFieldName x, MD_GuideLineFieldName y)
                {                         
                        return x.DisplayOrder - y.DisplayOrder;
            
                }

                #endregion
        }
}
