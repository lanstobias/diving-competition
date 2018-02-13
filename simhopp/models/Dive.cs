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

<<<<<<< HEAD
        public Dive(DiveCode code, ScoreList scores)
        {
            this.Code = code;
            this.Scores = scores;
        }
        
=======
>>>>>>> 53ceb6a348dbf99d4a01c0970b1cf9a1f72d6888
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

        public ScoreList generateScoresWithoutFirstAndLastScore()
        {
            ScoreList ScoresWithoutFirstAndLastScore = null;
            return ScoresWithoutFirstAndLastScore;
        }
    }
}
