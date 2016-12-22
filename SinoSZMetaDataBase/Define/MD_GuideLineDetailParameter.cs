using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_GuideLineDetailParameter
        {
                private string name = "";
                private string dataValue = "";
                private string title = "";
                private string type = "";

                public MD_GuideLineDetailParameter() {}
                public MD_GuideLineDetailParameter(string _name,string _title,string _type,string _value){
                        name =_name;
                        title = _title;
                        type = _type;
                        dataValue = _value;
                }

                public string Name
                {
                        get { return name;}
                        set { name = value;}
                }

                public string DataValue
                {
                        get { return dataValue;}
                        set { dataValue = value;}
                }

                public string Type
                {
                        get { return type; }
                        set { type = value; }
                }

                public string Title
                {
                        get { return title; }
                        set { title = value; }
                }

        }
}
