using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_View_GuideLine
        {
                private string id;
                private int displayOrder;
                private string displayTitle;
                private string viewID;
                private string targetGuideLineID;
                private string relationParam;

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }
                public int DisplayOrder
                {
                        get { return displayOrder; }
                        set { displayOrder = value; }
                }

                public string DisplayTitle
                {
                        get { return displayTitle; }
                        set { displayTitle = value; }
                }
                public string ViewID
                {
                        get { return viewID; }
                        set { viewID = value; }
                }
                public string TargetGuideLineID
                {
                        get { return targetGuideLineID; }
                        set { targetGuideLineID = value; }
                }
                public string RelationParam
                {
                        get { return relationParam; }
                        set { relationParam = value; }
                }
                public override string ToString()
                {
                        return DisplayTitle;
                }
        }
}
