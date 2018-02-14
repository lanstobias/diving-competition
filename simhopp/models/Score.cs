using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Score
    {
        public Score()
        {

        }

        public Score(double value)
        {
            this.Value = value;
        }

        public double Value { get; set; }
        public Judge Judge { get; set; }

    }
}
