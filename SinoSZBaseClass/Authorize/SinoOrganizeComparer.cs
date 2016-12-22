using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.Authorize
{
        public class SinoOrganizeComparer : IComparer<SinoOrganize>
        {
                #region IComparer<SinoOrganize> Members

                public int Compare(SinoOrganize x, SinoOrganize y)
                {
                        return x.DisplayOrder - y.DisplayOrder;
                }

                #endregion
        }
}
