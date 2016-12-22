using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_QueryModel_ExRight
        {
                private string id = "";
                private string rightName = "";
                private string rightTitle = "";
                private string modelid = "";
                private string fatherRightID = "";
                private int displayOrder = 0;

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }
                public string RightName
                {
                        get { return rightName; }
                        set { rightName = value; }
                }
                public string RightTitle { get { return rightTitle; } set { rightTitle = value; } }
                public string ModelID { get { return modelid; } set { modelid = value; } }
                public string FatherRightID { get { return fatherRightID; } set { fatherRightID = value; } }
                public int DisplayOrder { get { return displayOrder; } set { displayOrder = value; } }

                public override string ToString()
                {
                        return rightTitle;
                }

        }
}
