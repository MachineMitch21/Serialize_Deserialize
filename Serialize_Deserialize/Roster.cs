using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialize_Deserialize
{
    /// <summary>
    /// Holds a list of Employee objects 
    /// </summary>
    [Serializable]
	[XmlRoot("Roster")]
    public class Roster
    {
        public Roster()
        {
            _rosterName = "New Roster";
        }

        public Roster(string rosterName)
        {
            _rosterName = rosterName;
        }

        public Roster(string rosterName, params Employee[] employees)
        {
            _rosterName = rosterName;
            
            for (int i = 0; i < employees.Length; i++)
            {
                AddEmployee(employees[i]);
            }
        }

        string _rosterName;
        List<Employee> _employees = new List<Employee>();

		[XmlElement("RosterName")]
        public string RosterName
        {
            get { return _rosterName; }
            set { _rosterName = value; }
        }

		[XmlArray("Employees")]
		public List<Employee> Employees
		{
			get { return _employees; }
		}

        public int Count { get { return _employees.Count; } }

        public void AddEmployee(Employee employeeToAdd)
        {
            _employees.Add(employeeToAdd);
        }

        public Employee GetEmployeeByIndex(int index)
        {
            return _employees[index];
        }

        public int GetIndexOfEmployee(Employee employee)
        {
            if (!_employees.Contains(employee))
            {
                return -1;
            }

            return _employees.IndexOf(employee);
        }

		public override string ToString()
		{
			string employeeDescs = "\n";

			for (int i = 0; i < Count; i++)
			{
				employeeDescs += _employees[i].ToString() + "\n";
			}
			return string.Format("[Roster -- RosterName: {0}, Number Of Employees: {1}]", RosterName, Count);
		}
    }
}
