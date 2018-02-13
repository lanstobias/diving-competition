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

        public DiveCode Code
        {
            get;set;
        }

        public ScoreList Scores
        {
            get;set;
        }

        public double generateRawScore()
        {
            double RawScore = 0;

            return RawScore;
        }

        public double generateFinalizedScore()
        {
            double FinalizedScore = 0;
            generateScoresWithoutFirstAndLastScore();
            return FinalizedScore;
        }
    }
}
