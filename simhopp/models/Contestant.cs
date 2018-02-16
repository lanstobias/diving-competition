using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Contestant : Person
    {
        #region Properties
        //
        // Properites
        //
        public List<DiveList> DiveLists { get; set; }

        #endregion

        #region Constructor(s)
        public Contestant()
            : base()
        {
            DiveLists = null;
        }

        public Contestant(List<DiveList> diveLists)
            : base()
        {
            this.DiveLists = diveLists;
        }
        #endregion


    }
}
