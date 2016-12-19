using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace SinoSZJS.Base.V2.Document
{
    [DataContract]
    public class DocPdf
    {
        [DataMember]
        public byte[] Content { get; set; }

        [DataMember]
        public string DocTypeDetailId { get; set; }
    }
}
