using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    class Dive
    {
        public Dive()
        {

        }

        public Dive(DiveCode code, ScoreList scores)
        {
            this.Code = code;
            this.Scores = scores;
        }
        
        public DiveCode Code
        {
            get;set;
        }
        public ScoreList Scores
        {
            get;set;
        }
    }
}
