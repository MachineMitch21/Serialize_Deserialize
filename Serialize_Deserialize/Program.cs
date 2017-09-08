using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ObjectSerializer;
using System.IO;


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

            RosterSaveManager rsm = new RosterSaveManager(".xml", "Data/Rosters/", new XmlObjectSaver<Roster>());

            rsm.Save(bigRoster);

            Roster test = rsm.Load("BigRoster");

            Out(test.ToString());
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
