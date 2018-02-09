using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    class Contest
    {
        #region Properties
        public ContestInfo Info { get; set; }

        public JudgeList Judges { get; set; }

        public ContestantList Contestants { get; set; }

        public DiveList Dives { get; set; }

        #endregion

        #region Contructor(s)
        public Contest()
        {
            Info = null;
            Judges = null;
            Contestants = null;
            Dives = null;
        }

        public Contest(ContestInfo info, JudgeList judges, ContestantList contestants, DiveList dives)
        {
            this.Info = info;
            this.Judges = judges;
            this.Contestants = contestants;
            this.Dives = dives;
        }


        #endregion

    }
}
