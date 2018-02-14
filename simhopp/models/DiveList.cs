using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class DiveList : List<Dive>
    {

        public SubContestBranch SubContestBranch { get; set; }

        #region Constructor(s)
        public DiveList(SubContestBranch subContestBranch)
            : base()
        {
            this.SubContestBranch = subContestBranch;
        }

        #endregion
    }
}
