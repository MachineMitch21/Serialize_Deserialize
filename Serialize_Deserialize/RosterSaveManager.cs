using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using ObjectSerializer;

namespace Serialize_Deserialize
{
    public class RosterSaveManager
    {
        protected string _fileExt = ".bin";
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
        /// <param name="roster"></param>
		public void Save(Roster roster)
        {
            BinaryObjectSaver<Roster> rosterSaver = new BinaryObjectSaver<Roster>();

            rosterSaver.Save(roster, new FileStream(_filePath + verifyExtension(roster.RosterName), FileMode.Create));
        }

        /// <summary>
        /// Loads a file with the specified name.  (Files must be loaded using the same type of save manager they were saved with)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Roster</returns>
		public Roster Load(string fileName)
        {
            BinaryObjectSaver<Roster> rosterLoader = new BinaryObjectSaver<Roster>();

            return rosterLoader.Load(new FileStream(_filePath + verifyExtension(fileName), FileMode.Open));
        }

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
