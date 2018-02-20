using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    /// <summary>
    /// This class inherits from Dictionary to store pairs of Contestants and their total score for a certain contest or subContest.
    /// </summary>
    public class ResultDictionary : Dictionary<Contestant, double>
    {
        public void Sort()
        {
            var sortedDict = this.OrderByDescending(x => x.Value).ToList();

            this.Clear();

            foreach (var val in sortedDict)
                this.Add(val.Key, val.Value);
            
        }
    }
}
