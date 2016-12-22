using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_View2View
        {
                private string id;
                private int displayOrder;
                private string displayTitle;
                private MD_View2ViewGroup viewGroup;
                private string targetViewName;
                private string relationString;
                private MD_QueryModel queryModel;

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }

                public string RelationString
                {
                        get { return relationString; }
                        set { relationString = value; }
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

                public MD_View2ViewGroup ViewGroup
                {
                        get { return viewGroup; }
                        set { viewGroup = value; }
                }

                public string TargetViewName
                {
                        get { return targetViewName; }
                        set { targetViewName = value; }
                }

                public MD_QueryModel QueryModel
                {
                        get { return queryModel; }
                        set { queryModel = value; }
                }

                public override string ToString()
                {
                        return this.displayTitle;
                }
        }
}
