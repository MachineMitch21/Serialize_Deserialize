using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace Serialize_Deserialize
{

    public class Program
    {
        public static string[] names = new string[10] { "Dan", "Jim", "Donna", "Jessica", "Joe", "Bob", "Heidi", "Jack", "Joanne", "Pat" };
        public static string[] jobs = new string[5] { "Supervisor", "Programmer", "HR", "IT", "Membership Consultant" };
        public static int[] salaries = new int[5] { 10000, 20000, 30000, 40000, 50000 };

        static void Main(string[] args)
		{
            Random random = new Random();

            Roster bigRoster = new Roster("BigRoster");
            
            for (int i = 0; i < 10000; i++)
            {
                bigRoster.AddEmployee(new Employee(i + 1, names[random.Next(0, names.Length - 1)], jobs[random.Next(0, jobs.Length - 1)], salaries[random.Next(0, salaries.Length - 1)]));
            }

            RosterSaveManager rsm = new XmlSaveManager();

            Out("Saving...");
            rsm.Save(bigRoster);
            
            Roster loadedBigRoster = null;

            Out("Loading...");

            loadedBigRoster = rsm.Load("BigRoster");

            Out(loadedBigRoster.ToString());
            Read();
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

        /// <summary>
        /// Implements Console.WriteLine(object)
        /// </summary>
        /// <param name="output"></param>
        static void Out(object output)
        {
            Console.WriteLine(output);
        }

        /// <summary>
        /// Implements Console.Read()
        /// </summary>
        /// <returns></returns>
        static int Read()
        {
            return Console.Read();
        }

        /// <summary>
        /// Implements Console.ReadLine()
        /// </summary>
        /// <returns></returns>
        static string ReadLine()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);

            return Console.ReadLine();
        }
    }
}
