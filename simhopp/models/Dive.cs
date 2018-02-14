using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Dive
    {
        #region Constructor(s)
        public Dive()
        {
            Scores = null;
        }

        public Dive(DiveCode code)
        {
            this.Code = code;
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
            ScoreList scoresWithoutFirstAndLastScore = generateScoresWithoutFirstAndLastScore();

            //Summering av alla poäng
            foreach (var scores in scoresWithoutFirstAndLastScore)
            {
                FinalizedScore += scores.Value;
            }
            
            FinalizedScore *= Code.Multiplier;

            return FinalizedScore;
        }

        /// <summary>
        /// Removes the end scores as per official rules
        /// </summary>
        /// <returns>New list with the valid scores</returns>
        public ScoreList generateScoresWithoutFirstAndLastScore()
        {
            ScoreList ScoresWithoutFirstAndLastScore = new ScoreList();

            SortScoreListAscending();

            // sums all the scores
            // i start at 1 to skip first
            if (Scores.Count > 2)
            {
                for (int i = 1; i < Scores.Count; i++)
                {
                    // skip last
                    if (i == Scores.Count - 1)
                        break;

                    ScoresWithoutFirstAndLastScore.Add(Scores[i]);
                }
            }
            else
                return Scores;

            return ScoresWithoutFirstAndLastScore;
        }

        public void SortScoreListAscending()
        {
            ScoreComparer scoreComparer = new ScoreComparer();
            Scores.Sort(scoreComparer);
        }

        #endregion
    }
}
