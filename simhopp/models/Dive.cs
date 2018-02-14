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
            Scores = null;
        }

        public Dive(DiveCode code)
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

        /// <summary>
        /// Generates the raw total score of the dive, without removing the ends.
        /// </summary>
        /// <returns>double with the raw score</returns>
        public double generateRawScore()
        {
            double RawScore = 0;
            foreach (var score in Scores)
                RawScore += score.Value;

            RawScore = RawScore * this.Code.Multiplier;
            return RawScore;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double generateFinalizedScore()
        {
            double FinalizedScore = 0;
            generateScoresWithoutFirstAndLastScore();
            return FinalizedScore;
        }

        /// <summary>
        /// Removes the end scores as per official rules
        /// </summary>
        /// <returns>New list with the valid scores</returns>
        public ScoreList generateScoresWithoutFirstAndLastScore()
        {
            ScoreList ScoresWithoutFirstAndLastScore = null;
            
            // i start at 1 to skip first
            for(int i = 1; i < Scores.Count; i++)
            {
                if (i == Scores.Count - 1)
                    break;
                ScoresWithoutFirstAndLastScore.Add(Scores[i]);
            }
            return ScoresWithoutFirstAndLastScore;
        }

        #endregion
    }
}
