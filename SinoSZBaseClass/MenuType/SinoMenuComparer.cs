using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.MenuType
{
        public class SinoMenuComparer : IComparer<SinoMenuItem>
        {
                #region IComparer<SinoMenuItem> Members

                public int Compare(SinoMenuItem x, SinoMenuItem y)
                {
                        return x.DisplayOrder - y.DisplayOrder;
                }

                #endregion
        }
}
