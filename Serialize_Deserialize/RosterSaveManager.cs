using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using ObjectSerializer;

namespace Serialize_Deserialize
{
    /// <summary>
    /// Saves a roster object to a file.  (FilePath default: "Data/Rosters/") (FileExt default: ".bin") (ObjectSaver<Roster> default: BinaryObjectSaver<Roster>)
    /// </summary>
    public class RosterSaveManager
    {
        protected string _fileExt = ".bin";
        protected string _filePath = "Data/Rosters/";

        protected ObjectSaver<Roster> _objSaver;

        public RosterSaveManager()
        {
            verifyPathDirectory();

            _objSaver = new BinaryObjectSaver<Roster>();
        }

        public RosterSaveManager(ObjectSaver<Roster> objSaver)
        {
            verifyPathDirectory();

            _objSaver = objSaver;
        }

        public RosterSaveManager(string fileExt, string filePath)
        {
            _filePath = filePath;
            _fileExt = fileExt;

            verifyPathDirectory();

            _objSaver = new BinaryObjectSaver<Roster>();
        }

        public RosterSaveManager(string fileExt, string filePath, ObjectSaver<Roster> objSaver)
        {
            _filePath = filePath;
            _fileExt = fileExt;

            verifyPathDirectory();

            _objSaver = objSaver;
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
            try
            {
                _objSaver.Save(roster, new FileStream(_filePath + verifyExtension(roster.RosterName), FileMode.Create));
            }
            catch(IOException e)
            {
                Console.WriteLine(string.Format("Error writing to the specified path ({0}) \n ERROR REPORT: {1}", _filePath, e.Message));
            }
        }

        /// <summary>
        /// Loads a file with the specified name.  (Files must be loaded using the same type of save manager they were saved with)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Roster</returns>
		public Roster Load(string fileName)
        {
            Roster loadedRoster = null;

            try
            {
                loadedRoster = _objSaver.Load(new FileStream(_filePath + verifyExtension(fileName), FileMode.Open));
                return loadedRoster;
            }
            catch (IOException e)
            {
                Console.WriteLine(string.Format("Error reading from the specified path ({0}) \n ERROR REPORT: {1}", _filePath, e.Message));
            }

            return loadedRoster;
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

        protected void verifyPathDirectory()
        {
            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }
        }
    }
}
