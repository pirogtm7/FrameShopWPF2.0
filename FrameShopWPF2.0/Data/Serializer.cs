using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace FrameShopWPF
{
    public class Serializer
    {
        interface ISerialization
        {
            void Serialization(Object obj, string path);
        }

        public class XMLSerializator : ISerialization
        {
            DataContractSerializer xmlSerializer;

            public XMLSerializator(Type type)
            {
                xmlSerializer = new DataContractSerializer(type);
            }
            public void Serialization(Object obj, string path)
            {
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xmlSerializer.WriteObject(stream, obj);
                }
            }
        }
    }
}
