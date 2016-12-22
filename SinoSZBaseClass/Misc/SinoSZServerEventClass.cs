using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.Misc
{
        public class SinoSZServerEventClass : MarshalByRefObject
        {
                private string ObjName = "";
                public SinoSZServerEventClass(string _name)
                {
                        this.ObjName = _name;
                }
                
                public void OnTestMethod()
                {
                        //Console.WriteLine("{0}租期续约!", this.ObjName);
                }

        }

}
