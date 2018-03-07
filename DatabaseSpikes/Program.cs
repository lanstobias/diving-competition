using System;
using Simhopp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSpikes
{
    class Program
    {
        static void Main(string[] args)
        {
            //DatabasePerson databasePerson = new DatabasePerson();
            //databasePerson.AddPerson();

            //DatabaseContest databaseContest = new DatabaseContest();
            //databaseContest.AddContestInfo();

            //DatabaseContest databaseContest = new DatabaseContest();
            //databaseContest.AddContest();

            DatabasePerson databasePerson = new DatabasePerson();
            List<Person> persons = databasePerson.FetchPersons();

            Console.WriteLine("Skriv ut personer:");
            foreach (var person in persons)
            {
                Console.Write(person.ID + ": " + person.GetFullName() + " " + person.Age + "\n");
            }

            Console.ReadKey();
        }
    }
}

