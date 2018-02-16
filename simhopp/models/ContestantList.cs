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
    }
}
