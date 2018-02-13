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
        public DiveList Dives { get; set; }

        #endregion

        #region Constructor(s)
        public Contestant()
        {
            Dives = null;
        }

        public Contestant(DiveList dives)
        {
            this.Dives = dives;
        }
        #endregion


    }
}
