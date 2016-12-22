using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.RefCode
{
        [Serializable]
        public class RefCodeTableSet
        {
                Dictionary<string, RefCodeTable> _refTables = new Dictionary<string, RefCodeTable>();
                public Dictionary<string, RefCodeTable> RefTables
                {
                        get { return _refTables; }
                        set { _refTables = value; }
                }
        }
}
