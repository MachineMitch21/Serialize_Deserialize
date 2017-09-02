using System;

namespace Serialize_Deserialize
{
	public class JsonSaveManager : RosterSaveManager
	{
		public JsonSaveManager()
		{
			_fileExt = ".json";
		}

		public override void Save(Roster Roster)
		{
			throw new NotImplementedException ();
		}

		public override Roster Load(string fileName)
		{
			throw new NotImplementedException ();
		}
	}
}

