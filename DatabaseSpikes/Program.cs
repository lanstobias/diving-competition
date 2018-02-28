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
            DatabasePerson databasePerson = new DatabasePerson();
            databasePerson.AddPerson();
            
            Console.ReadKey();
        }
    }
}

