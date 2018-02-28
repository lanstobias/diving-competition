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

        internal bool Exists(Dive dive)
        {
            foreach (var d in this)
            {
                if (d == dive)
                    return true;
            }

            return false;
        }

        public DiveList DeepCopy()
        {
            DiveList diveList = new DiveList(this.SubContestBranch);

            foreach (var d in this)
            {
                diveList.Add(new Dive(d.Code, d.Scores));
            }

            return diveList;
        }

    }
}
