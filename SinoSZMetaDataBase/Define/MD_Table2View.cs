using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_Table2View
        {
                private string id = "";
                private string tid = "";
                private string modelName = "";
                private string conditionStr = "";
                private string confine = "";

                public MD_Table2View(string _id, string _tid, string _model, string _condi, string _confine)
                {
                        id = _id;
                        tid = _tid;
                        modelName = _model;
                        conditionStr = _condi;
                        confine = _confine;
                }

                public string Confine
                {
                        get { return confine; }
                        set { confine = value; }
                }

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }

                public string TID
                {
                        get { return tid; }
                        set { tid = value; }
                }

                public string ModelName
                {
                        get { return modelName; }
                        set { modelName = value; }
                }

                public string ConditionStr
                {
                        get { return conditionStr; }
                        set { conditionStr = value; }
                }

                public override string ToString()
                {
                        return modelName;
                }



        }
}
