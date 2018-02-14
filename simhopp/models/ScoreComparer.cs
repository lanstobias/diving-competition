using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class ScoreComparer : IComparer<Score>
    {
        public int Compare(Score scoreOne, Score scoreTwo)
        {
            if (scoreOne == null)
            {
                if (scoreTwo == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (scoreTwo == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare by Score values
                    int retval = scoreOne.Value.CompareTo(scoreTwo.Value);

                    if (retval != 0)
                    {
                        // If the names are not equal 
                        // 
                        //
                        return retval;
                    }
                    else
                    {
                        // If the strings are equal length,
                        // sort them by male names string comparison.
                        //
                        return scoreOne.Judge.FirstName.CompareTo(scoreTwo.Judge.FirstName);
                        // return scoreOne.Male.Name.CompareTo(scoreTwo.Male.Name);
                    }
                }
            }
        }
    }
}
