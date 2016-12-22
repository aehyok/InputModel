using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Services;

namespace SinoSZBaseClass.Misc
{
        public class SinoSZRemoteObjectTracker : ITrackingHandler
        {
                #region ITrackingHandler Members

                public void DisconnectedObject(object obj)
                {
                        
                        //Console.WriteLine("对象{0}在{1}被Disconnect ！", obj.ToString(),DateTime.Now.ToShortTimeString());

                }

                public void MarshaledObject(object obj, System.Runtime.Remoting.ObjRef or)
                {

                        //Console.WriteLine("对象{0}在{1}被编组！", obj.ToString(), DateTime.Now.ToShortTimeString());
                }

                public void UnmarshaledObject(object obj, System.Runtime.Remoting.ObjRef or)
                {

                        //Console.WriteLine("对象{0}在{1}被解组！", obj.ToString(), DateTime.Now.ToShortTimeString());
                }

                #endregion
        }
}
