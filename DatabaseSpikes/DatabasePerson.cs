using System;
using Simhopp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSpikes
{
    public class DatabasePerson
    {
        public DatabasePerson()
        {

        }

        public void AddPerson()
        {
            Person bob = new Person(1, "Bob", "Dylan", 89, "hej@hej.com", "male", "2324324", "pappersgatan");
            Database database = new Database();

            try
            {
                database.StorePerson(bob);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
