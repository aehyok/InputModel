using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2.InterfaceLib
{
    public class ICS_ENTRY_HEAD_EXTEND
    {
        public string ENTRY_ID { get; set; }
        public string CONTACTS_1 { get; set; }
        public string CONTACTS_1_TEL_1 { get; set; }
        public string CONTACTS_1_TEL_2 { get; set; }
        public string CONTACTS_2 { get; set; }
        public string CONTACTS_2_TEL_1 { get; set; }
        public string CONTACTS_2_TEL_2 { get; set; }
        public string IS_FORBIDDEN { get; set; }
        public string OPER_USER { get; set; }
        public string CONTAINER_ID { get; set; }
        public string EXAM_MEMO { get; set; }
    }
}
