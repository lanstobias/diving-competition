using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Denna klass är en Gren, vi valde namnet SubContestBranch eftersom namnet Event eller DiveEvent skulle kunna skapa förviring. Detta namn förvirar kanske också, men inte lika mycket ansåg vi.
namespace Simhopp
{
    public class SubContestBranch
    {

        public SubContestBranch()
        {

        }

        public string Name { get; set; }
        public Contest ParentContest { get; set; }
    }
}
