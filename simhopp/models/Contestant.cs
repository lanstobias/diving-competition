using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    class Contestant
    {
        #region Properties
        //
        // Properites
        //
        public List<DiveList> DiveLists { get; set; }

        #endregion

        #region Constructor(s)
        public Contestant()
        {
            DiveLists = null;
        }

        public Contestant(List<DiveList> diveLists)
        {
            this.DiveLists = diveLists;
        }
        #endregion


    }
}
