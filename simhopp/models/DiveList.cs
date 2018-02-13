using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    class DiveList : List<Dive>
    {

        public SubContestBranch SubContest { get; set; }

        #region Constructor(s)
        public DiveList(SubContestBranch subContest)
            : base()
        {
            this.SubContest = SubContest;
        }

        #endregion
    }
}
