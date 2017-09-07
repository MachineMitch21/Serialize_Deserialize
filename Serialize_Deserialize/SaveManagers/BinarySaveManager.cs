using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Serialize_Deserialize
{
	public class BinarySaveManager : GenericSaveManager
	{
		public BinarySaveManager()
		{
			_fileExt = ".bin";
            _formatter = new BinaryFormatter();
		}
	}
}

