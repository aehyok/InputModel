using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
    [DataContract]
    public class Attachment
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string BZID { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public string FileType { get; set; }
        [DataMember]
        public byte[] FileContent { get; set; }
        [DataMember]
        public decimal FileSize { get; set; }
        [DataMember]
        public string UploadTime { get; set; }
    }
}
