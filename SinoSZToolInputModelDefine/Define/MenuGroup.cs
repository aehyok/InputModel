using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZToolInputModelDefine.Define
{
        public class MenuGroup
        {
                public string GroupTitle = "";
                public List<string> Buttons = new List<string>();
                public MenuGroup()
                {
                }


                public MenuGroup(string _title)
                {
                        GroupTitle = _title;
                }
        }
}
