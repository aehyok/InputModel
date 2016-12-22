using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SinoSZBaseClass
{
        public class CloneSerializeObject
        {
                static public object Clone(object _obj)
                {
                        IFormatter formatter = new BinaryFormatter();
                        Stream stream = new MemoryStream();
                        formatter.Serialize(stream, _obj);

                        stream.Position = 0;
                        object _ret = formatter.Deserialize(stream);
                        return _ret;
                }
        }
}
