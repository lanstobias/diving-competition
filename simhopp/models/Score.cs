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
            this.Value = 0;
        }

        // for testing purposes
        public Score(double value)
        {
            this.Value = value;
        }

        public Score(double value, Judge judge)
        {
            this.Value = value;
            this.Judge = judge;
        }

        public double Value { get; set; }
        public Judge Judge { get; set; }

    }
}
