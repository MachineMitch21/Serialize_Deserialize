using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;

namespace Serialize_Deserialize
{
    public class SoapSaveManager : GenericSaveManager
    {
        public SoapSaveManager()
        {
            _fileExt = ".dat";
            _formatter = new SoapFormatter();
        }
    }
}
