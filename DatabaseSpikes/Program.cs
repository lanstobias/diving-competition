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

            List<Judge> judges = databasePerson.FetchJudges();

            Console.WriteLine("\nSkriv ut domare:");
            foreach (var judge in judges)
            {
                Console.Write(judge.ID + ": " + judge.GetFullName() + " " + judge.Age + "\n");
            }

            List<Contestant> contestants = databasePerson.FetchContestants();

            Console.WriteLine("\nSkriv ut dykare:");
            foreach (var contestant in contestants)
            {
                Console.Write(contestant.ID + ": " + contestant.GetFullName() + " " + contestant.Age + "\n");
            }

            Console.ReadKey();
        }
    }
}

