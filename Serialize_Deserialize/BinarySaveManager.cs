using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Serialize_Deserialize
{
	public class BinarySaveManager : RosterSaveManager
	{
		public BinarySaveManager()
		{
			_fileExt = ".bin";
		}

		public override void Save(Roster roster)
		{
			FileStream fs = new FileStream(_filePath + verifyExtension(roster.RosterName), FileMode.Create);
			BinaryFormatter binaryFormatter = new BinaryFormatter();

			try
			{
				binaryFormatter.Serialize(fs, roster);
			}
			catch(SerializationException se)
			{
				Console.WriteLine("Failed to Serialize " + roster.RosterName + se.Message);
				throw;
			}
			finally
			{
				fs.Close();
			}
		}

		public override Roster Load(string fileName)
		{
			if (GetRosterFileNames().Contains(verifyExtension(ref fileName)))
			{

				FileStream fs = new FileStream(_filePath + fileName, FileMode.Open);
				BinaryFormatter binaryFormatter = new BinaryFormatter();

				try
				{
					Roster loadedRoster = (Roster)binaryFormatter.Deserialize(fs);
					return loadedRoster;
				}
				catch(SerializationException se)
				{
					Console.WriteLine("Trouble deserializing " + fileName + " \n" + se.Message);
					throw;
				}
				finally
				{
					fs.Close();
				}
			}

			Console.WriteLine("Attempting to load " + fileName + " but the file could not be found.  Verify spelling and try again.");
			return null;
		}
	}
}

