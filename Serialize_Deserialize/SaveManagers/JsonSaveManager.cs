﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace Serialize_Deserialize
{
	public class JsonSaveManager : RosterSaveManager
	{
		public JsonSaveManager()
		{
			_fileExt = ".json";
		}
	}
}

