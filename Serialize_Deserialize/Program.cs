using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialize_Deserialize
{
    public class Program
    {
        static void Main(string[] args)
        {
			
			Roster roster = new Roster("TestRoster", new Employee[] {	new Employee(0, "Joe", "Manager", 45000), 
																		new Employee(1, "Jeff", "Supervisor", 50000), 
																		new Employee(2, "Tim", "Programmer", 80000),	
																		new Employee(3, "Janice", "HR", 40000),
																		new Employee(4, "Larry", "IT", 38000)			});
			
			RosterSaveManager rsm = new XmlSaveManager();
			rsm.Save(roster);

			Roster test = rsm.Load("TestRoster");

			Out(test.ToString());
        }


		//All of these functions could eventually be used for an interactive console implementation of the roster program
        static void AddEmployeeOrSaveAndExit(ref Roster r)
        {
            Out("Type 'save' to save and exit");
            Out("");
            Out("");
            Out("Create Employee?");

            string create = ReadLine();

            if (create == "yes")
            {
                Out("Employee Name: ");
                string name = ReadLine();

                Out("");

                Out("Employee Title: ");
                string title = ReadLine();

                Out("");

                Out("Employee Salary: ");
                string salary = ReadLine();

                Employee e = new Employee(r.Count + 1, name, title, Convert.ToSingle(salary));

                r.AddEmployee(e);

                AddEmployeeOrSaveAndExit(ref r);
            }
            else
            {
                RosterSaveManager rsm = new BinarySaveManager();
                rsm.Save(r);
            }
        }

        static char AskInitialQuestion()
        {
            Out("Hello, would you like to load a roster?");
            Out("Y");
            Out("N");

            return Convert.ToChar(Read());
        }

        static Roster CreateNewRoster()
        {
            Out("Create New Roster: ");
            Out("");

            string rosterName = ReadLine();

            Roster roster = new Roster(rosterName);

            return roster;
        }

        static char GetRosterToLoad()
        {
            DisplayRosters();

            return Convert.ToChar(Read());
        }

        static void DisplayRosters()
        {
            RosterSaveManager rsm = new BinarySaveManager();

            for (int i = 0; i < rsm.GetRosterFileNames().Length; i++)
            {
                Out(String.Format("{0}: {1}", (i), rsm.GetRosterFileNames()[i]));
            }
        }

        static void Out(object output)
        {
            Console.WriteLine(output);
        }

        static int Read()
        {
            return Console.Read();
        }

        static string ReadLine()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);

            return Console.ReadLine();
        }
    }
}
