using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Linq;

namespace Serialize_Deserialize
{
	public class XmlSaveManager : GenericSaveManager
	{
		public XmlSaveManager()
		{
			_fileExt = ".xml";
            _formatter = new XmlFormatter<Roster>();
		}
	}
}

