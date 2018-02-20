using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Denna klass är en Gren, vi valde namnet SubContestBranch eftersom namnet Event eller DiveEvent skulle kunna skapa förviring. Detta namn förvirar kanske också, men inte lika mycket ansåg vi.
namespace Simhopp
{
    public class SubContestBranch
    {

        public SubContestBranch()
        {
            Name = "-";
            ParentContest = null;
            BranchContestants = new ContestantList();
        }

        public SubContestBranch(string name, Contest parentContest, ContestantList branchContestants)
        {
            this.Name = name;
            this.ParentContest = parentContest;
            this.BranchContestants = branchContestants;
        }

        public string Name { get; set; }
        public Contest ParentContest { get; set; }

        public ContestantList BranchContestants { get; set; }

        #region Methods

        /// <summary>
        /// Add a new dive to the correct divelist of a Contestant
        /// </summary>
        /// <param name="diver">The Contestant who made the dive</param>
        /// <param name="diveToBeAdded">The dive</param>
        public void AddNewDive(Contestant diver, Dive diveToBeAdded)
        {
            if (this.BranchContestants.Contains(diver))
            {

                // If this is the first dive of this Contestant, create a new DiveList connected to this branch,
                // and then add the dive.
                if (diver.DiveLists.Count == 0)
                {
                    diver.DiveLists.Add(new DiveList(this));
                    diver.DiveLists.ElementAt(0).Add(diveToBeAdded);
                }
                // if it is not the first dive, go through the DiveList(s) and see if any of them match with
                // this branch. If no such list exists, create it and add the dive.
                else
                {
                    foreach (var list in diver.DiveLists)
                    {
                        if (list.SubContestBranch == this)
                        {
                            list.Add(diveToBeAdded);
                            break;
                        }
                        else
                        {
                            diver.DiveLists.Add(new DiveList(this));
                            diver.DiveLists.Last().Add(diveToBeAdded);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Remove an existing dive from a contestants DiveList bound to this branch
        /// </summary>
        /// <param name="diver">The Contestant to have his dive removed</param>
        /// <param name="diveToBeRemoved">The dive in question</param>
        public bool RemoveExistingDive(Contestant diver, Dive diveToBeRemoved)
        {
            if(BranchContestants.Exists(diver))
            {
                foreach (var list in diver.DiveLists)
                {
                    if (list.Exists(diveToBeRemoved))
                    {
                        list.Remove(diveToBeRemoved);
                        return true;
                    }
                }
            }
            return false;
            
        }

        /// <summary>
        /// Generates a dictionary containing all the contestants and their total score in this subcontest.
        /// Sorts it in descending order with the winner first.
        /// ResultDictionary inherits from Dictionary<Contestant, double> 
        /// </summary>
        /// <returns>A ResultDictionary object</returns>
        public ResultDictionary GenerateSubContestResult()
        {
            ResultDictionary resultDictionary = new ResultDictionary();
            double sum = 0;

            foreach(var diver in BranchContestants)
            {
                foreach(var diveList in diver.DiveLists)
                {
                    if(diveList.SubContestBranch == this)
                    {
                        foreach(var dive in diveList)
                            sum += dive.generateFinalizedScore();
                        
                        resultDictionary.Add(diver, sum);
                        sum = 0;
                    }
                }
            }

            resultDictionary.Sort();
            return resultDictionary;
        }

        #endregion
    }
}
