using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_FUNCTION
        {
                private string id = "";
                private string name = "";
                private string displayTitle = "";
                private string description = "";
                private string resultType = "";
                private string functionType = "";
                private List<string> paramList = new List<string>();
                private Dictionary<string, string> paramTypeDict = new Dictionary<string, string>();

                public MD_FUNCTION() { }

                public MD_FUNCTION(string _id, string _name, string _title, string _description, string _resultType, string _functionType)
                {
                        id = _id;
                        name = _name;
                        displayTitle = _title;
                        description = _description;
                        resultType = _resultType;
                        functionType = _functionType;
                }

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }
                public string DisplayTitle
                {
                        get { return displayTitle; }
                        set { displayTitle = value; }
                }
                public List<string> ParamList
                {
                        get { return paramList; }
                        set { paramList = value; }
                }

                public Dictionary<string, string> ParamTypeDict
                {
                        get { return paramTypeDict; }
                        set { paramTypeDict = value; }
                }
                public string FunctionType
                {
                        get
                        {
                                return functionType;
                        }
                        set { functionType = value; }
                }

                public string ResultType
                {
                        get { return resultType; }
                        set { resultType = value; }
                }
                public string Name
                {
                        get { return name; }
                        set { name = value; }
                }
                public string Description
                {
                        get { return description; }
                        set { description = value; }
                }
        }
}
