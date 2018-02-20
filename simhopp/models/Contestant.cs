using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Contestant : Person
    {
        #region Properties
        //
        // Properites
        //
        public List<DiveList> DiveLists { get; set; }

        #endregion

        #region Constructor(s)
        public Contestant()
            : base()
        {
            DiveLists = new List<DiveList>();
        }

        // constructor for easy testing
        public Contestant(string name)
            : base(0, name, "", 0, "", "", "", "")
        {
            DiveLists = new List<DiveList>();
        }

        public Contestant(List<DiveList> diveLists)
            : base()
        {
            this.DiveLists = diveLists;
        }

        // without divelist
        public Contestant(int ID, String firstName, String lastName, int age, String email, String gender, String SSN, String address)
            : base(ID, firstName, lastName, age, email, gender, SSN, address)
        {
            DiveLists = new List<DiveList>();
        }

        // with existing divelist
        public Contestant(int ID, String firstName, String lastName, int age, String email, String gender, String SSN, String address, List<DiveList> diveLists)
            : base(ID, firstName, lastName, age, email, gender, SSN, address)
        {
            DiveLists = diveLists;
        }
        #endregion


    }
}
