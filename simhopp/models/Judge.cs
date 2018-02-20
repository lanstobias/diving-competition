using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Judge : Person
    {
        public Judge()
            : base()
        {
        }

        // constructor for easy testing
        public Judge(string firstName, string lastName)
            : base(0, firstName, lastName, 0, "", "", "", "")
        {
        }

        public Judge(int ID = 0, String firstName = "", String lastName = "", int age = 0, String email = "", String gender = "male", String SSN = "", String address = "")
            : base(ID, firstName, lastName, age, email, gender, SSN, address)
        { 
        }
    }
}
