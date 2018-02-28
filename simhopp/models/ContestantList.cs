using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class ContestantList : List<Contestant>
    {
        public ContestantList()
            : base()
        {

        }

        internal bool Exists(Contestant diver)
        {
            foreach(var c in this)
            {
                if (c == diver)
                    return true;
            }

            return false;
        }

        public ContestantList DeepCopy()
        {
            ContestantList contestantList = new ContestantList();

            foreach(var c in this)
            {
                contestantList.Add(new Contestant(c.ID, c.FirstName, c.LastName, c.Age, c.Email, c.Gender, c.SocialSecurityNr, c.Address, c.DiveLists.ToList()));
            }

            return contestantList;
        }
    }
}
