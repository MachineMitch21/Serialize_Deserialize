using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace Serialize_Deserialize
{
    public abstract class GenericSaveManager : RosterSaveManager
    {
        protected IFormatter _formatter;

        public override void Save(Roster roster)
        {
            FileStream fs = new FileStream(_filePath + verifyExtension(roster.RosterName), FileMode.Create);

            try
            {
                _formatter.Serialize(fs, roster);
            }
            catch (SerializationException se)
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

                try
                {
                    Roster loadedRoster = (Roster)_formatter.Deserialize(fs);
                    return loadedRoster;
                }
                catch (SerializationException se)
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
