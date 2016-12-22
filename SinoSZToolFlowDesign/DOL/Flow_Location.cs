using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZToolFlowDesign.DOL
{
        [Serializable]
        public class Flow_Location
        {
                private string id ;
                private string dwdm ;
                private string dwName ;
                private string fullDWName ;

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }
                public string DWDM
                {
                        get { return dwdm;}
                        set { dwdm = value;}
                }

                public string DwName
                {
                        get { return dwName; }
                        set { dwName = value; }
                }

                public string FullDwName
                {
                        get { return fullDWName; }
                        set { fullDWName = value; }
                }

            

                public Flow_Location(string _id,string _dwdm,string _dwName,string _fullDWName)
                {
                        this.id = _id;
                        this.dwdm = _dwdm;
                        this.dwName = _dwName;
                        this.fullDWName = _fullDWName;
                }
        }
}
