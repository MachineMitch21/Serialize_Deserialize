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

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        /// <summary>
        /// Saves the specified roster to a file.  (Binary (use BinarySaveManager) or Xml (use XmlSaveManager) files supported depending on object used to save)
        /// </summary>
        /// <param name="Roster"></param>
		public abstract void Save(Roster Roster);

        /// <summary>
        /// Loads a file with the specified name.  (Files must be loaded using the same type of save manager they were saved with)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Roster</returns>
		public abstract Roster Load(string fileName);

        /// <summary>
        /// Gets a list of file names located within the path specified in the _filePath for the save manager
        /// </summary>
        /// <returns>string[] fileNames</returns>
        public string[] GetRosterFileNames()
        {
			string [] fileNames = Directory.GetFiles(_filePath);

			for (int i = 0; i < fileNames.Length; i++)
			{
				fileNames[i] = Path.GetFileName(fileNames[i]);
			}

			return fileNames;
        }

        /// <summary>
        /// Verifies the extension is present in the string parameter.  Changes the original variable's value to match the changes provided
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected string verifyExtension(ref string fileName)
        {
			if (fileName.EndsWith(_fileExt))
            {
                return fileName;
            }

			return (fileName += _fileExt);
        }


        /// <summary>
        /// Verifies the extension is present in the string parameter.  Doesn't change the original variable's value
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
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
