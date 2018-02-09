using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Person
    {

        #region Properties
        public int ID { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int Age { get; set; } 

        public String Email { get; set; }

        public String Gender { get; set; }

        public String SocialSecurityNr { get; set; }

        public String Address { get; set; }
        #endregion

        public Person()
        {

        }

        public Person(int ID, String FirstName, String LastName, int Age, String Email, String Gender, String SSN, String Address)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Email = Email;
            this.Gender = Gender;
            this.SocialSecurityNr = SSN;
            this.Address = Address;
        }



    }
}
