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
        /// <param name="Diver">The Contestant who made the dive</param>
        /// <param name="DiveToBeAdded">The dive</param>
        public void AddNewDive(Contestant Diver, Dive DiveToBeAdded)
        {
            if (this.BranchContestants.Contains(Diver))
            {

                // If this is the first dive of this Contestant, create a new DiveList connected to this branch,
                // and then add the dive.
                if (Diver.DiveLists.Count == 0)
                {
                    Diver.DiveLists.Add(new DiveList(this));
                    Diver.DiveLists.ElementAt(0).Add(DiveToBeAdded);
                }
                // if it is not the first dive, go through the DiveList(s) and see if any of them match with
                // this branch. If no such list exists, create it and add the dive.
                else
                {
                    foreach (var list in Diver.DiveLists)
                    {
                        if (list.SubContestBranch == this)
                        {
                            list.Add(DiveToBeAdded);
                            break;
                        }
                        else
                        {
                            Diver.DiveLists.Add(new DiveList(this));
                            Diver.DiveLists.Last().Add(DiveToBeAdded);
                            break;
                        }
                    }
                }
            }
            
        }
        #endregion
    }
}
