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
        //
        // Properties
        //
        public ContestInfo Info { get; set; }

        public JudgeList Judges { get; set; }

        public ContestantList Contestants { get; set; }

        public SubContestBranchList SubContestBranches { get; set; }

        #endregion

        #region Contructor(s)
        //
        // Default constructor
        //
        public Contest()
        {
            Info = null;
            Judges = null;
            Contestants = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Object containing info about contest</param>
        /// <param name="judges">List of judges</param>
        /// <param name="contestants">list of contestants</param>
        public Contest(ContestInfo info, JudgeList judges, ContestantList contestants)
        {
            this.Info = info;
            this.Judges = judges;
            this.Contestants = contestants;
        }
        #endregion


    }
}
