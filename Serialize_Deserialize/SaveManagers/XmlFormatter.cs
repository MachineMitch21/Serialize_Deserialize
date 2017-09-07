using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;

namespace Serialize_Deserialize
{
    class XmlFormatter<T> : IFormatter
    {
        public SerializationBinder Binder
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public StreamingContext Context
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ISurrogateSelector SurrogateSelector
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public object Deserialize(Stream serializationStream)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            return xmlSerializer.Deserialize(serializationStream);   
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            xmlSerializer.Serialize(serializationStream, graph);
        }
    }
}
