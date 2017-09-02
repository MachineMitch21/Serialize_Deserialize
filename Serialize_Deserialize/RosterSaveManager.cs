using System;
using System.Collections.Generic;
using System.IO;

namespace Serialize_Deserialize
{
    public abstract class RosterSaveManager
    {
        protected string _fileExt = ".txt";
        protected string _filePath = "Data/Rosters/";

        public RosterSaveManager()
        {
			if (!Directory.Exists(_filePath))
            {
				Directory.CreateDirectory(_filePath);
            }
        }

		public abstract void Save(Roster Roster);
		public abstract Roster Load(string fileName);

        public string[] GetRosterFileNames()
        {
			return Directory.GetFiles(_filePath);
        }

        //Helper method for verifying the extension of a fileName to load
        //The parameter is passed as reference so that any added extension will reflect onto the actual passed string
        protected string verifyExtension(ref string fileName)
        {
			if (fileName.EndsWith(_fileExt))
            {
                return fileName;
            }

			return (fileName += _fileExt);
        }

		protected string verifyExtension(string fileName)
		{
			if (fileName.EndsWith(_fileExt))
			{
				return fileName;
			}

			return (fileName + _fileExt);
		}
    }
}
