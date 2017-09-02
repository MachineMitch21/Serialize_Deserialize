using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialize_Deserialize
{
    [Serializable]
	[XmlRoot("Employee")]
    public class Employee
    {
        public Employee()
        {
            _id = -1;
            _title = "New Employee";
            _salary = 0.0f;
        }

        public Employee(int id, string name, string title, float salary)
        {
            _id = id;
			_name = name;
            _title = title;
            _salary = salary;
        }

        private int _id;
        private string _name;
        private string _title;
        private float _salary;

		[XmlElement("id")]
		public int ID 
		{ 
			get { return _id; }  
			set { _id = value; }
		}

		[XmlElement("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

		[XmlElement("title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

		[XmlElement("salary")]
        public float Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

		public override string ToString ()
		{
			return string.Format ("[Employee: ID={0}, Name={1}, Title={2}, Salary={3}]", ID, Name, Title, Salary);
		}
    }
}
