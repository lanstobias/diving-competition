using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp.Models
{
    class Contest
    {
        #region Properties
        public ContestInfo Info { get; set; }

        public JudgeList Judges { get; set; }

        public ContestList Contestants { get; set; }

        public DiveList Dives { get; set; }

        #endregion

        #region Contructor(s)
        public Contest()
        {

        }
        #endregion

    }
}
