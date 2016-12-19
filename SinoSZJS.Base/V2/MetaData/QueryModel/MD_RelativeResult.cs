using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SinoSZJS.Base.V2.MetaData.QueryModel
{
    [DataContract]
    public class MD_RelativeResult
    {
        [DataMember]
        public DataSet ResultTables { get; set; }
        [DataMember]
        public MDQuery_ResultTable MainTable { set; get; }
        [DataMember]
        public MDQuery_ResultTable SingleTable { set; get; }
        [DataMember]
        public List<MDQuery_ResultTable> ChildTable { set; get; }
        [DataMember]
        public List<MDQuery_ConditionItem> ConditionItemList { set; get; }
        [DataMember]
        public string MList { set; get; }
        [DataMember]
        public string CList { set; get; }
        [DataMember]
        public string ExpressValue { set; get; }
        [DataMember]
        public string QModelName { set; get; }
    }
}
