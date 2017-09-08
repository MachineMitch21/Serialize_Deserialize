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

        public Roster FilterByEmployeeName(string nameToFilterBy)
        {
            Roster filteredRoster = new Roster();

            for (int i = 0; i < Count; i++)
            {
                if (_employees[i].Name == nameToFilterBy)
                {
                    filteredRoster.AddEmployee(_employees[i]);
                }
            }

            return filteredRoster;
        }

        public Roster FilterByEmployeeTitle(string titleToFilterBy)
        {
            Roster filteredRoster = new Roster();

            for (int i = 0; i < Count; i++)
            {
                if (_employees[i].Title == titleToFilterBy)
                {
                    filteredRoster.AddEmployee(_employees[i]);
                }
            }

            return filteredRoster;
        }

        public Roster FilterByEmployeeSalary(float salaryLow, float salaryHigh)
        {
            Roster filteredRoster = new Roster();

            for (int i = 0; i < Count; i++)
            {
                if (_employees[i].Salary >= salaryLow && _employees[i].Salary <= salaryHigh)
                {
                    filteredRoster.AddEmployee(_employees[i]);
                }
            }

            return filteredRoster;
        }

        public Roster FilterByEmployeeID(int idLow, int idHigh)
        {
            Roster filteredRoster = new Roster();

            for (int i = 0; i < Count; i++)
            {
                if (_employees[i].ID >= idLow && _employees[i].ID <= idHigh)
                {
                    filteredRoster.AddEmployee(_employees[i]);
                }
            }

            return filteredRoster;
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
