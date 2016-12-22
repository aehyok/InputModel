using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable]
        public class MD_View2ViewGroup
        {
                private string id;
                private int displayOrder;
                private string displayTitle;
                private MD_QueryModel queryModel;
                private IList<MD_View2View> view2Views;

                public IList<MD_View2View> View2Views
                {
                        get { return view2Views; }
                        set { view2Views = value; }
                }

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
