using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.MenuType
{
        [Serializable]
        public class firstPageItem
        {
                private string id = "";
                private string itemType = "";
                private string itemParam = "";
                private string caption = "";

                public firstPageItem() { }
                public firstPageItem(string _id, string _type, string _param, string _caption)
                {
                        id = _id;
                        itemType = _type;
                        itemParam = _param;
                        caption = _caption;
                }

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }

                public string ItemType
                {
                        get { return itemType; }
                        set { itemType = value; }
                }

                public string ItemParam
                {
                        get { return itemParam; }
                        set { itemParam = value; }
                }

                public string Caption
                {
                        get { return caption; }
                        set { caption = value; }
                }


        }
}
