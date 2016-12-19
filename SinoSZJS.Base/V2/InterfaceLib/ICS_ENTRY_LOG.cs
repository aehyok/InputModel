using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2.InterfaceLib
{
    public class ICS_ENTRY_LOG
    {
        public string ROW_ID { get; set; }
        public string ENTRY_ID { get; set; }
        public string G_NO { get; set; }
        public string COL_KEY { get; set; }
        public string COL_DESC { get; set; }
        public string COL_OLD_VALUE { get; set; }
        public string COL_NEW_VALUE { get; set; }
        public string LogKey { get; set; }
    }
}
