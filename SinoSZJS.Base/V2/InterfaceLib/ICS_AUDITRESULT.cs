using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2.InterfaceLib
{
    public class ICS_AUDITRESULT
    {
        public string EntryId { get; set; }
        public string IsProhibitGoods { get; set; }
        public string IsNeedLicence { get; set; }
        public string IsDeclRateGtRealRate { get; set; }
        public string UnpaidAmount { get; set; }
        public string IsContainedEntryExitGoods { get; set; }
        public string IsNeedTGD { get; set; }
        public string IsNeedReapplyTGD { get; set; }
        public string Result { get; set; }
        public string SumTax { get; set; }
        public string REMARK { get; set; }
    }
}
