using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.ModelDefine
{
        public class MDModel_ColumnComparer : IComparer<MDModel_Table_Column>
        {
                #region IComparer<MDModel_Table_Column> Members

                public int Compare(MDModel_Table_Column x, MDModel_Table_Column y)
                {
                        return x.ColumnDefine.DisplayOrder - y.ColumnDefine.DisplayOrder;
                }

                #endregion
        }
}
