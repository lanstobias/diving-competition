using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    class Dive
    {
        #region Constructor(s)
        public Dive()
        {

        }
        
        public Dive(DiveCode code, ScoreList scores)
        {
            this.Code = code;
            this.Scores = scores;
        }
        #endregion

        #region Properties

        public DiveCode Code
        {
            get;set;
        }

        public ScoreList Scores
        {
            get;set;
        }

        #endregion

        #region Functions

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

        #endregion
    }
}
