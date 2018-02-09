using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simhopp.models
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



    }
}
