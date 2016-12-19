using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SinoSZJS.Base.V2.MetaData.QueryModel
{
    [DataContract]   
    public class MDQuery_Condition
    {
        public int ColumnIndex { set; get; }

        public string ColumnName { set; get; }

        public string DisplayTitle { set; get; }

        public string ColumnDataType { set; get; }

        public string ColumnRefDMB { set; get; }

        public string TableName { set; get; }
    }
}
