using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.InputModel
{
        [Serializable]
        public class MD_InputModel_ColumnGroup
        {
                private string modelID = "";
                private string groupID = "";
                private string displayTitle = "";
                private int displayOrder = 0;
                private List<MD_InputModel_Column> columns = new List<MD_InputModel_Column>();

                public MD_InputModel_ColumnGroup(string _groupID, string _modelID, string _title, int _order)
                {
                        modelID = _modelID;
                        groupID = _groupID;
                        displayTitle = _title;
                        displayOrder = _order;
                }
                public List<MD_InputModel_Column> Columns
                {
                        get { return columns; }
                        set { columns = value; }
                }

                public string ModelID
                {
                        get { return modelID; }
                        set { modelID = value; }
                }

                public string GroupID
                {
                        get { return groupID; }
                        set { groupID = value; }
                }
                public string DisplayTitle
                {
                        get { return displayTitle; }
                        set { displayTitle = value; }
                }

                public int DisplayOrder
                {
                        get { return displayOrder; }
                        set { displayOrder = value; }
                }

                public override string ToString()
                {
                        return displayTitle;
                }


        }
}
