using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.MenuType
{
        public class SinoMenuFatherFinder
        {
                private string fatherID;
               
                public SinoMenuFatherFinder(string _fid)
                {
                        this.fatherID = _fid;
                }

                public bool FindByFather(SinoMenuItem _menuItem)
                {
                        return (_menuItem.FatherID == fatherID);
                }


        }
}
