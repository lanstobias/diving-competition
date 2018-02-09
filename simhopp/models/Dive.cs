using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simhopp.models
{
    class Dive
    {
        public Dive()
        {

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
