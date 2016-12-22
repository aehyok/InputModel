using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.SystemInterface
{
        public class SystemICS_SJJH_NodeComparer : IComparer<SystemICS_SJJH_Node>
        {
                #region IComparer<SystemICS_SJJH_Node> Members

                public int Compare(SystemICS_SJJH_Node x, SystemICS_SJJH_Node y)
                {
                        return x.XH - y.XH;
                }

                #endregion
        }
}
